using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.New_Components;

namespace TomeOfTheFirebird.Modified_Content.ImprovedMultiarchetypeProjct
{
    class SpellSlots
    {
        public static void Execute()
        {
            return;
            BlueprintGuid deriveGUID = Main.TotFContext.Blueprints.GetDerivedMaster("DiminishedSpellcastingMaster");
            //TODO Eldritch Font - from mod, not sure which, Arcanist with +1 spells per day / -1 spells prepped

            //Bard:
            //Arrowsong from CharacterCreationExpansion - check if using spellbook for anything but slot change! Probably is!


            //Cleric - angelfire
            FixArchetypeWithFeature("857bc9fadf70f294795a9cba974a48b8", 1, "e3219e7f8055cd54e8324a3ba0fff576");//Angelfire Apostile
            
            //TODO: TTB ChannelerOfTheUnknown - will need extra work because multi domain slots

            //Crusader!
            FixArchetypeWithoutExistingFeature("6bfb7e74b530f3749b590286dd2b9b30", 1, "Crusader", "Cleric", "A crusader chooses only one domain and gains one fewer spell of each level than normal. If this reduces the number to 0, she may cast spells of that level only if they are domain spells or if her Wisdom allows bonus spells of that level.");

            //Magus: Sword Saint

            FixArchetypeWithoutExistingFeature("7d6678f2160018049814838af2ab4236", 1, "Sword Saint", "Magus", "A sword saint may cast one fewer spell of each level than normal. If this reduces the number to 0, he may cast spells of that level only if his casting attribute allows bonus spells of that level.");

            void FixArchetypeWithoutExistingFeature(string archetype, int slotReduction, string archetypeName, string classname, string desc, string overrideSysname = "")
            {
                BlueprintArchetype arch = BlueprintTool.Get<BlueprintArchetype>(archetype);
                arch.m_ReplaceSpellbook = null;
                BlueprintFeature feature = MakerTools.MakeSpellsPerDayChangeFeature(arch.ToReference<BlueprintArchetypeReference>(), archetypeName, classname, desc, overrideSysname, slotReduction * -1);

                LevelEntry level1 = arch.AddFeatures.FirstOrDefault(x => x.Level == 1);
                if (level1 == null)
                {
                    level1 = new LevelEntry() { m_Features = new List<BlueprintFeatureBaseReference>() { feature.ToReference<BlueprintFeatureBaseReference>() } };
                }
                else
                {
                    level1.m_Features.Add(feature.ToReference<BlueprintFeatureBaseReference>());
                }

                Main.TotFContext.Logger.LogPatch("Patched Spellbook And Added Feature For Multi Archetype Compatibility", arch);

            }
            
            void FixArchetypeWithFeature(string archetype, int slotReduction, string feature)
            {
                BlueprintArchetype arch = BlueprintTool.Get<BlueprintArchetype>(archetype);
                arch.m_ReplaceSpellbook = null;
                

                MakerTools.ApplySpellsPerDayChangeToFeature(feature, arch.GetParentClass().ToReference<BlueprintCharacterClassReference>(), slotReduction * -1);
                Main.TotFContext.Logger.LogPatch("Patched Spellbook For Multi Archetype Compatibility", arch);
            }
        }

        /*
        [HarmonyPatch(typeof(Spellbook), nameof(Spellbook.GetSpellsPerDay), new Type[] { typeof(int) })]
        static class Spellbook_GetSpellsPerDay
        {
            static void Postfix(Spellbook __instance, ref int __result, int spellLevel)
            {
                
                    var part = __instance.Owner.Get<AllLevelsSpellSlotShiftPart>();
                    if (part != null && !__instance.IsStandaloneMythic)
                    {
                        ModifiableValueAttributeStat modifiableValueAttributeStat = __instance.Owner.Stats.GetStat(__instance.Blueprint.CastingAttribute) as ModifiableValueAttributeStat;
                        if (part.Changes.TryGetValue(__instance.Blueprint.ToReference<BlueprintSpellbookReference>(), out var shift))
                        {
                            //Recalculating bonus spells because I cannot be arsed to write an interpiler right now
                            int bonusSpells = 0;
                            int bonus = __instance.Owner.IsPlayerFaction ? (modifiableValueAttributeStat.Bonus - spellLevel) : ((modifiableValueAttributeStat.BaseValue - 10) / 2 - spellLevel);
                            if (bonus >= 0 && spellLevel > 0)
                            {
                                bonusSpells = bonus / 4 + 1;
                                
                            }

                            int newVal = __result + shift.ShiftVal;
                            if (newVal < bonusSpells)
                            {
                                __result = bonusSpells;
                            }
                            else
                            {
                                __result = newVal;
                            }

                        }

                    }


                


            }

        }
        */
    }
}

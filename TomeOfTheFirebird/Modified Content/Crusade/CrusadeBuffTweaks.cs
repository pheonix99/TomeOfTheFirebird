using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Blueprints.Classes;
using Kingmaker.ElementsSystem;
using Kingmaker.Kingdom.Actions;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Kingdom.Buffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.Config;

namespace TomeOfTheFirebird.Modified_Content.Crusade
{
    public class CrusadeBuffTweaks
    {
        public static void PermaMonsterSlayers()
        {
            if (ModSettings.ContentModifications.Crusade.IsDisabled("MonsterSlayers"))
                return;
            BlueprintKingdomBuff monsterSlayers = Resources.GetBlueprint<BlueprintKingdomBuff>("c1b2b611c9b242b4ae84944eb0eb9e91");
            monsterSlayers.DurationDays = 0;
            monsterSlayers.Description = LocalizationTool.CreateString("MonsterSlayersRe.Desc", "All units gain the {g|ReadyForAnything}[Ready for Anything]{/g} feat.", true);

            BlueprintKingdomProject monsterslayerseven = Resources.GetBlueprint<BlueprintKingdomProject>("f4a53d4ac414477cad6778326708383d");
            monsterslayerseven.Solutions.Entries.FirstOrDefault(x => x.Leader == Kingmaker.Kingdom.LeaderType.General).Resolutions.FirstOrDefault(x => x.Margin == EventResult.MarginType.Success).Actions.Actions.OfType<KingdomActionAddBuff>().FirstOrDefault().OverrideDuration = 0;

            monsterslayerseven.m_MechanicalDescription = LocalizationTool.CreateString("MonsterSlayersRe2.Desc", "All units gain the {g|ReadyForAnything}[Ready for Anything]{/g} feat.", true);

        }

        public static void PermaLocalProduction()
        {
            if (ModSettings.ContentModifications.Crusade.IsDisabled("LocalProduction"))
                return;
            Blades();
            Bows();
            Spells();
            Ponies();
            void Blades()
            {
                BlueprintKingdomProject blades = Resources.GetBlueprint<BlueprintKingdomProject>("840e284399994927908b3861ef3d6f26");
                ActionList bladesActions = blades.Solutions.Entries.FirstOrDefault(x => x.Leader == Kingmaker.Kingdom.LeaderType.General).Resolutions.FirstOrDefault(x => x.Margin == EventResult.MarginType.Success).Actions;

                PermBuffsFromList(bladesActions);
                Main.LogPatch("Patched", blades);
                DeRepeatable(blades);
                var BladesDesc = LocalizationTool.CreateString("BladesGearTweakDesc.Desc", "All infantry and cavalry units gain the {g|FineSteel}[Fine Steel]{/g} feat.", true); ;

                blades.m_MechanicalDescription = BladesDesc;

                BlueprintKingdomBuff bladesBuff = Resources.GetBlueprint<BlueprintKingdomBuff>("455137c7bda24e6eb0a858cfb7bb911f");
                bladesBuff.Description = BladesDesc;

                Main.LogPatch("Desc modded", bladesBuff);
                MakeTacFeatureVisible(bladesBuff);
            }
            void Bows()
            {

                BlueprintKingdomProject bows = Resources.GetBlueprint<BlueprintKingdomProject>("033d121cf3564b86a88dbad9cb13222c");
                ActionList bowsActions = bows.Solutions.Entries.FirstOrDefault(x => x.Leader == Kingmaker.Kingdom.LeaderType.General).Resolutions.FirstOrDefault(x => x.Margin == EventResult.MarginType.Success).Actions;
                DeRepeatable(bows);
                PermBuffsFromList(bowsActions);
                Main.LogPatch("Patched", bows);

                var BowDesc = LocalizationTool.CreateString("BowGearTweakDesc.Desc", "All ranged units gain the {g|DeadlyAmmunition}[Serrated Arrows]{/g} feat.", true); ;

                bows.m_MechanicalDescription = BowDesc;
                BlueprintKingdomBuff bowsBuff = Resources.GetBlueprint<BlueprintKingdomBuff>("c0b9fa7ccc9546ffa97ca9fee334fa9f");
                bowsBuff.Description = BowDesc;
                Main.LogPatch("Desc modded", bowsBuff);

                //BlueprintFeature FineSteel = Resources.GetBlueprint<BlueprintFeature>("81da3d34baea4914b5f525770e2b843d");
                //FineSteel.HideInUI = false;
                //FineSteel.HideInCharacterSheetAndLevelUp = false;
                //FineSteel.AddComponents(new TacticalCombatVisibleFeature());
                MakeTacFeatureVisible(bowsBuff);

            }

            void Spells()
            {
                BlueprintKingdomProject spells = Resources.GetBlueprint<BlueprintKingdomProject>("6ad5bd92d86b46eaa088b643aa59e0c8");
                ActionList spellsActions = spells.Solutions.Entries.FirstOrDefault(x => x.Leader == Kingmaker.Kingdom.LeaderType.General).Resolutions.FirstOrDefault(x => x.Margin == EventResult.MarginType.Success).Actions;
                DeRepeatable(spells);
                PermBuffsFromList(spellsActions);
                Main.LogPatch("Patched", spells);

                var SpellDesc = LocalizationTool.CreateString("SpellcasterGearTweakDesc.Desc", "All spellcasting units gain the {g|ProtectiveTalismans}[Protective Talismans]{/g} feat.", true); ;

                spells.m_MechanicalDescription = SpellDesc;
                BlueprintKingdomBuff spellsBuff = Resources.GetBlueprint<BlueprintKingdomBuff>("6da7dac332424bd589345ee1383d70f2");
                spellsBuff.Description = SpellDesc;
                Main.LogPatch("Desc modded", spellsBuff);
                MakeTacFeatureVisible(spellsBuff);

            }
            void Ponies()
            {
                BlueprintKingdomProject azataPonies = Resources.GetBlueprint<BlueprintKingdomProject>("5e7a2d84d1fa4cb8ad983c77c0da93b6");
                ActionList azataPoniesActions = azataPonies.Solutions.Entries.FirstOrDefault(x => x.Leader == Kingmaker.Kingdom.LeaderType.Diplomat).Resolutions.FirstOrDefault(x => x.Margin == EventResult.MarginType.Success).Actions;
                DeRepeatable(azataPonies);
                PermBuffsFromList(azataPoniesActions);
                Main.LogPatch("Patched", azataPonies);
                var PoniesDesc = LocalizationTool.CreateString("AzataPoniesTweakDesc.Desc", "All cavalry units gain the {g|EnchantedMounts}[Enchanted Mounts]{/g} feat.", true); ;

                azataPonies.m_MechanicalDescription = PoniesDesc;
                BlueprintKingdomBuff poniesBuff = Resources.GetBlueprint<BlueprintKingdomBuff>("7fc82e5db09b47899195e72039818660");
                poniesBuff.Description = PoniesDesc;
                Main.LogPatch("Desc modded", poniesBuff);
                MakeTacFeatureVisible(poniesBuff);
            }
            static void PermBuffsFromList(ActionList l)
            {
                foreach (var v in l.Actions.OfType<KingdomActionAddBuff>())
                {
                    v.OverrideDuration = 0;
                   
                }


            }

            static void MakeTacFeatureVisible(BlueprintKingdomBuff buff)
            {
                foreach(var v in buff.Components.OfType<KingdomTacticalArmyFeature>())
                {
                    foreach(var v2 in v.Features)
                    {
                        BlueprintFeature tac = v2.Get();
                        if (!tac.Components.Any(x=>x is TacticalCombatVisibleFeature))
                        {
                            tac.AddComponents(new TacticalCombatVisibleFeature());
                            Main.LogPatch("Made Tactical Feature Visible: ", tac);
                        }
                    }
                }
                Main.LogPatch("Made Tactical Features Show: ", buff);
            }

            static void DeRepeatable(BlueprintKingdomProject target)
            {
                target.Repeatable = false;
            }
        }

    }
}

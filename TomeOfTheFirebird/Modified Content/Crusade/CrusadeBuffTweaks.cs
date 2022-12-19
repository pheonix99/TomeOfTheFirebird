using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Blueprints.Classes;
using Kingmaker.ElementsSystem;
using Kingmaker.Kingdom.Actions;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Kingdom.Buffs;
using System.Linq;
using TabletopTweaks.Core.Utilities;

namespace TomeOfTheFirebird.Modified_Content.Crusade
{
    public class CrusadeBuffTweaks
    {
        public static void PermaMonsterSlayers()
        {
            if (Main.TotFContext.ContentModifications.Crusade.IsDisabled("MonsterSlayers"))
                return;
            BlueprintKingdomBuff monsterSlayers = BlueprintTools.GetBlueprint<BlueprintKingdomBuff>("c1b2b611c9b242b4ae84944eb0eb9e91");
            monsterSlayers.DurationDays = 0;
            monsterSlayers.Description = LocalizationTool.CreateString("MonsterSlayersRe.Desc", "All units gain the {g|ReadyForAnything}[Ready for Anything]{/g} feat.", true);

            BlueprintKingdomProject monsterslayerseven = BlueprintTools.GetBlueprint<BlueprintKingdomProject>("f4a53d4ac414477cad6778326708383d");
            monsterslayerseven.Solutions.Entries.FirstOrDefault(x => x.Leader == Kingmaker.Kingdom.LeaderType.General).Resolutions.FirstOrDefault(x => x.Margin == EventResult.MarginType.Success).Actions.Actions.OfType<KingdomActionAddBuff>().FirstOrDefault().OverrideDuration = 0;

            monsterslayerseven.m_MechanicalDescription = LocalizationTool.CreateString("MonsterSlayersRe2.Desc", "All units gain the {g|ReadyForAnything}[Ready for Anything]{/g} feat.", true);

        }

        public static void PermaLocalProduction()
        {
            if (Main.TotFContext.ContentModifications.Crusade.IsDisabled("LocalProduction"))
                return;
            Blades();
            Bows();
            Spells();
            Ponies();
            void Blades()
            {
                BlueprintKingdomProject blades = BlueprintTools.GetBlueprint<BlueprintKingdomProject>("840e284399994927908b3861ef3d6f26");
                ActionList bladesActions = blades.Solutions.Entries.FirstOrDefault(x => x.Leader == Kingmaker.Kingdom.LeaderType.General).Resolutions.FirstOrDefault(x => x.Margin == EventResult.MarginType.Success).Actions;

                PermBuffsFromList(bladesActions);
                Main.TotFContext.Logger.LogPatch("Patched", blades);
                DeRepeatable(blades);
                Kingmaker.Localization.LocalizedString BladesDesc = LocalizationTool.CreateString("BladesGearTweakDesc.Desc", "All infantry and cavalry units gain the {g|FineSteel}[Fine Steel]{/g} feat.", true); ;

                blades.m_MechanicalDescription = BladesDesc;

                BlueprintKingdomBuff bladesBuff = BlueprintTools.GetBlueprint<BlueprintKingdomBuff>("455137c7bda24e6eb0a858cfb7bb911f");
                bladesBuff.Description = BladesDesc;

                Main.TotFContext.Logger.LogPatch("Desc modded", bladesBuff);
                MakeTacFeatureVisible(bladesBuff);
            }
            void Bows()
            {

                BlueprintKingdomProject bows = BlueprintTools.GetBlueprint<BlueprintKingdomProject>("033d121cf3564b86a88dbad9cb13222c");
                ActionList bowsActions = bows.Solutions.Entries.FirstOrDefault(x => x.Leader == Kingmaker.Kingdom.LeaderType.General).Resolutions.FirstOrDefault(x => x.Margin == EventResult.MarginType.Success).Actions;
                DeRepeatable(bows);
                PermBuffsFromList(bowsActions);
                Main.TotFContext.Logger.LogPatch("Patched", bows);

                Kingmaker.Localization.LocalizedString BowDesc = LocalizationTool.CreateString("BowGearTweakDesc.Desc", "All ranged units gain the {g|DeadlyAmmunition}[Serrated Arrows]{/g} feat.", true); ;

                bows.m_MechanicalDescription = BowDesc;
                BlueprintKingdomBuff bowsBuff = BlueprintTools.GetBlueprint<BlueprintKingdomBuff>("c0b9fa7ccc9546ffa97ca9fee334fa9f");
                bowsBuff.Description = BowDesc;
                Main.TotFContext.Logger.LogPatch("Desc modded", bowsBuff);

                //BlueprintFeature FineSteel = Resources.GetBlueprint<BlueprintFeature>("81da3d34baea4914b5f525770e2b843d");
                //FineSteel.HideInUI = false;
                //FineSteel.HideInCharacterSheetAndLevelUp = false;
                //FineSteel.AddComponents(new TacticalCombatVisibleFeature());
                MakeTacFeatureVisible(bowsBuff);

            }

            void Spells()
            {
                BlueprintKingdomProject spells = BlueprintTools.GetBlueprint<BlueprintKingdomProject>("6ad5bd92d86b46eaa088b643aa59e0c8");
                ActionList spellsActions = spells.Solutions.Entries.FirstOrDefault(x => x.Leader == Kingmaker.Kingdom.LeaderType.General).Resolutions.FirstOrDefault(x => x.Margin == EventResult.MarginType.Success).Actions;
                DeRepeatable(spells);
                PermBuffsFromList(spellsActions);
                Main.TotFContext.Logger.LogPatch("Patched", spells);

                Kingmaker.Localization.LocalizedString SpellDesc = LocalizationTool.CreateString("SpellcasterGearTweakDesc.Desc", "All spellcasting units gain the {g|ProtectiveTalismans}[Protective Talismans]{/g} feat.", true); ;

                spells.m_MechanicalDescription = SpellDesc;
                BlueprintKingdomBuff spellsBuff = BlueprintTools.GetBlueprint<BlueprintKingdomBuff>("6da7dac332424bd589345ee1383d70f2");
                spellsBuff.Description = SpellDesc;
                Main.TotFContext.Logger.LogPatch("Desc modded", spellsBuff);
                MakeTacFeatureVisible(spellsBuff);

            }
            void Ponies()
            {
                BlueprintKingdomProject azataPonies = BlueprintTools.GetBlueprint<BlueprintKingdomProject>("5e7a2d84d1fa4cb8ad983c77c0da93b6");
                ActionList azataPoniesActions = azataPonies.Solutions.Entries.FirstOrDefault(x => x.Leader == Kingmaker.Kingdom.LeaderType.Diplomat).Resolutions.FirstOrDefault(x => x.Margin == EventResult.MarginType.Success).Actions;
                DeRepeatable(azataPonies);
                PermBuffsFromList(azataPoniesActions);
                Main.TotFContext.Logger.LogPatch("Patched", azataPonies);
                Kingmaker.Localization.LocalizedString PoniesDesc = LocalizationTool.CreateString("AzataPoniesTweakDesc.Desc", "All cavalry units gain the {g|EnchantedMounts}[Enchanted Mounts]{/g} feat.", true); ;

                azataPonies.m_MechanicalDescription = PoniesDesc;
                BlueprintKingdomBuff poniesBuff = BlueprintTools.GetBlueprint<BlueprintKingdomBuff>("7fc82e5db09b47899195e72039818660");
                poniesBuff.Description = PoniesDesc;
                Main.TotFContext.Logger.LogPatch("Desc modded", poniesBuff);
                MakeTacFeatureVisible(poniesBuff);
            }
            static void PermBuffsFromList(ActionList l)
            {
                foreach (KingdomActionAddBuff v in l.Actions.OfType<KingdomActionAddBuff>())
                {
                    v.OverrideDuration = 0;
                   
                }


            }

            static void MakeTacFeatureVisible(BlueprintKingdomBuff buff)
            {
                foreach(KingdomTacticalArmyFeature v in buff.Components.OfType<KingdomTacticalArmyFeature>())
                {
                    foreach(Kingmaker.Blueprints.BlueprintFeatureReference v2 in v.Features)
                    {
                        BlueprintFeature tac = v2.Get();
                        if (!tac.Components.Any(x=>x is TacticalCombatVisibleFeature))
                        {
                            BlueprintCore.Utils.BlueprintExtensions.AddComponents(tac, new TacticalCombatVisibleFeature());
                            
                            Main.TotFContext.Logger.LogPatch("Made Tactical Feature Visible: ", tac);
                        }
                    }
                }
                Main.TotFContext.Logger.LogPatch("Made Tactical Features Show: ", buff);
            }

            static void DeRepeatable(BlueprintKingdomProject target)
            {
                target.Repeatable = false;
            }
        }

    }
}

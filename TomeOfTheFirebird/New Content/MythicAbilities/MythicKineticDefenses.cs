using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.UnitLogic.Class.Kineticist.Properties;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.NewComponents.Properties;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.New_Components;
using UnityModManagerNet;

namespace TomeOfTheFirebird.New_Content.MythicAbilities
{
    class MythicKineticDefenses
    {
        public static void Make()
        {
            string shroudFeatureid = "29ec36fa2a5b8b94ebce170bd369083a";
            string searingFleshId = "8ad77685e64842c45a6f5b19f9086c6c";
            string fleshOfStoneId = "a275b35f282601944a97e694f6bc79f8";
            string windsId = "bb0de2047c448bd46aff120be3b39b7a";

            BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator effectfeatureConfig = Helpers.MakerTools.MakeFeature("MythicKineticDefensesEffectFeature", "Mythic Kinetic Aegis", "Mythic power augments your defensive wild talents. Core kinetic defenses now act as if you'd enhanceed them with a point of burn for free, gaining another virtual point at MR 3, 6, and 9");

            //effectfeatureConfig.AddIncreaseResourceAmount(resource: "1f4eeef738e694c44aad070a0b3d64a2", value: -1);//Decrease Water Upgrade Resource 
            //effectfeatureConfig.AddIncreaseResourceAmount(resource: "081b766c9a8c1b84fa0b38b46912451c", value: -1);//Decrease Fire Upgrade Resource 
            //effectfeatureConfig.AddIncreaseResourceAmount(resource: "a942347023fedb2419f8bdbb4450e528", value: -1);//Decrease Earth Upgrade Resource 
            //effectfeatureConfig.AddIncreaseResourceAmount(resource: "f3ed2974316feb344afacc0d7ada3ace", value: -1);//Decrease Wind Upgrade Resource 

            BlueprintFeature effectbuilt = effectfeatureConfig.Configure();
            Main.TotFContext.Logger.LogPatch(effectbuilt);
            ProgressionConfigurator prog = Helpers.MakerTools.MakeProg("MythicKineticDefensesProgression", "Mythic Kinetic Defenses", "Mythic power augments your defensive wild talents. Core kinetic defenses now act as if you'd enhanceed them with a point of burn for free, gaining another virtual point at MR 3, 6, and 9");
            prog.AddHideFeatureInInspect();
            prog.SetHideInCharacterSheetAndLevelUp(true);
            prog.SetHideInUI(true);
            prog.SetHideNotAvailibleInUI(true);
            prog.AddToLevelEntries(1, effectbuilt);
            prog.AddToLevelEntries(3, effectbuilt);
            prog.AddToLevelEntries(6, effectbuilt);
            prog.AddToLevelEntries(9, effectbuilt);
            prog.SetGiveFeaturesForPreviousLevels(true);
            prog.SetClasses("530b6a79cb691c24ba99e1577b4beb6d", "5d501618a28bdc24c80007a5c937dcb7", "15a85e67b7d69554cab9ed5830d0268e", "211f49705f478b3468db6daa802452a2", "9a3b2c63afa79744cbca46bea0da9a16", "a5a9fe8f663d701488bd1db8ea40484e", "8df873a8c6e48294abdb78c45834aa0a", "247aa787806d5da4f89cfc3dff0b217f", "8e19495ea576a8641964102d177e34b7", "daf1235b6217787499c14e4e32142523", "3d420403f3e7340499931324640efe96");

            BlueprintProgression progBuilt = prog.Configure();
            Main.TotFContext.Logger.LogPatch(progBuilt);
            BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator featureConfig = Helpers.MakerTools.MakeFeature("MythicKineticDefenses", "Mythic Kinetic Aegis", "Mythic power augments your defensive wild talents. Core kinetic defenses now act as if you'd enhanceed them with a point of burn for free, gaining another virtual point at MR 3, 6, and 9");
            featureConfig.AddToGroups(FeatureGroup.MythicAbility);
            
            featureConfig.AddFacts(facts: new() { progBuilt });
            featureConfig.AddPrerequisiteFeature(shroudFeatureid, group: Prerequisite.GroupType.Any);
            featureConfig.AddPrerequisiteFeature(searingFleshId, group: Prerequisite.GroupType.Any);
            featureConfig.AddPrerequisiteFeature(fleshOfStoneId, group: Prerequisite.GroupType.Any);
            featureConfig.AddPrerequisiteFeature(windsId, group: Prerequisite.GroupType.Any);
            BlueprintFeature built = featureConfig.Configure();

            Main.TotFContext.Logger.LogPatch(built);
            if (Main.TotFContext.NewContent.MythicAbilities.IsDisabled("MythicKineticAegis"))
                return;
            FixFleshOfStone();
            FixEnvelopingWinds();
            FixShroudOfWater();
            FixSearingFlesh();
            void FixFleshOfStone()
            {
                string fleshOfStoneEffectFeatureID = "a942347023fedb2419f8bdbb4450e528";
                BlueprintFeature fosEffectFeature = BlueprintTool.Get<BlueprintFeature>(fleshOfStoneEffectFeatureID);
                ContextRankConfig scalingConfig = fosEffectFeature.GetComponents<ContextRankConfig>(x => x.m_Type == Kingmaker.Enums.AbilityRankType.DamageDice).FirstOrDefault();//Because Vek needs to kill getComponent because it collides with the vanilla exentsion
                scalingConfig.m_BaseValueType = ContextRankBaseValueType.FeatureListRanks;
                scalingConfig.m_FeatureList = new BlueprintFeatureReference[]
                {
                    scalingConfig.m_Feature,
                    effectbuilt.ToReference<BlueprintFeatureReference>()
                };
                RecalculateOnFactsChange recalcer = fosEffectFeature.GetComponent<RecalculateOnFactsChange>();
                recalcer.m_CheckedFacts = recalcer.m_CheckedFacts.AppendToArray(effectbuilt.ToReference<BlueprintUnitFactReference>());

                Main.TotFContext.Logger.LogPatch("Patched in Mythic Kinetic Aegis", fosEffectFeature);
            }

            void FixEnvelopingWinds()
            {
                string envelopingWindsBuffGUID = "b803fcd9da7b1564fb52978f08372767";//EvelopingWindsBuff
                BlueprintBuff envelopingWindsBuff = BlueprintTool.Get<BlueprintBuff>(envelopingWindsBuffGUID);
                ContextRankConfig scalingConfig = envelopingWindsBuff.GetComponents<ContextRankConfig>(x => x.m_Type == Kingmaker.Enums.AbilityRankType.Default).FirstOrDefault();//Because Vek needs to kill getComponent because it collides with the vanilla exentsion
                scalingConfig.m_BaseValueType = ContextRankBaseValueType.FeatureListRanks;
                scalingConfig.m_FeatureList = new BlueprintFeatureReference[]
                {
                    scalingConfig.m_Feature,
                    effectbuilt.ToReference<BlueprintFeatureReference>()
                };
                RecalculateOnFactsChange recalcer = envelopingWindsBuff.GetComponent<RecalculateOnFactsChange>();
                recalcer.m_CheckedFacts = recalcer.m_CheckedFacts.AppendToArray(effectbuilt.ToReference<BlueprintUnitFactReference>());


                Main.TotFContext.Logger.LogPatch("Patched in Mythic Kinetic Aegis", envelopingWindsBuff);
            }

            void FixShroudOfWater()
            {
                string shroudUpgradeFeatureId = "fc083e19a8c961c4890de1a36e2b5c20";
                BlueprintFeature upgradeEffectFeature = BlueprintTool.Get<BlueprintFeature>(shroudUpgradeFeatureId);
                FixArmor();
                void FixArmor()
                {
                    string shroudArmorEffecFeaturetId = "1ff803cb49f63ea4185490fae2c43ca7";
                    BlueprintFeature armorEffectFeature = BlueprintTool.Get<BlueprintFeature>(shroudArmorEffecFeaturetId);

                    ShroudOfWater existingComp = armorEffectFeature.GetComponent<ShroudOfWater>();
                    if (existingComp is not CustomShroudOfWater)
                    {
                        armorEffectFeature.RemoveComponents<ShroudOfWater>();
                        armorEffectFeature.AddComponent<CustomShroudOfWater>(x =>
                        {
                            x.m_UpgradeFeature = upgradeEffectFeature.ToReference<BlueprintFeatureReference>();
                            x.Descriptor = Kingmaker.Enums.ModifierDescriptor.Armor;
                            x.Stat = Kingmaker.EntitySystem.Stats.StatType.AC;
                            x.BaseValue = new Kingmaker.UnitLogic.Mechanics.ContextValue()
                            {
                                ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Shared,
                                Value = 0,
                                ValueRank = Kingmaker.Enums.AbilityRankType.Default,
                                ValueShared = Kingmaker.UnitLogic.Abilities.AbilitySharedValue.Damage
                            };
                            x.m_UpgradeFeatures = new List<BlueprintFeatureReference>()
                            {
                            effectbuilt.ToReference<BlueprintFeatureReference>()
                            };
                        });
                    }
                    else
                    {
                        (existingComp as CustomShroudOfWater).m_UpgradeFeatures.Add(effectbuilt.ToReference<BlueprintFeatureReference>());
                    }
                    RecalculateOnFactsChange recalcer = armorEffectFeature.GetComponent<RecalculateOnFactsChange>();
                    recalcer.m_CheckedFacts = recalcer.m_CheckedFacts.AppendToArray(effectbuilt.ToReference<BlueprintUnitFactReference>());
                    Main.TotFContext.Logger.LogPatch("Patched in Mythic Kinetic Aegis", armorEffectFeature);
                }
                FixShield();
                void FixShield()
                {
                    string shroudshieldEffecFeaturetId = "4d8feca11d6e29a499ae761b90eacdba";
                    BlueprintFeature shieldEffectFeature = BlueprintTool.Get<BlueprintFeature>(shroudshieldEffecFeaturetId);

                    ShroudOfWater existingComp = shieldEffectFeature.GetComponent<ShroudOfWater>();
                    if (existingComp is not CustomShroudOfWater)
                    {
                        shieldEffectFeature.RemoveComponents<ShroudOfWater>();
                        shieldEffectFeature.AddComponent<CustomShroudOfWater>(x =>
                        {
                            x.Descriptor = Kingmaker.Enums.ModifierDescriptor.Shield;
                            x.Stat = Kingmaker.EntitySystem.Stats.StatType.AC;
                            x.BaseValue = new Kingmaker.UnitLogic.Mechanics.ContextValue()
                            {
                                ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Shared,
                                Value = 0,
                                ValueRank = Kingmaker.Enums.AbilityRankType.Default,
                                ValueShared = Kingmaker.UnitLogic.Abilities.AbilitySharedValue.Damage
                            };
                            x.m_UpgradeFeature = upgradeEffectFeature.ToReference<BlueprintFeatureReference>();
                            x.m_UpgradeFeatures = new List<BlueprintFeatureReference>()
                            {
                            effectbuilt.ToReference<BlueprintFeatureReference>()
                            };
                        });
                    }
                    else
                    {
                        (existingComp as CustomShroudOfWater).m_UpgradeFeatures.Add(effectbuilt.ToReference<BlueprintFeatureReference>());
                    }
                    RecalculateOnFactsChange recalcer = shieldEffectFeature.GetComponent<RecalculateOnFactsChange>();
                    recalcer.m_CheckedFacts = recalcer.m_CheckedFacts.AppendToArray(effectbuilt.ToReference<BlueprintUnitFactReference>());
                    Main.TotFContext.Logger.LogPatch("Patched in Mythic Kinetic Aegis", shieldEffectFeature);
                }

              


            }

           
            void FixSearingFlesh()
            {
                string searingFleshEffectFeature = "642bb6097c37b3b4b8be1f46d2d9296e";
                BlueprintFeature searingFleshEffect = BlueprintTool.Get<BlueprintFeature>(searingFleshEffectFeature);
                if (searingFleshEffect == null)
                {
                    Main.TotFContext.Logger.LogError("searingFleshEffect is null on searingflesh");
                }
                ContextRankConfig scalingConfig = searingFleshEffect.GetComponents<ContextRankConfig>(x => x.m_Type == Kingmaker.Enums.AbilityRankType.Default).FirstOrDefault();//Because Vek needs to kill getComponent because it collides with the vanilla exentsion
                if (scalingConfig == null)
                {
                    Main.TotFContext.Logger.LogError("ScalingConfig is null on searingflesh");
                }
                scalingConfig.m_BaseValueType = ContextRankBaseValueType.FeatureListRanks;
                scalingConfig.m_FeatureList = new BlueprintFeatureReference[]
                {
                    scalingConfig.m_Feature,
                    effectbuilt.ToReference<BlueprintFeatureReference>()
                };
               
                Main.TotFContext.Logger.LogPatch("Patched in Mythic Kinetic Aegis", searingFleshEffect);
            }
          
            

            FeatTools.AddAsMythicAbility(built);
            

            
        }

       public static void MakeLater()
        {
            if (Main.TotFContext.NewContent.MythicAbilities.IsDisabled("MythicKineticAegis"))
                return;
            if (UnityModManager.FindMod("KineticistElementsExpanded")?.Enabled == true)
            {


                BlueprintFeature built = BlueprintTool.Get<BlueprintFeature>("MythicKineticDefenses");
                BlueprintFeature mythicEffectFeature = BlueprintTool.Get<BlueprintFeature>("MythicKineticDefensesEffectFeature");
                FixForceWard();
                FixEmptiness();
                FixFleshOfWood();
                void FixForceWard()
                {
                    string forceWardHPPropertyid = "f84ce6cafefb4080957f0559676fa980";
                    BlueprintUnitProperty forceWardHPProperty = BlueprintTool.Get< BlueprintUnitProperty>(forceWardHPPropertyid);
                    IEnumerable<PropertyValueGetter> getters = forceWardHPProperty.GetComponents<PropertyValueGetter>();
                    PropertyValueGetter getterToEdit = getters.FirstOrDefault(x => x is not ClassLevelGetter);//Does this look insane? Yes. Is it the best way to mess around with a custom class from another mod? Yeah probably
                    forceWardHPProperty.RemoveComponent(getterToEdit);
                    string forceWardEffectFeatureid = "4710d10f66304a8eaf5cb835f94e9453";

                    forceWardHPProperty.AddComponent<FeatureRanksWithExtrasPropertyValueGetter>(x =>
                    {
                        x.bonus = 4;
                        x.Features.Add(built.ToReference<BlueprintFeatureReference>());
                        x.Features.Add(BlueprintTool.GetRef<BlueprintFeatureReference>(forceWardEffectFeatureid));
                    });


                    /*mythicEffectFeature.AddComponent<IncreaseResourceAmount>(x =>
                    {
                        x.Value = -1;
                        x.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>("1997f2da4ed94209983de569fb2b1125");
                    });*/

                    BlueprintFeature aetherFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("772d6eb030d547d6b9f85e599ec9fef1");
                    built.AddPrerequisiteFeature(aetherFeature, Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any);
                    Main.TotFContext.Logger.LogPatch("Patched in Mythic Kinetic Aegis", forceWardHPProperty);
                }

                //aether



                //void
                void FixEmptiness()
                {
                    string emptinessEffectBuffID = "9226ccc4238f44d6b9efa66ccf32a3d9";
                    BlueprintBuff emptinessEffectBuff = BlueprintTool.Get<BlueprintBuff>(emptinessEffectBuffID);
                    if (emptinessEffectBuff == null)
                    {
                        Main.TotFContext.Logger.LogError("emptinessBuff is null on emptineess");
                    }
                    ContextRankConfig scalingConfig = emptinessEffectBuff.GetComponents<ContextRankConfig>(x => x.m_Type == Kingmaker.Enums.AbilityRankType.StatBonus).FirstOrDefault();//Because Vek needs to kill getComponent because it collides with the vanilla exentsion
                    if (scalingConfig == null)
                    {
                        Main.TotFContext.Logger.LogError("ScalingConfig is null on emptineess");
                    }
                    scalingConfig.m_BaseValueType = ContextRankBaseValueType.FeatureListRanks;
                    scalingConfig.m_FeatureList = new BlueprintFeatureReference[]
                    {
                        scalingConfig.m_Feature,
                        mythicEffectFeature.ToReference<BlueprintFeatureReference>()
                    };
                    /*mythicEffectFeature.AddComponent<IncreaseResourceAmount>(x =>
                    {
                        x.Value = -1;
                        x.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>("210861baca74448fb7486f0dffc22150");
                    });*/

                    RecalculateOnFactsChange recalcer = emptinessEffectBuff.GetComponent<RecalculateOnFactsChange>();
                    recalcer.m_CheckedFacts = recalcer.m_CheckedFacts.AppendToArray(mythicEffectFeature.ToReference<BlueprintUnitFactReference>());

                    BlueprintFeature negativeFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("92de8ee602184f1eb81434edc204a7b5");
                    built.AddPrerequisiteFeature(negativeFeature, Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any);
                    Main.TotFContext.Logger.LogPatch("Patched in Mythic Kinetic Aegis", emptinessEffectBuff);
                }



                //wood

                void FixFleshOfWood()
                {
                    string fleshOfWoodBuffid = "925b8a3794aa417e8b2d8a0fbf089255";
                    BlueprintBuff fleshOfWoodBuf = BlueprintTool.Get<BlueprintBuff>(fleshOfWoodBuffid);
                    if (fleshOfWoodBuf == null)
                    {
                        Main.TotFContext.Logger.LogError("fleshOfWoodBuf is null on fleshOfWood");
                    }
                    ContextRankConfig scalingConfig = fleshOfWoodBuf?.GetComponents<ContextRankConfig>(x => x.m_Type == Kingmaker.Enums.AbilityRankType.Default).FirstOrDefault();//Because Vek needs to kill getComponent because it collides with the vanilla exentsion
                    if (scalingConfig == null)
                    {
                        Main.TotFContext.Logger.LogError("ScalingConfig is null on fleshOfWood");
                    }
                    scalingConfig.m_BaseValueType = ContextRankBaseValueType.FeatureListRanks;
                    scalingConfig.m_FeatureList = new BlueprintFeatureReference[]
                    {
                        scalingConfig.m_Feature,
                        mythicEffectFeature.ToReference<BlueprintFeatureReference>()
                    };
                    /*mythicEffectFeature.AddComponent<IncreaseResourceAmount>(x =>
                    {
                        x.Value = -1;
                        x.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>("9ccaff4d3095448b87d4dab29357d5db");
                    });*/

                    RecalculateOnFactsChange recalcer = fleshOfWoodBuf.GetComponent<RecalculateOnFactsChange>();
                    recalcer.m_CheckedFacts = recalcer.m_CheckedFacts.AppendToArray(mythicEffectFeature.ToReference<BlueprintUnitFactReference>());

                    BlueprintFeature negativeFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("12617b1537b749a0b7a4e30d2627ba7a");
                    built.AddPrerequisiteFeature(negativeFeature, Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any);
                    Main.TotFContext.Logger.LogPatch("Patched in Mythic Kinetic Aegis", fleshOfWoodBuf);
                }

                BlueprintFeature woodFeature = BlueprintTool.Get<BlueprintFeature>("12617b1537b749a0b7a4e30d2627ba7a");
               
            }
            else
            {
                Main.TotFContext.Logger.Log("Expanded Elements Not Found, skipping aether, void and wood when making Mythic Kinetic Defenses");
            }
        }

        /*
         * Defense talents act as if 1 point of burn had been invested +1 at MR 3/6/9
         * Adaptation talents act as if burn was 1 higher per MR
         * 
         * 
         */

    }
}

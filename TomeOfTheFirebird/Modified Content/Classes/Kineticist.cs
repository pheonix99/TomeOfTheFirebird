﻿using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Utils;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using System.Collections.Generic;
using System.Linq;
using TabletopTweaks.Core.NewComponents;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.New_Components;
using UnityModManagerNet;

namespace TomeOfTheFirebird.Modified_Content.Classes
{
    class Kineticist
    {
        public static void PatchKineticistLate()
        {

            AddInternalBuffer();
            
            

            FixElementalDefenseAbility("25fc1cc07ea34f94eb6fbbce473767b4", "bbba1600582cf8446bb515a33bd89af8");//EnvelopingWInds
            FixElementalDefenseAbility("4332f1dfd6f93194abfd0440dfb8e4aa", "a942347023fedb2419f8bdbb4450e528");//FleshOfStone
            FixElementalDefenseAbility("04a61f1221b79a742912cfd847b65911", "642bb6097c37b3b4b8be1f46d2d9296e");//SearingFlesh
            FixElementalDefenseAbility("84d77a1c06b800545aacd91210d3505c", "fc083e19a8c961c4890de1a36e2b5c20");//ShroudOfWater
           
            MakeAbilityRequireNotAlreadyActive("41281aa38b6b27f4fa3a05c97cc01783");//AerialEvasion 
            return;

            

            void AddInternalBuffer()
            {
                if (Settings.IsDisabled("InternalBuffer"))
                    return;

                BlueprintFeature buffer = BlueprintTool.Get<BlueprintFeature>("InternalBufferFeature");
                BlueprintFeature bufferEU = BlueprintTool.Get<BlueprintFeature>("InternalBufferExtraUseFeature");



                BlueprintProgression kinProgression = BlueprintTool.Get<BlueprintProgression>("b79e92dd495edd64e90fb483c504b8df");


                kinProgression.LevelEntries.FirstOrDefault(x => x.Level == 6).m_Features.Add(buffer.ToReference<BlueprintFeatureBaseReference>());
                kinProgression.LevelEntries.FirstOrDefault(x => x.Level == 11).m_Features.Add(bufferEU.ToReference<BlueprintFeatureBaseReference>());
                kinProgression.LevelEntries.FirstOrDefault(x => x.Level == 16).m_Features.Add(bufferEU.ToReference<BlueprintFeatureBaseReference>());


                BlueprintArchetype darkElementalist = BlueprintTool.Get<BlueprintArchetype>("f12f18ae8842425489d29f302e69134c");
                ArchetypeConfigurator.For(darkElementalist).AddToRemoveFeatures(6, buffer).AddToRemoveFeatures(11, bufferEU).AddToRemoveFeatures(16, bufferEU).Configure();


                BlueprintArchetype overwhelmingSoul = BlueprintTool.Get<BlueprintArchetype>("aa11888104d17f7459851e8d559ffa98");
                ArchetypeConfigurator.For(overwhelmingSoul).AddToRemoveFeatures(6, buffer).AddToRemoveFeatures(11, bufferEU).AddToRemoveFeatures(16, bufferEU).Configure();
            }
            
        }

        public static void PatchKinecicistLast()
        {
            CreateBloodBlade();
            void CreateBloodBlade()
            {
                BlueprintItemWeapon BloodKineticBladeWeapon = BlueprintTool.Get<BlueprintItemWeapon>("92f9a719ffd652947ab37363266cc0a6");
                BlueprintAbility bloodBlastBase = BlueprintTool.Get<BlueprintAbility>("ba2113cfed0c2c14b93c20e7625a4c74");
                BlueprintFeature kineticBladeINfusion = BlueprintTool.Get<BlueprintFeature>("9ff81732daddb174aa8138ad1297c787");

                
                BlueprintAbility BloodKineticBladeBlastBurn = BlueprintTool.Get<BlueprintAbility>("15278f2a9a5eaa441a261ec033b60b57");
                BlueprintActivatableAbility KinetidBladeBloodBlastAbilty = BlueprintTool.Get<BlueprintActivatableAbility>("98f0da4bf25a34a4caffa6b8a2d33ef6");

                FeatureConfigurator BloodKineticBladeFeatureConfig = MakerTools.MakeFeature("TOTF_BloodKineticBladeFeature", LocalizationTool.GetString("BloodKineticBladeSystem.Name"), LocalizationTool.GetString("Blank"), icon: BloodKineticBladeWeapon.Icon);
                BloodKineticBladeFeatureConfig.SetHideInUI(true);
                BloodKineticBladeFeatureConfig.SetIsClassFeature(true);
                BloodKineticBladeFeatureConfig.SetHideInCharacterSheetAndLevelUp(true);
                if (false)
                //if (Settings.IsEnabled("BloodKineticBlade"))
                {
                    BloodKineticBladeFeatureConfig.AddFeatureIfHasFact(checkedFact: BloodKineticBladeBlastBurn, feature: BloodKineticBladeBlastBurn, not: true);
                    BloodKineticBladeFeatureConfig.AddFeatureIfHasFact(checkedFact: KinetidBladeBloodBlastAbilty, feature: KinetidBladeBloodBlastAbilty, not: true);
                    AbilityConfigurator.For("0a386b1c2b4ae9b4f81ddf4557155810").RemoveComponents(x => x is SpellDescriptorComponent).EditComponent<AbilityKineticist>(x =>
                    {
                        x.BlastBurnCost = 2;
                        x.CachedDamageInfo.Remove(x.CachedDamageInfo.First(x => x.Type.Type == Kingmaker.RuleSystem.Rules.Damage.DamageType.Energy));
                        var chached = x.CachedDamageInfo.First(x => (x.Type.Type == Kingmaker.RuleSystem.Rules.Damage.DamageType.Physical));
                        chached.Half = false;

                    }).AddAbilityDeliverProjectile(needAttackRoll:true, projectiles: new List<Blueprint<BlueprintProjectileReference>>() { "06e268d6a2b5a3a438c2dd52d68bfef6" }, type: AbilityProjectileType.Simple, isHandOfTheApprentice: false, length: new Kingmaker.Utility.Feet(0f), lineWidth: new Kingmaker.Utility.Feet(5f), weapon: "65951e1195848844b8ab8f46d942f6e8", replaceAttackRollBonusStat: false, useMaxProjectilesCount: false, delayBetweenProjectiles: 0f, maxProjectilesCountRank: Kingmaker.Enums.AbilityRankType.Default).Configure();
                }
                BlueprintFeature BloodKineticBladeFeature = BloodKineticBladeFeatureConfig.Configure();

                BlueprintWeaponEnchantment waterblade = BlueprintTool.Get<BlueprintWeaponEnchantment>("d3f4abb0b4c10094ba61833e2b730b4f");

               

               

                if (false)
                //if (Settings.IsEnabled("BloodKineticBlade"))
                {
                    WeaponEnchantmentConfigurator.For("f2e21757f4b5b2541861cf59f3249a48").SetWeaponFxPrefab(waterblade.WeaponFxPrefab).SetEnchantName("BloodBladeEnchant.Name").EditComponent<ContextCalculateSharedValue>(x =>
                    {
                        x.Value.DiceCountValue.ValueRank = Kingmaker.Enums.AbilityRankType.DamageDice;
                        x.Value.BonusValue.ValueRank = Kingmaker.Enums.AbilityRankType.DamageBonus;

                    }).Configure();

                    ItemWeaponConfigurator.For("92f9a719ffd652947ab37363266cc0a6").SetDisplayNameText(BlueprintTool.Get<BlueprintAbility>("ab6e3f470fba2d349b7b7ef0990b5476").m_DisplayName).Configure();
                    
                    FeatureConfigurator.For(kineticBladeINfusion).AddFeatureIfHasFact(checkedFact: bloodBlastBase, feature: BloodKineticBladeFeature).SetReapplyOnLevelUp().Configure();
                    AbilityConfigurator.For("80f10dc9181a0f64f97a9f7ac9f47d65").EditComponent<AbilityCasterHasFacts>(x =>
                    {
                        x.m_Facts = x.m_Facts.AddItem<BlueprintUnitFactReference>(BlueprintTool.GetRef<BlueprintUnitFactReference>("badb94b7adfc5eb40bf85eb14085142c")).ToArray();
                    });
                    Main.TotFContext.Logger.LogPatch("Built and added", BloodKineticBladeFeature);
                }
            }
        }

        private static void MakeAbilityRequireNotAlreadyActive(string abilityGuid)
        {
            BlueprintAbility ability = BlueprintTool.Get<BlueprintAbility>(abilityGuid);
            AbilityEffectRunAction action = ability.GetComponent<AbilityEffectRunAction>();
            ContextActionApplyBuff applyBuff = action.Actions.Actions.OfType<ContextActionApplyBuff>().FirstOrDefault();
            BlueprintBuffReference buff = applyBuff.m_Buff;
            ability.RemoveComponents<AbilityResourceLogic>();
            ability.AddComponent<AbilityRequirementHasBuff>(x =>
            {
                x.RequiredBuff = buff;
                x.Not = true;
            });
            ability.RemoveComponents<AbilityAcceptBurnOnCast>();
            AbilityConfigurator.For(ability).AddAbilityKineticist(amount: 1, wildTalentBurnCost: 1).Configure();
            Main.TotFContext.Logger.LogPatch("Replaced resource with AbilityRequirement", ability);
        }

        private static void FixElementalDefenseAbility(string abilityGuid, string stackingFactguid)
        {
            
            BlueprintAbility ability = BlueprintTool.Get<BlueprintAbility>(abilityGuid);
            BlueprintAbilityResourceReference resource = ability.GetComponent<AbilityResourceLogic>().m_RequiredResource;
            if (resource == null)
            {
                Main.TotFContext.Logger.LogError($"Resource is null on {ability.name}");
                return;
            }


            BlueprintUnitFactReference buff = BlueprintTool.GetRef<BlueprintUnitFactReference>(stackingFactguid);
            if (buff == null)
            {
                Main.TotFContext.Logger.LogError($"buff is null on {ability.name}");
                return;
            }
            ability.RemoveComponents<AbilityAcceptBurnOnCast>();
            
            AbilityConfigurator.For(ability).AddAbilityKineticist(amount: 1, wildTalentBurnCost: 1).AddComponent< AbilityRestrictionWildTalentCastCapper>(x=> {

                x.m_facts = new List<BlueprintUnitFactReference>()
                {
                    buff

                };
                x.m_CapResource = resource;
                x.useCapResource = true;
                x.IsDefense = true;
                x.m_MythicKineticDefense = BlueprintTool.GetRef<BlueprintFeatureReference>("MythicKineticDefenses");
                
            }).Configure();
                
            

          

            Main.TotFContext.Logger.LogPatch("Updated handler for burn", ability);
            
        }

        public static void FixKEEAbilities()
        {
            if (UnityModManager.FindMod("KineticistElementsExpanded")?.Active == true)
            {
               
                FixElementalDefenseAbility("c4e945c830e842528d0fb89a30787fa0", "b16c53343ea447578306d79cfbcae43e");//FleshofWoodAbility
                FixElementalDefenseAbility("3a8b76ab4d1a45db8e9cb3ee0bda020a", "01f5444fcf5f4a3490411787c1f7db63");//Emptyness
                //FixForceWard();//ForceWard
                
                void FixForceWard()
                {
                    BlueprintAbility forceWardAbility = BlueprintTool.Get<BlueprintAbility>("9dd89afa73bf4e189808a2270deb0bb7");
                    forceWardAbility.RemoveComponents<AbilityAcceptBurnOnCast>();
                    AbilityConfigurator.For(forceWardAbility).AddAbilityKineticist(amount: 1, wildTalentBurnCost: 1).Configure();
                }
                
            }
        }
    }
}


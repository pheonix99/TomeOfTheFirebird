using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.NewComponents;
using TabletopTweaks.Core.Utilities;
//using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.New_Components.Prerequisites;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalModifierDescriptors;

namespace TomeOfTheFirebird.New_Content.RacialOptions
{
    static class Tiefling
    {
       static string elvenHeritageId = "5482f879dcfd40f9a3168fdb48bc938c";

        public static void Make()
        {
            if (Settings.IsEnabled("TieflingAlternateFeatures") || Settings.IsEnabled("ArmorOfThePit"))
            {
                var TieflingNAStacker = MakerTools.MakeFeature("TieflingNAStackerFeature", "Tiefling Natural Armor", "", true);
                TieflingNAStacker.SetRanks(3);
                TieflingNAStacker.AddStatBonus(ModifierDescriptor.NaturalArmorForm, stat: Kingmaker.EntitySystem.Stats.StatType.AC, value: 1);
                TieflingNAStacker.Configure();
            }
            else
            {
                MakerTools.MakeFeature("TieflingNAStackerFeature", "Tiefling Natural Armor", "", true).Configure();
            }
            List<DamageEnergyType> damageEnergyTypes = new() { DamageEnergyType.Fire, DamageEnergyType.Cold, DamageEnergyType.Electricity };
            if (Settings.IsEnabled("TieflingAlternateFeatures"))
            {

                List<string> TeiflingSLAs = new List<string>()
            {
                "ae9e3a143e40f20419aa2b1ec92e2e06",//Asura hideous laughter
                "81de55902e7caaf4398a5fbc9fe70123",
                "e6d3d5b1ffb576e4d9a4226d36fb3744",
                "2317930d7ccac3c469ab6ef130b2cfcc",
                "2be099877cf9c564788ac3896d272dd7",
                "11ea631b47b65aa4ba0e60c088602cf3",
                "bbaaf67996fae1c44b7d37073d74c016",
                "042b75d69603e7f4ca73ff148da1f270",
                "805bbe0b29fe2ae4f8a6e3da88d1fe3a",
                "f4f94ae005b810e4a99082fd1e367bb8",
                "f779120fd8e69ca48928e2457ef2a2a1",
                "1c044a499d1327a48b42676813c306c1",

                "ba27c690b06efad42ba7e5ca408d780b", //Kyton Web

                
                "120ffcf4fc599a34e96e307091491764",
                "71a0b8c29e35c6d4bb8a6d4dd8ccd33c"
            };

                foreach (var sla in TeiflingSLAs)
                {
                    Main.TotFContext.Logger.Log($"Tieflings SLA: {BlueprintTool.Get<BlueprintAbility>(sla).Name}");

                }

                
                var TieflingNoAlternateTrait = TabletopTweaks.Core.Utilities.Helpers.CreateBlueprint<BlueprintFeature>(Main.TotFContext, "TieflingNoAlternateTrait", bp =>
                {
                    bp.IsClassFeature = true;
                    bp.Ranks = 1;
                    bp.Groups = new FeatureGroup[] { FeatureGroup.Racial };
                    bp.HideInUI = true;
                    //bp.HideInCharacterSheetAndLevelUp = true;
                    bp.SetName(Main.TotFContext, "None");
                    bp.SetDescription(Main.TotFContext, "No Alternate Trait");
                });
                var noSLA = MakerTools.MakeFeature("TieflingNoSLAFeature", "No Racial SLA", "", hide: true).Configure();
                var chomp = MakerTools.MakeFeature("MawTieflingRacialFeature", "Maw or Claw (Maw)", "Some tieflings take on the more bestial aspects of their fiendish ancestors. These tieflings exhibit either powerful, toothy maws or dangerous claws. This tiefling gains a bite attack that deals 1d6 points of damage. These attacks are primary natural attacks. This racial trait replaces the spell-like ability racial trait.");
                chomp.AddAdditionalLimb("a000716f88c969c499a535dadcf09286");
                chomp.AddSLAReplacer(TeiflingSLAs);
                chomp.AddPrerequisiteNoFeature(feature: noSLA, hideInUI: true);
                chomp.AddFacts(facts: new() { noSLA });
                chomp.SetRanks(1);
                chomp.Configure();

                var icon = BlueprintTool.Get<BlueprintActivatableAbility>("f68af48f9ebf32549b5f9fdc4edfd475").Icon;

                var clawBuff = MakerTools.MakeBuff("ClawTieflingRacialBuff", "Maw or Claw (Claw)", "Some tieflings take on the more bestial aspects of their fiendish ancestors. These tieflings exhibit either powerful, toothy maws or dangerous claws. This tiefling gains two claws that each deal 1d4 points of damage. These attacks are primary natural attacks. This racial trait replaces the spell-like ability racial trait.", icon);
                clawBuff.AddEmptyHandWeaponOverride(isMonkUnarmedStrike: false, isPermanent: false, weapon: "118fdd03e569a66459ab01a20af6811a");
                clawBuff.Configure();
                
                
                var clawToggle = MakerTools.MakeToggle("ClawTieflingRacialToggle", "Maw or Claw (Claw)", "Some tieflings take on the more bestial aspects of their fiendish ancestors. These tieflings exhibit either powerful, toothy maws or dangerous claws. This tiefling gains two claws that each deal 1d4 points of damage. These attacks are primary natural attacks. This racial trait replaces the spell-like ability racial trait.", icon);
                clawToggle.SetBuff("ClawTieflingRacialBuff");
                clawToggle.SetActivationType(Kingmaker.UnitLogic.ActivatableAbilities.AbilityActivationType.WithUnitCommand);
                clawToggle.SetDeactivateIfCombatEnded(false).SetOnlyInCombat(false).SetDoNotTurnOffOnRest(true);


                clawToggle.Configure();
                var clawFeature = MakerTools.MakeFeature("ClawTieflingRacialFeature", "Maw or Claw (Claw)", "Some tieflings take on the more bestial aspects of their fiendish ancestors. These tieflings exhibit either powerful, toothy maws or dangerous claws. This tiefling gains two claws that each deal 1d4 points of damage. These attacks are primary natural attacks. This racial trait replaces the spell-like ability racial trait.");
                clawFeature.AddFacts(new() { "ClawTieflingRacialToggle" });
                clawFeature.AddSLAReplacer(TeiflingSLAs);
                clawFeature.AddPrerequisiteNoFeature(feature: noSLA, hideInUI: true);
                clawFeature.AddFacts(facts: new() { noSLA });
                clawFeature.SetRanks(1);
                clawFeature.Configure();

               
                foreach(var v in BlueprintTool.Get<BlueprintFeatureSelection>("c862fd0e4046d2d4d9702dd60474a181").AllFeatures)
                {
                    var slas = v.GetComponents<AddFacts>().FirstOrDefault().m_Facts;
                   

                    v.RemoveComponents<AddFacts>();
                    foreach (var sla in slas)
                    {
                        v.AddComponent<AddFeatureIfHasFact>(x =>
                        {
                            x.Not = true;
                            x.m_CheckedFact = noSLA.ToReference<BlueprintUnitFactReference>();
                            x.m_Feature = sla;
                        });
                        Main.TotFContext.Logger.LogPatch("Switching around", sla.Get());
                    }
                    
                }

                var scaledSkinConfigurator = MakerTools.MakeFeatureSelector("ScaledSkinTieflingRacialFeature", "Scaled Skin", "The skin of these tieflings provides some energy resistance, but is also as hard as armor. Choose one of the following energy types: cold, electricity, or fire. A tiefling with this trait gains resistance 5 in the chosen energy type and also gains a +1 natural armor bonus to AC. This racial trait replaces fiendish resistance.");
                scaledSkinConfigurator.SetRanks(1);
                scaledSkinConfigurator.SetGroups(FeatureGroup.Racial);
                
                FeatureConfigurator.For("c5b7ad498cca069499dc71b97cbe51fb").RemoveComponents(x => x is AddStatBonus addStatBonus && addStatBonus.Stat == Kingmaker.EntitySystem.Stats.StatType.AC).AddFacts(new() { "TieflingNAStackerFeature" }).Configure();
                
                
                foreach (var d in damageEnergyTypes)
                {
                    var config = MakerTools.MakeFeature($"ScaledSkinResist{d.ToString()}Feature", $"Scaled Skin: Resistant to {d.ToString()}", $"The skin of these tieflings provides some energy resistance, but is also as hard as armor. A tiefling with this trait gains resistance 5 to {d.ToString()} and also gains a +1 natural armor bonus to AC. This racial trait replaces fiendish resistance.");
                    config.AddResistEnergy(type: d, value: ContextValues.Constant(5));
                    config.SetRanks(1);
                    var done = config.Configure();

                    scaledSkinConfigurator.AddToAllFeatures(done);
                }
                var scaledSkinConfigurator2 = FeatureConfigurator.For(scaledSkinConfigurator.Configure());
                scaledSkinConfigurator2.AddTraitReplacment("c4029234bd17ee9488941ad7a14333f6");
                scaledSkinConfigurator2.AddFacts(facts: new List<Blueprint<BlueprintUnitFactReference>>() { "TieflingNAStackerFeature" });
                
                scaledSkinConfigurator2.Configure();

                var HeritageConfigurator = MakerTools.MakeFeatureSelector("TieflingAlternateTraitSelector", "Alternate Traits", "Various places and living conditions create sub-races differing from their peers. They gain unique racial {g|Encyclopedia:Trait}traits{/g} in exchange for losing some of the usual ones.");
                HeritageConfigurator.SetRanks(1);
                HeritageConfigurator.SetGroups(FeatureGroup.Racial);
                HeritageConfigurator.SetGroup(FeatureGroup.KitsuneHeritage);
                //HeritageConfigurator.SetGroup(FeatureGroup.TieflingHeritage);
                HeritageConfigurator.AddToAllFeatures(TieflingNoAlternateTrait);
                HeritageConfigurator.AddToAllFeatures("ScaledSkinTieflingRacialFeature");

                HeritageConfigurator.AddToAllFeatures("MawTieflingRacialFeature");
                HeritageConfigurator.AddToAllFeatures("ClawTieflingRacialFeature");
                HeritageConfigurator.AddComponent<PrerequisitePartyMember>(x =>
                { 
                    x.CheckInProgression = true;
                    x.HideInUI = true;
                    
                });
                var configDone = HeritageConfigurator.Configure();


                AddSelectionCallback("ScaledSkinTieflingRacialFeature", configDone);
                AddSelectionCallback("MawTieflingRacialFeature", configDone);
                AddSelectionCallback("ClawTieflingRacialFeature", configDone);

                RaceConfigurator.For("5c4e42124dc2b4647af6e36cf2590500").AddToFeatures("TieflingAlternateTraitSelector").Configure();
                //RaceConfigurator.For("5c4e42124dc2b4647af6e36cf2590500").AddToFeatures("41c8486641f7d6d4283ca9dae4147a9f").Configure();

                var woljifProg = BlueprintTool.Get<BlueprintFeature>("4bf1e3da22a4fe44f8a516cc24e6ef79");
                var adder = woljifProg.GetComponents<AddClassLevels>(x => !x.CharacterClass.IsMythic).FirstOrDefault();
                adder.Selections = adder.Selections.AppendToArray(new SelectionEntry
                {
                    m_Selection = configDone.ToReference<BlueprintFeatureSelectionReference>(),
                    m_Features = new BlueprintFeatureReference[] { TieflingNoAlternateTrait .ToReference<BlueprintFeatureReference>()}
                });
            }
            else
            {
                
                var noSLA = MakerTools.MakeFeature("TieflingNoSLAFeature", "No Racial SLA", "", hide: true).Configure();
                var TieflingNoAlternateTrait = TabletopTweaks.Core.Utilities.Helpers.CreateBlueprint<BlueprintFeature>(Main.TotFContext, "TieflingNoAlternateTrait", bp =>
                {
                    bp.SetName(Main.TotFContext, "None");
                    bp.SetDescription(Main.TotFContext, "No Alternate Trait");
                });
                var chomp = MakerTools.MakeFeature("MawTieflingRacialFeature", "Maw or Claw (Maw)", "Some tieflings take on the more bestial aspects of their fiendish ancestors. These tieflings exhibit either powerful, toothy maws or dangerous claws. This tiefling gains a bite attack that deals 1d6 points of damage. These attacks are primary natural attacks. This racial trait replaces the spell-like ability racial trait.").Configure();
                var claw = MakerTools.MakeFeature("ClawTieflingRacialFeature", "Maw or Claw (Claw)", "Some tieflings take on the more bestial aspects of their fiendish ancestors. These tieflings exhibit either powerful, toothy maws or dangerous claws. This tiefling gains two claws that each deal 1d4 points of damage. These attacks are primary natural attacks. This racial trait replaces the spell-like ability racial trait.").Configure();
                var scaledSkinConfigurator = MakerTools.MakeFeatureSelector("ScaledSkinTieflingRacialFeature", "Scaled Skin", "The skin of these tieflings provides some energy resistance, but is also as hard as armor. Choose one of the following energy types: cold, electricity, or fire. A tiefling with this trait gains resistance 5 in the chosen energy type and also gains a +1 natural armor bonus to AC. This racial trait replaces fiendish resistance.").Configure();
                foreach (var d in damageEnergyTypes)
                {
                    var config = MakerTools.MakeFeature($"ScaledSkinResist{d.ToString()}Feature", $"Scaled Skin: Resist {d.ToString()}", $"Resist {d.ToString()} 5");
             
                    var done = config.Configure();
                  
                }
                

                var HeritageConfigurator = MakerTools.MakeFeatureSelector("TieflingAlternateTraitSelector", "Alternate Traits", "Various places and living conditions create sub-races differing from their peers. They gain unique racial {g|Encyclopedia:Trait}traits{/g} in exchange for losing some of the usual ones.").Configure();
            }
        }

        private static void AddSelectionCallback(Blueprint<BlueprintReference<BlueprintFeature>> feature, BlueprintFeatureSelection selection)
        {

            FeatureConfigurator.For(feature).AddComponent<AddAdditionalRacialFeatures>(c => {
                c.Features = new BlueprintFeatureBaseReference[] { selection.ToReference<BlueprintFeatureBaseReference>() };
            }).Configure();
        }

        private static void AddTraitReplacment(this FeatureConfigurator feature, string replacement)
        {
            
            feature.AddRemoveFeatureOnApply(replacement).AddPrerequisiteFeature(replacement);

           
        }

        private static void AddSLAReplacer(this FeatureConfigurator feature, List<string> replacements)
        {
            foreach(var v in replacements)
            {
                feature.AddRemoveFeatureOnApply(v);
            }
            
            feature.AddComponent<PrerequisiteAbilityFromList>(x =>
            {
                x.m_Abilities = replacements.Select(y => BlueprintTool.GetRef<BlueprintAbilityReference>(y)).ToArray();
                x.Amount = 1;
            });
          


        }

        /*
         *  [PFS Legal] Scaled Skin
Source Advanced Race Guide pg. 169
The skin of these tieflings provides some energy resistance, but is also as hard as armor. Choose one of the following energy types: cold, electricity, or fire. A tiefling with this trait gains resistance 5 in the chosen energy type and also gains a +1 natural armor bonus to AC. This racial trait replaces fiendish resistance. 
         */

        /*
         *  [PFS Legal] Maw or Claw
Source Advanced Race Guide pg. 169
Some tieflings take on the more bestial aspects of their fiendish ancestors. These tieflings exhibit either powerful, toothy maws or dangerous claws. The tiefling can choose a bite attack that deals 1d6 points of damage or two claws that each deal 1d4 points of damage. These attacks are primary natural attacks. This racial trait replaces the spell-like ability racial trait.
         */
    }
}

using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using TomeOfTheFirebird.New_Components;

namespace TomeOfTheFirebird.Modified_Content.Items
{
    class AdoptPets
    {
        public static void Adopt()
        {
            var PetImpID = "ff0b6d4a4c0142344924711cb47f39d9";
            var PetOwlcatId = "6ea6d3b50bfa24e46a710beafbd95cd0";
            var pipefoxid = "53eaa254970205c4bb7d9c9813a25915";
            var petCat = "bcc767d66c7d2c74f9fe70b73c83c286";



        }

        private static void BuildPetFeature(string petGUID)
        {
            bool isLive = true;//TODO change
            var pet = BlueprintTool.Get<BlueprintItemEquipmentUsable>(petGUID);

            string extractedName = pet.name.Replace("Item", "");
            string adoptedFeatureSystemName = $"Adopted{extractedName}Feature";
            string adoptedSummonToggleAbilitySystemName = $"Adopted{extractedName}Ability";
            string adoptedSummonToggleBuffSystemName = $"Adopted{extractedName}Buff";

            List<BlueprintComponent> components = new List<BlueprintComponent>();
            var PetActivatable = pet.ActivatableAbility;
            var PetBuff = PetActivatable.Buff;
            AddFamiliar familiar = null;

            foreach (BlueprintComponent blueprintComponent in PetBuff.ComponentsArray)
            {
                if (blueprintComponent is AddFamiliar addFamiliar)
                {
                    familiar = addFamiliar;
                }
                else if (blueprintComponent is AddStatBonus statBonus)
                {
                    components.Add(statBonus);//Shouldn't be an issue copying this
                }
                else
                {
                    return;//Unhandled type, abort ASAP
                }
            }
            if (familiar == null)
            {
                isLive = false;
            }



            var buffguid = Main.TotFContext.Blueprints.GetGUID(adoptedSummonToggleBuffSystemName);
            var buffConfig = BuffConfigurator.New(adoptedSummonToggleBuffSystemName, buffguid.ToString());
            if (isLive)
            {
                buffConfig.SetDisplayName(PetBuff.m_DisplayName);
                buffConfig.SetDescription(PetBuff.m_Description);
                buffConfig.SetIcon(PetBuff.Icon);
                buffConfig.AddFamiliar(prefabLink: familiar.PrefabLink);
            }
            buffConfig.Configure();


            var toggleGuid = Main.TotFContext.Blueprints.GetGUID(adoptedSummonToggleAbilitySystemName);
            var toggleConfig = ActivatableAbilityConfigurator.New(adoptedSummonToggleAbilitySystemName, toggleGuid.ToString());
            if (isLive)
            {
                toggleConfig.SetDisplayName(PetActivatable.m_DisplayName);
                toggleConfig.SetDescription(PetActivatable.m_Description);
                toggleConfig.SetIcon(PetActivatable.Icon);
                toggleConfig.SetBuff(adoptedSummonToggleBuffSystemName);
                toggleConfig.SetDeactivateImmediately(true);
                toggleConfig.SetDoNotTurnOffOnRest(true);
            }
            toggleConfig.Configure();


            var featureguid = Main.TotFContext.Blueprints.GetGUID(adoptedFeatureSystemName);
            var featureconfig = FeatureConfigurator.New(adoptedFeatureSystemName, featureguid.ToString());
            if (isLive)
            {
                featureconfig.SetDisplayName(pet.m_DisplayNameText);
                featureconfig.SetDescription(pet.m_DescriptionText);
                featureconfig.SetRanks(1);
                featureconfig.SetIcon(pet.Icon);
                featureconfig.AddFacts(facts: new List<Blueprint<BlueprintUnitFactReference>>() { adoptedSummonToggleAbilitySystemName });
                foreach (var comp in components)
                {
                    featureconfig.AddComponent(comp);
                }
                
                featureconfig.AddFeatureSurvivesRespec();
            }
            featureconfig.Configure();
            if (isLive)
            {
                ItemFeatureSwapFactory.Run(adoptedFeatureSystemName, petGUID);
            }
           

            

        }
    }
}

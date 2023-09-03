using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Epic.OnlineServices.PlayerDataStorage;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System.Collections.Generic;
using System.Linq;
using TabletopTweaks.Core.MechanicsChanges;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.New_Components;
using UniRx;
using static TabletopTweaks.Core.MechanicsChanges.MetamagicExtention;

namespace TomeOfTheFirebird.New_Content.Features
{
    class KineticistDoubleMetakinesis
    {
        public static void Build()
        {
            var icon = AssetLoader.LoadInternal(Main.TotFContext, "Abilities", "TwinSpell.png");
            var feature = MakerTools.MakeFeature("MetakinesisDoubleFeature", LocalizationTool.GetString("MetakinesisDouble.Name"), LocalizationTool.GetString("MetakinesisDouble.Desc"), icon);
            var masterFeature = MakerTools.MakeFeature("MetakinesisMasterDouble", LocalizationTool.GetString("MetakinesisDoubleExpert.Name"), LocalizationTool.GetString("MetakinesisDoubleExpert.Desc"), icon);
            var toggle = MakerTools.MakeToggle("MetakinesisDoubleAbility", LocalizationTool.GetString("MetakinesisDouble.Name"), LocalizationTool.GetString("MetakinesisDouble.Desc"), icon);
            var toggleMaster = MakerTools.MakeToggle("MetakinesisDoubleCheaperAbility", LocalizationTool.GetString("MetakinesisDouble.Name"), LocalizationTool.GetString("MetakinesisDouble.Desc"), icon);
            var buff = MakerTools.MakeBuff("MetakinesisDoubleBuff", LocalizationTool.GetString("MetakinesisDouble.Name"), LocalizationTool.GetString("MetakinesisDouble.Desc"), icon);
            var buffMaster = MakerTools.MakeBuff("MetakinesisDoubleCheaperBuff", LocalizationTool.GetString("MetakinesisDouble.Name"), LocalizationTool.GetString("MetakinesisDouble.Desc"), icon);

            if (Settings.IsEnabled("TwinSpell"))
            {
                feature.SetHideInUI(false);
                masterFeature.SetIcon(icon);
                masterFeature.SetHideInUI(false);
                masterFeature.SetHideInCharacterSheetAndLevelUp(false);
                masterFeature.SetHideNotAvailibleInUI(false);
                feature.SetIcon(icon);
                feature.AddFeatureIfHasFact(feature: "MetakinesisDoubleAbility", checkedFact: "MetakinesisMasterDouble", not: true);
                feature.AddFeatureIfHasFact(feature: "MetakinesisDoubleCheaperAbility", checkedFact: "MetakinesisMasterDouble", not: false);
                feature.SetReapplyOnLevelUp(true);
                feature.AddComponent<AttachTwinSpellUnitPart>();

                toggle.SetBuff("MetakinesisDoubleBuff");
                toggle.SetIcon(icon);
                toggleMaster.SetIcon(icon);
                toggleMaster.SetBuff("MetakinesisDoubleCheaperBuff");
                SharedToggleStuff(toggle);
                SharedToggleStuff(toggleMaster);

                buff.SetIcon(icon);
                buffMaster.SetIcon(icon);
                SharedBuffStuff(buff, 4);
                SharedBuffStuff(buffMaster, 3);

                masterFeature.AddPrerequisiteFeature("MetakinesisDoubleFeature");



            }
            buff.Configure();
            buffMaster.Configure();

            var toggleBuilt =  toggle.Configure();
            toggleMaster.Configure();
            var featurebuilt = feature.Configure();
            var masterfeaturebuild = masterFeature.Configure();
            if (Settings.IsEnabled("TwinSpell"))
            {
                int level = 17;
                ProgressionConfigurator.For("b79e92dd495edd64e90fb483c504b8df").AddToLevelEntry(level, "MetakinesisDoubleFeature").Configure();
               
                BlueprintProgression kinProg = BlueprintTool.Get<BlueprintProgression>("b79e92dd495edd64e90fb483c504b8df");
                kinProg.UIGroups[2].m_Features.Add(featurebuilt.ToReference<BlueprintFeatureBaseReference>());
                ArchetypeConfigurator.For("7d61d9b2250260a45b18c5634524a8fb").AddToRemoveFeatures(level, "MetakinesisDoubleFeature").Configure();
                FeatureSelectionConfigurator.For("8c33002186eb2fd45a140eed1301e207").AddToAllFeatures(masterfeaturebuild).Configure();
             
                
                Main.TotFContext.Logger.LogPatch("Built Metakinesis (Double)", featurebuilt);
            }

        }

        public static void DoLast()
        {
            if (Settings.IsEnabled("TwinSpell"))
            {
                var lancer = BlueprintTool.Get<BlueprintArchetype>("022742CCA0CD414C98EED87F24AE5607");

                if (lancer != null)
                {
                    ArchetypeConfigurator.For(lancer).AddToRemoveFeatures(17, "MetakinesisDoubleFeature");
                }
            }
        }

        private static void SharedToggleStuff(ActivatableAbilityConfigurator toggle)
        {
            toggle.SetActivationType(Kingmaker.UnitLogic.ActivatableAbilities.AbilityActivationType.Immediately);
            toggle.SetActivateWithUnitCommand(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Free);
            toggle.SetActivateOnUnitAction(Kingmaker.UnitLogic.ActivatableAbilities.AbilityActivateOnUnitActionType.Attack);
            toggle.SetOnlyInCombat(false);
            toggle.SetDoNotTurnOffOnRest(true);
            toggle.SetIsTargeted(false);
            toggle.SetDeactivateIfCombatEnded(false);
            toggle.SetWeightInGroup(1);
            toggle.SetDeactivateImmediately(true);

        }

        private static void SharedBuffStuff(BuffConfigurator buff, int burnValue)
        {
            buff.AddKineticistBurnModifier(burnType: Kingmaker.UnitLogic.Class.Kineticist.KineticistBurnType.Metakinesis, value: burnValue, useContextValue:false, removeBuffOnAcceptBurn: false, burnValue: ContextValues.Constant(burnValue));
            buff.AddAutoMetamagic(allowedAbilities: Kingmaker.Designers.Mechanics.Facts.AutoMetamagic.AllowedType.KineticistBlast, metamagic: (Metamagic)CustomMetamagic.Twin, checkSpellbook: false);
            buff.SetFlags(BlueprintBuff.Flags.HiddenInUi, BlueprintBuff.Flags.StayOnDeath);
            
        }


        public static void LoadBlasts()
        {
            if (Settings.IsEnabled("TwinSpell"))
            {
                BlueprintBuff empowerBuff = BlueprintTool.Get<BlueprintBuff>("f5f3aa17dd579ff49879923fb7bc2adb");
                Load("MetakinesisDoubleBuff");
                Load("MetakinesisDoubleCheaperBuff");


                void Load(string buffName)
                {
                    var buff = BuffConfigurator.For(buffName);
                    buff.EditComponent<AutoMetamagic>(x =>
                    {
                        x.Abilities = empowerBuff.GetComponent<AutoMetamagic>().Abilities;

                    });
                    buff.EditComponent<AddKineticistBurnModifier>(x =>
                    {
                        x.m_AppliableTo = empowerBuff.GetComponent<AddKineticistBurnModifier>().m_AppliableTo.ToArray();

                    });
                    buff.Configure();


                }
            }
        }

        
    }
}

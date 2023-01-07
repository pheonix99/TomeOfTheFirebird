using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.Mechanics.Properties;
using System.Linq;
using TabletopTweaks.Core.NewComponents.Properties;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.New_Components.Prerequisites;
using UnityModManagerNet;

namespace TomeOfTheFirebird.New_Content.Features
{
    class FighterArmorTrainingFakeLevel
    {
        public static void AddFighterArmorTrainingRank()
        {
            BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator maker = MakerTools.MakeFeature("ArmorTrainingRank", "FighterArmorTrainingRank", "", true);
            maker.SetIsClassFeature(true);
            maker.SetRanks(40);
            maker.Configure();


        }

        public static void Connect()
        {
            if (Settings.IsDisabled("PurifierCelestialArmorTraining"))
                return;
            if (UnityModManager.FindMod("TabletopTweaks-Base") == null)
            {
                return;
            }
            BlueprintCharacterClass FighterClass = BlueprintTools.GetBlueprint<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            BlueprintUnitProperty prop = BlueprintTools.GetBlueprint<BlueprintUnitProperty>("8889a638d9be4379ab9a5c2e08fd5015");
            BlueprintFeature feature = BlueprintTool.Get<BlueprintFeature>("ArmorTrainingRank");
            BlueprintFeatureSelection ArmorTrainingSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(Main.TotFContext, "ArmorTrainingSelection");
            if (prop != null)
            {
                prop.Components.OfType<CompositeCustomPropertyGetter>().FirstOrDefault().Properties = prop.Components.OfType<CompositeCustomPropertyGetter>().FirstOrDefault().Properties.AppendToArray(new CompositeCustomPropertyGetter.ComplexCustomProperty()
                {
                    Property = new FactRankGetter()
                    {
                        m_Fact = feature.ToReference<BlueprintUnitFactReference>()
                    }
                });
            }
            else
            {
                Main.TotFContext.Logger.Log($"Couldn't get FighterArmorTrainingProperty, cannot implement Armor Training connection");
                return;
            }
            string[] armorguids = new string[]
            {
                 "c1e7a208b5a544f58071af88a61ab842",
    "7743a11f841449b4935224ac1de82edd",
    "59cb9654de7147399b4d6a384d32dd3a",
    "67eb66ec98754e228a6b4633a10327fa",
    "bae7b370c4e8427c939a30e7133501c7",
   "80246fa3dfe14dea94ec6e6640900083"
            };
            foreach (string s in armorguids)
            {
                BlueprintFeatureSelection armorSelect = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>(s);
                armorSelect.HideNotAvailibleInUI = false;
                ConnectFeature(armorSelect);
            }

            BlueprintFeatureSelection armorSelect2 = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("5bf17c2ae9ee4615b27c993629ed9bc3");
            armorSelect2.HideNotAvailibleInUI = false;
            ConnectFeature(armorSelect2);
            ConnectFeature(ArmorTrainingSelection);

            void ConnectFeature(BlueprintFeature feature)
            {
                PrerequisiteClassLevel classReq = feature.Components.OfType<PrerequisiteClassLevel>().FirstOrDefault(x => x.m_CharacterClass.deserializedGuid == FighterClass.AssetGuidThreadSafe);
                if (classReq != null)
                {
                    int level = classReq.Level;
                    feature.RemoveComponent(classReq);
                    feature.AddPrerequisite<PrerequisiteProperty>(x =>
                    {
                        x.value = level;
                        x.UserFacingPropertyName = "Armor Training Rank";
                        x.propertyReference = prop.ToReference<BlueprintUnitPropertyReference>();
                    });
                }

            }
        }
    }
}

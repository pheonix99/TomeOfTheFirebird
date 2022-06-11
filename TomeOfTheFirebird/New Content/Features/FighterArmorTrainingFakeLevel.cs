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
            var maker = MakerTools.MakeFeature("ArmorTrainingRank", "FighterArmorTrainingRank", "", true);
            maker.SetIsClassFeature(true);
            maker.SetRanks(40);
            maker.Configure();

         
        }

        public static void Connect()
        {
            if (Main.TotFContext.Tweaks.Purifier.IsDisabled("CelestialArmorTraining"))
                return;
            if (UnityModManager.FindMod("TabletopTweaks-Base") == null)
            {
                return;
            }
            var FighterClass = BlueprintTools.GetBlueprint<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var prop = BlueprintTools.GetModBlueprint<BlueprintUnitProperty>(Main.TotFContext, "FighterArmorTrainingProperty");
            var feature = BlueprintTool.Get<BlueprintFeature>("ArmorTrainingRank");
            var ArmorTrainingSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(Main.TotFContext, "ArmorTrainingSelection");
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
            for (int i = 1; i <= 6; i++)
            {
                var armorSelect = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(Main.TotFContext, "AdvancedArmorTraining" + i.ToString());
                armorSelect.HideNotAvailibleInUI = false;
                ConnectFeature(armorSelect);
            }
            var armorSelect2 = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(Main.TotFContext, "AdvancedArmorTrainingSelection");
            armorSelect2.HideNotAvailibleInUI = false;
            ConnectFeature(armorSelect2);
            ConnectFeature(ArmorTrainingSelection);

            void ConnectFeature(BlueprintFeature feature)
            {
                var classReq = feature.Components.OfType<PrerequisiteClassLevel>().FirstOrDefault(x => x.m_CharacterClass.deserializedGuid == FighterClass.AssetGuidThreadSafe);
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

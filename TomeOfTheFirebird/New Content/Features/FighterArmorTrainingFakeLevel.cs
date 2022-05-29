using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Mechanics.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.NewComponents.Properties;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;

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
            var prop = BlueprintTools.GetModBlueprint<BlueprintUnitProperty>(Main.TotFContext, "FighterArmorTrainingProperty");
            var feature = BlueprintTool.Get<BlueprintFeature>("ArmorTrainingRank");
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
            }
        }
    }
}

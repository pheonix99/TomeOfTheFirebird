using Kingmaker.Assets.UnitLogic.Mechanics.Properties;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.UnitLogic.Class.Kineticist.Properties;
using Kingmaker.UnitLogic.Mechanics.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.NewComponents.Properties;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.New_Components;
using TomeOfTheFirebird.New_Components.Prerequisites;
using TomeOfTheFirebird.New_Components.Properties;

namespace TomeOfTheFirebird.New_Content.Feats
{
    class BurnResistance
    {
        public static void Make()
        {
            string sysName = "BurnResistanceFeature";
            BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator config = Helpers.MakerTools.MakeFeature(sysName, "Burn Resistance", "You can consider your character level to be two levels lower to determine the penalties you take from your burn class feature. ");
            config.AddToGroups(FeatureGroup.Feat);
            config.AddPrerequisiteClassLevel("42a455d9ec1ad924d889272429eb8391", 7);
            config.AddComponent<PrerequisiteUsesStandardBurn>();
            config.SetRanks(1);
            BlueprintFeature done = config.Configure();

            //ac8b7875fff5c0643ac499d404947fff
            BlueprintUnitProperty burnNumberProperty = BlueprintTools.GetBlueprint<BlueprintUnitProperty>("02c5943c77717974cb7fa1b7c0dc51f8");
            BlueprintUnitProperty nonlethalburnProp = BlueprintTools.GetBlueprint<BlueprintUnitProperty>("ac8b7875fff5c0643ac499d404947fff");
            nonlethalburnProp.RemoveComponents<KineticistBurnPropertyGetter>();
            nonlethalburnProp.AddComponent<CompositeCustomPropertyGetter>(
                x =>
                {
                    x.CalculationMode = CompositeCustomPropertyGetter.Mode.Sum;
                    x.Properties = new CompositeCustomPropertyGetter.ComplexCustomProperty[]//TODO tidy this up
                    {
                        new CompositeCustomPropertyGetter.ComplexCustomProperty()
                        {
                            Property = new KineticistBurnPropertyGetter(){
                            MultyplyOnCharacterLevel = true
                            }
                        },
                        new CompositeCustomPropertyGetter.ComplexCustomProperty()
                        {
                            Property =  new HasFeaturePropertyGetter()
                            {
                                    Property = new KineticistBurnPropertyGetter(),
                                featureBaseReference = done.ToReference<BlueprintFeatureBaseReference>()
                            },
                            Numerator = 2

                         }
                    };

                }
            );
            Main.TotFContext.Logger.LogPatch(done);
            if (Main.TotFContext.NewContent.Feats.IsDisabled("BurnResistance"))
                return;
            TabletopTweaks.Core.Utilities.FeatTools.AddAsFeat(done);


        }

        /*
         * 
Burn Resistance (feat)
View source

Prerequisite(s): Burn class feature, kineticist 7th

Benefit: 
         */
    }
}

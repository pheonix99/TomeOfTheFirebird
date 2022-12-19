using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.UnitLogic.Class.Kineticist.Properties;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.NewComponents.Properties;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.New_Components;

namespace TomeOfTheFirebird.New_Content.Feats
{
    class MythicKineticDefenses
    {
        public static void Make()
        {
            //Adaptations
            string airid = "c8719b3c5c0d4694cb13abcc3b7e893b";
            string coldid = "1ff5d6e76b7c2fa48be555b77d1ad8b2";
            string fireId = "2825e3a53c76ad944a47c5c44fb6109f";


            string airbuffId = "de4f4b6aa7f62204c95f5d03ac0bc459";
            
            string shroudFeatureid = "29ec36fa2a5b8b94ebce170bd369083a";
            string searingFleshId = "8ad77685e64842c45a6f5b19f9086c6c";
            string fleshOfStoneId = "a275b35f282601944a97e694f6bc79f8";
            string windsId = "bb0de2047c448bd46aff120be3b39b7a";
            BlueprintUnitProperty burnNumberProperty = BlueprintTools.GetBlueprint<BlueprintUnitProperty>("02c5943c77717974cb7fa1b7c0dc51f8");

            BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator featureConfig = Helpers.MakerTools.MakeFeature("MythicKineticDefenses", "Mythic Kinetic Defenses", "Mythic power augments your defensive wild talents. Talents increasing your energy resistence based off your burn now add your mythic rank to your effective burn. Core kinetic defenses now act as if you'd enhanceed them with a point of burn for free, gaining another virtual point at MR 4, 7, and 10");


            BlueprintFeature built = featureConfig.Configure();

            HasFeaturePropertyGetter mrGetter = new HasFeaturePropertyGetter()
            {
                Property = new SimplePropertyGetter()
                {
                    Property = UnitProperty.MythicLevel
                },
                featureBaseReference = built.ToReference<BlueprintFeatureBaseReference>()
            };
            BlueprintUnitProperty adaptProperty = TabletopTweaks.Core.Utilities.Helpers.CreateBlueprint<BlueprintUnitProperty>(Main.TotFContext, "KineticAdaptProperty", x =>
            {
                x.AddComponent<CompositeCustomPropertyGetter>(x =>
                {
                    x.CalculationMode = CompositeCustomPropertyGetter.Mode.Sum;
                    x.Properties = new CompositeCustomPropertyGetter.ComplexCustomProperty[]
                    {
                        new CompositeCustomPropertyGetter.ComplexCustomProperty()
                        {
                            Property = burnNumberProperty.GetComponent<KineticistBurnPropertyGetter>()
                        },
                        new CompositeCustomPropertyGetter.ComplexCustomProperty()
                        {
                            Property = mrGetter
                        }
                    };

                });

            });

            PatchResist(BlueprintTools.GetBlueprint<BlueprintFeature>(airid));
            PatchResist(BlueprintTools.GetBlueprint<BlueprintFeature>(coldid));
            PatchResist(BlueprintTools.GetBlueprint<BlueprintFeature>(fireId));

            void PatchResist(BlueprintFeature resist)
            {
                AddFacts trigger =   resist.Components.FirstOrDefault(x => x is AddFacts) as AddFacts;
                BlueprintUnitFactReference buffref = trigger.m_Facts[0];
                buffref.Get().GetComponent<AddDamageResistanceEnergy>().Value.m_CustomProperty = adaptProperty.ToReference<BlueprintUnitPropertyReference>();
                built.AddPrerequisiteFeature(resist, Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any);
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

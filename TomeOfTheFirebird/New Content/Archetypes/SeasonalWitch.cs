using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.New_Components.Prerequisites;

namespace TomeOfTheFirebird.New_Content.Archetypes
{
    class SeasonalWitch
    {
        public void Make()
        {
            var classID = "1b9873f1e7bfe5449bc84d03e9c8e3cc";
            var archeGuid = Main.TotFContext.Blueprints.GetGUID("SeasonWitchArchetype");
            var SeasonOfTheWitchUIFeatureGuid = Main.TotFContext.Blueprints.GetGUID("SeasonOfTheWitchUIFeature");

            var winterPatron = BlueprintTool.Get<BlueprintProgression>("e98d8d9f907c1814aa7376d6cdaac012");

            var SummerDCGuid = Main.TotFContext.Blueprints.GetGUID("SeasonOfTheWitchSummerDCFeature");
            var AutumnDCGuid = Main.TotFContext.Blueprints.GetGUID("SeasonOfTheWitchAutumnDCFeature");
            var WinterDCGuid = Main.TotFContext.Blueprints.GetGUID("SeasonOfTheWitchWinterDCFeature");
            var SpringDCGuid = Main.TotFContext.Blueprints.GetGUID("SeasonOfTheWitchSpringDCFeature");


            var SummerHexGuid = Main.TotFContext.Blueprints.GetGUID("SeasonOfTheWitchSummerHexFeature");
            var AutumnHexGuid = Main.TotFContext.Blueprints.GetGUID("SeasonOfTheWitchAutumnHexFeature");
            var WinterHexGuid = Main.TotFContext.Blueprints.GetGUID("SeasonOfTheWitchWinterHexFeature");
            var SpringHexGuid = Main.TotFContext.Blueprints.GetGUID("SeasonOfTheWitchSpringHexFeature");


            if (Settings.IsEnabled("SeasonWitch"))
            {

                

                var SeasonOfTheWitchUIFeature = FeatureConfigurator.New("SeasonOfTheWitchUIFeature", SeasonOfTheWitchUIFeatureGuid.ToString());
                SeasonOfTheWitchUIFeature.SetDisplayName(LocalizationTool.CreateString("SeasonOfTheWitchUIFeature.Name", "Season Of The Witch", false));
                SeasonOfTheWitchUIFeature.SetDescription(LocalizationTool.CreateString("SeasonOfTheWitchUIFeature.Desc", $"A season witch observes the cycles of life through symbolic festivals and the very real passage of time. Their covens celebrate the seasons and their impact on magic. These seasonal cycles alter their magic and mind-set, focusing their spells and hexes on a predominant energy type and philosophy.\n A season witch makes a commitment to embody the sacred symbolism of a season year round, and learns her spells through communion with nature, divining secrets from shapes in the clouds or the play of leaves on the wind.At 1st level, a season witch chooses the season that defines her abilities as her patron; this choice also provides her certain benefits.\nA spring witch has dominion over the renewing spirit of life and youth.The save DCs of her spells that deal electricity damage increase by 1.At 1st level, she gains either the charm hex or disguise hex as a bonus hex.\nA summer witch has dominion over growth, the harvest, and toil.The save DCs of her spells that deal fire damage increase by 1.At 1st level, she gains either the fortune hex or misfortune hex as a bonus hex.\nAn autumn witch has dominion over the provision of the land and the passing of life. The save DCs of her spells that deal acid damage increase by 1.At 1st level, she gains either the blight hex or slumber hex as a bonus hex.\nA winter witch has dominion over hearth and home.The save DCs of her spells that deal cold damage increase by 1.At 1st level, she gains either the healing hex or ward hex as a bonus hex."));
                SeasonOfTheWitchUIFeature.SetIsClassFeature(true);
                SeasonOfTheWitchUIFeature.Configure();


                var arche = ArchetypeConfigurator.New("SeasonWitch", archeGuid.ToString(), classID);
                arche.SetLocalizedName(LocalizationTool.CreateString("SeasonWitch.Name", "Season Witch"));
                arche.SetLocalizedName(LocalizationTool.CreateString("SeasonWitch.Desc", "Season witches gain their power from the cyclical and mystical exchange of energy passed from one season of nature to another. Often, season witches carry bitter grudges against their fellow witches, with many believing that the season prior to their chosen focus is inferior and the season that replaces their favored time is an usurper of time, but at other times season witches work together, understanding that all are a part of the cycle of the natural world."));

                arche.AddToAddFeatures(1, "SeasonOfTheWitchUIFeature");

                var winterDC = FeatureConfigurator.New("SeasonOfTheWitchWinterDCFeature", WinterDCGuid.ToString());
                winterDC.SetIsClassFeature(true);
                winterDC.SetDisplayName(LocalizationTool.CreateString("SeasonOfTheWitchWinterDCFeature.Name", "Season Of The Witch: Cold DC"));
                winterDC.SetDisplayName(LocalizationTool.CreateString("SeasonOfTheWitchWinterDCFeature.Desc", "A winter witch has dominion over hearth and home. The save DCs of her spells that deal cold damage increase by 1."));
                winterDC.AddIncreaseSpellDescriptorDC(1, new Kingmaker.Blueprints.Classes.Spells.SpellDescriptorWrapper(Kingmaker.Blueprints.Classes.Spells.SpellDescriptor.Cold));
                winterDC.AddPrerequisiteFeature(winterPatron, checkInProgression: true);
                winterDC.SetHideNotAvailibleInUI(true);
                winterDC.Configure();

                var springDC = FeatureConfigurator.New("SeasonOfTheWitchSpringDCFeature", SpringDCGuid.ToString());
                springDC.SetIsClassFeature(true);
                springDC.SetDisplayName(LocalizationTool.CreateString("SeasonOfTheWitchSpringDCFeature.Name", "Season Of The Witch: Electricity DC"));
                springDC.SetDisplayName(LocalizationTool.CreateString("SeasonOfTheWitchSpringDCFeature.Desc", "A spring witch has dominion over the renewing spirit of life and youth. The save DCs of her spells that deal electricity damage increase by 1"));
                springDC.AddIncreaseSpellDescriptorDC(1, new Kingmaker.Blueprints.Classes.Spells.SpellDescriptorWrapper(Kingmaker.Blueprints.Classes.Spells.SpellDescriptor.Electricity));
                //springDC.AddPrerequisiteFeature(winterPatron, checkInProgression: true);
                springDC.SetHideNotAvailibleInUI(true);
                springDC.Configure();

                var summerDC = FeatureConfigurator.New("SeasonOfTheWitchSummerDCFeature", SpringDCGuid.ToString());
                summerDC.SetIsClassFeature(true);
                summerDC.SetDisplayName(LocalizationTool.CreateString("SeasonOfTheWitchSummerDCFeature.Name", "Season Of The Summer: Fire DC"));
                summerDC.SetDisplayName(LocalizationTool.CreateString("SeasonOfTheWitchSummerDCFeature.Desc", "A summer witch has dominion over growth, the harvest, and toil. The save DCs of her spells that deal fire damage increase by 1."));
                summerDC.AddIncreaseSpellDescriptorDC(1, new Kingmaker.Blueprints.Classes.Spells.SpellDescriptorWrapper(Kingmaker.Blueprints.Classes.Spells.SpellDescriptor.Fire));
                //summerDC.AddPrerequisiteFeature(winterPatron, checkInProgression: true);
                summerDC.SetHideNotAvailibleInUI(true);
                summerDC.Configure();

                var autumnDC = FeatureConfigurator.New("SeasonOfTheWitchAutumnDCFeature", AutumnDCGuid.ToString());
                autumnDC.SetIsClassFeature(true);
                autumnDC.SetDisplayName(LocalizationTool.CreateString("SeasonOfTheWitchAutumnDCFeature.Name", "Season Of The Witch: Cold DC"));
                autumnDC.SetDisplayName(LocalizationTool.CreateString("SeasonOfTheWitchAutumnDCFeature.Desc", "An autumn witch has dominion over the provision of the land and the passing of life. The save DCs of her spells that deal acid damage increase by 1."));
                autumnDC.AddIncreaseSpellDescriptorDC(1, new Kingmaker.Blueprints.Classes.Spells.SpellDescriptorWrapper(Kingmaker.Blueprints.Classes.Spells.SpellDescriptor.Acid));
                //autumnDC.AddPrerequisiteFeature(winterPatron, checkInProgression: true);
                autumnDC.SetHideNotAvailibleInUI(true);
                autumnDC.Configure();

                var winterHex = FeatureSelectionConfigurator.New("SeasonOfTheWitchWinterHexFeature", WinterHexGuid.ToString());

                arche.AddToRemoveFeatures(1, "9846043cf51251a4897728ed6e24e76f");
                arche.AddToAddFeatures(1, "SeasonOfTheWitchWinterDCFeature");
                var archeBuilt = arche.Configure();

                BlueprintFeatureSelection patronSelector = BlueprintTool.Get<BlueprintFeatureSelection>("381cf4c890815d049a4420c6f31d063f");
                foreach(var patron in patronSelector.AllFeatures)
                {
                    if (!patron.Equals(winterPatron))
                    {
                        
                        patron.AddComponent<PrerequisiteArchetypeCantTakeWithX>(x =>
                        {
                            x.blockedArchetypes.Add(archeBuilt.ToReference<BlueprintArchetypeReference>());
                            x.blocked = patronSelector.ToReference<BlueprintFeatureSelectionReference>();
                            x.HideInUI = true;
    
                        });
                    }
                    patron.HideNotAvailibleInUI = true;
                }


            }
            else
            {
                ArchetypeConfigurator.New("SeasonWitch", archeGuid.ToString()).Configure();
                FeatureConfigurator.New("SeasonOfTheWitchUIFeature", SeasonOfTheWitchUIFeatureGuid.ToString()).Configure();
                FeatureConfigurator.New("SeasonOfTheWitchWinterDCFeature", WinterDCGuid.ToString()).Configure();
                FeatureConfigurator.New("SeasonOfTheWitchSpringDCFeature", SpringDCGuid.ToString()).Configure();
                FeatureConfigurator.New("SeasonOfTheWitchSummerDCFeature", SpringDCGuid.ToString()).Configure();
                FeatureConfigurator.New("SeasonOfTheWitchAutumnDCFeature", AutumnDCGuid.ToString()).Configure();
            }

        }
    }
}

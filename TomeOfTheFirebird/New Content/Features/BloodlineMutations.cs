using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.New_Components.BloodlineMutation;

namespace TomeOfTheFirebird.New_Content.Features
{
    class BloodlineMutations
    {
        public static void Setup()
        {
            if (!Settings.BloodlineMutationsEnabled())
                return;
            Main.TotFContext.Logger.Log($"Processing  sorc bloodlines for bloodline mutations");
            var sorc = BlueprintTool.Get<BlueprintFeatureSelection>("24bef8d1bee12274686f6da6ccbc8914").AllFeatures.Where(x => x is BlueprintProgression).Select(x => x as BlueprintProgression);
            foreach(var sorcBloodline in sorc)
            {
                ProcessProgression(sorcBloodline);
            }
            Main.TotFContext.Logger.Log($"Processing crossblooded sorc bloodlines for bloodline mutations");
            var xsorc = BlueprintTool.Get<BlueprintFeatureSelection>("60c99d78a70e0b44f87ba01d02d909a6").AllFeatures.Where(x => x is BlueprintProgression).Select(x => x as BlueprintProgression);
            foreach (var sorcBloodline in xsorc)
            {
                ProcessProgression(sorcBloodline);
            }

            Main.TotFContext.Logger.Log($"Processing seeker sorc bloodlines for bloodline mutations");
            var seeksorc = BlueprintTool.Get<BlueprintFeatureSelection>("7bda7cdb0ccda664c9eb8978cf512dbc").AllFeatures.Where(x => x is BlueprintProgression).Select(x => x as BlueprintProgression);
            foreach (var sorcBloodline in seeksorc)
            {
                ProcessProgression(sorcBloodline);
            }

            Main.TotFContext.Logger.Log($"Processing bloodrager bloodlines for bloodline mutations");
            var bloodrager = BlueprintTool.Get<BlueprintFeatureSelection>("62b33ac8ceb18dd47ad4c8f06849bc01").AllFeatures.Where(x => x is BlueprintProgression).Select(x => x as BlueprintProgression);
            foreach (var bloodragerbloodline in bloodrager)
            {
                ProcessProgression(bloodragerbloodline);
            }

            ProcessProgression(BlueprintTool.Get<BlueprintProgression>("8a95d80a3162d274896d50c2f18bb6b1"));//Empyreal
            ProcessProgression(BlueprintTool.Get<BlueprintProgression>("a46d4bd93601427409d034a997673ece"));//Sylvan

            List<string> ElementalDieScalingActiveAttackloodlinePowers = new();
            List<string> ShittyAttackSpellLikeBloodlinePowers = new();
            //Bloodrager
            ElementalDieScalingActiveAttackloodlinePowers.Add("3dbf2ff987b060f4fbfe3df88a4f51f6");//Black Dragon Breath
            ElementalDieScalingActiveAttackloodlinePowers.Add("41dbfcc6584aa34418cd7654eafe4b55");//Blue Dragon Breath
            ElementalDieScalingActiveAttackloodlinePowers.Add("f164bd712ff93fc4a9d034cf8a587098");//Brass Dragon Breath
            ElementalDieScalingActiveAttackloodlinePowers.Add("c99f37519a1e96d40a09d0f1bd4a9da4");//Copper Dragon Breath
            ElementalDieScalingActiveAttackloodlinePowers.Add("ff81c7764c54d0f4cae959f7a11d3c0b");//Gold Dragon Breath
            ElementalDieScalingActiveAttackloodlinePowers.Add("e295230146389784eb9ca50d88b74bb3");//Red Dragon Breath
            ElementalDieScalingActiveAttackloodlinePowers.Add("8788db3aa77e736419a9cb3b53451e7e");//White Dragon Breath
            ElementalDieScalingActiveAttackloodlinePowers.Add("a2ed208df4a37ab49820913c695517dd");//Green Dragon Breath
            ElementalDieScalingActiveAttackloodlinePowers.Add("1a7036520ed1022439f5c9d63ac76503");//Silver Dragon Breath
            ElementalDieScalingActiveAttackloodlinePowers.Add("53b8b1fd83f4bf94aa9d1fc2032b2cac");//Bronze Dragon Breath
            

            //f88081f3d2ed69c429736051f2fb80ae - hellfire charge, not an attack spell kin ability but close?
            //Sorc
            ShittyAttackSpellLikeBloodlinePowers.Add("64aca51981fc11346a20b723d7667e47");

            ElementalDieScalingActiveAttackloodlinePowers.Add("3f31704e595e78942b3640cdc9b95d8b");//Red Dragon Breath
            ElementalDieScalingActiveAttackloodlinePowers.Add("598e33639b662784fb07c0e4c8978aa4");//Gold Dragon Breath
            ElementalDieScalingActiveAttackloodlinePowers.Add("60a3047f434f38544a2878c26955d3ad");//Blue Dragon Breath
            ElementalDieScalingActiveAttackloodlinePowers.Add("633b622267c097d4abe3ec6445c05152");//Green Dragon Breath
            ElementalDieScalingActiveAttackloodlinePowers.Add("84be529914c90664aa948d8266bb3fa6");//White Dragon Breath
            ElementalDieScalingActiveAttackloodlinePowers.Add("531a57e0c19f80945b68bdb3e289279a");//Brass Dragon Breath
            ElementalDieScalingActiveAttackloodlinePowers.Add("1e65b0b2db777e24db96d8bc52cc9207");//Black Dragon Breath
            ElementalDieScalingActiveAttackloodlinePowers.Add("732291d7ac20b0949aae002622e00b34");//Bronze Dragon Breath
            ElementalDieScalingActiveAttackloodlinePowers.Add("11d03ebc508d6834cad5992056ad01a4");//Silver Dragon Breath
            ElementalDieScalingActiveAttackloodlinePowers.Add("826ef8251d9243941b432f97d901e938");//Copper Dragon Breath


            ElementalDieScalingActiveAttackloodlinePowers.Add("4729c2ac98d02004fb440d17f7786e28");//Air Beam
            ElementalDieScalingActiveAttackloodlinePowers.Add("8c2a0033a591b9247b45af575f12af77");//Earth Beam
            ElementalDieScalingActiveAttackloodlinePowers.Add("1b4989258e5964149a909e47c72b7f67");//Fire Beam
            ElementalDieScalingActiveAttackloodlinePowers.Add("9d5cb7c1b77455b4d84169ce081934c6");//Water Beam


            ElementalDieScalingActiveAttackloodlinePowers.Add("87e837a180a12db448a6d78e58e1b0a6");//Infernal Hellfire

            AbstractBloodlineMutationComponent.LoadElementalAttackPowers(ElementalDieScalingActiveAttackloodlinePowers);
            AbstractBloodlineMutationComponent.LoadBadScalingAttackPowers(ShittyAttackSpellLikeBloodlinePowers);

        }
        
        public static void AddToSelectors(Blueprint<BlueprintFeatureReference> blueprint)
        {

            

            FeatureSelectionConfigurator.For("3a60f0c0442acfb419b0c03b584e1394").AddToAllFeatures(blueprint).Configure();
            var bloodrager = BlueprintTool.Get<BlueprintFeatureSelection>("62b33ac8ceb18dd47ad4c8f06849bc01").AllFeatures.Where(x => x is BlueprintProgression).Select(x => x as BlueprintProgression);
            List<BlueprintFeatureSelection> bonusFeats = new();
            foreach(var prog in bloodrager)
            {
                var green = prog.LevelEntries.FirstOrDefault(x => x.Level == 6)?.Features.FirstOrDefault(x => x.name.Contains("Greenrager")) as BlueprintFeatureSelection;
                var meta = prog.LevelEntries.FirstOrDefault(x => x.Level == 6)?.Features.FirstOrDefault(x => x.name.Contains("Meta")) as BlueprintFeatureSelection;
                var stadnard = prog.LevelEntries.FirstOrDefault(x => x.Level == 12)?.Features.FirstOrDefault(x => x.name.Contains("FeatSelection")) as BlueprintFeatureSelection;
                if (green != null && !bonusFeats.Contains(green))
                {
                    bonusFeats.Add(green);
                }
                if (meta != null && !bonusFeats.Contains(meta))
                {
                    bonusFeats.Add(meta);
                }
                if (stadnard != null && !bonusFeats.Contains(stadnard))
                {
                    bonusFeats.Add(stadnard);
                }



            }

            foreach(var v in bonusFeats)
            {
                FeatureSelectionConfigurator.For(v).AddToAllFeatures(blueprint).Configure();
            }
        }

        private static void ProcessProgression(BlueprintProgression blueprintProgression)
        {
            Main.TotFContext.Logger.Log($"Processing progression {blueprintProgression} for bloodline mutations");
            ProgressionConfigurator.For(blueprintProgression).AddBloodlineSpellComponents().Configure();
            
        }
    }
}

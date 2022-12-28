using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.Class.Kineticist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.Modified_Content.KineticistOverhaul
{
    class SortTalentsByElement
    {
        public static void ReadVanillaElementalFociForBlasts()
        {

        }

        public static void ReadVanillaCompositeBlastData()
        {
            //cb30a291c75def84090430fbf2b5c05e - composite blast granter buff
        }

        public static void Sort()
        {
            
            BlueprintFeatureReference[] InfusionList = BlueprintTool.Get<BlueprintFeatureSelection>("58d6f8e9eea63f6418b107ce64f315ea").m_AllFeatures;
            BlueprintFeatureReference[] UtilityList = BlueprintTool.Get<BlueprintFeatureSelection>("5c883ae0cd6d7d5448b7a420f51f8459").m_AllFeatures;

            void Sort(BlueprintFeatureReference[] arr)
            {
                foreach(var v in arr)
                {
                    bool foundElement = false;
                    var bp = v.Get();
                    if (bp)
                }
            }
        }
    }

    public class TalentData
    {
        string[] elements;
        int level;
        bool infusion;
    }
}

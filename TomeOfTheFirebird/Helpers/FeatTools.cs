using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Utility;
using System.Linq;
using TomeOfTheFirebird.NewComponents.Prerequisites;


namespace TomeOfTheFirebird.Helpers
{
    static class FeatTools
    {
       
       

        /// <summary>
        /// Inserts an alternate StatType unlock with prerequisite feat
        /// For instance, Prodigious TWF's replacing dex reqs with str reqs is implemented this way
        /// Don't use this method if the feat *already* has a OR requirmenet not including the stat implemented using the Prequisite.Group.Any setting because that only allows a single OR group
        /// </summary>
        /// <param name="feat"></param>
        /// <param name="originalStat"></param>
        /// <param name="unlock"></param>
        /// <param name="newStat"></param>
        public static void PatchFeatWithFeatLockedAlternateAbilityPrereqSimple(BlueprintFeature feat, StatType originalStat, BlueprintFeature unlock, StatType newStat)
        {
            PrerequisiteStatValue ogReq = feat.Components.OfType<PrerequisiteStatValue>().FirstOrDefault(x => x.Stat == originalStat);
            if (ogReq != null)
            {
                ogReq.Group = Prerequisite.GroupType.Any;
                
                PrerequisiteLogicalAND logicalAND = new PrerequisiteLogicalAND();
                logicalAND.Group = Prerequisite.GroupType.Any;
                PrerequisiteFeature featReq = new PrerequisiteFeature();
                featReq.m_Feature = unlock.ToReference<BlueprintFeatureReference>();
                logicalAND.AddPrequisiteToList(featReq);
                logicalAND.OwnerBlueprint = feat;//Not sure if this necessary to set this but i do need this set for safety's sake
                PrerequisiteStatValue altReq = new PrerequisiteStatValue();
                altReq.Value = ogReq.Value;
                altReq.Stat = newStat;
                logicalAND.AddPrequisiteToList(altReq);
                FeatureConfigurator.For(feat.AssetGuidThreadSafe).AddComponent(logicalAND).Configure();
                

                
                
                
                
            }

        }

    
    }
}

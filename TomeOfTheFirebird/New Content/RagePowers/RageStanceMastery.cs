using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.New_Content.RagePowers
{
    class RageStanceMastery
    {
        public static void Make()
        {
            string sysname = "RageStanceMastery";
            string displayName = "Rage Stance Mastery";
            string desc = "The barbarian can now use two rage stances at once";
            if (Settings.IsEnabled("RagePowerRageStanceMastery"))
            {
                var feature = MakerTools.MakeFeature(sysname, displayName, desc);
                List<Blueprint<BlueprintFeatureReference>> reqs = new();
                reqs.Add("efb97e482f53f064dab85a9eeaf01085");//Guarded Stance
                reqs.Add("e4450dd9c06dc034fb7c0c08abcc202b");//Lethal Stance
                reqs.Add("bc64d8f695f6d6448b3863d253353e7f");//Powerful Stance
                reqs.Add("cb502c65dab407b4e928f5d8355cafc9");//Reckless stance
                if (Settings.IsEnabled("RagePowerElementalStance"))
                {
                    reqs.Add("ElementalStanceRagePowerAcid");
                    reqs.Add("ElementalStanceRagePowerFire");
                    reqs.Add("ElementalStanceRagePowerElectricity");
                    reqs.Add("ElementalStanceRagePowerCold");
                }


                feature.SetGroups(FeatureGroup.RagePower);

                feature.AddIncreaseActivatableAbilityGroupSize(group: Kingmaker.UnitLogic.ActivatableAbilities.ActivatableAbilityGroup.BarbarianStance);
                feature.AddPrerequisiteFeaturesFromList(reqs, 2);
                feature.Configure();
            }
            else
            {
                var feature = MakerTools.MakeFeature(sysname, displayName, desc);


                feature.Configure();
            }

        }


        public static void Finish()
        {
            if (Settings.IsEnabled("RagePowerRageStanceMastery"))
            {

                var mastery = BlueprintTool.Get<BlueprintFeature>("RageStanceMastery");

                var deadlyFeature = BlueprintTool.Get<BlueprintFeature>("c841ffa13d39ce442a408f57feb3cb8e");
                foreach (var comp in deadlyFeature.Components)
                {
                    if (comp is PrerequisiteClassLevel classLevel)
                    {
                        mastery.AddComponent<PrerequisiteClassLevel>(x =>
                        {

                            x.m_CharacterClass = classLevel.m_CharacterClass;
                            x.Level = classLevel.Level + 10;
                            x.Group = Prerequisite.GroupType.Any;
                        });
                    }
                    else if (comp is PrerequisiteArchetypeLevel arche)
                    {
                        mastery.AddComponent<PrerequisiteArchetypeLevel>(x =>
                        {
                            x.m_CharacterClass = arche.m_CharacterClass;
                            x.Level = arche.Level + 10;
                            x.m_Archetype = arche.m_Archetype;
                            x.Group = Prerequisite.GroupType.Any;
                        });

                    }
                }
            }
        }
    }
}

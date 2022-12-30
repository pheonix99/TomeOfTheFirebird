using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.Modified_Content.ImprovedMultiarchetypeProjct
{
    public class ArchetypeBoostData
    {
        
        public string ArchetypeGuid;
        public string[] FeatureGuids;
        

        public string progressionGuid = "";
    }

    

    class FighterCombatBoosts
    {
        private static BlueprintFeatureSelectionReference selector;
        static List<ArchetypeBoostData> archetypeBoostDatas = new();
        static BlueprintFeatureReference braveryRef;
        private static void StripBravery(BlueprintArchetype archetype)
        {
            archetype.RemoveFeatures.ForEach(x =>
            {
                x.m_Features.Remove(x => x.deserializedGuid.Equals(braveryRef.deserializedGuid));


            });
        }

        public static void AddMinorClassBoost(string archetype, params string[] features)
        {
            if (archetypeBoostDatas.Any(x=>x.ArchetypeGuid == archetype))
            {
                return;
            }
            else
            {
                archetypeBoostDatas.Add(new ArchetypeBoostData() { ArchetypeGuid = archetype, FeatureGuids = features });
            }


        }

        public static void Patch()
        {
            string braveryGUID = "f6388946f9f472f4585591b80e9f2452";
            var braveryFeature = BlueprintTool.Get<BlueprintFeature>(braveryGUID);
           
            var masterBoostGUID = Main.TotFContext.Blueprints.GetDerivedMaster("FighterCombatBoostsMaster");
            void ProcessBoostDatum(ArchetypeBoostData datum)
            {
                var archetype = BlueprintTool.Get<BlueprintArchetype>(datum.ArchetypeGuid);
                if (archetype is null)
                {
                    Main.TotFContext.Logger.LogError($"Could Not Load Archetype With GUID: {datum.ArchetypeGuid}");
                }    
                

                
                StripBravery(archetype);
                IEnumerable<BlueprintFeatureBaseReference> refs = datum.FeatureGuids.Select(x => BlueprintTool.GetRef<BlueprintFeatureBaseReference>(x));
                Dictionary<int, List<BlueprintFeatureBaseReference>> addedAt = new();
                BlueprintFeatureBaseReference first = null;
                BlueprintFeatureBaseReference reqs = null;
                foreach(LevelEntry l in archetype.AddFeatures)
                {
                    foreach(var s in refs)
                    {
                        if (l.m_Features.Contains(s))
                        {
#if DEBUG
                            Main.TotFContext.Logger.Log($"Found {s.NameSafe()} in {archetype.name} at level {l.Level}");
#endif
                            if (first == null)
                            {
                                first = s;
                            }
                            if (s.Get().GetComponents<Prerequisite>().Any())
                            {
                                reqs = s;
                            }
                            if (!addedAt.ContainsKey(l.Level))
                            {
                                addedAt.Add(l.Level, new());
                            }

                            addedAt[l.Level].Add(s);
                            l.m_Features.Remove(s);
                        }
                    }
                }
                if (first == null)
                    return;
                var firstGet = first.Get();
                var newGUID = Main.TotFContext.Blueprints.GetDerivedGUID(archetype.name + "CombatBoostProgression", masterBoostGUID, archetype.AssetGuid);

                var newProg = MakerTools.MakeProg(archetype.name + "CombatBoostProgression", firstGet.Name, firstGet.Description, firstGet.Icon);
                foreach(var level in addedAt)
                {
                    

                    newProg.SetLevelEntry(level.Key, level.Value.Select(x=> (Blueprint<BlueprintFeatureBaseReference>)x).ToArray());
                }
                newProg.SetClasses("48ac8db94d5de7645906c7d0ad3bcfbd");
                var made = newProg.Configure();

                FeatureSelectionConfigurator.For(selector).AddToAllFeatures(made).Configure();

            }
            var fighterProgress = BlueprintTool.Get<BlueprintProgression>("b50e94b57be32f74892f381ae2a8905a");
            fighterProgress.LevelEntries.ForEach(x =>
            {
                x.m_Features.Remove(x => x.deserializedGuid.Equals(braveryFeature.AssetGuid));
            });
            fighterProgress.LevelEntries.FirstOrDefault(x => x.Level == 2).m_Features.Add(selector.Get().ToReference<BlueprintFeatureBaseReference>());
            Main.TotFContext.Logger.LogPatch("Replaced Old Model Bravery With Combat Boosts", fighterProgress);

            foreach(var datum in archetypeBoostDatas)
            {
                ProcessBoostDatum(datum);


            }



            foreach (var arch in BlueprintTool.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd").Archetypes)
            {
                var l2 = arch.RemoveFeatures.FirstOrDefault(x => x.Level == 2);
                if (l2 == null)
                    continue;
                if (l2.m_Features.Any(x => x.deserializedGuid.Equals(braveryFeature.AssetGuid)))
                {
                    arch.RemoveFeatures.ForEach(x =>
                    {
                        x.m_Features.Remove(x => x.deserializedGuid.Equals(braveryFeature.AssetGuid));


                    });
                    l2.m_Features.Add(selector.Get().ToReference<BlueprintFeatureBaseReference>());
                    Main.TotFContext.Logger.LogPatch("Replaced Old Model Bravery Removal With Combat Boosts On Unprocessed Archetype", arch);

                }

            }
            //TODO patch default builds for Wendy, Regill, Trever

            //TODO
        }

        public static void Setup()
        {
            string braveryGUID = "f6388946f9f472f4585591b80e9f2452";
            var braveryFeature = BlueprintTool.Get<BlueprintFeature>(braveryGUID);
            braveryRef = BlueprintTool.GetRef<BlueprintFeatureReference>(braveryGUID);
            var masterGUID = Main.TotFContext.Blueprints.GetDerivedMaster("FighterCombatBoostsMaster");

            FeatureConfigurator.For("6ba2b2178dfc4331a34cc2a8a2b68d6a").AddPrerequisiteProficiency(armorProficiencies: new Kingmaker.Blueprints.Items.Armors.ArmorProficiencyGroup[] { Kingmaker.Blueprints.Items.Armors.ArmorProficiencyGroup.TowerShield }, weaponProficiencies: new Kingmaker.Enums.WeaponCategory[] { }, checkInProgression:false).Configure();

            AddMinorClassBoost("8dff97413c63c1147be8a5ca229abefc", features: "6ba2b2178dfc4331a34cc2a8a2b68d6a");//DHS
            AddMinorClassBoost("a599da9a8a6b9e54083b0a4d2a25db59", "6c97b3fd5d354454c9f69fea5348a7e8");//TSS
            AddMinorClassBoost("84643e02a764bff4a9c1aba333a53c89", features: "ab9d45de98fe56441a4c012f70dad6ee");//2Handed
            AddMinorClassBoost("fdee5f25a5d0fe0448d093b462435c0c", features: "fcffd9b743a98784fb9e293c22ee6aff");//Armriger
            AddMinorClassBoost("23d88af5a9470b845b893b31895b20c9",  "3cb9c3be879cf7a40b9db71a9b051b5b", "639652120568b7449922479ab8dab947", "410c4e8bba869f844868c0deedb84ab7");//Homebrew Archetypes Viking

            var braveryProg = MakeBraveryProg();

            BlueprintProgressionReference MakeBraveryProg()
            {

                BlueprintGuid braveryGUID = Main.TotFContext.Blueprints.GetDerivedGUID("BraveryCombatBoostProgression", masterGUID, braveryFeature.AssetGuid);
                var config = MakerTools.MakeProg("BraveryCombatBoostProgression", "Bravery", "", braveryFeature.Icon);
                config.SetIsClassFeature(true);
                config.SetDescription(braveryFeature.m_Description);
                config.SetLevelEntry(2, braveryGUID);
                config.SetLevelEntry(6, braveryGUID);
                config.SetLevelEntry(10, braveryGUID);
                config.SetLevelEntry(14, braveryGUID);
                config.SetLevelEntry(18, braveryGUID);
                config.SetClasses("48ac8db94d5de7645906c7d0ad3bcfbd");
                var made = config.Configure();


                Main.TotFContext.Logger.LogPatch("Converted Combat Boost To Progression", made);

                return made.ToReference<BlueprintProgressionReference>();
            }

            BlueprintFeatureSelectionReference MakeBoostSelector()
            {
                var selector = MakerTools.MakeFeatureSelector("CombatBoostFeatureSelector", "Combat Boost", "At 2nd level, a fighter can select a combat boost that will advance as he levels.");
                selector.SetIsClassFeature(true);

                selector.AddToAllFeatures("BraveryCombatBoostProgression");
                var made = selector.Configure();


                return made.ToReference<BlueprintFeatureSelectionReference>();
            }

            selector = MakeBoostSelector();



           

            
            
        }
    }
}

using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.New_Content
{
    class WitchPatrons
    {
       

        private class PatronDefine
        {
            

            public List<string> spells = new();
            public Func<bool> extraReqs;
            public string Name;

            public IEnumerable<string> archetypeSelectorsToAppendTo;

            public PatronDefine(string name, List<string> spells, Func<bool> extraReqs = null, IEnumerable<string> arches = null)
            {
                this.spells = spells;
                this.extraReqs = extraReqs;
                Name = name;
                archetypeSelectorsToAppendTo = arches ?? new string[] { };
            }

            public bool CanComplete()
            {
                if (!Settings.IsEnabled(SettingName))
                    return false;
                else if (extraReqs == null)
                    return true;
                else return extraReqs.Invoke();

            }

            public string ProgName => "Witch" + Name + "PatronProgression";
            public string SettingName => "WitchPatron" + Name;
        }

        static List<PatronDefine> patronDefines = new();


        public static void Make()
        {
            if (Settings.IsTTTBaseEnabled())
                BlueprintTool.AddGuidsByName(("SecondPatronReference", "d3135a2ddba34502b82670ed770c9068"));

            BlueprintTool.AddGuidsByName(("HagboundPatronSelect", "0b9af221d99a91842b3a2afbc6a68a1e"));
            
            BlueprintTool.AddGuidsByName(("ElementalPatronSelect", "3172b6960c774e19ad029c5e4a96d3e4"));
            if (Settings.IsCharOpsPlusEnabled())
            {
                BlueprintTool.AddGuidsByName(("WinterWitchPatronSelect", "43e304fade8d447fabf517981fd064c1"));
            }

            BlueprintFeature template = BlueprintTools.GetBlueprint<BlueprintFeature>("4f068ba134bcabf47a370c5ecde812c4");
            BlueprintCharacterClassReference witch = BlueprintTools.GetBlueprintReference<BlueprintCharacterClassReference>("1b9873f1e7bfe5449bc84d03e9c8e3cc");
            BlueprintProgression templateprog = BlueprintTools.GetBlueprint<BlueprintProgression>("cad7c2fdabeb9574f95f4b9ffee20afe");
            BlueprintFeatureSelection witchSelector = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("381cf4c890815d049a4420c6f31d063f");
            MakeAnimal();
            MakeDeath();
            MakeLight();
            MakePlague();
            MakeProtection();
            void MakeAnimal()
            {
                List<string> spells = new();
                spells.Add("403cf599412299a4f9d5d925c7b9fb33");//COTW - magic fang
                spells.Add("4c3d08935262b6544ae97599b3a9556d");//COTW - bull's strength
                spells.Add("754c478a2aa9bb54d809e648c3f7ac0e");
                spells.Add("c83db50513abdf74ca103651931fac4b");
                spells.Add("56923211d2ac95e43b8ac5031bab74d8");
                spells.Add("9b93040dad242eb43ac7de6bb6547030");//COTW - beast shape III
                spells.Add("940a545a665194b48b722c1f9dd78d53");
                spells.Add("cf689244b2c7e904eb85f26fd6e81552");
                spells.Add("a7469ef84ba50ac4cbf3d145e3173f8e");

                patronDefines.Add(new("Animal", spells));

                // Animals (Advanced Player's Guide pg. 70): 2nd — charm animals, 4th — speak with animals, 6th — dominate animal, 8th — summon nature's ally IV, 10th — animal growth, 12th — antilife shell, 14th — beast shape IV, 16th — animal shapes, 18th — summon nature's ally IX.
            }
            void MakeAurora()
            {
                List<string> spells = new();
                spells.Add("91da41b9793a4624797921f221db653c");//Color Spray
                spells.Add("56b8f0304a704a67b3c35cbe8c774854");//Hypnotic Pattern - expanded Content Required!
                spells.Add("");//Need Wall Of Nausea Replacement
                spells.Add("4b8265132f9c8174f87ce7fa6d0fe47b");//RainbowPattern
                spells.Add("");//Need Blazing Rainbow Replacement ... or implement it
                spells.Add("6303b404df12b0f4793fa0763b21dd2c");//Elemental Assessor. Is Assessor on level?
                spells.Add("b22fd434bdb60fb4ba1068206402c4cf");//PrismaticSpray
                spells.Add("");//Need Prismatic Wall replacement. That thing is an ai-breaker can't implement - possibly schintilating pattern
                spells.Add("ba48abb52b142164eba309fd09898856");//Polar Midnight
                                                               //2nd — color spray, 4th — hypnotic pattern, 6th — wall of nauseaACG, 8th — rainbow pattern, 10th — blazing rainbowACG, 12th — programmed image, 14th — prismatic spray, 16th — prismatic wall, 18th — polar midnightUM.

            }
            void MakeAutumn()
            {
                List<string> spells = new();
                spells.Add("450af0402422b0b4980d9c2175869612");//Ray Of Enfeeblement
                spells.Add("29ccc62632178d344ad0be0865fd3113");//Create Pit
                spells.Add("");//gentle repose replacement - soothing mud in COTW
                spells.Add("VitrolicMist");
                spells.Add("6d1d48a939ce475409f06e1b376bc386");//Major Creation Replacement - vinetrap - vinetrap in COTWW
                spells.Add("dbf99b00cd35d0a4491c6cc9e771b487");
                spells.Add("8c29e953190cc67429dc9c701b16b7c2");
                spells.Add("08323922485f7e246acb3d2276515526");
                spells.Add("b24583190f36a8442b212e45226c54fc");

                /// 2nd — ray of enfeeblement, 4th — create pit, 6th — gentle repose, 8th — vitriolic mist, 10th — major creation, 12th — acid fog, 14th — caustic eruption, 16th — horrid wilting, 18th — wail of the banshee.
            }

            void MakeDeath()
            {
                List<string> spells = new();

                spells.Add("450af0402422b0b4980d9c2175869612");


                if (!Settings.IsEnabled("WitchPatronDeathL2replace"))
                {
                    spells.Add("c36c1d11771b0584f8e100b92ee5475b");
                }
                else
                {
                    spells.Add("b7731c2b4fa1c9844a092329177be4c3");

                }
                spells.Add("GloomblindBolts");
                spells.Add("f2f1efac32ea2884e84ecaf14657298b");//Boneshatter;
                spells.Add(("1cde0691195feae45bab5b83ea3f221e"));//Wracking Ray
                spells.Add(("a89dcbbab8f40e44e920cc60636097cf"));//CircleOfDeath
                spells.Add(("6f1dcf6cfa92d1948a740195707c0dbe"));//FingerOfDeath
                spells.Add(("08323922485f7e246acb3d2276515526"));//HorridWilting
                spells.Add(("b24583190f36a8442b212e45226c54fc"));//HorridWilting





                
                patronDefines.Add(new PatronDefine("Death", spells, () => { return Settings.IsEnabled("GloomblindBolts"); }));//TODO patch to work with expanded content gloomblind bolts
                

            }

          
            void MakeEnchantment()
            {
                List<string> spells = new();
                spells.Add("feb70aab86cc17f4bb64432c83737ac2");//COTW - command
                spells.Add("fd4d9fd7f87575d47aafe2a64a6e2d8d");//COTW - laughter
                spells.Add("e6048d85fc3294f4c92b21c8d7526b1f");//COTW - Cacophonus call
                spells.Add("dd2918e4a77c50044acba1ac93494c36");//
                spells.Add("d7cbd2004ce66a042aeab2e95a3c5c61");
                spells.Add("d316d3d94d20c674db2c24d7de96f6a7");//COTW - serentity
                spells.Add("cbf3bafa8375340498b86a3313a11e2f");
                spells.Add("");//irresiststable dange
                spells.Add("3c17035ec4717674cae2e841a190e757");

                //Remember to add to Winter Witch!
                // [PFS Legal] Enchantment (Ultimate Magic pg. 83): 2nd — unnatural lust, 4th — calm emotions, 6th — unadulterated loathing, 8th — overwhelming grief, 10th — dominate person, 12th — geas, 14th — euphoric tranquility, 16th — demand, 18th — dominate monster.
            }

         
          
            void MakeLight()
            {
                List<string> spells = new();
                spells.Add("39a602aa80cc96f4597778b6d4d49c0a");//Flare Burst - COTW used color spray
                spells.Add("BurstOfRadiance");//
                spells.Add("bf0accce250381a44b857d4af6c8e10d");//Searing Light - COTW used Remove Blindness, disregarding because this is baby sunbeam/sunburst and the game always subs searing for daylight
                spells.Add("4b8265132f9c8174f87ce7fa6d0fe47b");
                spells.Add("ebade19998e1f8542a1b55bd4da766b3");
                spells.Add("f8cea58227f59c64399044a82c9735c4");//Chains Of Light - added because seriously Sirocco?
                //TODO find replaement out of theme
                spells.Add("1fca0ba2fdfe2994a8c8bc1f0f2fc5b1");//Sunbeam
                spells.Add("e96424f70ff884947b06f41a765b7658");//Sunburst
                spells.Add("08ccad78cac525040919d51963f9ac39");
                // [PFS Legal] Light (Ultimate Magic pg. 83): 2nd — dancing lantern, 4th — continual flame, 6th — daylight, 8th — rainbow pattern, 10th — fire snake, 12th — sirocco, 14th — sunbeam, 16th — sunburst, 18th — fiery body.

                patronDefines.Add(new("Light", spells, ()=> { return Settings.IsEnabled("BurstOfRadiance"); }));

                
            }

            void MakeMountain()
            {
                List<string> spells = new();
                spells.Add("85067a04a97416949b5d1dbf986d93f3");
                spells.Add("5181c2ed0190fc34b8a1162783af5bf4");
                spells.Add("EarthTremor");//COTW used battering blast, lolno go for that tremor attack spell
                spells.Add("d1afa8bc28c99104da7d784115552de5");
                spells.Add("7c5d556b9a5883048bf030e20daebe31");//COTW used stoneskin, communal - using
                spells.Add("e243740dfdb17a246b116b334ed0b165");//COTW used Stone To Flesh - hilariously niche but I don't think this game could cope with Flesh To Stone. Using
                spells.Add("3ecd589cf1a55df42a3b66940ee93ea4");//Summong Greater Earth Elemental 

                spells.Add("65254c7a2cf18944287207e1de3e44e8");//Summong Elder Earth Elemental 
                spells.Add("01300baad090d634cb1a1b2defe068d6");//Summong Elder Earth Elemental 
                //Mountain (Heroes of the Wild pg. 13): 2nd — stone fist, 4th — stone call, 6th — stone shape, 8th — spike stones, 10th — wall of stone, 12th — flesh to stone, 14th — stone tell, 16th — repel metal or stone, 18th — clashing rocks.
            }
            
            void MakePlague()
            {
                List<string> spells = new();
                spells.Add("fa3078b9976a5b24caf92e20ee9c0f54");//COTW - ray of sickening
                if (Settings.IsEnabled("PlaguePerniciousPoison"))
                    spells.Add("dee3074b2fbfb064b80b973f9b56319e");//COTW - pernicious poison
                else
                    spells.Add("0b101dd5618591e478f825f0eef155b4");
                spells.Add("48e2744846ed04b4580be1a3343a5d3d");
                spells.Add("4b76d32feb089ad4499c3a1ce8e1ac27");
                spells.Add("548d339ba87ee56459c98e80167bdf10");//COTW - cloudkill
                spells.Add("82a5b848c05e3f342b893dedb1f9b446");//PlagueStorm - COTW
                spells.Add("76a11b460be25e44ca85904d6806e5a3");//COTW - create undead kicked up a level because ye gods plague not getting plage storm
                spells.Add("08323922485f7e246acb3d2276515526");//COTW - Horrid WIlting
                spells.Add("37302f72b06ced1408bf5bb965766d46");
                // Plague (Advanced Player's Guide pg. 70): 2nd — detect undead, 4th — command undead, 6th — contagion, 8th — animate dead, 10th — giant vermin, 12th — create undead, 14th — control undead, 16th — create greater undead, 18th — energy drain.
                //Add to hagbound
                patronDefines.Add(new("Plague", spells, arches: new string[] { "HagboundPatronSelect" }));
            }
            void MakeProtection()
            {
                List<string> spells = new();
                spells.Add("183d5bb91dea3a1489a6db6c9cb64445");//Shield of faith - h
                spells.Add("21ffef7791ce73f468b6fca4d9371e8b");
                spells.Add("d2f116cfe05fcdd4a94e80143b67046f");//COTW - protection from energy
                spells.Add("c66e86905f7606c4eaa5c774f0357b2b");
                spells.Add("7c5d556b9a5883048bf030e20daebe31");//COTW used stoneskin, communal - using
                spells.Add("fafd77c6bfa85c04ba31fdc1c962c914");//COTW - Restoration, Greater
                spells.Add("42aa71adc7343714fa92e471baa98d42");//COTW - protection from spells
                spells.Add("7ef49f184922063499b8f1346fb7f521");//COTW - Seamantle
                spells.Add("87a29febd010993419f2a4a9bee11cfc");//COTW - mind blank, communal

                // [PFS Legal] Protection (Heroes of the High Court pg. 9): 2nd — sanctuary, 4th — resist energy, 6th — wrathful mantleAPG, 8th — stoneskin, 10th — interposing hand, 12th — forbiddance, 14th — greater spell immunity, 16th — prismatic wall, 18th — freedom.

                patronDefines.Add(new("Protection", spells));
            }
            void MakeSpring()
            {
                List<string> spells = new();
                spells.Add("f3c0b267dd17a2a45a40805e31fe3cd1");
                spells.Add("6c7467f0344004d48848a43d8c078bf8");//COTW sickening entnaglement
                spells.Add("d219494150ac1f24f9ce14a3d4f66d26");//COTW feather step mass
                spells.Add("a5e23522eda32dc45801e32c05dc9f96");//COTW Good Hope
                spells.Add("");//COTW constricting coils ... huh?
                spells.Add("645558d63604747428d55f0dd3a4cb58");
                spells.Add("26be70c4664d07446bdfe83504c1d757");//COTW changestaff
                spells.Add("7cfbefe0931257344b2cb7ddc4cdff6f");//COTW - stormbolts
                spells.Add("");

                // [PFS Legal] Spring (Ultimate Wilderness pg. 88): 2nd — feather fall, 4th — alter self, 6th — pup shape, 8th — trueform, 10th — lightning arc, 12th — chain lightning, 14th — control weather, 16th — stormbolts, 18th — time stop.
            }

            void MakeStorm()
            {
                List<string> spells = new();
                spells.Add("");
                spells.Add("");
                spells.Add("2a9ef0e0b5822a24d88b16673a267456");//Call Lightning
                spells.Add("fcb028205a71ee64d98175ff39a0abf9");//I
                spells.Add("d5a36a7ee8177be4f848b953d1c53c84");
                spells.Add("");
                spells.Add("");
                spells.Add("7cfbefe0931257344b2cb7ddc4cdff6f");//Not sure what this is
                spells.Add("5d8f1da2fdc0b9242af9f326f9e507be");//COTW - winds of vegneance
                //Add to elemental witch
                //Storms (Heroes of the Wild pg. 13): 2nd — obscuring mist, 4th — fog cloud, 6th — call lightning, 8th — ice storm, 10th — call lightning storm, 12th — wind walk, 14th — control weather, 16th — whirlwind, 18th — storm of vengeance.
            }


            void MakeSummer()
            {
                List<string> spells = new();
                spells.Add("f8774451760a427ab4694d10581cfda6");//Goodberry - expanded content!
                spells.Add("");//FlamingSphere - needs replacer
                spells.Add("bf0accce250381a44b857d4af6c8e10d");//Searing Light
                spells.Add("");//Greater flaming
                spells.Add("WallOfFireAbility");//Wall of fire - from EC!
                spells.Add("093ed1d67a539ad4c939d9d05cfe192c");
                spells.Add("1fca0ba2fdfe2994a8c8bc1f0f2fc5b1");//Sunbeam
                spells.Add("e96424f70ff884947b06f41a765b7658");//Sunburst
                spells.Add("08ccad78cac525040919d51963f9ac39");

                // [PFS Legal] Summer (Ultimate Wilderness pg. 88, Heroes of the Wild pg. 13): 2nd — goodberry, 4th — flaming sphere, 6th — daylight, 8th — greater flaming sphere, 10th — wall of fire, 12th — sirocco, 14th — sunbeam, 16th — sunburst, 18th — fiery body.
            }
            
            void MakeWater()
            {
                List<string> spells = new();
                spells.Add("");//Hydraulic push from expanded content
                spells.Add("");//Slipstream from expanded content
                spells.Add("");//Need replacement for Water Breathing
                spells.Add("");//Need replacement for control water
                spells.Add("");//Need replacement for geyser
                spells.Add("");//e body III
                spells.Add("");// e body IV
                spells.Add("7ef49f184922063499b8f1346fb7f521");//Seamantle
                spells.Add("");//Tsunami

                // Water (Advanced Player's Guide pg. 70): 2nd — bless water/curse water, 4th — slipstream, 6th — water breathing, 8th — control water, 10th — geyser, 12th — elemental body III (water only), 14th — elemental body IV (water only), 16th — seamantle, 18th — tsunami.
            }

            void ProcessPatron(PatronDefine patronDefine)
            {
                if (patronDefine.CanComplete())
                {

                    var config = ProgressionConfigurator.New(patronDefine.ProgName, Main.TotFContext.Blueprints.GetGUID(patronDefine.ProgName).ToString());
                    config.SetDisplayName(LocalizationTool.CreateString(patronDefine.ProgName + ".Name", patronDefine.Name));
                    config.AddToClasses(new Blueprint<BlueprintCharacterClassReference>[] { witch });

                    List<BlueprintAbility> spells = patronDefine.spells.Select(x => BlueprintTool.Get<BlueprintAbility>(x)).ToList();
                   
                    for (int i = 0; i < 9; i++)
                    {
                        int spelllevel = i + 1;
                        BlueprintFeature feature = MakeEntry(spelllevel, spells[i], patronDefine.Name);

                        config.AddToLevelEntries(spelllevel * 2, new Blueprint<BlueprintFeatureBaseReference>[] { feature.ToReference<BlueprintFeatureBaseReference>() });
                      
                        
                        

                    }
                    config.AddSpellsToDescription(introduction: templateprog.GetComponent<AddSpellsToDescription>().Introduction, spells: patronDefine.spells.Select(x=>(Blueprint<BlueprintAbilityReference>)x).ToList());
                    config.SetIsClassFeature(true);
                    
                    

                 


                    if (Settings.IsTTTBaseEnabled())
                    {
                        //prog.AddFacts(new() { "SecondPatronReference" });
                    }
                   
                    var prog = config.SetGroups(FeatureGroup.WitchPatron).Configure();
                    Main.TotFContext.Logger.LogPatch(prog);

                    
                        FeatureSelectionConfigurator.For(witchSelector).AddToAllFeatures( prog).Configure();
                    if (Settings.IsTTTBaseEnabled())
                    {
                        FeatureSelectionConfigurator.For("24afc8be7a964e5a939b2a199ba60682").AddToAllFeatures(prog).Configure();
                    }
                    foreach(string s in patronDefine.archetypeSelectorsToAppendTo)
                    {
                        FeatureSelectionConfigurator.For(s).AddToAllFeatures(prog).Configure();
                    }
                    
                }
                else
                {
                    BlueprintProgression progression = TabletopTweaks.Core.Utilities.Helpers.CreateBlueprint<BlueprintProgression>(Main.TotFContext, patronDefine.ProgName, x =>
                    {
                        x.SetName(Main.TotFContext, patronDefine.Name);
                        x.AddClass(witch);
                        x.LevelEntries = new LevelEntry[0];
                        x.GiveFeaturesForPreviousLevels = true;
                        for (int i = 0; i < 9; i++)
                        {
                            int spelllevel = i + 1;

                            BlueprintFeature feature = TabletopTweaks.Core.Utilities.Helpers.CreateBlueprint<BlueprintFeature>(Main.TotFContext, $"Witch{patronDefine.Name}PatronSpellLevel{spelllevel}", x =>
                            {
                                x.HideInCharacterSheetAndLevelUp = true;
                            
                                

                            });
                           
                         

                        }
                        
                        x.IsClassFeature = true;

                    });
                }


            }
           

            

            BlueprintFeature MakeEntry(int level, BlueprintAbility Spell, string patron)
            {
                BlueprintFeature entry = TabletopTweaks.Core.Utilities.Helpers.CreateBlueprint<BlueprintFeature>(Main.TotFContext, $"Witch{patron}PatronSpellLevel{level}", x =>
                {
                    x.HideInCharacterSheetAndLevelUp = true;
                    x.SetNameDescription(template);
                    x.IsClassFeature = true;
                    x.AddComponent<AddKnownSpell>(x =>
                    {
                        x.m_Spell = Spell.ToReference<BlueprintAbilityReference>();
                        x.m_CharacterClass = witch;
                        x.SpellLevel = level;
                    });

                });

                return entry;
            }
               

            foreach(var patron in patronDefines)
            {
                ProcessPatron(patron);
            }
        }
    
        
    }
}

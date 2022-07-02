using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;

namespace TomeOfTheFirebird.New_Content
{
    class WitchPatrons
    {
        public static void Make()
        {
            var template = BlueprintTools.GetBlueprint<BlueprintFeature>("4f068ba134bcabf47a370c5ecde812c4");
            var witch = BlueprintTools.GetBlueprintReference<BlueprintCharacterClassReference>("1b9873f1e7bfe5449bc84d03e9c8e3cc");
            var templateprog = BlueprintTools.GetBlueprint<BlueprintProgression>("cad7c2fdabeb9574f95f4b9ffee20afe");
           
            MakeDeath();
            void MakeDeath()
            {
                List<BlueprintAbility> spells = new();
                var rayOfEnfeeblement = BlueprintTools.GetBlueprint<BlueprintAbility>("450af0402422b0b4980d9c2175869612");
                spells.Add(rayOfEnfeeblement);
                var blessingOfCourageAndLife = BlueprintTools.GetBlueprint<BlueprintAbility>("c36c1d11771b0584f8e100b92ee5475b");
                var boneshaker = BlueprintTools.GetBlueprint<BlueprintAbility>("b7731c2b4fa1c9844a092329177be4c3");
                if (Main.TotFContext.NewContent.WitchPatrons.IsDisabled("DeathPatronReplaceBlessingOfCourageAndLife"))
                {
                    spells.Add(blessingOfCourageAndLife);
                }
                else
                {
                    spells.Add(boneshaker);
                    
                }
                spells.Add(BlueprintTool.Get<BlueprintAbility>( "GloomblindBolts"));
                spells.Add(BlueprintTools.GetBlueprint<BlueprintAbility>("f2f1efac32ea2884e84ecaf14657298b"));//Boneshatter;
                spells.Add(BlueprintTools.GetBlueprint<BlueprintAbility>("1cde0691195feae45bab5b83ea3f221e"));//Wracking Ray
                spells.Add(BlueprintTools.GetBlueprint<BlueprintAbility>("a89dcbbab8f40e44e920cc60636097cf"));//CircleOfDeath
                spells.Add(BlueprintTools.GetBlueprint<BlueprintAbility>("6f1dcf6cfa92d1948a740195707c0dbe"));//FingerOfDeath
                spells.Add(BlueprintTools.GetBlueprint<BlueprintAbility>("08323922485f7e246acb3d2276515526"));//HorridWilting
                spells.Add(BlueprintTools.GetBlueprint<BlueprintAbility>("b24583190f36a8442b212e45226c54fc"));//HorridWilting

              

               

                var deathprog = MakePatronProgression("Death", spells);

                

            }

            BlueprintProgression MakePatronProgression(string patronName, List<BlueprintAbility> spells)
            {
                if (spells.Count != 9)
                    return null;
                else
                {
                    var progression = TabletopTweaks.Core.Utilities.Helpers.CreateBlueprint<BlueprintProgression>(Main.TotFContext, $"Witch{patronName}PatronProgression", x =>
                    {
                        x.SetName(Main.TotFContext, patronName);
                        x.AddClass(witch);
                        x.LevelEntries = new LevelEntry[0];
                        for (int i = 0; i < 9; i++)
                        {
                            int spelllevel = i + 1;
                            var feature = MakeEntry(spelllevel, spells[i], patronName);
                            x.LevelEntries = x.LevelEntries.AppendToArray(new LevelEntry { m_Features = new List<BlueprintFeatureBaseReference>() { feature.ToReference<BlueprintFeatureBaseReference>() }, Level = spelllevel * 2 });

                        }
                        x.AddComponent<AddSpellsToDescription>(x =>
                        {
                            x.m_Spells = spells.Select(x => x.ToReference<BlueprintAbilityReference>()).ToArray();
                            x.Introduction = templateprog.GetComponent<AddSpellsToDescription>().Introduction;

                        });
                        x.IsClassFeature = true;
                        x.Groups = new FeatureGroup[] { FeatureGroup.WitchPatron };
                    });
                    Main.TotFContext.Logger.LogPatch(progression);
                    return progression;

                }

            }


            BlueprintFeature MakeEntry(int level, BlueprintAbility Spell, string patron)
            {
                var entry = TabletopTweaks.Core.Utilities.Helpers.CreateBlueprint<BlueprintFeature>(Main.TotFContext, $"Witch{patron}PatronSpellLevel{level}", x =>
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

        }
    
        public static void Finish()
        {
            var witchSelector = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("381cf4c890815d049a4420c6f31d063f");
            if (!Main.TotFContext.NewContent.WitchPatrons.IsDisabled("DeathPatron") && !Main.TotFContext.NewContent.Spells.IsDisabled("GloomblindBolts"))
            {
                witchSelector.AddFeatures(BlueprintTools.GetModBlueprint<BlueprintProgression>(Main.TotFContext, "WitchDeathPatronProgression"));
                Main.TotFContext.Logger.LogPatch("Added Death Patron", witchSelector);
            }
        }
    }
}

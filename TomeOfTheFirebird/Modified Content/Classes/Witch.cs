using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;

namespace TomeOfTheFirebird.Modified_Content.Classes
{
    class Witch
    {
        //TODO patch freezing sphere into Elements 6
        //TODO patch firestorm into Elements 8
        //TODO patch meteor swarm into Elements 9?

        public static void AllPatronFixes()
        {
            bool fixIcons = Settings.IsEnabled("FixWitchSpellIcons");
            
            bool fixWWProg = Settings.IsEnabled("WinterWitchPatronProgression");
            var wwPRC = BlueprintTool.GetRef<BlueprintCharacterClassReference>("eb24ca44debf6714aabe1af1fd905a07");
            var patronselector = BlueprintTool.Get<BlueprintFeatureSelection>("381cf4c890815d049a4420c6f31d063f");

            foreach (var v in patronselector.m_AllFeatures)
            {
                var v2 = BlueprintTools.GetBlueprint<BlueprintProgression>(v.Guid);

                if (v2 != null)
                {
                    var patron = ProgressionConfigurator.For(v2);
                    if (fixIcons)
                    {
                        patron.ModifyLevelEntries(x =>
                          {
                              foreach (var q in x.m_Features)
                              {
                                  var feature = q.Get();

                                  AddKnownSpell referant = feature.GetComponent<AddKnownSpell>();
                                  if (referant != null)
                                  {
                                      FeatureConfigurator.For(feature).SetIcon(referant.m_Spell.Get().Icon).Configure();

                                  }
                                  Main.TotFContext.Logger.LogPatch($"Patched Icon on", feature);
                              }
                          });
                    }
                    if (fixWWProg)
                    {
                        bool hasWW = false;

                        if (v2.m_Classes.Any(x => x.Class.ToReference<BlueprintCharacterClassReference>().Equals(wwPRC)))
                        {
                            Main.TotFContext.Logger.LogPatch("Skipped Adding Winter Witch Progression to patron", v2);
                            hasWW = true;
                        }
                           
                        
                        if (!hasWW)
                        {
                            Main.TotFContext.Logger.LogPatch("Added Winter Witch Progression to patron", v2);
                            patron.AddToClasses(wwPRC);
                        }
                    }
                    patron.Configure();
                }
            }

        }

    }
}

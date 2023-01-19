using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums.Damage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.New_Content.Feats
{
    class ArmorOfThePit
    {
        public static void Make()
        {
            if (Settings.IsEnabled("ArmorOfThePit"))
            {
                var ssOnconfig = MakerTools.MakeFeature("ArmorOfThePitSSOnFeature", "Armor Of The Pit - Scaled Skin", "", hide: true);

                List<DamageEnergyType> damageEnergyTypes = new() { DamageEnergyType.Fire, DamageEnergyType.Cold, DamageEnergyType.Electricity };

                foreach (var d in damageEnergyTypes)
                {
                    var sysfeatureconfig = MakerTools.MakeFeature($"AotPSSonResist{d.ToString()}Feature", $"Armor Of The Pit: Resist {d.ToString()}", "", hide: true);
                    sysfeatureconfig.AddResistEnergy(type: d, value: ContextValues.Constant(5));
                    sysfeatureconfig.SetIsClassFeature(true);
                    var made = sysfeatureconfig.Configure();
                    string name = $"ScaledSkinResist{d.ToString()}Feature";
                    ssOnconfig.AddFeatureIfHasFact(checkedFact: name, feature: made, not: true);

                }
                
                ssOnconfig.AddFacts(facts: new() { "TieflingNAStackerFeature" });
                ssOnconfig.Configure();

                var ssOffconfig = MakerTools.MakeFeature("ArmorOfThePitSSOffFeature", "Armor Of The Pit", "", hide: true);


                ssOffconfig.AddFacts(facts: new() { "TieflingNAStackerFeature", "TieflingNAStackerFeature" });
                ssOffconfig.Configure();

                var config = MakerTools.MakeFeature("ArmorOfThePitMasterFeature", "Armor Of The Pit", "You gain a +2 natural armor bonus.\n Special: If you have the scaled skin racial trait, you instead gain +1 natural armor and resistance 5 to two of the following energy types that you don’t have resistance to already: cold, electricity, and fire", groups: FeatureGroup.Feat);
                config.AddPrerequisiteFeature("5c4e42124dc2b4647af6e36cf2590500");
                config.AddFeatureIfHasFact(checkedFact: "ScaledSkinTieflingRacialFeature", feature: "ArmorOfThePitSSOnFeature");
                config.AddFeatureIfHasFact(checkedFact: "ScaledSkinTieflingRacialFeature", feature: "ArmorOfThePitSSOffFeature", not: true);
                config.Configure();

            }
            else
            {
                var ssOnconfig = MakerTools.MakeFeature("ArmorOfThePitSSOnFeature", "Armor Of The Pit - Scaled Skin", "", hide: true).Configure();
                var ssOffconfig = MakerTools.MakeFeature("ArmorOfThePitSSOffFeature", "Armor Of The Pit", "", hide: true).Configure();
                var config = MakerTools.MakeFeature("ArmorOfThePitMasterFeature", "Armor Of The Pit", "You gain a +2 natural armor bonus.\n Special: If you have the scaled skin racial trait, you instead gain +1 natural armor and resistance 5 to two of the following energy types that you don’t have resistance to already: cold, electricity, and fire").Configure();
            }
        }

        /*
         * 
         * Your fiendish traits take the form of a protective scaly skin.

Prerequisites: Tiefling.

Benefit: You gain a +2 natural armor bonus.

Special: If you have the scaled skin racial trait, you instead gain resistance 5 to two of the following energy types that you don’t have resistance to already: cold, electricity, and fire.
         */

        /*
         */
    }
}

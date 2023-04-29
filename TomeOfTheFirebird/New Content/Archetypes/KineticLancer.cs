using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using System;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.New_Content.Archetypes
{
    /*
     * 

Masters of the sky, kinetic lancers have mastered the ancient art of combat practiced by the dragoons of old, blessed by the wind itself and given power to nearly fly for short periods of time. Untethered by the ground, these warriors can make impressive aerial strikes that would be impossible for their lesser kin. They were the elite forces of the Ghadabi cavalry forces, and may still yet exist in that capacity in some isolated oasis.

Energy Pounce (Ex): At 1st level, a kinetic lancer gains Kinetic Leap as a bonus feat, ignoring its prerequisites, as well as the kinetic blade infusion. Whenever the kinetic lancer accepts burn with their Kinetic Leap feat, they also reduce the burn cost of the kinetic blade infusion as well as any infusion for which it is a prerequisite by 1 until their burn is removed. All movement during a round in which the kinetic lancer has used the Kinetic Leap feat does not provoke attacks of opportunity, and a kinetic lancer does not take falling damage from falling from any height.

This ability replaces the basic utility wild talent and 1st level infusion.

Dragoon Dive (Ex): As a full round action, a kinetic lancer can use their Kinetic Leap feat to leap into the air, making an attack with the kinetic blade infusion or any infusion for which it is a prerequisite at the end of their movement (including vital blade), reducing the burn cost of the blast by 1. This is treated as a charge for the purposes of bonuses and penalties. At 11th level, they instead reduce the burn cost of the blast by 2.

This ability replaces gather power.

Dragoon Leap (Ex): At 2nd level, a kinetic lancer gains the air’s leap utility wild talent, regardless of their element. They also ignore their base land speed for determining if their jumping distance exceeds their base land speed while using the Kinetic Leap feat, allowing them to leap as far as their Acrobatics check would allow. If the kinetic lancer already possesses air’s leap, they can select another utility wild talent for which they qualify.

This ability replaces the 2nd level utility wild talent.

Kinetic Spear (Su): At 5th level, a kinetic lancer can select the following form infusion:

    Kinetic Spear
    Element(s) universal; Type form infusion; Level 3; Burn 2
    Prerequisite(s) kinetic blade
    Associated Blasts any
    Saving Throw none

    You form a dense spear of raw energy. This form infusion functions as kinetic whip except its critical threat range is increased by 1 (this stacks with Improved Critical and keen but is applied last). If you make an attack inside of your natural reach with this infusion, you cannot score a critical hit with this infusion and its damage die is reduced by 1 step. If you also possess the vital blade form infusion, you can use this infusion with it as though it was the kinetic whip form infusion.

Dragoon Frenzy (Ex): At 8th level, a kinetic lancer can make a full-attack with the kinetic blade infusion or any other infusion for which it is a prerequisite while using the dragoon dive class feature. If the kinetic lancer applies the vital blade form infusion to their kinetic blast, all adjacent squares to the target take damage equal to the minimum damage of the kinetic lancer’s kinetic blast (Reflex save for half). A kinetic lancer can choose a number of spaces equal to their Constitution modifier; these spaces do not take damage from this ability.

This ability replaces the 8th level utility wild talent.

Impaling Crash (Su): At 9th level, by accepting 1 point of burn when they use their dragoon dive class feature, they can impale their foe with their kinetic blast upon making a successful attack, leaving it inside of the creature for a number of rounds equal to their Constitution modifier. Each round the creature is impaled by this weapon, they take damage equal to the minimum damage of the kinetic blast (substance infusions do not apply to this damage), although elemental overflow damage is not applied to this damage. The creature can spend a standard action to make a Strength check (DC equal to 10 + twice the kinetic lancer’s Constitution modifier) to remove it.

This ability replaces metakinesis (maximize).

Impossible Leap (Ex): At 11th level, whenever a kinetic lancer possesses 3 or more burn, they are always treated as though they have accepted burn when using the air’s leap wild talent.

This ability replaces supercharge.

Furious Dragoon (Ex): At 13th level, by accepting 2 points of burn when they use their dragoon dive class feature, they can make an additional attack with their kinetic blade or an infusion for which it is a prerequisite.

If the kinetic lancer kinetic blast has the vital blade form infusion applied to it, they instead double the area of additional damage done by dragoon frenzy.

This ability replaces the 13th level infusion.

Brutal Dragoon (Su): At 17th level, whenever a kinetic lancer uses the dragoon dive class feature, they deal 1 additional damage for each damage die their kinetic blast deals and increase the DC of any substance infusion applied to it by +2.

This ability replaces metakinesis (twice).

     */
    class KineticLancer
    {
        public static void Build()
        {
            var guid = Main.TotFContext.Blueprints.GetGUID("KineticLancerArchetype");

            var lancer = ArchetypeConfigurator.New("KineticLancerArchetype", guid.ToString(), "42a455d9ec1ad924d889272429eb8391");
            lancer.SetLocalizedName("KineticLancer.Name");
            lancer.SetLocalizedDescription("KineticLancer.Desc");
            lancer.AddToRemoveFeatures(1, "58d6f8e9eea63f6418b107ce64f315ea");//Infusion
            //Add Removal Of Basic Kinesis Here!
            lancer.AddToAddFeatures(1, EnergyPounce());
            lancer.AddToAddFeatures(1, DragoonDive());
            lancer.AddToRemoveFeatures(1, "71f526b1d4b50b94582b0b9cbe12b0e0");//Gather Power
            lancer.AddToRemoveFeatures(2, "5c883ae0cd6d7d5448b7a420f51f8459");//Wild Talent
            lancer.AddToAddFeatures(2, DragoonLeap());
            lancer.AddToRemoveFeatures(8, "5c883ae0cd6d7d5448b7a420f51f8459");//Wild Talent
            lancer.AddToAddFeatures(8, DragoonFrenzy());
            lancer.AddToRemoveFeatures(9, "0306bc7c6930a5c4b879c7dea78208c2");//Maximize
            lancer.AddToAddFeatures(9, ImpalingCrash());
            lancer.AddToRemoveFeatures(11, "5a13756fb4be25f46951bc3f16448276");//Supercharge
            lancer.AddToAddFeatures(11, ImpossibleLeap());
            lancer.AddToRemoveFeatures(13, "58d6f8e9eea63f6418b107ce64f315ea");//Infusion
            lancer.AddToAddFeatures(13, FuriousDragoon());
            lancer.AddToRemoveFeatures(17, "MetakinesisDoubleFeature");
            lancer.AddToAddFeatures(13, BrutalDragoon());

        }

        private static BlueprintFeature FuriousDragoon()
        {
            var config = MakerTools.MakeFeature("FuriousDragoonFeature", LocalizationTool.GetString("FuriousDragoon.Name"), LocalizationTool.GetString("FuriousDragoon.Desc"), hide: false);





            return config.Configure();
        }

        private static BlueprintFeature BrutalDragoon()
        {
            var config = MakerTools.MakeFeature("BrutalDragoonFeature", LocalizationTool.GetString("BrutalDragoon.Name"), LocalizationTool.GetString("BrutalDragoon.Desc"), hide: false);





            return config.Configure();
        }
        private static BlueprintFeature ImpossibleLeap()
        {
            var config = MakerTools.MakeFeature("ImpossibleLeapFeature", LocalizationTool.GetString("ImpossibleLeap.Name"), LocalizationTool.GetString("ImpossibleLeap.Desc"), hide: false);





            return config.Configure();
        }

        private static BlueprintFeature DragoonFrenzy()
        {
            var config = MakerTools.MakeFeature("DragoonFrenzyFeature", LocalizationTool.GetString("DragoonFrenzy.Name"), LocalizationTool.GetString("DragoonFrenzy.Desc"), hide: false);





            return config.Configure();
        }

        private static BlueprintFeature EnergyPounce()
        {
            var config = MakerTools.MakeFeature("EnergyPounceFeature", LocalizationTool.GetString("EnergyPounce.Name"), LocalizationTool.GetString("EnergyPounce.Desc"), hide: false);
            config.AddFacts(facts: new() { "9ff81732daddb174aa8138ad1297c787" });//Kinetic Blade




            return config.Configure();


        }

        private static BlueprintFeature DragoonDive()
        {
            var config = MakerTools.MakeFeature("DragoonDiveFeature", LocalizationTool.GetString("DragoonDive.Name"), LocalizationTool.GetString("DragoonDive.Desc"), hide: false);
            




            return config.Configure();
        }
        private static BlueprintFeature DragoonLeap()
        {
            var config = MakerTools.MakeFeature("DragoonLeapFeature", LocalizationTool.GetString("DragoonLeap.Name"), LocalizationTool.GetString("DragoonLeap.Desc"), hide: false);





            return config.Configure();
        }

        private static BlueprintFeature ImpalingCrash()
        {
            var config = MakerTools.MakeFeature("ImpalingCrashFeature", LocalizationTool.GetString("ImpalingCrash.Name"), LocalizationTool.GetString("ImpalingCrash.Desc"), hide: false);





            return config.Configure();
        }
    }
}

using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.New_Components.Prerequisites;

namespace TomeOfTheFirebird.New_Content.WildTalents
{
    class BasicKinesis
    {
        public static void Build()
        {
            BlueprintCore.Blueprints.Configurators.Classes.Selection.FeatureSelectionConfigurator UtilitySelector = MakerTools.MakeFeatureSelector("UtilityWildTalentFakeSelector", "Utility Wild Talent", "A kineticist gains her selected element’s basic utility wild talent (basic telekinesis, basic aerokinesis, etc.) as a bonus wild talent at level 1.", false);
            UtilitySelector.SetIsClassFeature(true);

            MakeAerokinesis();


            UtilitySelector.AddToAllFeatures("BasicGeokinesisFeature", "BasicAerokinesisFeature", "BasicHydrokinesisFeature", "BasicPyrokinesisFeature");
            
        }

        public static void Finish()
        {
            FinishAeroBuff();
        }


        private static void FinishAeroBuff()
        {
            BlueprintBuff lifeBubble = BlueprintTool.Get<BlueprintBuff>("4aa87d3319124a2daf74d80ca5d4595e");

            BuffConfigurator patchOnAntiBad = BuffConfigurator.For("BasicAerokinesisBuff");
            patchOnAntiBad.AddSavingThrowBonusAgainstSpecificSpells(spells: lifeBubble.Components.OfType<AddSpellImmunity>().FirstOrDefault().m_Exceptions.Select(x => (Blueprint<Kingmaker.Blueprints.BlueprintAbilityReference>)x).ToList());
            patchOnAntiBad.Configure();

        }

        private static void MakeAerokinesis()
        {
            BlueprintAbility airblast = BlueprintTool.Get<BlueprintAbility>("0ab1552e2ebdacf44bb7b20f5393366d");
            BuffConfigurator aeroBuffConfig = MakerTools.MakeBuff("BasicAerokinesisBuff", "Basic Aerokinesis Breeze", $"You can create a light breeze that blows against a creature or object from a direction of your choice that follows the target wherever it goes. The breeze grants the subject a +2 bonus on saves against very hot conditions, severe heat, breath weapons, and cloud vapors and gases (such as cloudkill, stinking cloud, and inhaled poisons). You can have only one such breeze active at any one time.", icon: airblast.Icon);
            aeroBuffConfig.AddUniqueBuff();
            aeroBuffConfig.AddSavingThrowBonusAgainstDescriptor(bonus: ContextValues.Constant(2), modifierDescriptor: Kingmaker.Enums.ModifierDescriptor.Circumstance, spellDescriptor: new Kingmaker.Blueprints.Classes.Spells.SpellDescriptorWrapper(Kingmaker.Blueprints.Classes.Spells.SpellDescriptor.BreathWeapon));
            aeroBuffConfig.AddRemoveBuffIfCasterIsMissing(removeOnCasterDeath: true);


            BlueprintBuff aerobuff = aeroBuffConfig.Configure();

            BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities.AbilityConfigurator aeroAbilityConfig = MakerTools.MakeAbility("BasicAerokinesisAbility", "Basic Aerokinesis", $"You can create a light breeze that blows against a creature or object from a direction of your choice that follows the target wherever it goes. The breeze grants the subject a +2 bonus on saves against very hot conditions, severe heat, breath weapons, and cloud vapors and gases (such as cloudkill, stinking cloud, and inhaled poisons).  You can have only one such breeze active at any one time.", airblast.Icon, new Kingmaker.Localization.LocalizedString(), new Kingmaker.Localization.LocalizedString());
            aeroAbilityConfig.SetAnimation(Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Kineticist);

            aeroAbilityConfig.SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard);
            aeroAbilityConfig.AddAbilityEffectRunAction(ActionsBuilder.New().ApplyBuffPermanent(buff: aerobuff.AssetGuidThreadSafe, isFromSpell:false, isNotDispelable:true));
            aeroAbilityConfig.AddAbilityKineticist(wildTalentBurnCost: 0, amount: 0, isSpendResource: false);
            aeroAbilityConfig.SetType(AbilityType.SpellLike);
            aeroAbilityConfig.SetCanTargetFriends(true);
            aeroAbilityConfig.SetCanTargetSelf(true);


            BlueprintAbility aeroAbility = aeroAbilityConfig.Configure();

            BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator aeroConfig = MakerTools.MakeFeature("BasicAerokinesisFeature", "Basic Aerokinesis", $"You can create a light breeze that blows against a creature or object from a direction of your choice that follows the target wherever it goes. The breeze grants the subject a +2 bonus on saves against very hot conditions, severe heat, breath weapons, and cloud vapors and gases (such as cloudkill, stinking cloud, and inhaled poisons).  You can have only one such breeze active at any one time.");
            aeroConfig.SetIsClassFeature(true);
            aeroConfig.AddFacts(facts: new List<Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>>() { aeroAbility });

            List<Blueprint<BlueprintFeatureReference>> list = new List<Blueprint<BlueprintFeatureReference>>();
            foreach (string x in KineticistHelpers.PrimaryAirFocues)
                list.Add(x);
            foreach (string x in KineticistHelpers.SecondaryAirFocues)
                list.Add(x);
            aeroConfig.AddPrerequisiteFeaturesFromList(features: list , amount: 1);
            
            Kingmaker.Blueprints.Classes.BlueprintFeature aero = aeroConfig.Configure();

            
        }

        private static void MakeElectrokinesis()
        {
            BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator electroConfig = MakerTools.MakeFeature("BasicElectrokinesisFeature", "Basic Electrokinesis", $"Unlike the typical aerokineticist, you focus much more on your control over electricity. You receive a competence bonus equal to 3 + 1/2 your kineticist level on Disable Device checks against technological objects, and a circumstance bonus on damage rolls equal to 1 + 1/5 your kineticist level on your electric blast, thunderstorm blast, and any composite blast for which electric blast or thunderstorm blast is a prerequisite when using them against creatures of the aquatic or water subtypes or creatures equipped with metal armor or holding metal objects. ");
            electroConfig.SetIsClassFeature(true);
            

            List<Blueprint<BlueprintFeatureReference>> list = new List<Blueprint<BlueprintFeatureReference>>();
            foreach (string x in KineticistHelpers.PrimaryAirFocues)
                list.Add(x);
            foreach (string x in KineticistHelpers.SecondaryAirFocues)
                list.Add(x);
            electroConfig.AddPrerequisiteFeaturesFromList(features: list, amount: 1);
            Kingmaker.Blueprints.Classes.BlueprintFeature aero = electroConfig.Configure();

            
        }

        /*
         * Basic Electrokinesis

Element(s) air; Level 1; Type utility (Su); Burn —
Requirement(s) electric blast

Unlike the typical aerokineticist, you focus much more on your control over electricity. You receive a competence bonus equal to 3 + 1/2 your kineticist level on Disable Device checks against technological objects, and a circumstance bonus on damage rolls equal to 1 + 1/5 your kineticist level on your electric blast, thunderstorm blast, and any composite blast for which electric blast or thunderstorm blast is a prerequisite when using them against creatures of the aquatic or water subtypes or creatures equipped with metal armor or holding metal objects. You cannot learn basic aerokinesis without possessing air blast, and if you possess basic aerokinesis at the time you gain this wild talent, you lose it and any wild talents for which basic aerokinesis is a prerequisite. You also cannot learn air blast unless you already possess electric blast, and if you already possess air blast when you gain this wild talent, it is replaced by electric blast (this could affect which composite blasts you have access to).

You can select this talent in place of basic aerokinesis.
         */

        /*
         *  Basic Geokinesis
Source Occult Adventures pg. 23
Talent Link Link
Element earth; Type utility (Sp); Level 1; Burn 0
You can move up to 5 pounds per kineticist level of rocks, loose earth, sand, clay, and other similar materials up to 15 feet as a move action. You can search earthen and stone areas from a distance as if using the siftAPG cantrip.
         */

        public static void BasicGeokinesis()
        {
            BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator geoConfig = MakerTools.MakeFeature("BasicGeokinesisFeature", "Basic Geokinesis", $"Currently no in-game effect: \nTT: You can move up to 5 pounds per kineticist level of rocks, loose earth, sand, clay, and other similar materials up to 15 feet as a move action. You can search earthen and stone areas from a distance as if using the sift cantrip.");
            geoConfig.SetIsClassFeature(true);
            List<Blueprint<BlueprintFeatureReference>> list = new List<Blueprint<BlueprintFeatureReference>>();
            foreach (string x in KineticistHelpers.PrimaryEarthFocuses)
                list.Add(x);
            foreach (string x in KineticistHelpers.SecondaryEarthFocuses)
                list.Add(x);
            geoConfig.AddPrerequisiteFeaturesFromList(features: list, amount: 1);
            //geoConfig.AddFacts(facts: new List<Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>>() { aeroAbility });

            //Not sure what to do with this bar feat tax for Advanced Kinesis?

            Kingmaker.Blueprints.Classes.BlueprintFeature geo = geoConfig.Configure();
        }

        /*Basic Hydrokinesis
Source Occult Adventures pg. 23
Talent Link Link
Element water; Type utility (Sp); Level 1; Burn 0
You can create water as the cantrip create water, purify water as if using purify food and drink, and dry wet creatures and objects as if using prestidigitation. While you cannot lift water into the air using this ability, you can create mild currents in a body of water by concentrating. These currents are strong enough to run a water mill as if the mill were being turned manually by a creature with a Strength score equal to your Constitution score.
         */
        public static void BasicHydrokinesis()
        {
            BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator hydroConfig = MakerTools.MakeFeature("BasicHydrokinesisFeature", "Basic Hydrokinesis", $"Currently no in-game effect: \nTT: You can create water as the cantrip create water, purify water as if using purify food and drink, and dry wet creatures and objects as if using prestidigitation. While you cannot lift water into the air using this ability, you can create mild currents in a body of water by concentrating. These currents are strong enough to run a water mill as if the mill were being turned manually by a creature with a Strength score equal to your Constitution score.");
            hydroConfig.SetIsClassFeature(true);
            List<Blueprint<BlueprintFeatureReference>> list = new List<Blueprint<BlueprintFeatureReference>>();
            foreach (string x in KineticistHelpers.PrimaryWaterFocuses)
                list.Add(x);
            foreach (string x in KineticistHelpers.SecondaryWaterFocuses)
                list.Add(x);
            hydroConfig.AddPrerequisiteFeaturesFromList(features: list, amount: 1);
            //geoConfig.AddFacts(facts: new List<Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>>() { aeroAbility });

            Kingmaker.Blueprints.Classes.BlueprintFeature hydro = hydroConfig.Configure();

            //Generate purifier solution on rest?
        }

        /*
         * Basic Cryokinesis

Element(s) water; Level 1; Type utility (Su); Burn —
Requirement(s) cold blast

You focus more strongly on your ability to manipulate ice and snow than water in its liquid state. You receive a bonus to your natural armor equal to 1 + ⅕ your kineticist level and can use create water at will, but it instead conjures an equivalent amount of ice. You also receive a circumstance bonus on damage rolls equal to 1 + ⅕ your kineticist level on your cold blast, ice blast, and any composite blast for which cold blast or ice blast is a prerequisite when using them against creatures of the fire subtype and when used in cold temperatures and frigid environments. You cannot learn basic hydrokinesis without possessing water blast, and if you possess basic hydrokinesis at the time you gain this wild talent, you lose it and any wild talents for which basic hydrokinesis is a prerequisite. You also cannot learn water blast unless you already possess cold blast, and if you already possess water blast when you gain this wild talent, it is replaced by cold blast (this could also affect which composite blasts you have access to).

You can select this talent in place of basic hydrokinesis.
         */
        /*
         * Basic Pyrokinesis
Source Occult Adventures pg. 23
Talent Link Link
Element fire; Type utility (Sp); Level 1; Burn 0
You can use your inner flame to reproduce the effects of a flare, light, or sparkAPG cantrip, except that the light you create with light produces heat like a normal flame; using any of the three abilities ends any previous light effect from this wild talent.
         */
        public static void BasicPyrokinesis()
        {
            BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator pyroConfig = MakerTools.MakeFeature("BasicPyrokinesisFeature", "Basic Pyrokinesis", $"Currently no in-game effect: \nTT: You can use your inner flame to reproduce the effects of a flare or light cantrip; using either of these abilities ends any previous light effect from this wild talent.");
            pyroConfig.SetIsClassFeature(true);
            List<Blueprint<BlueprintFeatureReference>> list = new List<Blueprint<BlueprintFeatureReference>>();
            foreach (string x in KineticistHelpers.PrimaryFireFocuses)
                list.Add(x);
            foreach (string x in KineticistHelpers.SecondaryFireFocuses)
                list.Add(x);
            pyroConfig.AddPrerequisiteFeaturesFromList(features: list, amount: 1);
            //geoConfig.AddFacts(facts: new List<Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>>() { aeroAbility });

            Kingmaker.Blueprints.Classes.BlueprintFeature pyro = pyroConfig.Configure();
        }

        public static void BasicTelekinesis()
        {
            BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator teleConfig = MakerTools.MakeFeature("BasicTelekinesisFeature", "Basic Telekinesis", $"Currently no in-game effect: \nTT: This ability is similar to mage hand, except you can move an object that weighs up to 5 pounds per 2 kineticist levels you possess (minimum 5 pounds), and you can move magical objects. Additionally, you can create a container of entwined strands of aether in order to hold liquids or piles of small objects of the same weight. You can dip the container to pick up or drop a liquid as a move action. If you possess the extended range wild talent, you can increase the range of basic telekinesis to medium range and increase the rate of movement to 30 feet per round, and if you possess the extreme range wild talent, You can increase the range of basic telekinesis to long range and increase the rate of movement to 60 feet per round. You can also use your basic telekinesis to duplicate the effects of the open/close cantrip.\nYou can open or close (your choice) a door, chest, box, window, bag, pouch, bottle, barrel, or other container. If anything resists this activity (such as a bar on a door or a lock on a chest), the spell fails. In addition, the spell can only open and close things weighing 30 pounds or less. Thus, doors, chests, and similar objects sized for enormous creatures may be beyond this spell’s ability to affect.");
            teleConfig.SetIsClassFeature(true);
            List<Blueprint<BlueprintFeatureReference>> list = new List<Blueprint<BlueprintFeatureReference>>();
            foreach (string x in KineticistHelpers.PrimaryAetherFocues)
                list.Add(x);
            foreach (string x in KineticistHelpers.SecondaryAetherFocues)
                list.Add(x);
            teleConfig.AddPrerequisiteFeaturesFromList(features: list, amount: 1);
            //geoConfig.AddFacts(facts: new List<Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>>() { aeroAbility });

            Kingmaker.Blueprints.Classes.BlueprintFeature pyro = teleConfig.Configure();
            //Extend opening/closing/looting reach?
        }

        public static void BasicPhytokinesis()
        {
            BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator teleConfig = MakerTools.MakeFeature("BasicPhytokinesisFeature", "Basic Phytokinesis", $"Currently no in-game effect: \nTT: You can prune and otherwise tend plants within 30 feet without using gardening tools. You can search wooded areas and other plant-heavy areas from a distance as if using the sift cantrip. By concentrating, you can detect plants within 120 feet as if using detect animals or plants.");
            teleConfig.SetIsClassFeature(true);
            List<Blueprint<BlueprintFeatureReference>> list = new List<Blueprint<BlueprintFeatureReference>>();
            foreach (string x in KineticistHelpers.PrimaryWoodFocuses)
                list.Add(x);
            foreach (string x in KineticistHelpers.SecondaryWoodFocuses)
                list.Add(x);
            teleConfig.AddPrerequisiteFeaturesFromList(features: list, amount: 1);
            //geoConfig.AddFacts(facts: new List<Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>>() { aeroAbility });

            Kingmaker.Blueprints.Classes.BlueprintFeature pyro = teleConfig.Configure();
       
        }


        public static void BasicChaoskinesis()
        {
            BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator teleConfig = MakerTools.MakeFeature("BasicChaokinesisFeature", "Basic Chaoskinesis", $"Currently no in-game effect: \nTT: You can create a shadow that protects a target from bright light. You can also change gravity to increase a creature’s carrying capacity by half or grant a creature a +4 bonus on Acrobatics checks to jump.\nEach benefit lasts 1 hour or until you use basic chaokinesis again..");
            teleConfig.SetIsClassFeature(true);
            List<Blueprint<BlueprintFeatureReference>> list = new List<Blueprint<BlueprintFeatureReference>>();
            foreach (string x in KineticistHelpers.PrimaryAetherFocues)
                list.Add(x);
            foreach (string x in KineticistHelpers.SecondaryAetherFocues)
                list.Add(x);
            teleConfig.AddPrerequisiteFeaturesFromList(features: list, amount: 1);
            //geoConfig.AddFacts(facts: new List<Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>>() { aeroAbility });

            Kingmaker.Blueprints.Classes.BlueprintFeature pyro = teleConfig.Configure();
       
        }


    }
}

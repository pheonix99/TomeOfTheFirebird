using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.New_Content.WildTalents
{
    class BasicKinesis
    {
        public static void Build()
        {
            var UtilitySelector = MakerTools.MakeFeatureSelector("UtilityWildTalentFakeSelector", "Utility Wild Talent", "A kineticist gains her selected element’s basic utility wild talent (basic telekinesis, basic aerokinesis, etc.) as a bonus wild talent at level 1.", false);
            UtilitySelector.SetIsClassFeature(true);

            UtilitySelector.AddToAllFeatures("BasicGeokinesisFeature", "BasicAerokinesisFeature", "BasicHydrokinesisFeature", "BasicPyrokinesisFeature");
            
        }

        public static void FinishAeroBuff()
        {
            var lifeBubble = BlueprintTool.Get<BlueprintBuff>("4aa87d3319124a2daf74d80ca5d4595e");

            var patchOnAntiBad = BuffConfigurator.For("BasicAerokinesisBuff");
            patchOnAntiBad.AddSavingThrowBonusAgainstSpecificSpells(spells: lifeBubble.Components.OfType<AddSpellImmunity>().FirstOrDefault().m_Exceptions.Select(x => (Blueprint<Kingmaker.Blueprints.BlueprintAbilityReference>)x).ToList());
            patchOnAntiBad.Configure();

        }

        public static void MakeAerokinesis()
        {
            var airblast = BlueprintTool.Get<BlueprintAbility>("0ab1552e2ebdacf44bb7b20f5393366d");
            var aeroBuffConfig = MakerTools.MakeBuff("BasicAerokinesisBuff", "Basic Aerokinesis Breeze", $"You can create a light breeze that blows against a creature or object from a direction of your choice that follows the target wherever it goes. The breeze grants the subject a +2 bonus on saves against very hot conditions, severe heat, breath weapons, and cloud vapors and gases (such as cloudkill, stinking cloud, and inhaled poisons). You can have only one such breeze active at any one time.", icon: airblast.Icon);
            aeroBuffConfig.AddUniqueBuff();
            aeroBuffConfig.AddSavingThrowBonusAgainstDescriptor(bonus: ContextValues.Constant(2), modifierDescriptor: Kingmaker.Enums.ModifierDescriptor.Circumstance, spellDescriptor: new Kingmaker.Blueprints.Classes.Spells.SpellDescriptorWrapper(Kingmaker.Blueprints.Classes.Spells.SpellDescriptor.BreathWeapon));
            aeroBuffConfig.AddRemoveBuffIfCasterIsMissing(removeOnCasterDeath: true);
            

            var aerobuff = aeroBuffConfig.Configure();

            var aeroAbilityConfig = MakerTools.MakeAbility("BasicAerokinesisAbility", "Basic Aerokinesis", $"You can create a light breeze that blows against a creature or object from a direction of your choice that follows the target wherever it goes. The breeze grants the subject a +2 bonus on saves against very hot conditions, severe heat, breath weapons, and cloud vapors and gases (such as cloudkill, stinking cloud, and inhaled poisons).  You can have only one such breeze active at any one time.", airblast.Icon, new Kingmaker.Localization.LocalizedString(), new Kingmaker.Localization.LocalizedString());
            aeroAbilityConfig.SetAnimation(Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Kineticist);

            aeroAbilityConfig.SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard);
            aeroAbilityConfig.AddAbilityEffectRunAction(ActionsBuilder.New().ApplyBuffPermanent(buff: aerobuff.AssetGuidThreadSafe, isFromSpell:false, isNotDispelable:true));
            aeroAbilityConfig.AddAbilityKineticist(wildTalentBurnCost: 0, amount: 0, isSpendResource: false);
            aeroAbilityConfig.SetType(AbilityType.SpellLike);
            aeroAbilityConfig.SetCanTargetFriends(true);
            aeroAbilityConfig.SetCanTargetSelf(true);


            var aeroAbility = aeroAbilityConfig.Configure();

           var aeroConfig = MakerTools.MakeFeature("BasicAerokinesisFeature", "Basic Aerokinesis", $"You can create a light breeze that blows against a creature or object from a direction of your choice that follows the target wherever it goes. The breeze grants the subject a +2 bonus on saves against very hot conditions, severe heat, breath weapons, and cloud vapors and gases (such as cloudkill, stinking cloud, and inhaled poisons).  You can have only one such breeze active at any one time.");
            aeroConfig.SetIsClassFeature(true);
            aeroConfig.AddFacts(facts: new List<Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>>() { aeroAbility });

            var list = new List<Blueprint<BlueprintFeatureReference>>();
            foreach (var x in KineticistHelpers.PrimaryAirFocues)
                list.Add(x);
            foreach (var x in KineticistHelpers.SecondaryAirFocues)
                list.Add(x);
            aeroConfig.AddPrerequisiteFeaturesFromList(features: list , amount: 1);
            var aero = aeroConfig.Configure();

            
        }

        /*
         *  [PFS Legal] Basic Aerokinesis
Source Occult Adventures pg. 23
Talent Link Link
Element air; Type utility (Sp); Level 1; Burn 0
You can create a light breeze that blows against a creature or object from a direction of your choice that follows the target wherever it goes. The breeze grants the subject a +2 bonus on saves against very hot conditions, severe heat, breath weapons, and cloud vapors and gases (such as cloudkill, stinking cloud, and inhaled poisons). This wild talent doesn’t function without air or while underwater. You can have only one such breeze active at any one time.

You can also use your aerokinesis to make it harder to detect you or others by scent. You can designate a number of creatures or objects equal to your Constitution bonus. These creatures and objects always count as being downwind for the purpose of determining the distance at which they can be detected by scent. This effect lasts for 1 hour or until you use basic aerokinesis again, whichever comes first.
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
            var geoConfig = MakerTools.MakeFeature("BasicGeokinesisFeature", "Basic Geokinesis", $"Currently no in-game effect: \nTT: You can move up to 5 pounds per kineticist level of rocks, loose earth, sand, clay, and other similar materials up to 15 feet as a move action. You can search earthen and stone areas from a distance as if using the sift cantrip.");
            geoConfig.SetIsClassFeature(true);
            var list = new List<Blueprint<BlueprintFeatureReference>>();
            foreach (var x in KineticistHelpers.PrimaryEarthFocuses)
                list.Add(x);
            foreach (var x in KineticistHelpers.SecondaryEarthFocuses)
                list.Add(x);
            geoConfig.AddPrerequisiteFeaturesFromList(features: list, amount: 1);
            //geoConfig.AddFacts(facts: new List<Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>>() { aeroAbility });

            var geo = geoConfig.Configure();
        }

        /*Basic Hydrokinesis
Source Occult Adventures pg. 23
Talent Link Link
Element water; Type utility (Sp); Level 1; Burn 0
You can create water as the cantrip create water, purify water as if using purify food and drink, and dry wet creatures and objects as if using prestidigitation. While you cannot lift water into the air using this ability, you can create mild currents in a body of water by concentrating. These currents are strong enough to run a water mill as if the mill were being turned manually by a creature with a Strength score equal to your Constitution score.
         */
        public static void BasicHydrokinesis()
        {
            var hydroConfig = MakerTools.MakeFeature("BasicHydrokinesisFeature", "Basic Hydrokinesis", $"Currently no in-game effect: \nTT: You can create water as the cantrip create water, purify water as if using purify food and drink, and dry wet creatures and objects as if using prestidigitation. While you cannot lift water into the air using this ability, you can create mild currents in a body of water by concentrating. These currents are strong enough to run a water mill as if the mill were being turned manually by a creature with a Strength score equal to your Constitution score.");
            hydroConfig.SetIsClassFeature(true);
            var list = new List<Blueprint<BlueprintFeatureReference>>();
            foreach (var x in KineticistHelpers.PrimaryWaterFocuses)
                list.Add(x);
            foreach (var x in KineticistHelpers.SecondaryWaterFocuses)
                list.Add(x);
            hydroConfig.AddPrerequisiteFeaturesFromList(features: list, amount: 1);
            //geoConfig.AddFacts(facts: new List<Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>>() { aeroAbility });

            var hydro = hydroConfig.Configure();
        }
        /*
         * Basic Pyrokinesis
Source Occult Adventures pg. 23
Talent Link Link
Element fire; Type utility (Sp); Level 1; Burn 0
You can use your inner flame to reproduce the effects of a flare, light, or sparkAPG cantrip, except that the light you create with light produces heat like a normal flame; using any of the three abilities ends any previous light effect from this wild talent.
         */
        public static void BasicPyrokinesis()
        {
            var pyroConfig = MakerTools.MakeFeature("BasicPyrokinesisFeature", "Basic Pyrokinesis", $"Currently no in-game effect: \nTT: You can use your inner flame to reproduce the effects of a flare or light cantrip; using any of the three abilities ends any previous light effect from this wild talent.");
            pyroConfig.SetIsClassFeature(true);
            var list = new List<Blueprint<BlueprintFeatureReference>>();
            foreach (var x in KineticistHelpers.PrimaryFireFocuses)
                list.Add(x);
            foreach (var x in KineticistHelpers.SecondaryFireFocuses)
                list.Add(x);
            pyroConfig.AddPrerequisiteFeaturesFromList(features: list, amount: 1);
            //geoConfig.AddFacts(facts: new List<Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>>() { aeroAbility });

            var hydro = pyroConfig.Configure();
        }
    }
}

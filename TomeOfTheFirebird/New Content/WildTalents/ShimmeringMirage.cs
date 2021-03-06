using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;

namespace TomeOfTheFirebird.New_Content.WildTalents
{
    class ShimmeringMirage
    {
        public static void Make()
        {
            var shieldShroudBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("1f1657d95529d8945964515ca44473aa");
            var armorShroudBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("04d22f8c690781d4c8f61f0437cb91ef");
            var icon = BlueprintTools.GetBlueprint<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564").Icon;

            var mirageBuffWorking = Helpers.MakerTools.MakeBuff("ShimmeringMirageWildTalentSystemBuff", "Shimmering Mirage", "Your shroud bends light, creating a shimmering mirage. While your shroud of water is active, attacks against you suffer a 20% miss chance due to concealment until the next time your burn is removed.");
            mirageBuffWorking.AddConcealment(checkDistance: false, checkWeaponRangeType: false, concealment: Kingmaker.Enums.Concealment.Partial, descriptor: Kingmaker.Enums.ConcealmentDescriptor.Blur, distanceGreater: new Kingmaker.Utility.Feet());
            var buffBuildWorking = mirageBuffWorking.Configure();


            var mirageBuff = Helpers.MakerTools.MakeBuff("ShimmeringMirageWildTalentBuff", "Shimmering Mirage", "Your shroud bends light, creating a shimmering mirage. While your shroud of water is active, attacks against you suffer a 20% miss chance due to concealment until the next time your burn is removed.", icon);
           
            mirageBuff.AddBuffExtraEffects(checkedBuff: shieldShroudBuff, buffBuildWorking);
            mirageBuff.AddBuffExtraEffects(checkedBuff: armorShroudBuff, buffBuildWorking);
            var buffBuild = mirageBuff.Configure();
            
            

            var mirageAbility = Helpers.MakerTools.MakeAbility("ShimmeringMirageWildTalentAbility", "Shimmering Mirage", "Your shroud bends light, creating a shimmering mirage. While your shroud of water is active, attacks against you suffer a 20% miss chance due to concealment until the next time your burn is removed.", icon, new Kingmaker.Localization.LocalizedString(), new Kingmaker.Localization.LocalizedString());
            mirageAbility.AddAbilityKineticist(amount: 1, wildTalentBurnCost: 1, cachedDamageInfo: new List<Kingmaker.UnitLogic.Class.Kineticist.AbilityKineticist.DamageInfo>());
            mirageAbility.SetType(AbilityType.Supernatural);
            mirageAbility.SetRange(AbilityRange.Personal);
            mirageAbility.SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard);
            mirageAbility.SetAnimation(Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Kineticist);
            mirageAbility.AddAbilityEffectRunAction(ActionsBuilder.New().ApplyBuffPermanent(buff: buffBuild, isFromSpell: true, isNotDispelable: true));
            var ability = mirageAbility.Configure();

            var mirage = Helpers.MakerTools.MakeFeature("ShimmeringMirageWildTalent", "Shimmering Mirage", "Your shroud bends light, creating a shimmering mirage. While your shroud of water is active, attacks against you suffer a 20% miss chance due to concealment until the next time your burn is removed.");
            mirage.SetIsClassFeature(true);
            mirage.AddFacts(new List<BlueprintCore.Utils.Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>>() { ability });
            mirage.AddPrerequisiteClassLevel(characterClass: "42a455d9ec1ad924d889272429eb8391", level: 9);
            foreach(string s in KineticistHelpers.PrimaryWaterFocuses)
            {
                mirage.AddPrerequisiteFeature(feature: s, group: Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any);
                
            }
            foreach (string s in KineticistHelpers.SecondaryWaterFocuses)
            {
                mirage.AddPrerequisiteFeature(feature: s, group: Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any);

            }
            mirage.AddPrerequisiteFeature(feature: "29ec36fa2a5b8b94ebce170bd369083a", group: Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.All);


            var mirageMake = mirage.Configure();


            var wtselector = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("5c883ae0cd6d7d5448b7a420f51f8459");

            wtselector.AddFeatures(mirageMake);


        }

        /*
         * 
         *  Shimmering Mirage
Source Occult Adventures pg. 27
Talent Link Link
Element water; Type utility (Sp); Level 5; Burn 1
Prerequisite shroud of water
Your shroud bends light, creating a shimmering mirage. While your shroud of water is active, attacks against you suffer a 20% miss chance due to concealment until the next time your burn is removed.
         */
    }
}

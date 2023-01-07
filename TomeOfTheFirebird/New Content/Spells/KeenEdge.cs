using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using System;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Components;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.Reference;
using UnityEngine;

namespace TomeOfTheFirebird.New_Spells
{
    static class KeenEdge
    {
        static string desc = "This spell makes a weapon magically keen, improving its ability to deal telling blows.This transmutation doubles the threat range of the weapon.A threat range of 20 becomes 19-20, a threat range of 19-20 becomes 17-20, and a threat range of 18-20 becomes 15-20. The spell can be cast only on piercing or slashing weapons.If cast on arrows or crossbow bolts, the keen edge on a particular projectile ends after one use, whether or not the missile strikes its intended target.Treat shuriken as arrows, rather than as thrown weapons, for the purpose of this spell. \n\n Multiple effects that increase a weapon’s threat range (such as the keen special weapon property and the Improved Critical feat) don’t stack.You can’t cast this spell on a natural weapon, such as a claw.";
        static Sprite keenSprite;
        public static void BuildSpell()
        {
            keenSprite = BlueprintTools.GetBlueprint<BlueprintActivatableAbility>("27d76f1afda08a64d897cc81201b5218").Icon;//Keen weapon bond
            AbilityConfigurator maker = MakerTools.MakeSpell("KeenEdge", "Keen Edge",desc , keenSprite, Kingmaker.Blueprints.Classes.Spells.SpellSchool.Transmutation, new Kingmaker.Localization.LocalizedString(), LocalizedStrings.TenMinutePerLevelDuration);


         
            maker.SetRange(AbilityRange.Close).AllowTargeting(false, false, true, true).SetAnimation( UnitAnimationActionCastSpell.CastAnimationStyle.Directional).SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard).SetAvailableMetamagic(Metamagic.Quicken, Metamagic.Extend, Metamagic.Heighten, Metamagic.Reach, Metamagic.CompletelyNormal);
            AbilityConfigurator mainMaker = MakeHandedVersion(true);
            AbilityConfigurator offhandMaker = MakeHandedVersion(false);

           

       
           
            



            maker.AddAbilityVariants( new System.Collections.Generic.List<BlueprintCore.Utils.Blueprint<Kingmaker.Blueprints.BlueprintAbilityReference>>() { mainMaker.Configure().AssetGuidThreadSafe, offhandMaker.Configure().AssetGuidThreadSafe });



            BlueprintAbility made = maker.Configure();
            if (Settings.IsEnabled("KeenEdge"))
            {
                made.AddToSpellList(SpellTools.SpellList.BloodragerSpellList, 3);
                made.AddToSpellList(SpellTools.SpellList.InquisitorSpellList, 3);
                made.AddToSpellList(SpellTools.SpellList.MagusSpellList, 3);
                made.AddToSpellList(SpellTools.SpellList.WizardSpellList, 3);
                made.AddToSpellSpecialization();
            }
        }

        private static AbilityConfigurator MakeHandedVersion(bool main)
        {
            AbilityConfigurator maker = MakerTools.MakeSpell(main ? "KeenEdgePrimary" : "KeenEdgeSecondary", main ? "Keen Edge (Main Hand)" : "Keen Edge (Off Hand)", desc, keenSprite, Kingmaker.Blueprints.Classes.Spells.SpellSchool.Transmutation, new Kingmaker.Localization.LocalizedString(), LocalizedStrings.TenMinutePerLevelDuration);
            maker.SetRange(AbilityRange.Close).AllowTargeting(false, false, true, true).SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Directional).SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard).SetAvailableMetamagic(Metamagic.Quicken, Metamagic.Extend, Metamagic.Heighten, Metamagic.Reach, Metamagic.CompletelyNormal);
           
   
           
            string keen = "102a9c8c9b7a75e4fb5844e79deaf4c0";

            ActionsBuilder actions = ActionsBuilder.New().EnchantWornItem(enchantment: keen, slot: main ? Kingmaker.UI.GenericSlot.EquipSlotBase.SlotType.PrimaryHand : Kingmaker.UI.GenericSlot.EquipSlotBase.SlotType.SecondaryHand, durationValue: MakerTools.GetContextDurationValue(Kingmaker.UnitLogic.Mechanics.DurationRate.TenMinutes, true));
            maker.AddAbilityEffectRunAction(actions);
            maker.AddComponent<AbilityTargetHasSlashingPiercingWeaponInRelevantHand>(new Action<AbilityTargetHasSlashingPiercingWeaponInRelevantHand>(x => x.MainHand = main));
            maker.AddCraftInfoComponent(Kingmaker.Craft.CraftAOE.None,savingThrow:  Kingmaker.Craft.CraftSavingThrow.None,spellType: Kingmaker.Craft.CraftSpellType.Buff);

            return maker;

        }

        //        Keen Edge

        //School transmutation; Level bloodrager 3, inquisitor 3, magus 3, sorcerer/wizard 3; Subdomain murder 3; Elemental School metal 3; Mystery metal 3

        //CASTING

        //Casting Time 1 standard action
        //Components V, S

        //EFFECT

        //Range close(25 ft. + 5 ft./2 levels)
        //Targets one weapon or 50 projectiles, all of which must be together at the time of casting
        //Duration 10 min./level
        //Saving Throw Will negates(harmless, object); Spell Resistance yes(harmless, object)

        //DESCRIPTION

        //This spell makes a weapon magically keen, improving its ability to deal telling blows.This transmutation doubles the threat range of the weapon. A threat range of 20 becomes 19-20, a threat range of 19-20 becomes 17-20, and a threat range of 18-20 becomes 15-20. The spell can be cast only on piercing or slashing weapons.If cast on arrows or crossbow bolts, the keen edge on a particular projectile ends after one use, whether or not the missile strikes its intended target.Treat shuriken as arrows, rather than as thrown weapons, for the purpose of this spell.

        //Multiple effects that increase a weapon’s threat range (such as the keen special weapon property and the Improved Critical feat) don’t stack.You can’t cast this spell on a natural weapon, such as a claw.
    }
}

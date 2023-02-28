using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Components;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.Reference;
using UnityEngine;
using Kingmaker.Visual.Animation.Kingmaker.Actions;

namespace TomeOfTheFirebird.New_Spells
{
    public static class BoneFists
    {
        private static BlueprintAbility bonefists;
        public static void BuildSpell()
        {

            Sprite BoneFistsSprite = AssetLoader.LoadInternal(Main.TotFContext, "Spells", "BoneFists.png");
            AbilityConfigurator BoneFists = MakerTools.MakeSpell("BoneFists", "Bone Fists", "The bones of your targets’ joints grow thick and sharp, protruding painfully through the skin at the knuckles, elbows, shoulders, spine, and knees. The targets each gain a +1 bonus to natural armor and a +2 bonus on damage rolls with natural weapons.", BoneFistsSprite, Kingmaker.Blueprints.Classes.Spells.SpellSchool.Necromancy, new Kingmaker.Localization.LocalizedString(), LocalizedStrings.OneMinutePerLevelDuration);
            Main.TotFContext.Logger.Log("Bone Fists Build Started");

            BoneFists.AllowTargeting(true, false, true, true);
            BoneFists.SetRange(AbilityRange.Personal);

            BoneFists.SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Omni);
            BoneFists.SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard);
            BoneFists.SetAvailableMetamagic(Metamagic.Extend, Metamagic.Heighten, Metamagic.CompletelyNormal, Metamagic.Quicken, Metamagic.Reach);

            if (Settings.IsEnabled("BoneFists"))
            {
                BoneFists.AddToSpellLists(2, SpellList.Bloodrager, SpellList.Cleric, SpellList.Druid, SpellList.Shaman, SpellList.Hunter, SpellList.Ranger, SpellList.Witch, SpellList.Wizard);
                BoneFists.AddSpellToPsychic(2);
            }

            BoneFists.SetLocalizedSavingThrow(new Kingmaker.Localization.LocalizedString());
            BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs.BuffConfigurator BoneFistsBuff = MakerTools.MakeBuff("BoneFistsBuff", "Bone Fists", "The bones of your joints grow thick and sharp, protruding painfully through the skin at the knuckles, elbows, shoulders, spine, and knees. You gain a +1 bonus to natural armor and a +2 bonus on damage rolls with natural weapons.", BoneFistsSprite);
            BoneFistsBuff.SetFlags(BlueprintBuff.Flags.IsFromSpell);


            BoneFistsBuff.AddStatBonus(Kingmaker.Enums.ModifierDescriptor.NaturalArmor, stat: Kingmaker.EntitySystem.Stats.StatType.AC,value: 1);
            WeaponCategory[] allowed_categories = new WeaponCategory[] { WeaponCategory.Claw, WeaponCategory.Bite, WeaponCategory.Gore, WeaponCategory.OtherNaturalWeapons, WeaponCategory.UnarmedStrike, WeaponCategory.Tail };
            Main.TotFContext.Logger.Log("Building Bone Fists Natural Weapon Damage");
            ContextWeaponCategoryFlatDamageBonus bonefistsDMG = new ContextWeaponCategoryFlatDamageBonus()
            {
                categories = allowed_categories,
                Value = new Kingmaker.UnitLogic.Mechanics.ContextValue() { Value = 2 },
                descriptor = ModifierDescriptor.NaturalArmor

            };
            BoneFistsBuff.AddComponent(bonefistsDMG);

            Main.TotFContext.Logger.Log("Built Buff");
            BlueprintBuff builtBuff = BoneFistsBuff.Configure();
            ActionsBuilder actoion = ActionsBuilder.New().ApplyBuff(builtBuff.AssetGuidThreadSafe, durationValue: MakerTools.GetContextDurationValue(DurationRate.Minutes, true), isFromSpell: true);
            BoneFists.AddAbilityEffectRunAction(actoion);
            BoneFists.AddAbilityTargetsAround(radius: new Kingmaker.Utility.Feet(15f), spreadSpeed: new Kingmaker.Utility.Feet(11f), targetType: Kingmaker.UnitLogic.Abilities.Components.TargetType.Ally);
            //BoneFists.AddCraftInfoComponent(Kingmaker.Craft.CraftSpellType.Buff, Kingmaker.Craft.CraftSavingThrow.None, Kingmaker.Craft.CraftAOE.AOE);
            bonefists = BoneFists.Configure();
            




        }

    }
}

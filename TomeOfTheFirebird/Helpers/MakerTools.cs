using BlueprintCore.Blueprints.Configurators.Abilities;
using BlueprintCore.Blueprints.Configurators.Buffs;
using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.Config;
using UnityEngine;

namespace TomeOfTheFirebird.Helpers
{
    public static class MakerTools
    {
        public static FeatureConfigurator MakeFeature(string systemName, string displayName, string description, bool hide = false, Sprite icon = null)
        {
            Main.Log($"Building New Feature: {systemName}");
            var guid = ModSettings.Blueprints.GetGUID(systemName);
            LocalizedString name = LocalizationTool.CreateString(systemName + ".Name", displayName);
            LocalizedString desc = LocalizationTool.CreateString(systemName + ".Desc", description);

            var res = FeatureConfigurator.New(systemName, guid.ToString()).SetDisplayName(name).SetDescription(desc);
            if (icon != null)
            {
                res.SetIcon(icon);
            }
           
            return res;

        }
       
        

        public static EquipmentEnchantmentConfigurator MakeItemEnchantment(string systemName, string displayName, string description, int cost)
        {
            Main.Log($"Building New Enchantment: {systemName}");
            var guid = ModSettings.Blueprints.GetGUID(systemName);
            LocalizedString name = LocalizationTool.CreateString(systemName + ".Name", displayName);
            LocalizedString desc = LocalizationTool.CreateString(systemName + ".Desc", description);

            var res = EquipmentEnchantmentConfigurator.New(systemName, guid.ToString()).SetEnchantName(name).SetDescription(desc).SetEnchantmentCost(cost);
            

            return res;

        }

        public static WeaponEnchantmentConfigurator MakeWeaponEnchant(string systemName, string displayName, string description, string affixName, bool prefix, int effectivePlus)
        {
            Main.Log($"Building New Weapon Enchant: {systemName}");
            var guid = ModSettings.Blueprints.GetGUID(systemName);
            LocalizedString name = LocalizationTool.CreateString(systemName + ".Name", displayName);
            LocalizedString desc = LocalizationTool.CreateString(systemName + ".Desc", description);
            LocalizedString affix = LocalizationTool.CreateString(systemName + ".Affix", affixName);

            var enchant = WeaponEnchantmentConfigurator.New(systemName, guid.ToString()).SetEnchantName(name).SetDescription(desc).SetEnchantmentCost(effectivePlus);
            if (prefix)
            {
                enchant.SetPrefix(affix);
            }
            else
            {
                enchant.SetSuffix(affix);
            }


            return enchant;
        }

        public static AbilityConfigurator MakeSpell(string systemName, string displayName, string description, Sprite icon, SpellSchool school, LocalizedString savestring, LocalizedString durationString)
        {
            Main.Log($"Building New Spell: {systemName}");
            var guid = ModSettings.Blueprints.GetGUID(systemName);
            LocalizedString name = LocalizationTool.CreateString(systemName + ".Name", displayName);
            LocalizedString desc = LocalizationTool.CreateString(systemName + ".Desc", description);

            

            return AbilityConfigurator.New(systemName, guid.ToString()).SetDisplayName(name).SetDescription(desc).SetIcon(icon).SetSpellSchool(school).SetSavingThrowText(savestring).SetDurationText(durationString);


        }

        public static IEnumerable<AbilityConfigurator> ApplyToAll(this IEnumerable<AbilityConfigurator> targets, Func<AbilityConfigurator, AbilityConfigurator> act)
        {
            return targets.Select(x => act(x));
        }

        public static AbilityConfigurator SetTouchBuff(this AbilityConfigurator abilityConfigurator)
        {
            return abilityConfigurator.SetRange(Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Touch).AllowTargeting(false, false, true, true).SetAnimationStyle(Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Touch);
        }

        

        public static ContextDurationValue GetContextDurationValue(DurationRate duration, bool extendable)
        {
            return new ContextDurationValue() { m_IsExtendable = extendable, Rate = duration, BonusValue = new ContextValue() { ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Rank }, DiceType = Kingmaker.RuleSystem.DiceType.One, DiceCountValue = new ContextValue() };
        }

        public static BuffConfigurator MakeBuff(string systemName, string displayName, string description, Sprite icon = null)
        {
            Main.Log($"Building New Buff: {systemName}");
            var guid = ModSettings.Blueprints.GetGUID(systemName);
            LocalizedString name = LocalizationTool.CreateString(systemName + ".Name", displayName);
            LocalizedString desc = LocalizationTool.CreateString(systemName + ".Desc", description);


            var buff = BuffConfigurator.New(systemName, guid.ToString()).SetDisplayName(name).SetDescription(desc);
            if (icon != null)
            {
                buff.SetIcon(icon);

            }
            else
            {
                buff.AddToFlags(BlueprintBuff.Flags.HiddenInUi);
            }

            return buff;
        }

    }
}

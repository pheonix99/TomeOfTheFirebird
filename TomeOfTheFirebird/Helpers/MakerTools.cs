using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;

namespace TomeOfTheFirebird.Helpers
{
    public static class MakerTools
    {
        public static FeatureConfigurator MakeFeature(string systemName, string displayName, string description, bool hide = false, Sprite icon = null)
        {
            Main.TotFContext.Logger.Log($"Building New Feature: {systemName}");
            
            var guid = Main.TotFContext.Blueprints.GetGUID(systemName);
            LocalizedString name = LocalizationTool.CreateString(systemName + ".Name", displayName);
            LocalizedString desc = LocalizationTool.CreateString(systemName + ".Desc", description);
            Main.TotFContext.Logger.Log($"Guid for {systemName} is {guid.ToString()}");
            var res = FeatureConfigurator.New(systemName, guid.ToString()).SetDisplayName(name).SetDescription(desc);
            if (icon != null)
            {
                res.SetIcon(icon);
            }
            if (hide)
            {
                res.SetHideInUI(true);
                res.SetHideInCharacterSheetAndLevelUp(true);
            }
            return res;

        }

        public static FeatureSelectionConfigurator MakeFeatureSelector(string systemName, string displayName, string description, bool hide = false, Sprite icon = null)
        {
            Main.TotFContext.Logger.Log($"Building New Feature: {systemName}");

            var guid = Main.TotFContext.Blueprints.GetGUID(systemName);
            LocalizedString name = LocalizationTool.CreateString(systemName + ".Name", displayName);
            LocalizedString desc = LocalizationTool.CreateString(systemName + ".Desc", description);
            Main.TotFContext.Logger.Log($"Guid for {systemName} is {guid.ToString()}");
            var res = FeatureSelectionConfigurator.New(systemName, guid.ToString()).SetDisplayName(name).SetDescription(desc);
            if (icon != null)
            {
                res.SetIcon(icon);
            }
            if (hide)
            {
                res.SetHideInUI(true);
                res.SetHideInCharacterSheetAndLevelUp(true);
            }
            return res;

        }


        public static EquipmentEnchantmentConfigurator MakeItemEnchantment(string systemName, string displayName, string description, int cost)
        {
            Main.TotFContext.Logger.Log($"Building New Enchantment: {systemName}");
            var guid = Main.TotFContext.Blueprints.GetGUID(systemName);
            LocalizedString name = LocalizationTool.CreateString(systemName + ".Name", displayName);
            LocalizedString desc = LocalizationTool.CreateString(systemName + ".Desc", description);

            var res = EquipmentEnchantmentConfigurator.New(systemName, guid.ToString()).SetEnchantName(name).SetDescription(desc).SetEnchantmentCost(cost);
            

            return res;

        }

        public static WeaponEnchantmentConfigurator MakeWeaponEnchant(string systemName, string displayName, string description, string affixName, bool prefix, int effectivePlus, bool hidden = false)
        {
            Main.TotFContext.Logger.Log($"Building New Weapon Enchant: {systemName}");
            var guid = Main.TotFContext.Blueprints.GetGUID(systemName);
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

            enchant.SetHiddenInUI(hidden);
            return enchant;
        }

        public static AbilityConfigurator MakeAbility(string systemName, string displayName, string description, Sprite icon, LocalizedString savestring, LocalizedString durationString)
        {
            Main.TotFContext.Logger.Log($"Building New Spell: {systemName}");
            var guid = Main.TotFContext.Blueprints.GetGUID(systemName);
            LocalizedString name = null;
            LocalizedString desc = null;
            Main.TotFContext.Logger.Log("About to try localization");
            try
            {
                name = LocalizationTool.CreateString(systemName + ".Name", displayName);
                desc = LocalizationTool.CreateString(systemName + ".Desc", description);
                Main.TotFContext.Logger.Log("Localization done");
            }
            catch (Exception e)
            {
                Main.TotFContext.Logger.LogError(e.Message);
            }



            return AbilityConfigurator.New(systemName, guid.ToString()).SetDisplayName(name).SetDescription(desc).SetIcon(icon).SetLocalizedSavingThrow(savestring).SetLocalizedDuration(durationString);


        }


        public static AbilityConfigurator MakeSpell(string systemName, string displayName, string description, Sprite icon, SpellSchool school, LocalizedString savestring, LocalizedString durationString)
        {
            Main.TotFContext.Logger.Log($"Building New Spell: {systemName}");
            var guid = Main.TotFContext.Blueprints.GetGUID(systemName);
            LocalizedString name = null;
            LocalizedString desc = null;
            Main.TotFContext.Logger.Log("About to try localization");
            try
            {
                name = LocalizationTool.CreateString(systemName + ".Name", displayName);
                desc = LocalizationTool.CreateString(systemName + ".Desc", description);
                Main.TotFContext.Logger.Log("Localization done");
            }
            catch(Exception e)
            {
                Main.TotFContext.Logger.LogError(e.Message);
            }
            
           
            
            return AbilityConfigurator.New(systemName, guid.ToString()).SetDisplayName(name).SetDescription(desc).SetIcon(icon).AddSpellComponent(school).SetLocalizedSavingThrow(savestring).SetLocalizedDuration(durationString);


        }


        public static ActivatableAbilityConfigurator MakeToggle(string systemName, string displayName, string description, Sprite icon)
        {
            Main.TotFContext.Logger.Log($"Building New Toggle: {systemName}");
            var guid = Main.TotFContext.Blueprints.GetGUID(systemName);
            LocalizedString name = LocalizationTool.CreateString(systemName + ".Name", displayName);
            LocalizedString desc = LocalizationTool.CreateString(systemName + ".Desc", description);



            var made = ActivatableAbilityConfigurator.New(systemName, guid.ToString()).SetDisplayName(name).SetDescription(desc).SetIcon(icon);
            

            return made;
        }

        public static ProgressionConfigurator MakeProg(string systemName, string displayName, string description, Sprite icon = null)
        {
            Main.TotFContext.Logger.Log($"Building New Toggle: {systemName}");
            var guid = Main.TotFContext.Blueprints.GetGUID(systemName);
            LocalizedString name = LocalizationTool.CreateString(systemName + ".Name", displayName);
            LocalizedString desc = LocalizationTool.CreateString(systemName + ".Desc", description);



            return ProgressionConfigurator.New(systemName, guid.ToString()).SetDisplayName(name).SetDescription(desc).SetIcon(icon);


        }

        public static IEnumerable<AbilityConfigurator> ApplyToAll(this IEnumerable<AbilityConfigurator> targets, Func<AbilityConfigurator, AbilityConfigurator> act)
        {
            return targets.Select(x => act(x));
        }

        public static AbilityConfigurator SetTouchBuff(this AbilityConfigurator abilityConfigurator)
        {
            return abilityConfigurator.SetRange(Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Touch).AllowTargeting(false, false, true, true).SetAnimationStyle(Kingmaker.View.Animation.CastAnimationStyle.CastActionTouch);
        }

        

        public static ContextDurationValue GetContextDurationValue(DurationRate duration, bool extendable)
        {
            return new ContextDurationValue() { m_IsExtendable = extendable, Rate = duration, BonusValue = new ContextValue() { ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Rank }, DiceType = Kingmaker.RuleSystem.DiceType.One, DiceCountValue = new ContextValue() };
        }

        public static BuffConfigurator MakeBuff(string systemName, string displayName, string description, Sprite icon = null)
        {
            Main.TotFContext.Logger.Log($"Building New Buff: {systemName}");
            var guid = Main.TotFContext.Blueprints.GetGUID(systemName);
            LocalizedString name = LocalizationTool.CreateString(systemName + ".Name", displayName);
            LocalizedString desc = LocalizationTool.CreateString(systemName + ".Desc", description);


            var buff = BuffConfigurator.New(systemName, guid.ToString()).SetDisplayName(name).SetDescription(desc);
            buff.SetFxOnStart(new Kingmaker.ResourceLinks.PrefabLink());
            buff.SetFxOnRemove(new Kingmaker.ResourceLinks.PrefabLink());
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

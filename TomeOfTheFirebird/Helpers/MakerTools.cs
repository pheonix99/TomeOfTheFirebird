using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints;
using TomeOfTheFirebird.New_Components;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;

namespace TomeOfTheFirebird.Helpers
{
    public static class MakerTools
    {
        

        public static BlueprintFeature ApplySpellsPerDayChangeToFeature(Blueprint<BlueprintReference<BlueprintFeature>> blueprint, BlueprintCharacterClassReference charclass, int change = -1)
        {
            return FeatureConfigurator.For(blueprint).AddComponent<AllLevelsSpellSlotShift>(x =>
            {
                x.Amount = change;
                x.ClassReference = charclass;

            }).Configure();
        }

        public static BlueprintFeature MakeSpellsPerDayChangeFeature(BlueprintArchetypeReference archetype, string sourceArchetypeDisplayName, string sourceClassDisplayName, string description, string sysName = "", int change = -1, Sprite icon = null)
        {
            BlueprintCharacterClass classObj = archetype.Get().GetParentClass();

            if (String.IsNullOrEmpty(sysName))
            {
                sysName = classObj.Name.Replace("Class", "") + archetype.NameSafe().Replace("Archetype", "") + "ReducedSpellcastingFeature";
            }

            BlueprintFeature bp = TabletopTweaks.Core.Utilities.Helpers.CreateDerivedBlueprint<BlueprintFeature>(Main.TotFContext, sysName, Main.TotFContext.Blueprints.GetDerivedMaster("DiminishedSpellcastingMaster"), new SimpleBlueprint[] { archetype.Get() });


            FeatureConfigurator feature = FeatureGuts(FeatureConfigurator.For(bp),  false, icon);
            feature = MakeLocals(feature, sysName, $"{sourceArchetypeDisplayName} Diminished Spellcasting: {sourceClassDisplayName}", description);
            feature.SetIsClassFeature(true);
            feature.AddComponent<AllLevelsSpellSlotShift>(x =>
            {
                x.Amount = change;
                x.ClassReference = classObj.ToReference<BlueprintCharacterClassReference>();
            });
            BlueprintFeature made = feature.Configure();

            //BuildContent.CastReducers.Add(made.ToReference<BlueprintFeatureReference>());

            return made;

        }

        public static FeatureConfigurator MakeFeatureWithPredefinedGuid(BlueprintGuid guid, string systemName, string displayName, string description, bool hide = false, Sprite icon = null)
        {
            Main.TotFContext.Logger.Log($"Building New Feature: {systemName}");

          
            Main.TotFContext.Logger.Log($"Guid for {systemName} is {guid.ToString()}");
            FeatureConfigurator res = FeatureConfigurator.New(systemName, guid.ToString());

            res = MakeLocals(res, systemName, displayName, description);
            return FeatureGuts(res, hide, icon);
        }

        private static FeatureConfigurator MakeLocals(FeatureConfigurator featureConfigurator, string systemName, string displayName, string description)
        {
            LocalizedString name = LocalizationTool.CreateString(systemName + ".Name", displayName);
            LocalizedString desc = LocalizationTool.CreateString(systemName + ".Desc", description);


           return featureConfigurator.SetDisplayName(name).SetDescription(desc);
        }

        private static FeatureConfigurator FeatureGuts(FeatureConfigurator featureConfigurator, bool hide = false, Sprite icon = null)
        {
            
            if (icon != null)
            {
                featureConfigurator.SetIcon(icon);
            }
            if (hide)
            {
                featureConfigurator.SetHideInUI(true);
                featureConfigurator.SetHideInCharacterSheetAndLevelUp(true);
            }
            return featureConfigurator;
        }

        public static FeatureConfigurator MakeFeature(string systemName, LocalizedString displayName, LocalizedString description, bool hide = false, Sprite icon = null)
        {
            Main.TotFContext.Logger.Log($"Building New Feature: {systemName}");

            Kingmaker.Blueprints.BlueprintGuid guid = Main.TotFContext.Blueprints.GetGUID(systemName);
            Main.TotFContext.Logger.Log($"Guid for {systemName} is {guid.ToString()}");
            FeatureConfigurator res = FeatureConfigurator.New(systemName, guid.ToString());
        
            return FeatureGuts(res, hide, icon);
        }

        public static FeatureConfigurator MakeFeature(string systemName, string displayName, string description, bool hide = false, Sprite icon = null, params FeatureGroup[] groups)
        {
            Main.TotFContext.Logger.Log($"Building New Feature: {systemName}");

            Kingmaker.Blueprints.BlueprintGuid guid = Main.TotFContext.Blueprints.GetGUID(systemName);
            Main.TotFContext.Logger.Log($"Guid for {systemName} is {guid.ToString()}");
            FeatureConfigurator res = FeatureConfigurator.New(systemName, guid.ToString(), groups);
           
            res = MakeLocals(res, systemName, displayName, description);
            return FeatureGuts(res,  hide, icon);
        }

       
        public static FeatureSelectionConfigurator MakeFeatureSelector(string systemName, string displayName, string description, bool hide = false, Sprite icon = null, params FeatureGroup[] groups)
        {
            Main.TotFContext.Logger.Log($"Building New Feature: {systemName}");

            Kingmaker.Blueprints.BlueprintGuid guid = Main.TotFContext.Blueprints.GetGUID(systemName);
            LocalizedString name = LocalizationTool.CreateString(systemName + ".Name", displayName);
            LocalizedString desc = LocalizationTool.CreateString(systemName + ".Desc", description);
            Main.TotFContext.Logger.Log($"Guid for {systemName} is {guid.ToString()}");
            FeatureSelectionConfigurator res = FeatureSelectionConfigurator.New(systemName, guid.ToString()).SetDisplayName(name).SetDescription(desc);
            res.AddToGroups(groups);
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
            Kingmaker.Blueprints.BlueprintGuid guid = Main.TotFContext.Blueprints.GetGUID(systemName);
            LocalizedString name = LocalizationTool.CreateString(systemName + ".Name", displayName);
            LocalizedString desc = LocalizationTool.CreateString(systemName + ".Desc", description);

            EquipmentEnchantmentConfigurator res = EquipmentEnchantmentConfigurator.New(systemName, guid.ToString()).SetEnchantName(name).SetDescription(desc).SetEnchantmentCost(cost);
            

            return res;

        }

        public static WeaponEnchantmentConfigurator MakeWeaponEnchant(string systemName, string displayName, string description, string affixName, bool prefix, int effectivePlus, bool hidden = false)
        {
            Main.TotFContext.Logger.Log($"Building New Weapon Enchant: {systemName}");
            Kingmaker.Blueprints.BlueprintGuid guid = Main.TotFContext.Blueprints.GetGUID(systemName);
            LocalizedString name = LocalizationTool.CreateString(systemName + ".Name", displayName);
            LocalizedString desc = LocalizationTool.CreateString(systemName + ".Desc", description);
            LocalizedString affix = LocalizationTool.CreateString(systemName + ".Affix", affixName);

            WeaponEnchantmentConfigurator enchant = WeaponEnchantmentConfigurator.New(systemName, guid.ToString()).SetEnchantName(name).SetDescription(desc).SetEnchantmentCost(effectivePlus);
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
            Kingmaker.Blueprints.BlueprintGuid guid = Main.TotFContext.Blueprints.GetGUID(systemName);
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


        public static AbilityConfigurator MakeSpell(string systemName, string displayName, string description, Sprite icon, SpellSchool school, LocalizedString savestring, LocalizedString durationString = null)
        {
            Main.TotFContext.Logger.Log($"Building New Spell: {systemName}");
            Kingmaker.Blueprints.BlueprintGuid guid = Main.TotFContext.Blueprints.GetGUID(systemName);
            
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



            var config = AbilityConfigurator.New(systemName, guid.ToString()).SetDisplayName(name).SetDescription(desc).SetIcon(icon).AddSpellComponent(school).SetLocalizedSavingThrow(savestring);
            if (durationString != null)
                config.SetLocalizedDuration(durationString);

            return config;


        }


        public static ActivatableAbilityConfigurator MakeToggle(string systemName, string displayName, string description, Sprite icon)
        {
            Main.TotFContext.Logger.Log($"Building New Toggle: {systemName}");
            Kingmaker.Blueprints.BlueprintGuid guid = Main.TotFContext.Blueprints.GetGUID(systemName);
            LocalizedString name = LocalizationTool.CreateString(systemName + ".Name", displayName);
            LocalizedString desc = LocalizationTool.CreateString(systemName + ".Desc", description);



            ActivatableAbilityConfigurator made = ActivatableAbilityConfigurator.New(systemName, guid.ToString()).SetDisplayName(name).SetDescription(desc).SetIcon(icon);
            

            return made;
        }

        public static ProgressionConfigurator MakeProg(string systemName, string displayName, string description, Sprite icon = null)
        {
            Main.TotFContext.Logger.Log($"Building New Toggle: {systemName}");
            Kingmaker.Blueprints.BlueprintGuid guid = Main.TotFContext.Blueprints.GetGUID(systemName);
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
            return abilityConfigurator.SetRange(Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Touch).AllowTargeting(false, false, true, true).SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Touch);
        }

        

        public static ContextDurationValue GetContextDurationValue(DurationRate duration, bool extendable)
        {
            return new ContextDurationValue() { m_IsExtendable = extendable, Rate = duration, BonusValue = new ContextValue() { ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Rank }, DiceType = Kingmaker.RuleSystem.DiceType.One, DiceCountValue = new ContextValue() };
        }

        public static BuffConfigurator MakeBuff(string systemName, LocalizedString displayName, LocalizedString description, Sprite icon = null)
        {
            Main.TotFContext.Logger.Log($"Building New Buff: {systemName}");
            Kingmaker.Blueprints.BlueprintGuid guid = Main.TotFContext.Blueprints.GetGUID(systemName);
            


            BuffConfigurator buff = BuffConfigurator.New(systemName, guid.ToString()).SetDisplayName(displayName).SetDescription(description);
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

        public static BuffConfigurator MakeBuff(string systemName, string displayName, string description, Sprite icon = null)
        {
            Main.TotFContext.Logger.Log($"Building New Buff: {systemName}");
            Kingmaker.Blueprints.BlueprintGuid guid = Main.TotFContext.Blueprints.GetGUID(systemName);
            LocalizedString name = LocalizationTool.CreateString(systemName + ".Name", displayName);
            LocalizedString desc = LocalizationTool.CreateString(systemName + ".Desc", description);


            BuffConfigurator buff = BuffConfigurator.New(systemName, guid.ToString()).SetDisplayName(name).SetDescription(desc);
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

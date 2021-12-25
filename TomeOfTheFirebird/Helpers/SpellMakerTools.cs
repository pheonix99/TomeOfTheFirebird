using BlueprintCore.Blueprints.Configurators.Abilities;
using BlueprintCore.Blueprints.Configurators.Buffs;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Localization;
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
    public static class SpellMakerTools
    {
        public static AbilityConfigurator MakeSpell(string systemName, string displayName, string description, Sprite icon, SpellSchool school)
        {
            Main.Log($"Building New Spell: {systemName}");
            var guid = ModSettings.Blueprints.GetGUID(systemName);
            LocalizedString name = LocalizationTool.CreateString(systemName + ".Name", displayName);
            LocalizedString desc = LocalizationTool.CreateString(systemName + ".Desc", description);


            return AbilityConfigurator.New(systemName, guid.ToString()).SetDisplayName(name).SetDescription(desc).SetIcon(icon).SetSpellSchool(school);


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

        public static BuffConfigurator MakeBuff(string systemName, string displayName, string description, Sprite icon)
        {
            Main.Log($"Building New Buff: {systemName}");
            var guid = ModSettings.Blueprints.GetGUID(systemName);
            LocalizedString name = LocalizationTool.CreateString(systemName + ".Name", displayName);
            LocalizedString desc = LocalizationTool.CreateString(systemName + ".Desc", description);


            return BuffConfigurator.New(systemName, guid.ToString()).SetDisplayName(name).SetDescription(desc).SetIcon(icon);
        }

    }
}

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Components
{
  /// <summary>Helper class for creating <see cref="ContextRankConfig"/> objects.</summary>
  /// 
  /// <remarks>
  /// <para>
  /// Functions are split into two classes:
  /// </para>
  /// 
  /// <list type="bullet">
  /// <item>
  ///   <term>ContextRankConfigs</term>
  ///   <description>
  ///   Base class which creates a config with a specific base value type. A context rank config can only have one type
  ///   so you should only call one of these functions for a config.
  ///   </description>
  /// </item>
  /// <item>
  ///   <term><see cref="ProgressionExtensions"/></term>
  ///   <description>
  ///   Extension class which applies progressions. Like the base value, you can only have a single progression type so
  ///   you should only call one of these functions for a config.
  ///   </description>
  /// </item>
  /// </list>
  /// 
  /// <para>
  /// See <see href="https://github.com/TylerGoeringer/OwlcatModdingWiki/wiki/ContextRankConfig">ContextRankConfig</see>
  /// on the wiki for more details about the component and
  /// <see href="https://docs.google.com/spreadsheets/d/11nQdJ7DFzS73gwR9xk3gsKbyGgtDM51yNoMv7nNYnPw/edit?usp=sharing">ContextRankConfig Calculator</see>
  /// for help determining which progression to use.
  /// </para>
  /// 
  /// <example>
  /// Create a rank based on <see cref="StatType.Strength"/> modifier with a bonus value of 2 and a max value of 30:
  /// <code>
  ///   var rankConfig = ContextRankConfigs.StatBonus(StatType.Strength, max: 30).WithBonusValueProgression(2);
  /// </code>
  /// </example>
  /// </remarks>
  public static class ContextRankConfigs
  {
    private static ContextRankConfig NewConfig(
        ContextRankBaseValueType valueType,
        AbilityRankType type,
        int? max,
        int? min,
        string? feature = null,
        string[]? featureList = null,
        StatType stat = StatType.Unknown,
        ModifierDescriptor modDescriptor = ModifierDescriptor.None,
        string? buff = null,
        bool excludeClasses = false,
        string[]? archetypes = null,
        string[]? classes = null,
        string? property = null,
        string[]? propertyList = null)
    {
      var config =
          new ContextRankConfig
          {
            m_Type = type,
            m_BaseValueType = valueType,
            m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature),
            m_FeatureList =
                featureList?
                    .Select(feature => BlueprintTool.GetRef<BlueprintFeatureReference>(feature))
                    .ToArray(),
            m_Stat = stat,
            m_SpecificModifier = modDescriptor,
            m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff),
            m_ExceptClasses = excludeClasses,
            m_AdditionalArchetypes =
                archetypes?
                    .Select(archetype => BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype))
                    .ToArray(),
            m_Class =
                classes?
                    .Select(clazz => BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz))
                    .ToArray(),
            m_CustomProperty = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(property),
            m_CustomPropertyList =
                propertyList?
                    .Select(property => BlueprintTool.GetRef<BlueprintUnitPropertyReference>(property))
                    .ToArray(),
            m_Progression = ContextRankProgression.AsIs
          };
      if (max is not null)
      {
        config.m_UseMax = true;
        config.m_Max = max.Value;
      }
      if (min is not null)
      {
        config.m_UseMin = true;
        config.m_Min = min.Value;
      }
      return config;
    }

    /// <summary>Implements <see cref="ContextRankBaseValueType.BaseAttack"/></summary>
    /// 
    /// <param name="type">Type of config. Links the config to ContextValues with the same AbilityRankType.</param>
    /// <param name="max">Sets the max resulting value.</param>
    /// <param name="min">Sets the minimum resulting value.</param>
    public static ContextRankConfig BaseAttack(
        AbilityRankType type = AbilityRankType.Default, int? max = null, int? min = null)
    {
      return NewConfig(ContextRankBaseValueType.BaseAttack, type, max, min);
    }

    /// <summary>Implements <see cref="ContextRankBaseValueType.BaseStat"/></summary>
    /// <inheritdoc cref="BaseAttack(AbilityRankType, int?, int?)"/>
    public static ContextRankConfig BaseStat(
        StatType stat, AbilityRankType type = AbilityRankType.Default, int? max = null, int? min = null)
    {
      return NewConfig(ContextRankBaseValueType.BaseStat, type, max, min, stat: stat);
    }

    /// <summary>Implements <see cref="ContextRankBaseValueType.StatBonus"/></summary>
    /// <inheritdoc cref="BaseAttack(AbilityRankType, int?, int?)"/>
    public static ContextRankConfig StatBonus(
        StatType stat,
        ModifierDescriptor modDescriptor = ModifierDescriptor.None,
        AbilityRankType type = AbilityRankType.Default,
        int? max = null,
        int? min = null)
    {
      return NewConfig(ContextRankBaseValueType.StatBonus, type, max, min, stat: stat, modDescriptor: modDescriptor);
    }

    /// <summary>Implements <see cref="ContextRankBaseValueType.CasterLevel"/> and <see cref="ContextRankBaseValueType.MaxCasterLevel"/></summary>
    /// <inheritdoc cref="BaseAttack(AbilityRankType, int?, int?)"/>
    public static ContextRankConfig CasterLevel(
        bool useMax = false, AbilityRankType type = AbilityRankType.Default, int? max = null, int? min = null)
    {
      return NewConfig(
          useMax ? ContextRankBaseValueType.MaxCasterLevel : ContextRankBaseValueType.CasterLevel, type, max, min);
    }

    /// <summary>
    /// Implements <see cref="ContextRankBaseValueType.CharacterLevel"/>
    /// </summary>
    /// <inheritdoc cref="BaseAttack(AbilityRankType, int?, int?)"/>
    public static ContextRankConfig CharacterLevel(
        AbilityRankType type = AbilityRankType.Default, int? max = null, int? min = null)
    {
      return NewConfig(ContextRankBaseValueType.CharacterLevel, type, max, min);
    }

    /// <summary>
    /// Implements <see cref="ContextRankBaseValueType.CasterCR"/>
    /// </summary>
    /// <inheritdoc cref="BaseAttack(AbilityRankType, int?, int?)"/>
    public static ContextRankConfig CasterCR(
        AbilityRankType type = AbilityRankType.Default, int? max = null, int? min = null)
    {
      return NewConfig(ContextRankBaseValueType.CasterCR, type, max, min);
    }

    /// <summary>
    /// Implements <see cref="ContextRankBaseValueType.DungeonStage"/>
    /// </summary>
    /// <inheritdoc cref="BaseAttack(AbilityRankType, int?, int?)"/>
    public static ContextRankConfig DungeonStage(
        AbilityRankType type = AbilityRankType.Default, int? max = null, int? min = null)
    {
      return NewConfig(ContextRankBaseValueType.DungeonStage, type, max, min);
    }

    /// <summary>
    /// Implements <see cref="ContextRankBaseValueType.CustomProperty"/>
    /// </summary>
    /// 
    /// <param name="property"><see cref="Kingmaker.UnitLogic.Mechanics.Properties.BlueprintUnitProperty"/></param>
    /// <inheritdoc cref="BaseAttack(AbilityRankType, int?, int?)"/>
    public static ContextRankConfig CustomProperty(
        string property, AbilityRankType type = AbilityRankType.Default, int? max = null, int? min = null)
    {
      return NewConfig(ContextRankBaseValueType.CustomProperty, type, max, min, property: property);
    }

    /// <summary>
    /// Implements <see cref="ContextRankBaseValueType.MaxCustomProperty"/>
    /// </summary>
    /// 
    /// <param name="properties"><see cref="Kingmaker.UnitLogic.Mechanics.Properties.BlueprintUnitProperty"/></param>
    /// <inheritdoc cref="BaseAttack(AbilityRankType, int?, int?)"/>
    public static ContextRankConfig MaxCustomProperty(
        string[] properties,
        AbilityRankType type = AbilityRankType.Default,
        int? max = null,
        int? min = null)
    {
      return NewConfig(ContextRankBaseValueType.MaxCustomProperty, type, max, min, propertyList: properties);
    }

    /// <summary>
    /// Implements <see cref="ContextRankBaseValueType.ClassLevel"/>
    /// </summary>
    /// 
    /// <param name="classes"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <inheritdoc cref="BaseAttack(AbilityRankType, int?, int?)"/>
    public static ContextRankConfig ClassLevel(
        string[] classes,
        bool excludeClasses = false,
        AbilityRankType type = AbilityRankType.Default,
        int? max = null,
        int? min = null)
    {
      return NewConfig(
          ContextRankBaseValueType.ClassLevel, type, max, min, classes: classes, excludeClasses: excludeClasses);
    }

    /// <summary>
    /// Implements <see cref="ContextRankBaseValueType.MaxClassLevelWithArchetype"/>
    /// </summary>
    /// 
    /// <param name="classes"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="archetypes"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype"/></param>
    /// <inheritdoc cref="BaseAttack(AbilityRankType, int?, int?)"/>
    public static ContextRankConfig MaxClassLevelWithArchetype(
        string[] classes,
        string[] archetypes,
        bool excludeClasses = false,
        AbilityRankType type = AbilityRankType.Default,
        int? max = null,
        int? min = null)
    {
      return NewConfig(
          ContextRankBaseValueType.MaxClassLevelWithArchetype,
          type,
          max,
          min,
          classes: classes,
          archetypes: archetypes,
          excludeClasses: excludeClasses);
    }

    /// <summary>
    /// Implements <see cref="ContextRankBaseValueType.OwnerSummClassLevelWithArchetype"/> and
    /// <see cref="ContextRankBaseValueType.SummClassLevelWithArchetype"/>
    /// </summary>
    /// 
    /// <param name="classes"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="archetypes"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype"/></param>
    /// <inheritdoc cref="BaseAttack(AbilityRankType, int?, int?)"/>
    public static ContextRankConfig SumClassLevelWithArchetype(
        string[] classes,
        string[] archetypes,
        bool excludeClasses = false,
        bool useOwner = false,
        AbilityRankType type = AbilityRankType.Default,
        int? max = null,
        int? min = null)
    {
      return NewConfig(
          useOwner
              ? ContextRankBaseValueType.OwnerSummClassLevelWithArchetype
              : ContextRankBaseValueType.SummClassLevelWithArchetype,
          type,
          max,
          min,
          classes: classes,
          archetypes: archetypes,
          excludeClasses: excludeClasses);
    }

    /// <summary>
    /// Implements <see cref="ContextRankBaseValueType.Bombs"/>
    /// </summary>
    /// 
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    /// <param name="classes"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="archetypes"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype"/></param>
    /// <inheritdoc cref="BaseAttack(AbilityRankType, int?, int?)"/>
    public static ContextRankConfig Bombs(
        string feature,
        string[] classes,
        string[] archetypes,
        bool excludeClasses = false,
        AbilityRankType type = AbilityRankType.Default,
        int? max = null,
        int? min = null)
    {
      return NewConfig(
          ContextRankBaseValueType.Bombs,
          type,
          max,
          min,
          feature: feature,
          classes: classes,
          archetypes: archetypes,
          excludeClasses: excludeClasses);
    }

    /// <summary>
    /// Implements <see cref="ContextRankBaseValueType.FeatureRank"/> and
    /// <see cref="ContextRankBaseValueType.MasterFeatureRank"/>
    /// </summary>
    /// 
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    /// <inheritdoc cref="BaseAttack(AbilityRankType, int?, int?)"/>
    public static ContextRankConfig FeatureRank(
        string feature,
        bool useMaster = false,
        AbilityRankType type = AbilityRankType.Default,
        int? max = null,
        int? min = null)
    {
      return NewConfig(
          useMaster ? ContextRankBaseValueType.MasterFeatureRank : ContextRankBaseValueType.FeatureRank,
          type,
          max,
          min,
          feature: feature);
    }

    /// <summary>
    /// Implements <see cref="ContextRankBaseValueType.FeatureList"/> and
    /// <see cref="ContextRankBaseValueType.FeatureListRanks"/>
    /// </summary>
    /// 
    /// <param name="features"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    /// <inheritdoc cref="BaseAttack(AbilityRankType, int?, int?)"/>
    public static ContextRankConfig FeatureList(
        string[] features,
        bool useRanks = false,
        AbilityRankType type = AbilityRankType.Default,
        int? max = null,
        int? min = null)
    {
      return NewConfig(
          useRanks ? ContextRankBaseValueType.FeatureListRanks : ContextRankBaseValueType.FeatureList,
          type,
          max,
          min,
          featureList: features);
    }

    /// <summary>
    /// Implements <see cref="ContextRankBaseValueType.MythicLevel"/> and
    /// <see cref="ContextRankBaseValueType.MasterMythicLevel"/>
    /// </summary>
    /// <inheritdoc cref="BaseAttack(AbilityRankType, int?, int?)"/>
    public static ContextRankConfig MythicLevel(
        bool useMaster = false, AbilityRankType type = AbilityRankType.Default, int? max = null, int? min = null)
    {
      return NewConfig(
          useMaster ? ContextRankBaseValueType.MasterMythicLevel : ContextRankBaseValueType.MythicLevel,
          type,
          max,
          min);
    }

    /// <summary>
    /// Implements <see cref="ContextRankBaseValueType.MythicLevelPlusBuffRank"/>
    /// </summary>
    /// 
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <inheritdoc cref="BaseAttack(AbilityRankType, int?, int?)"/>
    public static ContextRankConfig MythicLevelPlusBuffRank(
        string buff, AbilityRankType type = AbilityRankType.Default, int? max = null, int? min = null)
    {
      return NewConfig(
          ContextRankBaseValueType.MythicLevelPlusBuffRank,
          type,
          max,
          min,
          buff: buff);
    }

    /// <summary>
    /// Implements <see cref="ContextRankBaseValueType.CasterBuffRank"/> and
    /// <see cref="ContextRankBaseValueType.TargetBuffRank"/>
    /// </summary>
    /// 
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <inheritdoc cref="BaseAttack(AbilityRankType, int?, int?)"/>
    public static ContextRankConfig BuffRank(
        string buff,
        bool useTarget = false,
        AbilityRankType type = AbilityRankType.Default,
        int? max = null,
        int? min = null)
    {
      return NewConfig(
          useTarget ? ContextRankBaseValueType.TargetBuffRank : ContextRankBaseValueType.CasterBuffRank,
          type,
          max,
          min,
          buff: buff);
    }
  }

  /// <summary>
  /// Progression extensions for <see cref="ContextRankConfig"/>.
  /// </summary>
  /// 
  /// <remarks>
  /// <para>Only one progression can be applied to a config; only call one of these functions for a config.</para>
  /// 
  /// <para>
  /// If the config should return the base value, no progression is needed.
  /// </para>
  /// 
  /// <para>
  /// Integer division is truncated: <c>3 / 2 = 1</c> (rounds down) and <c>-3 / 2 = -1</c> (rounds up).
  /// </para>
  /// 
  /// <para>
  /// Config progressions are deceptively named; the functions attempt to name them correctly. For easy mapping to the
  /// enum each function comment explains the progression formula and which enums are used. See also the
  /// <see href="https://docs.google.com/spreadsheets/d/11nQdJ7DFzS73gwR9xk3gsKbyGgtDM51yNoMv7nNYnPw/edit?usp=sharing">ContextRankConfig Calculator</see>.
  /// </para>
  /// </remarks>
  public static class ProgressionExtensions
  {
    /// <summary><c>Result = BaseValue / 2 + Bonus</c></summary>
    /// 
    /// <remarks>
    /// Implements <see cref="ContextRankProgression.Div2"/> and <see cref="ContextRankProgression.Div2PlusStep"/>
    /// </remarks>
    public static ContextRankConfig WithDiv2Progression(this ContextRankConfig config, int bonus = 0)
    {
      if (bonus > 0)
      {
        config.m_Progression = ContextRankProgression.Div2PlusStep;
        config.m_StepLevel = bonus;
      }
      else { config.m_Progression = ContextRankProgression.Div2; }
      return config;
    }

    /// <summary><c>Result = 1 + (BaseValue - 1) / 2</c></summary>
    /// 
    /// <remarks>
    /// Implements <see cref="ContextRankProgression.OnePlusDiv2"/>
    /// </remarks>
    public static ContextRankConfig WithOnePlusDiv2Progression(this ContextRankConfig config)
    {
      config.m_Progression = ContextRankProgression.OnePlusDiv2;
      return config;
    }

    /// <summary><c>Result = BaseValue / Divisor</c></summary>
    /// 
    /// <remarks>
    /// Implements <see cref="ContextRankProgression.DivStep"/>
    /// </remarks>
    public static ContextRankConfig WithDivStepProgression(this ContextRankConfig config, int divisor)
    {
      config.m_Progression = ContextRankProgression.DivStep;
      config.m_StepLevel = divisor;
      return config;
    }

    /// <summary>
    /// <c>Result = 1 + Max((BaseValue - Start) / Divisor, 0)</c><br/>
    /// OR<br/>
    /// <c>Result = 0</c>, if <c>delayStart</c> is <c>true</c> and <c>BaseValue &lt; Start</c>
    /// </summary>
    /// 
    /// <remarks>
    /// Implements <see cref="ContextRankProgression.StartPlusDivStep"/>,
    /// <see cref="ContextRankProgression.DelayedStartPlusDivStep"/>, and <see cref="ContextRankProgression.OnePlusDivStep"/>
    /// </remarks>
    public static ContextRankConfig WithStartPlusDivStepProgression(
        this ContextRankConfig config, int divisor, int start = 0, bool delayStart = false)
    {
      config.m_Progression =
          delayStart ? ContextRankProgression.DelayedStartPlusDivStep : ContextRankProgression.StartPlusDivStep;
      config.m_StepLevel = divisor;
      config.m_StartLevel = start;
      return config;
    }

    /// <summary>
    /// <c>Result = 1 + 2 * Max((BaseValue - Start) / Divisor, 0)</c>
    /// </summary>
    /// 
    /// <remarks>
    /// Implements <see cref="ContextRankProgression.StartPlusDoubleDivStep"/>
    /// </remarks>
    public static ContextRankConfig WithStartPlusDoubleDivStepProgression(
        this ContextRankConfig config, int divisor, int start = 0)
    {
      config.m_Progression = ContextRankProgression.StartPlusDoubleDivStep;
      config.m_StepLevel = divisor;
      config.m_StartLevel = start;
      return config;
    }

    /// <summary>
    /// <c>Result = BaseValue * Multiplier</c>
    /// </summary>
    /// 
    /// <remarks>
    /// Implements <see cref="ContextRankProgression.MultiplyByModifier"/>
    /// </remarks>
    public static ContextRankConfig WithMultiplyByModifierProgression(this ContextRankConfig config, int multiplier)
    {
      config.m_Progression = ContextRankProgression.MultiplyByModifier;
      config.m_StepLevel = multiplier;
      return config;
    }

    /// <summary>
    /// <c>Result = BaseValue + Bonus</c><br/>
    /// OR<br/>
    /// <c>OR = 2*BaseValue + Bonus</c>, if <c>doubleBaseValue</c> is <c>true</c>
    /// </summary>
    /// 
    /// <remarks>
    /// Implements <see cref="ContextRankProgression.BonusValue"/> and <see cref="ContextRankProgression.DoublePlusBonusValue"/>
    /// </remarks>
    public static ContextRankConfig WithBonusValueProgression(
        this ContextRankConfig config, int bonus, bool doubleBaseValue = false)
    {
      config.m_Progression =
          doubleBaseValue
              ? ContextRankProgression.DoublePlusBonusValue
              : ContextRankProgression.BonusValue;
      config.m_StepLevel = bonus;
      return config;
    }

    /// <summary>
    /// <c>Result = BaseValue + BaseValue / 2</c>
    /// </summary>
    /// 
    /// <remarks>
    /// Implements <see cref="ContextRankProgression.HalfMore"/>
    /// </remarks>
    public static ContextRankConfig WithHalfMoreProgression(this ContextRankConfig config)
    {
      config.m_Progression = ContextRankProgression.HalfMore;
      return config;
    }

    /// <summary>Implements <see cref="ContextRankProgression.Custom"/></summary>
    /// 
    /// <remarks>
    /// <para>
    /// Entries must be provided in ascending order by their Base.
    /// </para>
    /// 
    /// <para>
    /// The result is the <see cref="ContextRankConfig.CustomProgressionItem.ProgressionValue">ProgressionValue</see> of
    /// the first entry where the config's BaseValue is less than or equal to the entry's
    /// <see cref="ContextRankConfig.CustomProgressionItem.BaseValue">BaseValue</see>. If the config's BaseValue is
    /// greater than all entry <see cref="ContextRankConfig.CustomProgressionItem.BaseValue">BaseValues</see>, the last
    /// entry's <see cref="ContextRankConfig.CustomProgressionItem.ProgressionValue">ProgressionValue</see> is returned.
    /// </para>
    /// 
    /// <example>
    /// <code>
    ///   ContextRankConfigs.CharacterLevel().CustomProgression((5, 1), (10, 2), (13, 4), (18, 6));
    /// </code>
    /// <list type="bullet">
    /// <item>
    ///   <term>Levels 1-5</term>
    ///   <description><c>Result = 1</c></description>
    /// </item>
    /// <item>
    ///   <term>Levels 6-10</term>
    ///   <description><c>Result = 2</c></description>
    /// </item>
    /// <item>
    ///   <term>Levels 11-13</term>
    ///   <description><c>Result = 4</c></description>
    /// </item>
    /// <item>
    ///   <term>Levels 14+</term>
    ///   <description><c>Result = 6</c></description>
    /// </item>
    /// </list>
    /// </example>
    /// </remarks>
    public static ContextRankConfig WithCustomProgression(
        this ContextRankConfig config, params (int Base, int Progression)[] progression)
    {
      config.m_Progression = ContextRankProgression.Custom;
      config.m_CustomProgression =
          progression.ToList()
              .Select(
                  entry =>
                    new ContextRankConfig.CustomProgressionItem
                    {
                      BaseValue = entry.Base,
                      ProgressionValue = entry.Progression
                    })
              .ToArray();
      return config;
    }

    /// <summary>
    /// Creates a linear custom progression: <c>ProgressionValue = a * BaseValue + b</c>.
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    /// When <c>BaseValue</c> is less than <paramref name="startingBaseValue"/> the result is
    /// <paramref name="progressionValueBeforeStart"/>.
    /// </para>
    /// 
    /// <para>
    /// When <c>BaseValue</c> is greater than or equal to
    /// <paramref name="startingBaseValue"/> the result is <c>a * BaseValue + b</c>.
    /// </para>
    /// 
    /// <para>
    /// When <c>BaseValue</c> exceeds <paramref name="maxBaseValue"/> the result is <c>a * MaxBaseValue + b</c>.
    /// </para>
    /// 
    /// <para>
    /// If specified, <paramref name="maxProgressionValue"/> sets the maximum result.
    /// </para>
    /// 
    /// <para>
    /// If specified, <paramref name="minProgressionValue"/> sets the minimum result.
    /// </para>
    /// 
    /// <para>Results are truncated so 3.6 becomes 3.</para>
    /// 
    /// <example>
    /// The following config returns 0 until <c>CharacterLevel</c> is 4, then <c>1 + 3/4 * CharacterLevel</c>
    /// <code>
    ///   ContextRankConfigs.CharacterLevel().LinearProgression(0.75f, 1, startingBaseValue = 4);
    /// </code>
    /// </example>
    /// </remarks>
    public static ContextRankConfig WithLinearProgression(
        this ContextRankConfig config,
        float a,
        float b,
        int startingBaseValue = 1,
        int maxBaseValue = 40,
        int progressionValueBeforeStart = 0,
        int? minProgressionValue = null,
        int? maxProgressionValue = null)
    {
      List<(int Base, int Progression)> progression = new();
      int? lastProgressionValue = null;
      // Building in reverse simplifies creating a sparsely populated progression.
      for (int baseValue = maxBaseValue; baseValue >= startingBaseValue; baseValue--)
      {
        int progressionValue =
            Math.Min(
                Math.Max(
                    (int)(a * baseValue + b),
                    minProgressionValue is null ? int.MinValue : minProgressionValue.Value),
                maxProgressionValue is null ? int.MaxValue : maxProgressionValue.Value);
        // Only add an entry if the progression value changes.
        if (progressionValue != lastProgressionValue)
        {
          progression.Add((Base: baseValue, Progression: progressionValue));
          lastProgressionValue = progressionValue;
        }
      }
      progression.Add((Base: startingBaseValue - 1, Progression: progressionValueBeforeStart));

      progression.Reverse();
      return config.WithCustomProgression(progression.ToArray());
    }
  }

  /// <summary>
  /// Wrapper providing a constructor for <see cref="ContextRankConfig.CustomProgressionItem"/>
  /// </summary>
  [Obsolete("Use CustomProgression with anonymous tuples.")]
  public class ProgressionEntry : ContextRankConfig.CustomProgressionItem
  {
    public ProgressionEntry(int baseValue, int progressionValue) : base()
    {
      BaseValue = baseValue;
      ProgressionValue = progressionValue;
    }
  }
}
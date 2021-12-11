using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.AreaEffects;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Abilities
{
  /// <summary>Configurator for <see cref="BlueprintAbilityAreaEffect"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAbilityAreaEffect))]
  public class AbilityAreaEffectConfigurator
      : BaseBlueprintConfigurator<BlueprintAbilityAreaEffect, AbilityAreaEffectConfigurator>
  {
    private AbilityAreaEffectConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AbilityAreaEffectConfigurator For(string name) { return new AbilityAreaEffectConfigurator(name); }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AbilityAreaEffectConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintAbilityAreaEffect>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityAreaEffect.m_TargetType"/>
    /// </summary>
    public AbilityAreaEffectConfigurator SetTargetType(BlueprintAbilityAreaEffect.TargetType type)
    {
      return OnConfigureInternal(blueprint => blueprint.m_TargetType = type);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityAreaEffect.SpellResistance"/>
    /// </summary>
    public AbilityAreaEffectConfigurator ApplySpellResistance(bool applySR = true)
    {
      return OnConfigureInternal(blueprint => blueprint.SpellResistance = applySR);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityAreaEffect.AffectEnemies"/>
    /// </summary>
    public AbilityAreaEffectConfigurator SetAffectEnemies(bool affectEnemies = true)
    {
      return OnConfigureInternal(blueprint => blueprint.AffectEnemies = affectEnemies);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityAreaEffect.AggroEnemies"/>
    /// </summary>
    public AbilityAreaEffectConfigurator SetAggroEnemies(bool aggro = false)
    {
      return OnConfigureInternal(blueprint => blueprint.AggroEnemies = aggro);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityAreaEffect.AffectDead"/>
    /// </summary>
    public AbilityAreaEffectConfigurator SetAffectDead(bool affectDead = true)
    {
      return OnConfigureInternal(blueprint => blueprint.AffectDead = affectDead);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityAreaEffect.IgnoreSleepingUnits"/>
    /// </summary>
    public AbilityAreaEffectConfigurator SetIgnoreSleepingUnits(bool ignore = true)
    {
      return OnConfigureInternal(blueprint => blueprint.IgnoreSleepingUnits = ignore);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityAreaEffect.Shape"/>
    /// </summary>
    public AbilityAreaEffectConfigurator SetShape(AreaEffectShape shape)
    {
      return OnConfigureInternal(blueprint => blueprint.Shape = shape);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityAreaEffect.Size"/>
    /// </summary>
    public AbilityAreaEffectConfigurator SetSize(int radiusInFeet)
    {
      return OnConfigureInternal(blueprint => blueprint.Size = new Feet(radiusInFeet));
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityAreaEffect.Fx"/>
    /// </summary>
    public AbilityAreaEffectConfigurator SetFx(PrefabLink prefab)
    {
      return OnConfigureInternal(blueprint => blueprint.Fx = prefab);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityAreaEffect.m_SizeInCells"/> and <see cref="BlueprintAbilityAreaEffect.CanBeUsedInTacticalCombat"/>
    /// </summary>
    /// 
    /// <remarks>Sets <see cref="BlueprintAbilityAreaEffect.CanBeUsedInTacticalCombat"/> to true.</remarks>
    /// <param name="sizeInCells">The game library states this can only be odd and will always be a cylinder.</param>
    public AbilityAreaEffectConfigurator SetSizeInTacticalCombat(int sizeInCells)
    {
      return OnConfigureInternal(
          blueprint =>
          {
            blueprint.m_SizeInCells = sizeInCells;
            blueprint.CanBeUsedInTacticalCombat = true;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityAreaEffect.CanBeUsedInTacticalCombat"/>
    /// </summary>
    public AbilityAreaEffectConfigurator DisableInTacticalCombat()
    {
      return OnConfigureInternal(blueprint => blueprint.CanBeUsedInTacticalCombat = false);
    }


    /// <summary>
    /// Adds <see cref="Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig">ContextRankConfig</see>
    /// </summary>
    /// 
    /// <remarks>Use <see cref="Components.ContextRankConfigs">ContextRankConfigs</see> to create the config</remarks>
    [Implements(typeof(ContextRankConfig))]
    public AbilityAreaEffectConfigurator AddContextRankConfig(ContextRankConfig rankConfig)
    {
      return AddComponent(rankConfig);
    }

    /// <summary>
    /// Adds or modifies <see cref="SpellDescriptorComponent"/>
    /// </summary>
    [Implements(typeof(SpellDescriptorComponent))]
    public AbilityAreaEffectConfigurator AddSpellDescriptors(params SpellDescriptor[] descriptors)
    {
      return OnConfigureInternal(blueprint => AddSpellDescriptors(blueprint, descriptors.ToList()));
    }

    [Implements(typeof(SpellDescriptorComponent))]
    private static void AddSpellDescriptors(BlueprintScriptableObject bp, List<SpellDescriptor> descriptors)
    {
      var component = bp.GetComponent<SpellDescriptorComponent>();
      if (component is null)
      {
        component = new SpellDescriptorComponent();
        bp.AddComponents(component);
      }
      descriptors.ForEach(descriptor => component.Descriptor.m_IntValue |= (long)descriptor);
    }

    /// <summary>
    /// Modifies <see cref="SpellDescriptorComponent"/>
    /// </summary>
    [Implements(typeof(SpellDescriptorComponent))]
    public AbilityAreaEffectConfigurator RemoveSpellDescriptors(params SpellDescriptor[] descriptors)
    {
      return OnConfigureInternal(blueprint => RemoveSpellDescriptors(blueprint, descriptors.ToList()));
    }

    [Implements(typeof(SpellDescriptorComponent))]
    private static void RemoveSpellDescriptors(BlueprintScriptableObject bp, List<SpellDescriptor> descriptors)
    {
      var component = bp.GetComponent<SpellDescriptorComponent>();
      if (component is null) { return; }
      descriptors.ForEach(descriptor => component.Descriptor.m_IntValue &= ~(long)descriptor);
    }

    /// <summary>
    /// Adds <see cref="UniqueAreaEffect"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(UniqueAreaEffect))]
    public AbilityAreaEffectConfigurator AddUniqueAreaEffect(
        string? feature = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new UniqueAreaEffect();
      component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(feature);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParams"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="customProperty"><see cref="Kingmaker.UnitLogic.Mechanics.Properties.BlueprintUnitProperty"/></param>
    [Generated]
    [Implements(typeof(ContextCalculateAbilityParams))]
    public AbilityAreaEffectConfigurator AddContextCalculateAbilityParams(
        bool useKineticistMainStat = default,
        StatType statType = default,
        bool statTypeFromCustomProperty = default,
        string? customProperty = null,
        bool replaceCasterLevel = default,
        ContextValue? casterLevel = null,
        bool replaceSpellLevel = default,
        ContextValue? spellLevel = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(casterLevel);
      ValidateParam(spellLevel);
    
      var component = new ContextCalculateAbilityParams();
      component.UseKineticistMainStat = useKineticistMainStat;
      component.StatType = statType;
      component.StatTypeFromCustomProperty = statTypeFromCustomProperty;
      component.m_CustomProperty = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(customProperty);
      component.ReplaceCasterLevel = replaceCasterLevel;
      component.CasterLevel = casterLevel ?? ContextValues.Constant(0);
      component.ReplaceSpellLevel = replaceSpellLevel;
      component.SpellLevel = spellLevel ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParamsBasedOnClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ContextCalculateAbilityParamsBasedOnClass))]
    public AbilityAreaEffectConfigurator AddContextCalculateAbilityParamsBasedOnClass(
        bool useKineticistMainStat = default,
        StatType statType = default,
        string? characterClass = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ContextCalculateAbilityParamsBasedOnClass();
      component.UseKineticistMainStat = useKineticistMainStat;
      component.StatType = statType;
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateSharedValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextCalculateSharedValue))]
    public AbilityAreaEffectConfigurator AddContextCalculateSharedValue(
        AbilitySharedValue valueType = default,
        ContextDiceValue? value = null,
        double modifier = default)
    {
      ValidateParam(value);
    
      var component = new ContextCalculateSharedValue();
      component.ValueType = valueType;
      component.Value = value ?? Constants.Empty.DiceValue;
      component.Modifier = modifier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextSetAbilityParams"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextSetAbilityParams))]
    public AbilityAreaEffectConfigurator AddContextSetAbilityParams(
        bool add10ToDC = default,
        ContextValue? dC = null,
        ContextValue? casterLevel = null,
        ContextValue? concentration = null,
        ContextValue? spellLevel = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(dC);
      ValidateParam(casterLevel);
      ValidateParam(concentration);
      ValidateParam(spellLevel);
    
      var component = new ContextSetAbilityParams();
      component.Add10ToDC = add10ToDC;
      component.DC = dC ?? ContextValues.Constant(0);
      component.CasterLevel = casterLevel ?? ContextValues.Constant(0);
      component.Concentration = concentration ?? ContextValues.Constant(0);
      component.SpellLevel = spellLevel ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityDifficultyLimitDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityDifficultyLimitDC))]
    public AbilityAreaEffectConfigurator AddAbilityDifficultyLimitDC(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityDifficultyLimitDC();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityAreaEffectBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AbilityAreaEffectBuff))]
    public AbilityAreaEffectConfigurator AddAbilityAreaEffectBuff(
        ConditionsBuilder? condition = null,
        bool checkConditionEveryRound = default,
        string? buff = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityAreaEffectBuff();
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.CheckConditionEveryRound = checkConditionEveryRound;
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityAreaEffectMovement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityAreaEffectMovement))]
    public AbilityAreaEffectConfigurator AddAbilityAreaEffectMovement(
        Feet distancePerRound,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityAreaEffectMovement();
      component.DistancePerRound = distancePerRound;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityAreaEffectRunAction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityAreaEffectRunAction))]
    public AbilityAreaEffectConfigurator AddAbilityAreaEffectRunAction(
        ActionsBuilder? unitEnter = null,
        ActionsBuilder? unitExit = null,
        ActionsBuilder? unitMove = null,
        ActionsBuilder? round = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityAreaEffectRunAction();
      component.UnitEnter = unitEnter?.Build() ?? Constants.Empty.Actions;
      component.UnitExit = unitExit?.Build() ?? Constants.Empty.Actions;
      component.UnitMove = unitMove?.Build() ?? Constants.Empty.Actions;
      component.Round = round?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityAreaEffectSpecialBehaviour"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AbilityAreaEffectSpecialBehaviour))]
    public AbilityAreaEffectConfigurator AddAbilityAreaEffectSpecialBehaviour(
        Buff buffFact,
        SpecialBehaviour behaviour = default,
        string? buff = null,
        int count = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(buffFact);
    
      var component = new AbilityAreaEffectSpecialBehaviour();
      component.Behaviour = behaviour;
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.m_BuffFact = buffFact;
      component.m_Count = count;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbillityAreaEffectRoundFX"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbillityAreaEffectRoundFX))]
    public AbilityAreaEffectConfigurator AddAbillityAreaEffectRoundFX(
        PrefabLink? prefabLink = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(prefabLink);
    
      var component = new AbillityAreaEffectRoundFX();
      component.PrefabLink = prefabLink ?? Constants.Empty.PrefabLink;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AreaEffectPit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="visualSettings"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAreaEffectPitVisualSettings"/></param>
    /// <param name="unitOnEdgeBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="effectsImmunityFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    /// <param name="evadingImmunityFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AreaEffectPit))]
    public AbilityAreaEffectConfigurator AddAreaEffectPit(
        string? visualSettings = null,
        ContextValue? climbDC = null,
        ActionsBuilder? onFallAction = null,
        ActionsBuilder? everyRoundAction = null,
        ActionsBuilder? onEndedActionForUnitsInside = null,
        string? unitOnEdgeBuff = null,
        Size maxUnitSize = default,
        bool disableClimb = default,
        string[]? effectsImmunityFacts = null,
        string[]? evadingImmunityFacts = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(climbDC);
    
      var component = new AreaEffectPit();
      component.m_VisualSettings = BlueprintTool.GetRef<BlueprintAreaEffectPitVisualSettingsReference>(visualSettings);
      component.ClimbDC = climbDC ?? ContextValues.Constant(0);
      component.OnFallAction = onFallAction?.Build() ?? Constants.Empty.Actions;
      component.EveryRoundAction = everyRoundAction?.Build() ?? Constants.Empty.Actions;
      component.OnEndedActionForUnitsInside = onEndedActionForUnitsInside?.Build() ?? Constants.Empty.Actions;
      component.UnitOnEdgeBuff = BlueprintTool.GetRef<BlueprintBuffReference>(unitOnEdgeBuff);
      component.MaxUnitSize = maxUnitSize;
      component.DisableClimb = disableClimb;
      component.m_EffectsImmunityFacts = effectsImmunityFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_EvadingImmunityFacts = evadingImmunityFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="CustomAreaOnGrid"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CustomAreaOnGrid))]
    public AbilityAreaEffectConfigurator AddCustomAreaOnGrid(
        List<Vector2Int>? affectedCells = null,
        bool ignoreObstaclesAndUnits = default,
        bool spawnFxInEveryCell = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new CustomAreaOnGrid();
      component.AffectedCells = affectedCells;
      component.IgnoreObstaclesAndUnits = ignoreObstaclesAndUnits;
      component.SpawnFxInEveryCell = spawnFxInEveryCell;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}

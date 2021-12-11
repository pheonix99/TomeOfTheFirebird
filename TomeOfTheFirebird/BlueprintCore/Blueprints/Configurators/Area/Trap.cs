using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.ElementsSystem;
using Kingmaker.Visual.Animation.Kingmaker;
using System;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Configurator for <see cref="BlueprintTrap"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTrap))]
  public class TrapConfigurator : BaseMapObjectConfigurator<BlueprintTrap, TrapConfigurator>
  {
    private TrapConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TrapConfigurator For(string name)
    {
      return new TrapConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TrapConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintTrap>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.PerceptionDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapConfigurator SetPerceptionDC(int perceptionDC)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.PerceptionDC = perceptionDC;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.PerceptionRadius"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapConfigurator SetPerceptionRadius(float perceptionRadius)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.PerceptionRadius = perceptionRadius;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.DisableDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapConfigurator SetDisableDC(int disableDC)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DisableDC = disableDC;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.DisableTriggerMargin"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapConfigurator SetDisableTriggerMargin(int disableTriggerMargin)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DisableTriggerMargin = disableTriggerMargin;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.IsHiddenWhenInactive"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapConfigurator SetIsHiddenWhenInactive(bool isHiddenWhenInactive)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsHiddenWhenInactive = isHiddenWhenInactive;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.AllowedForRandomEncounters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapConfigurator SetAllowedForRandomEncounters(bool allowedForRandomEncounters)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AllowedForRandomEncounters = allowedForRandomEncounters;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.DisarmAnimation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapConfigurator SetDisarmAnimation(UnitAnimationInteractionType disarmAnimation)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DisarmAnimation = disarmAnimation;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.m_Actor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="actor"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public TrapConfigurator SetActor(string? actor)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Actor = BlueprintTool.GetRef<BlueprintUnitReference>(actor);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.TriggerConditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapConfigurator SetTriggerConditions(ConditionsBuilder? triggerConditions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TriggerConditions = triggerConditions?.Build() ?? Constants.Empty.Conditions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.DisableConditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapConfigurator SetDisableConditions(ConditionsBuilder? disableConditions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DisableConditions = disableConditions?.Build() ?? Constants.Empty.Conditions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.TrapActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapConfigurator SetTrapActions(ActionsBuilder? trapActions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TrapActions = trapActions?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.DisableActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapConfigurator SetDisableActions(ActionsBuilder? disableActions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DisableActions = disableActions?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Adds <see cref="Experience"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Experience))]
    public TrapConfigurator AddExperience(
        IntEvaluator count,
        EncounterType encounter = default,
        int cR = default,
        float modifier = default,
        bool dummy = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(count);
    
      var component = new Experience();
      component.Encounter = encounter;
      component.CR = cR;
      component.Modifier = modifier;
      component.Count = count;
      component.Dummy = dummy;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}

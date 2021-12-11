using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.UnitLogic;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="ConditionConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(ConditionConsideration))]
  public class ConditionConsiderationConfigurator : BaseConsiderationConfigurator<ConditionConsideration, ConditionConsiderationConfigurator>
  {
    private ConditionConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ConditionConsiderationConfigurator For(string name)
    {
      return new ConditionConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ConditionConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<ConditionConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="ConditionConsideration.Conditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ConditionConsiderationConfigurator SetConditions(UnitCondition[]? conditions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Conditions = conditions;
          });
    }

    /// <summary>
    /// Adds to <see cref="ConditionConsideration.Conditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ConditionConsiderationConfigurator AddToConditions(params UnitCondition[] conditions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Conditions = CommonTool.Append(bp.Conditions, conditions ?? new UnitCondition[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="ConditionConsideration.Conditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ConditionConsiderationConfigurator RemoveFromConditions(params UnitCondition[] conditions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Conditions = bp.Conditions.Where(item => !conditions.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="ConditionConsideration.HasCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ConditionConsiderationConfigurator SetHasCondition(float hasCondition)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HasCondition = hasCondition;
          });
    }

    /// <summary>
    /// Sets <see cref="ConditionConsideration.NoCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ConditionConsiderationConfigurator SetNoCondition(float noCondition)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NoCondition = noCondition;
          });
    }
  }
}

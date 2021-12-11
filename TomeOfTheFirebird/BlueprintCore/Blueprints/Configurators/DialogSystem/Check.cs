using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Configurator for <see cref="BlueprintCheck"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCheck))]
  public class CheckConfigurator : BaseCueBaseConfigurator<BlueprintCheck, CheckConfigurator>
  {
    private CheckConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CheckConfigurator For(string name)
    {
      return new CheckConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CheckConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintCheck>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCheck.Type"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CheckConfigurator SetType(StatType type)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Type = type;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCheck.DC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CheckConfigurator SetDC(int dC)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DC = dC;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCheck.Hidden"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CheckConfigurator SetHidden(bool hidden)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Hidden = hidden;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCheck.DCModifiers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CheckConfigurator SetDCModifiers(DCModifier[]? dCModifiers)
    {
      ValidateParam(dCModifiers);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.DCModifiers = dCModifiers;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCheck.DCModifiers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CheckConfigurator AddToDCModifiers(params DCModifier[] dCModifiers)
    {
      ValidateParam(dCModifiers);
      return OnConfigureInternal(
          bp =>
          {
            bp.DCModifiers = CommonTool.Append(bp.DCModifiers, dCModifiers ?? new DCModifier[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCheck.DCModifiers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CheckConfigurator RemoveFromDCModifiers(params DCModifier[] dCModifiers)
    {
      ValidateParam(dCModifiers);
      return OnConfigureInternal(
          bp =>
          {
            bp.DCModifiers = bp.DCModifiers.Where(item => !dCModifiers.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCheck.m_Success"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="success"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintCueBase"/></param>
    [Generated]
    public CheckConfigurator SetSuccess(string? success)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Success = BlueprintTool.GetRef<BlueprintCueBaseReference>(success);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCheck.m_Fail"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="fail"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintCueBase"/></param>
    [Generated]
    public CheckConfigurator SetFail(string? fail)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Fail = BlueprintTool.GetRef<BlueprintCueBaseReference>(fail);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCheck.m_UnitEvaluator"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CheckConfigurator SetUnitEvaluator(UnitEvaluator unitEvaluator)
    {
      ValidateParam(unitEvaluator);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_UnitEvaluator = unitEvaluator;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCheck.Experience"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CheckConfigurator SetExperience(DialogExperience experience)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Experience = experience;
          });
    }
  }
}

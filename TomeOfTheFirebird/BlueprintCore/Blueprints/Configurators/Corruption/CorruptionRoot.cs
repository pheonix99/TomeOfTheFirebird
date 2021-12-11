using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Corruption;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Corruption
{
  /// <summary>
  /// Configurator for <see cref="BlueprintCorruptionRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCorruptionRoot))]
  public class CorruptionRootConfigurator : BaseBlueprintConfigurator<BlueprintCorruptionRoot, CorruptionRootConfigurator>
  {
    private CorruptionRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CorruptionRootConfigurator For(string name)
    {
      return new CorruptionRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CorruptionRootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintCorruptionRoot>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCorruptionRoot.m_Progression"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CorruptionRootConfigurator SetProgression(CorruptionProgression progression)
    {
      ValidateParam(progression);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Progression = progression;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCorruptionRoot.m_DefaultCorruptionGrowth"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CorruptionRootConfigurator SetDefaultCorruptionGrowth(int defaultCorruptionGrowth)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DefaultCorruptionGrowth = defaultCorruptionGrowth;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCorruptionRoot.m_DSSuccessCoefficient"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CorruptionRootConfigurator SetDSSuccessCoefficient(float dSSuccessCoefficient)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DSSuccessCoefficient = dSSuccessCoefficient;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCorruptionRoot.m_DSCriticalFailCoefficient"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CorruptionRootConfigurator SetDSCriticalFailCoefficient(float dSCriticalFailCoefficient)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DSCriticalFailCoefficient = dSCriticalFailCoefficient;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCorruptionRoot.m_GlobalMapBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="globalMapBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    public CorruptionRootConfigurator SetGlobalMapBuff(string? globalMapBuff)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_GlobalMapBuff = BlueprintTool.GetRef<BlueprintBuffReference>(globalMapBuff);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCorruptionRoot.m_GlobalMapBuffDurationMinutes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CorruptionRootConfigurator SetGlobalMapBuffDurationMinutes(int globalMapBuffDurationMinutes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_GlobalMapBuffDurationMinutes = globalMapBuffDurationMinutes;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCorruptionRoot.m_SpeedModifierDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CorruptionRootConfigurator SetSpeedModifierDC(int speedModifierDC)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SpeedModifierDC = speedModifierDC;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCorruptionRoot.m_SpeedModifierDCIncrement"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CorruptionRootConfigurator SetSpeedModifierDCIncrement(int speedModifierDCIncrement)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SpeedModifierDCIncrement = speedModifierDCIncrement;
          });
    }
  }
}

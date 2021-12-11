using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Interaction;
using Kingmaker.ResourceLinks;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Interaction
{
  /// <summary>
  /// Configurator for <see cref="BlueprintInteractionRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintInteractionRoot))]
  public class InteractionRootConfigurator : BaseBlueprintConfigurator<BlueprintInteractionRoot, InteractionRootConfigurator>
  {
    private InteractionRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static InteractionRootConfigurator For(string name)
    {
      return new InteractionRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static InteractionRootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintInteractionRoot>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintInteractionRoot.m_InteractionDCVariation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public InteractionRootConfigurator SetInteractionDCVariation(int interactionDCVariation)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_InteractionDCVariation = interactionDCVariation;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintInteractionRoot.m_MagicPowerCost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public InteractionRootConfigurator SetMagicPowerCost(int magicPowerCost)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MagicPowerCost = magicPowerCost;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintInteractionRoot.m_MagicPowerItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="magicPowerItem"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public InteractionRootConfigurator SetMagicPowerItem(string? magicPowerItem)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MagicPowerItem = BlueprintTool.GetRef<BlueprintItemReference>(magicPowerItem);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintInteractionRoot.m_DestructionFx"/> (Auto Generated)
    /// </summary>
    [Generated]
    public InteractionRootConfigurator SetDestructionFx(PrefabLink? destructionFx)
    {
      ValidateParam(destructionFx);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DestructionFx = destructionFx ?? Constants.Empty.PrefabLink;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintInteractionRoot.m_FxDenominator"/> (Auto Generated)
    /// </summary>
    [Generated]
    public InteractionRootConfigurator SetFxDenominator(float fxDenominator)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_FxDenominator = fxDenominator;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintInteractionRoot.m_DefaultDestructionSuccessSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public InteractionRootConfigurator SetDefaultDestructionSuccessSound(string defaultDestructionSuccessSound)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DefaultDestructionSuccessSound = defaultDestructionSuccessSound;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintInteractionRoot.m_LockpickStartSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public InteractionRootConfigurator SetLockpickStartSound(string lockpickStartSound)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_LockpickStartSound = lockpickStartSound;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintInteractionRoot.m_LockpickEndSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public InteractionRootConfigurator SetLockpickEndSound(string lockpickEndSound)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_LockpickEndSound = lockpickEndSound;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintInteractionRoot.m_LockpickSuccessSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public InteractionRootConfigurator SetLockpickSuccessSound(string lockpickSuccessSound)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_LockpickSuccessSound = lockpickSuccessSound;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintInteractionRoot.m_LockpickFailSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public InteractionRootConfigurator SetLockpickFailSound(string lockpickFailSound)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_LockpickFailSound = lockpickFailSound;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintInteractionRoot.m_LockpickCriticalFailSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public InteractionRootConfigurator SetLockpickCriticalFailSound(string lockpickCriticalFailSound)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_LockpickCriticalFailSound = lockpickCriticalFailSound;
          });
    }
  }
}

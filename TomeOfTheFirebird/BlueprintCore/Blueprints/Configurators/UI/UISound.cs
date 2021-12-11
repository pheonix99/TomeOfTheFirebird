using BlueprintCore.Utils;
using Kingmaker.UI;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.UI
{
  /// <summary>
  /// Configurator for <see cref="BlueprintUISound"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUISound))]
  public class UISoundConfigurator : BaseBlueprintConfigurator<BlueprintUISound, UISoundConfigurator>
  {
    private UISoundConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UISoundConfigurator For(string name)
    {
      return new UISoundConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UISoundConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintUISound>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintUISound.Sounds"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UISoundConfigurator SetSounds(List<BlueprintUISound.UISound>? sounds)
    {
      ValidateParam(sounds);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Sounds = sounds;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintUISound.Sounds"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UISoundConfigurator AddToSounds(params BlueprintUISound.UISound[] sounds)
    {
      ValidateParam(sounds);
      return OnConfigureInternal(
          bp =>
          {
            bp.Sounds.AddRange(sounds.ToList() ?? new List<BlueprintUISound.UISound>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintUISound.Sounds"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UISoundConfigurator RemoveFromSounds(params BlueprintUISound.UISound[] sounds)
    {
      ValidateParam(sounds);
      return OnConfigureInternal(
          bp =>
          {
            bp.Sounds = bp.Sounds.Where(item => !sounds.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUISound.ArmyManagement"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UISoundConfigurator SetArmyManagement(List<BlueprintUISound.UISound>? armyManagement)
    {
      ValidateParam(armyManagement);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ArmyManagement = armyManagement;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintUISound.ArmyManagement"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UISoundConfigurator AddToArmyManagement(params BlueprintUISound.UISound[] armyManagement)
    {
      ValidateParam(armyManagement);
      return OnConfigureInternal(
          bp =>
          {
            bp.ArmyManagement.AddRange(armyManagement.ToList() ?? new List<BlueprintUISound.UISound>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintUISound.ArmyManagement"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UISoundConfigurator RemoveFromArmyManagement(params BlueprintUISound.UISound[] armyManagement)
    {
      ValidateParam(armyManagement);
      return OnConfigureInternal(
          bp =>
          {
            bp.ArmyManagement = bp.ArmyManagement.Where(item => !armyManagement.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUISound.Tooltip"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UISoundConfigurator SetTooltip(List<BlueprintUISound.UISound>? tooltip)
    {
      ValidateParam(tooltip);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Tooltip = tooltip;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintUISound.Tooltip"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UISoundConfigurator AddToTooltip(params BlueprintUISound.UISound[] tooltip)
    {
      ValidateParam(tooltip);
      return OnConfigureInternal(
          bp =>
          {
            bp.Tooltip.AddRange(tooltip.ToList() ?? new List<BlueprintUISound.UISound>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintUISound.Tooltip"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UISoundConfigurator RemoveFromTooltip(params BlueprintUISound.UISound[] tooltip)
    {
      ValidateParam(tooltip);
      return OnConfigureInternal(
          bp =>
          {
            bp.Tooltip = bp.Tooltip.Where(item => !tooltip.Contains(item)).ToList();
          });
    }
  }
}

using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Configurator for <see cref="BlueprintClassAdditionalVisualSettingsProgression"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintClassAdditionalVisualSettingsProgression))]
  public class ClassAdditionalVisualSettingsProgressionConfigurator : BaseBlueprintConfigurator<BlueprintClassAdditionalVisualSettingsProgression, ClassAdditionalVisualSettingsProgressionConfigurator>
  {
    private ClassAdditionalVisualSettingsProgressionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ClassAdditionalVisualSettingsProgressionConfigurator For(string name)
    {
      return new ClassAdditionalVisualSettingsProgressionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ClassAdditionalVisualSettingsProgressionConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintClassAdditionalVisualSettingsProgression>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintClassAdditionalVisualSettingsProgression.Entries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClassAdditionalVisualSettingsProgressionConfigurator SetEntries(BlueprintClassAdditionalVisualSettingsProgression.Entry[]? entries)
    {
      ValidateParam(entries);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Entries = entries;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintClassAdditionalVisualSettingsProgression.Entries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClassAdditionalVisualSettingsProgressionConfigurator AddToEntries(params BlueprintClassAdditionalVisualSettingsProgression.Entry[] entries)
    {
      ValidateParam(entries);
      return OnConfigureInternal(
          bp =>
          {
            bp.Entries = CommonTool.Append(bp.Entries, entries ?? new BlueprintClassAdditionalVisualSettingsProgression.Entry[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintClassAdditionalVisualSettingsProgression.Entries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClassAdditionalVisualSettingsProgressionConfigurator RemoveFromEntries(params BlueprintClassAdditionalVisualSettingsProgression.Entry[] entries)
    {
      ValidateParam(entries);
      return OnConfigureInternal(
          bp =>
          {
            bp.Entries = bp.Entries.Where(item => !entries.Contains(item)).ToArray();
          });
    }
  }
}

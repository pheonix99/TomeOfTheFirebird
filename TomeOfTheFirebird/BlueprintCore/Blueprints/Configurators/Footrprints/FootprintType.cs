using BlueprintCore.Utils;
using Kingmaker.Blueprints.Footrprints;
using Kingmaker.Enums;
using Kingmaker.Utility.EnumArrays;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Footrprints
{
  /// <summary>
  /// Configurator for <see cref="BlueprintFootprintType"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintFootprintType))]
  public class FootprintTypeConfigurator : BaseBlueprintConfigurator<BlueprintFootprintType, FootprintTypeConfigurator>
  {
    private FootprintTypeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FootprintTypeConfigurator For(string name)
    {
      return new FootprintTypeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FootprintTypeConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintFootprintType>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFootprintType.FootprintType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FootprintTypeConfigurator SetFootprintType(FootprintType footprintType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FootprintType = footprintType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintFootprintType.Footprints"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FootprintTypeConfigurator SetFootprints(FootprintsEnumArray footprints)
    {
      ValidateParam(footprints);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Footprints = footprints;
          });
    }
  }
}

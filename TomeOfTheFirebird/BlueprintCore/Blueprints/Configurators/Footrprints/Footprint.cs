using BlueprintCore.Utils;
using Kingmaker.Blueprints.Footrprints;
using Kingmaker.ResourceLinks;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Footrprints
{
  /// <summary>
  /// Configurator for <see cref="BlueprintFootprint"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintFootprint))]
  public class FootprintConfigurator : BaseBlueprintConfigurator<BlueprintFootprint, FootprintConfigurator>
  {
    private FootprintConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FootprintConfigurator For(string name)
    {
      return new FootprintConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FootprintConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintFootprint>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFootprint.LeftFootPrint"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FootprintConfigurator SetLeftFootPrint(PrefabLink? leftFootPrint)
    {
      ValidateParam(leftFootPrint);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LeftFootPrint = leftFootPrint ?? Constants.Empty.PrefabLink;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintFootprint.RightFootPrint"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FootprintConfigurator SetRightFootPrint(PrefabLink? rightFootPrint)
    {
      ValidateParam(rightFootPrint);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.RightFootPrint = rightFootPrint ?? Constants.Empty.PrefabLink;
          });
    }
  }
}

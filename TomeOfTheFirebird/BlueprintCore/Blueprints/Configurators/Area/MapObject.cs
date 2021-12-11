using BlueprintCore.Utils;
using Kingmaker.Blueprints.Area;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintMapObject"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintMapObject))]
  public abstract class BaseMapObjectConfigurator<T, TBuilder>
      : BaseLogicConnectorConfigurator<T, TBuilder>
      where T : BlueprintMapObject
      where TBuilder : BaseMapObjectConfigurator<T, TBuilder>
  {
    protected BaseMapObjectConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintMapObject.Prefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetPrefab(GameObject prefab)
    {
      ValidateParam(prefab);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Prefab = prefab;
          });
    }
  }
}

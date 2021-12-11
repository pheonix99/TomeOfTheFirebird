using BlueprintCore.Utils;
using Kingmaker.Blueprints.Console;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Console
{
  /// <summary>
  /// Configurator for <see cref="GamePadTexts"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(GamePadTexts))]
  public class GamePadTextsConfigurator : BaseBlueprintConfigurator<GamePadTexts, GamePadTextsConfigurator>
  {
    private GamePadTextsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static GamePadTextsConfigurator For(string name)
    {
      return new GamePadTextsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static GamePadTextsConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<GamePadTexts>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="GamePadTexts.m_Layers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GamePadTextsConfigurator SetLayers(List<GamePadTexts.GamePadTextsLayer>? layers)
    {
      ValidateParam(layers);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Layers = layers;
          });
    }

    /// <summary>
    /// Adds to <see cref="GamePadTexts.m_Layers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GamePadTextsConfigurator AddToLayers(params GamePadTexts.GamePadTextsLayer[] layers)
    {
      ValidateParam(layers);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Layers.AddRange(layers.ToList() ?? new List<GamePadTexts.GamePadTextsLayer>());
          });
    }

    /// <summary>
    /// Removes from <see cref="GamePadTexts.m_Layers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GamePadTextsConfigurator RemoveFromLayers(params GamePadTexts.GamePadTextsLayer[] layers)
    {
      ValidateParam(layers);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Layers = bp.m_Layers.Where(item => !layers.Contains(item)).ToList();
          });
    }
  }
}

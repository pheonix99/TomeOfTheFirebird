using BlueprintCore.Utils;
using Kingmaker.Blueprints.Console;
using Kingmaker.Blueprints.Root;
using Owlcat.Runtime.UI.ConsoleTools.GamepadInput;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>
  /// Configurator for <see cref="ConsoleRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(ConsoleRoot))]
  public class ConsoleRootConfigurator : BaseBlueprintConfigurator<ConsoleRoot, ConsoleRootConfigurator>
  {
    private ConsoleRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ConsoleRootConfigurator For(string name)
    {
      return new ConsoleRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ConsoleRootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<ConsoleRoot>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="ConsoleRoot.Icons"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ConsoleRootConfigurator SetIcons(GamePadIcons icons)
    {
      ValidateParam(icons);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Icons = icons;
          });
    }

    /// <summary>
    /// Sets <see cref="ConsoleRoot.Texts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="texts"><see cref="Kingmaker.Blueprints.Console.GamePadTexts"/></param>
    [Generated]
    public ConsoleRootConfigurator SetTexts(string? texts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Texts = BlueprintTool.GetRef<GamePadTexts.Reference>(texts);
          });
    }

    /// <summary>
    /// Sets <see cref="ConsoleRoot.InGameMenuIcons"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ConsoleRootConfigurator SetInGameMenuIcons(ConsoleRoot.UIInGameMenuIcons inGameMenuIcons)
    {
      ValidateParam(inGameMenuIcons);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.InGameMenuIcons = inGameMenuIcons;
          });
    }
  }
}

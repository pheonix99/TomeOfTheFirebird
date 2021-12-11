using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.Localization;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="ConsiderationCustom"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(ConsiderationCustom))]
  public class ConsiderationCustomConfigurator : BaseConsiderationConfigurator<ConsiderationCustom, ConsiderationCustomConfigurator>
  {
    private ConsiderationCustomConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ConsiderationCustomConfigurator For(string name)
    {
      return new ConsiderationCustomConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ConsiderationCustomConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<ConsiderationCustom>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="ConsiderationCustom.Consideration"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="consideration"><see cref="Kingmaker.AI.Blueprints.Considerations.Consideration"/></param>
    [Generated]
    public ConsiderationCustomConfigurator SetConsideration(string? consideration)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Consideration = BlueprintTool.GetRef<ConsiderationReference>(consideration);
          });
    }

    /// <summary>
    /// Sets <see cref="ConsiderationCustom.Title"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ConsiderationCustomConfigurator SetTitle(LocalizedString? title)
    {
      ValidateParam(title);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Title = title ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="ConsiderationCustom.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ConsiderationCustomConfigurator SetDescription(LocalizedString? description)
    {
      ValidateParam(description);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Description = description ?? Constants.Empty.String;
          });
    }
  }
}

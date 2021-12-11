using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.UnitLogic.Commands.Base;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="ActiveCommandConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(ActiveCommandConsideration))]
  public class ActiveCommandConsiderationConfigurator : BaseConsiderationConfigurator<ActiveCommandConsideration, ActiveCommandConsiderationConfigurator>
  {
    private ActiveCommandConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ActiveCommandConsiderationConfigurator For(string name)
    {
      return new ActiveCommandConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ActiveCommandConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<ActiveCommandConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="ActiveCommandConsideration.CommandType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ActiveCommandConsiderationConfigurator SetCommandType(UnitCommand.CommandType commandType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CommandType = commandType;
          });
    }

    /// <summary>
    /// Sets <see cref="ActiveCommandConsideration.HasCommandScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ActiveCommandConsiderationConfigurator SetHasCommandScore(float hasCommandScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HasCommandScore = hasCommandScore;
          });
    }

    /// <summary>
    /// Sets <see cref="ActiveCommandConsideration.NoCommandScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ActiveCommandConsiderationConfigurator SetNoCommandScore(float noCommandScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NoCommandScore = noCommandScore;
          });
    }
  }
}

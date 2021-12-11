using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.UnitLogic.Commands.Base;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="CommandCooldownConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(CommandCooldownConsideration))]
  public class CommandCooldownConsiderationConfigurator : BaseConsiderationConfigurator<CommandCooldownConsideration, CommandCooldownConsiderationConfigurator>
  {
    private CommandCooldownConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CommandCooldownConsiderationConfigurator For(string name)
    {
      return new CommandCooldownConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CommandCooldownConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<CommandCooldownConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="CommandCooldownConsideration.CommandType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CommandCooldownConsiderationConfigurator SetCommandType(UnitCommand.CommandType commandType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CommandType = commandType;
          });
    }

    /// <summary>
    /// Sets <see cref="CommandCooldownConsideration.OnCooldownScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CommandCooldownConsiderationConfigurator SetOnCooldownScore(float onCooldownScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OnCooldownScore = onCooldownScore;
          });
    }

    /// <summary>
    /// Sets <see cref="CommandCooldownConsideration.OffCooldownScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CommandCooldownConsiderationConfigurator SetOffCooldownScore(float offCooldownScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OffCooldownScore = offCooldownScore;
          });
    }
  }
}

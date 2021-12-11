using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.RuleSystem;
using Kingmaker.Settings;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAiAction"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAiAction))]
  public abstract class BaseAiActionConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintAiAction
      where TBuilder : BaseAiActionConfigurator<T, TBuilder>
  {
    protected BaseAiActionConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.AdditionalBehaviour"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetAdditionalBehaviour(bool additionalBehaviour)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AdditionalBehaviour = additionalBehaviour;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.MinDifficulty"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetMinDifficulty(GameDifficultyOption minDifficulty)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MinDifficulty = minDifficulty;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.InvertDifficultyRequirements"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetInvertDifficultyRequirements(bool invertDifficultyRequirements)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.InvertDifficultyRequirements = invertDifficultyRequirements;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.OncePerRound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetOncePerRound(bool oncePerRound)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OncePerRound = oncePerRound;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.CooldownRounds"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCooldownRounds(int cooldownRounds)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CooldownRounds = cooldownRounds;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.CooldownDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCooldownDice(DiceFormula cooldownDice)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CooldownDice = cooldownDice;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.StartCooldownRounds"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetStartCooldownRounds(int startCooldownRounds)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StartCooldownRounds = startCooldownRounds;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.CombatCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCombatCount(int combatCount)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CombatCount = combatCount;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.UseWhenAIDisabled"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetUseWhenAIDisabled(bool useWhenAIDisabled)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.UseWhenAIDisabled = useWhenAIDisabled;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.UseOnLimitedAI"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetUseOnLimitedAI(bool useOnLimitedAI)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.UseOnLimitedAI = useOnLimitedAI;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.BaseScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetBaseScore(float baseScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BaseScore = baseScore;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.m_ActorConsiderations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="actorConsiderations"><see cref="Kingmaker.AI.Blueprints.Considerations.Consideration"/></param>
    [Generated]
    public TBuilder SetActorConsiderations(string[]? actorConsiderations)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ActorConsiderations = actorConsiderations.Select(name => BlueprintTool.GetRef<ConsiderationReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAiAction.m_ActorConsiderations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="actorConsiderations"><see cref="Kingmaker.AI.Blueprints.Considerations.Consideration"/></param>
    [Generated]
    public TBuilder AddToActorConsiderations(params string[] actorConsiderations)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ActorConsiderations = CommonTool.Append(bp.m_ActorConsiderations, actorConsiderations.Select(name => BlueprintTool.GetRef<ConsiderationReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAiAction.m_ActorConsiderations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="actorConsiderations"><see cref="Kingmaker.AI.Blueprints.Considerations.Consideration"/></param>
    [Generated]
    public TBuilder RemoveFromActorConsiderations(params string[] actorConsiderations)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = actorConsiderations.Select(name => BlueprintTool.GetRef<ConsiderationReference>(name));
            bp.m_ActorConsiderations =
                bp.m_ActorConsiderations
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.m_TargetConsiderations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="targetConsiderations"><see cref="Kingmaker.AI.Blueprints.Considerations.Consideration"/></param>
    [Generated]
    public TBuilder SetTargetConsiderations(string[]? targetConsiderations)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TargetConsiderations = targetConsiderations.Select(name => BlueprintTool.GetRef<ConsiderationReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAiAction.m_TargetConsiderations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="targetConsiderations"><see cref="Kingmaker.AI.Blueprints.Considerations.Consideration"/></param>
    [Generated]
    public TBuilder AddToTargetConsiderations(params string[] targetConsiderations)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TargetConsiderations = CommonTool.Append(bp.m_TargetConsiderations, targetConsiderations.Select(name => BlueprintTool.GetRef<ConsiderationReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAiAction.m_TargetConsiderations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="targetConsiderations"><see cref="Kingmaker.AI.Blueprints.Considerations.Consideration"/></param>
    [Generated]
    public TBuilder RemoveFromTargetConsiderations(params string[] targetConsiderations)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = targetConsiderations.Select(name => BlueprintTool.GetRef<ConsiderationReference>(name));
            bp.m_TargetConsiderations =
                bp.m_TargetConsiderations
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}

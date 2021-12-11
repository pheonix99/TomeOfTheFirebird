using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>
  /// Configurator for <see cref="BlueprintArmyLeader"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArmyLeader))]
  public class ArmyLeaderConfigurator : BaseBlueprintConfigurator<BlueprintArmyLeader, ArmyLeaderConfigurator>
  {
    private ArmyLeaderConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArmyLeaderConfigurator For(string name)
    {
      return new ArmyLeaderConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArmyLeaderConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintArmyLeader>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmyLeader.m_LeaderName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyLeaderConfigurator SetLeaderName(LocalizedString? leaderName)
    {
      ValidateParam(leaderName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_LeaderName = leaderName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmyLeader.m_Portrait"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="portrait"><see cref="Kingmaker.Blueprints.BlueprintPortrait"/></param>
    [Generated]
    public ArmyLeaderConfigurator SetPortrait(string? portrait)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Portrait = BlueprintTool.GetRef<BlueprintPortraitReference>(portrait);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmyLeader.m_StartingLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyLeaderConfigurator SetStartingLevel(int startingLevel)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_StartingLevel = startingLevel;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmyLeader.m_LeaderProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="leaderProgression"><see cref="Kingmaker.Armies.BlueprintLeaderProgression"/></param>
    [Generated]
    public ArmyLeaderConfigurator SetLeaderProgression(string? leaderProgression)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_LeaderProgression = BlueprintTool.GetRef<BlueprintLeaderProgression.Reference>(leaderProgression);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmyLeader.m_Unit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unit"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public ArmyLeaderConfigurator SetUnit(string? unit)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(unit);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmyLeader.m_baseSkills"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="baseSkills"><see cref="Kingmaker.Armies.Blueprints.BlueprintLeaderSkill"/></param>
    [Generated]
    public ArmyLeaderConfigurator SetBaseSkills(string[]? baseSkills)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_baseSkills = baseSkills.Select(name => BlueprintTool.GetRef<BlueprintLeaderSkillReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintArmyLeader.m_baseSkills"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="baseSkills"><see cref="Kingmaker.Armies.Blueprints.BlueprintLeaderSkill"/></param>
    [Generated]
    public ArmyLeaderConfigurator AddToBaseSkills(params string[] baseSkills)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_baseSkills = CommonTool.Append(bp.m_baseSkills, baseSkills.Select(name => BlueprintTool.GetRef<BlueprintLeaderSkillReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintArmyLeader.m_baseSkills"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="baseSkills"><see cref="Kingmaker.Armies.Blueprints.BlueprintLeaderSkill"/></param>
    [Generated]
    public ArmyLeaderConfigurator RemoveFromBaseSkills(params string[] baseSkills)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = baseSkills.Select(name => BlueprintTool.GetRef<BlueprintLeaderSkillReference>(name));
            bp.m_baseSkills =
                bp.m_baseSkills
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}

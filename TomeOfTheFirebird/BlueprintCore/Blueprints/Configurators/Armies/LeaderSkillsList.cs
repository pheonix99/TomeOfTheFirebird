using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Blueprints;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>
  /// Configurator for <see cref="BlueprintLeaderSkillsList"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintLeaderSkillsList))]
  public class LeaderSkillsListConfigurator : BaseBlueprintConfigurator<BlueprintLeaderSkillsList, LeaderSkillsListConfigurator>
  {
    private LeaderSkillsListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static LeaderSkillsListConfigurator For(string name)
    {
      return new LeaderSkillsListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static LeaderSkillsListConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintLeaderSkillsList>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintLeaderSkillsList.m_Skills"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="skills"><see cref="Kingmaker.Armies.Blueprints.BlueprintLeaderSkill"/></param>
    [Generated]
    public LeaderSkillsListConfigurator SetSkills(string[]? skills)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Skills = skills.Select(name => BlueprintTool.GetRef<BlueprintLeaderSkillReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintLeaderSkillsList.m_Skills"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="skills"><see cref="Kingmaker.Armies.Blueprints.BlueprintLeaderSkill"/></param>
    [Generated]
    public LeaderSkillsListConfigurator AddToSkills(params string[] skills)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Skills = CommonTool.Append(bp.m_Skills, skills.Select(name => BlueprintTool.GetRef<BlueprintLeaderSkillReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintLeaderSkillsList.m_Skills"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="skills"><see cref="Kingmaker.Armies.Blueprints.BlueprintLeaderSkill"/></param>
    [Generated]
    public LeaderSkillsListConfigurator RemoveFromSkills(params string[] skills)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = skills.Select(name => BlueprintTool.GetRef<BlueprintLeaderSkillReference>(name));
            bp.m_Skills =
                bp.m_Skills
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}

using BlueprintCore.Utils;
using Kingmaker.Blueprints.Quests;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Quests
{
  /// <summary>
  /// Configurator for <see cref="BlueprintQuestGroups"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintQuestGroups))]
  public class QuestGroupsConfigurator : BaseBlueprintConfigurator<BlueprintQuestGroups, QuestGroupsConfigurator>
  {
    private QuestGroupsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static QuestGroupsConfigurator For(string name)
    {
      return new QuestGroupsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static QuestGroupsConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintQuestGroups>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestGroups.Groups"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestGroupsConfigurator SetGroups(QuestGroup[]? groups)
    {
      ValidateParam(groups);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Groups = groups;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintQuestGroups.Groups"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestGroupsConfigurator AddToGroups(params QuestGroup[] groups)
    {
      ValidateParam(groups);
      return OnConfigureInternal(
          bp =>
          {
            bp.Groups = CommonTool.Append(bp.Groups, groups ?? new QuestGroup[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintQuestGroups.Groups"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestGroupsConfigurator RemoveFromGroups(params QuestGroup[] groups)
    {
      ValidateParam(groups);
      return OnConfigureInternal(
          bp =>
          {
            bp.Groups = bp.Groups.Where(item => !groups.Contains(item)).ToArray();
          });
    }
  }
}

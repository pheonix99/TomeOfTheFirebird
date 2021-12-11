using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Configurator for <see cref="BlueprintProgression"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintProgression))]
  public class ProgressionConfigurator : BaseFeatureConfigurator<BlueprintProgression, ProgressionConfigurator>
  {
    private ProgressionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ProgressionConfigurator For(string name)
    {
      return new ProgressionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ProgressionConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintProgression>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProgression.m_Classes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator SetClasses(BlueprintProgression.ClassWithLevel[]? classes)
    {
      ValidateParam(classes);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Classes = classes;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintProgression.m_Classes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator AddToClasses(params BlueprintProgression.ClassWithLevel[] classes)
    {
      ValidateParam(classes);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Classes = CommonTool.Append(bp.m_Classes, classes ?? new BlueprintProgression.ClassWithLevel[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintProgression.m_Classes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator RemoveFromClasses(params BlueprintProgression.ClassWithLevel[] classes)
    {
      ValidateParam(classes);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Classes = bp.m_Classes.Where(item => !classes.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProgression.m_Archetypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator SetArchetypes(BlueprintProgression.ArchetypeWithLevel[]? archetypes)
    {
      ValidateParam(archetypes);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Archetypes = archetypes;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintProgression.m_Archetypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator AddToArchetypes(params BlueprintProgression.ArchetypeWithLevel[] archetypes)
    {
      ValidateParam(archetypes);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Archetypes = CommonTool.Append(bp.m_Archetypes, archetypes ?? new BlueprintProgression.ArchetypeWithLevel[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintProgression.m_Archetypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator RemoveFromArchetypes(params BlueprintProgression.ArchetypeWithLevel[] archetypes)
    {
      ValidateParam(archetypes);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Archetypes = bp.m_Archetypes.Where(item => !archetypes.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProgression.ForAllOtherClasses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator SetForAllOtherClasses(bool forAllOtherClasses)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ForAllOtherClasses = forAllOtherClasses;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProgression.m_AlternateProgressionClasses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator SetAlternateProgressionClasses(BlueprintProgression.ClassWithLevel[]? alternateProgressionClasses)
    {
      ValidateParam(alternateProgressionClasses);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AlternateProgressionClasses = alternateProgressionClasses;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintProgression.m_AlternateProgressionClasses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator AddToAlternateProgressionClasses(params BlueprintProgression.ClassWithLevel[] alternateProgressionClasses)
    {
      ValidateParam(alternateProgressionClasses);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AlternateProgressionClasses = CommonTool.Append(bp.m_AlternateProgressionClasses, alternateProgressionClasses ?? new BlueprintProgression.ClassWithLevel[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintProgression.m_AlternateProgressionClasses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator RemoveFromAlternateProgressionClasses(params BlueprintProgression.ClassWithLevel[] alternateProgressionClasses)
    {
      ValidateParam(alternateProgressionClasses);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AlternateProgressionClasses = bp.m_AlternateProgressionClasses.Where(item => !alternateProgressionClasses.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProgression.AlternateProgressionType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator SetAlternateProgressionType(AlternateProgressionType alternateProgressionType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AlternateProgressionType = alternateProgressionType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProgression.LevelEntries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator SetLevelEntries(LevelEntry[]? levelEntries)
    {
      ValidateParam(levelEntries);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LevelEntries = levelEntries;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintProgression.LevelEntries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator AddToLevelEntries(params LevelEntry[] levelEntries)
    {
      ValidateParam(levelEntries);
      return OnConfigureInternal(
          bp =>
          {
            bp.LevelEntries = CommonTool.Append(bp.LevelEntries, levelEntries ?? new LevelEntry[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintProgression.LevelEntries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator RemoveFromLevelEntries(params LevelEntry[] levelEntries)
    {
      ValidateParam(levelEntries);
      return OnConfigureInternal(
          bp =>
          {
            bp.LevelEntries = bp.LevelEntries.Where(item => !levelEntries.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProgression.UIGroups"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator SetUIGroups(UIGroup[]? uIGroups)
    {
      ValidateParam(uIGroups);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.UIGroups = uIGroups;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintProgression.UIGroups"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator AddToUIGroups(params UIGroup[] uIGroups)
    {
      ValidateParam(uIGroups);
      return OnConfigureInternal(
          bp =>
          {
            bp.UIGroups = CommonTool.Append(bp.UIGroups, uIGroups ?? new UIGroup[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintProgression.UIGroups"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator RemoveFromUIGroups(params UIGroup[] uIGroups)
    {
      ValidateParam(uIGroups);
      return OnConfigureInternal(
          bp =>
          {
            bp.UIGroups = bp.UIGroups.Where(item => !uIGroups.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProgression.m_UIDeterminatorsGroup"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="uIDeterminatorsGroup"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeatureBase"/></param>
    [Generated]
    public ProgressionConfigurator SetUIDeterminatorsGroup(string[]? uIDeterminatorsGroup)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_UIDeterminatorsGroup = uIDeterminatorsGroup.Select(name => BlueprintTool.GetRef<BlueprintFeatureBaseReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintProgression.m_UIDeterminatorsGroup"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="uIDeterminatorsGroup"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeatureBase"/></param>
    [Generated]
    public ProgressionConfigurator AddToUIDeterminatorsGroup(params string[] uIDeterminatorsGroup)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_UIDeterminatorsGroup = CommonTool.Append(bp.m_UIDeterminatorsGroup, uIDeterminatorsGroup.Select(name => BlueprintTool.GetRef<BlueprintFeatureBaseReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintProgression.m_UIDeterminatorsGroup"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="uIDeterminatorsGroup"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeatureBase"/></param>
    [Generated]
    public ProgressionConfigurator RemoveFromUIDeterminatorsGroup(params string[] uIDeterminatorsGroup)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = uIDeterminatorsGroup.Select(name => BlueprintTool.GetRef<BlueprintFeatureBaseReference>(name));
            bp.m_UIDeterminatorsGroup =
                bp.m_UIDeterminatorsGroup
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProgression.m_ExclusiveProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="exclusiveProgression"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    public ProgressionConfigurator SetExclusiveProgression(string? exclusiveProgression)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ExclusiveProgression = BlueprintTool.GetRef<BlueprintCharacterClassReference>(exclusiveProgression);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProgression.GiveFeaturesForPreviousLevels"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator SetGiveFeaturesForPreviousLevels(bool giveFeaturesForPreviousLevels)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.GiveFeaturesForPreviousLevels = giveFeaturesForPreviousLevels;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProgression.m_FeatureRankIncrease"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="featureRankIncrease"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    public ProgressionConfigurator SetFeatureRankIncrease(string? featureRankIncrease)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_FeatureRankIncrease = BlueprintTool.GetRef<BlueprintFeatureReference>(featureRankIncrease);
          });
    }
  }
}

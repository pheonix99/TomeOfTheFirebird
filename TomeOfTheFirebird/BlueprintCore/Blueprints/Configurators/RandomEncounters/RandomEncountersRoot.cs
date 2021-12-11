using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.View;
using Kingmaker.RandomEncounters.Settings;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.RandomEncounters
{
  /// <summary>
  /// Configurator for <see cref="RandomEncountersRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(RandomEncountersRoot))]
  public class RandomEncountersRootConfigurator : BaseBlueprintConfigurator<RandomEncountersRoot, RandomEncountersRootConfigurator>
  {
    private RandomEncountersRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RandomEncountersRootConfigurator For(string name)
    {
      return new RandomEncountersRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RandomEncountersRootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<RandomEncountersRoot>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="RandomEncountersRoot.EncountersEnabled"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator SetEncountersEnabled(bool encountersEnabled)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.EncountersEnabled = encountersEnabled;
          });
    }

    /// <summary>
    /// Sets <see cref="RandomEncountersRoot.m_Chapters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator SetChapters(RandomEncounterChapterSettings[]? chapters)
    {
      ValidateParam(chapters);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Chapters = chapters;
          });
    }

    /// <summary>
    /// Adds to <see cref="RandomEncountersRoot.m_Chapters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator AddToChapters(params RandomEncounterChapterSettings[] chapters)
    {
      ValidateParam(chapters);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Chapters = CommonTool.Append(bp.m_Chapters, chapters ?? new RandomEncounterChapterSettings[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="RandomEncountersRoot.m_Chapters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator RemoveFromChapters(params RandomEncounterChapterSettings[] chapters)
    {
      ValidateParam(chapters);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Chapters = bp.m_Chapters.Where(item => !chapters.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="RandomEncountersRoot.EncounterPawnPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator SetEncounterPawnPrefab(GlobalMapRandomEncounterPawn encounterPawnPrefab)
    {
      ValidateParam(encounterPawnPrefab);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.EncounterPawnPrefab = encounterPawnPrefab;
          });
    }

    /// <summary>
    /// Sets <see cref="RandomEncountersRoot.EncounterPawnOffset"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator SetEncounterPawnOffset(float encounterPawnOffset)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.EncounterPawnOffset = encounterPawnOffset;
          });
    }

    /// <summary>
    /// Sets <see cref="RandomEncountersRoot.EncounterPawnDistanceFromLocation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator SetEncounterPawnDistanceFromLocation(float encounterPawnDistanceFromLocation)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.EncounterPawnDistanceFromLocation = encounterPawnDistanceFromLocation;
          });
    }

    /// <summary>
    /// Sets <see cref="RandomEncountersRoot.m_TrashLootSettings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="trashLootSettings"><see cref="Kingmaker.Blueprints.Loot.TrashLootSettings"/></param>
    [Generated]
    public RandomEncountersRootConfigurator SetTrashLootSettings(string? trashLootSettings)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TrashLootSettings = BlueprintTool.GetRef<TrashLootSettingsReference>(trashLootSettings);
          });
    }

    /// <summary>
    /// Sets <see cref="RandomEncountersRoot.ZoneSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator SetZoneSettings(ZoneCombatRandomEncounterSettings[]? zoneSettings)
    {
      ValidateParam(zoneSettings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ZoneSettings = zoneSettings;
          });
    }

    /// <summary>
    /// Adds to <see cref="RandomEncountersRoot.ZoneSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator AddToZoneSettings(params ZoneCombatRandomEncounterSettings[] zoneSettings)
    {
      ValidateParam(zoneSettings);
      return OnConfigureInternal(
          bp =>
          {
            bp.ZoneSettings = CommonTool.Append(bp.ZoneSettings, zoneSettings ?? new ZoneCombatRandomEncounterSettings[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="RandomEncountersRoot.ZoneSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator RemoveFromZoneSettings(params ZoneCombatRandomEncounterSettings[] zoneSettings)
    {
      ValidateParam(zoneSettings);
      return OnConfigureInternal(
          bp =>
          {
            bp.ZoneSettings = bp.ZoneSettings.Where(item => !zoneSettings.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="RandomEncountersRoot.m_Encounters"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="encounters"><see cref="Kingmaker.RandomEncounters.Settings.BlueprintRandomEncounter"/></param>
    [Generated]
    public RandomEncountersRootConfigurator SetEncounters(string[]? encounters)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Encounters = encounters.Select(name => BlueprintTool.GetRef<BlueprintRandomEncounterReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="RandomEncountersRoot.m_Encounters"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="encounters"><see cref="Kingmaker.RandomEncounters.Settings.BlueprintRandomEncounter"/></param>
    [Generated]
    public RandomEncountersRootConfigurator AddToEncounters(params string[] encounters)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Encounters.AddRange(encounters.Select(name => BlueprintTool.GetRef<BlueprintRandomEncounterReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="RandomEncountersRoot.m_Encounters"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="encounters"><see cref="Kingmaker.RandomEncounters.Settings.BlueprintRandomEncounter"/></param>
    [Generated]
    public RandomEncountersRootConfigurator RemoveFromEncounters(params string[] encounters)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = encounters.Select(name => BlueprintTool.GetRef<BlueprintRandomEncounterReference>(name));
            bp.m_Encounters =
                bp.m_Encounters
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="RandomEncountersRoot.Armies"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator SetArmies(ArmySettings[]? armies)
    {
      ValidateParam(armies);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Armies = armies;
          });
    }

    /// <summary>
    /// Adds to <see cref="RandomEncountersRoot.Armies"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator AddToArmies(params ArmySettings[] armies)
    {
      ValidateParam(armies);
      return OnConfigureInternal(
          bp =>
          {
            bp.Armies = CommonTool.Append(bp.Armies, armies ?? new ArmySettings[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="RandomEncountersRoot.Armies"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator RemoveFromArmies(params ArmySettings[] armies)
    {
      ValidateParam(armies);
      return OnConfigureInternal(
          bp =>
          {
            bp.Armies = bp.Armies.Where(item => !armies.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="RandomEncountersRoot.m_Vendor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator SetVendor(REVendor vendor)
    {
      ValidateParam(vendor);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Vendor = vendor;
          });
    }

    /// <summary>
    /// Sets <see cref="RandomEncountersRoot.MaxExperiencePerUnitDivisor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator SetMaxExperiencePerUnitDivisor(int maxExperiencePerUnitDivisor)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MaxExperiencePerUnitDivisor = maxExperiencePerUnitDivisor;
          });
    }

    /// <summary>
    /// Sets <see cref="RandomEncountersRoot.MinExperiencePerUnitDivisor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator SetMinExperiencePerUnitDivisor(int minExperiencePerUnitDivisor)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MinExperiencePerUnitDivisor = minExperiencePerUnitDivisor;
          });
    }

    /// <summary>
    /// Sets <see cref="RandomEncountersRoot.MaxTargetExperienceDivisor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator SetMaxTargetExperienceDivisor(int maxTargetExperienceDivisor)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MaxTargetExperienceDivisor = maxTargetExperienceDivisor;
          });
    }
  }
}

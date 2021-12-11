using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Configurator for <see cref="BlueprintRegion"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintRegion))]
  public class RegionConfigurator : BaseBlueprintConfigurator<BlueprintRegion, RegionConfigurator>
  {
    private RegionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RegionConfigurator For(string name)
    {
      return new RegionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RegionConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintRegion>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRegion.m_Id"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RegionConfigurator SetId(RegionId id)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Id = id;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRegion.LocalizedName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RegionConfigurator SetLocalizedName(LocalizedString? localizedName)
    {
      ValidateParam(localizedName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LocalizedName = localizedName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRegion.ClaimedDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RegionConfigurator SetClaimedDescription(LocalizedString? claimedDescription)
    {
      ValidateParam(claimedDescription);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ClaimedDescription = claimedDescription ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRegion.m_Adjacent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="adjacent"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintRegion"/></param>
    [Generated]
    public RegionConfigurator SetAdjacent(string[]? adjacent)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Adjacent = adjacent.Select(name => BlueprintTool.GetRef<BlueprintRegionReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintRegion.m_Adjacent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="adjacent"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintRegion"/></param>
    [Generated]
    public RegionConfigurator AddToAdjacent(params string[] adjacent)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Adjacent.AddRange(adjacent.Select(name => BlueprintTool.GetRef<BlueprintRegionReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintRegion.m_Adjacent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="adjacent"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintRegion"/></param>
    [Generated]
    public RegionConfigurator RemoveFromAdjacent(params string[] adjacent)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = adjacent.Select(name => BlueprintTool.GetRef<BlueprintRegionReference>(name));
            bp.m_Adjacent =
                bp.m_Adjacent
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRegion.m_ClaimEvent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="claimEvent"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomClaim"/></param>
    [Generated]
    public RegionConfigurator SetClaimEvent(string? claimEvent)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ClaimEvent = BlueprintTool.GetRef<BlueprintKingdomClaimReference>(claimEvent);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRegion.StatsWhenClaimed"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RegionConfigurator SetStatsWhenClaimed(KingdomStats.Changes statsWhenClaimed)
    {
      ValidateParam(statsWhenClaimed);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.StatsWhenClaimed = statsWhenClaimed;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRegion.UpgradeEvents"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RegionConfigurator SetUpgradeEvents(List<BlueprintRegion.UpgradeVariant>? upgradeEvents)
    {
      ValidateParam(upgradeEvents);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.UpgradeEvents = upgradeEvents;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintRegion.UpgradeEvents"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RegionConfigurator AddToUpgradeEvents(params BlueprintRegion.UpgradeVariant[] upgradeEvents)
    {
      ValidateParam(upgradeEvents);
      return OnConfigureInternal(
          bp =>
          {
            bp.UpgradeEvents.AddRange(upgradeEvents.ToList() ?? new List<BlueprintRegion.UpgradeVariant>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintRegion.UpgradeEvents"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RegionConfigurator RemoveFromUpgradeEvents(params BlueprintRegion.UpgradeVariant[] upgradeEvents)
    {
      ValidateParam(upgradeEvents);
      return OnConfigureInternal(
          bp =>
          {
            bp.UpgradeEvents = bp.UpgradeEvents.Where(item => !upgradeEvents.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRegion.Artisans"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="artisans"><see cref="Kingmaker.Kingdom.Artisans.BlueprintKingdomArtisan"/></param>
    [Generated]
    public RegionConfigurator SetArtisans(string[]? artisans)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Artisans = artisans.Select(name => BlueprintTool.GetRef<BlueprintKingdomArtisanReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintRegion.Artisans"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="artisans"><see cref="Kingmaker.Kingdom.Artisans.BlueprintKingdomArtisan"/></param>
    [Generated]
    public RegionConfigurator AddToArtisans(params string[] artisans)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Artisans.AddRange(artisans.Select(name => BlueprintTool.GetRef<BlueprintKingdomArtisanReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintRegion.Artisans"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="artisans"><see cref="Kingmaker.Kingdom.Artisans.BlueprintKingdomArtisan"/></param>
    [Generated]
    public RegionConfigurator RemoveFromArtisans(params string[] artisans)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = artisans.Select(name => BlueprintTool.GetRef<BlueprintKingdomArtisanReference>(name));
            bp.Artisans =
                bp.Artisans
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRegion.CR"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RegionConfigurator SetCR(int cR)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CR = cR;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRegion.HardEncountersDisabled"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RegionConfigurator SetHardEncountersDisabled(bool hardEncountersDisabled)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HardEncountersDisabled = hardEncountersDisabled;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRegion.OverrideCorruption"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RegionConfigurator SetOverrideCorruption(bool overrideCorruption)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OverrideCorruption = overrideCorruption;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRegion.CorruptionGrowth"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RegionConfigurator SetCorruptionGrowth(int corruptionGrowth)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CorruptionGrowth = corruptionGrowth;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRegion.m_GlobalMap"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="globalMap"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMap"/></param>
    [Generated]
    public RegionConfigurator SetGlobalMap(string? globalMap)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMapReference>(globalMap);
          });
    }
  }
}

using BlueprintCore.Utils;
using Kingmaker.Kingdom;
using Kingmaker.UI.Kingdom;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Configurator for <see cref="KingdomUIRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(KingdomUIRoot))]
  public class KingdomUIRootConfigurator : BaseBlueprintConfigurator<KingdomUIRoot, KingdomUIRootConfigurator>
  {
    private KingdomUIRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomUIRootConfigurator For(string name)
    {
      return new KingdomUIRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomUIRootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<KingdomUIRoot>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.DefaultOpportunityMapMarker"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator SetDefaultOpportunityMapMarker(KingdomUIEventMapMarker defaultOpportunityMapMarker)
    {
      ValidateParam(defaultOpportunityMapMarker);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.DefaultOpportunityMapMarker = defaultOpportunityMapMarker;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.DefaultProblemMapMarker"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator SetDefaultProblemMapMarker(KingdomUIEventMapMarker defaultProblemMapMarker)
    {
      ValidateParam(defaultProblemMapMarker);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.DefaultProblemMapMarker = defaultProblemMapMarker;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.Stats"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator SetStats(List<KingdomUIRoot.KingdomStatElement>? stats)
    {
      ValidateParam(stats);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Stats = stats;
          });
    }

    /// <summary>
    /// Adds to <see cref="KingdomUIRoot.Stats"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator AddToStats(params KingdomUIRoot.KingdomStatElement[] stats)
    {
      ValidateParam(stats);
      return OnConfigureInternal(
          bp =>
          {
            bp.Stats.AddRange(stats.ToList() ?? new List<KingdomUIRoot.KingdomStatElement>());
          });
    }

    /// <summary>
    /// Removes from <see cref="KingdomUIRoot.Stats"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator RemoveFromStats(params KingdomUIRoot.KingdomStatElement[] stats)
    {
      ValidateParam(stats);
      return OnConfigureInternal(
          bp =>
          {
            bp.Stats = bp.Stats.Where(item => !stats.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.Resources"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator SetResources(List<KingdomUIRoot.KingdomResourceElement>? resources)
    {
      ValidateParam(resources);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Resources = resources;
          });
    }

    /// <summary>
    /// Adds to <see cref="KingdomUIRoot.Resources"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator AddToResources(params KingdomUIRoot.KingdomResourceElement[] resources)
    {
      ValidateParam(resources);
      return OnConfigureInternal(
          bp =>
          {
            bp.Resources.AddRange(resources.ToList() ?? new List<KingdomUIRoot.KingdomResourceElement>());
          });
    }

    /// <summary>
    /// Removes from <see cref="KingdomUIRoot.Resources"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator RemoveFromResources(params KingdomUIRoot.KingdomResourceElement[] resources)
    {
      ValidateParam(resources);
      return OnConfigureInternal(
          bp =>
          {
            bp.Resources = bp.Resources.Where(item => !resources.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.RavenTexts"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator SetRavenTexts(KingdomUIRoot.KingdomRavenText ravenTexts)
    {
      ValidateParam(ravenTexts);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.RavenTexts = ravenTexts;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.LeaderDescriptions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator SetLeaderDescriptions(List<KingdomUIRoot.KingdomLeaderDescription>? leaderDescriptions)
    {
      ValidateParam(leaderDescriptions);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LeaderDescriptions = leaderDescriptions;
          });
    }

    /// <summary>
    /// Adds to <see cref="KingdomUIRoot.LeaderDescriptions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator AddToLeaderDescriptions(params KingdomUIRoot.KingdomLeaderDescription[] leaderDescriptions)
    {
      ValidateParam(leaderDescriptions);
      return OnConfigureInternal(
          bp =>
          {
            bp.LeaderDescriptions.AddRange(leaderDescriptions.ToList() ?? new List<KingdomUIRoot.KingdomLeaderDescription>());
          });
    }

    /// <summary>
    /// Removes from <see cref="KingdomUIRoot.LeaderDescriptions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator RemoveFromLeaderDescriptions(params KingdomUIRoot.KingdomLeaderDescription[] leaderDescriptions)
    {
      ValidateParam(leaderDescriptions);
      return OnConfigureInternal(
          bp =>
          {
            bp.LeaderDescriptions = bp.LeaderDescriptions.Where(item => !leaderDescriptions.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.Texts"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator SetTexts(KingdomUIRoot.KingdomUITexts texts)
    {
      ValidateParam(texts);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Texts = texts;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.EventResultMarginDescriptions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator SetEventResultMarginDescriptions(List<KingdomUIRoot.EventResultMarginDescription>? eventResultMarginDescriptions)
    {
      ValidateParam(eventResultMarginDescriptions);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.EventResultMarginDescriptions = eventResultMarginDescriptions;
          });
    }

    /// <summary>
    /// Adds to <see cref="KingdomUIRoot.EventResultMarginDescriptions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator AddToEventResultMarginDescriptions(params KingdomUIRoot.EventResultMarginDescription[] eventResultMarginDescriptions)
    {
      ValidateParam(eventResultMarginDescriptions);
      return OnConfigureInternal(
          bp =>
          {
            bp.EventResultMarginDescriptions.AddRange(eventResultMarginDescriptions.ToList() ?? new List<KingdomUIRoot.EventResultMarginDescription>());
          });
    }

    /// <summary>
    /// Removes from <see cref="KingdomUIRoot.EventResultMarginDescriptions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator RemoveFromEventResultMarginDescriptions(params KingdomUIRoot.EventResultMarginDescription[] eventResultMarginDescriptions)
    {
      ValidateParam(eventResultMarginDescriptions);
      return OnConfigureInternal(
          bp =>
          {
            bp.EventResultMarginDescriptions = bp.EventResultMarginDescriptions.Where(item => !eventResultMarginDescriptions.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.Settlement"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator Settlement(KingdomUIRoot.SettlementRoot settlement)
    {
      ValidateParam(settlement);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Settlement = settlement;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.Tooltip"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator SetTooltip(KingdomUIRoot.KingdomUITooltip tooltip)
    {
      ValidateParam(tooltip);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Tooltip = tooltip;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.Motto"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator SetMotto(KingdomUIRoot.KingdomMotto motto)
    {
      ValidateParam(motto);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Motto = motto;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.KingdomStatusChangeReasons"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator SetKingdomStatusChangeReasons(List<KingdomUIRoot.KingdomStatusChangeReasonEntity>? kingdomStatusChangeReasons)
    {
      ValidateParam(kingdomStatusChangeReasons);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.KingdomStatusChangeReasons = kingdomStatusChangeReasons;
          });
    }

    /// <summary>
    /// Adds to <see cref="KingdomUIRoot.KingdomStatusChangeReasons"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator AddToKingdomStatusChangeReasons(params KingdomUIRoot.KingdomStatusChangeReasonEntity[] kingdomStatusChangeReasons)
    {
      ValidateParam(kingdomStatusChangeReasons);
      return OnConfigureInternal(
          bp =>
          {
            bp.KingdomStatusChangeReasons.AddRange(kingdomStatusChangeReasons.ToList() ?? new List<KingdomUIRoot.KingdomStatusChangeReasonEntity>());
          });
    }

    /// <summary>
    /// Removes from <see cref="KingdomUIRoot.KingdomStatusChangeReasons"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator RemoveFromKingdomStatusChangeReasons(params KingdomUIRoot.KingdomStatusChangeReasonEntity[] kingdomStatusChangeReasons)
    {
      ValidateParam(kingdomStatusChangeReasons);
      return OnConfigureInternal(
          bp =>
          {
            bp.KingdomStatusChangeReasons = bp.KingdomStatusChangeReasons.Where(item => !kingdomStatusChangeReasons.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.KingdomHistoryEntitisCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator SetKingdomHistoryEntitisCount(int kingdomHistoryEntitisCount)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.KingdomHistoryEntitisCount = kingdomHistoryEntitisCount;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.ExResourceStateTypeStrings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator SetExResourceStateTypeStrings(KingdomUIRoot.ResourceStateTypeStrings exResourceStateTypeStrings)
    {
      ValidateParam(exResourceStateTypeStrings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ExResourceStateTypeStrings = exResourceStateTypeStrings;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomUIRoot.KingdomStautsDesriptions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator SetKingdomStautsDesriptions(List<KingdomUIRoot.KingdomStatusDescription>? kingdomStautsDesriptions)
    {
      ValidateParam(kingdomStautsDesriptions);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.KingdomStautsDesriptions = kingdomStautsDesriptions;
          });
    }

    /// <summary>
    /// Adds to <see cref="KingdomUIRoot.KingdomStautsDesriptions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator AddToKingdomStautsDesriptions(params KingdomUIRoot.KingdomStatusDescription[] kingdomStautsDesriptions)
    {
      ValidateParam(kingdomStautsDesriptions);
      return OnConfigureInternal(
          bp =>
          {
            bp.KingdomStautsDesriptions.AddRange(kingdomStautsDesriptions.ToList() ?? new List<KingdomUIRoot.KingdomStatusDescription>());
          });
    }

    /// <summary>
    /// Removes from <see cref="KingdomUIRoot.KingdomStautsDesriptions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomUIRootConfigurator RemoveFromKingdomStautsDesriptions(params KingdomUIRoot.KingdomStatusDescription[] kingdomStautsDesriptions)
    {
      ValidateParam(kingdomStautsDesriptions);
      return OnConfigureInternal(
          bp =>
          {
            bp.KingdomStautsDesriptions = bp.KingdomStautsDesriptions.Where(item => !kingdomStautsDesriptions.Contains(item)).ToList();
          });
    }
  }
}

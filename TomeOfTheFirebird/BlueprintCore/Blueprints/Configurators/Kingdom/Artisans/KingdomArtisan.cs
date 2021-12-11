using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Artisans;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Kingdom.Artisans
{
  /// <summary>
  /// Configurator for <see cref="BlueprintKingdomArtisan"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomArtisan))]
  public class KingdomArtisanConfigurator : BaseBlueprintConfigurator<BlueprintKingdomArtisan, KingdomArtisanConfigurator>
  {
    private KingdomArtisanConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomArtisanConfigurator For(string name)
    {
      return new KingdomArtisanConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomArtisanConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintKingdomArtisan>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomArtisan.m_ShopBlueprint"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="shopBlueprint"><see cref="Kingmaker.Kingdom.Settlements.BlueprintSettlementBuilding"/></param>
    [Generated]
    public KingdomArtisanConfigurator SetShopBlueprint(string? shopBlueprint)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ShopBlueprint = BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(shopBlueprint);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomArtisan.ItemDecks"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="itemDecks"><see cref="Kingmaker.Kingdom.Artisans.ArtisanItemDeck"/></param>
    [Generated]
    public KingdomArtisanConfigurator SetItemDecks(string[]? itemDecks)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ItemDecks = itemDecks.Select(name => BlueprintTool.GetRef<ArtisanItemDeckReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintKingdomArtisan.ItemDecks"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="itemDecks"><see cref="Kingmaker.Kingdom.Artisans.ArtisanItemDeck"/></param>
    [Generated]
    public KingdomArtisanConfigurator AddToItemDecks(params string[] itemDecks)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ItemDecks.AddRange(itemDecks.Select(name => BlueprintTool.GetRef<ArtisanItemDeckReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintKingdomArtisan.ItemDecks"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="itemDecks"><see cref="Kingmaker.Kingdom.Artisans.ArtisanItemDeck"/></param>
    [Generated]
    public KingdomArtisanConfigurator RemoveFromItemDecks(params string[] itemDecks)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = itemDecks.Select(name => BlueprintTool.GetRef<ArtisanItemDeckReference>(name));
            bp.ItemDecks =
                bp.ItemDecks
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomArtisan.Tiers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomArtisanConfigurator SetTiers(BlueprintKingdomArtisan.TierData[]? tiers)
    {
      ValidateParam(tiers);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Tiers = tiers;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintKingdomArtisan.Tiers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomArtisanConfigurator AddToTiers(params BlueprintKingdomArtisan.TierData[] tiers)
    {
      ValidateParam(tiers);
      return OnConfigureInternal(
          bp =>
          {
            bp.Tiers = CommonTool.Append(bp.Tiers, tiers ?? new BlueprintKingdomArtisan.TierData[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintKingdomArtisan.Tiers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomArtisanConfigurator RemoveFromTiers(params BlueprintKingdomArtisan.TierData[] tiers)
    {
      ValidateParam(tiers);
      return OnConfigureInternal(
          bp =>
          {
            bp.Tiers = bp.Tiers.Where(item => !tiers.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomArtisan.m_Masterpiece"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="masterpiece"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public KingdomArtisanConfigurator SetMasterpiece(string? masterpiece)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Masterpiece = BlueprintTool.GetRef<BlueprintItemReference>(masterpiece);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomArtisan.MasterpieceUnlock"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomArtisanConfigurator SetMasterpieceUnlock(ConditionsBuilder? masterpieceUnlock)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MasterpieceUnlock = masterpieceUnlock?.Build() ?? Constants.Empty.Conditions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomArtisan.m_HelpProject"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="helpProject"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomProject"/></param>
    [Generated]
    public KingdomArtisanConfigurator SetHelpProject(string? helpProject)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_HelpProject = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(helpProject);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomArtisan.OnProductionStarted"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomArtisanConfigurator SetOnProductionStarted(ActionsBuilder? onProductionStarted)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OnProductionStarted = onProductionStarted?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomArtisan.OnGiftReady"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomArtisanConfigurator SetOnGiftReady(ActionsBuilder? onGiftReady)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OnGiftReady = onGiftReady?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomArtisan.OnGiftCollected"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomArtisanConfigurator SetOnGiftCollected(ActionsBuilder? onGiftCollected)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OnGiftCollected = onGiftCollected?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomArtisan.CanCollectGift"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomArtisanConfigurator SetCanCollectGift(ConditionsBuilder? canCollectGift)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CanCollectGift = canCollectGift?.Build() ?? Constants.Empty.Conditions;
          });
    }
  }
}

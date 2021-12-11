using BlueprintCore.Utils;
using Kingmaker.Kingdom.Artisans;
using Kingmaker.Localization;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Kingdom.Artisans
{
  /// <summary>
  /// Configurator for <see cref="ArtisanItemDeck"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(ArtisanItemDeck))]
  public class ArtisanItemDeckConfigurator : BaseBlueprintConfigurator<ArtisanItemDeck, ArtisanItemDeckConfigurator>
  {
    private ArtisanItemDeckConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArtisanItemDeckConfigurator For(string name)
    {
      return new ArtisanItemDeckConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArtisanItemDeckConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<ArtisanItemDeck>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="ArtisanItemDeck.TypeName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArtisanItemDeckConfigurator SetTypeName(LocalizedString? typeName)
    {
      ValidateParam(typeName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.TypeName = typeName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="ArtisanItemDeck.Tiers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArtisanItemDeckConfigurator SetTiers(ArtisanItemDeck.TierData[]? tiers)
    {
      ValidateParam(tiers);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Tiers = tiers;
          });
    }

    /// <summary>
    /// Adds to <see cref="ArtisanItemDeck.Tiers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArtisanItemDeckConfigurator AddToTiers(params ArtisanItemDeck.TierData[] tiers)
    {
      ValidateParam(tiers);
      return OnConfigureInternal(
          bp =>
          {
            bp.Tiers = CommonTool.Append(bp.Tiers, tiers ?? new ArtisanItemDeck.TierData[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="ArtisanItemDeck.Tiers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArtisanItemDeckConfigurator RemoveFromTiers(params ArtisanItemDeck.TierData[] tiers)
    {
      ValidateParam(tiers);
      return OnConfigureInternal(
          bp =>
          {
            bp.Tiers = bp.Tiers.Where(item => !tiers.Contains(item)).ToArray();
          });
    }
  }
}

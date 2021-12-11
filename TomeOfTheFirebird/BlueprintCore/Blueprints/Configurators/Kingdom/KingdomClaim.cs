using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Configurator for <see cref="BlueprintKingdomClaim"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomClaim))]
  public class KingdomClaimConfigurator : BaseKingdomProjectConfigurator<BlueprintKingdomClaim, KingdomClaimConfigurator>
  {
    private KingdomClaimConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomClaimConfigurator For(string name)
    {
      return new KingdomClaimConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomClaimConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintKingdomClaim>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomClaim.KnownCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomClaimConfigurator SetKnownCondition(ConditionsBuilder? knownCondition)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.KnownCondition = knownCondition?.Build() ?? Constants.Empty.Conditions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomClaim.FailCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomClaimConfigurator SetFailCondition(ConditionsBuilder? failCondition)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FailCondition = failCondition?.Build() ?? Constants.Empty.Conditions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomClaim.UnknownDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomClaimConfigurator SetUnknownDescription(LocalizedString? unknownDescription)
    {
      ValidateParam(unknownDescription);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.UnknownDescription = unknownDescription ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomClaim.KnownDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomClaimConfigurator SetKnownDescription(LocalizedString? knownDescription)
    {
      ValidateParam(knownDescription);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.KnownDescription = knownDescription ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomClaim.FailedDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomClaimConfigurator SetFailedDescription(LocalizedString? failedDescription)
    {
      ValidateParam(failedDescription);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.FailedDescription = failedDescription ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomClaim.FulfilledDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomClaimConfigurator SetFulfilledDescription(LocalizedString? fulfilledDescription)
    {
      ValidateParam(fulfilledDescription);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.FulfilledDescription = fulfilledDescription ?? Constants.Empty.String;
          });
    }
  }
}

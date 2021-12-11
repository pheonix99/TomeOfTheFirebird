using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Kingdom.Flags;
using Kingmaker.Localization;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Kingdom.Flags
{
  /// <summary>
  /// Configurator for <see cref="BlueprintKingdomMoraleFlag"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomMoraleFlag))]
  public class KingdomMoraleFlagConfigurator : BaseFactConfigurator<BlueprintKingdomMoraleFlag, KingdomMoraleFlagConfigurator>
  {
    private KingdomMoraleFlagConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomMoraleFlagConfigurator For(string name)
    {
      return new KingdomMoraleFlagConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomMoraleFlagConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintKingdomMoraleFlag>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomMoraleFlag.m_DisplayName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomMoraleFlagConfigurator SetDisplayName(LocalizedString? displayName)
    {
      ValidateParam(displayName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DisplayName = displayName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomMoraleFlag.m_Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomMoraleFlagConfigurator SetDescription(LocalizedString? description)
    {
      ValidateParam(description);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Description = description ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomMoraleFlag.m_NeutralDuration"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomMoraleFlagConfigurator SetNeutralDuration(int neutralDuration)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_NeutralDuration = neutralDuration;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomMoraleFlag.m_NegativeWarningDuration"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomMoraleFlagConfigurator SetNegativeWarningDuration(int negativeWarningDuration)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_NegativeWarningDuration = negativeWarningDuration;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomMoraleFlag.m_PerDayBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomMoraleFlagConfigurator SetPerDayBonus(int perDayBonus)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_PerDayBonus = perDayBonus;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomMoraleFlag.m_PerDayPenalty"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomMoraleFlagConfigurator SetPerDayPenalty(int perDayPenalty)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_PerDayPenalty = perDayPenalty;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomMoraleFlag.m_FlagType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomMoraleFlagConfigurator SetFlagType(BlueprintKingdomMoraleFlag.FlagType flagType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_FlagType = flagType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomMoraleFlag.m_CounterDecrementPerDay"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomMoraleFlagConfigurator SetCounterDecrementPerDay(int counterDecrementPerDay)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CounterDecrementPerDay = counterDecrementPerDay;
          });
    }
  }
}

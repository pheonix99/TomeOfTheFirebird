using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.RuleSystem;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Configurator for <see cref="ArmyRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(ArmyRoot))]
  public class ArmyRootConfigurator : BaseBlueprintConfigurator<ArmyRoot, ArmyRootConfigurator>
  {
    private ArmyRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArmyRootConfigurator For(string name)
    {
      return new ArmyRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArmyRootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<ArmyRoot>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_TravelingArmiesByChapter"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetTravelingArmiesByChapter(ArmyRoot.ChapterSpawnInfo[]? travelingArmiesByChapter)
    {
      ValidateParam(travelingArmiesByChapter);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TravelingArmiesByChapter = travelingArmiesByChapter;
          });
    }

    /// <summary>
    /// Adds to <see cref="ArmyRoot.m_TravelingArmiesByChapter"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator AddToTravelingArmiesByChapter(params ArmyRoot.ChapterSpawnInfo[] travelingArmiesByChapter)
    {
      ValidateParam(travelingArmiesByChapter);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TravelingArmiesByChapter = CommonTool.Append(bp.m_TravelingArmiesByChapter, travelingArmiesByChapter ?? new ArmyRoot.ChapterSpawnInfo[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="ArmyRoot.m_TravelingArmiesByChapter"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator RemoveFromTravelingArmiesByChapter(params ArmyRoot.ChapterSpawnInfo[] travelingArmiesByChapter)
    {
      ValidateParam(travelingArmiesByChapter);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TravelingArmiesByChapter = bp.m_TravelingArmiesByChapter.Where(item => !travelingArmiesByChapter.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_MaxTravelingArmiesOnMap"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetMaxTravelingArmiesOnMap(int maxTravelingArmiesOnMap)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MaxTravelingArmiesOnMap = maxTravelingArmiesOnMap;
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.ResourceIcon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetResourceIcon(ArmyRoot.ResourceIcons resourceIcon)
    {
      ValidateParam(resourceIcon);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ResourceIcon = resourceIcon;
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_NobilitySettlementsProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="nobilitySettlementsProgression"><see cref="Kingmaker.Blueprints.Classes.BlueprintStatProgression"/></param>
    [Generated]
    public ArmyRootConfigurator SetNobilitySettlementsProgression(string? nobilitySettlementsProgression)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_NobilitySettlementsProgression = BlueprintTool.GetRef<BlueprintStatProgressionReference>(nobilitySettlementsProgression);
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_NobilityBuildingsProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="nobilityBuildingsProgression"><see cref="Kingmaker.Blueprints.Classes.BlueprintStatProgression"/></param>
    [Generated]
    public ArmyRootConfigurator SetNobilityBuildingsProgression(string? nobilityBuildingsProgression)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_NobilityBuildingsProgression = BlueprintTool.GetRef<BlueprintStatProgressionReference>(nobilityBuildingsProgression);
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_NobilityIncomeProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="nobilityIncomeProgression"><see cref="Kingmaker.Blueprints.Classes.BlueprintStatProgression"/></param>
    [Generated]
    public ArmyRootConfigurator SetNobilityIncomeProgression(string? nobilityIncomeProgression)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_NobilityIncomeProgression = BlueprintTool.GetRef<BlueprintStatProgressionReference>(nobilityIncomeProgression);
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_NobilityArmyStrengthProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="nobilityArmyStrengthProgression"><see cref="Kingmaker.Blueprints.Classes.BlueprintStatProgression"/></param>
    [Generated]
    public ArmyRootConfigurator SetNobilityArmyStrengthProgression(string? nobilityArmyStrengthProgression)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_NobilityArmyStrengthProgression = BlueprintTool.GetRef<BlueprintStatProgressionReference>(nobilityArmyStrengthProgression);
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_RoyalCourtLeadersProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="royalCourtLeadersProgression"><see cref="Kingmaker.Blueprints.Classes.BlueprintStatProgression"/></param>
    [Generated]
    public ArmyRootConfigurator SetRoyalCourtLeadersProgression(string? royalCourtLeadersProgression)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_RoyalCourtLeadersProgression = BlueprintTool.GetRef<BlueprintStatProgressionReference>(royalCourtLeadersProgression);
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_RoyalCourtRanksProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="royalCourtRanksProgression"><see cref="Kingmaker.Blueprints.Classes.BlueprintStatProgression"/></param>
    [Generated]
    public ArmyRootConfigurator SetRoyalCourtRanksProgression(string? royalCourtRanksProgression)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_RoyalCourtRanksProgression = BlueprintTool.GetRef<BlueprintStatProgressionReference>(royalCourtRanksProgression);
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_RoyalCourtMissionProgressionChapter2"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="royalCourtMissionProgressionChapter2"><see cref="Kingmaker.Blueprints.Classes.BlueprintStatProgression"/></param>
    [Generated]
    public ArmyRootConfigurator SetRoyalCourtMissionProgressionChapter2(string? royalCourtMissionProgressionChapter2)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_RoyalCourtMissionProgressionChapter2 = BlueprintTool.GetRef<BlueprintStatProgressionReference>(royalCourtMissionProgressionChapter2);
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_RoyalCourtMissionProgressionChapter3"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="royalCourtMissionProgressionChapter3"><see cref="Kingmaker.Blueprints.Classes.BlueprintStatProgression"/></param>
    [Generated]
    public ArmyRootConfigurator SetRoyalCourtMissionProgressionChapter3(string? royalCourtMissionProgressionChapter3)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_RoyalCourtMissionProgressionChapter3 = BlueprintTool.GetRef<BlueprintStatProgressionReference>(royalCourtMissionProgressionChapter3);
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_NobilityPresetReward"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="nobilityPresetReward"><see cref="Kingmaker.Armies.Blueprints.BlueprintArmyPreset"/></param>
    [Generated]
    public ArmyRootConfigurator SetNobilityPresetReward(string? nobilityPresetReward)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_NobilityPresetReward = BlueprintTool.GetRef<BlueprintArmyPresetReference>(nobilityPresetReward);
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_SummonArmiesMap"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="summonArmiesMap"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMap"/></param>
    [Generated]
    public ArmyRootConfigurator SetSummonArmiesMap(string? summonArmiesMap)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SummonArmiesMap = BlueprintTool.GetRef<BlueprintGlobalMapReference>(summonArmiesMap);
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_MercenaryFreeRerollsStart"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetMercenaryFreeRerollsStart(int mercenaryFreeRerollsStart)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MercenaryFreeRerollsStart = mercenaryFreeRerollsStart;
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_MercenaryStartSlots"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetMercenaryStartSlots(int mercenaryStartSlots)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MercenaryStartSlots = mercenaryStartSlots;
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_RerollStartPrice"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetRerollStartPrice(KingdomResourcesAmount rerollStartPrice)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_RerollStartPrice = rerollStartPrice;
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_MercenaryDefaultCountFormula"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetMercenaryDefaultCountFormula(DiceFormula mercenaryDefaultCountFormula)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MercenaryDefaultCountFormula = mercenaryDefaultCountFormula;
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_MercenaryDefaultCountBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetMercenaryDefaultCountBonus(int mercenaryDefaultCountBonus)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MercenaryDefaultCountBonus = mercenaryDefaultCountBonus;
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_MercenaryDefaultCountDivider"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetMercenaryDefaultCountDivider(float mercenaryDefaultCountDivider)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MercenaryDefaultCountDivider = mercenaryDefaultCountDivider;
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_OverpricedMercenaryCountMultiplier"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetOverpricedMercenaryCountMultiplier(float overpricedMercenaryCountMultiplier)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_OverpricedMercenaryCountMultiplier = overpricedMercenaryCountMultiplier;
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_OverpricedMercenaryPriceMultiplier"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetOverpricedMercenaryPriceMultiplier(float overpricedMercenaryPriceMultiplier)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_OverpricedMercenaryPriceMultiplier = overpricedMercenaryPriceMultiplier;
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_MercenaryPriceMoraleModifierCoefficient"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetMercenaryPriceMoraleModifierCoefficient(float mercenaryPriceMoraleModifierCoefficient)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MercenaryPriceMoraleModifierCoefficient = mercenaryPriceMoraleModifierCoefficient;
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_MercenaryFormulaMoraleCap"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetMercenaryFormulaMoraleCap(int mercenaryFormulaMoraleCap)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MercenaryFormulaMoraleCap = mercenaryFormulaMoraleCap;
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_ExperienceFinancesCoef"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetExperienceFinancesCoef(float experienceFinancesCoef)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ExperienceFinancesCoef = experienceFinancesCoef;
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_ExperienceMaterialsCoef"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetExperienceMaterialsCoef(float experienceMaterialsCoef)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ExperienceMaterialsCoef = experienceMaterialsCoef;
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_ExperienceFavorsCoef"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetExperienceFavorsCoef(float experienceFavorsCoef)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ExperienceFavorsCoef = experienceFavorsCoef;
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_ArmyDangerBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetArmyDangerBonus(int armyDangerBonus)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ArmyDangerBonus = armyDangerBonus;
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_ArmyDangerMultiplier"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetArmyDangerMultiplier(float armyDangerMultiplier)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ArmyDangerMultiplier = armyDangerMultiplier;
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_ArmyStrings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetArmyStrings(ArmyStrings armyStrings)
    {
      ValidateParam(armyStrings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ArmyStrings = armyStrings;
          });
    }
  }
}

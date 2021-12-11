using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Blueprints;
using Kingmaker.Armies.TacticalCombat.Brain;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Owlcat.Runtime.Core.Math;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>
  /// Configurator for <see cref="BlueprintTacticalCombatRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTacticalCombatRoot))]
  public class TacticalCombatRootConfigurator : BaseBlueprintConfigurator<BlueprintTacticalCombatRoot, TacticalCombatRootConfigurator>
  {
    private TacticalCombatRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TacticalCombatRootConfigurator For(string name)
    {
      return new TacticalCombatRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TacticalCombatRootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintTacticalCombatRoot>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_ProbabilitySampler"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetProbabilitySampler(ProbabilityCurveSampler probabilitySampler)
    {
      ValidateParam(probabilitySampler);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ProbabilitySampler = probabilitySampler;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_CrusadersFaction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="crusadersFaction"><see cref="Kingmaker.Blueprints.BlueprintFaction"/></param>
    [Generated]
    public TacticalCombatRootConfigurator SetCrusadersFaction(string? crusadersFaction)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CrusadersFaction = BlueprintTool.GetRef<BlueprintFactionReference>(crusadersFaction);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_DemonsFaction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="demonsFaction"><see cref="Kingmaker.Blueprints.BlueprintFaction"/></param>
    [Generated]
    public TacticalCombatRootConfigurator SetDemonsFaction(string? demonsFaction)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DemonsFaction = BlueprintTool.GetRef<BlueprintFactionReference>(demonsFaction);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_DefaultBrain"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="defaultBrain"><see cref="Kingmaker.Armies.TacticalCombat.Brain.BlueprintTacticalCombatBrain"/></param>
    [Generated]
    public TacticalCombatRootConfigurator SetDefaultBrain(string? defaultBrain)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DefaultBrain = BlueprintTool.GetRef<BlueprintTacticalCombatBrain.Reference>(defaultBrain);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_DefaultLeaderBrain"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="defaultLeaderBrain"><see cref="Kingmaker.Armies.TacticalCombat.Brain.BlueprintTacticalCombatBrain"/></param>
    [Generated]
    public TacticalCombatRootConfigurator SetDefaultLeaderBrain(string? defaultLeaderBrain)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DefaultLeaderBrain = BlueprintTool.GetRef<BlueprintTacticalCombatBrain.Reference>(defaultLeaderBrain);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_AiSpellCastWeight"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetAiSpellCastWeight(float aiSpellCastWeight)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AiSpellCastWeight = aiSpellCastWeight;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_AiCanUseRituals"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetAiCanUseRituals(bool aiCanUseRituals)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AiCanUseRituals = aiCanUseRituals;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_DelayBetweenTurns"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetDelayBetweenTurns(float delayBetweenTurns)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DelayBetweenTurns = delayBetweenTurns;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_DelayAfterMoraleEffect"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetDelayAfterMoraleEffect(float delayAfterMoraleEffect)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DelayAfterMoraleEffect = delayAfterMoraleEffect;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_DelayBeforeBattleEnd"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetDelayBeforeBattleEnd(float delayBeforeBattleEnd)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DelayBeforeBattleEnd = delayBeforeBattleEnd;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_MaxTurnDuration"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetMaxTurnDuration(float maxTurnDuration)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MaxTurnDuration = maxTurnDuration;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_MoveSpeed"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetMoveSpeed(int moveSpeed)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MoveSpeed = moveSpeed;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_MaxSquadsCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetMaxSquadsCount(int maxSquadsCount)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MaxSquadsCount = maxSquadsCount;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_BuffPrefix"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetBuffPrefix(LocalizedString? buffPrefix)
    {
      ValidateParam(buffPrefix);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_BuffPrefix = buffPrefix ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_ArmyLossesCoefOnRetreat"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetArmyLossesCoefOnRetreat(float armyLossesCoefOnRetreat)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ArmyLossesCoefOnRetreat = armyLossesCoefOnRetreat;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_AutoVictoryChanceCoefficient"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetAutoVictoryChanceCoefficient(float autoVictoryChanceCoefficient)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AutoVictoryChanceCoefficient = autoVictoryChanceCoefficient;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_AutoVictoryChanceMinimum"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetAutoVictoryChanceMinimum(float autoVictoryChanceMinimum)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AutoVictoryChanceMinimum = autoVictoryChanceMinimum;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_AutoCombatLossesCoefficient"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetAutoCombatLossesCoefficient(float autoCombatLossesCoefficient)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AutoCombatLossesCoefficient = autoCombatLossesCoefficient;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_AutoCombatMinimumLossesCoefficient"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetAutoCombatMinimumLossesCoefficient(float autoCombatMinimumLossesCoefficient)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AutoCombatMinimumLossesCoefficient = autoCombatMinimumLossesCoefficient;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_DiceRollResultsDistribution"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetDiceRollResultsDistribution(AnimationCurve diceRollResultsDistribution)
    {
      ValidateParam(diceRollResultsDistribution);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DiceRollResultsDistribution = diceRollResultsDistribution;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_BannedUnitFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="bannedUnitFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    public TacticalCombatRootConfigurator SetBannedUnitFacts(string[]? bannedUnitFacts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_BannedUnitFacts = bannedUnitFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintTacticalCombatRoot.m_BannedUnitFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="bannedUnitFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    public TacticalCombatRootConfigurator AddToBannedUnitFacts(params string[] bannedUnitFacts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_BannedUnitFacts.AddRange(bannedUnitFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintTacticalCombatRoot.m_BannedUnitFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="bannedUnitFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    public TacticalCombatRootConfigurator RemoveFromBannedUnitFacts(params string[] bannedUnitFacts)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = bannedUnitFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name));
            bp.m_BannedUnitFacts =
                bp.m_BannedUnitFacts
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_DefaultZone"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetDefaultZone(TacticalCombatAreaZone defaultZone)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DefaultZone = defaultZone;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_ZoneSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetZoneSettings(List<BlueprintTacticalCombatRoot.TacticalZoneSettings>? zoneSettings)
    {
      ValidateParam(zoneSettings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ZoneSettings = zoneSettings;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintTacticalCombatRoot.m_ZoneSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator AddToZoneSettings(params BlueprintTacticalCombatRoot.TacticalZoneSettings[] zoneSettings)
    {
      ValidateParam(zoneSettings);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ZoneSettings.AddRange(zoneSettings.ToList() ?? new List<BlueprintTacticalCombatRoot.TacticalZoneSettings>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintTacticalCombatRoot.m_ZoneSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator RemoveFromZoneSettings(params BlueprintTacticalCombatRoot.TacticalZoneSettings[] zoneSettings)
    {
      ValidateParam(zoneSettings);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ZoneSettings = bp.m_ZoneSettings.Where(item => !zoneSettings.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_LeaderManaResource"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="leaderManaResource"><see cref="Kingmaker.Blueprints.BlueprintAbilityResource"/></param>
    [Generated]
    public TacticalCombatRootConfigurator SetLeaderManaResource(string? leaderManaResource)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_LeaderManaResource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(leaderManaResource);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_WinnerCutscene"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="winnerCutscene"><see cref="Kingmaker.AreaLogic.Cutscenes.Cutscene"/></param>
    [Generated]
    public TacticalCombatRootConfigurator SetWinnerCutscene(string? winnerCutscene)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_WinnerCutscene = BlueprintTool.GetRef<CutsceneReference>(winnerCutscene);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_PositiveMoraleFx"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetPositiveMoraleFx(PrefabLink? positiveMoraleFx)
    {
      ValidateParam(positiveMoraleFx);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_PositiveMoraleFx = positiveMoraleFx ?? Constants.Empty.PrefabLink;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatRoot.m_NegativeMoraleFx"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatRootConfigurator SetNegativeMoraleFx(PrefabLink? negativeMoraleFx)
    {
      ValidateParam(negativeMoraleFx);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_NegativeMoraleFx = negativeMoraleFx ?? Constants.Empty.PrefabLink;
          });
    }
  }
}

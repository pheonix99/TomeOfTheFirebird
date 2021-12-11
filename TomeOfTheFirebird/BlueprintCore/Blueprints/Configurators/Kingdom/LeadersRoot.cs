using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Configurator for <see cref="LeadersRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(LeadersRoot))]
  public class LeadersRootConfigurator : BaseBlueprintConfigurator<LeadersRoot, LeadersRootConfigurator>
  {
    private LeadersRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static LeadersRootConfigurator For(string name)
    {
      return new LeadersRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static LeadersRootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<LeadersRoot>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.m_ExpTable"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="expTable"><see cref="Kingmaker.Blueprints.Classes.BlueprintStatProgression"/></param>
    [Generated]
    public LeadersRootConfigurator SetExpTable(string? expTable)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ExpTable = BlueprintTool.GetRef<BlueprintStatProgressionReference>(expTable);
          });
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.m_Leaders"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="leaders"><see cref="Kingmaker.Armies.BlueprintArmyLeader"/></param>
    [Generated]
    public LeadersRootConfigurator SetLeaders(string[]? leaders)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Leaders = leaders.Select(name => BlueprintTool.GetRef<BlueprintArmyLeaderReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="LeadersRoot.m_Leaders"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="leaders"><see cref="Kingmaker.Armies.BlueprintArmyLeader"/></param>
    [Generated]
    public LeadersRootConfigurator AddToLeaders(params string[] leaders)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Leaders = CommonTool.Append(bp.m_Leaders, leaders.Select(name => BlueprintTool.GetRef<BlueprintArmyLeaderReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="LeadersRoot.m_Leaders"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="leaders"><see cref="Kingmaker.Armies.BlueprintArmyLeader"/></param>
    [Generated]
    public LeadersRootConfigurator RemoveFromLeaders(params string[] leaders)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = leaders.Select(name => BlueprintTool.GetRef<BlueprintArmyLeaderReference>(name));
            bp.m_Leaders =
                bp.m_Leaders
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.m_AttackLeaderFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="attackLeaderFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    public LeadersRootConfigurator SetAttackLeaderFeature(string? attackLeaderFeature)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AttackLeaderFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(attackLeaderFeature);
          });
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.m_DeffenceLeaderFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="deffenceLeaderFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    public LeadersRootConfigurator SetDeffenceLeaderFeature(string? deffenceLeaderFeature)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DeffenceLeaderFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(deffenceLeaderFeature);
          });
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.m_BaseManaRegen"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeadersRootConfigurator SetBaseManaRegen(int baseManaRegen)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_BaseManaRegen = baseManaRegen;
          });
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.FirstLeadCost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeadersRootConfigurator SetFirstLeadCost(int firstLeadCost)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FirstLeadCost = firstLeadCost;
          });
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.ReducedLeadCost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeadersRootConfigurator SetReducedLeadCost(int reducedLeadCost)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ReducedLeadCost = reducedLeadCost;
          });
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.LeadCostMultiply"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeadersRootConfigurator SetLeadCostMultiply(float leadCostMultiply)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.LeadCostMultiply = leadCostMultiply;
          });
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.m_ArmyLeaderAssignmentCooldownDays"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeadersRootConfigurator SetArmyLeaderAssignmentCooldownDays(int armyLeaderAssignmentCooldownDays)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ArmyLeaderAssignmentCooldownDays = armyLeaderAssignmentCooldownDays;
          });
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.m_CheaperLeadersProject"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cheaperLeadersProject"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomProject"/></param>
    [Generated]
    public LeadersRootConfigurator SetCheaperLeadersProject(string? cheaperLeadersProject)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CheaperLeadersProject = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(cheaperLeadersProject);
          });
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.m_TalentedLeadersProject"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="talentedLeadersProject"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomProject"/></param>
    [Generated]
    public LeadersRootConfigurator SetTalentedLeadersProject(string? talentedLeadersProject)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TalentedLeadersProject = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(talentedLeadersProject);
          });
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.m_ExperiencedLeadersProject"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="experiencedLeadersProject"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomProject"/></param>
    [Generated]
    public LeadersRootConfigurator SetExperiencedLeadersProject(string? experiencedLeadersProject)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ExperiencedLeadersProject = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(experiencedLeadersProject);
          });
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.m_ExcellentLeadersProject"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="excellentLeadersProject"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomProject"/></param>
    [Generated]
    public LeadersRootConfigurator SetExcellentLeadersProject(string? excellentLeadersProject)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ExcellentLeadersProject = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(excellentLeadersProject);
          });
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.SkillsListName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeadersRootConfigurator SetSkillsListName(LocalizedString? skillsListName)
    {
      ValidateParam(skillsListName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.SkillsListName = skillsListName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.ManaName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeadersRootConfigurator SetManaName(LocalizedString? manaName)
    {
      ValidateParam(manaName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ManaName = manaName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.AttackBonusName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeadersRootConfigurator SetAttackBonusName(LocalizedString? attackBonusName)
    {
      ValidateParam(attackBonusName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.AttackBonusName = attackBonusName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.DeffBonusName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeadersRootConfigurator SetDeffBonusName(LocalizedString? deffBonusName)
    {
      ValidateParam(deffBonusName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.DeffBonusName = deffBonusName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.SpellStrengthName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeadersRootConfigurator SetSpellStrengthName(LocalizedString? spellStrengthName)
    {
      ValidateParam(spellStrengthName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.SpellStrengthName = spellStrengthName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="LeadersRoot.LeaderHireText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeadersRootConfigurator SetLeaderHireText(LocalizedString? leaderHireText)
    {
      ValidateParam(leaderHireText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LeaderHireText = leaderHireText ?? Constants.Empty.String;
          });
    }
  }
}

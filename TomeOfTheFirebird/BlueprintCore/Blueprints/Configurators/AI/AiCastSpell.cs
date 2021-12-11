using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="BlueprintAiCastSpell"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAiCastSpell))]
  public class AiCastSpellConfigurator : BaseAiActionConfigurator<BlueprintAiCastSpell, AiCastSpellConfigurator>
  {
    private AiCastSpellConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AiCastSpellConfigurator For(string name)
    {
      return new AiCastSpellConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AiCastSpellConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintAiCastSpell>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.m_MinCasterSqrDistanceToLocator"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetMinCasterSqrDistanceToLocator(float minCasterSqrDistanceToLocator)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MinCasterSqrDistanceToLocator = minCasterSqrDistanceToLocator;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.m_MinPartySqrDistanceToLocator"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetMinPartySqrDistanceToLocator(float minPartySqrDistanceToLocator)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MinPartySqrDistanceToLocator = minPartySqrDistanceToLocator;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.m_MaxPartySqrDistanceToLocator"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetMaxPartySqrDistanceToLocator(float maxPartySqrDistanceToLocator)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MaxPartySqrDistanceToLocator = maxPartySqrDistanceToLocator;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.m_AffectedByImpatience"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetAffectedByImpatience(bool affectedByImpatience)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AffectedByImpatience = affectedByImpatience;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.m_Ability"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    public AiCastSpellConfigurator SetAbility(string? ability)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.m_ForceTargetSelf"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetForceTargetSelf(bool forceTargetSelf)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ForceTargetSelf = forceTargetSelf;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.m_ForceTargetEnemy"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetForceTargetEnemy(bool forceTargetEnemy)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ForceTargetEnemy = forceTargetEnemy;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.m_RandomVariant"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetRandomVariant(bool randomVariant)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_RandomVariant = randomVariant;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.m_Variant"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="variant"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    public AiCastSpellConfigurator SetVariant(string? variant)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Variant = BlueprintTool.GetRef<BlueprintAbilityReference>(variant);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.m_VariantsSet"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="variantsSet"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    public AiCastSpellConfigurator SetVariantsSet(string[]? variantsSet)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_VariantsSet = variantsSet.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAiCastSpell.m_VariantsSet"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="variantsSet"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    public AiCastSpellConfigurator AddToVariantsSet(params string[] variantsSet)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_VariantsSet = CommonTool.Append(bp.m_VariantsSet, variantsSet.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAiCastSpell.m_VariantsSet"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="variantsSet"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    public AiCastSpellConfigurator RemoveFromVariantsSet(params string[] variantsSet)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = variantsSet.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name));
            bp.m_VariantsSet =
                bp.m_VariantsSet
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.Locators"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetLocators(EntityReference[]? locators)
    {
      ValidateParam(locators);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Locators = locators;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAiCastSpell.Locators"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator AddToLocators(params EntityReference[] locators)
    {
      ValidateParam(locators);
      return OnConfigureInternal(
          bp =>
          {
            bp.Locators = CommonTool.Append(bp.Locators, locators ?? new EntityReference[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAiCastSpell.Locators"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator RemoveFromLocators(params EntityReference[] locators)
    {
      ValidateParam(locators);
      return OnConfigureInternal(
          bp =>
          {
            bp.Locators = bp.Locators.Where(item => !locators.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.CheckCasterDistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetCheckCasterDistance(bool checkCasterDistance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CheckCasterDistance = checkCasterDistance;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.MinCasterDistanceToLocator"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetMinCasterDistanceToLocator(float minCasterDistanceToLocator)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MinCasterDistanceToLocator = minCasterDistanceToLocator;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.CheckPartyDistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetCheckPartyDistance(bool checkPartyDistance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CheckPartyDistance = checkPartyDistance;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.MinPartyDistanceToLocator"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetMinPartyDistanceToLocator(float minPartyDistanceToLocator)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MinPartyDistanceToLocator = minPartyDistanceToLocator;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiCastSpell.MaxPartyDistanceToLocator"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiCastSpellConfigurator SetMaxPartyDistanceToLocator(float maxPartyDistanceToLocator)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MaxPartyDistanceToLocator = maxPartyDistanceToLocator;
          });
    }
  }
}

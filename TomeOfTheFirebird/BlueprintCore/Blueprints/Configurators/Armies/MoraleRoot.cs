using BlueprintCore.Utils;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>
  /// Configurator for <see cref="MoraleRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(MoraleRoot))]
  public class MoraleRootConfigurator : BaseBlueprintConfigurator<MoraleRoot, MoraleRootConfigurator>
  {
    private MoraleRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static MoraleRootConfigurator For(string name)
    {
      return new MoraleRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static MoraleRootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<MoraleRoot>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="MoraleRoot.m_MoraleBorder"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MoraleRootConfigurator SetMoraleBorder(Vector2Int moraleBorder)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MoraleBorder = moraleBorder;
          });
    }

    /// <summary>
    /// Sets <see cref="MoraleRoot.m_DevineForNegative"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MoraleRootConfigurator SetDevineForNegative(float devineForNegative)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DevineForNegative = devineForNegative;
          });
    }

    /// <summary>
    /// Sets <see cref="MoraleRoot.m_DevineForPositive"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MoraleRootConfigurator SetDevineForPositive(float devineForPositive)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DevineForPositive = devineForPositive;
          });
    }

    /// <summary>
    /// Sets <see cref="MoraleRoot.m_NegativeFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="negativeFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    public MoraleRootConfigurator SetNegativeFacts(string[]? negativeFacts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_NegativeFacts = negativeFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="MoraleRoot.m_NegativeFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="negativeFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    public MoraleRootConfigurator AddToNegativeFacts(params string[] negativeFacts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_NegativeFacts = CommonTool.Append(bp.m_NegativeFacts, negativeFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="MoraleRoot.m_NegativeFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="negativeFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    public MoraleRootConfigurator RemoveFromNegativeFacts(params string[] negativeFacts)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = negativeFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name));
            bp.m_NegativeFacts =
                bp.m_NegativeFacts
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="MoraleRoot.m_GlobalArmiesMoraleBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="globalArmiesMoraleBuff"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomBuff"/></param>
    [Generated]
    public MoraleRootConfigurator SetGlobalArmiesMoraleBuff(string? globalArmiesMoraleBuff)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_GlobalArmiesMoraleBuff = BlueprintTool.GetRef<BlueprintKingdomBuffReference>(globalArmiesMoraleBuff);
          });
    }

    /// <summary>
    /// Sets <see cref="MoraleRoot.BaseMoraleValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MoraleRootConfigurator SetBaseMoraleValue(LocalizedString? baseMoraleValue)
    {
      ValidateParam(baseMoraleValue);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.BaseMoraleValue = baseMoraleValue ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="MoraleRoot.ArmyEffectOnSquad"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MoraleRootConfigurator SetArmyEffectOnSquad(LocalizedString? armyEffectOnSquad)
    {
      ValidateParam(armyEffectOnSquad);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ArmyEffectOnSquad = armyEffectOnSquad ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="MoraleRoot.UnitNotHaveMorale"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MoraleRootConfigurator SetUnitNotHaveMorale(LocalizedString? unitNotHaveMorale)
    {
      ValidateParam(unitNotHaveMorale);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.UnitNotHaveMorale = unitNotHaveMorale ?? Constants.Empty.String;
          });
    }
  }
}

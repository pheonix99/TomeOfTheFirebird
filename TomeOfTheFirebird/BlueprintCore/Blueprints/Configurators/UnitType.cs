using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Configurator for <see cref="BlueprintUnitType"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnitType))]
  public class UnitTypeConfigurator : BaseBlueprintConfigurator<BlueprintUnitType, UnitTypeConfigurator>
  {
    private UnitTypeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitTypeConfigurator For(string name)
    {
      return new UnitTypeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitTypeConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintUnitType>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnitType.KnowledgeStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitTypeConfigurator SetKnowledgeStat(StatType knowledgeStat)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.KnowledgeStat = knowledgeStat;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnitType.Image"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitTypeConfigurator SetImage(Sprite image)
    {
      ValidateParam(image);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Image = image;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnitType.Name"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitTypeConfigurator SetName(LocalizedString? name)
    {
      ValidateParam(name);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Name = name ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnitType.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitTypeConfigurator SetDescription(LocalizedString? description)
    {
      ValidateParam(description);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Description = description ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnitType.m_SignatureAbilities"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="signatureAbilities"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    public UnitTypeConfigurator SetSignatureAbilities(string[]? signatureAbilities)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SignatureAbilities = signatureAbilities.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintUnitType.m_SignatureAbilities"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="signatureAbilities"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    public UnitTypeConfigurator AddToSignatureAbilities(params string[] signatureAbilities)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SignatureAbilities = CommonTool.Append(bp.m_SignatureAbilities, signatureAbilities.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintUnitType.m_SignatureAbilities"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="signatureAbilities"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    public UnitTypeConfigurator RemoveFromSignatureAbilities(params string[] signatureAbilities)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = signatureAbilities.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name));
            bp.m_SignatureAbilities =
                bp.m_SignatureAbilities
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}

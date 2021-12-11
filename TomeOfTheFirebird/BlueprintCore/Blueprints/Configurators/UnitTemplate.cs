using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Configurator for <see cref="BlueprintUnitTemplate"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnitTemplate))]
  public class UnitTemplateConfigurator : BaseBlueprintConfigurator<BlueprintUnitTemplate, UnitTemplateConfigurator>
  {
    private UnitTemplateConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitTemplateConfigurator For(string name)
    {
      return new UnitTemplateConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitTemplateConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintUnitTemplate>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnitTemplate.m_RemoveFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="removeFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    public UnitTemplateConfigurator SetRemoveFacts(string[]? removeFacts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_RemoveFacts = removeFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintUnitTemplate.m_RemoveFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="removeFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    public UnitTemplateConfigurator AddToRemoveFacts(params string[] removeFacts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_RemoveFacts = CommonTool.Append(bp.m_RemoveFacts, removeFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintUnitTemplate.m_RemoveFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="removeFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    public UnitTemplateConfigurator RemoveFromRemoveFacts(params string[] removeFacts)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = removeFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name));
            bp.m_RemoveFacts =
                bp.m_RemoveFacts
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnitTemplate.m_AddFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="addFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    public UnitTemplateConfigurator SetAddFacts(string[]? addFacts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AddFacts = addFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintUnitTemplate.m_AddFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="addFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    public UnitTemplateConfigurator AddToAddFacts(params string[] addFacts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AddFacts = CommonTool.Append(bp.m_AddFacts, addFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintUnitTemplate.m_AddFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="addFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    public UnitTemplateConfigurator RemoveFromAddFacts(params string[] addFacts)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = addFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name));
            bp.m_AddFacts =
                bp.m_AddFacts
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnitTemplate.StatAdjustments"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitTemplateConfigurator SetStatAdjustments(BlueprintUnitTemplate.StatAdjustment[]? statAdjustments)
    {
      ValidateParam(statAdjustments);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.StatAdjustments = statAdjustments;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintUnitTemplate.StatAdjustments"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitTemplateConfigurator AddToStatAdjustments(params BlueprintUnitTemplate.StatAdjustment[] statAdjustments)
    {
      ValidateParam(statAdjustments);
      return OnConfigureInternal(
          bp =>
          {
            bp.StatAdjustments = CommonTool.Append(bp.StatAdjustments, statAdjustments ?? new BlueprintUnitTemplate.StatAdjustment[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintUnitTemplate.StatAdjustments"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitTemplateConfigurator RemoveFromStatAdjustments(params BlueprintUnitTemplate.StatAdjustment[] statAdjustments)
    {
      ValidateParam(statAdjustments);
      return OnConfigureInternal(
          bp =>
          {
            bp.StatAdjustments = bp.StatAdjustments.Where(item => !statAdjustments.Contains(item)).ToArray();
          });
    }
  }
}

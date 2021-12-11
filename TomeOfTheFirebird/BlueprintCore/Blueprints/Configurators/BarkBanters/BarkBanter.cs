using BlueprintCore.Utils;
using Kingmaker.BarkBanters;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.BarkBanters
{
  /// <summary>
  /// Configurator for <see cref="BlueprintBarkBanter"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintBarkBanter))]
  public class BarkBanterConfigurator : BaseBlueprintConfigurator<BlueprintBarkBanter, BarkBanterConfigurator>
  {
    private BarkBanterConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static BarkBanterConfigurator For(string name)
    {
      return new BarkBanterConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static BarkBanterConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintBarkBanter>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBarkBanter.m_SpeakerType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BarkBanterConfigurator SetSpeakerType(SpeakerType speakerType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SpeakerType = speakerType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintBarkBanter.m_Unit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unit"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public BarkBanterConfigurator SetUnit(string? unit)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(unit);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintBarkBanter.Conditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BarkBanterConfigurator SetConditions(BanterConditions conditions)
    {
      ValidateParam(conditions);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Conditions = conditions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintBarkBanter.m_Weight"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BarkBanterConfigurator SetWeight(float weight)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Weight = weight;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintBarkBanter.FirstPhrase"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BarkBanterConfigurator SetFirstPhrase(LocalizedString[]? firstPhrase)
    {
      ValidateParam(firstPhrase);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.FirstPhrase = firstPhrase;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintBarkBanter.FirstPhrase"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BarkBanterConfigurator AddToFirstPhrase(params LocalizedString[] firstPhrase)
    {
      ValidateParam(firstPhrase);
      return OnConfigureInternal(
          bp =>
          {
            bp.FirstPhrase = CommonTool.Append(bp.FirstPhrase, firstPhrase ?? new LocalizedString[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintBarkBanter.FirstPhrase"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BarkBanterConfigurator RemoveFromFirstPhrase(params LocalizedString[] firstPhrase)
    {
      ValidateParam(firstPhrase);
      return OnConfigureInternal(
          bp =>
          {
            bp.FirstPhrase = bp.FirstPhrase.Where(item => !firstPhrase.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintBarkBanter.Responses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BarkBanterConfigurator SetResponses(BlueprintBarkBanter.BanterResponseEntry[]? responses)
    {
      ValidateParam(responses);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Responses = responses;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintBarkBanter.Responses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BarkBanterConfigurator AddToResponses(params BlueprintBarkBanter.BanterResponseEntry[] responses)
    {
      ValidateParam(responses);
      return OnConfigureInternal(
          bp =>
          {
            bp.Responses = CommonTool.Append(bp.Responses, responses ?? new BlueprintBarkBanter.BanterResponseEntry[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintBarkBanter.Responses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BarkBanterConfigurator RemoveFromResponses(params BlueprintBarkBanter.BanterResponseEntry[] responses)
    {
      ValidateParam(responses);
      return OnConfigureInternal(
          bp =>
          {
            bp.Responses = bp.Responses.Where(item => !responses.Contains(item)).ToArray();
          });
    }
  }
}

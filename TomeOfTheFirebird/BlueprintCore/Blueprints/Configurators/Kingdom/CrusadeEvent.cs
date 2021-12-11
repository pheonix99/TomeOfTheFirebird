using BlueprintCore.Utils;
using Kingmaker.Kingdom.Blueprints;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Configurator for <see cref="BlueprintCrusadeEvent"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCrusadeEvent))]
  public class CrusadeEventConfigurator : BaseKingdomEventBaseConfigurator<BlueprintCrusadeEvent, CrusadeEventConfigurator>
  {
    private CrusadeEventConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CrusadeEventConfigurator For(string name)
    {
      return new CrusadeEventConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CrusadeEventConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintCrusadeEvent>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCrusadeEvent.m_EventSolutions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CrusadeEventConfigurator SetEventSolutions(EventSolution[]? eventSolutions)
    {
      ValidateParam(eventSolutions);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_EventSolutions = eventSolutions;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCrusadeEvent.m_EventSolutions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CrusadeEventConfigurator AddToEventSolutions(params EventSolution[] eventSolutions)
    {
      ValidateParam(eventSolutions);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_EventSolutions = CommonTool.Append(bp.m_EventSolutions, eventSolutions ?? new EventSolution[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCrusadeEvent.m_EventSolutions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CrusadeEventConfigurator RemoveFromEventSolutions(params EventSolution[] eventSolutions)
    {
      ValidateParam(eventSolutions);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_EventSolutions = bp.m_EventSolutions.Where(item => !eventSolutions.Contains(item)).ToArray();
          });
    }
  }
}

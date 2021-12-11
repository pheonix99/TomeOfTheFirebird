using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.RandomEncounters.Settings;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.RandomEncounters
{
  /// <summary>
  /// Configurator for <see cref="BlueprintCampingEncounter"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCampingEncounter))]
  public class CampingEncounterConfigurator : BaseBlueprintConfigurator<BlueprintCampingEncounter, CampingEncounterConfigurator>
  {
    private CampingEncounterConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CampingEncounterConfigurator For(string name)
    {
      return new CampingEncounterConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CampingEncounterConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintCampingEncounter>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampingEncounter.Chance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampingEncounterConfigurator SetChance(int chance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Chance = chance;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampingEncounter.Conditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampingEncounterConfigurator SetConditions(ConditionsBuilder? conditions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampingEncounter.EncounterActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampingEncounterConfigurator SetEncounterActions(ActionsBuilder? encounterActions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.EncounterActions = encounterActions?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampingEncounter.InterruptsRest"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampingEncounterConfigurator SetInterruptsRest(bool interruptsRest)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.InterruptsRest = interruptsRest;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampingEncounter.PartyTired"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampingEncounterConfigurator SetPartyTired(bool partyTired)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.PartyTired = partyTired;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampingEncounter.MainCharacterTired"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampingEncounterConfigurator SetMainCharacterTired(bool mainCharacterTired)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MainCharacterTired = mainCharacterTired;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampingEncounter.NotOnGlobalMap"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampingEncounterConfigurator SetNotOnGlobalMap(bool notOnGlobalMap)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NotOnGlobalMap = notOnGlobalMap;
          });
    }
  }
}

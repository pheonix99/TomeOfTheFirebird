using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.View;
using Kingmaker.Localization;
using Kingmaker.RandomEncounters.Settings;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.RandomEncounters
{
  /// <summary>
  /// Configurator for <see cref="BlueprintRandomEncounter"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintRandomEncounter))]
  public class RandomEncounterConfigurator : BaseBlueprintConfigurator<BlueprintRandomEncounter, RandomEncounterConfigurator>
  {
    private RandomEncounterConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RandomEncounterConfigurator For(string name)
    {
      return new RandomEncounterConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RandomEncounterConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintRandomEncounter>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.ExcludeFromREList"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetExcludeFromREList(bool excludeFromREList)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ExcludeFromREList = excludeFromREList;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.IsPeaceful"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetIsPeaceful(bool isPeaceful)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsPeaceful = isPeaceful;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.Name"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetName(LocalizedString? name)
    {
      ValidateParam(name);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Name = name ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetDescription(LocalizedString? description)
    {
      ValidateParam(description);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Description = description ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.AvoidType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetAvoidType(EncounterAvoidType avoidType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AvoidType = avoidType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.AvoidDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetAvoidDC(int avoidDC)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AvoidDC = avoidDC;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.EncountersLimit"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetEncountersLimit(int encountersLimit)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.EncountersLimit = encountersLimit;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.Conditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetConditions(ConditionsBuilder? conditions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.PawnPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetPawnPrefab(GlobalMapRandomEncounterPawn pawnPrefab)
    {
      ValidateParam(pawnPrefab);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.PawnPrefab = pawnPrefab;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.Type"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetType(EncounterType type)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Type = type;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.DisableAutoSave"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetDisableAutoSave(bool disableAutoSave)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DisableAutoSave = disableAutoSave;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.OnEnter"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetOnEnter(ActionsBuilder? onEnter)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OnEnter = onEnter?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.CanBeCampingEncounter"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetCanBeCampingEncounter(bool canBeCampingEncounter)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CanBeCampingEncounter = canBeCampingEncounter;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.m_AreaEntrance"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="areaEntrance"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    [Generated]
    public RandomEncounterConfigurator SetAreaEntrance(string? areaEntrance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AreaEntrance = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(areaEntrance);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.m_BookEvent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="bookEvent"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintDialog"/></param>
    [Generated]
    public RandomEncounterConfigurator SetBookEvent(string? bookEvent)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_BookEvent = BlueprintTool.GetRef<BlueprintDialogReference>(bookEvent);
          });
    }
  }
}

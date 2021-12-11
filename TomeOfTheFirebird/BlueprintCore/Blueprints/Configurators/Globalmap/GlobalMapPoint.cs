using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Loot;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Enums;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;
using System;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>
  /// Configurator for <see cref="BlueprintGlobalMapPoint"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintGlobalMapPoint))]
  public class GlobalMapPointConfigurator : BaseBlueprintConfigurator<BlueprintGlobalMapPoint, GlobalMapPointConfigurator>
  {
    private GlobalMapPointConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static GlobalMapPointConfigurator For(string name)
    {
      return new GlobalMapPointConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static GlobalMapPointConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintGlobalMapPoint>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.m_GlobalMap"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="globalMap"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMap"/></param>
    [Generated]
    public GlobalMapPointConfigurator SetGlobalMap(string? globalMap)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMap.Reference>(globalMap);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.Type"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetType(GlobalMapPointType type)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Type = type;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.IsHidden"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetIsHidden(bool isHidden)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsHidden = isHidden;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.RevealedOnStart"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetRevealedOnStart(bool revealedOnStart)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RevealedOnStart = revealedOnStart;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.ExploreOnEnter"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetExploreOnEnter(bool exploreOnEnter)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ExploreOnEnter = exploreOnEnter;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.ClosedOnStart"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetClosedOnStart(bool closedOnStart)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ClosedOnStart = closedOnStart;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.Name"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetName(LocalizedString? name)
    {
      ValidateParam(name);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Name = name ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetDescription(LocalizedString? description)
    {
      ValidateParam(description);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Description = description ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.FakeName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetFakeName(LocalizedString? fakeName)
    {
      ValidateParam(fakeName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.FakeName = fakeName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.FakeDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetFakeDescription(LocalizedString? fakeDescription)
    {
      ValidateParam(fakeDescription);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.FakeDescription = fakeDescription ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.DcPerception"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetDcPerception(int dcPerception)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DcPerception = dcPerception;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.DCModifiers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetDCModifiers(DCModifier[]? dCModifiers)
    {
      ValidateParam(dCModifiers);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.DCModifiers = dCModifiers;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintGlobalMapPoint.DCModifiers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator AddToDCModifiers(params DCModifier[] dCModifiers)
    {
      ValidateParam(dCModifiers);
      return OnConfigureInternal(
          bp =>
          {
            bp.DCModifiers = CommonTool.Append(bp.DCModifiers, dCModifiers ?? new DCModifier[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintGlobalMapPoint.DCModifiers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator RemoveFromDCModifiers(params DCModifier[] dCModifiers)
    {
      ValidateParam(dCModifiers);
      return OnConfigureInternal(
          bp =>
          {
            bp.DCModifiers = bp.DCModifiers.Where(item => !dCModifiers.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.OverrideRandomEncounterZoneSize"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetOverrideRandomEncounterZoneSize(bool overrideRandomEncounterZoneSize)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OverrideRandomEncounterZoneSize = overrideRandomEncounterZoneSize;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.NoRandomEncounterZoneSize"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetNoRandomEncounterZoneSize(float noRandomEncounterZoneSize)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NoRandomEncounterZoneSize = noRandomEncounterZoneSize;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.m_AreaEntrance"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="areaEntrance"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    [Generated]
    public GlobalMapPointConfigurator SetAreaEntrance(string? areaEntrance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AreaEntrance = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(areaEntrance);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.m_Entrances"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="entrances"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintMultiEntrance"/></param>
    [Generated]
    public GlobalMapPointConfigurator SetEntrances(string? entrances)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Entrances = BlueprintTool.GetRef<BlueprintMultiEntrance.Reference>(entrances);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.m_BookEvent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="bookEvent"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintDialog"/></param>
    [Generated]
    public GlobalMapPointConfigurator SetBookEvent(string? bookEvent)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_BookEvent = BlueprintTool.GetRef<BlueprintDialogReference>(bookEvent);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.PossibleToRevealCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetPossibleToRevealCondition(ConditionsBuilder? possibleToRevealCondition)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.PossibleToRevealCondition = possibleToRevealCondition?.Build() ?? Constants.Empty.Conditions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.LocationVariations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="locationVariations"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPointVariation"/></param>
    [Generated]
    public GlobalMapPointConfigurator SetLocationVariations(string[]? locationVariations)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.LocationVariations = locationVariations.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapPointVariation.Reference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintGlobalMapPoint.LocationVariations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="locationVariations"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPointVariation"/></param>
    [Generated]
    public GlobalMapPointConfigurator AddToLocationVariations(params string[] locationVariations)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.LocationVariations = CommonTool.Append(bp.LocationVariations, locationVariations.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapPointVariation.Reference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintGlobalMapPoint.LocationVariations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="locationVariations"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPointVariation"/></param>
    [Generated]
    public GlobalMapPointConfigurator RemoveFromLocationVariations(params string[] locationVariations)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = locationVariations.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapPointVariation.Reference>(name));
            bp.LocationVariations =
                bp.LocationVariations
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.HasKingdomResource"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetHasKingdomResource(bool hasKingdomResource)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HasKingdomResource = hasKingdomResource;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.ResourceStats"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetResourceStats(KingdomStats.Changes resourceStats)
    {
      ValidateParam(resourceStats);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ResourceStats = resourceStats;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.ResourceName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetResourceName(LocalizedString? resourceName)
    {
      ValidateParam(resourceName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ResourceName = resourceName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.HasIngredients"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetHasIngredients(bool hasIngredients)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HasIngredients = hasIngredients;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.Ingredients"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetIngredients(IngredientPair[]? ingredients)
    {
      ValidateParam(ingredients);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Ingredients = ingredients;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintGlobalMapPoint.Ingredients"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator AddToIngredients(params IngredientPair[] ingredients)
    {
      ValidateParam(ingredients);
      return OnConfigureInternal(
          bp =>
          {
            bp.Ingredients = CommonTool.Append(bp.Ingredients, ingredients ?? new IngredientPair[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintGlobalMapPoint.Ingredients"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator RemoveFromIngredients(params IngredientPair[] ingredients)
    {
      ValidateParam(ingredients);
      return OnConfigureInternal(
          bp =>
          {
            bp.Ingredients = bp.Ingredients.Where(item => !ingredients.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.HasLoot"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetHasLoot(bool hasLoot)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HasLoot = hasLoot;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.Loot"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetLoot(LootEntry[]? loot)
    {
      ValidateParam(loot);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Loot = loot;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintGlobalMapPoint.Loot"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator AddToLoot(params LootEntry[] loot)
    {
      ValidateParam(loot);
      return OnConfigureInternal(
          bp =>
          {
            bp.Loot = CommonTool.Append(bp.Loot, loot ?? new LootEntry[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintGlobalMapPoint.Loot"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator RemoveFromLoot(params LootEntry[] loot)
    {
      ValidateParam(loot);
      return OnConfigureInternal(
          bp =>
          {
            bp.Loot = bp.Loot.Where(item => !loot.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.AdditionalArmyExperience"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetAdditionalArmyExperience(int additionalArmyExperience)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AdditionalArmyExperience = additionalArmyExperience;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.ResourceFoundDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetResourceFoundDescription(LocalizedString? resourceFoundDescription)
    {
      ValidateParam(resourceFoundDescription);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ResourceFoundDescription = resourceFoundDescription ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.m_ArmyObjective"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="armyObjective"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public GlobalMapPointConfigurator SetArmyObjective(string? armyObjective)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ArmyObjective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(armyObjective);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.Region"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetRegion(RegionId region)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Region = region;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.ForceShowNameInUI"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetForceShowNameInUI(bool forceShowNameInUI)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ForceShowNameInUI = forceShowNameInUI;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.OverrideEnterConfirmationText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetOverrideEnterConfirmationText(bool overrideEnterConfirmationText)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OverrideEnterConfirmationText = overrideEnterConfirmationText;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.CustomEnterConfirmationText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetCustomEnterConfirmationText(LocalizedString? customEnterConfirmationText)
    {
      ValidateParam(customEnterConfirmationText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.CustomEnterConfirmationText = customEnterConfirmationText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.OnEnterActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetOnEnterActions(ActionsBuilder? onEnterActions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OnEnterActions = onEnterActions?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.DemonGarrison"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="demonGarrison"><see cref="Kingmaker.Armies.Blueprints.BlueprintArmyPreset"/></param>
    [Generated]
    public GlobalMapPointConfigurator SetDemonGarrison(string? demonGarrison)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DemonGarrison = BlueprintTool.GetRef<BlueprintArmyPreset.Reference>(demonGarrison);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.GarrisonLeader"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="garrisonLeader"><see cref="Kingmaker.Armies.BlueprintArmyLeader"/></param>
    [Generated]
    public GlobalMapPointConfigurator SetGarrisonLeader(string? garrisonLeader)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.GarrisonLeader = BlueprintTool.GetRef<BlueprintArmyLeaderReference>(garrisonLeader);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.AutoDefeatData"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetAutoDefeatData(AutoDefeatData autoDefeatData)
    {
      ValidateParam(autoDefeatData);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.AutoDefeatData = autoDefeatData;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.UseCustomClosedText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetUseCustomClosedText(bool useCustomClosedText)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.UseCustomClosedText = useCustomClosedText;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.CustomClosedText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetCustomClosedText(LocalizedString? customClosedText)
    {
      ValidateParam(customClosedText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.CustomClosedText = customClosedText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPoint.GlobalMapZone"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointConfigurator SetGlobalMapZone(GlobalMapZone globalMapZone)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.GlobalMapZone = globalMapZone;
          });
    }

    /// <summary>
    /// Adds <see cref="LocationRadiusBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(LocationRadiusBuff))]
    public GlobalMapPointConfigurator AddLocationRadiusBuff(
        float radius = default,
        string? buff = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new LocationRadiusBuff();
      component.Radius = radius;
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="LocationRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="requiredCompanions"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(LocationRestriction))]
    public GlobalMapPointConfigurator AddLocationRestriction(
        ConditionsBuilder? ignoreCondition = null,
        ConditionsBuilder? allowedCondition = null,
        string[]? requiredCompanions = null,
        LocalizedString? description = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(description);
    
      var component = new LocationRestriction();
      component.IgnoreCondition = ignoreCondition?.Build() ?? Constants.Empty.Conditions;
      component.AllowedCondition = allowedCondition?.Build() ?? Constants.Empty.Conditions;
      component.RequiredCompanions = requiredCompanions.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToList();
      component.Description = description ?? Constants.Empty.String;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="LocationRevealedTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LocationRevealedTrigger))]
    public GlobalMapPointConfigurator AddLocationRevealedTrigger(
        bool onlyOnce = default,
        ActionsBuilder? onReveal = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new LocationRevealedTrigger();
      component.OnlyOnce = onlyOnce;
      component.OnReveal = onReveal?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}

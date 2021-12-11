using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Armies.Components;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Armies.TacticalCombat.LeaderSkills;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.CharGen;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.Blueprints.Items;
using Kingmaker.Controllers.Rest.Special;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.TempMapCode.Ambush;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Persistence.Versioning;
using Kingmaker.Enums;
using Kingmaker.Kingdom;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Interaction;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Components.Fixers;
using Kingmaker.Utility;
using Kingmaker.View.MapObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Configurator for <see cref="BlueprintUnit"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnit))]
  public class UnitConfigurator : BaseUnitFactConfigurator<BlueprintUnit, UnitConfigurator>
  {
    private UnitConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitConfigurator For(string name)
    {
      return new UnitConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintUnit>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.m_Type"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="type"><see cref="Kingmaker.Blueprints.BlueprintUnitType"/></param>
    [Generated]
    public UnitConfigurator SetType(string? type)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Type = BlueprintTool.GetRef<BlueprintUnitTypeReference>(type);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.LocalizedName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetLocalizedName(SharedStringAsset localizedName)
    {
      ValidateParam(localizedName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LocalizedName = localizedName;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Gender"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetGender(Gender gender)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Gender = gender;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Size"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetSize(Size size)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Size = size;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.IsLeftHanded"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetIsLeftHanded(bool isLeftHanded)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsLeftHanded = isLeftHanded;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Color"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetColor(Color color)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Color = color;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.m_Race"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="race"><see cref="Kingmaker.Blueprints.Classes.BlueprintRace"/></param>
    [Generated]
    public UnitConfigurator SetRace(string? race)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Race = BlueprintTool.GetRef<BlueprintRaceReference>(race);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Alignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetAlignment(Alignment alignment)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Alignment = alignment;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.m_Portrait"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="portrait"><see cref="Kingmaker.Blueprints.BlueprintPortrait"/></param>
    [Generated]
    public UnitConfigurator SetPortrait(string? portrait)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Portrait = BlueprintTool.GetRef<BlueprintPortraitReference>(portrait);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Prefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetPrefab(UnitViewLink prefab)
    {
      ValidateParam(prefab);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Prefab = prefab;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.m_CustomizationPreset"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="customizationPreset"><see cref="Kingmaker.UnitLogic.Customization.UnitCustomizationPreset"/></param>
    [Generated]
    public UnitConfigurator SetCustomizationPreset(string? customizationPreset)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CustomizationPreset = BlueprintTool.GetRef<UnitCustomizationPresetReference>(customizationPreset);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.m_RandomParameters"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="randomParameters"><see cref="Kingmaker.UnitLogic.Customization.RandomParameters"/></param>
    [Generated]
    public UnitConfigurator SetRandomParameters(string? randomParameters)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_RandomParameters = BlueprintTool.GetRef<RandomParametersReference>(randomParameters);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Visual"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetVisual(UnitVisualParams visual)
    {
      ValidateParam(visual);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Visual = visual;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.m_Faction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="faction"><see cref="Kingmaker.Blueprints.BlueprintFaction"/></param>
    [Generated]
    public UnitConfigurator SetFaction(string? faction)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Faction = BlueprintTool.GetRef<BlueprintFactionReference>(faction);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.FactionOverrides"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetFactionOverrides(FactionOverrides factionOverrides)
    {
      ValidateParam(factionOverrides);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.FactionOverrides = factionOverrides;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.m_StartingInventory"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startingInventory"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public UnitConfigurator SetStartingInventory(string[]? startingInventory)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_StartingInventory = startingInventory.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintUnit.m_StartingInventory"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startingInventory"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public UnitConfigurator AddToStartingInventory(params string[] startingInventory)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_StartingInventory = CommonTool.Append(bp.m_StartingInventory, startingInventory.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintUnit.m_StartingInventory"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startingInventory"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public UnitConfigurator RemoveFromStartingInventory(params string[] startingInventory)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = startingInventory.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name));
            bp.m_StartingInventory =
                bp.m_StartingInventory
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.m_Brain"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="brain"><see cref="Kingmaker.AI.Blueprints.BlueprintBrain"/></param>
    [Generated]
    public UnitConfigurator SetBrain(string? brain)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Brain = BlueprintTool.GetRef<BlueprintBrainReference>(brain);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.AlternativeBrains"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="alternativeBrains"><see cref="Kingmaker.AI.Blueprints.BlueprintBrain"/></param>
    [Generated]
    public UnitConfigurator SetAlternativeBrains(string[]? alternativeBrains)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AlternativeBrains = alternativeBrains.Select(name => BlueprintTool.GetRef<BlueprintBrainReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintUnit.AlternativeBrains"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="alternativeBrains"><see cref="Kingmaker.AI.Blueprints.BlueprintBrain"/></param>
    [Generated]
    public UnitConfigurator AddToAlternativeBrains(params string[] alternativeBrains)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AlternativeBrains = CommonTool.Append(bp.AlternativeBrains, alternativeBrains.Select(name => BlueprintTool.GetRef<BlueprintBrainReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintUnit.AlternativeBrains"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="alternativeBrains"><see cref="Kingmaker.AI.Blueprints.BlueprintBrain"/></param>
    [Generated]
    public UnitConfigurator RemoveFromAlternativeBrains(params string[] alternativeBrains)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = alternativeBrains.Select(name => BlueprintTool.GetRef<BlueprintBrainReference>(name));
            bp.AlternativeBrains =
                bp.AlternativeBrains
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Body"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetBody(BlueprintUnit.UnitBody body)
    {
      ValidateParam(body);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Body = body;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Strength"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetStrength(int strength)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Strength = strength;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Dexterity"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetDexterity(int dexterity)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Dexterity = dexterity;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Constitution"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetConstitution(int constitution)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Constitution = constitution;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Intelligence"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetIntelligence(int intelligence)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Intelligence = intelligence;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Wisdom"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetWisdom(int wisdom)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Wisdom = wisdom;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Charisma"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetCharisma(int charisma)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Charisma = charisma;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Speed"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetSpeed(Feet speed)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Speed = speed;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.BaseAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetBaseAttackBonus(int baseAttackBonus)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BaseAttackBonus = baseAttackBonus;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Skills"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetSkills(BlueprintUnit.UnitSkills skills)
    {
      ValidateParam(skills);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Skills = skills;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.MaxHP"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetMaxHP(int maxHP)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MaxHP = maxHP;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.m_AdditionalTemplates"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="additionalTemplates"><see cref="Kingmaker.Blueprints.BlueprintUnitTemplate"/></param>
    [Generated]
    public UnitConfigurator SetAdditionalTemplates(string[]? additionalTemplates)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AdditionalTemplates = additionalTemplates.Select(name => BlueprintTool.GetRef<BlueprintUnitTemplateReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintUnit.m_AdditionalTemplates"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="additionalTemplates"><see cref="Kingmaker.Blueprints.BlueprintUnitTemplate"/></param>
    [Generated]
    public UnitConfigurator AddToAdditionalTemplates(params string[] additionalTemplates)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AdditionalTemplates = CommonTool.Append(bp.m_AdditionalTemplates, additionalTemplates.Select(name => BlueprintTool.GetRef<BlueprintUnitTemplateReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintUnit.m_AdditionalTemplates"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="additionalTemplates"><see cref="Kingmaker.Blueprints.BlueprintUnitTemplate"/></param>
    [Generated]
    public UnitConfigurator RemoveFromAdditionalTemplates(params string[] additionalTemplates)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = additionalTemplates.Select(name => BlueprintTool.GetRef<BlueprintUnitTemplateReference>(name));
            bp.m_AdditionalTemplates =
                bp.m_AdditionalTemplates
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.m_AddFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="addFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    public UnitConfigurator SetAddFacts(string[]? addFacts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AddFacts = addFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintUnit.m_AddFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="addFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    public UnitConfigurator AddToAddFacts(params string[] addFacts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AddFacts = CommonTool.Append(bp.m_AddFacts, addFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintUnit.m_AddFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="addFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    public UnitConfigurator RemoveFromAddFacts(params string[] addFacts)
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
    /// Sets <see cref="BlueprintUnit.IsCheater"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetIsCheater(bool isCheater)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsCheater = isCheater;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.IsFake"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetIsFake(bool isFake)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsFake = isFake;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.m_CachedTags"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetCachedTags(AddTags cachedTags)
    {
      ValidateParam(cachedTags);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedTags = cachedTags;
          });
    }

    /// <summary>
    /// Adds <see cref="UnitUpgraderComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="upgraders"><see cref="Kingmaker.EntitySystem.Persistence.Versioning.BlueprintUnitUpgrader"/></param>
    [Generated]
    [Implements(typeof(UnitUpgraderComponent))]
    public UnitConfigurator AddUnitUpgraderComponent(
        string[]? upgraders = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new UnitUpgraderComponent();
      component.m_Upgraders = upgraders.Select(name => BlueprintTool.GetRef<BlueprintUnitUpgrader.Reference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="CampingSpecialAbility"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="campCutscene"><see cref="Kingmaker.AreaLogic.Cutscenes.Cutscene"/></param>
    /// <param name="selfBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="partyBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="partyBuffDuringCamp"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="selfBuffOnRandomEncounter"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="partyBuffOnRandomEncounter"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="enemiesBuffOnRandomEncounter"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="dlcReward"><see cref="Kingmaker.DLC.BlueprintDlcReward"/></param>
    [Generated]
    [Implements(typeof(CampingSpecialAbility))]
    public UnitConfigurator AddCampingSpecialAbility(
        LocalizedString? name = null,
        LocalizedString? description = null,
        CampPositionType campPositionType = default,
        string? campCutscene = null,
        string? selfBuff = null,
        string? partyBuff = null,
        string? partyBuffDuringCamp = null,
        string? selfBuffOnRandomEncounter = null,
        string? partyBuffOnRandomEncounter = null,
        string? enemiesBuffOnRandomEncounter = null,
        int minEnemyRandomEncounterBuffs = default,
        int maxEnemyRandomEncounterBuffs = default,
        float randomEncounterBuffsChance = default,
        int extraRations = default,
        CampingSpecialCustomMechanics customMechanics = default,
        string? dlcReward = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(name);
      ValidateParam(description);
    
      var component = new CampingSpecialAbility();
      component.Name = name ?? Constants.Empty.String;
      component.Description = description ?? Constants.Empty.String;
      component.CampPositionType = campPositionType;
      component.m_CampCutscene = BlueprintTool.GetRef<CutsceneReference>(campCutscene);
      component.m_SelfBuff = BlueprintTool.GetRef<BlueprintBuffReference>(selfBuff);
      component.m_PartyBuff = BlueprintTool.GetRef<BlueprintBuffReference>(partyBuff);
      component.m_PartyBuffDuringCamp = BlueprintTool.GetRef<BlueprintBuffReference>(partyBuffDuringCamp);
      component.m_SelfBuffOnRandomEncounter = BlueprintTool.GetRef<BlueprintBuffReference>(selfBuffOnRandomEncounter);
      component.m_PartyBuffOnRandomEncounter = BlueprintTool.GetRef<BlueprintBuffReference>(partyBuffOnRandomEncounter);
      component.m_EnemiesBuffOnRandomEncounter = BlueprintTool.GetRef<BlueprintBuffReference>(enemiesBuffOnRandomEncounter);
      component.MinEnemyRandomEncounterBuffs = minEnemyRandomEncounterBuffs;
      component.MaxEnemyRandomEncounterBuffs = maxEnemyRandomEncounterBuffs;
      component.RandomEncounterBuffsChance = randomEncounterBuffsChance;
      component.ExtraRations = extraRations;
      component.CustomMechanics = customMechanics;
      component.m_DlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(dlcReward);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="OverrideAnimationRaceComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blueprintRace"><see cref="Kingmaker.Blueprints.Classes.BlueprintRace"/></param>
    [Generated]
    [Implements(typeof(OverrideAnimationRaceComponent))]
    public UnitConfigurator AddOverrideAnimationRaceComponent(
        string? blueprintRace = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new OverrideAnimationRaceComponent();
      component.BlueprintRace = BlueprintTool.GetRef<BlueprintRaceReference>(blueprintRace);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DualCompanionComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="pairCompanion"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(DualCompanionComponent))]
    public UnitConfigurator AddDualCompanionComponent(
        string? pairCompanion = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DualCompanionComponent();
      component.m_PairCompanion = BlueprintTool.GetRef<BlueprintUnitReference>(pairCompanion);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="LockedCompanionComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LockedCompanionComponent))]
    public UnitConfigurator AddLockedCompanionComponent(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new LockedCompanionComponent();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="UnitAggroFilter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitAggroFilter))]
    public UnitConfigurator AddUnitAggroFilter(
        ConditionsBuilder? filterCondition = null,
        ActionsBuilder? actionsOnAggro = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new UnitAggroFilter();
      component.FilterCondition = filterCondition?.Build() ?? Constants.Empty.Conditions;
      component.ActionsOnAggro = actionsOnAggro?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DisableAllFx"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableAllFx))]
    public UnitConfigurator AddDisableAllFx(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DisableAllFx();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ReplaceUnitBlueprintForRespec"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blueprint"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(ReplaceUnitBlueprintForRespec))]
    public UnitConfigurator AddReplaceUnitBlueprintForRespec(
        string? blueprint = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ReplaceUnitBlueprintForRespec();
      component.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitReference>(blueprint);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="UnitIsStoryCompanion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitIsStoryCompanion))]
    public UnitConfigurator AddUnitIsStoryCompanion(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new UnitIsStoryCompanion();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddClassLevelsToPets"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blueprintPet"><see cref="Kingmaker.Blueprints.BlueprintPet"/></param>
    [Generated]
    [Implements(typeof(AddClassLevelsToPets))]
    public UnitConfigurator AddClassLevelsToPets(
        string? blueprintPet = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddClassLevelsToPets();
      component.m_BlueprintPet = BlueprintTool.GetRef<BlueprintPet.Reference>(blueprintPet);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ClassLevelLimit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ClassLevelLimit))]
    public UnitConfigurator AddClassLevelLimit(
        int levelLimit = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ClassLevelLimit();
      component.LevelLimit = levelLimit;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="MythicLevelLimit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MythicLevelLimit))]
    public UnitConfigurator AddMythicLevelLimit(
        int levelLimit = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new MythicLevelLimit();
      component.LevelLimit = levelLimit;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="Experience"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Experience))]
    public UnitConfigurator AddExperience(
        IntEvaluator count,
        EncounterType encounter = default,
        int cR = default,
        float modifier = default,
        bool dummy = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(count);
    
      var component = new Experience();
      component.Encounter = encounter;
      component.CR = cR;
      component.Modifier = modifier;
      component.Count = count;
      component.Dummy = dummy;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="PregenUnitComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PregenUnitComponent))]
    public UnitConfigurator AddPregenUnitComponent(
        LocalizedString? pregenName = null,
        LocalizedString? pregenDescription = null,
        LocalizedString? pregenClass = null,
        LocalizedString? pregenRole = null)
    {
      ValidateParam(pregenName);
      ValidateParam(pregenDescription);
      ValidateParam(pregenClass);
      ValidateParam(pregenRole);
    
      var component = new PregenUnitComponent();
      component.PregenName = pregenName ?? Constants.Empty.String;
      component.PregenDescription = pregenDescription ?? Constants.Empty.String;
      component.PregenClass = pregenClass ?? Constants.Empty.String;
      component.PregenRole = pregenRole ?? Constants.Empty.String;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ActionsOnClick"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ActionsOnClick))]
    public UnitConfigurator AddActionsOnClick(
        ActionsBuilder? actions = null,
        float overrideDistance = default,
        ConditionsBuilder? conditions = null,
        bool triggerOnApproach = default,
        bool triggerOnParty = default,
        float cooldown = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ActionsOnClick();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_OverrideDistance = overrideDistance;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.TriggerOnApproach = triggerOnApproach;
      component.TriggerOnParty = triggerOnParty;
      component.Cooldown = cooldown;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BarkOnClick"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BarkOnClick))]
    public UnitConfigurator AddBarkOnClick(
        LocalizedString? bark = null,
        bool showOnUser = default,
        float overrideDistance = default,
        ConditionsBuilder? conditions = null,
        bool triggerOnApproach = default,
        bool triggerOnParty = default,
        float cooldown = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(bark);
    
      var component = new BarkOnClick();
      component.Bark = bark ?? Constants.Empty.String;
      component.ShowOnUser = showOnUser;
      component.m_OverrideDistance = overrideDistance;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.TriggerOnApproach = triggerOnApproach;
      component.TriggerOnParty = triggerOnParty;
      component.Cooldown = cooldown;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DialogOnClick"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="dialog"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintDialog"/></param>
    [Generated]
    [Implements(typeof(DialogOnClick))]
    public UnitConfigurator AddDialogOnClick(
        string? dialog = null,
        ActionsBuilder? noDialogActions = null,
        float overrideDistance = default,
        ConditionsBuilder? conditions = null,
        bool triggerOnApproach = default,
        bool triggerOnParty = default,
        float cooldown = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DialogOnClick();
      component.m_Dialog = BlueprintTool.GetRef<BlueprintDialogReference>(dialog);
      component.NoDialogActions = noDialogActions?.Build() ?? Constants.Empty.Actions;
      component.m_OverrideDistance = overrideDistance;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.TriggerOnApproach = triggerOnApproach;
      component.TriggerOnParty = triggerOnParty;
      component.Cooldown = cooldown;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddAbilityToCharacterComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilities"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddAbilityToCharacterComponent))]
    public UnitConfigurator AddAbilityToCharacterComponent(
        string[]? abilities = null)
    {
      var component = new AddAbilityToCharacterComponent();
      component.m_Abilities = abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAmbushBehaviour"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddAmbushBehaviour))]
    public UnitConfigurator AddAmbushBehaviour(
        float joinCombatDisatnce = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddAmbushBehaviour();
      component.JoinCombatDisatnce = joinCombatDisatnce;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddLoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="loot"><see cref="Kingmaker.Blueprints.Loot.BlueprintUnitLoot"/></param>
    [Generated]
    [Implements(typeof(AddLoot))]
    public UnitConfigurator AddLoot(
        string? loot = null)
    {
      var component = new AddLoot();
      component.m_Loot = BlueprintTool.GetRef<BlueprintUnitLootReference>(loot);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddLootToVendorTable"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="loot"><see cref="Kingmaker.Blueprints.Loot.BlueprintUnitLoot"/></param>
    [Generated]
    [Implements(typeof(AddLootToVendorTable))]
    public UnitConfigurator AddLootToVendorTable(
        string? loot = null)
    {
      var component = new AddLootToVendorTable();
      component.m_Loot = BlueprintTool.GetRef<BlueprintUnitLootReference>(loot);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddPostLoadActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddPostLoadActions))]
    public UnitConfigurator AddPostLoadActions(
        ActionsBuilder? actions = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddPostLoadActions();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddSharedVendor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Table"><see cref="Kingmaker.Blueprints.Items.BlueprintSharedVendorTable"/></param>
    [Generated]
    [Implements(typeof(AddSharedVendor))]
    public UnitConfigurator AddSharedVendor(
        string? m_Table = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddSharedVendor();
      component.m_m_Table = BlueprintTool.GetRef<BlueprintSharedVendorTableReference>(m_Table);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddTags"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddTags))]
    public UnitConfigurator AddTags(
        bool useInRandomEncounter = default,
        bool useInDungeon = default,
        bool isRanged = default,
        bool isCaster = default,
        AddTags.DifficultyRequirement difficultyRequirement = default,
        UnitTag[]? tags = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddTags();
      component.UseInRandomEncounter = useInRandomEncounter;
      component.UseInDungeon = useInDungeon;
      component.IsRanged = isRanged;
      component.IsCaster = isCaster;
      component.m_DifficultyRequirement = difficultyRequirement;
      component.Tags = tags;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddVendorItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="loot"><see cref="Kingmaker.Blueprints.Loot.BlueprintUnitLoot"/></param>
    [Generated]
    [Implements(typeof(AddVendorItems))]
    public UnitConfigurator AddVendorItems(
        string? loot = null)
    {
      var component = new AddVendorItems();
      component.m_Loot = BlueprintTool.GetRef<BlueprintUnitLootReference>(loot);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeVendorPrices"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeVendorPrices))]
    public UnitConfigurator AddChangeVendorPrices(
        Dictionary<BlueprintItem,long> itemsToCosts,
        ChangeVendorPrices.Entry[]? priceOverrides = null)
    {
      ValidateParam(priceOverrides);
      ValidateParam(itemsToCosts);
    
      var component = new ChangeVendorPrices();
      component.m_PriceOverrides = priceOverrides;
      component.m_ItemsToCosts = itemsToCosts;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PregenDollSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PregenDollSettings))]
    public UnitConfigurator AddPregenDollSettings(
        PregenDollSettings.Entry defaultValue,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(defaultValue);
    
      var component = new PregenDollSettings();
      component.Default = defaultValue;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddActivatableAbilityComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="activatableAbilities"><see cref="Kingmaker.UnitLogic.ActivatableAbilities.BlueprintActivatableAbility"/></param>
    [Generated]
    [Implements(typeof(AddActivatableAbilityComponent))]
    public UnitConfigurator AddActivatableAbilityComponent(
        string[]? activatableAbilities = null)
    {
      var component = new AddActivatableAbilityComponent();
      component.m_ActivatableAbilities = activatableAbilities.Select(name => BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(name)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NonHumanoidCompanion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NonHumanoidCompanion))]
    public UnitConfigurator AddNonHumanoidCompanion()
    {
      return AddComponent(new NonHumanoidCompanion());
    }

    /// <summary>
    /// Adds <see cref="FixUnitOnPostLoad_AddNewFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="newFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(FixUnitOnPostLoad_AddNewFact))]
    public UnitConfigurator AddFixUnitOnPostLoad_AddNewFact(
        string taskId,
        string comment,
        string? newFact = null)
    {
      var component = new FixUnitOnPostLoad_AddNewFact();
      component.m_NewFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(newFact);
      component.TaskId = taskId;
      component.Comment = comment;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReturnVendorTable"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="table"><see cref="Kingmaker.Blueprints.Items.BlueprintSharedVendorTable"/></param>
    [Generated]
    [Implements(typeof(ReturnVendorTable))]
    public UnitConfigurator AddReturnVendorTable(
        string taskId,
        string comment,
        string? table = null)
    {
      var component = new ReturnVendorTable();
      component.m_Table = BlueprintTool.GetRef<BlueprintSharedVendorTableReference>(table);
      component.TaskId = taskId;
      component.Comment = comment;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyCriticalDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyCriticalDamage))]
    public UnitConfigurator AddArmyCriticalDamage(
        ContextValue? chanceBase = null,
        ContextValue? chanceMultiplier = null,
        float critBonus = default,
        float critMultiplier = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(chanceBase);
      ValidateParam(chanceMultiplier);
    
      var component = new ArmyCriticalDamage();
      component.m_ChanceBase = chanceBase ?? ContextValues.Constant(0);
      component.m_ChanceMultiplier = chanceMultiplier ?? ContextValues.Constant(0);
      component.m_CritBonus = critBonus;
      component.m_CritMultiplier = critMultiplier;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ArmySwitchWeaponSlotInMelee"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmySwitchWeaponSlotInMelee))]
    public UnitConfigurator AddArmySwitchWeaponSlotInMelee(
        int slotIndexForMelee = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ArmySwitchWeaponSlotInMelee();
      component.m_SlotIndexForMelee = slotIndexForMelee;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TacticalMoraleModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalMoraleModifier))]
    public UnitConfigurator AddTacticalMoraleModifier(
        TargetFilter targetFilter,
        TacticalMoraleModifier.FactionTarget factionTarget = default,
        int modValue = default)
    {
      ValidateParam(targetFilter);
    
      var component = new TacticalMoraleModifier();
      component.m_TargetFilter = targetFilter;
      component.m_FactionTarget = factionTarget;
      component.m_ModValue = modValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyUnitComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyUnitComponent))]
    public UnitConfigurator AddArmyUnitComponent(
        Sprite icon,
        KingdomResourcesAmount recruitmentPrice,
        KingdomResourcesAmount supportPrice,
        LocalizedString? description = null,
        bool isHaveMorale = default,
        int startMorale = default,
        int maxExtraActions = default,
        int mercenariesBaseGrowths = default,
        ArmyProperties properties = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(icon);
      ValidateParam(description);
    
      var component = new ArmyUnitComponent();
      component.Icon = icon;
      component.Description = description ?? Constants.Empty.String;
      component.IsHaveMorale = isHaveMorale;
      component.StartMorale = startMorale;
      component.MaxExtraActions = maxExtraActions;
      component.RecruitmentPrice = recruitmentPrice;
      component.SupportPrice = supportPrice;
      component.MercenariesBaseGrowths = mercenariesBaseGrowths;
      component.Properties = properties;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ArmyUnitSpellPower"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyUnitSpellPower))]
    public UnitConfigurator AddArmyUnitSpellPower(
        int spellPower = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ArmyUnitSpellPower();
      component.m_SpellPower = spellPower;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BuffOnEntityCreated"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(BuffOnEntityCreated))]
    public UnitConfigurator AddBuffOnEntityCreated(
        string? buff = null)
    {
      var component = new BuffOnEntityCreated();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEquipmentToPet"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="items"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(AddEquipmentToPet))]
    public UnitConfigurator AddEquipmentToPet(
        string[]? items = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddEquipmentToPet();
      component.m_Items = items.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}

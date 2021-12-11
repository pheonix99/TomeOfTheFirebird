using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Designers.Mechanics.Prerequisites;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Alignments;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Configurator for <see cref="BlueprintCharacterClass"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCharacterClass))]
  public class CharacterClassConfigurator : BaseBlueprintConfigurator<BlueprintCharacterClass, CharacterClassConfigurator>
  {
    private CharacterClassConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CharacterClassConfigurator For(string name)
    {
      return new CharacterClassConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CharacterClassConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintCharacterClass>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.LocalizedName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator SetLocalizedName(LocalizedString? localizedName)
    {
      ValidateParam(localizedName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LocalizedName = localizedName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.LocalizedDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator SetLocalizedDescription(LocalizedString? localizedDescription)
    {
      ValidateParam(localizedDescription);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LocalizedDescription = localizedDescription ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.LocalizedDescriptionShort"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator SetLocalizedDescriptionShort(LocalizedString? localizedDescriptionShort)
    {
      ValidateParam(localizedDescriptionShort);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LocalizedDescriptionShort = localizedDescriptionShort ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.m_Icon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator SetIcon(Sprite icon)
    {
      ValidateParam(icon);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Icon = icon;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.SkillPoints"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator SetSkillPoints(int skillPoints)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SkillPoints = skillPoints;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.HitDie"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator SetHitDie(DiceType hitDie)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HitDie = hitDie;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.HideIfRestricted"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator SetHideIfRestricted(bool hideIfRestricted)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HideIfRestricted = hideIfRestricted;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.PrestigeClass"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator SetPrestigeClass(bool prestigeClass)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.PrestigeClass = prestigeClass;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.IsMythic"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator SetIsMythic(bool isMythic)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsMythic = isMythic;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.m_IsHigherMythic"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator SetIsHigherMythic(bool isHigherMythic)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IsHigherMythic = isHigherMythic;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.m_BaseAttackBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="baseAttackBonus"><see cref="Kingmaker.Blueprints.Classes.BlueprintStatProgression"/></param>
    [Generated]
    public CharacterClassConfigurator SetBaseAttackBonus(string? baseAttackBonus)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_BaseAttackBonus = BlueprintTool.GetRef<BlueprintStatProgressionReference>(baseAttackBonus);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.m_FortitudeSave"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="fortitudeSave"><see cref="Kingmaker.Blueprints.Classes.BlueprintStatProgression"/></param>
    [Generated]
    public CharacterClassConfigurator SetFortitudeSave(string? fortitudeSave)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_FortitudeSave = BlueprintTool.GetRef<BlueprintStatProgressionReference>(fortitudeSave);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.m_ReflexSave"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="reflexSave"><see cref="Kingmaker.Blueprints.Classes.BlueprintStatProgression"/></param>
    [Generated]
    public CharacterClassConfigurator SetReflexSave(string? reflexSave)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ReflexSave = BlueprintTool.GetRef<BlueprintStatProgressionReference>(reflexSave);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.m_WillSave"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="willSave"><see cref="Kingmaker.Blueprints.Classes.BlueprintStatProgression"/></param>
    [Generated]
    public CharacterClassConfigurator SetWillSave(string? willSave)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_WillSave = BlueprintTool.GetRef<BlueprintStatProgressionReference>(willSave);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.m_Progression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="progression"><see cref="Kingmaker.Blueprints.Classes.BlueprintProgression"/></param>
    [Generated]
    public CharacterClassConfigurator SetProgression(string? progression)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Progression = BlueprintTool.GetRef<BlueprintProgressionReference>(progression);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.m_Spellbook"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbook"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellbook"/></param>
    [Generated]
    public CharacterClassConfigurator SetSpellbook(string? spellbook)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(spellbook);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.ClassSkills"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator SetClassSkills(StatType[]? classSkills)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ClassSkills = classSkills;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCharacterClass.ClassSkills"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator AddToClassSkills(params StatType[] classSkills)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ClassSkills = CommonTool.Append(bp.ClassSkills, classSkills ?? new StatType[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCharacterClass.ClassSkills"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator RemoveFromClassSkills(params StatType[] classSkills)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ClassSkills = bp.ClassSkills.Where(item => !classSkills.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.IsDivineCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator SetIsDivineCaster(bool isDivineCaster)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsDivineCaster = isDivineCaster;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.IsArcaneCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator SetIsArcaneCaster(bool isArcaneCaster)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsArcaneCaster = isArcaneCaster;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.m_Archetypes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="archetypes"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype"/></param>
    [Generated]
    public CharacterClassConfigurator SetArchetypes(string[]? archetypes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Archetypes = archetypes.Select(name => BlueprintTool.GetRef<BlueprintArchetypeReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCharacterClass.m_Archetypes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="archetypes"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype"/></param>
    [Generated]
    public CharacterClassConfigurator AddToArchetypes(params string[] archetypes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Archetypes = CommonTool.Append(bp.m_Archetypes, archetypes.Select(name => BlueprintTool.GetRef<BlueprintArchetypeReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCharacterClass.m_Archetypes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="archetypes"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype"/></param>
    [Generated]
    public CharacterClassConfigurator RemoveFromArchetypes(params string[] archetypes)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = archetypes.Select(name => BlueprintTool.GetRef<BlueprintArchetypeReference>(name));
            bp.m_Archetypes =
                bp.m_Archetypes
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.StartingGold"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator SetStartingGold(int startingGold)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StartingGold = startingGold;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.m_StartingItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startingItems"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public CharacterClassConfigurator SetStartingItems(string[]? startingItems)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_StartingItems = startingItems.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCharacterClass.m_StartingItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startingItems"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public CharacterClassConfigurator AddToStartingItems(params string[] startingItems)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_StartingItems = CommonTool.Append(bp.m_StartingItems, startingItems.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCharacterClass.m_StartingItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startingItems"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public CharacterClassConfigurator RemoveFromStartingItems(params string[] startingItems)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = startingItems.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name));
            bp.m_StartingItems =
                bp.m_StartingItems
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.PrimaryColor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator SetPrimaryColor(int primaryColor)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.PrimaryColor = primaryColor;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.SecondaryColor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator SetSecondaryColor(int secondaryColor)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SecondaryColor = secondaryColor;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.m_EquipmentEntities"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="equipmentEntities"><see cref="Kingmaker.Visual.CharacterSystem.KingmakerEquipmentEntity"/></param>
    [Generated]
    public CharacterClassConfigurator SetEquipmentEntities(string[]? equipmentEntities)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_EquipmentEntities = equipmentEntities.Select(name => BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCharacterClass.m_EquipmentEntities"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="equipmentEntities"><see cref="Kingmaker.Visual.CharacterSystem.KingmakerEquipmentEntity"/></param>
    [Generated]
    public CharacterClassConfigurator AddToEquipmentEntities(params string[] equipmentEntities)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_EquipmentEntities = CommonTool.Append(bp.m_EquipmentEntities, equipmentEntities.Select(name => BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCharacterClass.m_EquipmentEntities"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="equipmentEntities"><see cref="Kingmaker.Visual.CharacterSystem.KingmakerEquipmentEntity"/></param>
    [Generated]
    public CharacterClassConfigurator RemoveFromEquipmentEntities(params string[] equipmentEntities)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = equipmentEntities.Select(name => BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(name));
            bp.m_EquipmentEntities =
                bp.m_EquipmentEntities
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.MaleEquipmentEntities"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator SetMaleEquipmentEntities(EquipmentEntityLink[]? maleEquipmentEntities)
    {
      ValidateParam(maleEquipmentEntities);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.MaleEquipmentEntities = maleEquipmentEntities;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCharacterClass.MaleEquipmentEntities"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator AddToMaleEquipmentEntities(params EquipmentEntityLink[] maleEquipmentEntities)
    {
      ValidateParam(maleEquipmentEntities);
      return OnConfigureInternal(
          bp =>
          {
            bp.MaleEquipmentEntities = CommonTool.Append(bp.MaleEquipmentEntities, maleEquipmentEntities ?? new EquipmentEntityLink[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCharacterClass.MaleEquipmentEntities"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator RemoveFromMaleEquipmentEntities(params EquipmentEntityLink[] maleEquipmentEntities)
    {
      ValidateParam(maleEquipmentEntities);
      return OnConfigureInternal(
          bp =>
          {
            bp.MaleEquipmentEntities = bp.MaleEquipmentEntities.Where(item => !maleEquipmentEntities.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.FemaleEquipmentEntities"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator SetFemaleEquipmentEntities(EquipmentEntityLink[]? femaleEquipmentEntities)
    {
      ValidateParam(femaleEquipmentEntities);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.FemaleEquipmentEntities = femaleEquipmentEntities;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCharacterClass.FemaleEquipmentEntities"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator AddToFemaleEquipmentEntities(params EquipmentEntityLink[] femaleEquipmentEntities)
    {
      ValidateParam(femaleEquipmentEntities);
      return OnConfigureInternal(
          bp =>
          {
            bp.FemaleEquipmentEntities = CommonTool.Append(bp.FemaleEquipmentEntities, femaleEquipmentEntities ?? new EquipmentEntityLink[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCharacterClass.FemaleEquipmentEntities"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator RemoveFromFemaleEquipmentEntities(params EquipmentEntityLink[] femaleEquipmentEntities)
    {
      ValidateParam(femaleEquipmentEntities);
      return OnConfigureInternal(
          bp =>
          {
            bp.FemaleEquipmentEntities = bp.FemaleEquipmentEntities.Where(item => !femaleEquipmentEntities.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.m_Difficulty"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator SetDifficulty(int difficulty)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Difficulty = difficulty;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.RecommendedAttributes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator SetRecommendedAttributes(StatType[]? recommendedAttributes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RecommendedAttributes = recommendedAttributes;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCharacterClass.RecommendedAttributes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator AddToRecommendedAttributes(params StatType[] recommendedAttributes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RecommendedAttributes = CommonTool.Append(bp.RecommendedAttributes, recommendedAttributes ?? new StatType[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCharacterClass.RecommendedAttributes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator RemoveFromRecommendedAttributes(params StatType[] recommendedAttributes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RecommendedAttributes = bp.RecommendedAttributes.Where(item => !recommendedAttributes.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.NotRecommendedAttributes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator SetNotRecommendedAttributes(StatType[]? notRecommendedAttributes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NotRecommendedAttributes = notRecommendedAttributes;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCharacterClass.NotRecommendedAttributes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator AddToNotRecommendedAttributes(params StatType[] notRecommendedAttributes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NotRecommendedAttributes = CommonTool.Append(bp.NotRecommendedAttributes, notRecommendedAttributes ?? new StatType[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCharacterClass.NotRecommendedAttributes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator RemoveFromNotRecommendedAttributes(params StatType[] notRecommendedAttributes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NotRecommendedAttributes = bp.NotRecommendedAttributes.Where(item => !notRecommendedAttributes.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.m_SignatureAbilities"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="signatureAbilities"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    public CharacterClassConfigurator SetSignatureAbilities(string[]? signatureAbilities)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SignatureAbilities = signatureAbilities.Select(name => BlueprintTool.GetRef<BlueprintFeatureReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCharacterClass.m_SignatureAbilities"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="signatureAbilities"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    public CharacterClassConfigurator AddToSignatureAbilities(params string[] signatureAbilities)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SignatureAbilities = CommonTool.Append(bp.m_SignatureAbilities, signatureAbilities.Select(name => BlueprintTool.GetRef<BlueprintFeatureReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCharacterClass.m_SignatureAbilities"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="signatureAbilities"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    public CharacterClassConfigurator RemoveFromSignatureAbilities(params string[] signatureAbilities)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = signatureAbilities.Select(name => BlueprintTool.GetRef<BlueprintFeatureReference>(name));
            bp.m_SignatureAbilities =
                bp.m_SignatureAbilities
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.m_DefaultBuild"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="defaultBuild"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    public CharacterClassConfigurator SetDefaultBuild(string? defaultBuild)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DefaultBuild = BlueprintTool.GetRef<BlueprintUnitFactReference>(defaultBuild);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.m_AdditionalVisualSettings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="additionalVisualSettings"><see cref="Kingmaker.Blueprints.Classes.BlueprintClassAdditionalVisualSettingsProgression"/></param>
    [Generated]
    public CharacterClassConfigurator SetAdditionalVisualSettings(string? additionalVisualSettings)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AdditionalVisualSettings = BlueprintTool.GetRef<BlueprintClassAdditionalVisualSettingsProgression.Reference>(additionalVisualSettings);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClass.VisualSettingsPriority"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CharacterClassConfigurator SetVisualSettingsPriority(int visualSettingsPriority)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.VisualSettingsPriority = visualSettingsPriority;
          });
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteArchetypeLevel"/>
    /// </summary>
    /// 
    /// <param name="clazz"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass">BlueprintCharacterClass</see></param>
    /// <param name="archetype"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype">BlueprintArchetype</see></param>
    [Implements(typeof(PrerequisiteArchetypeLevel))]
    public CharacterClassConfigurator PrerequisiteArchetype(
        string clazz,
        string archetype,
        int level = 1,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteArchetypeLevel>(group, checkInProgression, hideInUI);
      prereq.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      prereq.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      prereq.Level = level;
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteCasterType">PrerequisiteCasterType</see>
    /// </summary>
    [Implements(typeof(PrerequisiteCasterType))]
    public CharacterClassConfigurator PrerequisiteCasterType(
        bool isArcane,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false,
        ComponentMerge behavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? merge = null)
    {
      var prereq = PrereqTool.Create<PrerequisiteCasterType>(group, checkInProgression, hideInUI);
      prereq.IsArcane = isArcane;
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteCasterTypeSpellLevel">PrerequisiteCasterTypeSpellLevel</see>
    /// </summary>
    [Implements(typeof(PrerequisiteCasterTypeSpellLevel))]
    public CharacterClassConfigurator PrerequisiteCasterTypeSpellLevel(
        bool isArcane,
        bool onlySpontaneous,
        int minSpellLevel,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteCasterTypeSpellLevel>(group, checkInProgression, hideInUI);
      prereq.IsArcane = isArcane;
      prereq.OnlySpontaneous = onlySpontaneous;
      prereq.RequiredSpellLevel = minSpellLevel;
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteCharacterLevel">PrerequisiteCharacterLevel</see>
    /// </summary>
    [Implements(typeof(PrerequisiteCharacterLevel))]
    public CharacterClassConfigurator PrerequisiteCharacterLevel(
        int minLevel,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false,
        ComponentMerge behavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? merge = null)
    {
      var prereq = PrereqTool.Create<PrerequisiteCharacterLevel>(group, checkInProgression, hideInUI);
      prereq.Level = minLevel;
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteClassLevel">PrerequisiteClassLevel</see>
    /// </summary>
    /// 
    /// <param name="clazz"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass">BlueprintCharacterClass</see></param>
    [Implements(typeof(PrerequisiteClassLevel))]
    public CharacterClassConfigurator PrerequisiteClassLevel(
        string clazz,
        int minLevel,
        bool negate = false,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteClassLevel>(group, checkInProgression, hideInUI);
      prereq.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      prereq.Level = minLevel;
      prereq.Not = negate;
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteClassSpellLevel">PrerequisiteClassSpellLevel</see>
    /// </summary>
    /// 
    /// <param name="clazz"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass">BlueprintCharacterClass</see></param>
    [Implements(typeof(PrerequisiteClassSpellLevel))]
    public CharacterClassConfigurator PrerequisiteClassSpellLevel(
        string clazz,
        int minSpellLevel,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false,
        ComponentMerge behavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? merge = null)
    {
      var prereq = PrereqTool.Create<PrerequisiteClassSpellLevel>(group, checkInProgression, hideInUI);
      prereq.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      prereq.RequiredSpellLevel = minSpellLevel;
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteEtude">PrerequisiteEtude</see>
    /// </summary>
    /// 
    /// <param name="etude"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude">BlueprintEtude</see></param>
    [Implements(typeof(PrerequisiteEtude))]
    public CharacterClassConfigurator PrerequisiteEtude(
        string etude,
        bool playing = true,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteEtude>(group, checkInProgression, hideInUI);
      prereq.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      prereq.NotPlaying = !playing;
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteFeature">PrerequisiteFeature</see>
    /// </summary>
    /// 
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    [Implements(typeof(PrerequisiteFeature))]
    public CharacterClassConfigurator PrerequisiteFeature(
        string feature,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteFeature>(group, checkInProgression, hideInUI);
      prereq.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteFeaturesFromList">PrerequisiteFeaturesFromList</see>
    /// </summary>
    /// 
    /// <param name="features"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    [Implements(typeof(PrerequisiteFeaturesFromList))]
    public CharacterClassConfigurator PrerequisiteFeaturesFromList(
        string[] features,
        int requiredNumber = 1,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteFeaturesFromList>(group, checkInProgression, hideInUI);
      prereq.m_Features =
          features.Select(feature => BlueprintTool.GetRef<BlueprintFeatureReference>(feature)).ToArray();
      prereq.Amount = requiredNumber;
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteIsPet">PrerequisiteIsPet</see>
    /// </summary>
    [Implements(typeof(PrerequisiteIsPet))]
    public CharacterClassConfigurator PrerequisiteIsPet(
        bool negate = false,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteIsPet>(group, checkInProgression, hideInUI);
      prereq.Not = negate;
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteMainCharacter">PrerequisiteMainCharacter</see>
    /// </summary>
    [Implements(typeof(PrerequisiteMainCharacter))]
    public CharacterClassConfigurator PrerequisiteMainCharacter(
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false,
        ComponentMerge behavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? merge = null)
    {
      var prereq = PrereqTool.Create<PrerequisiteMainCharacter>(group, checkInProgression, hideInUI);
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteMainCharacter">PrerequisiteMainCharacter</see>
    /// </summary>
    [Implements(typeof(PrerequisiteMainCharacter))]
    public CharacterClassConfigurator PrerequisiteCompanion(
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false,
        ComponentMerge behavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? merge = null)
    {
      var prereq = PrereqTool.Create<PrerequisiteMainCharacter>(group, checkInProgression, hideInUI);
      prereq.Companion = true;
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteMythicLevel">PrerequisiteMythicLevel</see>
    /// </summary>
    [Implements(typeof(PrerequisiteMythicLevel))]
    public CharacterClassConfigurator PrerequisiteMythicLevel(
        int level,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false,
        ComponentMerge behavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? merge = null)
    {
      var prereq = PrereqTool.Create<PrerequisiteMythicLevel>(group, checkInProgression, hideInUI);
      prereq.Level = level;
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteNoArchetype">PrerequisiteNoArchetype</see>
    /// </summary>
    /// 
    /// <param name="clazz"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass">BlueprintCharacterClass</see></param>
    /// <param name="archetype"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype">BlueprintArchetype</see></param>
    [Implements(typeof(PrerequisiteNoArchetype))]
    public CharacterClassConfigurator PrerequisiteNoArchetype(
        string clazz,
        string archetype,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteNoArchetype>(group, checkInProgression, hideInUI);
      prereq.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      prereq.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteNoClassLevel"/>
    /// </summary>
    /// 
    /// <param name="clazz"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass">BlueprintCharacterClass</see></param>
    [Implements(typeof(PrerequisiteNoClassLevel))]
    public CharacterClassConfigurator PrerequisiteNoClass(
        string clazz,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteNoClassLevel>(group, checkInProgression, hideInUI);
      prereq.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteNoFeature">PrerequisiteNoFeature</see>
    /// </summary>
    /// 
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    [Implements(typeof(PrerequisiteNoFeature))]
    public CharacterClassConfigurator PrerequisiteNoFeature(
        string feature,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteNoFeature>(group, checkInProgression, hideInUI);
      prereq.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteNotProficient">PrerequisiteNotProficient</see>
    /// </summary>
    [Implements(typeof(PrerequisiteNotProficient))]
    public CharacterClassConfigurator PrerequisiteNotProficient(
        WeaponCategory[] weapons,
        ArmorProficiencyGroup[] armors,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false,
        ComponentMerge behavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? merge = null)
    {
      var prereq =
          PrereqTool.Create<PrerequisiteNotProficient>(group, checkInProgression, hideInUI);
      prereq.WeaponProficiencies = weapons ?? Constants.Empty.WeaponCategories;
      prereq.ArmorProficiencies = armors ?? Constants.Empty.ArmorProficiencies;
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteParametrizedFeature"/>
    /// </summary>
    /// 
    /// <param name="spellFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    /// <param name="spellAbility"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility">BlueprintAbility</see></param>
    [Implements(typeof(PrerequisiteParametrizedFeature))]
    public CharacterClassConfigurator PrerequisiteParameterizedSpellFeature(
        string spellFeature,
        string spellAbility,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteParametrizedFeature>(group, checkInProgression, hideInUI);
      // Note: There is no distinction between SpellSpecialization and LearnSpell, despite them
      // being called out independently in the component.
      prereq.ParameterType = FeatureParameterType.LearnSpell;
      prereq.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(spellFeature);
      prereq.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spellAbility);
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteParametrizedFeature"/>
    /// </summary>
    /// 
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    [Implements(typeof(PrerequisiteParametrizedFeature))]
    public CharacterClassConfigurator PrerequisiteParameterizedWeaponFeature(
        string feature,
        WeaponCategory weapon,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq =
          PrereqTool.Create<PrerequisiteParametrizedFeature>(group, checkInProgression, hideInUI);
      prereq.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      prereq.ParameterType = FeatureParameterType.WeaponCategory;
      prereq.WeaponCategory = weapon;
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteParametrizedFeature"/>
    /// </summary>
    /// 
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    [Implements(typeof(PrerequisiteParametrizedFeature))]
    public CharacterClassConfigurator PrerequisiteParameterizedSpellSchoolFeature(
        string feature,
        SpellSchool school,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteParametrizedFeature>(group, checkInProgression, hideInUI);
      prereq.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      prereq.ParameterType = FeatureParameterType.SpellSchool;
      prereq.SpellSchool = school;
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteParametrizedWeaponSubcategory"/>
    /// </summary>
    /// 
    /// <param name="weaponFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    [Implements(typeof(PrerequisiteParametrizedWeaponSubcategory))]
    public CharacterClassConfigurator PrerequisiteParameterizedWeaponSubcategory(
        string weaponFeature,
        WeaponSubCategory weapon,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteParametrizedWeaponSubcategory>(group, checkInProgression, hideInUI);
      prereq.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(weaponFeature);
      prereq.SubCategory = weapon;
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisitePet">PrerequisitePet</see>
    /// </summary>
    [Implements(typeof(PrerequisitePet))]
    public CharacterClassConfigurator PrerequisitePet(
        PetType type,
        bool negate = false,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisitePet>(group, checkInProgression, hideInUI);
      prereq.Type = type;
      prereq.NoCompanion = negate;
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisitePlayerHasFeature">PrerequisitePlayerHasFeature</see>
    /// </summary>
    /// 
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    [Implements(typeof(PrerequisitePlayerHasFeature))]
    public CharacterClassConfigurator PrerequisitePlayerHasFeature(
        string feature,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisitePlayerHasFeature>(group, checkInProgression, hideInUI);
      prereq.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteProficiency"/>
    /// </summary>
    [Implements(typeof(PrerequisiteProficiency))]
    public CharacterClassConfigurator PrerequisiteProficient(
        WeaponCategory[] weapons,
        ArmorProficiencyGroup[] armors,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false,
        ComponentMerge behavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? merge = null)
    {
      var prereq =
          PrereqTool.Create<PrerequisiteProficiency>(group, checkInProgression, hideInUI);
      prereq.WeaponProficiencies = weapons ?? Constants.Empty.WeaponCategories;
      prereq.ArmorProficiencies = armors ?? Constants.Empty.ArmorProficiencies;
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteStatValue"/>
    /// </summary>
    [Implements(typeof(PrerequisiteStatValue))]
    public CharacterClassConfigurator PrerequisiteStat(
        StatType type,
        int minValue,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteStatValue>(group, checkInProgression, hideInUI);
      prereq.Stat = type;
      prereq.Value = minValue;
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds or modifies <see cref="PrerequisiteAlignment"/>
    /// </summary>
    [Implements(typeof(PrerequisiteAlignment))]
    public CharacterClassConfigurator AddPrerequisiteAlignment(params AlignmentMaskType[] alignments)
    {
      return OnConfigureInternal(blueprint => AddPrerequisiteAlignment(blueprint, alignments.ToList()));
    }

    [Implements(typeof(PrerequisiteAlignment))]
    private static void AddPrerequisiteAlignment(BlueprintScriptableObject bp, List<AlignmentMaskType> alignments)
    {
      var component = bp.GetComponent<PrerequisiteAlignment>();
      if (component is null)
      {
        component = new PrerequisiteAlignment();
        bp.AddComponents(component);
      }
      alignments.ForEach(alignment => component.Alignment |= alignment);
    }

    /// <summary>
    /// Modifies <see cref="PrerequisiteAlignment"/>
    /// </summary>
    [Implements(typeof(PrerequisiteAlignment))]
    public CharacterClassConfigurator RemovePrerequisiteAlignment(params AlignmentMaskType[] alignments)
    {
      return OnConfigureInternal(blueprint => RemovePrerequisiteAlignment(blueprint, alignments.ToList()));
    }

    [Implements(typeof(PrerequisiteAlignment))]
    private static void RemovePrerequisiteAlignment(BlueprintScriptableObject bp, List<AlignmentMaskType> alignments)
    {
      var component = bp.GetComponent<PrerequisiteAlignment>();
      if (component is null) { return; }
      alignments.ForEach(alignment => component.Alignment &= ~alignment);
    }

    /// <summary>
    /// Adds <see cref="DeityDependencyClass"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DeityDependencyClass))]
    public CharacterClassConfigurator AddDeityDependencyClass(
        bool isDeityDependencyClass = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DeityDependencyClass();
      component.IsDeityDependencyClass = isDeityDependencyClass;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="HideClassIfPrerequisitesRequiredComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HideClassIfPrerequisitesRequiredComponent))]
    public CharacterClassConfigurator AddHideClassIfPrerequisitesRequiredComponent(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new HideClassIfPrerequisitesRequiredComponent();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="MythicClassArtComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="portraits"><see cref="Kingmaker.Blueprints.BlueprintPortrait"/></param>
    [Generated]
    [Implements(typeof(MythicClassArtComponent))]
    public CharacterClassConfigurator AddMythicClassArtComponent(
        SpriteLink selectorPortrait,
        SpriteLink selectorPortraitLineart,
        SpriteLink commonFrame,
        SpriteLink commonFrameDecor,
        SpriteLink portraitFrame,
        SpriteLink selectorFrame,
        SpriteLink abilityFrame,
        SpriteLink emblem,
        string[]? portraits = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(selectorPortrait);
      ValidateParam(selectorPortraitLineart);
      ValidateParam(commonFrame);
      ValidateParam(commonFrameDecor);
      ValidateParam(portraitFrame);
      ValidateParam(selectorFrame);
      ValidateParam(abilityFrame);
      ValidateParam(emblem);
    
      var component = new MythicClassArtComponent();
      component.m_SelectorPortrait = selectorPortrait;
      component.m_SelectorPortraitLineart = selectorPortraitLineart;
      component.m_CommonFrame = commonFrame;
      component.m_CommonFrameDecor = commonFrameDecor;
      component.m_PortraitFrame = portraitFrame;
      component.m_SelectorFrame = selectorFrame;
      component.m_AbilityFrame = abilityFrame;
      component.m_Emblem = emblem;
      component.m_Portraits = portraits.Select(name => BlueprintTool.GetRef<BlueprintPortraitReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="MythicClassLockComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MythicClassLockComponent))]
    public CharacterClassConfigurator AddMythicClassLockComponent(
        Mythic[]? locks = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new MythicClassLockComponent();
      component.Locks = locks;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SkipLevelsForSpellProgression"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SkipLevelsForSpellProgression))]
    public CharacterClassConfigurator AddSkipLevelsForSpellProgression(
        int[]? levels = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SkipLevelsForSpellProgression();
      component.Levels = levels;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteLoreMaster"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="loreMaster"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(PrerequisiteLoreMaster))]
    public CharacterClassConfigurator AddPrerequisiteLoreMaster(
        string? loreMaster = null,
        int rating = default,
        Prerequisite.GroupType group = default,
        bool checkInProgression = default,
        bool hideInUI = default)
    {
      var component = new PrerequisiteLoreMaster();
      component.m_LoreMaster = BlueprintTool.GetRef<BlueprintCharacterClassReference>(loreMaster);
      component.Rating = rating;
      component.Group = group;
      component.CheckInProgression = checkInProgression;
      component.HideInUI = hideInUI;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteFullStatValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PrerequisiteFullStatValue))]
    public CharacterClassConfigurator AddPrerequisiteFullStatValue(
        StatType stat = default,
        int value = default,
        Prerequisite.GroupType group = default,
        bool checkInProgression = default,
        bool hideInUI = default)
    {
      var component = new PrerequisiteFullStatValue();
      component.Stat = stat;
      component.Value = value;
      component.Group = group;
      component.CheckInProgression = checkInProgression;
      component.HideInUI = hideInUI;
      return AddComponent(component);
    }
  }
}

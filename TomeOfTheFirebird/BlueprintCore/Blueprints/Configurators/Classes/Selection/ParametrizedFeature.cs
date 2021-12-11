using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Classes.Selection
{
  /// <summary>
  /// Configurator for <see cref="BlueprintParametrizedFeature"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintParametrizedFeature))]
  public class ParametrizedFeatureConfigurator : BaseFeatureConfigurator<BlueprintParametrizedFeature, ParametrizedFeatureConfigurator>
  {
    private ParametrizedFeatureConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ParametrizedFeatureConfigurator For(string name)
    {
      return new ParametrizedFeatureConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ParametrizedFeatureConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintParametrizedFeature>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintParametrizedFeature.ParameterType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ParametrizedFeatureConfigurator SetParameterType(FeatureParameterType parameterType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ParameterType = parameterType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintParametrizedFeature.WeaponSubCategory"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ParametrizedFeatureConfigurator SetWeaponSubCategory(WeaponSubCategory weaponSubCategory)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.WeaponSubCategory = weaponSubCategory;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintParametrizedFeature.SelectionFeatureGroup"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ParametrizedFeatureConfigurator SetSelectionFeatureGroup(FeatureGroup selectionFeatureGroup)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SelectionFeatureGroup = selectionFeatureGroup;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintParametrizedFeature.RequireProficiency"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ParametrizedFeatureConfigurator SetRequireProficiency(bool requireProficiency)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RequireProficiency = requireProficiency;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintParametrizedFeature.m_SpellList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellList"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellList"/></param>
    [Generated]
    public ParametrizedFeatureConfigurator SetSpellList(string? spellList)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(spellList);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintParametrizedFeature.m_SpellcasterClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellcasterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    public ParametrizedFeatureConfigurator SetSpellcasterClass(string? spellcasterClass)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SpellcasterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(spellcasterClass);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintParametrizedFeature.SpecificSpellLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ParametrizedFeatureConfigurator SetSpecificSpellLevel(bool specificSpellLevel)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SpecificSpellLevel = specificSpellLevel;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintParametrizedFeature.SpellLevelPenalty"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ParametrizedFeatureConfigurator SetSpellLevelPenalty(int spellLevelPenalty)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SpellLevelPenalty = spellLevelPenalty;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintParametrizedFeature.SpellLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ParametrizedFeatureConfigurator SetSpellLevel(int spellLevel)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SpellLevel = spellLevel;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintParametrizedFeature.DisallowSpellsInSpellList"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ParametrizedFeatureConfigurator SetDisallowSpellsInSpellList(bool disallowSpellsInSpellList)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DisallowSpellsInSpellList = disallowSpellsInSpellList;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintParametrizedFeature.m_Prerequisite"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="prerequisite"><see cref="Kingmaker.Blueprints.Classes.Selection.BlueprintParametrizedFeature"/></param>
    [Generated]
    public ParametrizedFeatureConfigurator SetPrerequisite(string? prerequisite)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Prerequisite = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(prerequisite);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintParametrizedFeature.CustomParameterVariants"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="customParameterVariants"><see cref="Kingmaker.Blueprints.BlueprintScriptableObject"/></param>
    [Generated]
    public ParametrizedFeatureConfigurator SetCustomParameterVariants(string[]? customParameterVariants)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CustomParameterVariants = customParameterVariants.Select(name => BlueprintTool.GetRef<AnyBlueprintReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintParametrizedFeature.CustomParameterVariants"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="customParameterVariants"><see cref="Kingmaker.Blueprints.BlueprintScriptableObject"/></param>
    [Generated]
    public ParametrizedFeatureConfigurator AddToCustomParameterVariants(params string[] customParameterVariants)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CustomParameterVariants = CommonTool.Append(bp.CustomParameterVariants, customParameterVariants.Select(name => BlueprintTool.GetRef<AnyBlueprintReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintParametrizedFeature.CustomParameterVariants"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="customParameterVariants"><see cref="Kingmaker.Blueprints.BlueprintScriptableObject"/></param>
    [Generated]
    public ParametrizedFeatureConfigurator RemoveFromCustomParameterVariants(params string[] customParameterVariants)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = customParameterVariants.Select(name => BlueprintTool.GetRef<AnyBlueprintReference>(name));
            bp.CustomParameterVariants =
                bp.CustomParameterVariants
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintParametrizedFeature.HasNoSuchFeature"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ParametrizedFeatureConfigurator SetHasNoSuchFeature(bool hasNoSuchFeature)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HasNoSuchFeature = hasNoSuchFeature;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintParametrizedFeature.IgnoreParameterFeaturePrerequisites"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ParametrizedFeatureConfigurator SetIgnoreParameterFeaturePrerequisites(bool ignoreParameterFeaturePrerequisites)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IgnoreParameterFeaturePrerequisites = ignoreParameterFeaturePrerequisites;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintParametrizedFeature.BlueprintParameterVariants"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blueprintParameterVariants"><see cref="Kingmaker.Blueprints.BlueprintScriptableObject"/></param>
    [Generated]
    public ParametrizedFeatureConfigurator SetBlueprintParameterVariants(string[]? blueprintParameterVariants)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BlueprintParameterVariants = blueprintParameterVariants.Select(name => BlueprintTool.GetRef<AnyBlueprintReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintParametrizedFeature.BlueprintParameterVariants"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blueprintParameterVariants"><see cref="Kingmaker.Blueprints.BlueprintScriptableObject"/></param>
    [Generated]
    public ParametrizedFeatureConfigurator AddToBlueprintParameterVariants(params string[] blueprintParameterVariants)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BlueprintParameterVariants = CommonTool.Append(bp.BlueprintParameterVariants, blueprintParameterVariants.Select(name => BlueprintTool.GetRef<AnyBlueprintReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintParametrizedFeature.BlueprintParameterVariants"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blueprintParameterVariants"><see cref="Kingmaker.Blueprints.BlueprintScriptableObject"/></param>
    [Generated]
    public ParametrizedFeatureConfigurator RemoveFromBlueprintParameterVariants(params string[] blueprintParameterVariants)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = blueprintParameterVariants.Select(name => BlueprintTool.GetRef<AnyBlueprintReference>(name));
            bp.BlueprintParameterVariants =
                bp.BlueprintParameterVariants
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintParametrizedFeature.m_CachedItems"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ParametrizedFeatureConfigurator SetCachedItems(FeatureUIData[]? cachedItems)
    {
      ValidateParam(cachedItems);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedItems = cachedItems;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintParametrizedFeature.m_CachedItems"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ParametrizedFeatureConfigurator AddToCachedItems(params FeatureUIData[] cachedItems)
    {
      ValidateParam(cachedItems);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedItems = CommonTool.Append(bp.m_CachedItems, cachedItems ?? new FeatureUIData[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintParametrizedFeature.m_CachedItems"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ParametrizedFeatureConfigurator RemoveFromCachedItems(params FeatureUIData[] cachedItems)
    {
      ValidateParam(cachedItems);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedItems = bp.m_CachedItems.Where(item => !cachedItems.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Adds <see cref="AddParametrizedClassSkill"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddParametrizedClassSkill))]
    public ParametrizedFeatureConfigurator AddParametrizedClassSkill(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddParametrizedClassSkill();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddParametrizedStatBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddParametrizedStatBonus))]
    public ParametrizedFeatureConfigurator AddParametrizedStatBonus(
        ContextValue? value = null,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);
    
      var component = new AddParametrizedStatBonus();
      component.Value = value ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityFocusParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityFocusParametrized))]
    public ParametrizedFeatureConfigurator AddAbilityFocusParametrized(
        bool spellsOnly = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityFocusParametrized();
      component.SpellsOnly = spellsOnly;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddFeatureParametrized))]
    public ParametrizedFeatureConfigurator AddFeatureParametrized(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddFeatureParametrized();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureToPetParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddFeatureToPetParametrized))]
    public ParametrizedFeatureConfigurator AddFeatureToPetParametrized(
        PetType petType = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddFeatureToPetParametrized();
      component.PetType = petType;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ExpandedArsenalMagicSchools"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ExpandedArsenalMagicSchools))]
    public ParametrizedFeatureConfigurator AddExpandedArsenalMagicSchools(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ExpandedArsenalMagicSchools();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="FullWeaponMasterySkeletonParametrized"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="focus"><see cref="Kingmaker.Blueprints.Classes.Selection.BlueprintParametrizedFeature"/></param>
    /// <param name="specialization"><see cref="Kingmaker.Blueprints.Classes.Selection.BlueprintParametrizedFeature"/></param>
    /// <param name="greaterFocus"><see cref="Kingmaker.Blueprints.Classes.Selection.BlueprintParametrizedFeature"/></param>
    /// <param name="greaterSpecialization"><see cref="Kingmaker.Blueprints.Classes.Selection.BlueprintParametrizedFeature"/></param>
    /// <param name="improvedCritical"><see cref="Kingmaker.Blueprints.Classes.Selection.BlueprintParametrizedFeature"/></param>
    /// <param name="weaponMastery"><see cref="Kingmaker.Blueprints.Classes.Selection.BlueprintParametrizedFeature"/></param>
    /// <param name="greaterFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(FullWeaponMasterySkeletonParametrized))]
    public ParametrizedFeatureConfigurator AddFullWeaponMasterySkeletonParametrized(
        string? focus = null,
        string? specialization = null,
        string? greaterFocus = null,
        string? greaterSpecialization = null,
        string? improvedCritical = null,
        string? weaponMastery = null,
        string? greaterFeature = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new FullWeaponMasterySkeletonParametrized();
      component.m_Focus = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(focus);
      component.m_Specialization = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(specialization);
      component.m_GreaterFocus = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(greaterFocus);
      component.m_GreaterSpecialization = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(greaterSpecialization);
      component.m_ImprovedCritical = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(improvedCritical);
      component.m_WeaponMastery = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(weaponMastery);
      component.m_GreaterFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(greaterFeature);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ImprovedCriticalEdgeParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ImprovedCriticalEdgeParametrized))]
    public ParametrizedFeatureConfigurator AddImprovedCriticalEdgeParametrized(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ImprovedCriticalEdgeParametrized();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ImprovedCriticalMythicParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ImprovedCriticalMythicParametrized))]
    public ParametrizedFeatureConfigurator AddImprovedCriticalMythicParametrized(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ImprovedCriticalMythicParametrized();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ImprovedCriticalParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ImprovedCriticalParametrized))]
    public ParametrizedFeatureConfigurator AddImprovedCriticalParametrized(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ImprovedCriticalParametrized();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="KensaiChosenWeapon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="focus"><see cref="Kingmaker.Blueprints.Classes.Selection.BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(KensaiChosenWeapon))]
    public ParametrizedFeatureConfigurator AddKensaiChosenWeapon(
        string? focus = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new KensaiChosenWeapon();
      component.m_Focus = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(focus);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="LearnSpellParametrized"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellcasterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="spellList"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellList"/></param>
    [Generated]
    [Implements(typeof(LearnSpellParametrized))]
    public ParametrizedFeatureConfigurator AddLearnSpellParametrized(
        string? spellcasterClass = null,
        string? spellList = null,
        bool specificSpellLevel = default,
        int spellLevelPenalty = default,
        int spellLevel = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new LearnSpellParametrized();
      component.m_SpellcasterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(spellcasterClass);
      component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(spellList);
      component.SpecificSpellLevel = specificSpellLevel;
      component.SpellLevelPenalty = spellLevelPenalty;
      component.SpellLevel = spellLevel;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SavesFixerParamSpellSchool"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavesFixerParamSpellSchool))]
    public ParametrizedFeatureConfigurator AddSavesFixerParamSpellSchool(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SavesFixerParamSpellSchool();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SchoolMasteryParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SchoolMasteryParametrized))]
    public ParametrizedFeatureConfigurator AddSchoolMasteryParametrized(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SchoolMasteryParametrized();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SpellFocusParametrized"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="mythicFocus"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SpellFocusParametrized))]
    public ParametrizedFeatureConfigurator AddSpellFocusParametrized(
        int bonusDC = default,
        ModifierDescriptor descriptor = default,
        string? mythicFocus = null,
        bool spellsOnly = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SpellFocusParametrized();
      component.BonusDC = bonusDC;
      component.Descriptor = descriptor;
      component.m_MythicFocus = BlueprintTool.GetRef<BlueprintUnitFactReference>(mythicFocus);
      component.SpellsOnly = spellsOnly;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SpellSpecializationParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpellSpecializationParametrized))]
    public ParametrizedFeatureConfigurator AddSpellSpecializationParametrized(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SpellSpecializationParametrized();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponFocusParametrized"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="mythicFocus"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(WeaponFocusParametrized))]
    public ParametrizedFeatureConfigurator AddWeaponFocusParametrized(
        string? mythicFocus = null,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponFocusParametrized();
      component.m_MythicFocus = BlueprintTool.GetRef<BlueprintUnitFactReference>(mythicFocus);
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponMasteryParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponMasteryParametrized))]
    public ParametrizedFeatureConfigurator AddWeaponMasteryParametrized(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponMasteryParametrized();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponSpecializationParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponSpecializationParametrized))]
    public ParametrizedFeatureConfigurator AddWeaponSpecializationParametrized(
        bool mythic = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponSpecializationParametrized();
      component.Mythic = mythic;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}

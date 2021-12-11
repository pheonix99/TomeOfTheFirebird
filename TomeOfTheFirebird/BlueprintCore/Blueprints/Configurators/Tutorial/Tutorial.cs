using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using Kingmaker.PubSubSystem;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.Settings;
using Kingmaker.Tutorial;
using Kingmaker.Tutorial.Solvers;
using Kingmaker.Tutorial.Triggers;
using Kingmaker.UI.Kingdom;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Buffs;
using System;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Tutorial
{
  /// <summary>
  /// Configurator for <see cref="BlueprintTutorial"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTutorial))]
  public class TutorialConfigurator : BaseFactConfigurator<BlueprintTutorial, TutorialConfigurator>
  {
    private TutorialConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TutorialConfigurator For(string name)
    {
      return new TutorialConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TutorialConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintTutorial>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.m_Picture"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetPicture(SpriteLink picture)
    {
      ValidateParam(picture);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Picture = picture;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.m_Video"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetVideo(VideoLink video)
    {
      ValidateParam(video);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Video = video;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.m_TitleText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetTitleText(LocalizedString? titleText)
    {
      ValidateParam(titleText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TitleText = titleText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.m_TriggerText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetTriggerText(LocalizedString? triggerText)
    {
      ValidateParam(triggerText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TriggerText = triggerText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.m_DescriptionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetDescriptionText(LocalizedString? descriptionText)
    {
      ValidateParam(descriptionText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DescriptionText = descriptionText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.m_SolutionFoundText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetSolutionFoundText(LocalizedString? solutionFoundText)
    {
      ValidateParam(solutionFoundText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SolutionFoundText = solutionFoundText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.m_SolutionNotFoundText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetSolutionNotFoundText(LocalizedString? solutionNotFoundText)
    {
      ValidateParam(solutionNotFoundText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SolutionNotFoundText = solutionNotFoundText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.Tag"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetTag(TutorialTag tag)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Tag = tag;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.Priority"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetPriority(int priority)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Priority = priority;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.Limit"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetLimit(int limit)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Limit = limit;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.Frequency"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetFrequency(int frequency)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Frequency = frequency;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.SetCooldown"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetCooldown(bool setCooldown)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SetCooldown = setCooldown;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.IgnoreCooldown"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetIgnoreCooldown(bool ignoreCooldown)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IgnoreCooldown = ignoreCooldown;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.Windowed"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetWindowed(bool windowed)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Windowed = windowed;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.DisableAnalyticsTracking"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetDisableAnalyticsTracking(bool disableAnalyticsTracking)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DisableAnalyticsTracking = disableAnalyticsTracking;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.EncyclopediaReference"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="encyclopediaReference"><see cref="Kingmaker.Blueprints.Encyclopedia.BlueprintEncyclopediaPage"/></param>
    [Generated]
    public TutorialConfigurator SetEncyclopediaReference(string? encyclopediaReference)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.EncyclopediaReference = BlueprintTool.GetRef<BlueprintEncyclopediaPageReference>(encyclopediaReference);
          });
    }

    /// <summary>
    /// Adds <see cref="TutorialPage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialPage))]
    public TutorialConfigurator AddTutorialPage(
        SpriteLink picture,
        VideoLink video,
        LocalizedString? titleText = null,
        LocalizedString? triggerText = null,
        LocalizedString? descriptionText = null,
        LocalizedString? solutionFoundText = null,
        LocalizedString? solutionNotFoundText = null)
    {
      ValidateParam(picture);
      ValidateParam(video);
      ValidateParam(titleText);
      ValidateParam(triggerText);
      ValidateParam(descriptionText);
      ValidateParam(solutionFoundText);
      ValidateParam(solutionNotFoundText);
    
      var component = new TutorialPage();
      component.m_Picture = picture;
      component.m_Video = video;
      component.m_TitleText = titleText ?? Constants.Empty.String;
      component.m_TriggerText = triggerText ?? Constants.Empty.String;
      component.m_DescriptionText = descriptionText ?? Constants.Empty.String;
      component.m_SolutionFoundText = solutionFoundText ?? Constants.Empty.String;
      component.m_SolutionNotFoundText = solutionNotFoundText ?? Constants.Empty.String;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerAbilityDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerAbilityDamage))]
    public TutorialConfigurator AddTutorialTriggerAbilityDamage(
        bool drain = default,
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerAbilityDamage();
      component.Drain = drain;
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerAffectedByAreaEffect"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerAffectedByAreaEffect))]
    public TutorialConfigurator AddTutorialTriggerAffectedByAreaEffect(
        SpellDescriptorWrapper spellDescriptors,
        bool needAllDescriptors = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerAffectedByAreaEffect();
      component.SpellDescriptors = spellDescriptors;
      component.NeedAllDescriptors = needAllDescriptors;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerArcaneSpellFailure"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerArcaneSpellFailure))]
    public TutorialConfigurator AddTutorialTriggerArcaneSpellFailure(
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerArcaneSpellFailure();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerAreaLoaded"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="area"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerAreaLoaded))]
    public TutorialConfigurator AddTutorialTriggerAreaLoaded(
        string? area = null,
        ConditionsBuilder? condition = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerAreaLoaded();
      component.m_Area = BlueprintTool.GetRef<BlueprintAreaReference>(area);
      component.m_Condition = condition?.Build() ?? Constants.Empty.Conditions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerArmorCheckPenalty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerArmorCheckPenalty))]
    public TutorialConfigurator AddTutorialTriggerArmorCheckPenalty(
        float penaltyTriggerPercent = default,
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerArmorCheckPenalty();
      component.PenaltyTriggerPercent = penaltyTriggerPercent;
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerArmorDexBonusLimiter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerArmorDexBonusLimiter))]
    public TutorialConfigurator AddTutorialTriggerArmorDexBonusLimiter(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerArmorDexBonusLimiter();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerAttackFlatFootedTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerAttackFlatFootedTarget))]
    public TutorialConfigurator AddTutorialTriggerAttackFlatFootedTarget(
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerAttackFlatFootedTarget();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerAttackOfOpportunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerAttackOfOpportunity))]
    public TutorialConfigurator AddTutorialTriggerAttackOfOpportunity(
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerAttackOfOpportunity();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerBuffAttached"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buffs"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerBuffAttached))]
    public TutorialConfigurator AddTutorialTriggerBuffAttached(
        SpellDescriptorWrapper triggerDescriptors,
        bool needAllDescriptors = default,
        bool fromList = default,
        string[]? buffs = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerBuffAttached();
      component.TriggerDescriptors = triggerDescriptors;
      component.NeedAllDescriptors = needAllDescriptors;
      component.FromList = fromList;
      component.Buffs = buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerCanBuffAlly"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="triggerAreas"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    /// <param name="ability"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerCanBuffAlly))]
    public TutorialConfigurator AddTutorialTriggerCanBuffAlly(
        string[]? triggerAreas = null,
        string? ability = null,
        bool checkTankStat = default,
        bool allowItemsWithSpell = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerCanBuffAlly();
      component.m_TriggerAreas = triggerAreas.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name)).ToArray();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.m_CheckTankStat = checkTankStat;
      component.m_AllowItemsWithSpell = allowItemsWithSpell;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerCanReadScrollByNPC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="scrolls"><see cref="Kingmaker.Blueprints.Items.Equipment.BlueprintItemEquipmentUsable"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerCanReadScrollByNPC))]
    public TutorialConfigurator AddTutorialTriggerCanReadScrollByNPC(
        string[]? scrolls = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerCanReadScrollByNPC();
      component.m_Scrolls = scrolls.Select(name => BlueprintTool.GetRef<BlueprintItemEquipmentUsableReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerConditionImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerConditionImmunity))]
    public TutorialConfigurator AddTutorialTriggerConditionImmunity(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerConditionImmunity();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerCriticalHit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerCriticalHit))]
    public TutorialConfigurator AddTutorialTriggerCriticalHit(
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerCriticalHit();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerDamageAllyWithSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerDamageAllyWithSpell))]
    public TutorialConfigurator AddTutorialTriggerDamageAllyWithSpell(
        string[]? spells = null,
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerDamageAllyWithSpell();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerDamageFromWeapon"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerDamageFromWeapon))]
    public TutorialConfigurator AddTutorialTriggerDamageFromWeapon(
        TutorialContext savedContext,
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        bool allowFlatfootedTarget = default,
        bool allowACTouchAttack = default,
        bool showAfterCombat = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(savedContext);
    
      var component = new TutorialTriggerDamageFromWeapon();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      component.m_AllowFlatfootedTarget = allowFlatfootedTarget;
      component.m_AllowACTouchAttack = allowACTouchAttack;
      component.m_ShowAfterCombat = showAfterCombat;
      component.m_SavedContext = savedContext;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerDamageReduction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerDamageReduction))]
    public TutorialConfigurator AddTutorialTriggerDamageReduction(
        bool absoluteDR = default,
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerDamageReduction();
      component.AbsoluteDR = absoluteDR;
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerDeathDoor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerDeathDoor))]
    public TutorialConfigurator AddTutorialTriggerDeathDoor(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerDeathDoor();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerDialogMythicAnswer"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerDialogMythicAnswer))]
    public TutorialConfigurator AddTutorialTriggerDialogMythicAnswer(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerDialogMythicAnswer();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEmptySkillSlotOnRest"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerEmptySkillSlotOnRest))]
    public TutorialConfigurator AddTutorialTriggerEmptySkillSlotOnRest(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerEmptySkillSlotOnRest();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnemyHasAnyFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enemyFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerEnemyHasAnyFact))]
    public TutorialConfigurator AddTutorialTriggerEnemyHasAnyFact(
        string[]? enemyFacts = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerEnemyHasAnyFact();
      component.m_EnemyFacts = enemyFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnemyHasBlindsight"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buffs"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerEnemyHasBlindsight))]
    public TutorialConfigurator AddTutorialTriggerEnemyHasBlindsight(
        UnitEntityData unit,
        Buff partyBuff,
        string[]? buffs = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(unit);
      ValidateParam(partyBuff);
    
      var component = new TutorialTriggerEnemyHasBlindsight();
      component.m_Unit = unit;
      component.m_PartyBuff = partyBuff;
      component.m_Buffs = buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnemyHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enemyFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    /// <param name="spells"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerEnemyHasFact))]
    public TutorialConfigurator AddTutorialTriggerEnemyHasFact(
        UnitEntityData unit,
        string? enemyFact = null,
        string[]? spells = null,
        bool allowItemsWithSpell = default)
    {
      ValidateParam(unit);
    
      var component = new TutorialTriggerEnemyHasFact();
      component.m_Unit = unit;
      component.m_EnemyFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(enemyFact);
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_AllowItemsWithSpell = allowItemsWithSpell;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnemyHasRegeneration"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerEnemyHasRegeneration))]
    public TutorialConfigurator AddTutorialTriggerEnemyHasRegeneration(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerEnemyHasRegeneration();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnemyHasVulnerability"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerEnemyHasVulnerability))]
    public TutorialConfigurator AddTutorialTriggerEnemyHasVulnerability(
        string descriptor,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerEnemyHasVulnerability();
      component.m_Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnergyDrain"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerEnergyDrain))]
    public TutorialConfigurator AddTutorialTriggerEnergyDrain(
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerEnergyDrain();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnergyImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerEnergyImmunity))]
    public TutorialConfigurator AddTutorialTriggerEnergyImmunity(
        bool fromSpell = default,
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerEnergyImmunity();
      component.FromSpell = fromSpell;
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnergyResistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerEnergyResistance))]
    public TutorialConfigurator AddTutorialTriggerEnergyResistance(
        bool fromSpell = default,
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerEnergyResistance();
      component.FromSpell = fromSpell;
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerExtraAttackAfterLevelUp"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerExtraAttackAfterLevelUp))]
    public TutorialConfigurator AddTutorialTriggerExtraAttackAfterLevelUp(
        UnitEntityData triggerUnit,
        int startPrimaryAttackCount = default,
        int startSecondaryAttackCount = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(triggerUnit);
    
      var component = new TutorialTriggerExtraAttackAfterLevelUp();
      component.m_TriggerUnit = triggerUnit;
      component.m_StartPrimaryAttackCount = startPrimaryAttackCount;
      component.m_StartSecondaryAttackCount = startSecondaryAttackCount;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerFormationChangedBadly"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerFormationChangedBadly))]
    public TutorialConfigurator AddTutorialTriggerFormationChangedBadly(
        bool partyWasChanged = default,
        int tanksCount = default,
        float minTankDistance = default,
        GameDifficultyOption maxGameDifficulty = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerFormationChangedBadly();
      component.m_PartyWasChanged = partyWasChanged;
      component.TanksCount = tanksCount;
      component.MinTankDistance = minTankDistance;
      component.MaxGameDifficulty = maxGameDifficulty;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerHaveBetterEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerHaveBetterEquipment))]
    public TutorialConfigurator AddTutorialTriggerHaveBetterEquipment(
        int minGradeDiff = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerHaveBetterEquipment();
      component.MinGradeDiff = minGradeDiff;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerHealEnemyWithSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerHealEnemyWithSpell))]
    public TutorialConfigurator AddTutorialTriggerHealEnemyWithSpell(
        string[]? spells = null,
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerHealEnemyWithSpell();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerHealingScroll"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerHealingScroll))]
    public TutorialConfigurator AddTutorialTriggerHealingScroll(
        float unitLeftHealthPercent = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerHealingScroll();
      component.UnitLeftHealthPercent = unitLeftHealthPercent;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerItemIdentificationFailed"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerItemIdentificationFailed))]
    public TutorialConfigurator AddTutorialTriggerItemIdentificationFailed(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerItemIdentificationFailed();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerKingdomManagementOpened"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerKingdomManagementOpened))]
    public TutorialConfigurator AddTutorialTriggerKingdomManagementOpened(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerKingdomManagementOpened();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerKingdomTabSelected"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerKingdomTabSelected))]
    public TutorialConfigurator AddTutorialTriggerKingdomTabSelected(
        KingdomNavigationType type = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerKingdomTabSelected();
      component.m_Type = type;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerLowGroupHealth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerLowGroupHealth))]
    public TutorialConfigurator AddTutorialTriggerLowGroupHealth(
        float healSkillsLeftPercent = default,
        float averageGroupHealthPercent = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerLowGroupHealth();
      component.HealSkillsLeftPercent = healSkillsLeftPercent;
      component.AverageGroupHealthPercent = averageGroupHealthPercent;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerLowHitPoints"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerLowHitPoints))]
    public TutorialConfigurator AddTutorialTriggerLowHitPoints(
        float threshold = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerLowHitPoints();
      component.Threshold = threshold;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerMemorizeSpontaneousSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerMemorizeSpontaneousSpell))]
    public TutorialConfigurator AddTutorialTriggerMemorizeSpontaneousSpell(
        string? characterClass = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerMemorizeSpontaneousSpell();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerMissingPreciseShot"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerMissingPreciseShot))]
    public TutorialConfigurator AddTutorialTriggerMissingPreciseShot(
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerMissingPreciseShot();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerMissingTwoWeaponFighting"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerMissingTwoWeaponFighting))]
    public TutorialConfigurator AddTutorialTriggerMissingTwoWeaponFighting(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerMissingTwoWeaponFighting();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerMountAnimal"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerMountAnimal))]
    public TutorialConfigurator AddTutorialTriggerMountAnimal(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerMountAnimal();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerMultipleUnitsCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerMultipleUnitsCondition))]
    public TutorialConfigurator AddTutorialTriggerMultipleUnitsCondition(
        UnitCondition triggerCondition = default,
        int minimumUnitsCount = default,
        bool allowOnGlobalMap = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerMultipleUnitsCondition();
      component.TriggerCondition = triggerCondition;
      component.MinimumUnitsCount = minimumUnitsCount;
      component.AllowOnGlobalMap = allowOnGlobalMap;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewCrusaderArmy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerNewCrusaderArmy))]
    public TutorialConfigurator AddTutorialTriggerNewCrusaderArmy(
        int minimumNumberOfArmies = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerNewCrusaderArmy();
      component.m_MinimumNumberOfArmies = minimumNumberOfArmies;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewItemWithEnchantment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantment"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerNewItemWithEnchantment))]
    public TutorialConfigurator AddTutorialTriggerNewItemWithEnchantment(
        string? enchantment = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerNewItemWithEnchantment();
      component.m_Enchantment = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(enchantment);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewNotLearnedScroll"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerNewNotLearnedScroll))]
    public TutorialConfigurator AddTutorialTriggerNewNotLearnedScroll(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerNewNotLearnedScroll();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewRecipe"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerNewRecipe))]
    public TutorialConfigurator AddTutorialTriggerNewRecipe(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerNewRecipe();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewRodItem"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerNewRodItem))]
    public TutorialConfigurator AddTutorialTriggerNewRodItem(
        Metamagic triggerMetamagic = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerNewRodItem();
      component.TriggerMetamagic = triggerMetamagic;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewSpellWithoutRequiredMaterial"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerNewSpellWithoutRequiredMaterial))]
    public TutorialConfigurator AddTutorialTriggerNewSpellWithoutRequiredMaterial(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerNewSpellWithoutRequiredMaterial();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewWand"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerNewWand))]
    public TutorialConfigurator AddTutorialTriggerNewWand(
        string[]? spells = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerNewWand();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNoAutocastSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="recommendedAbilities"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    /// <param name="companions"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerNoAutocastSpell))]
    public TutorialConfigurator AddTutorialTriggerNoAutocastSpell(
        string[]? recommendedAbilities = null,
        string[]? companions = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerNoAutocastSpell();
      component.m_RecommendedAbilities = recommendedAbilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Companions = companions.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNonStackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerNonStackBonus))]
    public TutorialConfigurator AddTutorialTriggerNonStackBonus(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerNonStackBonus();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerOpenArmyRecruit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerOpenArmyRecruit))]
    public TutorialConfigurator AddTutorialTriggerOpenArmyRecruit(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerOpenArmyRecruit();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerOpenRestUI"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerOpenRestUI))]
    public TutorialConfigurator AddTutorialTriggerOpenRestUI(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerOpenRestUI();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerPartyEncumbrance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerPartyEncumbrance))]
    public TutorialConfigurator AddTutorialTriggerPartyEncumbrance(
        Encumbrance minTriggerEncumbrance = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerPartyEncumbrance();
      component.MinTriggerEncumbrance = minTriggerEncumbrance;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerSavingThrow"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerSavingThrow))]
    public TutorialConfigurator AddTutorialTriggerSavingThrow(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerSavingThrow();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerSkillCheck"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerSkillCheck))]
    public TutorialConfigurator AddTutorialTriggerSkillCheck(
        TutorialTriggerSkillCheck.ResultType triggerOnResult = default,
        bool skillRestriction = default,
        StatType skill = default,
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerSkillCheck();
      component.m_TriggerOnResult = triggerOnResult;
      component.SkillRestriction = skillRestriction;
      component.Skill = skill;
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerSneakAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerSneakAttack))]
    public TutorialConfigurator AddTutorialTriggerSneakAttack(
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerSneakAttack();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerSpellResistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerSpellResistance))]
    public TutorialConfigurator AddTutorialTriggerSpellResistance(
        SpellDescriptorWrapper descriptor,
        TutorialTriggerSpellResistance.Target triggerTarget = default,
        bool needAllDescriptors = default,
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerSpellResistance();
      component.TriggerTarget = triggerTarget;
      component.Descriptor = descriptor;
      component.NeedAllDescriptors = needAllDescriptors;
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerTacticalCombatEnd"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerTacticalCombatEnd))]
    public TutorialConfigurator AddTutorialTriggerTacticalCombatEnd(
        bool demonsWon = default,
        bool onlyGarrison = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerTacticalCombatEnd();
      component.m_DemonsWon = demonsWon;
      component.m_OnlyGarrison = onlyGarrison;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerTacticalCombatStart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enemyUnits"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerTacticalCombatStart))]
    public TutorialConfigurator AddTutorialTriggerTacticalCombatStart(
        bool enemyShouldHaveLeader = default,
        bool specifyEnemyUnits = default,
        bool playerShouldHaveLeader = default,
        string[]? enemyUnits = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerTacticalCombatStart();
      component.m_EnemyShouldHaveLeader = enemyShouldHaveLeader;
      component.m_SpecifyEnemyUnits = specifyEnemyUnits;
      component.m_PlayerShouldHaveLeader = playerShouldHaveLeader;
      component.m_EnemyUnits = enemyUnits.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerTargetRestriction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerTargetRestriction))]
    public TutorialConfigurator AddTutorialTriggerTargetRestriction(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerTargetRestriction();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerTouchAC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerTouchAC))]
    public TutorialConfigurator AddTutorialTriggerTouchAC(
        int touchACDifference = default,
        int missesInRow = default,
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerTouchAC();
      component.TouchACDifference = touchACDifference;
      component.MissesInRow = missesInRow;
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerTurnBaseModeActivated"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerTurnBaseModeActivated))]
    public TutorialConfigurator AddTutorialTriggerTurnBaseModeActivated(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerTurnBaseModeActivated();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUIEvent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerUIEvent))]
    public TutorialConfigurator AddTutorialTriggerUIEvent(
        UIEventType uIEvent = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerUIEvent();
      component.UIEvent = uIEvent;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerUnitCondition))]
    public TutorialConfigurator AddTutorialTriggerUnitCondition(
        UnitCondition triggerCondition = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerUnitCondition();
      component.TriggerCondition = triggerCondition;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitDeath"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerUnitDeath))]
    public TutorialConfigurator AddTutorialTriggerUnitDeath(
        bool isPet = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerUnitDeath();
      component.IsPet = isPet;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitDiedWithoutBardPerformance"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="performances"><see cref="Kingmaker.UnitLogic.ActivatableAbilities.BlueprintActivatableAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerUnitDiedWithoutBardPerformance))]
    public TutorialConfigurator AddTutorialTriggerUnitDiedWithoutBardPerformance(
        string[]? performances = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerUnitDiedWithoutBardPerformance();
      component.m_Performances = performances.Select(name => BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitEncumbrance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerUnitEncumbrance))]
    public TutorialConfigurator AddTutorialTriggerUnitEncumbrance(
        Encumbrance minTriggerEncumbrance = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerUnitEncumbrance();
      component.MinTriggerEncumbrance = minTriggerEncumbrance;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitLostAlignmentFeature"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerUnitLostAlignmentFeature))]
    public TutorialConfigurator AddTutorialTriggerUnitLostAlignmentFeature(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerUnitLostAlignmentFeature();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitWithSneakAttackJoinParty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerUnitWithSneakAttackJoinParty))]
    public TutorialConfigurator AddTutorialTriggerUnitWithSneakAttackJoinParty(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialTriggerUnitWithSneakAttackJoinParty();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialSolverAllFromTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialSolverAllFromTrigger))]
    public TutorialConfigurator AddTutorialSolverAllFromTrigger(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialSolverAllFromTrigger();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialSolverBestWeaponAgainstTarget"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintWeaponEnchantment"/></param>
    [Generated]
    [Implements(typeof(TutorialSolverBestWeaponAgainstTarget))]
    public TutorialConfigurator AddTutorialSolverBestWeaponAgainstTarget(
        bool checkRegeneration = default,
        bool checkEnchantment = default,
        string[]? enchantments = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialSolverBestWeaponAgainstTarget();
      component.CheckRegeneration = checkRegeneration;
      component.CheckEnchantment = checkEnchantment;
      component.m_Enchantments = enchantments.Select(name => BlueprintTool.GetRef<BlueprintWeaponEnchantmentReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialSolverItemFromTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialSolverItemFromTrigger))]
    public TutorialConfigurator AddTutorialSolverItemFromTrigger(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialSolverItemFromTrigger();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialSolverSpellFromList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialSolverSpellFromList))]
    public TutorialConfigurator AddTutorialSolverSpellFromList(
        string[]? spells = null,
        bool allowItems = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialSolverSpellFromList();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.AllowItems = allowItems;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialSolverSpellWithDamage"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ignoredSpells"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialSolverSpellWithDamage))]
    public TutorialConfigurator AddTutorialSolverSpellWithDamage(
        SpellDescriptorWrapper spellDescriptor,
        bool checkRegeneration = default,
        bool checkVulnerability = default,
        AttackTypeFlag attackType = default,
        bool onlyAoE = default,
        bool useDescriptor = default,
        bool needAllDescriptors = default,
        string[]? ignoredSpells = null,
        bool allowItems = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialSolverSpellWithDamage();
      component.CheckRegeneration = checkRegeneration;
      component.CheckVulnerability = checkVulnerability;
      component.AttackType = attackType;
      component.OnlyAoE = onlyAoE;
      component.UseDescriptor = useDescriptor;
      component.SpellDescriptor = spellDescriptor;
      component.NeedAllDescriptors = needAllDescriptors;
      component.IgnoredSpells = ignoredSpells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToList();
      component.AllowItems = allowItems;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TutorialSolverSpellWithDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialSolverSpellWithDescriptor))]
    public TutorialConfigurator AddTutorialSolverSpellWithDescriptor(
        SpellDescriptorWrapper spellDescriptors,
        bool needAllDescriptors = default,
        bool excludeOnlySelfTarget = default,
        bool allowItems = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TutorialSolverSpellWithDescriptor();
      component.SpellDescriptors = spellDescriptors;
      component.NeedAllDescriptors = needAllDescriptors;
      component.ExcludeOnlySelfTarget = excludeOnlySelfTarget;
      component.AllowItems = allowItems;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}

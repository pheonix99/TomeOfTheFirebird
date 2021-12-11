using BlueprintCore.Abilities.Restrictions.New;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.TurnBasedModifiers;
using Kingmaker.Craft;
using Kingmaker.Designers.Mechanics.Recommendations;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UI.UnitSettings.Blueprints;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using Kingmaker.Visual.HitSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Abilities
{
  /// <summary>Configurator for <see cref="BlueprintAbility"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAbility))]
  public class AbilityConfigurator : BaseUnitFactConfigurator<BlueprintAbility, AbilityConfigurator>
  {
    private AbilityConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AbilityConfigurator For(string name) { return new AbilityConfigurator(name); }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AbilityConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintAbility>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.m_DefaultAiAction"/>
    /// </summary>
    /// 
    /// <param name="aiAction">
    /// <see cref="BlueprintAiCastSpell"/> Has its <see cref="BlueprintAiCastSpell.m_Ability"/> updated to this blueprint.
    /// </param>
    public AbilityConfigurator SetAiAction(string aiAction)
    {
      OnConfigureInternal(
          blueprint =>
          {
            var aiBlueprint = BlueprintTool.Get<BlueprintAiCastSpell>(aiAction);
            aiBlueprint.m_Ability = Blueprint.ToReference<BlueprintAbilityReference>();
            blueprint.m_DefaultAiAction = aiBlueprint.ToReference<BlueprintAiCastSpell.Reference>();
          });
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.Type"/>
    /// </summary>
    public AbilityConfigurator SetType(AbilityType type)
    {
      OnConfigureInternal(blueprint => blueprint.Type = type);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.Range"/>
    /// </summary>
    /// 
    /// <remarks>Use <see cref="SetCustomRange(int)"/> for <see cref="AbilityRange.Custom"/>.</remarks>
    public AbilityConfigurator SetRange(AbilityRange range)
    {
      if (range == AbilityRange.Custom)
      {
        throw new InvalidOperationException("Use SetCustomRange() for AbilityRange.Custom.");
      }
      OnConfigureInternal(blueprint => blueprint.Range = range);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.Range"/> and <see cref="BlueprintAbility.CustomRange"/>
    /// </summary>
    public AbilityConfigurator SetCustomRange(int rangeInFeet)
    {
      OnConfigureInternal(
          blueprint =>
          {
            blueprint.Range = AbilityRange.Custom;
            blueprint.CustomRange = new Feet(rangeInFeet);
          });
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.ShowNameForVariant"/> and <see cref="BlueprintAbility.OnlyForAllyCaster"/>
    /// </summary>
    public AbilityConfigurator ShowNameForVariant(bool showName = true, bool onlyForAlly = false)
    {
      OnConfigureInternal(
          blueprint =>
          {
            blueprint.ShowNameForVariant = showName;
            blueprint.OnlyForAllyCaster = onlyForAlly;
          });
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.CanTargetPoint"/>, <see cref="BlueprintAbility.CanTargetEnemies"/>,
    /// <see cref="BlueprintAbility.CanTargetFriends"/>, and <see cref="BlueprintAbility.CanTargetSelf"/>
    /// </summary>
    public AbilityConfigurator AllowTargeting(
        bool? point = null, bool? enemies = null, bool? friends = null, bool? self = null)
    {
      OnConfigureInternal(
          blueprint =>
          {
            blueprint.CanTargetPoint = point ?? blueprint.CanTargetPoint;
            blueprint.CanTargetEnemies = enemies ?? blueprint.CanTargetEnemies;
            blueprint.CanTargetFriends = friends ?? blueprint.CanTargetFriends;
            blueprint.CanTargetSelf = self ?? blueprint.CanTargetSelf;
          });
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.SpellResistance"/>
    /// </summary>
    public AbilityConfigurator ApplySpellResistance(bool applySR = true)
    {
      OnConfigureInternal(blueprint => blueprint.SpellResistance = applySR);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.ActionBarAutoFillIgnored"/>
    /// </summary>
    public AbilityConfigurator AutoFillActionBar(bool autoFill = true)
    {
      OnConfigureInternal(blueprint => blueprint.ActionBarAutoFillIgnored = !autoFill);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.Hidden"/>
    /// </summary>
    public AbilityConfigurator HideInUi(bool hide = true)
    {
      OnConfigureInternal(blueprint => blueprint.Hidden = hide);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.NeedEquipWeapons"/>
    /// </summary>
    public AbilityConfigurator RequireWeapon(bool requireWeapon = true)
    {
      OnConfigureInternal(blueprint => blueprint.NeedEquipWeapons = requireWeapon);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.NotOffensive"/>
    /// </summary>
    public AbilityConfigurator IsOffensive(bool offensive = true)
    {
      OnConfigureInternal(blueprint => blueprint.NotOffensive = !offensive);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.EffectOnAlly"/> and <see cref="BlueprintAbility.EffectOnEnemy"/>
    /// </summary>
    public AbilityConfigurator SetEffectOn(
        AbilityEffectOnUnit? onAlly = null, AbilityEffectOnUnit? onEnemy = null)
    {
      OnConfigureInternal(
          blueprint =>
          {
            blueprint.EffectOnAlly = onAlly ?? blueprint.EffectOnAlly;
            blueprint.EffectOnEnemy = onEnemy ?? blueprint.EffectOnEnemy;
          });
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.m_Parent"/>
    /// </summary>
    /// 
    /// <param name="name"><see cref="BlueprintAbility"/> Has this blueprint added as a variant.</param>
    public AbilityConfigurator SetParent(string name)
    {
      OnConfigureInternal(blueprint => SetParent(BlueprintTool.Get<BlueprintAbility>(name)));
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.m_Parent"/>
    /// </summary>
    /// 
    /// <remarks>The parent will be updated to remove this blueprint as a variant.</remarks>
    public AbilityConfigurator ClearParent()
    {
      OnConfigureInternal(blueprint => RemoveParent());
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.Animation"/>
    /// </summary>
    public AbilityConfigurator SetAnimationStyle(UnitAnimationActionCastSpell.CastAnimationStyle style)
    {
      OnConfigureInternal(blueprint => blueprint.Animation = style);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.ActionType"/> and <see cref="BlueprintAbility.HasFastAnimation"/>
    /// </summary>
    public AbilityConfigurator SetActionType(UnitCommand.CommandType type, bool? hasFastAnimation = null)
    {
      OnConfigureInternal(
          blueprint =>
          {
            blueprint.ActionType = type;
            blueprint.HasFastAnimation = hasFastAnimation ?? blueprint.HasFastAnimation;
          });
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.AvailableMetamagic"/>
    /// </summary>
    public AbilityConfigurator SetMetamagics(params Metamagic[] metamagics)
    {
      Metamagic availableMetamagic = 0;
      metamagics.ForEach(m => availableMetamagic |= m);
      return OnConfigureInternal(bp => bp.AvailableMetamagic = availableMetamagic);
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAbility.AvailableMetamagic"/>
    /// </summary>
    public AbilityConfigurator AddToMetamagics(params Metamagic[] metamagics)
    {
      return OnConfigureInternal(bp => metamagics.ForEach(m => bp.AvailableMetamagic |= m));
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAbility.AvailableMetamagic"/>
    /// </summary>
    public AbilityConfigurator RemoveFromMetamagics(params Metamagic[] metamagics)
    {
      return OnConfigureInternal(bp => metamagics.ForEach(m => bp.AvailableMetamagic &= ~m));
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.m_IsFullRoundAction"/>
    /// </summary>
    public AbilityConfigurator MakeFullRound(bool fullRound = true)
    {
      OnConfigureInternal(blueprint => blueprint.m_IsFullRoundAction = fullRound);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.LocalizedDuration"/>
    /// </summary>
    public AbilityConfigurator SetDurationText(LocalizedString duration)
    {
      OnConfigureInternal(blueprint => blueprint.LocalizedDuration = duration);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.LocalizedSavingThrow"/>
    /// </summary>
    public AbilityConfigurator SetSavingThrowText(LocalizedString savingThrow)
    {
      OnConfigureInternal(blueprint => blueprint.LocalizedSavingThrow = savingThrow);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.MaterialComponent"/>
    /// </summary>
    public AbilityConfigurator SetMaterialComponent(BlueprintAbility.MaterialComponentData component)
    {
      OnConfigureInternal(blueprint => blueprint.MaterialComponent = component);
      return this;
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbility.DisableLog"/>
    /// </summary>
    public AbilityConfigurator HideFromLog(bool hide = true)
    {
      OnConfigureInternal(blueprint => blueprint.DisableLog = hide);
      return this;
    }


    /// <summary>
    /// Adds <see cref="AbilityCasterAlignment"/>
    /// </summary>
    /// 
    /// <param name="ignoreFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    [Implements(typeof(AbilityCasterAlignment))]
    public AbilityConfigurator RequireCasterAlignment(AlignmentMaskType alignment, string? ignoreFact = null)
    {
      var hasAlignment = new AbilityCasterAlignment { Alignment = alignment };
      if (ignoreFact != null)
      {
        hasAlignment.m_IgnoreFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(ignoreFact);
      }
      return AddComponent(hasAlignment);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterHasFacts"/>
    /// </summary>
    /// 
    /// <param name="facts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    [Implements(typeof(AbilityCasterHasFacts))]
    public AbilityConfigurator RequireCasterFacts(params string[] facts)
    {
      var hasFacts = new AbilityCasterHasFacts
      {
        m_Facts = facts.Select(fact => BlueprintTool.GetRef<BlueprintUnitFactReference>(fact)).ToArray()
      };
      return AddComponent(hasFacts);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterHasNoFacts"/>
    /// </summary>
    /// 
    /// <param name="facts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    [Implements(typeof(AbilityCasterHasNoFacts))]
    public AbilityConfigurator RequireCasterHasNoFacts(params string[] facts)
    {
      var hasNoFacts = new AbilityCasterHasNoFacts
      {
        m_Facts = facts.Select(fact => BlueprintTool.GetRef<BlueprintUnitFactReference>(fact)).ToArray()
      };
      return AddComponent(hasNoFacts);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterHasChosenWeapon"/>
    /// </summary>
    /// 
    /// <remarks>
    /// Requires the caster to wield their chosen weapon, i.e. the weapon in which they have Weapon Focus or Weapon
    /// Specialization.
    /// </remarks>
    /// 
    /// <param name="parameterizedWeaponFeature"><see cref="Kingmaker.Blueprints.Classes.Selection.BlueprintParametrizedFeature">BlueprintParametrizedFeature</see></param>
    /// <param name="ignoreFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    [Implements(typeof(AbilityCasterHasChosenWeapon))]
    public AbilityConfigurator RequireCasterHasChosenWeapon(
        string parameterizedWeaponFeature, string? ignoreFact = null)
    {
      var hasChosenWeapon = new AbilityCasterHasChosenWeapon
      {
        m_ChosenWeaponFeature = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(parameterizedWeaponFeature)
      };
      if (ignoreFact != null)
      {
        hasChosenWeapon.m_IgnoreWeaponFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(ignoreFact);
      }
      return AddComponent(hasChosenWeapon);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterHasWeaponWithRangeType"/>
    /// </summary>
    [Implements(typeof(AbilityCasterHasWeaponWithRangeType))]
    public AbilityConfigurator RequireCasterWeaponRange(WeaponRangeType range)
    {
      var hasWeaponRange = new AbilityCasterHasWeaponWithRangeType { RangeType = range };
      return AddComponent(hasWeaponRange);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterInCombat"/>
    /// </summary>
    [Implements(typeof(AbilityCasterInCombat))]
    public AbilityConfigurator RequireCasterInCombat(bool requireInCombat = true)
    {
      var isInCombat = new AbilityCasterInCombat { Not = !requireInCombat };
      return AddComponent(isInCombat);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterIsOnFavoredTerrain"/>
    /// </summary>
    /// 
    /// <param name="ignoreFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    [Implements(typeof(AbilityCasterIsOnFavoredTerrain))]
    public AbilityConfigurator RequireCasterOnFavoredTerrain(string? ignoreFeature = null)
    {
      var onFavoredTerrain = new AbilityCasterIsOnFavoredTerrain();
      if (ignoreFeature != null)
      {
        onFavoredTerrain.m_IgnoreFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(ignoreFeature);
      }
      return AddComponent(onFavoredTerrain);
    }

    /// <summary>
    /// Adds <see cref="TargetHasBuffsFromCaster"/>
    /// </summary>
    /// 
    /// <param name="buffs"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff">BlueprintBuff</see></param>
    [Implements(typeof(TargetHasBuffsFromCaster))]
    public AbilityConfigurator RequireTargetHasBuffsFromCaster(string[] buffs, bool requireAllBuffs = false)
    {
      var hasBuffs = new TargetHasBuffsFromCaster
      {
        Buffs = buffs.Select(buff => BlueprintTool.GetRef<BlueprintBuffReference>(buff)).ToArray(),
        RequireAllBuffs = requireAllBuffs
      };
      return AddComponent(hasBuffs);
    }

    /// <summary>
    /// Adds <see cref="AbilityCanTargetDead"/>
    /// </summary>
    [Implements(typeof(AbilityCanTargetDead))]
    public AbilityConfigurator CanTargetDead()
    {
      return AddUniqueComponent(new AbilityCanTargetDead(), ComponentMerge.Skip);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliveredByWeapon"/>
    /// </summary>
    [DeliverEffectAttr]
    [Implements(typeof(AbilityDeliveredByWeapon))]
    public AbilityConfigurator DeliveredByWeapon()
    {
      return AddUniqueComponent(new AbilityDeliveredByWeapon(), ComponentMerge.Skip);
    }

    /// <summary>
    /// Adds <see cref="AbilityEffectRunAction"/>
    /// </summary>
    /// 
    /// <remarks>Default Merge: Appends the given <see cref="Kingmaker.ElementsSystem.ActionList">ActionList</see></remarks>
    [ApplyEffectAttr]
    [Implements(typeof(AbilityEffectRunAction))]
    public AbilityConfigurator RunActions(
        ActionsBuilder actions,
        SavingThrowType savingThrow = SavingThrowType.Unknown,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        Action<BlueprintComponent, BlueprintComponent>? merge = null)
    {
      var run = new AbilityEffectRunAction
      {
        Actions = actions.Build(),
        SavingThrowType = savingThrow
      };
      return AddUniqueComponent(run, mergeBehavior, merge ?? MergeRunActions);
    }

    [Implements(typeof(AbilityEffectRunAction))]
    private static void MergeRunActions(BlueprintComponent current, BlueprintComponent other)
    {
      var source = current as AbilityEffectRunAction;
      var target = other as AbilityEffectRunAction;
      source!.Actions.Actions = CommonTool.Append(source.Actions.Actions, target!.Actions.Actions);
    }

    /// <summary>
    /// Adds <see cref="AbilityEffectMiss"/>
    /// </summary>
    /// 
    /// <remarks>Default Merge: Appends the given <see cref="Kingmaker.ElementsSystem.ActionList">ActionList</see></remarks>
    [Implements(typeof(AbilityEffectMiss))]
    public AbilityConfigurator OnMiss(
        ActionsBuilder actions,
        bool useTargetSelector = true,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        Action<BlueprintComponent, BlueprintComponent>? merge = null)
    {
      var onMiss = new AbilityEffectMiss
      {
        MissAction = actions.Build(),
        UseTargetSelector = useTargetSelector
      };
      return AddUniqueComponent(onMiss, mergeBehavior, merge ?? MergeMissActions);
    }

    [Implements(typeof(AbilityEffectMiss))]
    private static void MergeMissActions(BlueprintComponent current, BlueprintComponent other)
    {
      var source = current as AbilityEffectMiss;
      var target = other as AbilityEffectMiss;
      source!.MissAction.Actions = CommonTool.Append(source.MissAction.Actions, target!.MissAction.Actions);
    }

    /// <summary>
    /// Adds <see cref="AbilityExecuteActionOnCast"/>
    /// </summary>
    [Implements(typeof(AbilityExecuteActionOnCast))]
    public AbilityConfigurator OnCast(ActionsBuilder actions, ConditionsBuilder? checker = null)
    {
      var onCast = new AbilityExecuteActionOnCast
      {
        Conditions = checker?.Build() ?? Constants.Empty.Conditions,
        Actions = actions.Build()
      };
      return AddComponent(onCast);
    }

    /// <summary>
    /// Adds <see cref="SpellComponent"/>
    /// </summary>
    [Implements(typeof(SpellComponent))]
    public AbilityConfigurator SetSpellSchool(
        SpellSchool school,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? merge = null)
    {
      var schoolComponent = new SpellComponent { School = school };
      return AddUniqueComponent(schoolComponent, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="CantripComponent"/>
    /// </summary>
    [Implements(typeof(CantripComponent))]
    public AbilityConfigurator MakeCantrip()
    {
      return AddUniqueComponent(new CantripComponent(), ComponentMerge.Skip);
    }

    /// <summary>
    /// Removes <see cref="CantripComponent"/>
    /// </summary>
    [Implements(typeof(CantripComponent))]
    public AbilityConfigurator MakeNotCantrip()
    {
      return RemoveComponents(c => c is CantripComponent);
    }

    /// <summary>
    /// Adds or modifies <see cref="AbilityVariants"/>
    /// </summary>
    /// 
    /// <param name="abilities"><see cref="BlueprintAbility"/> Updates the parent of each ability to this blueprint</param>
    [Implements(typeof(AbilityVariants))]
    public AbilityConfigurator AddVariants(params string[] abilities)
    {
      return OnConfigureInternal(
          blueprint =>
              AddVariants(
                  blueprint, abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToList()));
    }

    [Implements(typeof(AbilityVariants))]
    private static void AddVariants(BlueprintAbility bp, List<BlueprintAbilityReference> variants)
    {
      var component = bp.GetComponent<AbilityVariants>();
      if (component is null)
      {
        component = new AbilityVariants();
        bp.AddComponents(component);
      }
      var bpRef = bp.ToReference<BlueprintAbilityReference>();
      variants.ForEach(reference => reference.Get().m_Parent = bpRef);
      component.m_Variants = CommonTool.Append(component.m_Variants, variants.ToArray());
    }

    /// <summary>
    /// Modifies <see cref="AbilityVariants"/>
    /// </summary>
    /// 
    /// <param name="abilities"><see cref="BlueprintAbility"/> Removes this blueprint as the parent of each ability</param>
    [Implements(typeof(AbilityVariants))]
    public AbilityConfigurator RemoveVariants(params string[] abilities)
    {
      return OnConfigureInternal(
          blueprint =>
              RemoveVariants(
                  blueprint, abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToList()));
    }

    [Implements(typeof(AbilityVariants))]
    private static void RemoveVariants(BlueprintAbility bp, List<BlueprintAbilityReference> variants)
    {
      var component = bp.GetComponent<AbilityVariants>();
      if (component is null) { return; }

      var nullRef = BlueprintTool.GetRef<BlueprintAbilityReference>(null!);
      variants.ForEach(
          reference =>
          {
            var ability = reference.Get();
            if (ability.m_Parent?.deserializedGuid == bp.AssetGuid) { ability.m_Parent = nullRef; }
          });
      component.m_Variants =
          component.m_Variants
              .Where(
                  reference => !variants.Exists(removeRef => reference.deserializedGuid == removeRef.deserializedGuid))
              .ToArray();
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig">ContextRankConfig</see>
    /// </summary>
    /// 
    /// <remarks>Use <see cref="Components.ContextRankConfigs">ContextRankConfigs</see> to create the config</remarks>
    [Implements(typeof(ContextRankConfig))]
    public AbilityConfigurator AddContextRankConfig(ContextRankConfig rankConfig)
    {
      return AddComponent(rankConfig);
    }

    /// <summary>
    /// Adds or modifies <see cref="SpellDescriptorComponent"/>
    /// </summary>
    [Implements(typeof(SpellDescriptorComponent))]
    public AbilityConfigurator AddSpellDescriptors(params SpellDescriptor[] descriptors)
    {
      return OnConfigureInternal(blueprint => AddSpellDescriptors(blueprint, descriptors.ToList()));
    }

    [Implements(typeof(SpellDescriptorComponent))]
    private static void AddSpellDescriptors(BlueprintScriptableObject bp, List<SpellDescriptor> descriptors)
    {
      var component = bp.GetComponent<SpellDescriptorComponent>();
      if (component is null)
      {
        component = new SpellDescriptorComponent();
        bp.AddComponents(component);
      }
      descriptors.ForEach(descriptor => component.Descriptor.m_IntValue |= (long)descriptor);
    }

    /// <summary>
    /// Modifies <see cref="SpellDescriptorComponent"/>
    /// </summary>
    [Implements(typeof(SpellDescriptorComponent))]
    public AbilityConfigurator RemoveSpellDescriptors(params SpellDescriptor[] descriptors)
    {
      return OnConfigureInternal(blueprint => RemoveSpellDescriptors(blueprint, descriptors.ToList()));
    }

    [Implements(typeof(SpellDescriptorComponent))]
    private static void RemoveSpellDescriptors(BlueprintScriptableObject bp, List<SpellDescriptor> descriptors)
    {
      var component = bp.GetComponent<SpellDescriptorComponent>();
      if (component is null) { return; }
      descriptors.ForEach(descriptor => component.Descriptor.m_IntValue &= ~(long)descriptor);
    }

    /// <summary>
    /// Adds <see cref="InPowerDismemberComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(InPowerDismemberComponent))]
    public AbilityConfigurator AddInPowerDismemberComponent(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new InPowerDismemberComponent();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SplitDismemberComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SplitDismemberComponent))]
    public AbilityConfigurator AddSplitDismemberComponent(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SplitDismemberComponent();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ActionPanelLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ActionPanelLogic))]
    public AbilityConfigurator AddActionPanelLogic(
        int priority = default,
        ConditionsBuilder? autoFillConditions = null,
        ConditionsBuilder? autoCastConditions = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ActionPanelLogic();
      component.Priority = priority;
      component.AutoFillConditions = autoFillConditions?.Build() ?? Constants.Empty.Conditions;
      component.AutoCastConditions = autoCastConditions?.Build() ?? Constants.Empty.Conditions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="CraftInfoComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CraftInfoComponent))]
    public AbilityConfigurator AddCraftInfoComponent(
        CraftSpellType spellType = default,
        CraftSavingThrow savingThrow = default,
        CraftAOE aOEType = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new CraftInfoComponent();
      component.SpellType = spellType;
      component.SavingThrow = savingThrow;
      component.AOEType = aOEType;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityIsFullRoundInTurnBased"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityIsFullRoundInTurnBased))]
    public AbilityConfigurator AddAbilityIsFullRoundInTurnBased(
        bool fullRoundIfTurnBased = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityIsFullRoundInTurnBased();
      component.FullRoundIfTurnBased = fullRoundIfTurnBased;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="LevelUpRecommendation"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LevelUpRecommendation))]
    public AbilityConfigurator AddLevelUpRecommendation(
        ClassesPriority[]? classPriorities = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(classPriorities);
    
      var component = new LevelUpRecommendation();
      component.ClassPriorities = classPriorities;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ChirurgeonSpell"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChirurgeonSpell))]
    public AbilityConfigurator AddChirurgeonSpell()
    {
      return AddComponent(new ChirurgeonSpell());
    }

    /// <summary>
    /// Adds <see cref="PretendSpellLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PretendSpellLevel))]
    public AbilityConfigurator AddPretendSpellLevel(
        int spellLevel = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new PretendSpellLevel();
      component.SpellLevel = spellLevel;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SpellListComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellList"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellList"/></param>
    [Generated]
    [Implements(typeof(SpellListComponent))]
    public AbilityConfigurator AddSpellListComponent(
        string? spellList = null,
        int spellLevel = default)
    {
      var component = new SpellListComponent();
      component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(spellList);
      component.SpellLevel = spellLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellTypeOverride"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpellTypeOverride))]
    public AbilityConfigurator AddSpellTypeOverride(
        SpellSource type = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SpellTypeOverride();
      component.Type = type;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityAcceptBurnOnCast"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityAcceptBurnOnCast))]
    public AbilityConfigurator AddAbilityAcceptBurnOnCast(
        int burnValue = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityAcceptBurnOnCast();
      component.BurnValue = burnValue;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityKineticist"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cachedDamageSource"><see cref="Kingmaker.Blueprints.BlueprintScriptableObject"/></param>
    /// <param name="requiredResource"><see cref="Kingmaker.Blueprints.BlueprintAbilityResource"/></param>
    /// <param name="resourceCostIncreasingFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    /// <param name="resourceCostDecreasingFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AbilityKineticist))]
    public AbilityConfigurator AddAbilityKineticist(
        int blastBurnCost = default,
        int infusionBurnCost = default,
        int wildTalentBurnCost = default,
        List<AbilityKineticist.DamageInfo>? cachedDamageInfo = null,
        string? cachedDamageSource = null,
        string? requiredResource = null,
        bool isSpendResource = default,
        bool costIsCustom = default,
        int amount = default,
        string[]? resourceCostIncreasingFacts = null,
        string[]? resourceCostDecreasingFacts = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityKineticist();
      component.BlastBurnCost = blastBurnCost;
      component.InfusionBurnCost = infusionBurnCost;
      component.WildTalentBurnCost = wildTalentBurnCost;
      component.CachedDamageInfo = cachedDamageInfo;
      component.CachedDamageSource = BlueprintTool.GetRef<AnyBlueprintReference>(cachedDamageSource);
      component.m_RequiredResource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(requiredResource);
      component.m_IsSpendResource = isSpendResource;
      component.CostIsCustom = costIsCustom;
      component.Amount = amount;
      component.ResourceCostIncreasingFacts = resourceCostIncreasingFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToList();
      component.ResourceCostDecreasingFacts = resourceCostDecreasingFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToList();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParams"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="customProperty"><see cref="Kingmaker.UnitLogic.Mechanics.Properties.BlueprintUnitProperty"/></param>
    [Generated]
    [Implements(typeof(ContextCalculateAbilityParams))]
    public AbilityConfigurator AddContextCalculateAbilityParams(
        bool useKineticistMainStat = default,
        StatType statType = default,
        bool statTypeFromCustomProperty = default,
        string? customProperty = null,
        bool replaceCasterLevel = default,
        ContextValue? casterLevel = null,
        bool replaceSpellLevel = default,
        ContextValue? spellLevel = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(casterLevel);
      ValidateParam(spellLevel);
    
      var component = new ContextCalculateAbilityParams();
      component.UseKineticistMainStat = useKineticistMainStat;
      component.StatType = statType;
      component.StatTypeFromCustomProperty = statTypeFromCustomProperty;
      component.m_CustomProperty = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(customProperty);
      component.ReplaceCasterLevel = replaceCasterLevel;
      component.CasterLevel = casterLevel ?? ContextValues.Constant(0);
      component.ReplaceSpellLevel = replaceSpellLevel;
      component.SpellLevel = spellLevel ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParamsBasedOnClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ContextCalculateAbilityParamsBasedOnClass))]
    public AbilityConfigurator AddContextCalculateAbilityParamsBasedOnClass(
        bool useKineticistMainStat = default,
        StatType statType = default,
        string? characterClass = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ContextCalculateAbilityParamsBasedOnClass();
      component.UseKineticistMainStat = useKineticistMainStat;
      component.StatType = statType;
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateSharedValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextCalculateSharedValue))]
    public AbilityConfigurator AddContextCalculateSharedValue(
        AbilitySharedValue valueType = default,
        ContextDiceValue? value = null,
        double modifier = default)
    {
      ValidateParam(value);
    
      var component = new ContextCalculateSharedValue();
      component.ValueType = valueType;
      component.Value = value ?? Constants.Empty.DiceValue;
      component.Modifier = modifier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextSetAbilityParams"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextSetAbilityParams))]
    public AbilityConfigurator AddContextSetAbilityParams(
        bool add10ToDC = default,
        ContextValue? dC = null,
        ContextValue? casterLevel = null,
        ContextValue? concentration = null,
        ContextValue? spellLevel = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(dC);
      ValidateParam(casterLevel);
      ValidateParam(concentration);
      ValidateParam(spellLevel);
    
      var component = new ContextSetAbilityParams();
      component.Add10ToDC = add10ToDC;
      component.DC = dC ?? ContextValues.Constant(0);
      component.CasterLevel = casterLevel ?? ContextValues.Constant(0);
      component.Concentration = concentration ?? ContextValues.Constant(0);
      component.SpellLevel = spellLevel ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ArmyAbilityTeleportation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="casterDisappearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    /// <param name="casterAppearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    /// <param name="sideDisappearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    /// <param name="sideAppearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    [Generated]
    [Implements(typeof(ArmyAbilityTeleportation))]
    public AbilityConfigurator AddArmyAbilityTeleportation(
        Feet radius,
        GameObject portalFromPrefab,
        GameObject portalToPrefab,
        string portalBone,
        GameObject casterDisappearFx,
        GameObject casterAppearFx,
        GameObject sideDisappearFx,
        GameObject sideAppearFx,
        string? casterDisappearProjectile = null,
        string? casterAppearProjectile = null,
        string? sideDisappearProjectile = null,
        string? sideAppearProjectile = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(portalFromPrefab);
      ValidateParam(portalToPrefab);
      ValidateParam(casterDisappearFx);
      ValidateParam(casterAppearFx);
      ValidateParam(sideDisappearFx);
      ValidateParam(sideAppearFx);
    
      var component = new ArmyAbilityTeleportation();
      component.Radius = radius;
      component.PortalFromPrefab = portalFromPrefab;
      component.PortalToPrefab = portalToPrefab;
      component.PortalBone = portalBone;
      component.CasterDisappearFx = casterDisappearFx;
      component.CasterAppearFx = casterAppearFx;
      component.SideDisappearFx = sideDisappearFx;
      component.SideAppearFx = sideAppearFx;
      component.m_CasterDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(casterDisappearProjectile);
      component.m_CasterAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(casterAppearProjectile);
      component.m_SideDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(sideDisappearProjectile);
      component.m_SideAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(sideAppearProjectile);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityOnInBattleUnits"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityOnInBattleUnits))]
    public AbilityConfigurator AddAbilityOnInBattleUnits(
        AbilityOnInBattleUnits.AllyState factionType = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityOnInBattleUnits();
      component.m_FactionType = factionType;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityAffectLineOnGrid"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityAffectLineOnGrid))]
    public AbilityConfigurator AddAbilityAffectLineOnGrid(
        Feet spreadSpeed,
        bool vertical = default,
        Kingmaker.UnitLogic.Abilities.Components.TargetType targetType = default,
        ConditionsBuilder? condition = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityAffectLineOnGrid();
      component.m_Vertical = vertical;
      component.m_TargetType = targetType;
      component.m_Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.m_SpreadSpeed = spreadSpeed;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityAoERadius"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityAoERadius))]
    public AbilityConfigurator AddAbilityAoERadius(
        Feet radius,
        Kingmaker.UnitLogic.Abilities.Components.TargetType targetType = default,
        bool canBeUsedInTacticalCombat = default,
        int diameterInCells = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityAoERadius();
      component.m_Radius = radius;
      component.m_TargetType = targetType;
      component.m_CanBeUsedInTacticalCombat = canBeUsedInTacticalCombat;
      component.m_DiameterInCells = diameterInCells;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityApplyFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AbilityApplyFact))]
    public AbilityConfigurator AddAbilityApplyFact(
        ContextDurationValue duration,
        AbilityApplyFact.FactRestriction restriction = default,
        string[]? facts = null,
        bool hasDuration = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(duration);
    
      var component = new AbilityApplyFact();
      component.m_Restriction = restriction;
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_HasDuration = hasDuration;
      component.m_Duration = duration;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityConvertSpellLevelToResource"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="Kingmaker.Blueprints.BlueprintScriptableObject"/></param>
    [Generated]
    [Implements(typeof(AbilityConvertSpellLevelToResource))]
    public AbilityConfigurator AddAbilityConvertSpellLevelToResource(
        string? resource = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityConvertSpellLevelToResource();
      component.m_Resource = BlueprintTool.GetRef<AnyBlueprintReference>(resource);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomAnimationByBuff"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityCustomAnimationByBuff))]
    public AbilityConfigurator AddAbilityCustomAnimationByBuff(
        UnitAnimationActionClip defaultAnimation,
        AbilityCustomAnimationByBuff.Entry[]? variants = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(defaultAnimation);
      ValidateParam(variants);
    
      var component = new AbilityCustomAnimationByBuff();
      component.DefaultAnimation = defaultAnimation;
      component.Variants = variants;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityCustomAttack))]
    public AbilityConfigurator AddAbilityCustomAttack(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityCustomAttack();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomCharge"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityCustomCharge))]
    public AbilityConfigurator AddAbilityCustomCharge(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityCustomCharge();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomCleave"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="greaterFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AbilityCustomCleave))]
    public AbilityConfigurator AddAbilityCustomCleave(
        string? greaterFeature = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityCustomCleave();
      component.m_GreaterFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(greaterFeature);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomDimensionDoor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="casterDisappearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    /// <param name="casterAppearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    /// <param name="sideDisappearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    /// <param name="sideAppearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    [Generated]
    [Implements(typeof(AbilityCustomDimensionDoor))]
    public AbilityConfigurator AddAbilityCustomDimensionDoor(
        Feet radius,
        GameObject portalFromPrefab,
        GameObject portalToPrefab,
        string portalBone,
        GameObject casterDisappearFx,
        GameObject casterAppearFx,
        GameObject sideDisappearFx,
        GameObject sideAppearFx,
        string? casterDisappearProjectile = null,
        string? casterAppearProjectile = null,
        string? sideDisappearProjectile = null,
        string? sideAppearProjectile = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(portalFromPrefab);
      ValidateParam(portalToPrefab);
      ValidateParam(casterDisappearFx);
      ValidateParam(casterAppearFx);
      ValidateParam(sideDisappearFx);
      ValidateParam(sideAppearFx);
    
      var component = new AbilityCustomDimensionDoor();
      component.Radius = radius;
      component.PortalFromPrefab = portalFromPrefab;
      component.PortalToPrefab = portalToPrefab;
      component.PortalBone = portalBone;
      component.CasterDisappearFx = casterDisappearFx;
      component.CasterAppearFx = casterAppearFx;
      component.SideDisappearFx = sideDisappearFx;
      component.SideAppearFx = sideAppearFx;
      component.m_CasterDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(casterDisappearProjectile);
      component.m_CasterAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(casterAppearProjectile);
      component.m_SideDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(sideDisappearProjectile);
      component.m_SideAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(sideAppearProjectile);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomDimensionDoorSwap"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="disappearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    /// <param name="appearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    [Generated]
    [Implements(typeof(AbilityCustomDimensionDoorSwap))]
    public AbilityConfigurator AddAbilityCustomDimensionDoorSwap(
        GameObject portalFromPrefab,
        string portalBone,
        GameObject disappearFx,
        GameObject appearFx,
        string? disappearProjectile = null,
        string? appearProjectile = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(portalFromPrefab);
      ValidateParam(disappearFx);
      ValidateParam(appearFx);
    
      var component = new AbilityCustomDimensionDoorSwap();
      component.PortalFromPrefab = portalFromPrefab;
      component.PortalBone = portalBone;
      component.DisappearFx = disappearFx;
      component.AppearFx = appearFx;
      component.m_DisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(disappearProjectile);
      component.m_AppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(appearProjectile);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomDimensionDoorTargets"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="casterDisappearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    /// <param name="casterAppearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    /// <param name="sideDisappearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    /// <param name="sideAppearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    [Generated]
    [Implements(typeof(AbilityCustomDimensionDoorTargets))]
    public AbilityConfigurator AddAbilityCustomDimensionDoorTargets(
        Feet radius,
        GameObject portalFromPrefab,
        GameObject portalToPrefab,
        string portalBone,
        GameObject casterDisappearFx,
        GameObject casterAppearFx,
        GameObject sideDisappearFx,
        GameObject sideAppearFx,
        UnitEvaluator[]? targets = null,
        string? casterDisappearProjectile = null,
        string? casterAppearProjectile = null,
        string? sideDisappearProjectile = null,
        string? sideAppearProjectile = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(targets);
      ValidateParam(portalFromPrefab);
      ValidateParam(portalToPrefab);
      ValidateParam(casterDisappearFx);
      ValidateParam(casterAppearFx);
      ValidateParam(sideDisappearFx);
      ValidateParam(sideAppearFx);
    
      var component = new AbilityCustomDimensionDoorTargets();
      component.Targets = targets;
      component.Radius = radius;
      component.PortalFromPrefab = portalFromPrefab;
      component.PortalToPrefab = portalToPrefab;
      component.PortalBone = portalBone;
      component.CasterDisappearFx = casterDisappearFx;
      component.CasterAppearFx = casterAppearFx;
      component.SideDisappearFx = sideDisappearFx;
      component.SideAppearFx = sideAppearFx;
      component.m_CasterDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(casterDisappearProjectile);
      component.m_CasterAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(casterAppearProjectile);
      component.m_SideDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(sideDisappearProjectile);
      component.m_SideAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(sideAppearProjectile);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomDweomerLeap"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="casterDisappearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    /// <param name="casterAppearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    /// <param name="sideDisappearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    /// <param name="sideAppearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    [Generated]
    [Implements(typeof(AbilityCustomDweomerLeap))]
    public AbilityConfigurator AddAbilityCustomDweomerLeap(
        Feet radius,
        GameObject portalFromPrefab,
        GameObject portalToPrefab,
        string portalBone,
        GameObject casterDisappearFx,
        GameObject casterAppearFx,
        GameObject sideDisappearFx,
        GameObject sideAppearFx,
        string? casterDisappearProjectile = null,
        string? casterAppearProjectile = null,
        string? sideDisappearProjectile = null,
        string? sideAppearProjectile = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(portalFromPrefab);
      ValidateParam(portalToPrefab);
      ValidateParam(casterDisappearFx);
      ValidateParam(casterAppearFx);
      ValidateParam(sideDisappearFx);
      ValidateParam(sideAppearFx);
    
      var component = new AbilityCustomDweomerLeap();
      component.Radius = radius;
      component.PortalFromPrefab = portalFromPrefab;
      component.PortalToPrefab = portalToPrefab;
      component.PortalBone = portalBone;
      component.CasterDisappearFx = casterDisappearFx;
      component.CasterAppearFx = casterAppearFx;
      component.SideDisappearFx = sideDisappearFx;
      component.SideAppearFx = sideAppearFx;
      component.m_CasterDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(casterDisappearProjectile);
      component.m_CasterAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(casterAppearProjectile);
      component.m_SideDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(sideDisappearProjectile);
      component.m_SideAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(sideAppearProjectile);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomFlashStep"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="flashShot"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    /// <param name="casterDisappearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    /// <param name="casterAppearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    /// <param name="sideDisappearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    /// <param name="sideAppearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    [Generated]
    [Implements(typeof(AbilityCustomFlashStep))]
    public AbilityConfigurator AddAbilityCustomFlashStep(
        Feet radius,
        GameObject portalFromPrefab,
        GameObject portalToPrefab,
        string portalBone,
        GameObject casterDisappearFx,
        GameObject casterAppearFx,
        GameObject sideDisappearFx,
        GameObject sideAppearFx,
        string? flashShot = null,
        string? casterDisappearProjectile = null,
        string? casterAppearProjectile = null,
        string? sideDisappearProjectile = null,
        string? sideAppearProjectile = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(portalFromPrefab);
      ValidateParam(portalToPrefab);
      ValidateParam(casterDisappearFx);
      ValidateParam(casterAppearFx);
      ValidateParam(sideDisappearFx);
      ValidateParam(sideAppearFx);
    
      var component = new AbilityCustomFlashStep();
      component.m_FlashShot = BlueprintTool.GetRef<BlueprintUnitFactReference>(flashShot);
      component.Radius = radius;
      component.PortalFromPrefab = portalFromPrefab;
      component.PortalToPrefab = portalToPrefab;
      component.PortalBone = portalBone;
      component.CasterDisappearFx = casterDisappearFx;
      component.CasterAppearFx = casterAppearFx;
      component.SideDisappearFx = sideDisappearFx;
      component.SideAppearFx = sideAppearFx;
      component.m_CasterDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(casterDisappearProjectile);
      component.m_CasterAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(casterAppearProjectile);
      component.m_SideDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(sideDisappearProjectile);
      component.m_SideAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(sideAppearProjectile);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomFly"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityCustomFly))]
    public AbilityConfigurator AddAbilityCustomFly(
        UnitAnimationActionBuffState animation,
        AnimationCurve takeOff,
        AnimationCurve landing,
        float maxHeight = default,
        float flyUpTime = default,
        float takeoffTime = default,
        float landTime = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(animation);
      ValidateParam(takeOff);
      ValidateParam(landing);
    
      var component = new AbilityCustomFly();
      component.Animation = animation;
      component.MaxHeight = maxHeight;
      component.FlyUpTime = flyUpTime;
      component.TakeoffTime = takeoffTime;
      component.LandTime = landTime;
      component.TakeOff = takeOff;
      component.Landing = landing;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomMeleeAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="mythicBlueprint"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    /// <param name="rowdyFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AbilityCustomMeleeAttack))]
    public AbilityConfigurator AddAbilityCustomMeleeAttack(
        AbilityCustomMeleeAttack.AttackType type = default,
        int vitalStrikeMod = default,
        string? mythicBlueprint = null,
        string? rowdyFeature = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityCustomMeleeAttack();
      component.m_Type = type;
      component.VitalStrikeMod = vitalStrikeMod;
      component.m_MythicBlueprint = BlueprintTool.GetRef<BlueprintFeatureReference>(mythicBlueprint);
      component.m_RowdyFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(rowdyFeature);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomMove"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityCustomMove))]
    public AbilityConfigurator AddAbilityCustomMove(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityCustomMove();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomOverrun"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="addBuffWhileRunning"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AbilityCustomOverrun))]
    public AbilityConfigurator AddAbilityCustomOverrun(
        string? addBuffWhileRunning = null,
        float delayBeforeStart = default,
        float delayAfterFinish = default,
        bool firstTargetOnly = default,
        bool autoSuccess = default,
        bool stopOnCorpulence = default,
        ActionsBuilder? actions = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityCustomOverrun();
      component.m_AddBuffWhileRunning = BlueprintTool.GetRef<BlueprintBuffReference>(addBuffWhileRunning);
      component.DelayBeforeStart = delayBeforeStart;
      component.DelayAfterFinish = delayAfterFinish;
      component.FirstTargetOnly = firstTargetOnly;
      component.AutoSuccess = autoSuccess;
      component.StopOnCorpulence = stopOnCorpulence;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomTeleportation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="projectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    [Generated]
    [Implements(typeof(AbilityCustomTeleportation))]
    public AbilityConfigurator AddAbilityCustomTeleportation(
        GameObject disappearFx,
        GameObject appearFx,
        string? projectile = null,
        float disappearDuration = default,
        float appearDuration = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(disappearFx);
      ValidateParam(appearFx);
    
      var component = new AbilityCustomTeleportation();
      component.m_Projectile = BlueprintTool.GetRef<BlueprintProjectileReference>(projectile);
      component.DisappearFx = disappearFx;
      component.DisappearDuration = disappearDuration;
      component.AppearFx = appearFx;
      component.AppearDuration = appearDuration;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomTongueGrab"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityCustomTongueGrab))]
    public AbilityConfigurator AddAbilityCustomTongueGrab(
        UnitAnimationCustomTongueGrab animationAction,
        AnimationCurve stickCurve,
        AnimationCurve returnCurve,
        Feet pullDistance,
        float tongueStickSpeed = default,
        float tongueReturnSpeed = default,
        bool returnTargetAbility = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(animationAction);
      ValidateParam(stickCurve);
      ValidateParam(returnCurve);
    
      var component = new AbilityCustomTongueGrab();
      component.AnimationAction = animationAction;
      component.TongueStickSpeed = tongueStickSpeed;
      component.TongueReturnSpeed = tongueReturnSpeed;
      component.StickCurve = stickCurve;
      component.ReturnCurve = returnCurve;
      component.PullDistance = pullDistance;
      component.m_ReturnTargetAbility = returnTargetAbility;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomVitalStrike"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="mythicBlueprint"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    /// <param name="rowdyFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AbilityCustomVitalStrike))]
    public AbilityConfigurator AddAbilityCustomVitalStrike(
        int vitalStrikeMod = default,
        string? mythicBlueprint = null,
        string? rowdyFeature = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityCustomVitalStrike();
      component.VitalStrikeMod = vitalStrikeMod;
      component.m_MythicBlueprint = BlueprintTool.GetRef<BlueprintFeatureReference>(mythicBlueprint);
      component.m_RowdyFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(rowdyFeature);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliverAttackWithWeapon"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityDeliverAttackWithWeapon))]
    public AbilityConfigurator AddAbilityDeliverAttackWithWeapon(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityDeliverAttackWithWeapon();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliverChain"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="projectileFirst"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    /// <param name="projectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    [Generated]
    [Implements(typeof(AbilityDeliverChain))]
    public AbilityConfigurator AddAbilityDeliverChain(
        Feet radius,
        string? projectileFirst = null,
        string? projectile = null,
        ContextValue? targetsCount = null,
        bool targetDead = default,
        Kingmaker.UnitLogic.Abilities.Components.TargetType targetType = default,
        ConditionsBuilder? condition = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(targetsCount);
    
      var component = new AbilityDeliverChain();
      component.m_ProjectileFirst = BlueprintTool.GetRef<BlueprintProjectileReference>(projectileFirst);
      component.m_Projectile = BlueprintTool.GetRef<BlueprintProjectileReference>(projectile);
      component.TargetsCount = targetsCount ?? ContextValues.Constant(0);
      component.Radius = radius;
      component.TargetDead = targetDead;
      component.m_TargetType = targetType;
      component.m_Condition = condition?.Build() ?? Constants.Empty.Conditions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliverClashingRocks"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="projectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    /// <param name="weapon"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(AbilityDeliverClashingRocks))]
    public AbilityConfigurator AddAbilityDeliverClashingRocks(
        Feet width,
        Feet distanceToTarget,
        string? projectile = null,
        bool ignoreConcealment = default,
        bool needAttackRoll = default,
        string? weapon = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityDeliverClashingRocks();
      component.m_Projectile = BlueprintTool.GetRef<BlueprintProjectileReference>(projectile);
      component.Width = width;
      component.DistanceToTarget = distanceToTarget;
      component.IgnoreConcealment = ignoreConcealment;
      component.NeedAttackRoll = needAttackRoll;
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weapon);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliverDelay"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityDeliverDelay))]
    public AbilityConfigurator AddAbilityDeliverDelay(
        float delaySeconds = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityDeliverDelay();
      component.DelaySeconds = delaySeconds;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliverProjectile"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="projectiles"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    /// <param name="weapon"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintItemWeapon"/></param>
    /// <param name="controlledProjectileHolderBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AbilityDeliverProjectile))]
    public AbilityConfigurator AddAbilityDeliverProjectile(
        Feet length,
        Feet lineWidth,
        string[]? projectiles = null,
        AbilityProjectileType type = default,
        bool isHandOfTheApprentice = default,
        bool needAttackRoll = default,
        string? weapon = null,
        bool replaceAttackRollBonusStat = default,
        StatType attackRollBonusStat = default,
        bool useMaxProjectilesCount = default,
        AbilityRankType maxProjectilesCountRank = default,
        float delayBetweenProjectiles = default,
        string? controlledProjectileHolderBuff = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityDeliverProjectile();
      component.m_Projectiles = projectiles.Select(name => BlueprintTool.GetRef<BlueprintProjectileReference>(name)).ToArray();
      component.Type = type;
      component.IsHandOfTheApprentice = isHandOfTheApprentice;
      component.m_Length = length;
      component.m_LineWidth = lineWidth;
      component.NeedAttackRoll = needAttackRoll;
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weapon);
      component.ReplaceAttackRollBonusStat = replaceAttackRollBonusStat;
      component.AttackRollBonusStat = attackRollBonusStat;
      component.UseMaxProjectilesCount = useMaxProjectilesCount;
      component.MaxProjectilesCountRank = maxProjectilesCountRank;
      component.DelayBetweenProjectiles = delayBetweenProjectiles;
      component.m_ControlledProjectileHolderBuff = BlueprintTool.GetRef<BlueprintBuffReference>(controlledProjectileHolderBuff);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliverProjectileOnGrid"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="projectiles"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    /// <param name="weapon"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintItemWeapon"/></param>
    /// <param name="controlledProjectileHolderBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AbilityDeliverProjectileOnGrid))]
    public AbilityConfigurator AddAbilityDeliverProjectileOnGrid(
        Feet length,
        Feet lineWidth,
        bool launchProjectileOnGridLine = default,
        int lengthInCells = default,
        string[]? projectiles = null,
        AbilityProjectileType type = default,
        bool isHandOfTheApprentice = default,
        bool needAttackRoll = default,
        string? weapon = null,
        bool replaceAttackRollBonusStat = default,
        StatType attackRollBonusStat = default,
        bool useMaxProjectilesCount = default,
        AbilityRankType maxProjectilesCountRank = default,
        float delayBetweenProjectiles = default,
        string? controlledProjectileHolderBuff = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityDeliverProjectileOnGrid();
      component.LaunchProjectileOnGridLine = launchProjectileOnGridLine;
      component.LengthInCells = lengthInCells;
      component.m_Projectiles = projectiles.Select(name => BlueprintTool.GetRef<BlueprintProjectileReference>(name)).ToArray();
      component.Type = type;
      component.IsHandOfTheApprentice = isHandOfTheApprentice;
      component.m_Length = length;
      component.m_LineWidth = lineWidth;
      component.NeedAttackRoll = needAttackRoll;
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weapon);
      component.ReplaceAttackRollBonusStat = replaceAttackRollBonusStat;
      component.AttackRollBonusStat = attackRollBonusStat;
      component.UseMaxProjectilesCount = useMaxProjectilesCount;
      component.MaxProjectilesCountRank = maxProjectilesCountRank;
      component.DelayBetweenProjectiles = delayBetweenProjectiles;
      component.m_ControlledProjectileHolderBuff = BlueprintTool.GetRef<BlueprintBuffReference>(controlledProjectileHolderBuff);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliverTouch"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="touchWeapon"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(AbilityDeliverTouch))]
    public AbilityConfigurator AddAbilityDeliverTouch(
        string? touchWeapon = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityDeliverTouch();
      component.m_TouchWeapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(touchWeapon);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityDemonCharge"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityDemonCharge))]
    public AbilityConfigurator AddAbilityDemonCharge(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityDemonCharge();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityDifficultyLimitDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityDifficultyLimitDC))]
    public AbilityConfigurator AddAbilityDifficultyLimitDC(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityDifficultyLimitDC();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityEffectRunActionOnClickedPoint"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityEffectRunActionOnClickedPoint))]
    public AbilityConfigurator AddAbilityEffectRunActionOnClickedPoint(
        ActionsBuilder? action = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityEffectRunActionOnClickedPoint();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityEffectRunActionOnClickedTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityEffectRunActionOnClickedTarget))]
    public AbilityConfigurator AddAbilityEffectRunActionOnClickedTarget(
        ActionsBuilder? action = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityEffectRunActionOnClickedTarget();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityEffectRunActionOnClickedUnit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityEffectRunActionOnClickedUnit))]
    public AbilityConfigurator AddAbilityEffectRunActionOnClickedUnit(
        ActionsBuilder? action = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityEffectRunActionOnClickedUnit();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityEffectStickyTouch"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="touchDeliveryAbility"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AbilityEffectStickyTouch))]
    public AbilityConfigurator AddAbilityEffectStickyTouch(
        string? touchDeliveryAbility = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityEffectStickyTouch();
      component.m_TouchDeliveryAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(touchDeliveryAbility);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityIsBomb"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityIsBomb))]
    public AbilityConfigurator AddAbilityIsBomb(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityIsBomb();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityKineticBlade"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityKineticBlade))]
    public AbilityConfigurator AddAbilityKineticBlade(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityKineticBlade();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityMagusSpellRecallCostCalculator"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="improvedFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AbilityMagusSpellRecallCostCalculator))]
    public AbilityConfigurator AddAbilityMagusSpellRecallCostCalculator(
        string? improvedFeature = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityMagusSpellRecallCostCalculator();
      component.m_ImprovedFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(improvedFeature);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityRequirementCanMove"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityRequirementCanMove))]
    public AbilityConfigurator AddAbilityRequirementCanMove(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityRequirementCanMove();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityRequirementHasCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityRequirementHasCondition))]
    public AbilityConfigurator AddAbilityRequirementHasCondition(
        bool not = default,
        UnitCondition[]? conditions = null,
        List<UnitCondition>? conditionsCache = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityRequirementHasCondition();
      component.Not = not;
      component.Conditions = conditions;
      component.m_ConditionsCache = conditionsCache;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityRequirementHasItemInHands"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityRequirementHasItemInHands))]
    public AbilityConfigurator AddAbilityRequirementHasItemInHands(
        AbilityRequirementHasItemInHands.RequirementType type = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityRequirementHasItemInHands();
      component.m_Type = type;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityResourceLogic"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="requiredResource"><see cref="Kingmaker.Blueprints.BlueprintAbilityResource"/></param>
    /// <param name="resourceCostIncreasingFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    /// <param name="resourceCostDecreasingFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AbilityResourceLogic))]
    public AbilityConfigurator AddAbilityResourceLogic(
        string? requiredResource = null,
        bool isSpendResource = default,
        bool costIsCustom = default,
        int amount = default,
        string[]? resourceCostIncreasingFacts = null,
        string[]? resourceCostDecreasingFacts = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityResourceLogic();
      component.m_RequiredResource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(requiredResource);
      component.m_IsSpendResource = isSpendResource;
      component.CostIsCustom = costIsCustom;
      component.Amount = amount;
      component.ResourceCostIncreasingFacts = resourceCostIncreasingFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToList();
      component.ResourceCostDecreasingFacts = resourceCostDecreasingFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToList();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityRestoreSpellSlot"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityRestoreSpellSlot))]
    public AbilityConfigurator AddAbilityRestoreSpellSlot(
        bool anySpellLevel = default,
        int spellLevel = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityRestoreSpellSlot();
      component.AnySpellLevel = anySpellLevel;
      component.SpellLevel = spellLevel;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityRestoreSpontaneousSpell"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityRestoreSpontaneousSpell))]
    public AbilityConfigurator AddAbilityRestoreSpontaneousSpell(
        bool anySpellLevel = default,
        int spellLevel = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityRestoreSpontaneousSpell();
      component.AnySpellLevel = anySpellLevel;
      component.SpellLevel = spellLevel;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityShadowSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="factor"><see cref="Kingmaker.UnitLogic.Mechanics.Properties.BlueprintUnitProperty"/></param>
    /// <param name="spellList"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellList"/></param>
    [Generated]
    [Implements(typeof(AbilityShadowSpell))]
    public AbilityConfigurator AddAbilityShadowSpell(
        SpellSchool school = default,
        string? factor = null,
        int maxSpellLevel = default,
        string? spellList = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityShadowSpell();
      component.School = school;
      component.m_Factor = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(factor);
      component.MaxSpellLevel = maxSpellLevel;
      component.SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(spellList);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityShowIfCasterHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unitFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AbilityShowIfCasterHasFact))]
    public AbilityConfigurator AddAbilityShowIfCasterHasFact(
        string? unitFact = null,
        bool not = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityShowIfCasterHasFact();
      component.m_UnitFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(unitFact);
      component.Not = not;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilitySillyFeed"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilitySillyFeed))]
    public AbilityConfigurator AddAbilitySillyFeed(
        UnitAnimationActionClip animation,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(animation);
    
      var component = new AbilitySillyFeed();
      component.m_Animation = animation;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilitySwitchDualCompanion"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="disappearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    /// <param name="appearProjectile"><see cref="Kingmaker.Blueprints.BlueprintProjectile"/></param>
    [Generated]
    [Implements(typeof(AbilitySwitchDualCompanion))]
    public AbilityConfigurator AddAbilitySwitchDualCompanion(
        GameObject portalPrefab,
        string portalBone,
        GameObject disappearFx,
        GameObject appearFx,
        string? disappearProjectile = null,
        string? appearProjectile = null,
        float appearDelay = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(portalPrefab);
      ValidateParam(disappearFx);
      ValidateParam(appearFx);
    
      var component = new AbilitySwitchDualCompanion();
      component.PortalPrefab = portalPrefab;
      component.PortalBone = portalBone;
      component.DisappearFx = disappearFx;
      component.AppearFx = appearFx;
      component.m_DisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(disappearProjectile);
      component.m_AppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(appearProjectile);
      component.AppearDelay = appearDelay;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetsAround"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetsAround))]
    public AbilityConfigurator AddAbilityTargetsAround(
        Feet radius,
        Feet spreadSpeed,
        Kingmaker.UnitLogic.Abilities.Components.TargetType targetType = default,
        bool includeDead = default,
        ConditionsBuilder? condition = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityTargetsAround();
      component.m_Radius = radius;
      component.m_TargetType = targetType;
      component.m_IncludeDead = includeDead;
      component.m_Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.m_SpreadSpeed = spreadSpeed;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetsAroundOnGrid"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetsAroundOnGrid))]
    public AbilityConfigurator AddAbilityTargetsAroundOnGrid(
        Feet spreadSpeed,
        int diameterInCells = default,
        Kingmaker.UnitLogic.Abilities.Components.TargetType targetType = default,
        bool includeDead = default,
        ConditionsBuilder? condition = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityTargetsAroundOnGrid();
      component.m_DiameterInCells = diameterInCells;
      component.m_TargetType = targetType;
      component.m_IncludeDead = includeDead;
      component.m_Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.m_SpreadSpeed = spreadSpeed;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityUseOnRest"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityUseOnRest))]
    public AbilityConfigurator AddAbilityUseOnRest(
        AbilityUseOnRestType type = default,
        int baseValue = default,
        bool addCasterLevel = default,
        bool multiplyByCasterLevel = default,
        int maxCasterLevel = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityUseOnRest();
      component.Type = type;
      component.BaseValue = baseValue;
      component.AddCasterLevel = addCasterLevel;
      component.MultiplyByCasterLevel = multiplyByCasterLevel;
      component.MaxCasterLevel = maxCasterLevel;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilitySwtichDualCompanionChecker"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilitySwtichDualCompanionChecker))]
    public AbilityConfigurator AddAbilitySwtichDualCompanionChecker(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilitySwtichDualCompanionChecker();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetAlignment))]
    public AbilityConfigurator AddAbilityTargetAlignment(
        AlignmentMaskType alignment = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityTargetAlignment();
      component.Alignment = alignment;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetBreathOfLife"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="recentlyDeadBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="undeadFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AbilityTargetBreathOfLife))]
    public AbilityConfigurator AddAbilityTargetBreathOfLife(
        string? recentlyDeadBuff = null,
        string? undeadFact = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityTargetBreathOfLife();
      component.m_RecentlyDeadBuff = BlueprintTool.GetRef<BlueprintBuffReference>(recentlyDeadBuff);
      component.m_UndeadFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(undeadFact);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetCanSeeCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetCanSeeCaster))]
    public AbilityConfigurator AddAbilityTargetCanSeeCaster(
        bool not = default)
    {
      var component = new AbilityTargetCanSeeCaster();
      component.Not = not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetCellsRestriction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetCellsRestriction))]
    public AbilityConfigurator AddAbilityTargetCellsRestriction(
        List<int>? allowedColumns = null,
        bool factionDependent = default,
        bool onlyEmptyCells = default,
        int diameter = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityTargetCellsRestriction();
      component.m_AllowedColumns = allowedColumns;
      component.m_FactionDependent = factionDependent;
      component.m_OnlyEmptyCells = onlyEmptyCells;
      component.m_Diameter = diameter;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetDivineTroth"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AbilityTargetDivineTroth))]
    public AbilityConfigurator AddAbilityTargetDivineTroth(
        string? checkBuff = null)
    {
      var component = new AbilityTargetDivineTroth();
      component.m_CheckBuff = BlueprintTool.GetRef<BlueprintBuffReference>(checkBuff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHPCondition"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="factToCheck"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AbilityTargetHPCondition))]
    public AbilityConfigurator AddAbilityTargetHPCondition(
        int currentHPLessThan = default,
        bool inverted = default,
        bool checkFact = default,
        string? factToCheck = null,
        int overrideCurrentHPLessThan = default)
    {
      var component = new AbilityTargetHPCondition();
      component.CurrentHPLessThan = currentHPLessThan;
      component.Inverted = inverted;
      component.CheckFact = checkFact;
      component.m_FactToCheck = BlueprintTool.GetRef<BlueprintUnitFactReference>(factToCheck);
      component.OverrideCurrentHPLessThan = overrideCurrentHPLessThan;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHasCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetHasCondition))]
    public AbilityConfigurator AddAbilityTargetHasCondition(
        UnitCondition condition = default,
        bool not = default)
    {
      var component = new AbilityTargetHasCondition();
      component.Condition = condition;
      component.Not = not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHasConditionOrBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buffs"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AbilityTargetHasConditionOrBuff))]
    public AbilityConfigurator AddAbilityTargetHasConditionOrBuff(
        bool not = default,
        UnitCondition condition = default,
        string[]? buffs = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityTargetHasConditionOrBuff();
      component.Not = not;
      component.Condition = condition;
      component.m_Buffs = buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AbilityTargetHasFact))]
    public AbilityConfigurator AddAbilityTargetHasFact(
        string[]? checkedFacts = null,
        bool inverted = default)
    {
      var component = new AbilityTargetHasFact();
      component.m_CheckedFacts = checkedFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.Inverted = inverted;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHasMeleeWeaponInPrimaryHand"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetHasMeleeWeaponInPrimaryHand))]
    public AbilityConfigurator AddAbilityTargetHasMeleeWeaponInPrimaryHand(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityTargetHasMeleeWeaponInPrimaryHand();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHasNoFactUnless"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    /// <param name="unlessFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AbilityTargetHasNoFactUnless))]
    public AbilityConfigurator AddAbilityTargetHasNoFactUnless(
        string[]? checkedFacts = null,
        string? unlessFact = null)
    {
      var component = new AbilityTargetHasNoFactUnless();
      component.m_CheckedFacts = checkedFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_UnlessFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(unlessFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHasOneOfConditionsOrHP"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetHasOneOfConditionsOrHP))]
    public AbilityConfigurator AddAbilityTargetHasOneOfConditionsOrHP(
        UnitCondition[]? condition = null,
        bool needHPCondition = default,
        int currentHPLessThan = default,
        bool invertedHP = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityTargetHasOneOfConditionsOrHP();
      component.Condition = condition;
      component.NeedHPCondition = needHPCondition;
      component.CurrentHPLessThan = currentHPLessThan;
      component.InvertedHP = invertedHP;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsAlly"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetIsAlly))]
    public AbilityConfigurator AddAbilityTargetIsAlly(
        bool not = default)
    {
      var component = new AbilityTargetIsAlly();
      component.Not = not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsAnimalCompanion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetIsAnimalCompanion))]
    public AbilityConfigurator AddAbilityTargetIsAnimalCompanion(
        bool not = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityTargetIsAnimalCompanion();
      component.Not = not;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsAreaEffectFromCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetIsAreaEffectFromCaster))]
    public AbilityConfigurator AddAbilityTargetIsAreaEffectFromCaster(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityTargetIsAreaEffectFromCaster();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsDeadAnimalCompanion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetIsDeadAnimalCompanion))]
    public AbilityConfigurator AddAbilityTargetIsDeadAnimalCompanion(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityTargetIsDeadAnimalCompanion();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsDeadCompanion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetIsDeadCompanion))]
    public AbilityConfigurator AddAbilityTargetIsDeadCompanion(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityTargetIsDeadCompanion();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsFavoredEnemy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetIsFavoredEnemy))]
    public AbilityConfigurator AddAbilityTargetIsFavoredEnemy()
    {
      return AddComponent(new AbilityTargetIsFavoredEnemy());
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsNotDevoured"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetIsNotDevoured))]
    public AbilityConfigurator AddAbilityTargetIsNotDevoured(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityTargetIsNotDevoured();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsPartyMember"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetIsPartyMember))]
    public AbilityConfigurator AddAbilityTargetIsPartyMember(
        bool not = default)
    {
      var component = new AbilityTargetIsPartyMember();
      component.Not = not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsSuitableMount"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetIsSuitableMount))]
    public AbilityConfigurator AddAbilityTargetIsSuitableMount(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityTargetIsSuitableMount();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsSuitableMountSize"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetIsSuitableMountSize))]
    public AbilityConfigurator AddAbilityTargetIsSuitableMountSize(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityTargetIsSuitableMountSize();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetMaximumHitDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetMaximumHitDice))]
    public AbilityConfigurator AddAbilityTargetMaximumHitDice(
        int hitDice = default)
    {
      var component = new AbilityTargetMaximumHitDice();
      component.HitDice = hitDice;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetNotSelf"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetNotSelf))]
    public AbilityConfigurator AddAbilityTargetNotSelf(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityTargetNotSelf();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetRangeRestriction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetRangeRestriction))]
    public AbilityConfigurator AddAbilityTargetRangeRestriction(
        Feet distance,
        CompareOperation.Type compareType = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityTargetRangeRestriction();
      component.Distance = distance;
      component.CompareType = compareType;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetStatCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetStatCondition))]
    public AbilityConfigurator AddAbilityTargetStatCondition(
        StatType stat = default,
        int greaterThan = default,
        bool inverted = default)
    {
      var component = new AbilityTargetStatCondition();
      component.Stat = stat;
      component.GreaterThan = greaterThan;
      component.Inverted = inverted;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetStoneToFlesh"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityTargetStoneToFlesh))]
    public AbilityConfigurator AddAbilityTargetStoneToFlesh(
        bool canBeNotPetrified = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityTargetStoneToFlesh();
      component.CanBeNotPetrified = canBeNotPetrified;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DimensionDoorRestrictionIgnorance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DimensionDoorRestrictionIgnorance))]
    public AbilityConfigurator AddDimensionDoorRestrictionIgnorance(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DimensionDoorRestrictionIgnorance();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterMainWeaponCheck"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityCasterMainWeaponCheck))]
    public AbilityConfigurator AddAbilityCasterMainWeaponCheck(
        WeaponCategory[]? category = null)
    {
      var component = new AbilityCasterMainWeaponCheck();
      component.Category = category;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterMainWeaponIsMelee"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityCasterMainWeaponIsMelee))]
    public AbilityConfigurator AddAbilityCasterMainWeaponIsMelee()
    {
      return AddComponent(new AbilityCasterMainWeaponIsMelee());
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterMainWeaponIsTwoHanded"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityCasterMainWeaponIsTwoHanded))]
    public AbilityConfigurator AddAbilityCasterMainWeaponIsTwoHanded()
    {
      return AddComponent(new AbilityCasterMainWeaponIsTwoHanded());
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterNotPolymorphed"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityCasterNotPolymorphed))]
    public AbilityConfigurator AddAbilityCasterNotPolymorphed(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityCasterNotPolymorphed();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityMaxSquadsRestriction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityMaxSquadsRestriction))]
    public AbilityConfigurator AddAbilityMaxSquadsRestriction(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityMaxSquadsRestriction();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilitySpawnFx"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilitySpawnFx))]
    public AbilityConfigurator AddAbilitySpawnFx(
        PrefabLink? prefabLink = null,
        AbilitySpawnFxTime time = default,
        AbilitySpawnFxAnchor anchor = default,
        AbilitySpawnFxWeaponTarget weaponTarget = default,
        bool destroyOnCast = default,
        float delay = default,
        AbilitySpawnFxAnchor positionAnchor = default,
        AbilitySpawnFxAnchor orientationAnchor = default,
        AbilitySpawnFxOrientation orientationMode = default)
    {
      ValidateParam(prefabLink);
    
      var component = new AbilitySpawnFx();
      component.PrefabLink = prefabLink ?? Constants.Empty.PrefabLink;
      component.Time = time;
      component.Anchor = anchor;
      component.WeaponTarget = weaponTarget;
      component.DestroyOnCast = destroyOnCast;
      component.Delay = delay;
      component.PositionAnchor = positionAnchor;
      component.OrientationAnchor = orientationAnchor;
      component.OrientationMode = orientationMode;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyAbilityHook"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyAbilityHook))]
    public AbilityConfigurator AddArmyAbilityHook(
        AnimationCurve pullCurve,
        float pullSpeed = default,
        int pullDistanceInCells = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(pullCurve);
    
      var component = new ArmyAbilityHook();
      component.PullSpeed = pullSpeed;
      component.PullCurve = pullCurve;
      component.PullDistanceInCells = pullDistanceInCells;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="CustomAreaOnGrid"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CustomAreaOnGrid))]
    public AbilityConfigurator AddCustomAreaOnGrid(
        List<Vector2Int>? affectedCells = null,
        bool ignoreObstaclesAndUnits = default,
        bool spawnFxInEveryCell = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new CustomAreaOnGrid();
      component.AffectedCells = affectedCells;
      component.IgnoreObstaclesAndUnits = ignoreObstaclesAndUnits;
      component.SpawnFxInEveryCell = spawnFxInEveryCell;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatDefenseAbility"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCombatDefenseAbility))]
    public AbilityConfigurator AddTacticalCombatDefenseAbility(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TacticalCombatDefenseAbility();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatResurrection"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCombatResurrection))]
    public AbilityConfigurator AddTacticalCombatResurrection(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TacticalCombatResurrection();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="PureRecommendation"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PureRecommendation))]
    public AbilityConfigurator AddPureRecommendation(
        RecommendationPriority priority = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new PureRecommendation();
      component.Priority = priority;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RecommendationAccomplishedSneakAttacker"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationAccomplishedSneakAttacker))]
    public AbilityConfigurator AddRecommendationAccomplishedSneakAttacker()
    {
      return AddComponent(new RecommendationAccomplishedSneakAttacker());
    }

    /// <summary>
    /// Adds <see cref="RecommendationBaseAttackPart"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationBaseAttackPart))]
    public AbilityConfigurator AddRecommendationBaseAttackPart(
        float minPart = default,
        bool notRecommendIfHigher = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RecommendationBaseAttackPart();
      component.MinPart = minPart;
      component.NotRecommendIfHigher = notRecommendIfHigher;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RecommendationCompanionBoon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companionRank"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(RecommendationCompanionBoon))]
    public AbilityConfigurator AddRecommendationCompanionBoon(
        string? companionRank = null)
    {
      var component = new RecommendationCompanionBoon();
      component.m_CompanionRank = BlueprintTool.GetRef<BlueprintFeatureReference>(companionRank);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationHasFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(RecommendationHasFeature))]
    public AbilityConfigurator AddRecommendationHasFeature(
        string? feature = null,
        bool mandatory = default)
    {
      var component = new RecommendationHasFeature();
      component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(feature);
      component.Mandatory = mandatory;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationNoFeatFromGroup"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="features"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(RecommendationNoFeatFromGroup))]
    public AbilityConfigurator AddRecommendationNoFeatFromGroup(
        string[]? features = null,
        bool goodIfNoFeature = default)
    {
      var component = new RecommendationNoFeatFromGroup();
      component.m_Features = features.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.GoodIfNoFeature = goodIfNoFeature;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationRequiresSpellbook"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationRequiresSpellbook))]
    public AbilityConfigurator AddRecommendationRequiresSpellbook(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RecommendationRequiresSpellbook();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RecommendationRequiresSpellbookSource"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationRequiresSpellbookSource))]
    public AbilityConfigurator AddRecommendationRequiresSpellbookSource(
        bool arcane = default,
        bool divine = default,
        bool alchemist = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RecommendationRequiresSpellbookSource();
      component.Arcane = arcane;
      component.Divine = divine;
      component.Alchemist = alchemist;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RecommendationStatComparison"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationStatComparison))]
    public AbilityConfigurator AddRecommendationStatComparison(
        StatType higherStat = default,
        StatType lowerStat = default,
        int diff = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RecommendationStatComparison();
      component.HigherStat = higherStat;
      component.LowerStat = lowerStat;
      component.Diff = diff;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RecommendationStatMiminum"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationStatMiminum))]
    public AbilityConfigurator AddRecommendationStatMiminum(
        StatType stat = default,
        int minimalValue = default,
        bool goodIfHigher = default)
    {
      var component = new RecommendationStatMiminum();
      component.Stat = stat;
      component.MinimalValue = minimalValue;
      component.GoodIfHigher = goodIfHigher;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationWeaponSubcategoryFocus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationWeaponSubcategoryFocus))]
    public AbilityConfigurator AddRecommendationWeaponSubcategoryFocus(
        WeaponSubCategory subcategory = default,
        bool hasFocus = default,
        bool badIfNoFocus = default)
    {
      var component = new RecommendationWeaponSubcategoryFocus();
      component.Subcategory = subcategory;
      component.HasFocus = hasFocus;
      component.BadIfNoFocus = badIfNoFocus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationWeaponTypeFocus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationWeaponTypeFocus))]
    public AbilityConfigurator AddRecommendationWeaponTypeFocus(
        WeaponRangeType weaponRangeType = default,
        bool hasFocus = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RecommendationWeaponTypeFocus();
      component.WeaponRangeType = weaponRangeType;
      component.HasFocus = hasFocus;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="StatRecommendationChange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(StatRecommendationChange))]
    public AbilityConfigurator AddStatRecommendationChange(
        StatType stat = default,
        bool recommended = default)
    {
      var component = new StatRecommendationChange();
      component.Stat = stat;
      component.Recommended = recommended;
      return AddComponent(component);
    }

    protected override void ValidateInternal()
    {
      base.ValidateInternal();

      if (Blueprint.CustomRange > new Feet(0) && Blueprint.Range != AbilityRange.Custom)
      {
        AddValidationWarning("A custom range value is present without AbilityRange.Custom. It will be ignored.");
      }

      var spellComponent = Blueprint.GetComponent<SpellComponent>();
      if (spellComponent != null && spellComponent.School == SpellSchool.None)
      {
        AddValidationWarning("A spell component is present without a SpellSchool.");
      }

      if (Blueprint.GetComponents<AbilityVariants>().Count() > 1)
      {
        AddValidationWarning("Multiple AbilityVariants components present. Only the first is used.");
      }

      if (Blueprint.GetComponents<CantripComponent>().Count() > 1)
      {
        AddValidationWarning("Multiple AbilityVariants components present. Only the first is used.");
      }

      List<AbilityDeliverEffect> deliverEffects = Blueprint.GetComponents<AbilityDeliverEffect>().ToList();
      if (deliverEffects.Count > 1)
      {
        AddValidationWarning("Multiple AbilityDeliverEffects present. Only the first is used.");
      }

      if (Blueprint.GetComponent<AbilityApplyEffect>() is AbilityEffectMiss)
      {
        AddValidationWarning("AbilityEffectMiss is the first AbilityApplyEffect. It will always trigger.");
      }

      List<AbilityApplyEffect> applyEffects =
          Blueprint.GetComponents<AbilityApplyEffect>().ToList();
      if (applyEffects.Count == 1 && applyEffects[0] is AbilityEffectMiss)
      {
        AddValidationWarning("AbilityEffectMiss is the only AbilityApplyEffect. It will trigger on hit or miss.");
      }
      else if (applyEffects.Count == 2 && applyEffects[1] is AbilityEffectMiss)
      {
        var deliverEffect = Blueprint.GetComponent<AbilityDeliverEffect>();
        if (deliverEffect == null)
        {
          AddValidationWarning($"AbilityEffectMiss requires an AbilityDeliverEffect.");
        }
        else if (!SupportsEffectMiss(deliverEffect))
        {
          AddValidationWarning($"AbilityEffectMiss is not compatible with {deliverEffect.GetType()}");
        }
      }
      else if (applyEffects.Count > 1)
      {
        AddValidationWarning("Too many AbilityApplyEffects present. Only the first is used.");
      }

      if (Blueprint.GetComponents<AbilitySelectTarget>().Count() > 1)
      {
        AddValidationWarning("Multiple AbilitySelectTarget components present. Only the first is used.");
      }
    }

    private static bool SupportsEffectMiss(AbilityDeliverEffect effect)
    {
      return
          effect is AbilityDeliveredByWeapon
          || effect is AbilityDeliverClashingRocks
          || effect is AbilityDeliverProjectile
          || effect is AbilityDeliverTouch;
    }

    private void SetParent(BlueprintAbility parent)
    {
      Blueprint.Parent = parent;

      var parentVariants = parent.GetComponent<AbilityVariants>();
      var abilityRef = Blueprint.ToReference<BlueprintAbilityReference>();
      if (parentVariants != null)
      {
        parentVariants.m_Variants = CommonTool.Append(parentVariants.m_Variants, abilityRef);
        return;
      }

      parentVariants = new();
      parentVariants.m_Variants = new BlueprintAbilityReference[] { abilityRef };
      parent.AddComponents(parentVariants);
    }

    private void RemoveParent()
    {
      var parentVariants = Blueprint.Parent?.GetComponent<AbilityVariants>();
      Blueprint.Parent = null;
      if (parentVariants == null)
      {
        AddValidationWarning($"Tried to remove an invalid parent.");
        return;
      }
      parentVariants.m_Variants =
          parentVariants.m_Variants
              .ToList()
              .FindAll(ability => ability != Blueprint.ToReference<BlueprintAbilityReference>())
              .ToArray();
    }

    // Attribute for methods which add AbilityApplyEffect components.
    [AttributeUsage(AttributeTargets.Method)]
    public class ApplyEffectAttr : Attribute { }

    // Attribute for methods which add AbilityDeliverEffect components.
    [AttributeUsage(AttributeTargets.Method)]
    public class DeliverEffectAttr : Attribute { }

    // Attribute for methods which add AbilitySelectTarget components.
    [AttributeUsage(AttributeTargets.Method)]
    public class SelectTargetAttr : Attribute { }
  }
}

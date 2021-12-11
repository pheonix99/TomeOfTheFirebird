using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Armies.TacticalCombat.LeaderSkills;
using Kingmaker.Armies.TacticalCombat.LeaderSkills.UnitBuffComponents;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Controllers.Units;
using Kingmaker.Corruption;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Parts;
using Kingmaker.Utility;
using Kingmaker.Visual;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Buffs
{
  /// <summary>Configurator for <see cref="BlueprintBuff"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintBuff))]
  public class BuffConfigurator : BaseUnitFactConfigurator<BlueprintBuff, BuffConfigurator>
  {
    private BuffConfigurator(string name) : base(name) { }

    /// <summary>Returns a configurator for the given blueprint.</summary>
    /// 
    /// <remarks>
    /// Use this function if the blueprint exists in the game library. If you're using
    /// <see href="https://github.com/OwlcatOpenSource/WrathModificationTemplate">WrathModifiationTemplate</see> your
    /// JSON blueprints should already exist.
    /// </remarks>
    public static BuffConfigurator For(string name)
    {
      return new BuffConfigurator(name);
    }

    /// <summary>Creates a blueprint and returns its configurator.</summary>
    /// 
    /// <remarks>
    /// When this is called the mapping from name to Guid is stored so you can reference it by name in other calls to
    /// BlueprintCore. The mapping is equivalent to calling <see cref="BlueprintTool.AddGuidsByName"/>
    /// </remarks>
    public static BuffConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintBuff>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.IsClassFeature"/>
    /// </summary>
    public BuffConfigurator SetIsClassFeature(bool isClassFeature = true)
    {
      return OnConfigureInternal(blueprint => blueprint.IsClassFeature = isClassFeature);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.m_Flags"/>
    /// </summary>
    public BuffConfigurator SetFlags(params BlueprintBuff.Flags[] flags)
    {
      BlueprintBuff.Flags buffFlags = 0;
      flags.ForEach(f => buffFlags |= f);
      return OnConfigureInternal(bp => bp.m_Flags = buffFlags);
    }

    /// <summary>
    /// Adds to <see cref="BlueprintBuff.m_Flags"/>
    /// </summary>
    public BuffConfigurator AddToFlags(params BlueprintBuff.Flags[] flags)
    {
      return OnConfigureInternal(blueprint => flags.ForEach(f => blueprint.m_Flags |= f));
    }

    /// <summary>
    /// Removes from <see cref="BlueprintBuff.m_Flags"/>
    /// </summary>
    public BuffConfigurator RemoveFromFlags(params BlueprintBuff.Flags[] flags)
    {
      return OnConfigureInternal(blueprint => flags.ForEach(f => blueprint.m_Flags &= ~f));
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.Stacking"/>
    /// </summary>
    /// 
    /// <remarks>Use <see cref="SetRanks(int)"/> for <see cref="StackingType.Rank"/></remarks>
    public BuffConfigurator SetStackingType(StackingType type)
    {
      if (type == StackingType.Rank)
      {
        throw new InvalidOperationException("Use SetRanks() for StackingType.Rank.");
      }

      return OnConfigureInternal(blueprint => blueprint.Stacking = type);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.Ranks"/>
    /// </summary>
    ///
    /// <remarks>Also sets <see cref="BlueprintBuff.Stacking"/> to <see cref="StackingType.Rank"/></remarks>
    public BuffConfigurator SetRanks(int ranks)
    {
      return OnConfigureInternal(
          blueprint =>
          {
            blueprint.Stacking = StackingType.Rank;
            blueprint.Ranks = ranks;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.TickEachSecond"/>
    /// </summary>
    public BuffConfigurator SetTickEachSecond(bool tickEachSecond = true)
    {
      return OnConfigureInternal(blueprint => blueprint.TickEachSecond = tickEachSecond);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.Frequency"/>
    /// </summary>
    public BuffConfigurator SetFrequency(DurationRate rate)
    {
      return OnConfigureInternal(blueprint => blueprint.Frequency = rate);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.FxOnStart"/>
    /// </summary>
    public BuffConfigurator SetFxOnStart(PrefabLink prefab)
    {
      return OnConfigureInternal(blueprint => blueprint.FxOnStart = prefab);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBuff.FxOnRemove"/>
    /// </summary>
    public BuffConfigurator SetFxOnRemove(PrefabLink prefab)
    {
      return OnConfigureInternal(blueprint => blueprint.FxOnRemove = prefab);
    }


    /// <summary>
    /// Adds <see cref="AddEffectFastHealing"/>
    /// </summary>
    [Implements(typeof(AddEffectFastHealing))]
    public BuffConfigurator FastHealing(int baseValue, ContextValue? bonusValue = null)
    {
      var fastHealing = new AddEffectFastHealing
      {
        Heal = baseValue,
        Bonus = bonusValue ?? 0
      };
      return AddComponent(fastHealing);
    }

    /// <summary>
    /// Adds <see cref="RemoveWhenCombatEnded"/>
    /// </summary>
    [Implements(typeof(RemoveWhenCombatEnded))]
    public BuffConfigurator RemoveWhenCombatEnds()
    {
      return AddUniqueComponent(new RemoveWhenCombatEnded(), ComponentMerge.Skip);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.Mechanics.Buffs.BuffSleeping">BuffSleeping</see>
    /// </summary>
    [Implements(typeof(BuffSleeping))]
    public BuffConfigurator BuffSleeping(
        int? wakeupPerceptionDC = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? merge = null)
    {
      var sleeping = new BuffSleeping();
      if (wakeupPerceptionDC is not null) { sleeping.WakeupPerceptionDC = wakeupPerceptionDC.Value; }
      return AddUniqueComponent(sleeping, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddContextStatBonus"/>
    /// </summary>
    [Implements(typeof(AddContextStatBonus))]
    public BuffConfigurator AddContextStatBonus(
        StatType stat,
        ContextValue value,
        ModifierDescriptor descriptor = default,
        int multiplier = 1,
        int? minimal = null)
    {
      ValidateParam(value);

      var component = new AddContextStatBonus();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Multiplier = multiplier;
      component.Value = value ?? ContextValues.Constant(0);
      component.HasMinimal = minimal is not null;
      component.Minimal = minimal ?? 0;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig">ContextRankConfig</see>
    /// </summary>
    /// 
    /// <remarks>Use <see cref="Components.ContextRankConfigs">ContextRankConfigs</see> to create the config</remarks>
    [Implements(typeof(ContextRankConfig))]
    public BuffConfigurator AddContextRankConfig(ContextRankConfig rankConfig)
    {
      return AddComponent(rankConfig);
    }

    /// <summary>
    /// Adds or modifies <see cref="SpellDescriptorComponent"/>
    /// </summary>
    [Implements(typeof(SpellDescriptorComponent))]
    public BuffConfigurator AddSpellDescriptors(params SpellDescriptor[] descriptors)
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
    public BuffConfigurator RemoveSpellDescriptors(params SpellDescriptor[] descriptors)
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
    /// Adds <see cref="GlobalMapSpeedModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GlobalMapSpeedModifier))]
    public BuffConfigurator AddGlobalMapSpeedModifier(
        float speedModifier = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new GlobalMapSpeedModifier();
      component.SpeedModifier = speedModifier;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddForceMove"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddForceMove))]
    public BuffConfigurator AddForceMove(
        ContextValue? feetPerRound = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(feetPerRound);
    
      var component = new AddForceMove();
      component.FeetPerRound = feetPerRound ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddGoldenDragonSkillBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddGoldenDragonSkillBonus))]
    public BuffConfigurator AddGoldenDragonSkillBonus(
        ModifierDescriptor descriptor = default,
        StatType stat = default)
    {
      var component = new AddGoldenDragonSkillBonus();
      component.Descriptor = descriptor;
      component.Stat = stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddNocticulaBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddNocticulaBonus))]
    public BuffConfigurator AddNocticulaBonus(
        ModifierDescriptor descriptor = default,
        ContextValue? highestStatBonus = null,
        StatType highestStat = default,
        ContextValue? secondHighestStatBonus = null,
        StatType secondHighestStat = default)
    {
      ValidateParam(highestStatBonus);
      ValidateParam(secondHighestStatBonus);
    
      var component = new AddNocticulaBonus();
      component.Descriptor = descriptor;
      component.HighestStatBonus = highestStatBonus ?? ContextValues.Constant(0);
      component.m_HighestStat = highestStat;
      component.SecondHighestStatBonus = secondHighestStatBonus ?? ContextValues.Constant(0);
      component.m_SecondHighestStat = secondHighestStat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddRestTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddRestTrigger))]
    public BuffConfigurator AddRestTrigger(
        ActionsBuilder? action = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddRestTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddRunwayLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddRunwayLogic))]
    public BuffConfigurator AddRunwayLogic(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddRunwayLogic();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddTemporaryFeat"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feat"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddTemporaryFeat))]
    public BuffConfigurator AddTemporaryFeat(
        string? feat = null)
    {
      var component = new AddTemporaryFeat();
      component.m_Feat = BlueprintTool.GetRef<BlueprintFeatureReference>(feat);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTricksterAthleticBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddTricksterAthleticBonus))]
    public BuffConfigurator AddTricksterAthleticBonus(
        ModifierDescriptor descriptor = default)
    {
      var component = new AddTricksterAthleticBonus();
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddWeaponEnhancementBonusToStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddWeaponEnhancementBonusToStat))]
    public BuffConfigurator AddWeaponEnhancementBonusToStat(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int multiplier = default)
    {
      var component = new AddWeaponEnhancementBonusToStat();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Multiplier = multiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffEnchantAnyWeapon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantmentBlueprint"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(BuffEnchantAnyWeapon))]
    public BuffConfigurator AddBuffEnchantAnyWeapon(
        string? enchantmentBlueprint = null,
        EquipSlotBase.SlotType slot = default)
    {
      var component = new BuffEnchantAnyWeapon();
      component.m_EnchantmentBlueprint = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(enchantmentBlueprint);
      component.Slot = slot;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffEnchantSpecificWeaponWorn"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantmentBlueprint"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/></param>
    /// <param name="weaponBlueprint"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(BuffEnchantSpecificWeaponWorn))]
    public BuffConfigurator AddBuffEnchantSpecificWeaponWorn(
        string? enchantmentBlueprint = null,
        string? weaponBlueprint = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new BuffEnchantSpecificWeaponWorn();
      component.m_EnchantmentBlueprint = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(enchantmentBlueprint);
      component.m_WeaponBlueprint = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weaponBlueprint);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BuffEnchantWornItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantmentBlueprint"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(BuffEnchantWornItem))]
    public BuffConfigurator AddBuffEnchantWornItem(
        string? enchantmentBlueprint = null,
        bool allWeapons = default,
        EquipSlotBase.SlotType slot = default)
    {
      var component = new BuffEnchantWornItem();
      component.m_EnchantmentBlueprint = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(enchantmentBlueprint);
      component.AllWeapons = allWeapons;
      component.Slot = slot;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Bugurt"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Bugurt))]
    public BuffConfigurator AddBugurt(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new Bugurt();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DropLootAndDestroyOnDeactivate"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DropLootAndDestroyOnDeactivate))]
    public BuffConfigurator AddDropLootAndDestroyOnDeactivate(
        IDisposable coroutine,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(coroutine);
    
      var component = new DropLootAndDestroyOnDeactivate();
      component.m_Coroutine = coroutine;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="LimbsApartDismembermentRestricted"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LimbsApartDismembermentRestricted))]
    public BuffConfigurator AddLimbsApartDismembermentRestricted(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new LimbsApartDismembermentRestricted();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="MountedShield"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MountedShield))]
    public BuffConfigurator AddMountedShield(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new MountedShield();
      component.Descriptor = descriptor;
      component.Stat = stat;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffIfPartyNotInCombat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveBuffIfPartyNotInCombat))]
    public BuffConfigurator AddRemoveBuffIfPartyNotInCombat(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RemoveBuffIfPartyNotInCombat();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SetMagusFeatureActive"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetMagusFeatureActive))]
    public BuffConfigurator AddSetMagusFeatureActive(
        SetMagusFeatureActive.FeatureType feature = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SetMagusFeatureActive();
      component.m_Feature = feature;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ShroudOfWater"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="upgradeFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ShroudOfWater))]
    public BuffConfigurator AddShroudOfWater(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        ContextValue? baseValue = null,
        string? upgradeFeature = null)
    {
      ValidateParam(baseValue);
    
      var component = new ShroudOfWater();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.BaseValue = baseValue ?? ContextValues.Constant(0);
      component.m_UpgradeFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(upgradeFeature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UniqueBuff"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UniqueBuff))]
    public BuffConfigurator AddUniqueBuff(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new UniqueBuff();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistBlade"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blade"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(AddKineticistBlade))]
    public BuffConfigurator AddKineticistBlade(
        string? blade = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddKineticistBlade();
      component.m_Blade = BlueprintTool.GetRef<BlueprintItemWeaponReference>(blade);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="Polymorph"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="replaceUnitForInspection"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    /// <param name="portrait"><see cref="Kingmaker.Blueprints.BlueprintPortrait"/></param>
    /// <param name="mainHand"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintItemWeapon"/></param>
    /// <param name="offHand"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintItemWeapon"/></param>
    /// <param name="additionalLimbs"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintItemWeapon"/></param>
    /// <param name="secondaryAdditionalLimbs"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintItemWeapon"/></param>
    /// <param name="facts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(Polymorph))]
    public BuffConfigurator AddPolymorph(
        UnitViewLink prefab,
        UnitViewLink prefabFemale,
        Polymorph.VisualTransitionSettings enterTransition,
        Polymorph.VisualTransitionSettings exitTransition,
        PolymorphTransitionSettings transitionExternal,
        SpecialDollType specialDollType = default,
        string? replaceUnitForInspection = null,
        string? portrait = null,
        bool keepSlots = default,
        Size size = default,
        int strengthBonus = default,
        int dexterityBonus = default,
        int constitutionBonus = default,
        int naturalArmor = default,
        string? mainHand = null,
        string? offHand = null,
        string[]? additionalLimbs = null,
        string[]? secondaryAdditionalLimbs = null,
        string[]? facts = null,
        bool silentCaster = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(prefab);
      ValidateParam(prefabFemale);
      ValidateParam(enterTransition);
      ValidateParam(exitTransition);
      ValidateParam(transitionExternal);
    
      var component = new Polymorph();
      component.m_Prefab = prefab;
      component.m_PrefabFemale = prefabFemale;
      component.m_SpecialDollType = specialDollType;
      component.m_ReplaceUnitForInspection = BlueprintTool.GetRef<BlueprintUnitReference>(replaceUnitForInspection);
      component.m_Portrait = BlueprintTool.GetRef<BlueprintPortraitReference>(portrait);
      component.m_KeepSlots = keepSlots;
      component.Size = size;
      component.StrengthBonus = strengthBonus;
      component.DexterityBonus = dexterityBonus;
      component.ConstitutionBonus = constitutionBonus;
      component.NaturalArmor = naturalArmor;
      component.m_MainHand = BlueprintTool.GetRef<BlueprintItemWeaponReference>(mainHand);
      component.m_OffHand = BlueprintTool.GetRef<BlueprintItemWeaponReference>(offHand);
      component.m_AdditionalLimbs = additionalLimbs.Select(name => BlueprintTool.GetRef<BlueprintItemWeaponReference>(name)).ToArray();
      component.m_SecondaryAdditionalLimbs = secondaryAdditionalLimbs.Select(name => BlueprintTool.GetRef<BlueprintItemWeaponReference>(name)).ToArray();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_EnterTransition = enterTransition;
      component.m_ExitTransition = exitTransition;
      component.m_TransitionExternal = transitionExternal;
      component.m_SilentCaster = silentCaster;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffOnLoad"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveBuffOnLoad))]
    public BuffConfigurator AddRemoveBuffOnLoad(
        bool onlyFromParty = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RemoveBuffOnLoad();
      component.OnlyFromParty = onlyFromParty;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffOnTurnOn"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveBuffOnTurnOn))]
    public BuffConfigurator AddRemoveBuffOnTurnOn(
        bool onlyFromParty = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RemoveBuffOnTurnOn();
      component.OnlyFromParty = onlyFromParty;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddAreaEffect"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="areaEffect"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbilityAreaEffect"/></param>
    [Generated]
    [Implements(typeof(AddAreaEffect))]
    public BuffConfigurator AddAreaEffect(
        string? areaEffect = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddAreaEffect();
      component.m_AreaEffect = BlueprintTool.GetRef<BlueprintAbilityAreaEffectReference>(areaEffect);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddAttackBonus))]
    public BuffConfigurator AddAttackBonus(
        int bonus = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddAttackBonus();
      component.Bonus = bonus;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddCheatDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddCheatDamageBonus))]
    public BuffConfigurator AddCheatDamageBonus(
        int bonus = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddCheatDamageBonus();
      component.Bonus = bonus;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddDispelMagicFailedTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddDispelMagicFailedTrigger))]
    public BuffConfigurator AddDispelMagicFailedTrigger(
        ActionsBuilder? actionOnOwner = null,
        ActionsBuilder? actionOnCaster = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddDispelMagicFailedTrigger();
      component.ActionOnOwner = actionOnOwner?.Build() ?? Constants.Empty.Actions;
      component.ActionOnCaster = actionOnCaster?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddEffectContextFastHealing"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEffectContextFastHealing))]
    public BuffConfigurator AddEffectContextFastHealing(
        ContextValue? bonus = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(bonus);
    
      var component = new AddEffectContextFastHealing();
      component.Bonus = bonus ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddEffectProtectionFromElement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEffectProtectionFromElement))]
    public BuffConfigurator AddEffectProtectionFromElement(
        string element,
        int shieldCapacity = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddEffectProtectionFromElement();
      component.Element = element;
      component.ShieldCapacity = shieldCapacity;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddEffectRegeneration"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEffectRegeneration))]
    public BuffConfigurator AddEffectRegeneration(
        int heal = default,
        bool unremovable = default,
        bool cancelByMagicWeapon = default,
        DamageEnergyType[]? cancelDamageEnergyTypes = null,
        DamageAlignment[]? cancelDamageAlignmentTypes = null,
        PhysicalDamageMaterial[]? cancelDamageMaterials = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddEffectRegeneration();
      component.Heal = heal;
      component.Unremovable = unremovable;
      component.CancelByMagicWeapon = cancelByMagicWeapon;
      component.CancelDamageEnergyTypes = cancelDamageEnergyTypes;
      component.CancelDamageAlignmentTypes = cancelDamageAlignmentTypes;
      component.CancelDamageMaterials = cancelDamageMaterials;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddGenericStatBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddGenericStatBonus))]
    public BuffConfigurator AddGenericStatBonus(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int value = default)
    {
      var component = new AddGenericStatBonus();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddMirrorImage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddMirrorImage))]
    public BuffConfigurator AddMirrorImage(
        ContextDiceValue? count = null,
        int maxCount = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(count);
    
      var component = new AddMirrorImage();
      component.Count = count ?? Constants.Empty.DiceValue;
      component.MaxCount = maxCount;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddSpellSchool"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSpellSchool))]
    public BuffConfigurator AddSpellSchool(
        SpellSchool school = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddSpellSchool();
      component.School = school;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IsPositiveEffect"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsPositiveEffect))]
    public BuffConfigurator AddIsPositiveEffect(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IsPositiveEffect();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="NegativeLevelComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NegativeLevelComponent))]
    public BuffConfigurator AddNegativeLevelComponent(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new NegativeLevelComponent();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffIfCasterIsMissing"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveBuffIfCasterIsMissing))]
    public BuffConfigurator AddRemoveBuffIfCasterIsMissing(
        bool removeOnCasterDeath = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RemoveBuffIfCasterIsMissing();
      component.RemoveOnCasterDeath = removeOnCasterDeath;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ResurrectionLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ResurrectionLogic))]
    public BuffConfigurator AddResurrectionLogic(
        GameObject firstFx,
        GameObject secondFx,
        float firstFxDelay = default,
        float secondFxDelay = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(firstFx);
      ValidateParam(secondFx);
    
      var component = new ResurrectionLogic();
      component.FirstFx = firstFx;
      component.FirstFxDelay = firstFxDelay;
      component.SecondFx = secondFx;
      component.SecondFxDelay = secondFxDelay;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SetBuffOnsetDelay"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetBuffOnsetDelay))]
    public BuffConfigurator AddSetBuffOnsetDelay(
        ContextDurationValue delay,
        ActionsBuilder? onStart = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(delay);
    
      var component = new SetBuffOnsetDelay();
      component.Delay = delay;
      component.OnStart = onStart?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SpecialAnimationState"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpecialAnimationState))]
    public BuffConfigurator AddSpecialAnimationState(
        UnitAnimationActionBuffState animation,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(animation);
    
      var component = new SpecialAnimationState();
      component.Animation = animation;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SummonedUnitBuff"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SummonedUnitBuff))]
    public BuffConfigurator AddSummonedUnitBuff(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SummonedUnitBuff();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponAttackTypeDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponAttackTypeDamageBonus))]
    public BuffConfigurator AddWeaponAttackTypeDamageBonus(
        WeaponRangeType type = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        ContextValue? value = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);
    
      var component = new WeaponAttackTypeDamageBonus();
      component.Type = type;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParams"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="customProperty"><see cref="Kingmaker.UnitLogic.Mechanics.Properties.BlueprintUnitProperty"/></param>
    [Generated]
    [Implements(typeof(ContextCalculateAbilityParams))]
    public BuffConfigurator AddContextCalculateAbilityParams(
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
    public BuffConfigurator AddContextCalculateAbilityParamsBasedOnClass(
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
    public BuffConfigurator AddContextCalculateSharedValue(
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
    public BuffConfigurator AddContextSetAbilityParams(
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
    /// Adds <see cref="AbilityDifficultyLimitDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityDifficultyLimitDC))]
    public BuffConfigurator AddAbilityDifficultyLimitDC(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityDifficultyLimitDC();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstTacticalOwner"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstTacticalOwner))]
    public BuffConfigurator AddAttackBonusAgainstTacticalOwner(
        TargetFilter targetFilter,
        ContextValue? value = null,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(targetFilter);
      ValidateParam(value);
    
      var component = new AttackBonusAgainstTacticalOwner();
      component.m_TargetFilter = targetFilter;
      component.m_Value = value ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstTacticalTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstTacticalTarget))]
    public BuffConfigurator AddAttackBonusAgainstTacticalTarget(
        TargetFilter targetFilter,
        ContextValue? value = null,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(targetFilter);
      ValidateParam(value);
    
      var component = new AttackBonusAgainstTacticalTarget();
      component.m_TargetFilter = targetFilter;
      component.m_Value = value ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstTacticalOwner"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageBonusAgainstTacticalOwner))]
    public BuffConfigurator AddDamageBonusAgainstTacticalOwner(
        TargetFilter targetFilter,
        Kingmaker.UnitLogic.Mechanics.ValueType _valueType = default,
        ContextValue? value = null,
        int bonusPercentValue = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(targetFilter);
      ValidateParam(value);
    
      var component = new DamageBonusAgainstTacticalOwner();
      component.m_TargetFilter = targetFilter;
      component._valueType = _valueType;
      component.m_Value = value ?? ContextValues.Constant(0);
      component.m_BonusPercentValue = bonusPercentValue;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstTacticalTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageBonusAgainstTacticalTarget))]
    public BuffConfigurator AddDamageBonusAgainstTacticalTarget(
        TargetFilter targetFilter,
        Kingmaker.UnitLogic.Mechanics.ValueType _valueType = default,
        ContextValue? value = null,
        int bonusPercentValue = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(targetFilter);
      ValidateParam(value);
    
      var component = new DamageBonusAgainstTacticalTarget();
      component.m_TargetFilter = targetFilter;
      component._valueType = _valueType;
      component.m_Value = value ?? ContextValues.Constant(0);
      component.m_BonusPercentValue = bonusPercentValue;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ReplaceSquadAbilities"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="newAbilities"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(ReplaceSquadAbilities))]
    public BuffConfigurator AddReplaceSquadAbilities(
        string[]? newAbilities = null,
        bool forOneTurn = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ReplaceSquadAbilities();
      component.m_NewAbilities = newAbilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToList();
      component.m_ForOneTurn = forOneTurn;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatConfusion"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="aiAttackNearestAction"><see cref="Kingmaker.Armies.TacticalCombat.Brain.BlueprintTacticalCombatAiAction"/></param>
    [Generated]
    [Implements(typeof(TacticalCombatConfusion))]
    public BuffConfigurator AddTacticalCombatConfusion(
        string? aiAttackNearestAction = null,
        ActionsBuilder? harmSelfAction = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TacticalCombatConfusion();
      component.m_AiAttackNearestAction = BlueprintTool.GetRef<BlueprintTacticalCombatAiActionReference>(aiAttackNearestAction);
      component.m_HarmSelfAction = harmSelfAction?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TacticalMoraleChanceModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalMoraleChanceModifier))]
    public BuffConfigurator AddTacticalMoraleChanceModifier(
        bool changePositiveMorale = default,
        ContextValue? positiveMoraleChancePercentDelta = null,
        bool changeNegativeMorale = default,
        ContextValue? negativeMoraleChancePercentDelta = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(positiveMoraleChancePercentDelta);
      ValidateParam(negativeMoraleChancePercentDelta);
    
      var component = new TacticalMoraleChanceModifier();
      component.m_ChangePositiveMorale = changePositiveMorale;
      component.m_PositiveMoraleChancePercentDelta = positiveMoraleChancePercentDelta ?? ContextValues.Constant(0);
      component.m_ChangeNegativeMorale = changeNegativeMorale;
      component.m_NegativeMoraleChancePercentDelta = negativeMoraleChancePercentDelta ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TargetingBlind"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TargetingBlind))]
    public BuffConfigurator AddTargetingBlind(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TargetingBlind();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BodyguardACBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(BodyguardACBonus))]
    public BuffConfigurator AddBodyguardACBonus(
        string? checkBuff = null,
        ModifierDescriptor descriptor = default,
        ContextValue? value = null)
    {
      ValidateParam(value);
    
      var component = new BodyguardACBonus();
      component.m_CheckBuff = BlueprintTool.GetRef<BlueprintBuffReference>(checkBuff);
      component.Descriptor = descriptor;
      component.Value = value ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffExtraEffects"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="extraEffectBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="exceptionFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(BuffExtraEffects))]
    public BuffConfigurator AddBuffExtraEffects(
        string? checkedBuff = null,
        string? extraEffectBuff = null,
        string? exceptionFact = null)
    {
      var component = new BuffExtraEffects();
      component.m_CheckedBuff = BlueprintTool.GetRef<BlueprintBuffReference>(checkedBuff);
      component.m_ExtraEffectBuff = BlueprintTool.GetRef<BlueprintBuffReference>(extraEffectBuff);
      component.m_ExceptionFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(exceptionFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="InHarmsWay"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    /// <param name="cooldownBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(InHarmsWay))]
    public BuffConfigurator AddInHarmsWay(
        string? checkBuff = null,
        string? cooldownBuff = null)
    {
      var component = new InHarmsWay();
      component.m_CheckBuff = BlueprintTool.GetRef<BlueprintBuffReference>(checkBuff);
      component.m_CooldownBuff = BlueprintTool.GetRef<BlueprintBuffReference>(cooldownBuff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IndomitableMount"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cooldownBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(IndomitableMount))]
    public BuffConfigurator AddIndomitableMount(
        string? cooldownBuff = null)
    {
      var component = new IndomitableMount();
      component.m_CooldownBuff = BlueprintTool.GetRef<BlueprintBuffReference>(cooldownBuff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MetamagicOnNextSpell"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MetamagicOnNextSpell))]
    public BuffConfigurator AddMetamagicOnNextSpell(
        Metamagic metamagic = default,
        bool doNotRemove = default,
        bool sourcerousReflex = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new MetamagicOnNextSpell();
      component.Metamagic = metamagic;
      component.DoNotRemove = doNotRemove;
      component.SourcerousReflex = sourcerousReflex;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="MetamagicRodMechanics"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="rodAbility"><see cref="Kingmaker.UnitLogic.ActivatableAbilities.BlueprintActivatableAbility"/></param>
    /// <param name="abilitiesWhiteList"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(MetamagicRodMechanics))]
    public BuffConfigurator AddMetamagicRodMechanics(
        Metamagic metamagic = default,
        int maxSpellLevel = default,
        string? rodAbility = null,
        string[]? abilitiesWhiteList = null)
    {
      var component = new MetamagicRodMechanics();
      component.Metamagic = metamagic;
      component.MaxSpellLevel = maxSpellLevel;
      component.m_RodAbility = BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(rodAbility);
      component.m_AbilitiesWhiteList = abilitiesWhiteList.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MountedCombat"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cooldownBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(MountedCombat))]
    public BuffConfigurator AddMountedCombat(
        string? cooldownBuff = null)
    {
      var component = new MountedCombat();
      component.m_CooldownBuff = BlueprintTool.GetRef<BlueprintBuffReference>(cooldownBuff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NeutralToFaction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="faction"><see cref="Kingmaker.Blueprints.BlueprintFaction"/></param>
    [Generated]
    [Implements(typeof(NeutralToFaction))]
    public BuffConfigurator AddNeutralToFaction(
        string? faction = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new NeutralToFaction();
      component.m_Faction = BlueprintTool.GetRef<BlueprintFactionReference>(faction);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SpecificSpellDamageBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spell"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(SpecificSpellDamageBonus))]
    public BuffConfigurator AddSpecificSpellDamageBonus(
        string[]? spell = null,
        int bonus = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SpecificSpellDamageBonus();
      component.m_Spell = spell.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.Bonus = bonus;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="UnwillingShield"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="masterAbility"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(UnwillingShield))]
    public BuffConfigurator AddUnwillingShield(
        string? masterAbility = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new UnwillingShield();
      component.m_MasterAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(masterAbility);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="UnwillingShieldTarget"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="masterAbility"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(UnwillingShieldTarget))]
    public BuffConfigurator AddUnwillingShieldTarget(
        string? masterAbility = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new UnwillingShieldTarget();
      component.m_MasterAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(masterAbility);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstCaster))]
    public BuffConfigurator AddACBonusAgainstCaster(
        ContextValue? value = null,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);
    
      var component = new ACBonusAgainstCaster();
      component.Value = value ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstTarget))]
    public BuffConfigurator AddACBonusAgainstTarget(
        ContextValue? value = null,
        bool checkCaster = default,
        bool checkCasterFriend = default,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);
    
      var component = new ACBonusAgainstTarget();
      component.Value = value ?? ContextValues.Constant(0);
      component.CheckCaster = checkCaster;
      component.CheckCasterFriend = checkCasterFriend;
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddAdditionalLimbIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weapon"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintItemWeapon"/></param>
    /// <param name="checkedFact"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddAdditionalLimbIfHasFact))]
    public BuffConfigurator AddAdditionalLimbIfHasFact(
        string? weapon = null,
        string? checkedFact = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddAdditionalLimbIfHasFact();
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weapon);
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintFeatureReference>(checkedFact);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusAbilityValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatBonusAbilityValue))]
    public BuffConfigurator AddStatBonusAbilityValue(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        ContextValue? value = null)
    {
      ValidateParam(value);
    
      var component = new AddStatBonusAbilityValue();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value ?? ContextValues.Constant(0);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddStatBonusIfHasFact))]
    public BuffConfigurator AddStatBonusIfHasFact(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        ContextValue? value = null,
        bool invertCondition = default,
        bool requireAllFacts = default,
        string[]? checkedFacts = null)
    {
      ValidateParam(value);
    
      var component = new AddStatBonusIfHasFact();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value ?? ContextValues.Constant(0);
      component.InvertCondition = invertCondition;
      component.RequireAllFacts = requireAllFacts;
      component.m_CheckedFacts = checkedFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusIfHasSkill"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatBonusIfHasSkill))]
    public BuffConfigurator AddStatBonusIfHasSkill(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int valueTrue = default,
        int valueFalse = default,
        StatType checkedSkill = default,
        int skillValue = default)
    {
      var component = new AddStatBonusIfHasSkill();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.ValueTrue = valueTrue;
      component.ValueFalse = valueFalse;
      component.CheckedSkill = checkedSkill;
      component.SkillValue = skillValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusScaled"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatBonusScaled))]
    public BuffConfigurator AddStatBonusScaled(
        BuffScaling scaling,
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int value = default)
    {
      ValidateParam(scaling);
    
      var component = new AddStatBonusScaled();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.Scaling = scaling;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ApplyBuffOnHit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ApplyBuffOnHit))]
    public BuffConfigurator AddApplyBuffOnHit(
        Rounds time,
        string? buff = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ApplyBuffOnHit();
      component.m_buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.time = time;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstCaster))]
    public BuffConfigurator AddAttackBonusAgainstCaster(
        ContextValue? value = null,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);
    
      var component = new AttackBonusAgainstCaster();
      component.Value = value ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstTarget))]
    public BuffConfigurator AddAttackBonusAgainstTarget(
        ContextValue? value = null,
        ModifierDescriptor descriptor = default,
        bool checkCaster = default,
        bool checkCasterFriend = default,
        bool checkRangeType = default,
        WeaponRangeType rangeType = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);
    
      var component = new AttackBonusAgainstTarget();
      component.Value = value ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      component.CheckCaster = checkCaster;
      component.CheckCasterFriend = checkCasterFriend;
      component.CheckRangeType = checkRangeType;
      component.RangeType = rangeType;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BuffInvisibility"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffInvisibility))]
    public BuffConfigurator AddBuffInvisibility(
        bool notDispellAfterOffensiveAction = default,
        int stealthBonus = default,
        bool dispelWithAChance = default,
        ContextValue? chance = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(chance);
    
      var component = new BuffInvisibility();
      component.NotDispellAfterOffensiveAction = notDispellAfterOffensiveAction;
      component.m_StealthBonus = stealthBonus;
      component.DispelWithAChance = dispelWithAChance;
      component.Chance = chance ?? ContextValues.Constant(0);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BuffPoisonStatDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffPoisonStatDamage))]
    public BuffConfigurator AddBuffPoisonStatDamage(
        DiceFormula value,
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int bonus = default,
        int ticks = default,
        int succesfullSaves = default,
        SavingThrowType saveType = default,
        bool noEffectOnFirstTick = default)
    {
      var component = new BuffPoisonStatDamage();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.Bonus = bonus;
      component.Ticks = ticks;
      component.SuccesfullSaves = succesfullSaves;
      component.SaveType = saveType;
      component.NoEffectOnFirstTick = noEffectOnFirstTick;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffPoisonStatDamageContext"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffPoisonStatDamageContext))]
    public BuffConfigurator AddBuffPoisonStatDamageContext(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        ContextDiceValue? value = null,
        ContextValue? bonus = null,
        ContextValue? ticks = null,
        ContextValue? succesfullSaves = null,
        SavingThrowType saveType = default,
        bool noEffectOnFirstTick = default)
    {
      ValidateParam(value);
      ValidateParam(bonus);
      ValidateParam(ticks);
      ValidateParam(succesfullSaves);
    
      var component = new BuffPoisonStatDamageContext();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value ?? Constants.Empty.DiceValue;
      component.Bonus = bonus ?? ContextValues.Constant(0);
      component.Ticks = ticks ?? ContextValues.Constant(0);
      component.SuccesfullSaves = succesfullSaves ?? ContextValues.Constant(0);
      component.SaveType = saveType;
      component.NoEffectOnFirstTick = noEffectOnFirstTick;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ControlledProjectileHolder"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ControlledProjectileHolder))]
    public BuffConfigurator AddControlledProjectileHolder(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ControlledProjectileHolder();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageBonusAgainstTarget))]
    public BuffConfigurator AddDamageBonusAgainstTarget(
        ContextValue? value = null,
        bool checkCaster = default,
        bool checkCasterFriend = default,
        bool applyToSpellDamage = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);
    
      var component = new DamageBonusAgainstTarget();
      component.Value = value ?? ContextValues.Constant(0);
      component.CheckCaster = checkCaster;
      component.CheckCasterFriend = checkCasterFriend;
      component.ApplyToSpellDamage = applyToSpellDamage;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="EqualForce"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EqualForce))]
    public BuffConfigurator AddEqualForce(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new EqualForce();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="GreaterSnapShotBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GreaterSnapShotBonus))]
    public BuffConfigurator AddGreaterSnapShotBonus(
        ContextValue? value = null,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);
    
      var component = new GreaterSnapShotBonus();
      component.Value = value ?? ContextValues.Constant(0);
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IgnoreTargetDR"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreTargetDR))]
    public BuffConfigurator AddIgnoreTargetDR(
        bool checkCaster = default,
        bool checkCasterFriend = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IgnoreTargetDR();
      component.CheckCaster = checkCaster;
      component.CheckCasterFriend = checkCasterFriend;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="OverrideLocoMotion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OverrideLocoMotion))]
    public BuffConfigurator AddOverrideLocoMotion(
        UnitAnimationActionLocoMotion locoMotion,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(locoMotion);
    
      var component = new OverrideLocoMotion();
      component.LocoMotion = locoMotion;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RemovedByHeal"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemovedByHeal))]
    public BuffConfigurator AddRemovedByHeal(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RemovedByHeal();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    protected override void ValidateInternal()
    {
      base.ValidateInternal();

      if (Blueprint.GetComponent<ITickEachRound>() == null)
      {
        AddValidationWarning($"ITickEachRound component is missing. Frequency and TickEachSecond will be ignored.");
      }
    }
  }
}

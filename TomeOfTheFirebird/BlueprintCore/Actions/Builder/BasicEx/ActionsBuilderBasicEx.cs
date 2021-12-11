using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Designers;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.NamedParameters;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Actions.Builder.BasicEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for most game mechanics related actions not included in
  /// <see cref="ContextEx.ActionsBuilderContextEx">ContextEx</see>.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderBasicEx
  {
    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.AttachBuff">AttachBuff</see>
    /// </summary>
    /// 
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/>BlueprintBuff</param>
    [Implements(typeof(AttachBuff))]
    public static ActionsBuilder AttachBuff(
        this ActionsBuilder builder, string buff, UnitEvaluator target, IntEvaluator duration)
    {
      builder.Validate(target);
      builder.Validate(duration);

      var attachBuff = ElementTool.Create<AttachBuff>();
      attachBuff.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      attachBuff.Target = target;
      attachBuff.Duration = duration;
      return builder.Add(attachBuff);
    }

    /// <summary>
    /// Adds <see cref="CreaturesAround"/>
    /// </summary>
    [Implements(typeof(CreaturesAround))]
    public static ActionsBuilder OnCreaturesAround(
        this ActionsBuilder builder,
        ActionsBuilder actions,
        FloatEvaluator radius,
        PositionEvaluator center,
        bool checkLos = false,
        bool targetDead = false)
    {
      builder.Validate(radius);
      builder.Validate(center);

      var onCreatures = ElementTool.Create<CreaturesAround>();
      onCreatures.Actions = actions.Build();
      onCreatures.Radius = radius;
      onCreatures.Center = center;
      onCreatures.CheckLos = checkLos;
      onCreatures.IncludeDead = targetDead;
      return builder.Add(onCreatures);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.AddFact">AddFact</see>
    /// </summary>
    ///
    /// <param name="fact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/>BlueprintUnitFact</param>
    [Implements(typeof(AddFact))]
    public static ActionsBuilder AddFact(this ActionsBuilder builder, string fact, UnitEvaluator target)
    {
      builder.Validate(target);

      var addFact = ElementTool.Create<AddFact>();
      addFact.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(fact);
      addFact.Unit = target;
      return builder.Add(addFact);
    }

    /// <summary>
    /// Adds <see cref="AddFatigueHours"/>
    /// </summary>
    [Implements(typeof(AddFatigueHours))]
    public static ActionsBuilder AddFatigue(this ActionsBuilder builder, IntEvaluator hours, UnitEvaluator target)
    {
      builder.Validate(hours);
      builder.Validate(target);

      var fatigue = ElementTool.Create<AddFatigueHours>();
      fatigue.Hours = hours;
      fatigue.Unit = target;
      return builder.Add(fatigue);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.ChangeAlignment">ChangeAlignment</see>
    /// </summary>
    [Implements(typeof(ChangeAlignment))]
    public static ActionsBuilder ChangeAlignment(
        this ActionsBuilder builder, UnitEvaluator target, Alignment alignment)
    {
      builder.Validate(target);

      var changeAlignment = ElementTool.Create<ChangeAlignment>();
      changeAlignment.Unit = target;
      changeAlignment.Alignment = alignment;
      return builder.Add(changeAlignment);
    }

    /// <summary>
    /// Adds
    /// <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.ChangePlayerAlignment">ChangePlayerAlignment</see>
    /// </summary>
    [Implements(typeof(ChangePlayerAlignment))]
    public static ActionsBuilder ChangePlayerAlignment(
        this ActionsBuilder builder, Alignment alignment, bool unlockAlignment = false)
    {
      var changeAlignment = ElementTool.Create<ChangePlayerAlignment>();
      changeAlignment.TargetAlignment = alignment;
      changeAlignment.CanUnlockAlignment = unlockAlignment;
      return builder.Add(changeAlignment);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.DamageParty">DamageParty</see>
    /// </summary>
    [Implements(typeof(DamageParty))]
    public static ActionsBuilder DamageParty(
        this ActionsBuilder builder,
        DamageDescription damage,
        UnitEvaluator? source = null,
        bool enableBattleLog = true)
    {
      var dmg = ElementTool.Create<DamageParty>();
      dmg.Damage = damage;
      dmg.DisableBattleLog = !enableBattleLog;

      if (source == null) { dmg.NoSource = true; }
      else
      {
        builder.Validate(source);
        dmg.DamageSource = source;
      }
      return builder.Add(dmg);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.DealDamage">DealDamage</see>
    /// </summary>
    [Implements(typeof(DealDamage))]
    public static ActionsBuilder DealDamage(
        this ActionsBuilder builder,
        UnitEvaluator target,
        DamageDescription damage,
        UnitEvaluator? source = null,
        bool enableBattleLog = true,
        bool enableFxAndSound = true)
    {
      builder.Validate(target);

      var dmg = ElementTool.Create<DealDamage>();
      dmg.Target = target;
      dmg.Damage = damage;
      dmg.DisableBattleLog = !enableBattleLog;
      dmg.DisableFxAndSound = !enableFxAndSound;

      if (source == null) { dmg.NoSource = true; }
      else
      {
        builder.Validate(source);
        dmg.Source = source;
      }
      return builder.Add(dmg);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.DealStatDamage">DealStatDamage</see>
    /// </summary>
    [Implements(typeof(DealStatDamage))]
    public static ActionsBuilder DealStatDamage(
        this ActionsBuilder builder,
        UnitEvaluator target,
        StatType type,
        DiceFormula damageDice,
        int damageBonus = 0,
        UnitEvaluator? source = null,
        bool drain = false,
        bool enableBattleLog = true)
    {
      builder.Validate(target);

      var dmg = ElementTool.Create<DealStatDamage>();
      dmg.Target = target;
      dmg.Stat = type;
      dmg.DamageDice = damageDice;
      dmg.DamageBonus = damageBonus;
      dmg.IsDrain = drain;
      dmg.DisableBattleLog = !enableBattleLog;

      if (source == null) { dmg.NoSource = true; }
      else
      {
        builder.Validate(source);
        dmg.Source = source;
      }
      return builder.Add(dmg);
    }

    /// <summary>
    /// Adds <see cref="AddItemsToCollection"/>
    /// </summary>
    [Implements(typeof(AddItemsToCollection))]
    public static ActionsBuilder AddItems(
        this ActionsBuilder builder,
        List<LootEntry> items,
        ItemsCollectionEvaluator toCollection,
        bool silent = false,
        bool identify = false)
    {
      builder.Validate(toCollection);

      var addItems = ElementTool.Create<AddItemsToCollection>();
      addItems.Loot = items;
      addItems.ItemsCollection = toCollection;
      addItems.Silent = silent;
      addItems.Identify = identify;
      return builder.Add(addItems);
    }

    /// <summary>
    /// Adds <see cref="AddItemsToCollection"/>
    /// </summary>
    /// 
    /// <param name="loot"><see cref="BlueprintUnitLoot">BlueprintUnitLoot</see></param>
    [Implements(typeof(AddItemsToCollection))]
    public static ActionsBuilder AddItemsFromBlueprint(
        this ActionsBuilder builder,
        string loot,
        ItemsCollectionEvaluator toCollection,
        bool silent = false,
        bool identify = false)
    {
      builder.Validate(toCollection);

      var addItems = ElementTool.Create<AddItemsToCollection>();
      addItems.m_BlueprintLoot = BlueprintTool.GetRef<BlueprintUnitLootReference>(loot);
      addItems.ItemsCollection = toCollection;
      addItems.Silent = silent;
      addItems.Identify = identify;
      return builder.Add(addItems);
    }

    /// <summary>
    /// Adds <see cref="AddItemToPlayer"/>
    /// </summary>
    /// 
    /// <remarks>
    /// <list type="bullet">
    /// <item>
    ///   <description>
    ///     If the item is a <see cref="BlueprintItemEquipmentHand"/> use <see cref="GiveHandSlotItemToPlayer"/>
    ///   </description>
    /// </item>
    /// <item>
    ///   <description>
    ///     If the item is a <see cref="BlueprintItemEquipment"/> use <see cref="GiveEquipmentToPlayer"/>
    ///   </description>
    /// </item>
    /// <item>
    ///   <description>
    ///     For any other items use <see cref="GiveItemToPlayer"/>.
    ///   </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// 
    /// <param name="item"><see cref="BlueprintItem"/></param>
    [Implements(typeof(AddItemToPlayer))]
    public static ActionsBuilder GiveItemToPlayer(
        this ActionsBuilder builder,
        string item,
        int count = 1,
        bool silent = false,
        bool identify = false)
    {
      var itemBlueprint = BlueprintTool.Get<BlueprintItem>(item);
      if (itemBlueprint is BlueprintItemEquipmentHand)
      {
        throw new InvalidOperationException(
            "Item fits in hand slot. Use GiveHandSlotItemToPlayer()");
      }
      else if (itemBlueprint is BlueprintItemEquipment)
      {
        throw new InvalidOperationException("Item is equippable. Use GiveEquipmentToPlayer()");
      }

      return GiveItemToPlayer(builder, itemBlueprint, count, silent, identify);
    }

    /// <inheritdoc cref="GiveItemToPlayer"/>
    /// <param name="equipment"><see cref="BlueprintItemEquipment"/></param>
    [Implements(typeof(AddItemToPlayer))]
    public static ActionsBuilder GiveEquipmentToPlayer(
        this ActionsBuilder builder,
        string equipment,
        bool equip = false,
        UnitEvaluator? equipOn = null,
        bool errorIfDidNotEquip = true,
        int count = 1,
        bool silent = false,
        bool identify = false)
    {
      var item = BlueprintTool.Get<BlueprintItemEquipment>(equipment);
      if (item is BlueprintItemEquipmentHand)
      {
        throw new InvalidOperationException(
            "Item fits in hand slot. Use GiveHandSlotItemToPlayer()");
      }

      return GiveItemToPlayer(
          builder,
          item,
          count,
          silent,
          identify,
          equip: equip,
          equipOn: equipOn,
          errorIfDidNotEquip: errorIfDidNotEquip);
    }

    /// <inheritdoc cref="GiveItemToPlayer"/>
    /// <param name="handItem"><see cref="BlueprintItemEquipmentHand"/></param>
    [Implements(typeof(AddItemToPlayer))]
    public static ActionsBuilder GiveHandSlotItemToPlayer(
        this ActionsBuilder builder,
        string handItem,
        bool equip = false,
        UnitEvaluator? equipOn = null,
        bool errorIfDidNotEquip = true,
        int preferredHandSlot = 0,
        int count = 1,
        bool silent = false,
        bool identify = false)
    {
      return GiveItemToPlayer(
          builder,
          BlueprintTool.Get<BlueprintItemEquipmentHand>(handItem),
          count,
          silent,
          identify,
          equip: equip,
          equipOn: equipOn,
          errorIfDidNotEquip: errorIfDidNotEquip,
          preferredHandSlot: preferredHandSlot);
    }

    private static ActionsBuilder GiveItemToPlayer(
        ActionsBuilder builder,
        BlueprintItem item,
        int count,
        bool silent,
        bool identify,
        bool equip = false,
        UnitEvaluator? equipOn = null,
        bool errorIfDidNotEquip = true,
        int preferredHandSlot = 0)
    {
      var giveItem = ElementTool.Create<AddItemToPlayer>();
      giveItem.m_ItemToGive = item.ToReference<BlueprintItemReference>();
      giveItem.Equip = equip;
      giveItem.ErrorIfDidNotEquip = errorIfDidNotEquip;
      giveItem.PreferredWeaponSet = preferredHandSlot;
      giveItem.Quantity = count;
      giveItem.Silent = silent;
      giveItem.Identify = identify;

      if (equipOn is not null)
      {
        builder.Validate(equipOn);
        giveItem.EquipOn = equipOn;
      }
      return builder.Add(giveItem);
    }

    /// <summary>
    /// Adds <see cref="AdvanceUnitLevel"/>
    /// </summary>
    [Implements(typeof(AdvanceUnitLevel))]
    public static ActionsBuilder AdvanceLevel(
        this ActionsBuilder builder, UnitEvaluator unit, IntEvaluator targetLevel)
    {
      builder.Validate(unit);
      builder.Validate(targetLevel);

      var advanceLevel = ElementTool.Create<AdvanceUnitLevel>();
      advanceLevel.Unit = unit;
      advanceLevel.Level = targetLevel;
      return builder.Add(advanceLevel);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.DestroyUnit">DestroyUnit</see>
    /// </summary>
    [Implements(typeof(DestroyUnit))]
    public static ActionsBuilder DestroyUnit(
        this ActionsBuilder builder, UnitEvaluator unit, bool fadeOut = false)
    {
      builder.Validate(unit);

      var destroy = ElementTool.Create<DestroyUnit>();
      destroy.Target = unit;
      destroy.FadeOut = fadeOut;
      return builder.Add(destroy);
    }

    /// <summary>
    /// Adds <see cref="CombineToGroup"/>
    /// </summary>
    [Implements(typeof(CombineToGroup))]
    public static ActionsBuilder AddUnitToGroup(
        this ActionsBuilder builder, UnitEvaluator unit, UnitEvaluator group)
    {
      builder.Validate(unit);
      builder.Validate(group);

      var addToGroup = ElementTool.Create<CombineToGroup>();
      addToGroup.TargetUnit = unit;
      addToGroup.GroupHolder = group;
      return builder.Add(addToGroup);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.ClearUnitReturnPosition">ClearUnitReturnPosition</see>
    /// </summary>
    [Implements(typeof(ClearUnitReturnPosition))]
    public static ActionsBuilder ClearUnitReturnPosition(
        this ActionsBuilder builder, UnitEvaluator unit)
    {
      builder.Validate(unit);

      var clearReturnPosition = ElementTool.Create<ClearUnitReturnPosition>();
      clearReturnPosition.Unit = unit;
      return builder.Add(clearReturnPosition);
    }

    /// <inheritdoc cref="ClearUnitReturnPosition"/>
    [Implements(typeof(ClearUnitReturnPosition))]
    public static ActionsBuilder ClearAllUnitReturnPosition(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ClearUnitReturnPosition>());
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.AddUnitToSummonPool">AddUnitToSummonPool</see>
    /// </summary>
    /// 
    /// <param name="pool"><see cref="BlueprintSummonPool"/></param>
    [Implements(typeof(AddUnitToSummonPool))]
    public static ActionsBuilder AddUnitToSummonPool(
        this ActionsBuilder builder, UnitEvaluator unit, string pool)
    {
      builder.Validate(unit);

      var addSummon = ElementTool.Create<AddUnitToSummonPool>();
      addSummon.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(pool);
      addSummon.Unit = unit;
      return builder.Add(addSummon);
    }

    /// <summary>
    /// Adds <see cref="DeleteUnitFromSummonPool"/>
    /// </summary>
    /// 
    /// <param name="pool"><see cref="BlueprintSummonPool"/></param>
    [Implements(typeof(DeleteUnitFromSummonPool))]
    public static ActionsBuilder RemoveUnitFromSummonPool(
        this ActionsBuilder builder, UnitEvaluator unit, string pool)
    {
      builder.Validate(unit);

      var addSummon = ElementTool.Create<DeleteUnitFromSummonPool>();
      addSummon.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(pool);
      addSummon.Unit = unit;
      return builder.Add(addSummon);
    }

    //----- Auto Generated -----//

    /// <summary>
    /// Adds <see cref="DetachBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(DetachBuff))]
    public static ActionsBuilder DetachBuff(
        this ActionsBuilder builder,
        UnitEvaluator target,
        string? buff = null)
    {
      builder.Validate(target);
    
      var element = ElementTool.Create<DetachBuff>();
      element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      element.Target = target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DisableExperienceFromUnit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableExperienceFromUnit))]
    public static ActionsBuilder DisableExperienceFromUnit(
        this ActionsBuilder builder,
        UnitEvaluator unit)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<DisableExperienceFromUnit>();
      element.Unit = unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DrainEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DrainEnergy))]
    public static ActionsBuilder DrainEnergy(
        this ActionsBuilder builder,
        UnitEvaluator source,
        UnitEvaluator target,
        Rounds duration,
        DiceFormula damageDice,
        bool noSource = default,
        EnergyDrainType type = default,
        int damageBonus = default,
        bool disableBattleLog = default)
    {
      builder.Validate(source);
      builder.Validate(target);
    
      var element = ElementTool.Create<DrainEnergy>();
      element.NoSource = noSource;
      element.Source = source;
      element.Target = target;
      element.Type = type;
      element.Duration = duration;
      element.DamageDice = damageDice;
      element.DamageBonus = damageBonus;
      element.DisableBattleLog = disableBattleLog;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="FakePartyRest"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(FakePartyRest))]
    public static ActionsBuilder FakePartyRest(
        this ActionsBuilder builder,
        bool immediate = default,
        bool ignoreCorruption = default,
        bool restWithCraft = default,
        ActionsBuilder? actionsOnRestEnd = null)
    {
      var element = ElementTool.Create<FakePartyRest>();
      element.m_Immediate = immediate;
      element.m_IgnoreCorruption = ignoreCorruption;
      element.m_RestWithCraft = restWithCraft;
      element.m_ActionsOnRestEnd = actionsOnRestEnd?.Build() ?? Constants.Empty.Actions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GainExp"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GainExp))]
    public static ActionsBuilder GainExp(
        this ActionsBuilder builder,
        IntEvaluator count,
        EncounterType encounter = default,
        int cR = default,
        float modifier = default,
        bool dummy = default)
    {
      builder.Validate(count);
    
      var element = ElementTool.Create<GainExp>();
      element.Encounter = encounter;
      element.CR = cR;
      element.Modifier = modifier;
      element.Count = count;
      element.Dummy = dummy;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GainMythicLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GainMythicLevel))]
    public static ActionsBuilder GainMythicLevel(
        this ActionsBuilder builder,
        int levels = default)
    {
      var element = ElementTool.Create<GainMythicLevel>();
      element.Levels = levels;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HealParty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HealParty))]
    public static ActionsBuilder HealParty(
        this ActionsBuilder builder,
        UnitEvaluator healSource)
    {
      builder.Validate(healSource);
    
      var element = ElementTool.Create<HealParty>();
      element.HealSource = healSource;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HealUnit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HealUnit))]
    public static ActionsBuilder HealUnit(
        this ActionsBuilder builder,
        UnitEvaluator source,
        UnitEvaluator target,
        IntEvaluator healAmount,
        bool toFullHP = default)
    {
      builder.Validate(source);
      builder.Validate(target);
      builder.Validate(healAmount);
    
      var element = ElementTool.Create<HealUnit>();
      element.Source = source;
      element.Target = target;
      element.ToFullHP = toFullHP;
      element.HealAmount = healAmount;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ItemSetCharges"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="item"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(ItemSetCharges))]
    public static ActionsBuilder ItemSetCharges(
        this ActionsBuilder builder,
        IntEvaluator charges,
        ItemsCollectionEvaluator collection,
        string? item = null)
    {
      builder.Validate(charges);
      builder.Validate(collection);
    
      var element = ElementTool.Create<ItemSetCharges>();
      element.m_Item = BlueprintTool.GetRef<BlueprintItemReference>(item);
      element.Charges = charges;
      element.Collection = collection;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Kill"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Kill))]
    public static ActionsBuilder Kill(
        this ActionsBuilder builder,
        UnitEvaluator target,
        UnitEvaluator killer,
        bool critical = default,
        bool disableBattleLog = default,
        bool removeExp = default)
    {
      builder.Validate(target);
      builder.Validate(killer);
    
      var element = ElementTool.Create<Kill>();
      element.Target = target;
      element.Killer = killer;
      element.Critical = critical;
      element.DisableBattleLog = disableBattleLog;
      element.RemoveExp = removeExp;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="LevelUpUnit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LevelUpUnit))]
    public static ActionsBuilder LevelUpUnit(
        this ActionsBuilder builder,
        UnitEvaluator unit,
        IntEvaluator targetLevel)
    {
      builder.Validate(unit);
      builder.Validate(targetLevel);
    
      var element = ElementTool.Create<LevelUpUnit>();
      element.Unit = unit;
      element.TargetLevel = targetLevel;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MeleeAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MeleeAttack))]
    public static ActionsBuilder MeleeAttack(
        this ActionsBuilder builder,
        UnitEvaluator caster,
        UnitEvaluator target,
        bool autoHit = default,
        bool ignoreStatBonus = default)
    {
      builder.Validate(caster);
      builder.Validate(target);
    
      var element = ElementTool.Create<MeleeAttack>();
      element.Caster = caster;
      element.Target = target;
      element.AutoHit = autoHit;
      element.IgnoreStatBonus = ignoreStatBonus;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PartyUnits"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PartyUnits))]
    public static ActionsBuilder PartyUnits(
        this ActionsBuilder builder,
        Player.CharactersList unitsList = default,
        ActionsBuilder? actions = null)
    {
      var element = ElementTool.Create<PartyUnits>();
      element.m_UnitsList = unitsList;
      element.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PartyUseAbility"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PartyUseAbility))]
    public static ActionsBuilder PartyUseAbility(
        this ActionsBuilder builder,
        AbilitiesHelper.AbilityDescription description,
        bool allowItems = default)
    {
      builder.Validate(description);
    
      var element = ElementTool.Create<PartyUseAbility>();
      element.Description = description;
      element.AllowItems = allowItems;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RaiseDead"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companion"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(RaiseDead))]
    public static ActionsBuilder RaiseDead(
        this ActionsBuilder builder,
        string? companion = null,
        bool riseAllCompanions = default)
    {
      var element = ElementTool.Create<RaiseDead>();
      element.m_companion = BlueprintTool.GetRef<BlueprintUnitReference>(companion);
      element.riseAllCompanions = riseAllCompanions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RandomAction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RandomAction))]
    public static ActionsBuilder RandomAction(
        this ActionsBuilder builder,
        ActionAndWeight[]? actions = null)
    {
      var element = ElementTool.Create<RandomAction>();
      element.Actions = actions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveDeathDoor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveDeathDoor))]
    public static ActionsBuilder RemoveDeathDoor(
        this ActionsBuilder builder,
        UnitEvaluator unit)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<RemoveDeathDoor>();
      element.Unit = unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="fact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(RemoveFact))]
    public static ActionsBuilder RemoveFact(
        this ActionsBuilder builder,
        UnitEvaluator unit,
        string? fact = null)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<RemoveFact>();
      element.Unit = unit;
      element.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(fact);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RollPartySkillCheck"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RollPartySkillCheck))]
    public static ActionsBuilder RollPartySkillCheck(
        this ActionsBuilder builder,
        StatType stat = default,
        int dC = default,
        bool logSuccess = default,
        bool logFailure = default,
        ActionsBuilder? onSuccess = null,
        ActionsBuilder? onFailure = null)
    {
      var element = ElementTool.Create<RollPartySkillCheck>();
      element.Stat = stat;
      element.DC = dC;
      element.LogSuccess = logSuccess;
      element.LogFailure = logFailure;
      element.OnSuccess = onSuccess?.Build() ?? Constants.Empty.Actions;
      element.OnFailure = onFailure?.Build() ?? Constants.Empty.Actions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RollSkillCheck"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RollSkillCheck))]
    public static ActionsBuilder RollSkillCheck(
        this ActionsBuilder builder,
        UnitEvaluator unit,
        StatType stat = default,
        int dC = default,
        bool logSuccess = default,
        bool logFailure = default,
        bool voice = default,
        bool forbidPartyHelpInCamp = default,
        ActionsBuilder? onSuccess = null,
        ActionsBuilder? onFailure = null)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<RollSkillCheck>();
      element.Stat = stat;
      element.Unit = unit;
      element.DC = dC;
      element.LogSuccess = logSuccess;
      element.LogFailure = logFailure;
      element.Voice = voice;
      element.ForbidPartyHelpInCamp = forbidPartyHelpInCamp;
      element.OnSuccess = onSuccess?.Build() ?? Constants.Empty.Actions;
      element.OnFailure = onFailure?.Build() ?? Constants.Empty.Actions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RunActionHolder"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="holder"><see cref="Kingmaker.ElementsSystem.ActionsHolder"/></param>
    [Generated]
    [Implements(typeof(RunActionHolder))]
    public static ActionsBuilder RunActionHolder(
        this ActionsBuilder builder,
        string comment,
        ParametrizedContextSetter parameters,
        string? holder = null)
    {
      builder.Validate(parameters);
    
      var element = ElementTool.Create<RunActionHolder>();
      element.Comment = comment;
      element.Holder = BlueprintTool.GetRef<ActionsReference>(holder);
      element.Parameters = parameters;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Spawn"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Spawn))]
    public static ActionsBuilder Spawn(
        this ActionsBuilder builder,
        EntityReference[]? spawners = null,
        ActionsBuilder? actionsOnSpawn = null)
    {
      builder.Validate(spawners);
    
      var element = ElementTool.Create<Spawn>();
      element.Spawners = spawners;
      element.ActionsOnSpawn = actionsOnSpawn?.Build() ?? Constants.Empty.Actions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SpawnBySummonPool"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="pool"><see cref="Kingmaker.Blueprints.BlueprintSummonPool"/></param>
    [Generated]
    [Implements(typeof(SpawnBySummonPool))]
    public static ActionsBuilder SpawnBySummonPool(
        this ActionsBuilder builder,
        string? pool = null,
        ActionsBuilder? actionsOnSpawn = null)
    {
      var element = ElementTool.Create<SpawnBySummonPool>();
      element.m_Pool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(pool);
      element.ActionsOnSpawn = actionsOnSpawn?.Build() ?? Constants.Empty.Actions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SpawnByUnitGroup"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpawnByUnitGroup))]
    public static ActionsBuilder SpawnByUnitGroup(
        this ActionsBuilder builder,
        EntityReference group,
        ActionsBuilder? actionsOnSpawn = null)
    {
      builder.Validate(group);
    
      var element = ElementTool.Create<SpawnByUnitGroup>();
      element.Group = group;
      element.ActionsOnSpawn = actionsOnSpawn?.Build() ?? Constants.Empty.Actions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="StatusEffect"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(StatusEffect))]
    public static ActionsBuilder StatusEffect(
        this ActionsBuilder builder,
        UnitEvaluator unit,
        UnitCondition condition = default,
        bool remove = default)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<StatusEffect>();
      element.Unit = unit;
      element.Condition = condition;
      element.Remove = remove;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Summon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unit"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    /// <param name="summonPool"><see cref="Kingmaker.Blueprints.BlueprintSummonPool"/></param>
    [Generated]
    [Implements(typeof(Summon))]
    public static ActionsBuilder Summon(
        this ActionsBuilder builder,
        TransformEvaluator transform,
        Vector3 offset,
        string? unit = null,
        string? summonPool = null,
        bool groupBySummonPool = default,
        ActionsBuilder? onSummmon = null)
    {
      builder.Validate(transform);
    
      var element = ElementTool.Create<Summon>();
      element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(unit);
      element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(summonPool);
      element.GroupBySummonPool = groupBySummonPool;
      element.Transform = transform;
      element.Offset = offset;
      element.OnSummmon = onSummmon?.Build() ?? Constants.Empty.Actions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SummonPoolUnits"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="summonPool"><see cref="Kingmaker.Blueprints.BlueprintSummonPool"/></param>
    [Generated]
    [Implements(typeof(SummonPoolUnits))]
    public static ActionsBuilder SummonPoolUnits(
        this ActionsBuilder builder,
        string? summonPool = null,
        ConditionsBuilder? conditions = null,
        ActionsBuilder? actions = null)
    {
      var element = ElementTool.Create<SummonPoolUnits>();
      element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(summonPool);
      element.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      element.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SummonUnitCopy"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="copyBlueprint"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    /// <param name="summonPool"><see cref="Kingmaker.Blueprints.BlueprintSummonPool"/></param>
    [Generated]
    [Implements(typeof(SummonUnitCopy))]
    public static ActionsBuilder SummonUnitCopy(
        this ActionsBuilder builder,
        UnitEvaluator copyFrom,
        LocatorEvaluator locator,
        string? copyBlueprint = null,
        string? summonPool = null,
        bool doNotCreateItems = default,
        ActionsBuilder? onSummon = null)
    {
      builder.Validate(copyFrom);
      builder.Validate(locator);
    
      var element = ElementTool.Create<SummonUnitCopy>();
      element.CopyFrom = copyFrom;
      element.Locator = locator;
      element.m_CopyBlueprint = BlueprintTool.GetRef<BlueprintUnitReference>(copyBlueprint);
      element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(summonPool);
      element.DoNotCreateItems = doNotCreateItems;
      element.OnSummon = onSummon?.Build() ?? Constants.Empty.Actions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwitchActivatableAbility"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="Kingmaker.UnitLogic.ActivatableAbilities.BlueprintActivatableAbility"/></param>
    [Generated]
    [Implements(typeof(SwitchActivatableAbility))]
    public static ActionsBuilder SwitchActivatableAbility(
        this ActionsBuilder builder,
        UnitEvaluator unit,
        string? ability = null,
        bool isOn = default)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<SwitchActivatableAbility>();
      element.Unit = unit;
      element.m_Ability = BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(ability);
      element.IsOn = isOn;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwitchDualCompanion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SwitchDualCompanion))]
    public static ActionsBuilder SwitchDualCompanion(
        this ActionsBuilder builder,
        UnitEvaluator unit)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<SwitchDualCompanion>();
      element.Unit = unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitsFromSpawnersInUnitGroup"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitsFromSpawnersInUnitGroup))]
    public static ActionsBuilder UnitsFromSpawnersInUnitGroup(
        this ActionsBuilder builder,
        EntityReference group,
        ActionsBuilder? actions = null)
    {
      builder.Validate(group);
    
      var element = ElementTool.Create<UnitsFromSpawnersInUnitGroup>();
      element.m_Group = group;
      element.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return builder.Add(element);
    }
  }
}

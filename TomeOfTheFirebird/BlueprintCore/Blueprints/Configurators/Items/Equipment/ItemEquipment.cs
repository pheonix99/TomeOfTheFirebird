using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Components;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Alignments;
using System;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemEquipment"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipment))]
  public abstract class BaseItemEquipmentConfigurator<T, TBuilder>
      : BaseItemConfigurator<T, TBuilder>
      where T : BlueprintItemEquipment
      where TBuilder : BaseItemEquipmentConfigurator<T, TBuilder>
  {
    protected BaseItemEquipmentConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.CR"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCR(int cR)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CR = cR;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.m_Ability"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    public TBuilder SetAbility(string? ability)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.m_ActivatableAbility"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="activatableAbility"><see cref="Kingmaker.UnitLogic.ActivatableAbilities.BlueprintActivatableAbility"/></param>
    [Generated]
    public TBuilder SetActivatableAbility(string? activatableAbility)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ActivatableAbility = BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(activatableAbility);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.SpendCharges"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetSpendCharges(bool spendCharges)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SpendCharges = spendCharges;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.Charges"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCharges(int charges)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Charges = charges;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.RestoreChargesOnRest"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetRestoreChargesOnRest(bool restoreChargesOnRest)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RestoreChargesOnRest = restoreChargesOnRest;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.CasterLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCasterLevel(int casterLevel)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CasterLevel = casterLevel;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.SpellLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetSpellLevel(int spellLevel)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SpellLevel = spellLevel;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.DC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDC(int dC)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DC = dC;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.IsNonRemovable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIsNonRemovable(bool isNonRemovable)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsNonRemovable = isNonRemovable;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.m_EquipmentEntity"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="equipmentEntity"><see cref="Kingmaker.Visual.CharacterSystem.KingmakerEquipmentEntity"/></param>
    [Generated]
    public TBuilder SetEquipmentEntity(string? equipmentEntity)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_EquipmentEntity = BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(equipmentEntity);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.m_EquipmentEntityAlternatives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="equipmentEntityAlternatives"><see cref="Kingmaker.Visual.CharacterSystem.KingmakerEquipmentEntity"/></param>
    [Generated]
    public TBuilder SetEquipmentEntityAlternatives(string[]? equipmentEntityAlternatives)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_EquipmentEntityAlternatives = equipmentEntityAlternatives.Select(name => BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintItemEquipment.m_EquipmentEntityAlternatives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="equipmentEntityAlternatives"><see cref="Kingmaker.Visual.CharacterSystem.KingmakerEquipmentEntity"/></param>
    [Generated]
    public TBuilder AddToEquipmentEntityAlternatives(params string[] equipmentEntityAlternatives)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_EquipmentEntityAlternatives = CommonTool.Append(bp.m_EquipmentEntityAlternatives, equipmentEntityAlternatives.Select(name => BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintItemEquipment.m_EquipmentEntityAlternatives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="equipmentEntityAlternatives"><see cref="Kingmaker.Visual.CharacterSystem.KingmakerEquipmentEntity"/></param>
    [Generated]
    public TBuilder RemoveFromEquipmentEntityAlternatives(params string[] equipmentEntityAlternatives)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = equipmentEntityAlternatives.Select(name => BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(name));
            bp.m_EquipmentEntityAlternatives =
                bp.m_EquipmentEntityAlternatives
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.m_ForcedRampColorPresetIndex"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetForcedRampColorPresetIndex(int forcedRampColorPresetIndex)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ForcedRampColorPresetIndex = forcedRampColorPresetIndex;
          });
    }

    /// <summary>
    /// Adds <see cref="AddFactToEquipmentWielder"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="fact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddFactToEquipmentWielder))]
    public TBuilder AddFactToEquipmentWielder(
        string? fact = null)
    {
      var component = new AddFactToEquipmentWielder();
      component.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(fact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EquipmentRestrictionAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EquipmentRestrictionAlignment))]
    public TBuilder AddEquipmentRestrictionAlignment(
        AlignmentMaskType alignment = default)
    {
      var component = new EquipmentRestrictionAlignment();
      component.Alignment = alignment;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EquipmentRestrictionCannotEquip"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EquipmentRestrictionCannotEquip))]
    public TBuilder AddEquipmentRestrictionCannotEquip()
    {
      return AddComponent(new EquipmentRestrictionCannotEquip());
    }

    /// <summary>
    /// Adds <see cref="EquipmentRestrictionClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="clazz"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(EquipmentRestrictionClass))]
    public TBuilder AddEquipmentRestrictionClass(
        string? clazz = null,
        bool not = default)
    {
      var component = new EquipmentRestrictionClass();
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      component.Not = not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EquipmentRestrictionHasAnyClassFromList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="classes"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(EquipmentRestrictionHasAnyClassFromList))]
    public TBuilder AddEquipmentRestrictionHasAnyClassFromList(
        bool not = default,
        string[]? classes = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new EquipmentRestrictionHasAnyClassFromList();
      component.Not = not;
      component.m_Classes = classes.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="EquipmentRestrictionMainPlayer"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EquipmentRestrictionMainPlayer))]
    public TBuilder AddEquipmentRestrictionMainPlayer(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new EquipmentRestrictionMainPlayer();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="EquipmentRestrictionSpecialUnit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blueprint"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(EquipmentRestrictionSpecialUnit))]
    public TBuilder AddEquipmentRestrictionSpecialUnit(
        string? blueprint = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new EquipmentRestrictionSpecialUnit();
      component.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitReference>(blueprint);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="EquipmentRestrictionStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EquipmentRestrictionStat))]
    public TBuilder AddEquipmentRestrictionStat(
        StatType stat = default,
        int minValue = default)
    {
      var component = new EquipmentRestrictionStat();
      component.Stat = stat;
      component.MinValue = minValue;
      return AddComponent(component);
    }
  }
}

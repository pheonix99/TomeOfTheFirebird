using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using System;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Classes.Spells
{
  /// <summary>
  /// Configurator for <see cref="BlueprintSpellbook"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintSpellbook))]
  public class SpellbookConfigurator : BaseBlueprintConfigurator<BlueprintSpellbook, SpellbookConfigurator>
  {
    private SpellbookConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SpellbookConfigurator For(string name)
    {
      return new SpellbookConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SpellbookConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintSpellbook>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.Name"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetName(LocalizedString? name)
    {
      ValidateParam(name);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Name = name ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.IsMythic"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetIsMythic(bool isMythic)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsMythic = isMythic;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.m_SpellsPerDay"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellsPerDay"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellsTable"/></param>
    [Generated]
    public SpellbookConfigurator SetSpellsPerDay(string? spellsPerDay)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SpellsPerDay = BlueprintTool.GetRef<BlueprintSpellsTableReference>(spellsPerDay);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.m_SpellsKnown"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellsKnown"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellsTable"/></param>
    [Generated]
    public SpellbookConfigurator SetSpellsKnown(string? spellsKnown)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SpellsKnown = BlueprintTool.GetRef<BlueprintSpellsTableReference>(spellsKnown);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.m_SpellSlots"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellSlots"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellsTable"/></param>
    [Generated]
    public SpellbookConfigurator SetSpellSlots(string? spellSlots)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SpellSlots = BlueprintTool.GetRef<BlueprintSpellsTableReference>(spellSlots);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.m_SpellList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellList"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellList"/></param>
    [Generated]
    public SpellbookConfigurator SetSpellList(string? spellList)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(spellList);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.m_MythicSpellList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="mythicSpellList"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellList"/></param>
    [Generated]
    public SpellbookConfigurator SetMythicSpellList(string? mythicSpellList)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MythicSpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(mythicSpellList);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.m_CharacterClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    public SpellbookConfigurator SetCharacterClass(string? characterClass)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.CastingAttribute"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetCastingAttribute(StatType castingAttribute)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CastingAttribute = castingAttribute;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.Spontaneous"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetSpontaneous(bool spontaneous)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Spontaneous = spontaneous;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.SpellsPerLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetSpellsPerLevel(int spellsPerLevel)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SpellsPerLevel = spellsPerLevel;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.AllSpellsKnown"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetAllSpellsKnown(bool allSpellsKnown)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AllSpellsKnown = allSpellsKnown;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.CantripsType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetCantripsType(CantripsType cantripsType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CantripsType = cantripsType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.CasterLevelModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetCasterLevelModifier(int casterLevelModifier)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CasterLevelModifier = casterLevelModifier;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.CanCopyScrolls"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetCanCopyScrolls(bool canCopyScrolls)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CanCopyScrolls = canCopyScrolls;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.IsArcane"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetIsArcane(bool isArcane)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsArcane = isArcane;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.IsArcanist"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetIsArcanist(bool isArcanist)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsArcanist = isArcanist;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.HasSpecialSpellList"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetHasSpecialSpellList(bool hasSpecialSpellList)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HasSpecialSpellList = hasSpecialSpellList;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.SpecialSpellListName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetSpecialSpellListName(LocalizedString? specialSpellListName)
    {
      ValidateParam(specialSpellListName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.SpecialSpellListName = specialSpellListName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Adds <see cref="AddCustomSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellList"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellList"/></param>
    [Generated]
    [Implements(typeof(AddCustomSpells))]
    public SpellbookConfigurator AddCustomSpells(
        int casterLevel = default,
        string? spellList = null,
        int maxSpellLevel = default,
        int count = default)
    {
      var component = new AddCustomSpells();
      component.CasterLevel = casterLevel;
      component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(spellList);
      component.MaxSpellLevel = maxSpellLevel;
      component.Count = count;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IsAlchemistSpellbook"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsAlchemistSpellbook))]
    public SpellbookConfigurator AddIsAlchemistSpellbook(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IsAlchemistSpellbook();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IsSinMagicSpecialistSpellbook"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsSinMagicSpecialistSpellbook))]
    public SpellbookConfigurator AddIsSinMagicSpecialistSpellbook(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IsSinMagicSpecialistSpellbook();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}

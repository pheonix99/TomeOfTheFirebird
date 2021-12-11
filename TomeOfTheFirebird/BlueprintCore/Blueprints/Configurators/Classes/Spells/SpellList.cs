using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Classes.Spells
{
  /// <summary>
  /// Configurator for <see cref="BlueprintSpellList"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintSpellList))]
  public class SpellListConfigurator : BaseBlueprintConfigurator<BlueprintSpellList, SpellListConfigurator>
  {
    private SpellListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SpellListConfigurator For(string name)
    {
      return new SpellListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SpellListConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintSpellList>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellList.IsMythic"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellListConfigurator SetIsMythic(bool isMythic)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsMythic = isMythic;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellList.SpellsByLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellListConfigurator SetSpellsByLevel(SpellLevelList[]? spellsByLevel)
    {
      ValidateParam(spellsByLevel);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.SpellsByLevel = spellsByLevel;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintSpellList.SpellsByLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellListConfigurator AddToSpellsByLevel(params SpellLevelList[] spellsByLevel)
    {
      ValidateParam(spellsByLevel);
      return OnConfigureInternal(
          bp =>
          {
            bp.SpellsByLevel = CommonTool.Append(bp.SpellsByLevel, spellsByLevel ?? new SpellLevelList[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintSpellList.SpellsByLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellListConfigurator RemoveFromSpellsByLevel(params SpellLevelList[] spellsByLevel)
    {
      ValidateParam(spellsByLevel);
      return OnConfigureInternal(
          bp =>
          {
            bp.SpellsByLevel = bp.SpellsByLevel.Where(item => !spellsByLevel.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellList.m_FilteredList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="filteredList"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellList"/></param>
    [Generated]
    public SpellListConfigurator SetFilteredList(string? filteredList)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_FilteredList = BlueprintTool.GetRef<BlueprintSpellListReference>(filteredList);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellList.FilterByMaxLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellListConfigurator SetFilterByMaxLevel(int filterByMaxLevel)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FilterByMaxLevel = filterByMaxLevel;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellList.FilterByDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellListConfigurator SetFilterByDescriptor(bool filterByDescriptor)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FilterByDescriptor = filterByDescriptor;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellList.Descriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellListConfigurator SetDescriptor(SpellDescriptorWrapper descriptor)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Descriptor = descriptor;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellList.FilterBySchool"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellListConfigurator SetFilterBySchool(bool filterBySchool)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FilterBySchool = filterBySchool;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellList.ExcludeFilterSchool"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellListConfigurator SetExcludeFilterSchool(bool excludeFilterSchool)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ExcludeFilterSchool = excludeFilterSchool;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellList.FilterSchool"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellListConfigurator SetFilterSchool(SpellSchool filterSchool)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FilterSchool = filterSchool;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellList.FilterSchool2"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellListConfigurator SetFilterSchool2(SpellSchool filterSchool2)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FilterSchool2 = filterSchool2;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellList.m_MaxLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellListConfigurator SetMaxLevel(int maxLevel)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MaxLevel = maxLevel;
          });
    }
  }
}

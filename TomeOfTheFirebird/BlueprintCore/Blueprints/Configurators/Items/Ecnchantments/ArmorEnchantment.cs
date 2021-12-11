using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Designers.Mechanics.EquipmentEnchants;
using Kingmaker.Designers.Mechanics.Facts;
using System;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items.Ecnchantments
{
  /// <summary>
  /// Configurator for <see cref="BlueprintArmorEnchantment"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArmorEnchantment))]
  public class ArmorEnchantmentConfigurator : BaseEquipmentEnchantmentConfigurator<BlueprintArmorEnchantment, ArmorEnchantmentConfigurator>
  {
    private ArmorEnchantmentConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArmorEnchantmentConfigurator For(string name)
    {
      return new ArmorEnchantmentConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArmorEnchantmentConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintArmorEnchantment>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="ArmorEnhancementBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmorEnhancementBonus))]
    public ArmorEnchantmentConfigurator AddArmorEnhancementBonus(
        int enhancementValue = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ArmorEnhancementBonus();
      component.EnhancementValue = enhancementValue;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddSavesFixerArmorRecalculator"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddSavesFixerArmorRecalculator))]
    public ArmorEnchantmentConfigurator AddSavesFixerArmorRecalculator(
        string? feature = null)
    {
      var component = new AddSavesFixerArmorRecalculator();
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AdvanceArmorStats"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AdvanceArmorStats))]
    public ArmorEnchantmentConfigurator AddAdvanceArmorStats(
        int maxDexBonusShift = default,
        int armorCheckPenaltyShift = default,
        int arcaneSpellFailureShift = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AdvanceArmorStats();
      component.MaxDexBonusShift = maxDexBonusShift;
      component.ArmorCheckPenaltyShift = armorCheckPenaltyShift;
      component.ArcaneSpellFailureShift = arcaneSpellFailureShift;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}

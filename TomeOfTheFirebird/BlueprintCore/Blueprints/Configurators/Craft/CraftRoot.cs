using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Craft;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Craft
{
  /// <summary>
  /// Configurator for <see cref="CraftRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(CraftRoot))]
  public class CraftRootConfigurator : BaseBlueprintConfigurator<CraftRoot, CraftRootConfigurator>
  {
    private CraftRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CraftRootConfigurator For(string name)
    {
      return new CraftRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CraftRootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<CraftRoot>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="CraftRoot.m_CraftCostMultiplyer"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CraftRootConfigurator SetCraftCostMultiplyer(int craftCostMultiplyer)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CraftCostMultiplyer = craftCostMultiplyer;
          });
    }

    /// <summary>
    /// Sets <see cref="CraftRoot.m_CostForCraftDay"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CraftRootConfigurator SetCostForCraftDay(int costForCraftDay)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CostForCraftDay = costForCraftDay;
          });
    }

    /// <summary>
    /// Sets <see cref="CraftRoot.m_BaseCraftedAbilityDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CraftRootConfigurator SetBaseCraftedAbilityDC(int baseCraftedAbilityDC)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_BaseCraftedAbilityDC = baseCraftedAbilityDC;
          });
    }

    /// <summary>
    /// Sets <see cref="CraftRoot.m_BaseCraftDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CraftRootConfigurator SetBaseCraftDC(int baseCraftDC)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_BaseCraftDC = baseCraftDC;
          });
    }

    /// <summary>
    /// Sets <see cref="CraftRoot.m_PotionRequirements"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CraftRootConfigurator SetPotionRequirements(CraftRequirements[]? potionRequirements)
    {
      ValidateParam(potionRequirements);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_PotionRequirements = potionRequirements;
          });
    }

    /// <summary>
    /// Adds to <see cref="CraftRoot.m_PotionRequirements"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CraftRootConfigurator AddToPotionRequirements(params CraftRequirements[] potionRequirements)
    {
      ValidateParam(potionRequirements);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_PotionRequirements = CommonTool.Append(bp.m_PotionRequirements, potionRequirements ?? new CraftRequirements[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="CraftRoot.m_PotionRequirements"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CraftRootConfigurator RemoveFromPotionRequirements(params CraftRequirements[] potionRequirements)
    {
      ValidateParam(potionRequirements);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_PotionRequirements = bp.m_PotionRequirements.Where(item => !potionRequirements.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="CraftRoot.m_ScrollsRequirements"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CraftRootConfigurator SetScrollsRequirements(CraftRequirements[]? scrollsRequirements)
    {
      ValidateParam(scrollsRequirements);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ScrollsRequirements = scrollsRequirements;
          });
    }

    /// <summary>
    /// Adds to <see cref="CraftRoot.m_ScrollsRequirements"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CraftRootConfigurator AddToScrollsRequirements(params CraftRequirements[] scrollsRequirements)
    {
      ValidateParam(scrollsRequirements);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ScrollsRequirements = CommonTool.Append(bp.m_ScrollsRequirements, scrollsRequirements ?? new CraftRequirements[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="CraftRoot.m_ScrollsRequirements"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CraftRootConfigurator RemoveFromScrollsRequirements(params CraftRequirements[] scrollsRequirements)
    {
      ValidateParam(scrollsRequirements);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ScrollsRequirements = bp.m_ScrollsRequirements.Where(item => !scrollsRequirements.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="CraftRoot.m_PotionsItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="potionsItems"><see cref="Kingmaker.Blueprints.Items.Equipment.BlueprintItemEquipmentUsable"/></param>
    [Generated]
    public CraftRootConfigurator SetPotionsItems(string[]? potionsItems)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_PotionsItems = potionsItems.Select(name => BlueprintTool.GetRef<BlueprintItemEquipmentUsableReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="CraftRoot.m_PotionsItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="potionsItems"><see cref="Kingmaker.Blueprints.Items.Equipment.BlueprintItemEquipmentUsable"/></param>
    [Generated]
    public CraftRootConfigurator AddToPotionsItems(params string[] potionsItems)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_PotionsItems.AddRange(potionsItems.Select(name => BlueprintTool.GetRef<BlueprintItemEquipmentUsableReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="CraftRoot.m_PotionsItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="potionsItems"><see cref="Kingmaker.Blueprints.Items.Equipment.BlueprintItemEquipmentUsable"/></param>
    [Generated]
    public CraftRootConfigurator RemoveFromPotionsItems(params string[] potionsItems)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = potionsItems.Select(name => BlueprintTool.GetRef<BlueprintItemEquipmentUsableReference>(name));
            bp.m_PotionsItems =
                bp.m_PotionsItems
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="CraftRoot.m_ScrollsItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="scrollsItems"><see cref="Kingmaker.Blueprints.Items.Equipment.BlueprintItemEquipmentUsable"/></param>
    [Generated]
    public CraftRootConfigurator SetScrollsItems(string[]? scrollsItems)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ScrollsItems = scrollsItems.Select(name => BlueprintTool.GetRef<BlueprintItemEquipmentUsableReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="CraftRoot.m_ScrollsItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="scrollsItems"><see cref="Kingmaker.Blueprints.Items.Equipment.BlueprintItemEquipmentUsable"/></param>
    [Generated]
    public CraftRootConfigurator AddToScrollsItems(params string[] scrollsItems)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ScrollsItems.AddRange(scrollsItems.Select(name => BlueprintTool.GetRef<BlueprintItemEquipmentUsableReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="CraftRoot.m_ScrollsItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="scrollsItems"><see cref="Kingmaker.Blueprints.Items.Equipment.BlueprintItemEquipmentUsable"/></param>
    [Generated]
    public CraftRootConfigurator RemoveFromScrollsItems(params string[] scrollsItems)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = scrollsItems.Select(name => BlueprintTool.GetRef<BlueprintItemEquipmentUsableReference>(name));
            bp.m_ScrollsItems =
                bp.m_ScrollsItems
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="CraftRoot.m_IngredientTable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CraftRootConfigurator SetIngredientTable(IngredientTable ingredientTable)
    {
      ValidateParam(ingredientTable);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IngredientTable = ingredientTable;
          });
    }

    /// <summary>
    /// Sets <see cref="CraftRoot.m_CollectingRoot"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CraftRootConfigurator SetCollectingRoot(CollectIngredientRoot collectingRoot)
    {
      ValidateParam(collectingRoot);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CollectingRoot = collectingRoot;
          });
    }
  }
}

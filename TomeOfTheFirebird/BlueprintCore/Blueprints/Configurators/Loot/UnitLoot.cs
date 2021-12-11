using BlueprintCore.Utils;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Dungeon.Blueprints;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Loot
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintUnitLoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnitLoot))]
  public abstract class BaseUnitLootConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintUnitLoot
      where TBuilder : BaseUnitLootConfigurator<T, TBuilder>
  {
    protected BaseUnitLootConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintUnitLoot.m_Dummy"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDummy(BlueprintUnitLoot.Dummy dummy)
    {
      ValidateParam(dummy);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Dummy = dummy;
          });
    }

    /// <summary>
    /// Adds <see cref="DungeonVendorItemsComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DungeonVendorItemsComponent))]
    public TBuilder AddDungeonVendorItemsComponent(
        bool bigTable = default,
        int minCR = default,
        int count = default)
    {
      var component = new DungeonVendorItemsComponent();
      component.BigTable = bigTable;
      component.MinCR = minCR;
      component.Count = count;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LootItemsPackFixed"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LootItemsPackFixed))]
    public TBuilder AddLootItemsPackFixed(
        LootItem item,
        int count = default)
    {
      ValidateParam(item);
    
      var component = new LootItemsPackFixed();
      component.m_Item = item;
      component.m_Count = count;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LootItemsPackVariable"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LootItemsPackVariable))]
    public TBuilder AddLootItemsPackVariable(
        LootItem item,
        int countFrom = default,
        int countTo = default)
    {
      ValidateParam(item);
    
      var component = new LootItemsPackVariable();
      component.m_Item = item;
      component.m_CountFrom = countFrom;
      component.m_CountTo = countTo;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LootRandomItem"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LootRandomItem))]
    public TBuilder AddLootRandomItem(
        LootItemAndWeight[]? items = null)
    {
      ValidateParam(items);
    
      var component = new LootRandomItem();
      component.m_Items = items;
      return AddComponent(component);
    }
  }

  /// <summary>
  /// Configurator for <see cref="BlueprintUnitLoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnitLoot))]
  public class UnitLootConfigurator : BaseBlueprintConfigurator<BlueprintUnitLoot, UnitLootConfigurator>
  {
    private UnitLootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitLootConfigurator For(string name)
    {
      return new UnitLootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitLootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintUnitLoot>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnitLoot.m_Dummy"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitLootConfigurator SetDummy(BlueprintUnitLoot.Dummy dummy)
    {
      ValidateParam(dummy);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Dummy = dummy;
          });
    }

    /// <summary>
    /// Adds <see cref="DungeonVendorItemsComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DungeonVendorItemsComponent))]
    public UnitLootConfigurator AddDungeonVendorItemsComponent(
        bool bigTable = default,
        int minCR = default,
        int count = default)
    {
      var component = new DungeonVendorItemsComponent();
      component.BigTable = bigTable;
      component.MinCR = minCR;
      component.Count = count;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LootItemsPackFixed"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LootItemsPackFixed))]
    public UnitLootConfigurator AddLootItemsPackFixed(
        LootItem item,
        int count = default)
    {
      ValidateParam(item);
    
      var component = new LootItemsPackFixed();
      component.m_Item = item;
      component.m_Count = count;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LootItemsPackVariable"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LootItemsPackVariable))]
    public UnitLootConfigurator AddLootItemsPackVariable(
        LootItem item,
        int countFrom = default,
        int countTo = default)
    {
      ValidateParam(item);
    
      var component = new LootItemsPackVariable();
      component.m_Item = item;
      component.m_CountFrom = countFrom;
      component.m_CountTo = countTo;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LootRandomItem"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LootRandomItem))]
    public UnitLootConfigurator AddLootRandomItem(
        LootItemAndWeight[]? items = null)
    {
      ValidateParam(items);
    
      var component = new LootRandomItem();
      component.m_Items = items;
      return AddComponent(component);
    }
  }
}

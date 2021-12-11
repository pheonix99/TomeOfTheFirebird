using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.Dungeon.Blueprints.Boons;
using Kingmaker.Dungeon.Enums;
using Kingmaker.Localization;
using System;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Configurator for <see cref="BlueprintDungeonBoon"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintDungeonBoon))]
  public class DungeonBoonConfigurator : BaseBlueprintConfigurator<BlueprintDungeonBoon, DungeonBoonConfigurator>
  {
    private DungeonBoonConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DungeonBoonConfigurator For(string name)
    {
      return new DungeonBoonConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DungeonBoonConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintDungeonBoon>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonBoon.Name"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonBoonConfigurator SetName(LocalizedString? name)
    {
      ValidateParam(name);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Name = name ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonBoon.Icon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonBoonConfigurator SetIcon(Sprite icon)
    {
      ValidateParam(icon);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Icon = icon;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonBoon.m_Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonBoonConfigurator SetDescription(LocalizedString? description)
    {
      ValidateParam(description);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Description = description ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonBoon.MinStage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonBoonConfigurator SetMinStage(int minStage)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MinStage = minStage;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonBoon.m_CachedLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonBoonConfigurator SetCachedLogic(DungeonBoonLogic cachedLogic)
    {
      ValidateParam(cachedLogic);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedLogic = cachedLogic;
          });
    }

    /// <summary>
    /// Adds <see cref="BoonLogicExperience"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BoonLogicExperience))]
    public DungeonBoonConfigurator AddBoonLogicExperience(
        int step = default,
        int start = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new BoonLogicExperience();
      component.Step = step;
      component.Start = start;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BoonLogicExperienceRate"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BoonLogicExperienceRate))]
    public DungeonBoonConfigurator AddBoonLogicExperienceRate(
        int step = default,
        int start = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new BoonLogicExperienceRate();
      component.Step = step;
      component.Start = start;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BoonLogicGold"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BoonLogicGold))]
    public DungeonBoonConfigurator AddBoonLogicGold(
        int step = default,
        int start = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new BoonLogicGold();
      component.Step = step;
      component.Start = start;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BoonLogicItem"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BoonLogicItem))]
    public DungeonBoonConfigurator AddBoonLogicItem(
        bool isRandomItemOfType = default,
        DungeonLootType[]? type = null,
        bool pack = default,
        int step = default,
        int start = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new BoonLogicItem();
      component.IsRandomItemOfType = isRandomItemOfType;
      component.Type = type;
      component.Pack = pack;
      component.Step = step;
      component.Start = start;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BoonLogicPartyBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(BoonLogicPartyBuff))]
    public DungeonBoonConfigurator AddBoonLogicPartyBuff(
        DungeonBoonLogic.ProgressionType progression = default,
        bool mainCharacterOnly = default,
        string? buff = null,
        bool onlyRandomCharacterClass = default,
        int step = default,
        int start = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new BoonLogicPartyBuff();
      component.m_Progression = progression;
      component.m_MainCharacterOnly = mainCharacterOnly;
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.OnlyRandomCharacterClass = onlyRandomCharacterClass;
      component.Step = step;
      component.Start = start;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}

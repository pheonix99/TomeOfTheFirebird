using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Localization;
using Kingmaker.Visual.Sound;
using System;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Visual
{
  /// <summary>
  /// Configurator for <see cref="BlueprintUnitAsksList"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnitAsksList))]
  public class UnitAsksListConfigurator : BaseBlueprintConfigurator<BlueprintUnitAsksList, UnitAsksListConfigurator>
  {
    private UnitAsksListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitAsksListConfigurator For(string name)
    {
      return new UnitAsksListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitAsksListConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintUnitAsksList>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnitAsksList.DisplayName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitAsksListConfigurator SetDisplayName(LocalizedString? displayName)
    {
      ValidateParam(displayName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.DisplayName = displayName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Adds <see cref="UnitAsksComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitAsksComponent))]
    public UnitAsksListConfigurator AddUnitAsksComponent(
        string previewSound,
        UnitAsksComponent.Bark aggro,
        UnitAsksComponent.Bark pain,
        UnitAsksComponent.Bark fatigue,
        UnitAsksComponent.Bark death,
        UnitAsksComponent.Bark unconscious,
        UnitAsksComponent.Bark lowHealth,
        UnitAsksComponent.Bark criticalHit,
        UnitAsksComponent.Bark order,
        UnitAsksComponent.Bark orderMove,
        UnitAsksComponent.Bark selected,
        UnitAsksComponent.Bark refuseEquip,
        UnitAsksComponent.Bark refuseCast,
        UnitAsksComponent.Bark checkSuccess,
        UnitAsksComponent.Bark checkFail,
        UnitAsksComponent.Bark refuseUnequip,
        UnitAsksComponent.Bark discovery,
        UnitAsksComponent.Bark stealth,
        UnitAsksComponent.Bark stormRain,
        UnitAsksComponent.Bark stormSnow,
        UnitEntityData unit,
        UnitAsksComponent.Bark currentlyActiveBark,
        string[]? soundBanks = null,
        UnitAsksComponent.AnimationBark[]? animationBarks = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(aggro);
      ValidateParam(pain);
      ValidateParam(fatigue);
      ValidateParam(death);
      ValidateParam(unconscious);
      ValidateParam(lowHealth);
      ValidateParam(criticalHit);
      ValidateParam(order);
      ValidateParam(orderMove);
      ValidateParam(selected);
      ValidateParam(refuseEquip);
      ValidateParam(refuseCast);
      ValidateParam(checkSuccess);
      ValidateParam(checkFail);
      ValidateParam(refuseUnequip);
      ValidateParam(discovery);
      ValidateParam(stealth);
      ValidateParam(stormRain);
      ValidateParam(stormSnow);
      ValidateParam(animationBarks);
      ValidateParam(unit);
      ValidateParam(currentlyActiveBark);
    
      var component = new UnitAsksComponent();
      component.SoundBanks = soundBanks;
      component.PreviewSound = previewSound;
      component.Aggro = aggro;
      component.Pain = pain;
      component.Fatigue = fatigue;
      component.Death = death;
      component.Unconscious = unconscious;
      component.LowHealth = lowHealth;
      component.CriticalHit = criticalHit;
      component.Order = order;
      component.OrderMove = orderMove;
      component.Selected = selected;
      component.RefuseEquip = refuseEquip;
      component.RefuseCast = refuseCast;
      component.CheckSuccess = checkSuccess;
      component.CheckFail = checkFail;
      component.RefuseUnequip = refuseUnequip;
      component.Discovery = discovery;
      component.Stealth = stealth;
      component.StormRain = stormRain;
      component.StormSnow = stormSnow;
      component.AnimationBarks = animationBarks;
      component.m_Unit = unit;
      component.m_CurrentlyActiveBark = currentlyActiveBark;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}

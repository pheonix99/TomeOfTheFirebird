using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Cutscenes;
using Kingmaker.AreaLogic.Cutscenes.Components;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.NamedParameters;
using System;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AreaLogic.Cutscenes
{
  /// <summary>
  /// Configurator for <see cref="Cutscene"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(Cutscene))]
  public class CutsceneConfigurator : BaseGateConfigurator<Cutscene, CutsceneConfigurator>
  {
    private CutsceneConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CutsceneConfigurator For(string name)
    {
      return new CutsceneConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CutsceneConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<Cutscene>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="Cutscene.Priority"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator SetPriority(CutscenePriority priority)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Priority = priority;
          });
    }

    /// <summary>
    /// Sets <see cref="Cutscene.NonSkippable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator SetNonSkippable(bool nonSkippable)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NonSkippable = nonSkippable;
          });
    }

    /// <summary>
    /// Sets <see cref="Cutscene.ForbidDialogs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator SetForbidDialogs(bool forbidDialogs)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ForbidDialogs = forbidDialogs;
          });
    }

    /// <summary>
    /// Sets <see cref="Cutscene.ForbidRandomIdles"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator SetForbidRandomIdles(bool forbidRandomIdles)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ForbidRandomIdles = forbidRandomIdles;
          });
    }

    /// <summary>
    /// Sets <see cref="Cutscene.IsBackground"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator SetIsBackground(bool isBackground)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsBackground = isBackground;
          });
    }

    /// <summary>
    /// Sets <see cref="Cutscene.Sleepless"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator SetSleepless(bool sleepless)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Sleepless = sleepless;
          });
    }

    /// <summary>
    /// Sets <see cref="Cutscene.AllowCopies"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator SetAllowCopies(bool allowCopies)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AllowCopies = allowCopies;
          });
    }

    /// <summary>
    /// Sets <see cref="Cutscene.AwakeRange"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator SetAwakeRange(float awakeRange)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AwakeRange = awakeRange;
          });
    }

    /// <summary>
    /// Sets <see cref="Cutscene.Anchors"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator SetAnchors(EntityReference[]? anchors)
    {
      ValidateParam(anchors);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Anchors = anchors;
          });
    }

    /// <summary>
    /// Adds to <see cref="Cutscene.Anchors"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator AddToAnchors(params EntityReference[] anchors)
    {
      ValidateParam(anchors);
      return OnConfigureInternal(
          bp =>
          {
            bp.Anchors = CommonTool.Append(bp.Anchors, anchors ?? new EntityReference[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="Cutscene.Anchors"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator RemoveFromAnchors(params EntityReference[] anchors)
    {
      ValidateParam(anchors);
      return OnConfigureInternal(
          bp =>
          {
            bp.Anchors = bp.Anchors.Where(item => !anchors.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="Cutscene.MarkedUnitHandling"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator SetMarkedUnitHandling(Cutscene.MarkedUnitHandlingType markedUnitHandling)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MarkedUnitHandling = markedUnitHandling;
          });
    }

    /// <summary>
    /// Sets <see cref="Cutscene.DefaultParameters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator SetDefaultParameters(ParametrizedContextSetter defaultParameters)
    {
      ValidateParam(defaultParameters);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.DefaultParameters = defaultParameters;
          });
    }

    /// <summary>
    /// Sets <see cref="Cutscene.OnStopped"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutsceneConfigurator SetOnStopped(ActionsBuilder? onStopped)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OnStopped = onStopped?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Adds <see cref="StopCutsceneWhenExitingArea"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(StopCutsceneWhenExitingArea))]
    public CutsceneConfigurator AddStopCutsceneWhenExitingArea(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new StopCutsceneWhenExitingArea();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DestroyCutsceneOnLoad"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DestroyCutsceneOnLoad))]
    public CutsceneConfigurator AddDestroyCutsceneOnLoad(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DestroyCutsceneOnLoad();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}

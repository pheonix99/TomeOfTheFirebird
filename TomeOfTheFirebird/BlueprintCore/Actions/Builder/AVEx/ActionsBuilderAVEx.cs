using BlueprintCore.Utils;
using Kingmaker.Assets.UnitLogic.Mechanics.Actions;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.NamedParameters;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.Sound;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Visual.Animation;
using Kingmaker.Visual.Animation.Actions;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Actions.Builder.AVEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for actions involving audiovisual effects such as dialogs, camera,
  /// cutscenes, and sounds.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderAVEx
  {
    /// <summary>
    /// Adds <see cref="ChangeBookEventImage"/>
    /// </summary>
    [Implements(typeof(ChangeBookEventImage))]
    public static ActionsBuilder ChangeBookImage(this ActionsBuilder builder, SpriteLink image)
    {
      var setImage = ElementTool.Create<ChangeBookEventImage>();
      setImage.m_Image = image;
      return builder.Add(setImage);
    }

    /// <summary>
    /// Adds <see cref="CameraToPosition"/>
    /// </summary>
    [Implements(typeof(CameraToPosition))]
    public static ActionsBuilder MoveCamera(this ActionsBuilder builder, PositionEvaluator position)
    {
      builder.Validate(position);

      var moveCamera = ElementTool.Create<CameraToPosition>();
      moveCamera.Position = position;
      return builder.Add(moveCamera);
    }

    /// <summary>
    /// Adds
    /// <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.AddDialogNotification">AddDialogNotification</see>
    /// </summary>
    [Implements(typeof(AddDialogNotification))]
    public static ActionsBuilder AddDialogNotification(this ActionsBuilder builder, LocalizedString text)
    {
      var notification = ElementTool.Create<AddDialogNotification>();
      notification.Text = text;
      return builder.Add(notification);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.ClearBlood">ClearBlood</see>
    /// </summary>
    [Implements(typeof(ClearBlood))]
    public static ActionsBuilder ClearBlood(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ClearBlood>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionRunAnimationClip"/>
    /// </summary>
    [Implements(typeof(ContextActionRunAnimationClip))]
    public static ActionsBuilder RunAnimationClip(
        this ActionsBuilder builder,
        AnimationClipWrapper clip,
        ExecutionMode mode = ExecutionMode.Interrupted,
        float transitionIn = 0.25f,
        float transitionOut = 0.25f)
    {
      var animation = ElementTool.Create<ContextActionRunAnimationClip>();
      animation.ClipWrapper = clip;
      animation.Mode = mode;
      animation.TransitionIn = transitionIn;
      animation.TransitionOut = transitionOut;
      return builder.Add(animation);
    }

    /// <summary>
    /// Adds <see cref="ContextActionShowBark"/>
    /// </summary>
    [Implements(typeof(ContextActionShowBark))]
    public static ActionsBuilder Bark(
        this ActionsBuilder builder,
        LocalizedString bark,
        bool showIfUnconcious = false,
        bool durationBasedOnTextLength = false)
    {
      var showBark = ElementTool.Create<ContextActionShowBark>();
      showBark.WhatToBark = bark;
      showBark.ShowWhileUnconscious = showIfUnconcious;
      showBark.BarkDurationByText = durationBasedOnTextLength;
      return builder.Add(showBark);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpawnFx"/>
    /// </summary>
    [Implements(typeof(ContextActionSpawnFx))]
    public static ActionsBuilder SpawnFx(this ActionsBuilder builder, PrefabLink prefab)
    {
      var spawnFx = ElementTool.Create<ContextActionSpawnFx>();
      spawnFx.PrefabLink = prefab;
      return builder.Add(spawnFx);
    }

    //----- Kingmaker.Assets.UnitLogic.Mechanics.Actions -----//

    /// <summary>
    /// Adds <see cref="ContextActionPlaySound"/>
    /// </summary>
    [Implements(typeof(ContextActionPlaySound))]
    public static ActionsBuilder PlaySound(this ActionsBuilder builder, string soundName)
    {
      var playSound = ElementTool.Create<ContextActionPlaySound>();
      playSound.SoundName = soundName;
      return builder.Add(playSound);
    }

    //----- Auto Generated -----//

    /// <summary>
    /// Adds <see cref="OverrideRainIntesity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OverrideRainIntesity))]
    public static ActionsBuilder OverrideRainIntesity(
        this ActionsBuilder builder,
        float rainIntensity = default,
        float duration = default)
    {
      var element = ElementTool.Create<OverrideRainIntesity>();
      element.RainIntensity = rainIntensity;
      element.Duration = duration;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Play2DSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Play2DSound))]
    public static ActionsBuilder Play2DSound(
        this ActionsBuilder builder,
        string soundName,
        bool setSex = default,
        bool setRace = default)
    {
      var element = ElementTool.Create<Play2DSound>();
      element.SoundName = soundName;
      element.SetSex = setSex;
      element.SetRace = setRace;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Play3DSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Play3DSound))]
    public static ActionsBuilder Play3DSound(
        this ActionsBuilder builder,
        string soundName,
        EntityReference soundSourceObject,
        bool setSex = default,
        bool setRace = default,
        bool setCurrentSpeaker = default)
    {
      builder.Validate(soundSourceObject);
    
      var element = ElementTool.Create<Play3DSound>();
      element.SoundName = soundName;
      element.SoundSourceObject = soundSourceObject;
      element.SetSex = setSex;
      element.SetRace = setRace;
      element.SetCurrentSpeaker = setCurrentSpeaker;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayAnimationOneShot"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PlayAnimationOneShot))]
    public static ActionsBuilder PlayAnimationOneShot(
        this ActionsBuilder builder,
        AnimationClipWrapper clipWrapper,
        UnitEvaluator unit,
        float transitionIn = default,
        float transitionOut = default)
    {
      builder.Validate(clipWrapper);
      builder.Validate(unit);
    
      var element = ElementTool.Create<PlayAnimationOneShot>();
      element.m_ClipWrapper = clipWrapper;
      element.Unit = unit;
      element.TransitionIn = transitionIn;
      element.TransitionOut = transitionOut;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayCustomMusic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PlayCustomMusic))]
    public static ActionsBuilder PlayCustomMusic(
        this ActionsBuilder builder,
        string musicEventStart,
        string musicEventStop)
    {
      var element = ElementTool.Create<PlayCustomMusic>();
      element.MusicEventStart = musicEventStart;
      element.MusicEventStop = musicEventStop;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayCutscene"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cutscene"><see cref="Kingmaker.AreaLogic.Cutscenes.Cutscene"/></param>
    [Generated]
    [Implements(typeof(PlayCutscene))]
    public static ActionsBuilder PlayCutscene(
        this ActionsBuilder builder,
        ParametrizedContextSetter parameters,
        string? cutscene = null,
        bool putInQueue = default,
        bool checkExistence = default)
    {
      builder.Validate(parameters);
    
      var element = ElementTool.Create<PlayCutscene>();
      element.m_Cutscene = BlueprintTool.GetRef<CutsceneReference>(cutscene);
      element.PutInQueue = putInQueue;
      element.CheckExistence = checkExistence;
      element.Parameters = parameters;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ReloadMechanic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReloadMechanic))]
    public static ActionsBuilder ReloadMechanic(
        this ActionsBuilder builder,
        string desc,
        bool clearFx = default)
    {
      var element = ElementTool.Create<ReloadMechanic>();
      element.Desc = desc;
      element.ClearFx = clearFx;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetSoundState"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetSoundState))]
    public static ActionsBuilder SetSoundState(
        this ActionsBuilder builder,
        AkStateReference state)
    {
      builder.Validate(state);
    
      var element = ElementTool.Create<SetSoundState>();
      element.m_State = state;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ShowBark"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ShowBark))]
    public static ActionsBuilder ShowBark(
        this ActionsBuilder builder,
        SharedStringAsset whatToBarkShared,
        UnitEvaluator targetUnit,
        MapObjectEvaluator targetMapObject,
        LocalizedString? whatToBark = null,
        bool barkDurationByText = default)
    {
      builder.Validate(whatToBark);
      builder.Validate(whatToBarkShared);
      builder.Validate(targetUnit);
      builder.Validate(targetMapObject);
    
      var element = ElementTool.Create<ShowBark>();
      element.WhatToBark = whatToBark ?? Constants.Empty.String;
      element.WhatToBarkShared = whatToBarkShared;
      element.BarkDurationByText = barkDurationByText;
      element.TargetUnit = targetUnit;
      element.TargetMapObject = targetMapObject;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SpawnFx"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpawnFx))]
    public static ActionsBuilder SpawnFx(
        this ActionsBuilder builder,
        TransformEvaluator target,
        GameObject fxPrefab)
    {
      builder.Validate(target);
      builder.Validate(fxPrefab);
    
      var element = ElementTool.Create<SpawnFx>();
      element.Target = target;
      element.FxPrefab = fxPrefab;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="StopCustomMusic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(StopCustomMusic))]
    public static ActionsBuilder StopCustomMusic(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<StopCustomMusic>());
    }

    /// <summary>
    /// Adds <see cref="StopCutscene"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cutscene"><see cref="Kingmaker.AreaLogic.Cutscenes.Cutscene"/></param>
    [Generated]
    [Implements(typeof(StopCutscene))]
    public static ActionsBuilder StopCutscene(
        this ActionsBuilder builder,
        UnitEvaluator withUnit,
        string? cutscene = null,
        StopCutscene.UnitCheckType checkType = default)
    {
      builder.Validate(withUnit);
    
      var element = ElementTool.Create<StopCutscene>();
      element.m_Cutscene = BlueprintTool.GetRef<CutsceneReference>(cutscene);
      element.WithUnit = withUnit;
      element.m_CheckType = checkType;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ToggleObjectFx"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ToggleObjectFx))]
    public static ActionsBuilder ToggleObjectFx(
        this ActionsBuilder builder,
        MapObjectEvaluator target,
        bool toggleOn = default)
    {
      builder.Validate(target);
    
      var element = ElementTool.Create<ToggleObjectFx>();
      element.Target = target;
      element.ToggleOn = toggleOn;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ToggleObjectMusic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ToggleObjectMusic))]
    public static ActionsBuilder ToggleObjectMusic(
        this ActionsBuilder builder,
        MapObjectEvaluator target,
        bool toggleOn = default)
    {
      builder.Validate(target);
    
      var element = ElementTool.Create<ToggleObjectMusic>();
      element.Target = target;
      element.ToggleOn = toggleOn;
      return builder.Add(element);
    }
  }
}

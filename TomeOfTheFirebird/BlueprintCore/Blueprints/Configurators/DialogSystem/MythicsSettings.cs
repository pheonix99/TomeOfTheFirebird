using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Tutorial;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Configurator for <see cref="BlueprintMythicsSettings"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintMythicsSettings))]
  public class MythicsSettingsConfigurator : BaseBlueprintConfigurator<BlueprintMythicsSettings, MythicsSettingsConfigurator>
  {
    private MythicsSettingsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static MythicsSettingsConfigurator For(string name)
    {
      return new MythicsSettingsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static MythicsSettingsConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintMythicsSettings>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintMythicsSettings.m_MythicsInfos"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="mythicsInfos"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintMythicInfo"/></param>
    [Generated]
    public MythicsSettingsConfigurator SetMythicsInfos(string[]? mythicsInfos)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MythicsInfos = mythicsInfos.Select(name => BlueprintTool.GetRef<BlueprintMythicInfoReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintMythicsSettings.m_MythicsInfos"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="mythicsInfos"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintMythicInfo"/></param>
    [Generated]
    public MythicsSettingsConfigurator AddToMythicsInfos(params string[] mythicsInfos)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MythicsInfos = CommonTool.Append(bp.m_MythicsInfos, mythicsInfos.Select(name => BlueprintTool.GetRef<BlueprintMythicInfoReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintMythicsSettings.m_MythicsInfos"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="mythicsInfos"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintMythicInfo"/></param>
    [Generated]
    public MythicsSettingsConfigurator RemoveFromMythicsInfos(params string[] mythicsInfos)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = mythicsInfos.Select(name => BlueprintTool.GetRef<BlueprintMythicInfoReference>(name));
            bp.m_MythicsInfos =
                bp.m_MythicsInfos
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintMythicsSettings.m_MythicAlignments"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MythicsSettingsConfigurator SetMythicAlignments(MythicAlignment[]? mythicAlignments)
    {
      ValidateParam(mythicAlignments);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MythicAlignments = mythicAlignments;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintMythicsSettings.m_MythicAlignments"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MythicsSettingsConfigurator AddToMythicAlignments(params MythicAlignment[] mythicAlignments)
    {
      ValidateParam(mythicAlignments);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MythicAlignments = CommonTool.Append(bp.m_MythicAlignments, mythicAlignments ?? new MythicAlignment[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintMythicsSettings.m_MythicAlignments"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MythicsSettingsConfigurator RemoveFromMythicAlignments(params MythicAlignment[] mythicAlignments)
    {
      ValidateParam(mythicAlignments);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MythicAlignments = bp.m_MythicAlignments.Where(item => !mythicAlignments.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintMythicsSettings.m_TutorialChooseMythic"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="tutorialChooseMythic"><see cref="Kingmaker.Tutorial.BlueprintTutorial"/></param>
    [Generated]
    public MythicsSettingsConfigurator SetTutorialChooseMythic(string? tutorialChooseMythic)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TutorialChooseMythic = BlueprintTool.GetRef<BlueprintTutorial.Reference>(tutorialChooseMythic);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintMythicsSettings.CharcaterLevelRestrictions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MythicsSettingsConfigurator SetCharcaterLevelRestrictions(List<int>? charcaterLevelRestrictions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CharcaterLevelRestrictions = charcaterLevelRestrictions;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintMythicsSettings.CharcaterLevelRestrictions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MythicsSettingsConfigurator AddToCharcaterLevelRestrictions(params int[] charcaterLevelRestrictions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CharcaterLevelRestrictions.AddRange(charcaterLevelRestrictions.ToList() ?? new List<int>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintMythicsSettings.CharcaterLevelRestrictions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MythicsSettingsConfigurator RemoveFromCharcaterLevelRestrictions(params int[] charcaterLevelRestrictions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CharcaterLevelRestrictions = bp.CharcaterLevelRestrictions.Where(item => !charcaterLevelRestrictions.Contains(item)).ToList();
          });
    }
  }
}

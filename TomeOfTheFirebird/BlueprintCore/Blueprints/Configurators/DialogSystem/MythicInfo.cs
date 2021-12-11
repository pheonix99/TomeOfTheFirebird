using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Localization;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Configurator for <see cref="BlueprintMythicInfo"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintMythicInfo))]
  public class MythicInfoConfigurator : BaseBlueprintConfigurator<BlueprintMythicInfo, MythicInfoConfigurator>
  {
    private MythicInfoConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static MythicInfoConfigurator For(string name)
    {
      return new MythicInfoConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static MythicInfoConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintMythicInfo>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintMythicInfo._mythic"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MythicInfoConfigurator Set_mythic(Mythic _mythic)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp._mythic = _mythic;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintMythicInfo._etudeReference"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="_etudeReference"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public MythicInfoConfigurator Set_etudeReference(string? _etudeReference)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp._etudeReference = BlueprintTool.GetRef<BlueprintEtudeReference>(_etudeReference);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintMythicInfo._mythicName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MythicInfoConfigurator Set_mythicName(LocalizedString? _mythicName)
    {
      ValidateParam(_mythicName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp._mythicName = _mythicName ?? Constants.Empty.String;
          });
    }
  }
}

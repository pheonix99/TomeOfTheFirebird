using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DLC;
using Kingmaker.Localization;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.DLC
{
  /// <summary>
  /// Configurator for <see cref="BlueprintDlc"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintDlc))]
  public class DlcConfigurator : BaseBlueprintConfigurator<BlueprintDlc, DlcConfigurator>
  {
    private DlcConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DlcConfigurator For(string name)
    {
      return new DlcConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DlcConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintDlc>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlc.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcConfigurator SetDescription(LocalizedString? description)
    {
      ValidateParam(description);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Description = description ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlc.RewardReferences"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="rewardReferences"><see cref="Kingmaker.DLC.BlueprintDlcReward"/></param>
    [Generated]
    public DlcConfigurator SetRewardReferences(string[]? rewardReferences)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RewardReferences = rewardReferences.Select(name => BlueprintTool.GetRef<BlueprintDlcRewardReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDlc.RewardReferences"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="rewardReferences"><see cref="Kingmaker.DLC.BlueprintDlcReward"/></param>
    [Generated]
    public DlcConfigurator AddToRewardReferences(params string[] rewardReferences)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RewardReferences = CommonTool.Append(bp.RewardReferences, rewardReferences.Select(name => BlueprintTool.GetRef<BlueprintDlcRewardReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDlc.RewardReferences"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="rewardReferences"><see cref="Kingmaker.DLC.BlueprintDlcReward"/></param>
    [Generated]
    public DlcConfigurator RemoveFromRewardReferences(params string[] rewardReferences)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = rewardReferences.Select(name => BlueprintTool.GetRef<BlueprintDlcRewardReference>(name));
            bp.RewardReferences =
                bp.RewardReferences
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}

using BlueprintCore.Utils;
using Kingmaker.AreaLogic;
using Kingmaker.Blueprints;
using Kingmaker.QA.Arbiter;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.QA
{
  /// <summary>
  /// Configurator for <see cref="BlueprintArbiterInstruction"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArbiterInstruction))]
  public class ArbiterInstructionConfigurator : BaseBlueprintConfigurator<BlueprintArbiterInstruction, ArbiterInstructionConfigurator>
  {
    private ArbiterInstructionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArbiterInstructionConfigurator For(string name)
    {
      return new ArbiterInstructionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArbiterInstructionConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintArbiterInstruction>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="ArbiterAreaTest"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="area"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    /// <param name="overrideAreaPreset"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPreset"/></param>
    [Generated]
    [Implements(typeof(ArbiterAreaTest))]
    public ArbiterInstructionConfigurator AddArbiterAreaTest(
        ArbiterElementList areaParts,
        string? area = null,
        string? overrideAreaPreset = null,
        bool overrideTimeOfDay = default,
        TimeOfDay timeOfDay = default,
        bool makeMapScreenshot = default)
    {
      ValidateParam(areaParts);
    
      var component = new ArbiterAreaTest();
      component.Area = BlueprintTool.GetRef<BlueprintAreaReference>(area);
      component.OverrideAreaPreset = BlueprintTool.GetRef<BlueprintAreaPresetReference>(overrideAreaPreset);
      component.OverrideTimeOfDay = overrideTimeOfDay;
      component.TimeOfDay = timeOfDay;
      component.MakeMapScreenshot = makeMapScreenshot;
      component.AreaParts = areaParts;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArbiterWeaponTest"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weapon"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(ArbiterWeaponTest))]
    public ArbiterInstructionConfigurator AddArbiterWeaponTest(
        string? weapon = null)
    {
      var component = new ArbiterWeaponTest();
      component.Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weapon);
      return AddComponent(component);
    }
  }
}

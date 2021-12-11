using BlueprintCore.Utils;
using Kingmaker.Blueprints.Root.Fx;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Root.Fx
{
  /// <summary>
  /// Configurator for <see cref="CastsGroup"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(CastsGroup))]
  public class CastsGroupConfigurator : BaseBlueprintConfigurator<CastsGroup, CastsGroupConfigurator>
  {
    private CastsGroupConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CastsGroupConfigurator For(string name)
    {
      return new CastsGroupConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CastsGroupConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<CastsGroup>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="CastsGroup.m_ArcaneCasts"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CastsGroupConfigurator SetArcaneCasts(CastGroupForSpellSource arcaneCasts)
    {
      ValidateParam(arcaneCasts);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ArcaneCasts = arcaneCasts;
          });
    }

    /// <summary>
    /// Sets <see cref="CastsGroup.m_DivineCasts"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CastsGroupConfigurator SetDivineCasts(CastGroupForSpellSource divineCasts)
    {
      ValidateParam(divineCasts);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DivineCasts = divineCasts;
          });
    }
  }
}

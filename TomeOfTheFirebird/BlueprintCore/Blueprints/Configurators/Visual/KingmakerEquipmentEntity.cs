using BlueprintCore.Utils;
using Kingmaker.ResourceLinks;
using Kingmaker.Visual.CharacterSystem;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Visual
{
  /// <summary>
  /// Configurator for <see cref="KingmakerEquipmentEntity"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(KingmakerEquipmentEntity))]
  public class KingmakerEquipmentEntityConfigurator : BaseBlueprintConfigurator<KingmakerEquipmentEntity, KingmakerEquipmentEntityConfigurator>
  {
    private KingmakerEquipmentEntityConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingmakerEquipmentEntityConfigurator For(string name)
    {
      return new KingmakerEquipmentEntityConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingmakerEquipmentEntityConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<KingmakerEquipmentEntity>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="KingmakerEquipmentEntity.m_MaleArray"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingmakerEquipmentEntityConfigurator SetMaleArray(EquipmentEntityLink[]? maleArray)
    {
      ValidateParam(maleArray);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MaleArray = maleArray;
          });
    }

    /// <summary>
    /// Adds to <see cref="KingmakerEquipmentEntity.m_MaleArray"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingmakerEquipmentEntityConfigurator AddToMaleArray(params EquipmentEntityLink[] maleArray)
    {
      ValidateParam(maleArray);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MaleArray = CommonTool.Append(bp.m_MaleArray, maleArray ?? new EquipmentEntityLink[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="KingmakerEquipmentEntity.m_MaleArray"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingmakerEquipmentEntityConfigurator RemoveFromMaleArray(params EquipmentEntityLink[] maleArray)
    {
      ValidateParam(maleArray);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MaleArray = bp.m_MaleArray.Where(item => !maleArray.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="KingmakerEquipmentEntity.m_FemaleArray"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingmakerEquipmentEntityConfigurator SetFemaleArray(EquipmentEntityLink[]? femaleArray)
    {
      ValidateParam(femaleArray);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_FemaleArray = femaleArray;
          });
    }

    /// <summary>
    /// Adds to <see cref="KingmakerEquipmentEntity.m_FemaleArray"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingmakerEquipmentEntityConfigurator AddToFemaleArray(params EquipmentEntityLink[] femaleArray)
    {
      ValidateParam(femaleArray);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_FemaleArray = CommonTool.Append(bp.m_FemaleArray, femaleArray ?? new EquipmentEntityLink[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="KingmakerEquipmentEntity.m_FemaleArray"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingmakerEquipmentEntityConfigurator RemoveFromFemaleArray(params EquipmentEntityLink[] femaleArray)
    {
      ValidateParam(femaleArray);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_FemaleArray = bp.m_FemaleArray.Where(item => !femaleArray.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="KingmakerEquipmentEntity.m_RaceDependent"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingmakerEquipmentEntityConfigurator SetRaceDependent(bool raceDependent)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_RaceDependent = raceDependent;
          });
    }

    /// <summary>
    /// Sets <see cref="KingmakerEquipmentEntity.m_RaceDependentArrays"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingmakerEquipmentEntityConfigurator SetRaceDependentArrays(KingmakerEquipmentEntity.TwoLists[]? raceDependentArrays)
    {
      ValidateParam(raceDependentArrays);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_RaceDependentArrays = raceDependentArrays;
          });
    }

    /// <summary>
    /// Adds to <see cref="KingmakerEquipmentEntity.m_RaceDependentArrays"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingmakerEquipmentEntityConfigurator AddToRaceDependentArrays(params KingmakerEquipmentEntity.TwoLists[] raceDependentArrays)
    {
      ValidateParam(raceDependentArrays);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_RaceDependentArrays = CommonTool.Append(bp.m_RaceDependentArrays, raceDependentArrays ?? new KingmakerEquipmentEntity.TwoLists[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="KingmakerEquipmentEntity.m_RaceDependentArrays"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingmakerEquipmentEntityConfigurator RemoveFromRaceDependentArrays(params KingmakerEquipmentEntity.TwoLists[] raceDependentArrays)
    {
      ValidateParam(raceDependentArrays);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_RaceDependentArrays = bp.m_RaceDependentArrays.Where(item => !raceDependentArrays.Contains(item)).ToArray();
          });
    }
  }
}

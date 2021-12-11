using BlueprintCore.Utils;
using Kingmaker.Visual.HitSystem;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Visual
{
  /// <summary>
  /// Configurator for <see cref="HitSystemRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(HitSystemRoot))]
  public class HitSystemRootConfigurator : BaseBlueprintConfigurator<HitSystemRoot, HitSystemRootConfigurator>
  {
    private HitSystemRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static HitSystemRootConfigurator For(string name)
    {
      return new HitSystemRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static HitSystemRootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<HitSystemRoot>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.DamageTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetDamageTypes(DamageEntry[]? damageTypes)
    {
      ValidateParam(damageTypes);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.DamageTypes = damageTypes;
          });
    }

    /// <summary>
    /// Adds to <see cref="HitSystemRoot.DamageTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator AddToDamageTypes(params DamageEntry[] damageTypes)
    {
      ValidateParam(damageTypes);
      return OnConfigureInternal(
          bp =>
          {
            bp.DamageTypes = CommonTool.Append(bp.DamageTypes, damageTypes ?? new DamageEntry[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="HitSystemRoot.DamageTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator RemoveFromDamageTypes(params DamageEntry[] damageTypes)
    {
      ValidateParam(damageTypes);
      return OnConfigureInternal(
          bp =>
          {
            bp.DamageTypes = bp.DamageTypes.Where(item => !damageTypes.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.EnergyTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetEnergyTypes(EnergyEntry[]? energyTypes)
    {
      ValidateParam(energyTypes);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.EnergyTypes = energyTypes;
          });
    }

    /// <summary>
    /// Adds to <see cref="HitSystemRoot.EnergyTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator AddToEnergyTypes(params EnergyEntry[] energyTypes)
    {
      ValidateParam(energyTypes);
      return OnConfigureInternal(
          bp =>
          {
            bp.EnergyTypes = CommonTool.Append(bp.EnergyTypes, energyTypes ?? new EnergyEntry[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="HitSystemRoot.EnergyTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator RemoveFromEnergyTypes(params EnergyEntry[] energyTypes)
    {
      ValidateParam(energyTypes);
      return OnConfigureInternal(
          bp =>
          {
            bp.EnergyTypes = bp.EnergyTypes.Where(item => !energyTypes.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.BloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetBloodTypes(BloodEntry[]? bloodTypes)
    {
      ValidateParam(bloodTypes);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.BloodTypes = bloodTypes;
          });
    }

    /// <summary>
    /// Adds to <see cref="HitSystemRoot.BloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator AddToBloodTypes(params BloodEntry[] bloodTypes)
    {
      ValidateParam(bloodTypes);
      return OnConfigureInternal(
          bp =>
          {
            bp.BloodTypes = CommonTool.Append(bp.BloodTypes, bloodTypes ?? new BloodEntry[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="HitSystemRoot.BloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator RemoveFromBloodTypes(params BloodEntry[] bloodTypes)
    {
      ValidateParam(bloodTypes);
      return OnConfigureInternal(
          bp =>
          {
            bp.BloodTypes = bp.BloodTypes.Where(item => !bloodTypes.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.DefaultDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetDefaultDamage(DamageHitSettings defaultDamage)
    {
      ValidateParam(defaultDamage);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.DefaultDamage = defaultDamage;
          });
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.DefaultAoeDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetDefaultAoeDamage(DamageHitSettings defaultAoeDamage)
    {
      ValidateParam(defaultAoeDamage);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.DefaultAoeDamage = defaultAoeDamage;
          });
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.OverrideHitDirectionPrefabFromAnimationStyle"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetOverrideHitDirectionPrefabFromAnimationStyle(BloodPrefabsFromWeaponAnimationStyleEntry[]? overrideHitDirectionPrefabFromAnimationStyle)
    {
      ValidateParam(overrideHitDirectionPrefabFromAnimationStyle);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.OverrideHitDirectionPrefabFromAnimationStyle = overrideHitDirectionPrefabFromAnimationStyle;
          });
    }

    /// <summary>
    /// Adds to <see cref="HitSystemRoot.OverrideHitDirectionPrefabFromAnimationStyle"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator AddToOverrideHitDirectionPrefabFromAnimationStyle(params BloodPrefabsFromWeaponAnimationStyleEntry[] overrideHitDirectionPrefabFromAnimationStyle)
    {
      ValidateParam(overrideHitDirectionPrefabFromAnimationStyle);
      return OnConfigureInternal(
          bp =>
          {
            bp.OverrideHitDirectionPrefabFromAnimationStyle = CommonTool.Append(bp.OverrideHitDirectionPrefabFromAnimationStyle, overrideHitDirectionPrefabFromAnimationStyle ?? new BloodPrefabsFromWeaponAnimationStyleEntry[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="HitSystemRoot.OverrideHitDirectionPrefabFromAnimationStyle"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator RemoveFromOverrideHitDirectionPrefabFromAnimationStyle(params BloodPrefabsFromWeaponAnimationStyleEntry[] overrideHitDirectionPrefabFromAnimationStyle)
    {
      ValidateParam(overrideHitDirectionPrefabFromAnimationStyle);
      return OnConfigureInternal(
          bp =>
          {
            bp.OverrideHitDirectionPrefabFromAnimationStyle = bp.OverrideHitDirectionPrefabFromAnimationStyle.Where(item => !overrideHitDirectionPrefabFromAnimationStyle.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.MaxHeightIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetMaxHeightIncrease(float maxHeightIncrease)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MaxHeightIncrease = maxHeightIncrease;
          });
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.EnergyResistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetEnergyResistance(GameObject energyResistance)
    {
      ValidateParam(energyResistance);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.EnergyResistance = energyResistance;
          });
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.RagdollDistanceForLootBag"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetRagdollDistanceForLootBag(float ragdollDistanceForLootBag)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RagdollDistanceForLootBag = ragdollDistanceForLootBag;
          });
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.BlowUpDismembermentChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetBlowUpDismembermentChance(float blowUpDismembermentChance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BlowUpDismembermentChance = blowUpDismembermentChance;
          });
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.LimbsApartDismembermentChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetLimbsApartDismembermentChance(float limbsApartDismembermentChance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.LimbsApartDismembermentChance = limbsApartDismembermentChance;
          });
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.m_Initialized"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetInitialized(bool initialized)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Initialized = initialized;
          });
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.m_CachedDamageTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetCachedDamageTypes(HitCollection[]? cachedDamageTypes)
    {
      ValidateParam(cachedDamageTypes);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedDamageTypes = cachedDamageTypes;
          });
    }

    /// <summary>
    /// Adds to <see cref="HitSystemRoot.m_CachedDamageTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator AddToCachedDamageTypes(params HitCollection[] cachedDamageTypes)
    {
      ValidateParam(cachedDamageTypes);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedDamageTypes = CommonTool.Append(bp.m_CachedDamageTypes, cachedDamageTypes ?? new HitCollection[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="HitSystemRoot.m_CachedDamageTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator RemoveFromCachedDamageTypes(params HitCollection[] cachedDamageTypes)
    {
      ValidateParam(cachedDamageTypes);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedDamageTypes = bp.m_CachedDamageTypes.Where(item => !cachedDamageTypes.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.m_CachedEnergyTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetCachedEnergyTypes(HitCollection[]? cachedEnergyTypes)
    {
      ValidateParam(cachedEnergyTypes);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedEnergyTypes = cachedEnergyTypes;
          });
    }

    /// <summary>
    /// Adds to <see cref="HitSystemRoot.m_CachedEnergyTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator AddToCachedEnergyTypes(params HitCollection[] cachedEnergyTypes)
    {
      ValidateParam(cachedEnergyTypes);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedEnergyTypes = CommonTool.Append(bp.m_CachedEnergyTypes, cachedEnergyTypes ?? new HitCollection[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="HitSystemRoot.m_CachedEnergyTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator RemoveFromCachedEnergyTypes(params HitCollection[] cachedEnergyTypes)
    {
      ValidateParam(cachedEnergyTypes);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedEnergyTypes = bp.m_CachedEnergyTypes.Where(item => !cachedEnergyTypes.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.m_CachedBillboardBloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetCachedBillboardBloodTypes(HitCollection[]? cachedBillboardBloodTypes)
    {
      ValidateParam(cachedBillboardBloodTypes);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedBillboardBloodTypes = cachedBillboardBloodTypes;
          });
    }

    /// <summary>
    /// Adds to <see cref="HitSystemRoot.m_CachedBillboardBloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator AddToCachedBillboardBloodTypes(params HitCollection[] cachedBillboardBloodTypes)
    {
      ValidateParam(cachedBillboardBloodTypes);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedBillboardBloodTypes = CommonTool.Append(bp.m_CachedBillboardBloodTypes, cachedBillboardBloodTypes ?? new HitCollection[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="HitSystemRoot.m_CachedBillboardBloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator RemoveFromCachedBillboardBloodTypes(params HitCollection[] cachedBillboardBloodTypes)
    {
      ValidateParam(cachedBillboardBloodTypes);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedBillboardBloodTypes = bp.m_CachedBillboardBloodTypes.Where(item => !cachedBillboardBloodTypes.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.m_CachedDirectionalBloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetCachedDirectionalBloodTypes(HitCollection[]? cachedDirectionalBloodTypes)
    {
      ValidateParam(cachedDirectionalBloodTypes);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedDirectionalBloodTypes = cachedDirectionalBloodTypes;
          });
    }

    /// <summary>
    /// Adds to <see cref="HitSystemRoot.m_CachedDirectionalBloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator AddToCachedDirectionalBloodTypes(params HitCollection[] cachedDirectionalBloodTypes)
    {
      ValidateParam(cachedDirectionalBloodTypes);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedDirectionalBloodTypes = CommonTool.Append(bp.m_CachedDirectionalBloodTypes, cachedDirectionalBloodTypes ?? new HitCollection[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="HitSystemRoot.m_CachedDirectionalBloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator RemoveFromCachedDirectionalBloodTypes(params HitCollection[] cachedDirectionalBloodTypes)
    {
      ValidateParam(cachedDirectionalBloodTypes);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedDirectionalBloodTypes = bp.m_CachedDirectionalBloodTypes.Where(item => !cachedDirectionalBloodTypes.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.m_CachedBillboardAdditiveBloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetCachedBillboardAdditiveBloodTypes(HitCollection[]? cachedBillboardAdditiveBloodTypes)
    {
      ValidateParam(cachedBillboardAdditiveBloodTypes);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedBillboardAdditiveBloodTypes = cachedBillboardAdditiveBloodTypes;
          });
    }

    /// <summary>
    /// Adds to <see cref="HitSystemRoot.m_CachedBillboardAdditiveBloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator AddToCachedBillboardAdditiveBloodTypes(params HitCollection[] cachedBillboardAdditiveBloodTypes)
    {
      ValidateParam(cachedBillboardAdditiveBloodTypes);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedBillboardAdditiveBloodTypes = CommonTool.Append(bp.m_CachedBillboardAdditiveBloodTypes, cachedBillboardAdditiveBloodTypes ?? new HitCollection[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="HitSystemRoot.m_CachedBillboardAdditiveBloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator RemoveFromCachedBillboardAdditiveBloodTypes(params HitCollection[] cachedBillboardAdditiveBloodTypes)
    {
      ValidateParam(cachedBillboardAdditiveBloodTypes);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedBillboardAdditiveBloodTypes = bp.m_CachedBillboardAdditiveBloodTypes.Where(item => !cachedBillboardAdditiveBloodTypes.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.m_CachedDirectionalAdditiveBloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetCachedDirectionalAdditiveBloodTypes(HitCollection[]? cachedDirectionalAdditiveBloodTypes)
    {
      ValidateParam(cachedDirectionalAdditiveBloodTypes);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedDirectionalAdditiveBloodTypes = cachedDirectionalAdditiveBloodTypes;
          });
    }

    /// <summary>
    /// Adds to <see cref="HitSystemRoot.m_CachedDirectionalAdditiveBloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator AddToCachedDirectionalAdditiveBloodTypes(params HitCollection[] cachedDirectionalAdditiveBloodTypes)
    {
      ValidateParam(cachedDirectionalAdditiveBloodTypes);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedDirectionalAdditiveBloodTypes = CommonTool.Append(bp.m_CachedDirectionalAdditiveBloodTypes, cachedDirectionalAdditiveBloodTypes ?? new HitCollection[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="HitSystemRoot.m_CachedDirectionalAdditiveBloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator RemoveFromCachedDirectionalAdditiveBloodTypes(params HitCollection[] cachedDirectionalAdditiveBloodTypes)
    {
      ValidateParam(cachedDirectionalAdditiveBloodTypes);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedDirectionalAdditiveBloodTypes = bp.m_CachedDirectionalAdditiveBloodTypes.Where(item => !cachedDirectionalAdditiveBloodTypes.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetCachedBloodPrefabsFromWeaponAnimationStyleEntries(BloodPrefabsFromWeaponAnimationStyleEntry[]? cachedBloodPrefabsFromWeaponAnimationStyleEntries)
    {
      ValidateParam(cachedBloodPrefabsFromWeaponAnimationStyleEntries);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries = cachedBloodPrefabsFromWeaponAnimationStyleEntries;
          });
    }

    /// <summary>
    /// Adds to <see cref="HitSystemRoot.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator AddToCachedBloodPrefabsFromWeaponAnimationStyleEntries(params BloodPrefabsFromWeaponAnimationStyleEntry[] cachedBloodPrefabsFromWeaponAnimationStyleEntries)
    {
      ValidateParam(cachedBloodPrefabsFromWeaponAnimationStyleEntries);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries = CommonTool.Append(bp.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries, cachedBloodPrefabsFromWeaponAnimationStyleEntries ?? new BloodPrefabsFromWeaponAnimationStyleEntry[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="HitSystemRoot.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator RemoveFromCachedBloodPrefabsFromWeaponAnimationStyleEntries(params BloodPrefabsFromWeaponAnimationStyleEntry[] cachedBloodPrefabsFromWeaponAnimationStyleEntries)
    {
      ValidateParam(cachedBloodPrefabsFromWeaponAnimationStyleEntries);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries = bp.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries.Where(item => !cachedBloodPrefabsFromWeaponAnimationStyleEntries.Contains(item)).ToArray();
          });
    }
  }
}

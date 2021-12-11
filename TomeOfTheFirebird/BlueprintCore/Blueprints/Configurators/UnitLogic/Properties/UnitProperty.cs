using BlueprintCore.Utils;
using Kingmaker.Assets.UnitLogic.Mechanics.Properties;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Class.Kineticist.Properties;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.Utility;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.UnitLogic.Properties
{
  /// <summary>
  /// Configurator for <see cref="BlueprintUnitProperty"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnitProperty))]
  public class UnitPropertyConfigurator : BaseBlueprintConfigurator<BlueprintUnitProperty, UnitPropertyConfigurator>
  {
    private UnitPropertyConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitPropertyConfigurator For(string name)
    {
      return new UnitPropertyConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitPropertyConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintUnitProperty>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnitProperty.BaseValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitPropertyConfigurator SetBaseValue(int baseValue)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BaseValue = baseValue;
          });
    }

    /// <summary>
    /// Adds <see cref="CountCorpsesAroundPropertyGetter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="onlyOfType"><see cref="Kingmaker.Blueprints.BlueprintUnitType"/></param>
    [Generated]
    [Implements(typeof(CountCorpsesAroundPropertyGetter))]
    public UnitPropertyConfigurator AddCountCorpsesAroundPropertyGetter(
        Feet radius,
        PropertySettings settings,
        string? onlyOfType = null)
    {
      ValidateParam(settings);
    
      var component = new CountCorpsesAroundPropertyGetter();
      component.m_OnlyOfType = BlueprintTool.GetRef<BlueprintUnitTypeReference>(onlyOfType);
      component.m_Radius = radius;
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BaseAttackPropertyWithFeatureList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="features"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(BaseAttackPropertyWithFeatureList))]
    public UnitPropertyConfigurator AddBaseAttackPropertyWithFeatureList(
        PropertySettings settings,
        int baseValue = default,
        int baseAttackDiv = default,
        int baseAttackZero = default,
        string[]? features = null,
        int featureBonus = default)
    {
      ValidateParam(settings);
    
      var component = new BaseAttackPropertyWithFeatureList();
      component.BaseValue = baseValue;
      component.BaseAttackDiv = baseAttackDiv;
      component.BaseAttackZero = baseAttackZero;
      component.m_Features = features.Select(name => BlueprintTool.GetRef<BlueprintFeatureReference>(name)).ToArray();
      component.FeatureBonus = featureBonus;
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CurrentMeleeWeaponDamageStatGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CurrentMeleeWeaponDamageStatGetter))]
    public UnitPropertyConfigurator AddCurrentMeleeWeaponDamageStatGetter(
        PropertySettings settings)
    {
      ValidateParam(settings);
    
      var component = new CurrentMeleeWeaponDamageStatGetter();
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CurrentWeaponCriticalMultiplierGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CurrentWeaponCriticalMultiplierGetter))]
    public UnitPropertyConfigurator AddCurrentWeaponCriticalMultiplierGetter(
        PropertySettings settings)
    {
      ValidateParam(settings);
    
      var component = new CurrentWeaponCriticalMultiplierGetter();
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FightingDefensivelyACBonusProperty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="features"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    /// <param name="duelingFeatures"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(FightingDefensivelyACBonusProperty))]
    public UnitPropertyConfigurator AddFightingDefensivelyACBonusProperty(
        PropertySettings settings,
        string[]? features = null,
        string[]? duelingFeatures = null)
    {
      ValidateParam(settings);
    
      var component = new FightingDefensivelyACBonusProperty();
      component.m_Features = features.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_DuelingFeatures = duelingFeatures.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FightingDefensivelyAttackPenaltyProperty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="features"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    /// <param name="duelingFeatures"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    /// <param name="halfBuff"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(FightingDefensivelyAttackPenaltyProperty))]
    public UnitPropertyConfigurator AddFightingDefensivelyAttackPenaltyProperty(
        PropertySettings settings,
        string[]? features = null,
        string[]? duelingFeatures = null,
        string? halfBuff = null)
    {
      ValidateParam(settings);
    
      var component = new FightingDefensivelyAttackPenaltyProperty();
      component.m_Features = features.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_DuelingFeatures = duelingFeatures.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_HalfBuff = BlueprintTool.GetRef<BlueprintUnitFactReference>(halfBuff);
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KineticistBurnPropertyGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KineticistBurnPropertyGetter))]
    public UnitPropertyConfigurator AddKineticistBurnPropertyGetter(
        PropertySettings settings,
        bool multiplyOnClassLevel = default,
        bool multyplyOnCharacterLevel = default)
    {
      ValidateParam(settings);
    
      var component = new KineticistBurnPropertyGetter();
      component.MultiplyOnClassLevel = multiplyOnClassLevel;
      component.MultyplyOnCharacterLevel = multyplyOnCharacterLevel;
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KineticistMainStatBonusPropertyGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KineticistMainStatBonusPropertyGetter))]
    public UnitPropertyConfigurator AddKineticistMainStatBonusPropertyGetter(
        PropertySettings settings)
    {
      ValidateParam(settings);
    
      var component = new KineticistMainStatBonusPropertyGetter();
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LevelBasedPropertyWithFeatureList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="features"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(LevelBasedPropertyWithFeatureList))]
    public UnitPropertyConfigurator AddLevelBasedPropertyWithFeatureList(
        PropertySettings settings,
        int baseValue = default,
        int levelDiv = default,
        int levelZero = default,
        string[]? features = null,
        int featureBonus = default)
    {
      ValidateParam(settings);
    
      var component = new LevelBasedPropertyWithFeatureList();
      component.BaseValue = baseValue;
      component.LevelDiv = levelDiv;
      component.LevelZero = levelZero;
      component.m_Features = features.Select(name => BlueprintTool.GetRef<BlueprintFeatureReference>(name)).ToArray();
      component.FeatureBonus = featureBonus;
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="StatBonusIfHasFactProperty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="requiredFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(StatBonusIfHasFactProperty))]
    public UnitPropertyConfigurator AddStatBonusIfHasFactProperty(
        PropertySettings settings,
        int multiplier = default,
        StatType stat = default,
        string? requiredFact = null)
    {
      ValidateParam(settings);
    
      var component = new StatBonusIfHasFactProperty();
      component.Multiplier = multiplier;
      component.Stat = stat;
      component.m_RequiredFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(requiredFact);
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AnimalPetOwnerRankGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AnimalPetOwnerRankGetter))]
    public UnitPropertyConfigurator AddAnimalPetOwnerRankGetter(
        PropertySettings settings,
        UnitProperty property = default)
    {
      ValidateParam(settings);
    
      var component = new AnimalPetOwnerRankGetter();
      component.Property = property;
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AreaCrComplexGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AreaCrComplexGetter))]
    public UnitPropertyConfigurator AddAreaCrComplexGetter(
        PropertySettings settings,
        int bonus = default,
        int multiplier = default,
        int denominator = default)
    {
      ValidateParam(settings);
    
      var component = new AreaCrComplexGetter();
      component.Bonus = bonus;
      component.Multiplier = multiplier;
      component.Denominator = denominator;
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ClassLevelGetter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="clazz"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ClassLevelGetter))]
    public UnitPropertyConfigurator AddClassLevelGetter(
        PropertySettings settings,
        string? clazz = null)
    {
      ValidateParam(settings);
    
      var component = new ClassLevelGetter();
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CustomPropertyGetter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="property"><see cref="Kingmaker.UnitLogic.Mechanics.Properties.BlueprintUnitProperty"/></param>
    [Generated]
    [Implements(typeof(CustomPropertyGetter))]
    public UnitPropertyConfigurator AddCustomPropertyGetter(
        PropertySettings settings,
        string? property = null)
    {
      ValidateParam(settings);
    
      var component = new CustomPropertyGetter();
      component.m_Property = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(property);
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FactRankGetter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="fact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(FactRankGetter))]
    public UnitPropertyConfigurator AddFactRankGetter(
        PropertySettings settings,
        string? fact = null)
    {
      ValidateParam(settings);
    
      var component = new FactRankGetter();
      component.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(fact);
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShieldBonusGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ShieldBonusGetter))]
    public UnitPropertyConfigurator AddShieldBonusGetter(
        PropertySettings settings)
    {
      ValidateParam(settings);
    
      var component = new ShieldBonusGetter();
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SimplePropertyGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SimplePropertyGetter))]
    public UnitPropertyConfigurator AddSimplePropertyGetter(
        PropertySettings settings,
        UnitProperty property = default)
    {
      ValidateParam(settings);
    
      var component = new SimplePropertyGetter();
      component.Property = property;
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SkillRankGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SkillRankGetter))]
    public UnitPropertyConfigurator AddSkillRankGetter(
        PropertySettings settings,
        StatType skill = default)
    {
      ValidateParam(settings);
    
      var component = new SkillRankGetter();
      component.Skill = skill;
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SkillValueGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SkillValueGetter))]
    public UnitPropertyConfigurator AddSkillValueGetter(
        PropertySettings settings,
        StatType skill = default)
    {
      ValidateParam(settings);
    
      var component = new SkillValueGetter();
      component.Skill = skill;
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SummClassLevelGetter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="clazz"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="archetype"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype"/></param>
    /// <param name="archetypes"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(SummClassLevelGetter))]
    public UnitPropertyConfigurator AddSummClassLevelGetter(
        PropertySettings settings,
        string[]? clazz = null,
        string? archetype = null,
        string[]? archetypes = null)
    {
      ValidateParam(settings);
    
      var component = new SummClassLevelGetter();
      component.m_Class = clazz.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray();
      component.Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      component.m_Archetypes = archetypes.Select(name => BlueprintTool.GetRef<BlueprintArchetypeReference>(name)).ToArray();
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnitWeaponEnhancementGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitWeaponEnhancementGetter))]
    public UnitPropertyConfigurator AddUnitWeaponEnhancementGetter(
        PropertySettings settings)
    {
      ValidateParam(settings);
    
      var component = new UnitWeaponEnhancementGetter();
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CastingAttributeGetter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="clazz"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(CastingAttributeGetter))]
    public UnitPropertyConfigurator AddCastingAttributeGetter(
        PropertySettings settings,
        string? clazz = null,
        bool attributeBonus = default)
    {
      ValidateParam(settings);
    
      var component = new CastingAttributeGetter();
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      component.AttributeBonus = attributeBonus;
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ComplexPropertyGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ComplexPropertyGetter))]
    public UnitPropertyConfigurator AddComplexPropertyGetter(
        PropertySettings settings,
        int bonus = default,
        int multiplier = default,
        int denominator = default,
        UnitProperty property = default)
    {
      ValidateParam(settings);
    
      var component = new ComplexPropertyGetter();
      component.Bonus = bonus;
      component.Multiplier = multiplier;
      component.Denominator = denominator;
      component.Property = property;
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CustomProgressionPropertyGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CustomProgressionPropertyGetter))]
    public UnitPropertyConfigurator AddCustomProgressionPropertyGetter(
        PropertySettings settings,
        int start = default,
        int step = default,
        UnitProperty property = default)
    {
      ValidateParam(settings);
    
      var component = new CustomProgressionPropertyGetter();
      component.Start = start;
      component.Step = step;
      component.Property = property;
      component.Settings = settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MaxCastingAttributeGetter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="classes"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(MaxCastingAttributeGetter))]
    public UnitPropertyConfigurator AddMaxCastingAttributeGetter(
        PropertySettings settings,
        string[]? classes = null,
        bool attributeBonus = default,
        StatType defaultStat = default)
    {
      ValidateParam(settings);
    
      var component = new MaxCastingAttributeGetter();
      component.m_Classes = classes.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray();
      component.AttributeBonus = attributeBonus;
      component.DefaultStat = defaultStat;
      component.Settings = settings;
      return AddComponent(component);
    }
  }
}

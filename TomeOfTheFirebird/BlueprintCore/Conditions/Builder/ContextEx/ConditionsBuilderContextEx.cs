using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.Utility;
using Kingmaker.View.Animation;

#nullable enable
namespace BlueprintCore.Conditions.Builder.ContextEx
{
  /// <summary>
  /// Extension to <see cref="ConditionsBuilder"/> for most <see cref="ContextCondition"/> types. Some
  /// <see cref="ContextCondition"/> types are in more specific extensions such as
  /// <see cref="KingdomEx.ConditionsBuilderKingdomEx">KingdomEx</see>.
  /// </summary>
  /// <inheritdoc cref="ConditionsBuilder"/>
  public static class ConditionsBuilderContextEx
  {
    /// <summary>
    /// Adds <see cref="ContextConditionHasBuffFromCaster"/>
    /// </summary>
    /// 
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff">BlueprintBuff</see></param>
    [Implements(typeof(ContextConditionHasBuffFromCaster))]
    public static ConditionsBuilder HasBuffFromCaster(this ConditionsBuilder builder, string buff, bool negate = false)
    {
      var hasBuff = ElementTool.Create<ContextConditionHasBuffFromCaster>();
      hasBuff.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      hasBuff.Not = negate;
      return builder.Add(hasBuff);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCasterHasFact"/>
    /// </summary>
    /// 
    /// <param name="fact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    [Implements(typeof(ContextConditionCasterHasFact))]
    public static ConditionsBuilder CasterHasFact(this ConditionsBuilder builder, string fact, bool negate = false)
    {
      var hasFact = ElementTool.Create<ContextConditionCasterHasFact>();
      hasFact.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(fact);
      hasFact.Not = negate;
      return builder.Add(hasFact);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHasFact"/>
    /// </summary>
    /// 
    /// <param name="fact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    [Implements(typeof(ContextConditionHasFact))]
    public static ConditionsBuilder HasFact(this ConditionsBuilder builder, string fact, bool negate = false)
    {
      var hasFact = ElementTool.Create<ContextConditionHasFact>();
      hasFact.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(fact);
      hasFact.Not = negate;
      return builder.Add(hasFact);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionTargetIsYourself"/>
    /// </summary>
    [Implements(typeof(ContextConditionTargetIsYourself))]
    public static ConditionsBuilder TargetIsYourself(this ConditionsBuilder builder, bool negate = false)
    {
      var condition = ElementTool.Create<ContextConditionTargetIsYourself>();
      condition.Not = negate;
      return builder.Add(condition);
    }

    //----- Auto Generated -----//

    /// <summary>
    /// Adds <see cref="ContextConditionDistanceToTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionDistanceToTarget))]
    public static ConditionsBuilder ContextConditionDistanceToTarget(
        this ConditionsBuilder builder,
        Feet distanceGreater,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionDistanceToTarget>();
      element.DistanceGreater = distanceGreater;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionAlignment))]
    public static ConditionsBuilder ContextConditionAlignment(
        this ConditionsBuilder builder,
        bool checkCaster = default,
        AlignmentComponent alignment = default,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionAlignment>();
      element.CheckCaster = checkCaster;
      element.Alignment = alignment;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionAlignmentDifference"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionAlignmentDifference))]
    public static ConditionsBuilder ContextConditionAlignmentDifference(
        this ConditionsBuilder builder,
        int alignmentStepDifference = default,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionAlignmentDifference>();
      element.AlignmentStepDifference = alignmentStepDifference;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionAlive"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionAlive))]
    public static ConditionsBuilder ContextConditionAlive(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionAlive>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionBuffRank"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ContextConditionBuffRank))]
    public static ConditionsBuilder ContextConditionBuffRank(
        this ConditionsBuilder builder,
        string? buff = null,
        ContextValue? rankValue = null,
        bool negate = false)
    {
      builder.Validate(rankValue);
    
      var element = ElementTool.Create<ContextConditionBuffRank>();
      element.Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      element.RankValue = rankValue ?? ContextValues.Constant(0);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCasterHasBuffWithDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionCasterHasBuffWithDescriptor))]
    public static ConditionsBuilder ContextConditionCasterHasBuffWithDescriptor(
        this ConditionsBuilder builder,
        SpellDescriptorWrapper spellDescriptor,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionCasterHasBuffWithDescriptor>();
      element.SpellDescriptor = spellDescriptor;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCasterIsPartyEnemy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionCasterIsPartyEnemy))]
    public static ConditionsBuilder ContextConditionCasterIsPartyEnemy(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionCasterIsPartyEnemy>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCasterWeaponInTwoHands"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionCasterWeaponInTwoHands))]
    public static ConditionsBuilder ContextConditionCasterWeaponInTwoHands(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionCasterWeaponInTwoHands>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCharacterClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="clazz"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ContextConditionCharacterClass))]
    public static ConditionsBuilder ContextConditionCharacterClass(
        this ConditionsBuilder builder,
        bool checkCaster = default,
        string? clazz = null,
        int minLevel = default,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionCharacterClass>();
      element.CheckCaster = checkCaster;
      element.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      element.MinLevel = minLevel;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCompare"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionCompare))]
    public static ConditionsBuilder ContextConditionCompare(
        this ConditionsBuilder builder,
        ContextConditionCompare.Type type = default,
        ContextValue? checkValue = null,
        ContextValue? targetValue = null,
        bool negate = false)
    {
      builder.Validate(checkValue);
      builder.Validate(targetValue);
    
      var element = ElementTool.Create<ContextConditionCompare>();
      element.m_Type = type;
      element.CheckValue = checkValue ?? ContextValues.Constant(0);
      element.TargetValue = targetValue ?? ContextValues.Constant(0);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCompareCasterHP"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionCompareCasterHP))]
    public static ConditionsBuilder ContextConditionCompareCasterHP(
        this ConditionsBuilder builder,
        ContextConditionCompareCasterHP.CompareType compareType = default,
        ContextValue? value = null,
        bool negate = false)
    {
      builder.Validate(value);
    
      var element = ElementTool.Create<ContextConditionCompareCasterHP>();
      element.m_CompareType = compareType;
      element.Value = value ?? ContextValues.Constant(0);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCompareTargetHP"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionCompareTargetHP))]
    public static ConditionsBuilder ContextConditionCompareTargetHP(
        this ConditionsBuilder builder,
        ContextConditionCompareTargetHP.CompareType compareType = default,
        ContextValue? value = null,
        bool negate = false)
    {
      builder.Validate(value);
    
      var element = ElementTool.Create<ContextConditionCompareTargetHP>();
      element.m_CompareType = compareType;
      element.Value = value ?? ContextValues.Constant(0);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionFavoredEnemy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionFavoredEnemy))]
    public static ConditionsBuilder ContextConditionFavoredEnemy(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionFavoredEnemy>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionGender"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionGender))]
    public static ConditionsBuilder ContextConditionGender(
        this ConditionsBuilder builder,
        Gender gender = default,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionGender>();
      element.Gender = gender;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHasBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ContextConditionHasBuff))]
    public static ConditionsBuilder ContextConditionHasBuff(
        this ConditionsBuilder builder,
        string? buff = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionHasBuff>();
      element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHasBuffWithDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionHasBuffWithDescriptor))]
    public static ConditionsBuilder ContextConditionHasBuffWithDescriptor(
        this ConditionsBuilder builder,
        SpellDescriptorWrapper spellDescriptor,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionHasBuffWithDescriptor>();
      element.SpellDescriptor = spellDescriptor;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHasItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="itemToCheck"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(ContextConditionHasItem))]
    public static ConditionsBuilder ContextConditionHasItem(
        this ConditionsBuilder builder,
        bool money = default,
        string? itemToCheck = null,
        int quantity = default,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionHasItem>();
      element.Money = money;
      element.m_ItemToCheck = BlueprintTool.GetRef<BlueprintItemReference>(itemToCheck);
      element.Quantity = quantity;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHasTouchSpellCharge"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionHasTouchSpellCharge))]
    public static ConditionsBuilder ContextConditionHasTouchSpellCharge(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionHasTouchSpellCharge>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHasUniqueBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ContextConditionHasUniqueBuff))]
    public static ConditionsBuilder ContextConditionHasUniqueBuff(
        this ConditionsBuilder builder,
        string? buff = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionHasUniqueBuff>();
      element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHitDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionHitDice))]
    public static ConditionsBuilder ContextConditionHitDice(
        this ConditionsBuilder builder,
        int hitDice = default,
        bool addSharedValue = default,
        AbilitySharedValue sharedValue = default,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionHitDice>();
      element.HitDice = hitDice;
      element.AddSharedValue = addSharedValue;
      element.SharedValue = sharedValue;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsAlly"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsAlly))]
    public static ConditionsBuilder ContextConditionIsAlly(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsAlly>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsAmuletEquipped"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsAmuletEquipped))]
    public static ConditionsBuilder ContextConditionIsAmuletEquipped(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsAmuletEquipped>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsAnimalCompanion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsAnimalCompanion))]
    public static ConditionsBuilder ContextConditionIsAnimalCompanion(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsAnimalCompanion>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsCaster))]
    public static ConditionsBuilder ContextConditionIsCaster(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsCaster>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsEnemy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsEnemy))]
    public static ConditionsBuilder ContextConditionIsEnemy(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsEnemy>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsFlanked"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsFlanked))]
    public static ConditionsBuilder ContextConditionIsFlanked(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsFlanked>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsFlatFooted"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsFlatFooted))]
    public static ConditionsBuilder ContextConditionIsFlatFooted(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsFlatFooted>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsHelpless"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsHelpless))]
    public static ConditionsBuilder ContextConditionIsHelpless(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsHelpless>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsInCombat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsInCombat))]
    public static ConditionsBuilder ContextConditionIsInCombat(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsInCombat>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsMainTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsMainTarget))]
    public static ConditionsBuilder ContextConditionIsMainTarget(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsMainTarget>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsPartyMember"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsPartyMember))]
    public static ConditionsBuilder ContextConditionIsPartyMember(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsPartyMember>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsPetDead"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsPetDead))]
    public static ConditionsBuilder ContextConditionIsPetDead(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsPetDead>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsRing1Equipped"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsRing1Equipped))]
    public static ConditionsBuilder ContextConditionIsRing1Equipped(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsRing1Equipped>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsRing2Equipped"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsRing2Equipped))]
    public static ConditionsBuilder ContextConditionIsRing2Equipped(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsRing2Equipped>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsShieldEquipped"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsShieldEquipped))]
    public static ConditionsBuilder ContextConditionIsShieldEquipped(
        this ConditionsBuilder builder,
        bool checkCaster = default,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsShieldEquipped>();
      element.CheckCaster = checkCaster;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsTwoHandedEquipped"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsTwoHandedEquipped))]
    public static ConditionsBuilder ContextConditionIsTwoHandedEquipped(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsTwoHandedEquipped>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsUnconscious"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsUnconscious))]
    public static ConditionsBuilder ContextConditionIsUnconscious(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsUnconscious>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsWeaponEquipped"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsWeaponEquipped))]
    public static ConditionsBuilder ContextConditionIsWeaponEquipped(
        this ConditionsBuilder builder,
        bool checkWeaponRangeType = default,
        bool checkWeaponCategory = default,
        WeaponRangeType rangeType = default,
        WeaponCategory category = default,
        bool checkOnCaster = default,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsWeaponEquipped>();
      element.CheckWeaponRangeType = checkWeaponRangeType;
      element.CheckWeaponCategory = checkWeaponCategory;
      element.RangeType = rangeType;
      element.Category = category;
      element.CheckOnCaster = checkOnCaster;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionMaximumBurn"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionMaximumBurn))]
    public static ConditionsBuilder ContextConditionMaximumBurn(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionMaximumBurn>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionPeaceful"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionPeaceful))]
    public static ConditionsBuilder ContextConditionPeaceful(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionPeaceful>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionSharedValueHigher"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionSharedValueHigher))]
    public static ConditionsBuilder ContextConditionSharedValueHigher(
        this ConditionsBuilder builder,
        AbilitySharedValue sharedValue = default,
        int higherOrEqual = default,
        bool inverted = default,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionSharedValueHigher>();
      element.SharedValue = sharedValue;
      element.HigherOrEqual = higherOrEqual;
      element.Inverted = inverted;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionSharedValueHitDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionSharedValueHitDice))]
    public static ConditionsBuilder ContextConditionSharedValueHitDice(
        this ConditionsBuilder builder,
        AbilitySharedValue sharedValue = default,
        bool inverted = default,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionSharedValueHitDice>();
      element.SharedValue = sharedValue;
      element.Inverted = inverted;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionSize"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionSize))]
    public static ConditionsBuilder ContextConditionSize(
        this ConditionsBuilder builder,
        Size size = default,
        bool invert = default,
        bool checkCaster = default,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionSize>();
      element.Size = size;
      element.Invert = invert;
      element.CheckCaster = checkCaster;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionStatValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionStatValue))]
    public static ConditionsBuilder ContextConditionStatValue(
        this ConditionsBuilder builder,
        int n = default,
        StatType stat = default,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionStatValue>();
      element.N = n;
      element.Stat = stat;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionStealth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionStealth))]
    public static ConditionsBuilder ContextConditionStealth(
        this ConditionsBuilder builder,
        ContextConditionStealth.CheckTarget checkTarget = default,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionStealth>();
      element.m_CheckTarget = checkTarget;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionTargetCanSeeInvisible"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionTargetCanSeeInvisible))]
    public static ConditionsBuilder ContextConditionTargetCanSeeInvisible(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionTargetCanSeeInvisible>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionTargetIsArcaneCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionTargetIsArcaneCaster))]
    public static ConditionsBuilder ContextConditionTargetIsArcaneCaster(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionTargetIsArcaneCaster>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionTargetIsBlueprint"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unit"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(ContextConditionTargetIsBlueprint))]
    public static ConditionsBuilder ContextConditionTargetIsBlueprint(
        this ConditionsBuilder builder,
        string? unit = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionTargetIsBlueprint>();
      element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(unit);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionTargetIsDivineCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionTargetIsDivineCaster))]
    public static ConditionsBuilder ContextConditionTargetIsDivineCaster(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionTargetIsDivineCaster>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionTargetIsEngaged"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionTargetIsEngaged))]
    public static ConditionsBuilder ContextConditionTargetIsEngaged(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionTargetIsEngaged>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionUnconsciousAllyFarThan"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionUnconsciousAllyFarThan))]
    public static ConditionsBuilder ContextConditionUnconsciousAllyFarThan(
        this ConditionsBuilder builder,
        Feet distance,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionUnconsciousAllyFarThan>();
      element.Distance = distance;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionWeaponAnimationStyle"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionWeaponAnimationStyle))]
    public static ConditionsBuilder ContextConditionWeaponAnimationStyle(
        this ConditionsBuilder builder,
        WeaponAnimationStyle animationStyle = default,
        bool checkOnCaster = default,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionWeaponAnimationStyle>();
      element.AnimationStyle = animationStyle;
      element.CheckOnCaster = checkOnCaster;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextSwarmHasEnemiesInInnerCircle"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextSwarmHasEnemiesInInnerCircle))]
    public static ConditionsBuilder ContextSwarmHasEnemiesInInnerCircle(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextSwarmHasEnemiesInInnerCircle>();
      element.Not = negate;
      return builder.Add(element);
    }
  }
}

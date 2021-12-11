using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Armies.Components;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Armies.TacticalCombat.GameActions;
using Kingmaker.Armies.TacticalCombat.Grid;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Crusade.GlobalMagic;
using Kingmaker.Crusade.GlobalMagic.Actions;
using Kingmaker.Crusade.GlobalMagic.Actions.DamageLogic;
using Kingmaker.Crusade.GlobalMagic.Actions.SummonLogics;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Globalmap.State;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Actions;
using Kingmaker.Kingdom.Armies;
using Kingmaker.Kingdom.Armies.Actions;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Kingdom.Flags;
using Kingmaker.Kingdom.Settlements;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System.Linq;

#nullable enable
namespace BlueprintCore.Actions.Builder.KingdomEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for actions involving the Kingdom and Crusade
  /// system.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderKingdomEx
  {
    //----- Kingmaker.Armies.TacticalCombat.GameActions -----//

    /// <summary>
    /// Adds <see cref="ArmyAdditionalAction"/>
    /// </summary>
    [Implements(typeof(ArmyAdditionalAction))]
    public static ActionsBuilder GrantExtraArmyAction(
        this ActionsBuilder builder,
        bool usableInCurrentTurn = true,
        bool usableInBonusMoraleTurn = true)
    {
      var grantAction = ElementTool.Create<ArmyAdditionalAction>();
      grantAction.m_InCurrentTurn = usableInCurrentTurn;
      grantAction.m_CanAddInBonusMoraleTurn = usableInBonusMoraleTurn;
      return builder.Add(grantAction);
    }

    /// <summary>
    /// Adds <see cref="ContextActionAddCrusadeResource"/>
    /// </summary>
    [Implements(typeof(ContextActionAddCrusadeResource))]
    public static ActionsBuilder AddCrusadeResource(
        this ActionsBuilder builder, KingdomResourcesAmount amount)
    {
      var addResource = ElementTool.Create<ContextActionAddCrusadeResource>();
      addResource.m_ResourcesAmount = amount;
      return builder.Add(addResource);
    }

    /// <summary>
    /// Adds <see cref="ContextActionArmyRemoveFacts"/>
    /// </summary>
    /// 
    /// <param name="facts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    [Implements(typeof(ContextActionArmyRemoveFacts))]
    public static ActionsBuilder RemoveArmyFacts(
        this ActionsBuilder builder, params string[] facts)
    {
      var removeFacts = ElementTool.Create<ContextActionArmyRemoveFacts>();
      removeFacts.m_FactsToRemove =
          facts.Select(fact => BlueprintTool.GetRef<BlueprintUnitFactReference>(fact)).ToArray();
      return builder.Add(removeFacts);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRestoreLeaderAction"/>
    /// </summary>
    [Implements(typeof(ContextActionRestoreLeaderAction))]
    public static ActionsBuilder RestoreLeaderAction(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionRestoreLeaderAction>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionStopUnit"/>
    /// </summary>
    [Implements(typeof(ContextActionStopUnit))]
    public static ActionsBuilder StopUnit(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionStopUnit>());
    }

    //----- Kingmaker.Crusade.GlobalMagic.Actions -----//

    /// <summary>
    /// Adds <see cref="AddBuffToSquad"/>
    /// </summary>
    /// 
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff">BlueprintBuff</see></param>
    [Implements(typeof(AddBuffToSquad))]
    public static ActionsBuilder BuffSquad(
        this ActionsBuilder builder,
        string buff,
        GlobalMagicValue durationHours,
        SquadFilter filter)
    {
      var buffSquad = ElementTool.Create<AddBuffToSquad>();
      buffSquad.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      buffSquad.m_HoursDuration = durationHours;
      buffSquad.m_Filter = filter;
      return builder.Add(buffSquad);
    }

    /// <summary>
    /// Adds <see cref="ChangeArmyMorale"/>
    /// </summary>
    [Implements(typeof(ChangeArmyMorale))]
    public static ActionsBuilder ChangeArmyMorale(
          this ActionsBuilder builder, GlobalMagicValue duration, GlobalMagicValue change)
    {
      var changeMorale = ElementTool.Create<ChangeArmyMorale>();
      changeMorale.m_Duration = duration;
      changeMorale.m_ChangeValue = change;
      return builder.Add(changeMorale);
    }

    /// <summary>
    /// Adds <see cref="FakeSkipTime"/>
    /// </summary>
    [Implements(typeof(FakeSkipTime))]
    public static ActionsBuilder FakeSkipTime(this ActionsBuilder builder, GlobalMagicValue days)
    {
      var skipTime = ElementTool.Create<FakeSkipTime>();
      skipTime.m_SkipDays = days;
      return builder.Add(skipTime);
    }

    /// <summary>
    /// Adds <see cref="GainDiceArmyDamage"/>
    /// </summary>
    [Implements(typeof(GainDiceArmyDamage))]
    public static ActionsBuilder GainArmyDamage(
        this ActionsBuilder builder, SquadFilter filter, GlobalMagicValue dmgDice)
    {
      var gainDmg = ElementTool.Create<GainDiceArmyDamage>();
      gainDmg.m_Filter = filter;
      gainDmg.m_DiceValue = dmgDice;
      return builder.Add(gainDmg);
    }

    /// <summary>
    /// Adds <see cref="RemoveUnitsByExp"/>
    /// </summary>
    [Implements(typeof(RemoveUnitsByExp))]
    public static ActionsBuilder RemoveUnitsByExp(
        this ActionsBuilder builder, SquadFilter filter, GlobalMagicValue exp)
    {
      var removeUnits = ElementTool.Create<RemoveUnitsByExp>();
      removeUnits.m_Filter = filter;
      removeUnits.m_ExpValue = exp;
      return builder.Add(removeUnits);
    }

    /// <summary>
    /// Adds <see cref="GainGlobalMagicSpell"/>
    /// </summary>
    /// 
    /// <param name="spell"><see cref="BlueprintGlobalMagicSpell"/></param>
    [Implements(typeof(GainGlobalMagicSpell))]
    public static ActionsBuilder GainGlobalSpell(this ActionsBuilder builder, string spell)
    {
      var gainSpell = ElementTool.Create<GainGlobalMagicSpell>();
      gainSpell.m_Spell = BlueprintTool.GetRef<BlueprintGlobalMagicSpell.Reference>(spell);
      return builder.Add(gainSpell);
    }

    /// <summary>
    /// Adds <see cref="ManuallySetGlobalSpellCooldown"/>
    /// </summary>
    /// 
    /// <param name="spell"><see cref="BlueprintGlobalMagicSpell"/></param>
    [Implements(typeof(ManuallySetGlobalSpellCooldown))]
    public static ActionsBuilder PutGlobalSpellOnCooldown(this ActionsBuilder builder, string spell)
    {
      var activateCooldown = ElementTool.Create<ManuallySetGlobalSpellCooldown>();
      activateCooldown.m_Spell = BlueprintTool.GetRef<BlueprintGlobalMagicSpell.Reference>(spell);
      return builder.Add(activateCooldown);
    }

    /// <summary>
    /// Adds <see cref="OpenTeleportationInterface"/>
    /// </summary>
    [Implements(typeof(OpenTeleportationInterface))]
    public static ActionsBuilder GlobalTeleport(this ActionsBuilder builder, ActionsBuilder onTeleport)
    {
      var teleport = ElementTool.Create<OpenTeleportationInterface>();
      teleport.m_OnTeleportActions = onTeleport.Build();
      return builder.Add(teleport);
    }

    /// <summary>
    /// Adds <see cref="RemoveGlobalMagicSpell"/>
    /// </summary>
    /// 
    /// <param name="spell"><see cref="BlueprintGlobalMagicSpell"/></param>
    [Implements(typeof(RemoveGlobalMagicSpell))]
    public static ActionsBuilder RemoveGlobalSpell(this ActionsBuilder builder, string spell)
    {
      var removespell = ElementTool.Create<RemoveGlobalMagicSpell>();
      removespell.m_Spell = BlueprintTool.GetRef<BlueprintGlobalMagicSpell.Reference>(spell);
      return builder.Add(removespell);
    }

    /// <summary>
    /// Adds <see cref="RepairLeaderMana"/>
    /// </summary>
    [Implements(typeof(RepairLeaderMana))]
    public static ActionsBuilder RestoreLeaderMana(this ActionsBuilder builder, GlobalMagicValue value)
    {
      var restoreMana = ElementTool.Create<RepairLeaderMana>();
      restoreMana.m_Value = value;
      return builder.Add(restoreMana);
    }

    /// <summary>
    /// Adds <see cref="SummonExistUnits"/>
    /// </summary>
    [Implements(typeof(SummonExistUnits))]
    public static ActionsBuilder SummonMoreUnits(
        this ActionsBuilder builder, GlobalMagicValue expCost)
    {
      var summon = ElementTool.Create<SummonExistUnits>();
      summon.m_SumExpCost = expCost;
      return builder.Add(summon);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Crusade.GlobalMagic.Actions.SummonLogics.SummonRandomGroup">SummonRandomGroup</see>
    /// </summary>
    [Implements(typeof(SummonRandomGroup))]
    public static ActionsBuilder SummonRandomGroup(
        this ActionsBuilder builder,
        params SummonRandomGroup.RandomGroup[] groups)
    {
      var summon = ElementTool.Create<SummonRandomGroup>();
      summon.m_RandomGroups = groups;
      return builder.Add(summon);
    }

    /// <summary>
    /// Adds <see cref="TeleportArmyAction"/>
    /// </summary>
    [Implements(typeof(TeleportArmyAction))]
    public static ActionsBuilder TeleportArmy(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<TeleportArmyAction>());
    }

    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.CreateArmy">CreateArmy</see>
    /// </summary>
    /// 
    /// <param name="army"><see cref="BlueprintArmyPreset"/></param>
    /// <param name="location"><see cref="BlueprintGlobalMapPoint"/></param>
    /// <param name="leader"><see cref="BlueprintArmyLeader"/></param>
    [Implements(typeof(CreateArmy))]
    public static ActionsBuilder CreateCrusaderArmy(
        this ActionsBuilder builder,
        string army,
        string location,
        string? leader = null,
        int? movePoints = null,
        float? speed = null,
        bool? applyRecruitIncrease = null)
    {
      return builder.Add(
          CreateArmy(
              ArmyFaction.Crusaders,
              army,
              location,
              leader,
              movePoints: movePoints,
              speed: speed,
              applyRecruitIncrease: applyRecruitIncrease));
    }

    /// <inheritdoc cref="CreateCrusaderArmy"/>
    [Implements(typeof(CreateArmy))]
    public static ActionsBuilder CreateCrusaderArmyFromLosses(
        this ActionsBuilder builder,
        string location,
        int sumExperience,
        int maxSquads,
        bool applyRecruitIncrease = false)
    {
      var createArmy = ElementTool.Create<CreateArmyFromLosses>();
      createArmy.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(location);
      createArmy.m_SumExperience = sumExperience;
      createArmy.m_SquadsMaxCount = maxSquads;
      createArmy.m_ApplyRecruitIncrease = applyRecruitIncrease;
      return builder.Add(createArmy);
    }

    /// <inheritdoc cref="CreateCrusaderArmy"/>
    [Implements(typeof(CreateArmy))]
    public static ActionsBuilder CreateDemonArmy(
        this ActionsBuilder builder,
        string army,
        string location,
        string? leader = null,
        bool targetNearestEnemy = false,
        float? speed = null)
    {
      return builder.Add(
          CreateArmy(
              ArmyFaction.Demons,
              army,
              location,
              leader,
              target: targetNearestEnemy ? TravelLogicType.NearestEnemy : TravelLogicType.None,
              speed: speed));
    }


    /// <inheritdoc cref="CreateCrusaderArmy"/>
    /// 
    /// <param name="targetLocation"><see cref="BlueprintGlobalMapPoint"/></param>
    /// <param name="onTargetReached"><see cref="BlueprintActionList"/></param>
    [Implements(typeof(CreateArmy))]
    public static ActionsBuilder CreateDemonArmyTargetingLocation(
        this ActionsBuilder builder,
        string army,
        string location,
        string targetLocation,
        string? onTargetReached = null,
        string? leader = null,
        int? daysToTarget = null)
    {
      return builder.Add(
          CreateArmy(
              ArmyFaction.Demons,
              army,
              location,
              leader,
              targetLocation: targetLocation,
              onTargetReached: onTargetReached,
              daysToTarget: daysToTarget,
              target: TravelLogicType.Location));
    }

    private static CreateArmy CreateArmy(
        ArmyFaction faction,
        string army,
        string location,
        string? leader,
        string? targetLocation = null,
        string? onTargetReached = null,
        int? daysToTarget = null,
        int? movePoints = null,
        float? speed = null,
        bool? applyRecruitIncrease = null,
        TravelLogicType target = TravelLogicType.None)
    {
      var createArmy = ElementTool.Create<CreateArmy>();
      createArmy.Faction = faction;
      createArmy.Preset = BlueprintTool.GetRef<BlueprintArmyPreset.Reference>(army);
      createArmy.Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(location);
      createArmy.m_MoveTarget = target;

      createArmy.m_DaysToDestination = daysToTarget ?? 7;
      createArmy.MovementPoints = movePoints ?? 60;
      createArmy.m_ArmySpeed = speed ?? 1f;
      createArmy.m_ApplyRecruitIncrease = applyRecruitIncrease ?? false;

      if (leader == null)
      {
        createArmy.ArmyLeader = BlueprintReferenceBase.CreateTyped<ArmyLeader.Reference>(null);
      }
      else
      {
        createArmy.ArmyLeader = BlueprintTool.GetRef<ArmyLeader.Reference>(leader);
        createArmy.WithLeader = true;
      }
      createArmy.m_TargetLocation =
          BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(targetLocation!);
      createArmy.m_CompleteActions =
          BlueprintTool.GetRef<BlueprintActionList.Reference>(onTargetReached!);
      return createArmy;
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.CreateGarrison">CreateGarrison</see>
    /// </summary>
    /// 
    /// <param name="army"><see cref="BlueprintArmyPreset"/></param>
    /// <param name="location"><see cref="BlueprintGlobalMapPoint"/></param>
    /// <param name="leader"><see cref="BlueprintArmyLeader"/></param>
    [Implements(typeof(CreateGarrison))]
    public static ActionsBuilder CreateGarrison(
        this ActionsBuilder builder,
        string army,
        string location,
        string? leader = null,
        bool noReward = true)
    {
      var createGarrison = ElementTool.Create<CreateGarrison>();
      createGarrison.Preset = BlueprintTool.GetRef<BlueprintArmyPreset.Reference>(army);
      createGarrison.Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(location);
      createGarrison.HasNoReward = noReward;

      if (leader == null)
      {
        createGarrison.ArmyLeader = BlueprintReferenceBase.CreateTyped<ArmyLeader.Reference>(null);
      }
      else
      {
        createGarrison.WithLeader = true;
        createGarrison.ArmyLeader = BlueprintTool.GetRef<ArmyLeader.Reference>(leader);
      }
      return builder.Add(createGarrison);
    }

    //----- Kingmaker.Kingdom.Actions -----//

    /// <summary>
    /// Adds <see cref="AddMorale"/>
    /// </summary>
    [Implements(typeof(AddMorale))]
    public static ActionsBuilder IncreaseMorale(this ActionsBuilder builder, DiceFormula value, int bonus)
    {
      var increaseMorale = ElementTool.Create<AddMorale>();
      increaseMorale.Change = value;
      increaseMorale.Bonus = bonus;
      return builder.Add(increaseMorale);
    }

    /// <inheritdoc cref="IncreaseMorale"/>
    [Implements(typeof(AddMorale))]
    public static ActionsBuilder ReduceMorale(this ActionsBuilder builder, DiceFormula value, int bonus)
    {
      var reduceMorale = ElementTool.Create<AddMorale>();
      reduceMorale.Change = value;
      reduceMorale.Bonus = bonus;
      reduceMorale.Substract = true;
      return builder.Add(reduceMorale);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionActivateEventDeck"/>
    /// </summary>
    /// 
    /// <param name="deck"><see cref="BlueprintKingdomDeck"/></param>
    [Implements(typeof(KingdomActionActivateEventDeck))]
    public static ActionsBuilder ActivateEventDeck(this ActionsBuilder builder, string deck)
    {
      var activateDeck = ElementTool.Create<KingdomActionActivateEventDeck>();
      activateDeck.m_Deck = BlueprintTool.GetRef<BlueprintKingdomDeckReference>(deck);
      return builder.Add(activateDeck);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionAddBPRandom"/>
    /// </summary>
    [Implements(typeof(KingdomActionAddBPRandom))]
    public static ActionsBuilder AddBP(
        this ActionsBuilder builder,
        KingdomResource type,
        DiceFormula value,
        int bonus,
        bool showInEventHistory = true)
    {
      var addBP = ElementTool.Create<KingdomActionAddBPRandom>();
      addBP.ResourceType = type;
      addBP.Change = value;
      addBP.Bonus = bonus;
      addBP.IncludeInEventStats = showInEventHistory;
      return builder.Add(addBP);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionAddBuff"/>
    /// </summary>
    /// 
    /// <param name="buff"><see cref="BlueprintKingdomBuff"/></param>
    /// <param name="targetRegion"><see cref="BlueprintRegion"/></param>
    [Implements(typeof(KingdomActionAddBuff))]
    public static ActionsBuilder AddKingdomBuff(
        this ActionsBuilder builder,
        string buff,
        int durationOverrideDays = 0,
        string? targetRegion = null,
        bool applyToRegion = true,
        bool applyToAdjacentRegions = false)
    {
      var addBuff = ElementTool.Create<KingdomActionAddBuff>();
      addBuff.m_Blueprint = BlueprintTool.GetRef<BlueprintKingdomBuffReference>(buff);
      addBuff.OverrideDuration = durationOverrideDays;
      addBuff.m_Region = BlueprintTool.GetRef<BlueprintRegionReference>(targetRegion!);
      addBuff.ApplyToRegion = applyToRegion;
      addBuff.CopyToAdjacentRegions = applyToAdjacentRegions;
      return builder.Add(addBuff);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionAddFreeBuilding"/>
    /// </summary>
    /// 
    /// <param name="building"><see cref="Kingmaker.Kingdom.Settlements.BlueprintSettlementBuilding">BlueprintSettlementBuilding</see></param>
    /// <param name="settlement"><see cref="BlueprintSettlement"/></param>
    [Implements(typeof(KingdomActionAddFreeBuilding))]
    public static ActionsBuilder AddFreeBuilding(
        this ActionsBuilder builder, string building, int count = 1, string? settlement = null)
    {
      var addBuilding = ElementTool.Create<KingdomActionAddFreeBuilding>();
      addBuilding.m_Building = BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(building);
      addBuilding.Count = count;
      if (settlement == null)
      {
        addBuilding.Anywhere = true;
      }
      else
      {
        addBuilding.Anywhere = false;
        addBuilding.m_Settlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(settlement);
      }
      return builder.Add(addBuilding);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionAddMercenaryReroll"/>
    /// </summary>
    [Implements(typeof(KingdomActionAddMercenaryReroll))]
    public static ActionsBuilder AddFreeMercRerolls(this ActionsBuilder builder, int count = 1)
    {
      var addMercRerolls = ElementTool.Create<KingdomActionAddMercenaryReroll>();
      addMercRerolls.m_FreeRerollsToAdd = count;
      return builder.Add(addMercRerolls);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionAddRandomBuff"/>
    /// </summary>
    /// 
    /// <param name="buffs"><see cref="BlueprintKingdomBuff"/></param>
    [Implements(typeof(KingdomActionAddRandomBuff))]
    public static ActionsBuilder AddRandomKingdomBuff(
        this ActionsBuilder builder, string[] buffs, int durationOverrideDays = 0)
    {
      var addBuff = ElementTool.Create<KingdomActionAddRandomBuff>();
      addBuff.m_Buffs =
          buffs.Select(buff => BlueprintTool.GetRef<BlueprintKingdomBuffReference>(buff)).ToList();
      addBuff.OverrideDurationDays = durationOverrideDays;
      return builder.Add(addBuff);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionArtisanRequestHelp"/>
    /// </summary>
    /// 
    /// <param name="artisan"><see cref="Kingmaker.Kingdom.Artisans.BlueprintKingdomArtisan">BlueprintKingdomArtisan</see></param>
    /// <param name="project"><see cref="BlueprintKingdomProject"/></param>
    [Implements(typeof(KingdomActionArtisanRequestHelp))]
    public static ActionsBuilder ArtisanRequestHelp(this ActionsBuilder builder, string artisan, string project)
    {
      var requestHelp = ElementTool.Create<KingdomActionArtisanRequestHelp>();
      requestHelp.m_Artisan = BlueprintTool.GetRef<BlueprintKingdomArtisanReference>(artisan);
      requestHelp.m_Project = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(project);
      return builder.Add(requestHelp);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionChangeToAutoCrusade"/>
    /// </summary>
    [Implements(typeof(KingdomActionChangeToAutoCrusade))]
    public static ActionsBuilder EnableAutoCrusade(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionChangeToAutoCrusade>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionCollectLoot"/>
    /// </summary>
    [Implements(typeof(KingdomActionCollectLoot))]
    public static ActionsBuilder CollectKingdomLoot(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionCollectLoot>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionConquerRegion"/>
    /// </summary>
    /// 
    /// <param name="region"><see cref="BlueprintRegion"/></param>
    [Implements(typeof(KingdomActionConquerRegion))]
    public static ActionsBuilder ConquerRegion(this ActionsBuilder builder, string region)
    {
      var conquer = ElementTool.Create<KingdomActionConquerRegion>();
      conquer.m_Region = BlueprintTool.GetRef<BlueprintRegionReference>(region);
      return builder.Add(conquer);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionDestroyAllSettlements"/>
    /// </summary>
    [Implements(typeof(KingdomActionDestroyAllSettlements))]
    public static ActionsBuilder DestroyAllSettlements(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionDestroyAllSettlements>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionDisable"/>
    /// </summary>
    [Implements(typeof(KingdomActionDisable))]
    public static ActionsBuilder DisableKingdom(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionDisable>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionEnable"/>
    /// </summary>
    [Implements(typeof(KingdomActionEnable))]
    public static ActionsBuilder EnableKingdom(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionEnable>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionFillSettlement"/>
    /// </summary>
    /// 
    /// <param name="settlement"><see cref="BlueprintSettlement"/></param>
    /// <param name="buildList"><see cref="Kingmaker.Kingdom.AI.SettlementBuildList">SettlementBuildList</see></param>
    [Implements(typeof(KingdomActionFillSettlement))]
    public static ActionsBuilder FillSettlement(
        this ActionsBuilder builder, string settlement, string buildList)
    {
      var fill = ElementTool.Create<KingdomActionFillSettlement>();
      fill.m_SpecificSettlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(settlement);
      fill.m_BuildList = BlueprintTool.GetRef<SettlementBuildListReference>(buildList);
      return builder.Add(fill);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionFillSettlementByLocation"/>
    /// </summary>
    /// 
    /// <param name="location"><see cref="BlueprintGlobalMapPoint"/></param>
    /// <param name="buildList"><see cref="Kingmaker.Kingdom.AI.SettlementBuildList">SettlementBuildList</see></param>
    [Implements(typeof(KingdomActionFillSettlementByLocation))]
    public static ActionsBuilder FillSettlementByLocation(
        this ActionsBuilder builder, string location, string buildList)
    {
      var fill = ElementTool.Create<KingdomActionFillSettlementByLocation>();
      fill.m_SpecificSettlementLocation =
          BlueprintTool.GetRef<BlueprintGlobalMapPointReference>(location);
      fill.m_BuildList = BlueprintTool.GetRef<SettlementBuildListReference>(buildList);
      return builder.Add(fill);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionFinishRandomBuilding"/>
    /// </summary>
    [Implements(typeof(KingdomActionFinishRandomBuilding))]
    public static ActionsBuilder FinishRandomBuilding(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionFinishRandomBuilding>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionFoundKingdom"/>
    /// </summary>
    [Implements(typeof(KingdomActionFoundKingdom))]
    public static ActionsBuilder FoundKingdom(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionFoundKingdom>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionFoundSettlement"/>
    /// </summary>
    /// 
    /// <param name="location"><see cref="BlueprintGlobalMapPoint"/></param>
    /// <param name="settlement"><see cref="BlueprintSettlement"/></param>
    [Implements(typeof(KingdomActionFoundSettlement))]
    public static ActionsBuilder FoundSettlement(
        this ActionsBuilder builder, string location, string settlement)
    {
      var found = ElementTool.Create<KingdomActionFoundSettlement>();
      found.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(location);
      found.m_Settlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(settlement);
      return builder.Add(found);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionGainLeaderExperience"/>
    /// </summary>
    [Implements(typeof(KingdomActionGainLeaderExperience))]
    public static ActionsBuilder GrantLeaderExp(
        this ActionsBuilder builder, IntEvaluator exp, float? leaderLevelMultiplier = null)
    {
      builder.Validate(exp);

      var grantExp = ElementTool.Create<KingdomActionGainLeaderExperience>();
      grantExp.m_Value = exp;
      if (leaderLevelMultiplier != null)
      {
        grantExp.m_MultiplyByLeaderLevel = true;
        grantExp.m_MultiplierCoefficient = leaderLevelMultiplier.Value;
      }
      return builder.Add(grantExp);
    }

    //----- Kingmaker.Kingdom.Blueprints -----//

    /// <summary>
    /// Adds <see cref="Kingmaker.Kingdom.Blueprints.AddCrusadeResources">AddCrusadeResources</see>
    /// </summary>
    [Implements(typeof(AddCrusadeResources))]
    public static ActionsBuilder AddCrusadeResources(
        this ActionsBuilder builder, KingdomResourcesAmount resources)
    {
      var addResources = ElementTool.Create<AddCrusadeResources>();
      addResources._resourcesAmount = resources;
      return builder.Add(addResources);
    }

    //----- Kingmaker.UnitLogic.Mechanics.Actions -----//

    /// <summary>
    /// Adds <see cref="Kingmaker.UnitLogic.Mechanics.Actions.ChangeTacticalMorale">ChangeTacticalMorale</see>
    /// </summary>
    [Implements(typeof(ChangeTacticalMorale))]
    public static ActionsBuilder ChangeTacticalMorale(
        this ActionsBuilder builder, ContextValue value)
    {
      var changeMorale = ElementTool.Create<ChangeTacticalMorale>();
      changeMorale.m_Value = value;
      return builder.Add(changeMorale);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSquadUnitsKill"/>
    /// </summary>
    /// 
    /// <remarks>
    /// Use this to kill non-leader units from the caster's squad. Use <see cref="KillSquadLeaders"/> for leaders units.
    /// </remarks>
    /// 
    /// <param name="percent">Percentage of squad units to kill as a float between 0.0 and 1.0.</param>
    [Implements(typeof(ContextActionSquadUnitsKill))]
    public static ActionsBuilder KillSquadUnits(this ActionsBuilder builder, float percent)
    {
      var kill = ElementTool.Create<ContextActionSquadUnitsKill>();
      kill.m_UseFloatValue = true;
      kill.m_FloatCount = percent;
      return builder.Add(kill);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSquadUnitsKill"/>
    /// </summary>
    /// 
    /// <remarks>
    /// Use this to kill leader units from the caster's squad. Use <see cref="KillSquadUnits"/> for regular units.
    /// </remarks>
    [Implements(typeof(ContextActionSquadUnitsKill))]
    public static ActionsBuilder KillSquadLeaders(
        this ActionsBuilder builder, ContextDiceValue count)
    {
      var kill = ElementTool.Create<ContextActionSquadUnitsKill>();
      kill.m_Count = count;
      return builder.Add(kill);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSummonTacticalSquad"/>
    /// </summary>
    /// 
    /// <param name="unit"><see cref="BlueprintUnit"/></param>
    /// <param name="summonPool"><see cref="BlueprintSummonPool"/></param>
    [Implements(typeof(ContextActionSummonTacticalSquad))]
    public static ActionsBuilder SummonSquad(
        this ActionsBuilder builder,
        string unit,
        ContextValue count,
        ActionsBuilder? onSpawn = null,
        string? summonPool = null)
    {
      var summon = ElementTool.Create<ContextActionSummonTacticalSquad>();
      summon.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitReference>(unit);
      summon.m_Count = count;
      summon.m_AfterSpawn = onSpawn?.Build() ?? Constants.Empty.Actions;
      summon.m_SummonPool =
          summonPool is null
              ? null
              : BlueprintTool.GetRef<BlueprintSummonPoolReference>(summonPool);
      return builder.Add(summon);
    }

    /// <summary>
    /// Adds <see cref="ContextActionTacticalCombatDealDamage"/>
    /// </summary>
    [Implements(typeof(ContextActionTacticalCombatDealDamage))]
    public static ActionsBuilder TacticalCombatDealDamage(
        this ActionsBuilder builder,
        DamageTypeDescription type,
        DiceType diceType,
        ContextValue? diceRolls = null,
        bool dealHalf = false,
        bool ignoreCrit = false,
        int? minHPAfterDmg = null)
    {
      var dmg = ElementTool.Create<ContextActionTacticalCombatDealDamage>();
      dmg.DamageType = type;
      dmg.DiceType = diceType;
      dmg.RollsCount = diceRolls ?? dmg.RollsCount;
      dmg.Half = dealHalf;
      dmg.IgnoreCritical = ignoreCrit;

      if (minHPAfterDmg != null)
      {
        dmg.UseMinHPAfterDamage = true;
        dmg.MinHPAfterDamage = minHPAfterDmg.Value;
      }
      return builder.Add(dmg);
    }

    /// <summary>
    /// Adds <see cref="ContextActionTacticalCombatHealTarget"/>
    /// </summary>
    [Implements(typeof(ContextActionTacticalCombatHealTarget))]
    public static ActionsBuilder TacticalCombatHeal(
        this ActionsBuilder builder,
        DiceType diceType = DiceType.D6,
        ContextValue? diceRolls = null)
    {
      var heal = ElementTool.Create<ContextActionTacticalCombatHealTarget>();
      heal.DiceType = diceType;
      heal.RollsCount = diceRolls ?? heal.RollsCount;
      return builder.Add(heal);
    }

    //----- Auto Generated -----//

    /// <summary>
    /// Adds <see cref="KingdomIncreaseIncome"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomIncreaseIncome))]
    public static ActionsBuilder KingdomIncreaseIncome(
        this ActionsBuilder builder,
        int bonus = default,
        KingdomResource resourceType = default)
    {
      var element = ElementTool.Create<KingdomIncreaseIncome>();
      element.Bonus = bonus;
      element.ResourceType = resourceType;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangeKingdomMoraleMaximum"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeKingdomMoraleMaximum))]
    public static ActionsBuilder ChangeKingdomMoraleMaximum(
        this ActionsBuilder builder,
        int maxValueDelta = default)
    {
      var element = ElementTool.Create<ChangeKingdomMoraleMaximum>();
      element.m_MaxValueDelta = maxValueDelta;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomAddMoraleFlags"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="newFlags"><see cref="Kingmaker.Kingdom.Flags.BlueprintKingdomMoraleFlag"/></param>
    [Generated]
    [Implements(typeof(KingdomAddMoraleFlags))]
    public static ActionsBuilder KingdomAddMoraleFlags(
        this ActionsBuilder builder,
        string[]? newFlags = null)
    {
      var element = ElementTool.Create<KingdomAddMoraleFlags>();
      element.m_NewFlags = newFlags.Select(name => BlueprintTool.GetRef<BlueprintKingdomMoraleFlag.Reference>(name)).ToArray();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomFlagIncrement"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="targetFlag"><see cref="Kingmaker.Kingdom.Flags.BlueprintKingdomMoraleFlag"/></param>
    [Generated]
    [Implements(typeof(KingdomFlagIncrement))]
    public static ActionsBuilder KingdomFlagIncrement(
        this ActionsBuilder builder,
        string? targetFlag = null,
        int increment = default)
    {
      var element = ElementTool.Create<KingdomFlagIncrement>();
      element.m_TargetFlag = BlueprintTool.GetRef<BlueprintKingdomMoraleFlag.Reference>(targetFlag);
      element.m_Increment = increment;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomMoraleFlagUpdateIncome"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="targetFlag"><see cref="Kingmaker.Kingdom.Flags.BlueprintKingdomMoraleFlag"/></param>
    [Generated]
    [Implements(typeof(KingdomMoraleFlagUpdateIncome))]
    public static ActionsBuilder KingdomMoraleFlagUpdateIncome(
        this ActionsBuilder builder,
        string? targetFlag = null)
    {
      var element = ElementTool.Create<KingdomMoraleFlagUpdateIncome>();
      element.m_TargetFlag = BlueprintTool.GetRef<BlueprintKingdomMoraleFlag.Reference>(targetFlag);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomMoraleUpdateIncome"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomMoraleUpdateIncome))]
    public static ActionsBuilder KingdomMoraleUpdateIncome(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomMoraleUpdateIncome>());
    }

    /// <summary>
    /// Adds <see cref="KingdomRemoveMoraleFlags"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="flagsToRemove"><see cref="Kingmaker.Kingdom.Flags.BlueprintKingdomMoraleFlag"/></param>
    [Generated]
    [Implements(typeof(KingdomRemoveMoraleFlags))]
    public static ActionsBuilder KingdomRemoveMoraleFlags(
        this ActionsBuilder builder,
        string[]? flagsToRemove = null)
    {
      var element = ElementTool.Create<KingdomRemoveMoraleFlags>();
      element.m_FlagsToRemove = flagsToRemove.Select(name => BlueprintTool.GetRef<BlueprintKingdomMoraleFlag.Reference>(name)).ToArray();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomSetFlagState"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="targetFlag"><see cref="Kingmaker.Kingdom.Flags.BlueprintKingdomMoraleFlag"/></param>
    [Generated]
    [Implements(typeof(KingdomSetFlagState))]
    public static ActionsBuilder KingdomSetFlagState(
        this ActionsBuilder builder,
        string? targetFlag = null,
        KingdomMoraleFlag.State state = default,
        int maxDays = default)
    {
      var element = ElementTool.Create<KingdomSetFlagState>();
      element.m_TargetFlag = BlueprintTool.GetRef<BlueprintKingdomMoraleFlag.Reference>(targetFlag);
      element.m_State = state;
      element.m_MaxDays = maxDays;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ReduceNegativeMorale"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReduceNegativeMorale))]
    public static ActionsBuilder ReduceNegativeMorale(
        this ActionsBuilder builder,
        int value = default)
    {
      var element = ElementTool.Create<ReduceNegativeMorale>();
      element.m_Value = value;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddGrowthBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddGrowthBonus))]
    public static ActionsBuilder AddGrowthBonus(
        this ActionsBuilder builder,
        int bonus = default)
    {
      var element = ElementTool.Create<AddGrowthBonus>();
      element.Bonus = bonus;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddMercenaryToPool"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unit"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(AddMercenaryToPool))]
    public static ActionsBuilder AddMercenaryToPool(
        this ActionsBuilder builder,
        string? unit = null,
        float weight = default)
    {
      var element = ElementTool.Create<AddMercenaryToPool>();
      element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(unit);
      element.m_Weight = weight;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddTacticalArmyFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="armyUnits"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    /// <param name="features"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddTacticalArmyFeature))]
    public static ActionsBuilder AddTacticalArmyFeature(
        this ActionsBuilder builder,
        MercenariesIncludeOption mercenariesFilter = default,
        bool byTag = default,
        ArmyProperties armyTag = default,
        bool byUnits = default,
        string[]? armyUnits = null,
        string[]? features = null,
        ArmyFaction faction = default)
    {
      var element = ElementTool.Create<AddTacticalArmyFeature>();
      element.m_MercenariesFilter = mercenariesFilter;
      element.m_ByTag = byTag;
      element.m_ArmyTag = armyTag;
      element.m_ByUnits = byUnits;
      element.m_ArmyUnits = armyUnits.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToArray();
      element.m_Features = features.Select(name => BlueprintTool.GetRef<BlueprintFeatureReference>(name)).ToArray();
      element.m_Faction = faction;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangeMercenaryWeight"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unit"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(ChangeMercenaryWeight))]
    public static ActionsBuilder ChangeMercenaryWeight(
        this ActionsBuilder builder,
        string? unit = null,
        float weight = default)
    {
      var element = ElementTool.Create<ChangeMercenaryWeight>();
      element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(unit);
      element.m_Weight = weight;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DecreaseRecruitsGrowth"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unit"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(DecreaseRecruitsGrowth))]
    public static ActionsBuilder DecreaseRecruitsGrowth(
        this ActionsBuilder builder,
        string? unit = null,
        int count = default)
    {
      var element = ElementTool.Create<DecreaseRecruitsGrowth>();
      element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(unit);
      element.Count = count;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DecreaseRecruitsPool"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unit"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(DecreaseRecruitsPool))]
    public static ActionsBuilder DecreaseRecruitsPool(
        this ActionsBuilder builder,
        string? unit = null,
        int count = default)
    {
      var element = ElementTool.Create<DecreaseRecruitsPool>();
      element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(unit);
      element.Count = count;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ExchangeRecruits"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="oldUnit"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    /// <param name="newUnit"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(ExchangeRecruits))]
    public static ActionsBuilder ExchangeRecruits(
        this ActionsBuilder builder,
        int newGrowth = default,
        int oldGrowth = default,
        float convertCoefficient = default,
        string? oldUnit = null,
        string? newUnit = null)
    {
      var element = ElementTool.Create<ExchangeRecruits>();
      element.NewGrowth = newGrowth;
      element.OldGrowth = oldGrowth;
      element.ConvertCoefficient = convertCoefficient;
      element.m_OldUnit = BlueprintTool.GetRef<BlueprintUnitReference>(oldUnit);
      element.m_NewUnit = BlueprintTool.GetRef<BlueprintUnitReference>(newUnit);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IncreaseRecruitsGrowth"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unit"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(IncreaseRecruitsGrowth))]
    public static ActionsBuilder IncreaseRecruitsGrowth(
        this ActionsBuilder builder,
        string? unit = null,
        int count = default)
    {
      var element = ElementTool.Create<IncreaseRecruitsGrowth>();
      element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(unit);
      element.Count = count;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IncreaseRecruitsPool"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unit"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(IncreaseRecruitsPool))]
    public static ActionsBuilder IncreaseRecruitsPool(
        this ActionsBuilder builder,
        string? unit = null,
        int count = default)
    {
      var element = ElementTool.Create<IncreaseRecruitsPool>();
      element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(unit);
      element.Count = count;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveMercenaryFromPool"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unit"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(RemoveMercenaryFromPool))]
    public static ActionsBuilder RemoveMercenaryFromPool(
        this ActionsBuilder builder,
        string? unit = null)
    {
      var element = ElementTool.Create<RemoveMercenaryFromPool>();
      element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(unit);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ReplaceBuildings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="oldBuilding"><see cref="Kingmaker.Kingdom.Settlements.BlueprintSettlementBuilding"/></param>
    /// <param name="newBuilding"><see cref="Kingmaker.Kingdom.Settlements.BlueprintSettlementBuilding"/></param>
    [Generated]
    [Implements(typeof(ReplaceBuildings))]
    public static ActionsBuilder ReplaceBuildings(
        this ActionsBuilder builder,
        string? oldBuilding = null,
        string? newBuilding = null)
    {
      var element = ElementTool.Create<ReplaceBuildings>();
      element.m_OldBuilding = BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(oldBuilding);
      element.m_NewBuilding = BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(newBuilding);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetRecruitPoint"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="point"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    [Implements(typeof(SetRecruitPoint))]
    public static ActionsBuilder SetRecruitPoint(
        this ActionsBuilder builder,
        string? point = null)
    {
      var element = ElementTool.Create<SetRecruitPoint>();
      element.m_Point = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(point);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnlockUnitsGrowth"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unit"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(UnlockUnitsGrowth))]
    public static ActionsBuilder UnlockUnitsGrowth(
        this ActionsBuilder builder,
        string? unit = null)
    {
      var element = ElementTool.Create<UnlockUnitsGrowth>();
      element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(unit);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionGetArtisanGift"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="artisan"><see cref="Kingmaker.Kingdom.Artisans.BlueprintKingdomArtisan"/></param>
    [Generated]
    [Implements(typeof(KingdomActionGetArtisanGift))]
    public static ActionsBuilder KingdomActionGetArtisanGift(
        this ActionsBuilder builder,
        string? artisan = null)
    {
      var element = ElementTool.Create<KingdomActionGetArtisanGift>();
      element.m_Artisan = BlueprintTool.GetRef<BlueprintKingdomArtisanReference>(artisan);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionGetArtisanGiftWithCertainTier"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="artisan"><see cref="Kingmaker.Kingdom.Artisans.BlueprintKingdomArtisan"/></param>
    [Generated]
    [Implements(typeof(KingdomActionGetArtisanGiftWithCertainTier))]
    public static ActionsBuilder KingdomActionGetArtisanGiftWithCertainTier(
        this ActionsBuilder builder,
        string? artisan = null,
        int tier = default)
    {
      var element = ElementTool.Create<KingdomActionGetArtisanGiftWithCertainTier>();
      element.m_Artisan = BlueprintTool.GetRef<BlueprintKingdomArtisanReference>(artisan);
      element.tier = tier;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionGetPartyGoldByUnitsCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionGetPartyGoldByUnitsCount))]
    public static ActionsBuilder KingdomActionGetPartyGoldByUnitsCount(
        this ActionsBuilder builder,
        int goldPerUnit = default,
        float coefficient = default)
    {
      var element = ElementTool.Create<KingdomActionGetPartyGoldByUnitsCount>();
      element.m_GoldPerUnit = goldPerUnit;
      element.m_Coefficient = coefficient;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionGetResourcesByUnitsCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionGetResourcesByUnitsCount))]
    public static ActionsBuilder KingdomActionGetResourcesByUnitsCount(
        this ActionsBuilder builder,
        KingdomResourcesAmount resourcePerUnit,
        float coefficient = default)
    {
      var element = ElementTool.Create<KingdomActionGetResourcesByUnitsCount>();
      element.m_ResourcePerUnit = resourcePerUnit;
      element.m_Coefficient = coefficient;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionGetResourcesPercent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionGetResourcesPercent))]
    public static ActionsBuilder KingdomActionGetResourcesPercent(
        this ActionsBuilder builder,
        float percent = default,
        KingdomResource resourceType = default,
        int maxResourceCountGained = default)
    {
      var element = ElementTool.Create<KingdomActionGetResourcesPercent>();
      element.m_Percent = percent;
      element.m_ResourceType = resourceType;
      element.m_MaxResourceCountGained = maxResourceCountGained;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionGiveLoot"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionGiveLoot))]
    public static ActionsBuilder KingdomActionGiveLoot(
        this ActionsBuilder builder,
        LootEntry[]? loot = null)
    {
      builder.Validate(loot);
    
      var element = ElementTool.Create<KingdomActionGiveLoot>();
      element.Loot = loot;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionImproveSettlement"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="specificSettlement"><see cref="Kingmaker.Kingdom.BlueprintSettlement"/></param>
    [Generated]
    [Implements(typeof(KingdomActionImproveSettlement))]
    public static ActionsBuilder KingdomActionImproveSettlement(
        this ActionsBuilder builder,
        SettlementState.LevelType toLevel = default,
        string? specificSettlement = null)
    {
      var element = ElementTool.Create<KingdomActionImproveSettlement>();
      element.ToLevel = toLevel;
      element.m_SpecificSettlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(specificSettlement);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionImproveStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionImproveStat))]
    public static ActionsBuilder KingdomActionImproveStat(
        this ActionsBuilder builder,
        KingdomStats.Type statType = default)
    {
      var element = ElementTool.Create<KingdomActionImproveStat>();
      element.StatType = statType;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionMakeRoll"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionMakeRoll))]
    public static ActionsBuilder KingdomActionMakeRoll(
        this ActionsBuilder builder,
        KingdomStats.Type stat = default,
        int dC = default,
        ActionsBuilder? onSuccess = null,
        ActionsBuilder? onFailure = null)
    {
      var element = ElementTool.Create<KingdomActionMakeRoll>();
      element.Stat = stat;
      element.DC = dC;
      element.OnSuccess = onSuccess?.Build() ?? Constants.Empty.Actions;
      element.OnFailure = onFailure?.Build() ?? Constants.Empty.Actions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionModifyBuildTime"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionModifyBuildTime))]
    public static ActionsBuilder KingdomActionModifyBuildTime(
        this ActionsBuilder builder,
        float changeTime = default)
    {
      var element = ElementTool.Create<KingdomActionModifyBuildTime>();
      element.ChangeTime = changeTime;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionModifyClaims"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionModifyClaims))]
    public static ActionsBuilder KingdomActionModifyClaims(
        this ActionsBuilder builder,
        float changeTime = default,
        float changeCost = default)
    {
      var element = ElementTool.Create<KingdomActionModifyClaims>();
      element.ChangeTime = changeTime;
      element.ChangeCost = changeCost;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionModifyEventDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionModifyEventDC))]
    public static ActionsBuilder KingdomActionModifyEventDC(
        this ActionsBuilder builder,
        int modifier = default)
    {
      var element = ElementTool.Create<KingdomActionModifyEventDC>();
      element.Modifier = modifier;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionModifyRE"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionModifyRE))]
    public static ActionsBuilder KingdomActionModifyRE(
        this ActionsBuilder builder,
        float unclaimedChange = default,
        float claimedChange = default,
        float upgradedChange = default)
    {
      var element = ElementTool.Create<KingdomActionModifyRE>();
      element.UnclaimedChange = unclaimedChange;
      element.ClaimedChange = claimedChange;
      element.UpgradedChange = upgradedChange;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionModifyRankTime"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionModifyRankTime))]
    public static ActionsBuilder KingdomActionModifyRankTime(
        this ActionsBuilder builder,
        float changeTime = default)
    {
      var element = ElementTool.Create<KingdomActionModifyRankTime>();
      element.ChangeTime = changeTime;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionModifyStatRandom"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionModifyStatRandom))]
    public static ActionsBuilder KingdomActionModifyStatRandom(
        this ActionsBuilder builder,
        DiceFormula change,
        bool includeInEventStats = default)
    {
      var element = ElementTool.Create<KingdomActionModifyStatRandom>();
      element.IncludeInEventStats = includeInEventStats;
      element.Change = change;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionModifyStats"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionModifyStats))]
    public static ActionsBuilder KingdomActionModifyStats(
        this ActionsBuilder builder,
        KingdomStats.Changes changes,
        bool includeInEventStats = default)
    {
      builder.Validate(changes);
    
      var element = ElementTool.Create<KingdomActionModifyStats>();
      element.IncludeInEventStats = includeInEventStats;
      element.Changes = changes;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionModifyUnrest"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionModifyUnrest))]
    public static ActionsBuilder KingdomActionModifyUnrest(
        this ActionsBuilder builder,
        SharedStringAsset reasonString,
        bool makeBetter = default,
        bool bounded = default,
        KingdomStatusChangeReason reason = default,
        KingdomStatusType upTo = default)
    {
      builder.Validate(reasonString);
    
      var element = ElementTool.Create<KingdomActionModifyUnrest>();
      element.MakeBetter = makeBetter;
      element.Bounded = bounded;
      element.Reason = reason;
      element.ReasonString = reasonString;
      element.UpTo = upTo;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionNextChapter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionNextChapter))]
    public static ActionsBuilder KingdomActionNextChapter(
        this ActionsBuilder builder,
        int chapterNumber = default)
    {
      var element = ElementTool.Create<KingdomActionNextChapter>();
      element.ChapterNumber = chapterNumber;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionPullRankupChangesIntoDialog"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionPullRankupChangesIntoDialog))]
    public static ActionsBuilder KingdomActionPullRankupChangesIntoDialog(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionPullRankupChangesIntoDialog>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionRemoveAllLeaders"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionRemoveAllLeaders))]
    public static ActionsBuilder KingdomActionRemoveAllLeaders(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionRemoveAllLeaders>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionRemoveBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blueprint"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomBuff"/></param>
    /// <param name="region"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintRegion"/></param>
    [Generated]
    [Implements(typeof(KingdomActionRemoveBuff))]
    public static ActionsBuilder KingdomActionRemoveBuff(
        this ActionsBuilder builder,
        string? blueprint = null,
        bool applyToRegion = default,
        string? region = null,
        bool allBuffs = default)
    {
      var element = ElementTool.Create<KingdomActionRemoveBuff>();
      element.m_Blueprint = BlueprintTool.GetRef<BlueprintKingdomBuffReference>(blueprint);
      element.ApplyToRegion = applyToRegion;
      element.m_Region = BlueprintTool.GetRef<BlueprintRegionReference>(region);
      element.m_AllBuffs = allBuffs;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionRemoveEvent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="eventBlueprint"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomEventBase"/></param>
    [Generated]
    [Implements(typeof(KingdomActionRemoveEvent))]
    public static ActionsBuilder KingdomActionRemoveEvent(
        this ActionsBuilder builder,
        string? eventBlueprint = null,
        bool cancelIfInProgress = default,
        bool allIfMultiple = default)
    {
      var element = ElementTool.Create<KingdomActionRemoveEvent>();
      element.m_EventBlueprint = BlueprintTool.GetRef<BlueprintKingdomEventBaseReference>(eventBlueprint);
      element.CancelIfInProgress = cancelIfInProgress;
      element.AllIfMultiple = allIfMultiple;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionRemoveEventDeck"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="deck"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomDeck"/></param>
    [Generated]
    [Implements(typeof(KingdomActionRemoveEventDeck))]
    public static ActionsBuilder KingdomActionRemoveEventDeck(
        this ActionsBuilder builder,
        string? deck = null)
    {
      var element = ElementTool.Create<KingdomActionRemoveEventDeck>();
      element.m_Deck = BlueprintTool.GetRef<BlueprintKingdomDeckReference>(deck);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionRequestArtisanGift"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="artisan"><see cref="Kingmaker.Kingdom.Artisans.BlueprintKingdomArtisan"/></param>
    /// <param name="itemType"><see cref="Kingmaker.Kingdom.Artisans.ArtisanItemDeck"/></param>
    [Generated]
    [Implements(typeof(KingdomActionRequestArtisanGift))]
    public static ActionsBuilder KingdomActionRequestArtisanGift(
        this ActionsBuilder builder,
        string? artisan = null,
        string? itemType = null)
    {
      var element = ElementTool.Create<KingdomActionRequestArtisanGift>();
      element.m_Artisan = BlueprintTool.GetRef<BlueprintKingdomArtisanReference>(artisan);
      element.m_ItemType = BlueprintTool.GetRef<ArtisanItemDeckReference>(itemType);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionResetRecurrence"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionResetRecurrence))]
    public static ActionsBuilder KingdomActionResetRecurrence(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionResetRecurrence>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionResolveCrusadeEvent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="eventBlueprint"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintCrusadeEvent"/></param>
    [Generated]
    [Implements(typeof(KingdomActionResolveCrusadeEvent))]
    public static ActionsBuilder KingdomActionResolveCrusadeEvent(
        this ActionsBuilder builder,
        string? eventBlueprint = null,
        int solutionIndex = default)
    {
      var element = ElementTool.Create<KingdomActionResolveCrusadeEvent>();
      element.m_EventBlueprint = BlueprintTool.GetRef<BlueprintCrusadeEvent.Reference>(eventBlueprint);
      element.m_SolutionIndex = solutionIndex;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionResolveEvent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="eventBlueprint"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomEvent"/></param>
    [Generated]
    [Implements(typeof(KingdomActionResolveEvent))]
    public static ActionsBuilder KingdomActionResolveEvent(
        this ActionsBuilder builder,
        string? eventBlueprint = null,
        EventResult.MarginType result = default,
        Alignment alignment = default,
        bool finalResolve = default)
    {
      var element = ElementTool.Create<KingdomActionResolveEvent>();
      element.m_EventBlueprint = BlueprintTool.GetRef<BlueprintKingdomEventReference>(eventBlueprint);
      element.Result = result;
      element.Alignment = alignment;
      element.FinalResolve = finalResolve;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionResolveProject"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="eventBlueprint"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomProject"/></param>
    [Generated]
    [Implements(typeof(KingdomActionResolveProject))]
    public static ActionsBuilder KingdomActionResolveProject(
        this ActionsBuilder builder,
        string? eventBlueprint = null)
    {
      var element = ElementTool.Create<KingdomActionResolveProject>();
      element.m_EventBlueprint = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(eventBlueprint);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionRestartEvent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionRestartEvent))]
    public static ActionsBuilder KingdomActionRestartEvent(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionRestartEvent>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionRollbackRecurrence"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionRollbackRecurrence))]
    public static ActionsBuilder KingdomActionRollbackRecurrence(
        this ActionsBuilder builder,
        KingdomActionRollbackRecurrence.RollbackType type = default,
        int lastNDays = default,
        int lastNTimes = default,
        float resourcesRatio = default,
        bool includeResources = default,
        bool includeResourcesPerTurn = default,
        bool includeStats = default)
    {
      var element = ElementTool.Create<KingdomActionRollbackRecurrence>();
      element.m_Type = type;
      element.m_LastNDays = lastNDays;
      element.m_LastNTimes = lastNTimes;
      element.m_ResourcesRatio = resourcesRatio;
      element.m_IncludeResources = includeResources;
      element.m_IncludeResourcesPerTurn = includeResourcesPerTurn;
      element.m_IncludeStats = includeStats;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionSetAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionSetAlignment))]
    public static ActionsBuilder KingdomActionSetAlignment(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionSetAlignment>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionSetNotVisible"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionSetNotVisible))]
    public static ActionsBuilder KingdomActionSetNotVisible(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionSetNotVisible>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionSetRegionalIncome"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionSetRegionalIncome))]
    public static ActionsBuilder KingdomActionSetRegionalIncome(
        this ActionsBuilder builder,
        KingdomResourcesAmount incomePerClaimed,
        KingdomResourcesAmount incomePerUpgraded,
        bool add = default)
    {
      var element = ElementTool.Create<KingdomActionSetRegionalIncome>();
      element.IncomePerClaimed = incomePerClaimed;
      element.IncomePerUpgraded = incomePerUpgraded;
      element.Add = add;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionSetVisible"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomActionSetVisible))]
    public static ActionsBuilder KingdomActionSetVisible(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionSetVisible>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionSpawnRandomArmy"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="armies"><see cref="Kingmaker.Armies.Blueprints.BlueprintArmyPreset"/></param>
    /// <param name="locations"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    [Implements(typeof(KingdomActionSpawnRandomArmy))]
    public static ActionsBuilder KingdomActionSpawnRandomArmy(
        this ActionsBuilder builder,
        string[]? armies = null,
        ArmyFaction faction = default,
        string[]? locations = null)
    {
      var element = ElementTool.Create<KingdomActionSpawnRandomArmy>();
      element.m_Armies = armies.Select(name => BlueprintTool.GetRef<BlueprintArmyPresetReference>(name)).ToList();
      element.m_Faction = faction;
      element.m_Locations = locations.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(name)).ToList();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionStartEvent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="eventValue"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomEventBase"/></param>
    /// <param name="region"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintRegion"/></param>
    [Generated]
    [Implements(typeof(KingdomActionStartEvent))]
    public static ActionsBuilder KingdomActionStartEvent(
        this ActionsBuilder builder,
        string? eventValue = null,
        string? region = null,
        bool randomRegion = default,
        int delayDays = default,
        bool startNextMonth = default,
        bool checkTriggerImmediately = default,
        bool checkTriggerOnStart = default)
    {
      var element = ElementTool.Create<KingdomActionStartEvent>();
      element.m_Event = BlueprintTool.GetRef<BlueprintKingdomEventBaseReference>(eventValue);
      element.m_Region = BlueprintTool.GetRef<BlueprintRegionReference>(region);
      element.RandomRegion = randomRegion;
      element.DelayDays = delayDays;
      element.StartNextMonth = startNextMonth;
      element.CheckTriggerImmediately = checkTriggerImmediately;
      element.CheckTriggerOnStart = checkTriggerOnStart;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionUnlockArtisan"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="artisan"><see cref="Kingmaker.Kingdom.Artisans.BlueprintKingdomArtisan"/></param>
    [Generated]
    [Implements(typeof(KingdomActionUnlockArtisan))]
    public static ActionsBuilder KingdomActionUnlockArtisan(
        this ActionsBuilder builder,
        string? artisan = null)
    {
      var element = ElementTool.Create<KingdomActionUnlockArtisan>();
      element.m_Artisan = BlueprintTool.GetRef<BlueprintKingdomArtisanReference>(artisan);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveCrusadeResources"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveCrusadeResources))]
    public static ActionsBuilder RemoveCrusadeResources(
        this ActionsBuilder builder,
        KingdomResourcesAmount resourcesAmount)
    {
      var element = ElementTool.Create<RemoveCrusadeResources>();
      element.m_ResourcesAmount = resourcesAmount;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="BlockTacticalCell"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BlockTacticalCell))]
    public static ActionsBuilder BlockTacticalCell(
        this ActionsBuilder builder,
        TacticalMapObstacle.Link obstaclePrefab)
    {
      builder.Validate(obstaclePrefab);
    
      var element = ElementTool.Create<BlockTacticalCell>();
      element.m_ObstaclePrefab = obstaclePrefab;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatRecoverLeaderMana"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCombatRecoverLeaderMana))]
    public static ActionsBuilder TacticalCombatRecoverLeaderMana(
        this ActionsBuilder builder,
        ContextValue? value = null)
    {
      builder.Validate(value);
    
      var element = ElementTool.Create<TacticalCombatRecoverLeaderMana>();
      element.m_Value = value ?? ContextValues.Constant(0);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CreateArmyFromLosses"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="location"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    [Implements(typeof(CreateArmyFromLosses))]
    public static ActionsBuilder CreateArmyFromLosses(
        this ActionsBuilder builder,
        int sumExperience = default,
        int squadsMaxCount = default,
        string? location = null,
        bool applyRecruitIncrease = default)
    {
      var element = ElementTool.Create<CreateArmyFromLosses>();
      element.m_SumExperience = sumExperience;
      element.m_SquadsMaxCount = squadsMaxCount;
      element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(location);
      element.m_ApplyRecruitIncrease = applyRecruitIncrease;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="EnterKingdomInterface"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="returnPoint"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    [Generated]
    [Implements(typeof(EnterKingdomInterface))]
    public static ActionsBuilder EnterKingdomInterface(
        this ActionsBuilder builder,
        string? returnPoint = null,
        ActionsBuilder? triggerAfterAuto = null)
    {
      var element = ElementTool.Create<EnterKingdomInterface>();
      element.m_ReturnPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(returnPoint);
      element.TriggerAfterAuto = triggerAfterAuto?.Build() ?? Constants.Empty.Actions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RecruiteArmyLeader"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="armyLeader"><see cref="Kingmaker.Armies.BlueprintArmyLeader"/></param>
    [Generated]
    [Implements(typeof(RecruiteArmyLeader))]
    public static ActionsBuilder RecruiteArmyLeader(
        this ActionsBuilder builder,
        string? armyLeader = null)
    {
      var element = ElementTool.Create<RecruiteArmyLeader>();
      element.ArmyLeader = BlueprintTool.GetRef<ArmyLeader.Reference>(armyLeader);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveDemonArmies"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="armyPreset"><see cref="Kingmaker.Armies.Blueprints.BlueprintArmyPreset"/></param>
    [Generated]
    [Implements(typeof(RemoveDemonArmies))]
    public static ActionsBuilder RemoveDemonArmies(
        this ActionsBuilder builder,
        string? armyPreset = null,
        ArmyType armyType = default)
    {
      var element = ElementTool.Create<RemoveDemonArmies>();
      element.m_ArmyPreset = BlueprintTool.GetRef<BlueprintArmyPresetReference>(armyPreset);
      element.m_ArmyType = armyType;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveGarrison"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="location"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    [Implements(typeof(RemoveGarrison))]
    public static ActionsBuilder RemoveGarrison(
        this ActionsBuilder builder,
        string? location = null,
        bool handleAsGarrisonDefeated = default)
    {
      var element = ElementTool.Create<RemoveGarrison>();
      element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(location);
      element.HandleAsGarrisonDefeated = handleAsGarrisonDefeated;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveUnitFromArmy"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unitToRemove"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(RemoveUnitFromArmy))]
    public static ActionsBuilder RemoveUnitFromArmy(
        this ActionsBuilder builder,
        ArmiesEvaluator armies,
        RemoveUnitFromArmy.RemoveUnitFromArmyMode mode = default,
        bool removeCheapestUnit = default,
        bool removeSpecificUnit = default,
        string? unitToRemove = null,
        bool limitUnitExperienceMinimum = default,
        int unitExperienceMinimum = default,
        bool limitUnitExperienceMaximum = default,
        int unitExperienceMaximum = default,
        UnitTag[]? unitTagWhitelist = null,
        UnitTag[]? unitTagBlacklist = null,
        int experience = default,
        float percentage = default)
    {
      builder.Validate(armies);
    
      var element = ElementTool.Create<RemoveUnitFromArmy>();
      element.m_Armies = armies;
      element.m_Mode = mode;
      element.m_RemoveCheapestUnit = removeCheapestUnit;
      element.m_RemoveSpecificUnit = removeSpecificUnit;
      element.m_UnitToRemove = BlueprintTool.GetRef<BlueprintUnitReference>(unitToRemove);
      element.m_LimitUnitExperienceMinimum = limitUnitExperienceMinimum;
      element.m_UnitExperienceMinimum = unitExperienceMinimum;
      element.m_LimitUnitExperienceMaximum = limitUnitExperienceMaximum;
      element.m_UnitExperienceMaximum = unitExperienceMaximum;
      element.m_UnitTagWhitelist = unitTagWhitelist;
      element.m_UnitTagBlacklist = unitTagBlacklist;
      element.m_Experience = experience;
      element.m_Percentage = percentage;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetWarCampLocation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="location"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    [Implements(typeof(SetWarCampLocation))]
    public static ActionsBuilder SetWarCampLocation(
        this ActionsBuilder builder,
        string? location = null)
    {
      var element = ElementTool.Create<SetWarCampLocation>();
      element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(location);
      return builder.Add(element);
    }
  }
}

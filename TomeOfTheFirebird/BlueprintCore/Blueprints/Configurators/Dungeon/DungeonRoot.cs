using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.View.Roaming;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Configurator for <see cref="BlueprintDungeonRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintDungeonRoot))]
  public class DungeonRootConfigurator : BaseBlueprintConfigurator<BlueprintDungeonRoot, DungeonRootConfigurator>
  {
    private DungeonRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DungeonRootConfigurator For(string name)
    {
      return new DungeonRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DungeonRootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintDungeonRoot>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.DebugOutput"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetDebugOutput(BlueprintDungeonRoot.DebugOutputSettings debugOutput)
    {
      ValidateParam(debugOutput);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.DebugOutput = debugOutput;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.Test"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetTest(BlueprintDungeonRoot.TestSettings test)
    {
      ValidateParam(test);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Test = test;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_Localization"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="localization"><see cref="Kingmaker.Dungeon.Blueprints.BlueprintDungeonLocalizedStrings"/></param>
    [Generated]
    public DungeonRootConfigurator SetLocalization(string? localization)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Localization = BlueprintTool.GetRef<BlueprintDungeonLocalizedStringsReference>(localization);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_NewGamePreset"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="newGamePreset"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPreset"/></param>
    [Generated]
    public DungeonRootConfigurator SetNewGamePreset(string? newGamePreset)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_NewGamePreset = BlueprintTool.GetRef<BlueprintAreaPresetReference>(newGamePreset);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.BoonsPoolSize"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetBoonsPoolSize(int boonsPoolSize)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BoonsPoolSize = boonsPoolSize;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.QuestItemPerStageChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetQuestItemPerStageChance(int questItemPerStageChance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.QuestItemPerStageChance = questItemPerStageChance;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_UnitsWithQuestItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unitsWithQuestItems"><see cref="Kingmaker.Blueprints.BlueprintSummonPool"/></param>
    [Generated]
    public DungeonRootConfigurator SetUnitsWithQuestItems(string? unitsWithQuestItems)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_UnitsWithQuestItems = BlueprintTool.GetRef<BlueprintSummonPoolReference>(unitsWithQuestItems);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_MainVendorTable"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="mainVendorTable"><see cref="Kingmaker.Blueprints.Items.BlueprintSharedVendorTable"/></param>
    [Generated]
    public DungeonRootConfigurator SetMainVendorTable(string? mainVendorTable)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MainVendorTable = BlueprintTool.GetRef<BlueprintSharedVendorTableReference>(mainVendorTable);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_DivineVendorTable"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="divineVendorTable"><see cref="Kingmaker.Blueprints.Items.BlueprintSharedVendorTable"/></param>
    [Generated]
    public DungeonRootConfigurator SetDivineVendorTable(string? divineVendorTable)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DivineVendorTable = BlueprintTool.GetRef<BlueprintSharedVendorTableReference>(divineVendorTable);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_CorruptedFighterClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="corruptedFighterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    public DungeonRootConfigurator SetCorruptedFighterClass(string? corruptedFighterClass)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CorruptedFighterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(corruptedFighterClass);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_CorruptedArcherClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="corruptedArcherClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    public DungeonRootConfigurator SetCorruptedArcherClass(string? corruptedArcherClass)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CorruptedArcherClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(corruptedArcherClass);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_CorruptedCasterClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="corruptedCasterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    public DungeonRootConfigurator SetCorruptedCasterClass(string? corruptedCasterClass)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CorruptedCasterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(corruptedCasterClass);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.StartSetting"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetStartSetting(DungeonStageSetting startSetting)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StartSetting = startSetting;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.FirstChangeSettingStage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetFirstChangeSettingStage(int firstChangeSettingStage)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FirstChangeSettingStage = firstChangeSettingStage;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.ChangeSettingFrequency"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetChangeSettingFrequency(int changeSettingFrequency)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ChangeSettingFrequency = changeSettingFrequency;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.RoomsPerStage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetRoomsPerStage(int roomsPerStage)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RoomsPerStage = roomsPerStage;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.EmptyRoomsPerStage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetEmptyRoomsPerStage(int emptyRoomsPerStage)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.EmptyRoomsPerStage = emptyRoomsPerStage;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.FirstBossStage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetFirstBossStage(int firstBossStage)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FirstBossStage = firstBossStage;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.BossFrequency"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetBossFrequency(int bossFrequency)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BossFrequency = bossFrequency;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.FirstMiniBossStage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetFirstMiniBossStage(int firstMiniBossStage)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FirstMiniBossStage = firstMiniBossStage;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.MiniBossFrequency"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetMiniBossFrequency(int miniBossFrequency)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MiniBossFrequency = miniBossFrequency;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.HardEncountersPerStage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetHardEncountersPerStage(int hardEncountersPerStage)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HardEncountersPerStage = hardEncountersPerStage;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.AdditionalHardEncounterChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetAdditionalHardEncounterChance(int additionalHardEncounterChance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AdditionalHardEncounterChance = additionalHardEncounterChance;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.ApplyThemeChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetApplyThemeChance(int applyThemeChance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ApplyThemeChance = applyThemeChance;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.AdditionalShrineChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetAdditionalShrineChance(int additionalShrineChance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AdditionalShrineChance = additionalShrineChance;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.AdditionalLockedChestChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetAdditionalLockedChestChance(int additionalLockedChestChance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AdditionalLockedChestChance = additionalLockedChestChance;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.SecretEncounterChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetSecretEncounterChance(int secretEncounterChance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SecretEncounterChance = secretEncounterChance;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.FinalBossPortalChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetFinalBossPortalChance(int finalBossPortalChance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FinalBossPortalChance = finalBossPortalChance;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.FirstIncreaseCRStage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetFirstIncreaseCRStage(int firstIncreaseCRStage)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FirstIncreaseCRStage = firstIncreaseCRStage;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.IncreaseCRFrequency"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetIncreaseCRFrequency(int increaseCRFrequency)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IncreaseCRFrequency = increaseCRFrequency;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.BossCRBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetBossCRBonus(int bossCRBonus)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BossCRBonus = bossCRBonus;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.MiniBossCRBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetMiniBossCRBonus(int miniBossCRBonus)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MiniBossCRBonus = miniBossCRBonus;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.HardEncounterCRBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetHardEncounterCRBonus(int hardEncounterCRBonus)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HardEncounterCRBonus = hardEncounterCRBonus;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.RoomCRBonuses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetRoomCRBonuses(int[]? roomCRBonuses)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RoomCRBonuses = roomCRBonuses;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonRoot.RoomCRBonuses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToRoomCRBonuses(params int[] roomCRBonuses)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RoomCRBonuses = CommonTool.Append(bp.RoomCRBonuses, roomCRBonuses ?? new int[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonRoot.RoomCRBonuses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromRoomCRBonuses(params int[] roomCRBonuses)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RoomCRBonuses = bp.RoomCRBonuses.Where(item => !roomCRBonuses.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.EveryRoomCRBonuses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetEveryRoomCRBonuses(BlueprintDungeonRoot.StageCRBonus[]? everyRoomCRBonuses)
    {
      ValidateParam(everyRoomCRBonuses);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.EveryRoomCRBonuses = everyRoomCRBonuses;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonRoot.EveryRoomCRBonuses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToEveryRoomCRBonuses(params BlueprintDungeonRoot.StageCRBonus[] everyRoomCRBonuses)
    {
      ValidateParam(everyRoomCRBonuses);
      return OnConfigureInternal(
          bp =>
          {
            bp.EveryRoomCRBonuses = CommonTool.Append(bp.EveryRoomCRBonuses, everyRoomCRBonuses ?? new BlueprintDungeonRoot.StageCRBonus[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonRoot.EveryRoomCRBonuses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromEveryRoomCRBonuses(params BlueprintDungeonRoot.StageCRBonus[] everyRoomCRBonuses)
    {
      ValidateParam(everyRoomCRBonuses);
      return OnConfigureInternal(
          bp =>
          {
            bp.EveryRoomCRBonuses = bp.EveryRoomCRBonuses.Where(item => !everyRoomCRBonuses.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.CorruptedUnitChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetCorruptedUnitChance(int corruptedUnitChance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CorruptedUnitChance = corruptedUnitChance;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.UnitsCountInPack"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetUnitsCountInPack(BlueprintDungeonRoot.UnitsPerPack[]? unitsCountInPack)
    {
      ValidateParam(unitsCountInPack);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.UnitsCountInPack = unitsCountInPack;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonRoot.UnitsCountInPack"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToUnitsCountInPack(params BlueprintDungeonRoot.UnitsPerPack[] unitsCountInPack)
    {
      ValidateParam(unitsCountInPack);
      return OnConfigureInternal(
          bp =>
          {
            bp.UnitsCountInPack = CommonTool.Append(bp.UnitsCountInPack, unitsCountInPack ?? new BlueprintDungeonRoot.UnitsPerPack[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonRoot.UnitsCountInPack"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromUnitsCountInPack(params BlueprintDungeonRoot.UnitsPerPack[] unitsCountInPack)
    {
      ValidateParam(unitsCountInPack);
      return OnConfigureInternal(
          bp =>
          {
            bp.UnitsCountInPack = bp.UnitsCountInPack.Where(item => !unitsCountInPack.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.UnitsCountInBossPack"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetUnitsCountInBossPack(BlueprintDungeonRoot.UnitsPerPack[]? unitsCountInBossPack)
    {
      ValidateParam(unitsCountInBossPack);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.UnitsCountInBossPack = unitsCountInBossPack;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonRoot.UnitsCountInBossPack"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToUnitsCountInBossPack(params BlueprintDungeonRoot.UnitsPerPack[] unitsCountInBossPack)
    {
      ValidateParam(unitsCountInBossPack);
      return OnConfigureInternal(
          bp =>
          {
            bp.UnitsCountInBossPack = CommonTool.Append(bp.UnitsCountInBossPack, unitsCountInBossPack ?? new BlueprintDungeonRoot.UnitsPerPack[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonRoot.UnitsCountInBossPack"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromUnitsCountInBossPack(params BlueprintDungeonRoot.UnitsPerPack[] unitsCountInBossPack)
    {
      ValidateParam(unitsCountInBossPack);
      return OnConfigureInternal(
          bp =>
          {
            bp.UnitsCountInBossPack = bp.UnitsCountInBossPack.Where(item => !unitsCountInBossPack.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.PacksCountInRoom"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetPacksCountInRoom(BlueprintDungeonRoot.ValueWithWeight[]? packsCountInRoom)
    {
      ValidateParam(packsCountInRoom);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.PacksCountInRoom = packsCountInRoom;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonRoot.PacksCountInRoom"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToPacksCountInRoom(params BlueprintDungeonRoot.ValueWithWeight[] packsCountInRoom)
    {
      ValidateParam(packsCountInRoom);
      return OnConfigureInternal(
          bp =>
          {
            bp.PacksCountInRoom = CommonTool.Append(bp.PacksCountInRoom, packsCountInRoom ?? new BlueprintDungeonRoot.ValueWithWeight[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonRoot.PacksCountInRoom"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromPacksCountInRoom(params BlueprintDungeonRoot.ValueWithWeight[] packsCountInRoom)
    {
      ValidateParam(packsCountInRoom);
      return OnConfigureInternal(
          bp =>
          {
            bp.PacksCountInRoom = bp.PacksCountInRoom.Where(item => !packsCountInRoom.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.PacksCountInBossRoom"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetPacksCountInBossRoom(BlueprintDungeonRoot.ValueWithWeight[]? packsCountInBossRoom)
    {
      ValidateParam(packsCountInBossRoom);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.PacksCountInBossRoom = packsCountInBossRoom;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonRoot.PacksCountInBossRoom"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToPacksCountInBossRoom(params BlueprintDungeonRoot.ValueWithWeight[] packsCountInBossRoom)
    {
      ValidateParam(packsCountInBossRoom);
      return OnConfigureInternal(
          bp =>
          {
            bp.PacksCountInBossRoom = CommonTool.Append(bp.PacksCountInBossRoom, packsCountInBossRoom ?? new BlueprintDungeonRoot.ValueWithWeight[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonRoot.PacksCountInBossRoom"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromPacksCountInBossRoom(params BlueprintDungeonRoot.ValueWithWeight[] packsCountInBossRoom)
    {
      ValidateParam(packsCountInBossRoom);
      return OnConfigureInternal(
          bp =>
          {
            bp.PacksCountInBossRoom = bp.PacksCountInBossRoom.Where(item => !packsCountInBossRoom.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.Armies"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetArmies(DungeonArmySettings[]? armies)
    {
      ValidateParam(armies);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Armies = armies;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonRoot.Armies"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToArmies(params DungeonArmySettings[] armies)
    {
      ValidateParam(armies);
      return OnConfigureInternal(
          bp =>
          {
            bp.Armies = CommonTool.Append(bp.Armies, armies ?? new DungeonArmySettings[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonRoot.Armies"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromArmies(params DungeonArmySettings[] armies)
    {
      ValidateParam(armies);
      return OnConfigureInternal(
          bp =>
          {
            bp.Armies = bp.Armies.Where(item => !armies.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.Roaming"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetRoaming(RoamingUnitSettings roaming)
    {
      ValidateParam(roaming);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Roaming = roaming;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.CustomBosses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetCustomBosses(BlueprintDungeonRoot.CustomBossSettings[]? customBosses)
    {
      ValidateParam(customBosses);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.CustomBosses = customBosses;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonRoot.CustomBosses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToCustomBosses(params BlueprintDungeonRoot.CustomBossSettings[] customBosses)
    {
      ValidateParam(customBosses);
      return OnConfigureInternal(
          bp =>
          {
            bp.CustomBosses = CommonTool.Append(bp.CustomBosses, customBosses ?? new BlueprintDungeonRoot.CustomBossSettings[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonRoot.CustomBosses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromCustomBosses(params BlueprintDungeonRoot.CustomBossSettings[] customBosses)
    {
      ValidateParam(customBosses);
      return OnConfigureInternal(
          bp =>
          {
            bp.CustomBosses = bp.CustomBosses.Where(item => !customBosses.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_StageUnits"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="stageUnits"><see cref="Kingmaker.Blueprints.BlueprintSummonPool"/></param>
    [Generated]
    public DungeonRootConfigurator SetStageUnits(string? stageUnits)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_StageUnits = BlueprintTool.GetRef<BlueprintSummonPoolReference>(stageUnits);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.LootTableSmall"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetLootTableSmall(BlueprintDungeonRoot.LootTypeWeight[]? lootTableSmall)
    {
      ValidateParam(lootTableSmall);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LootTableSmall = lootTableSmall;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonRoot.LootTableSmall"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToLootTableSmall(params BlueprintDungeonRoot.LootTypeWeight[] lootTableSmall)
    {
      ValidateParam(lootTableSmall);
      return OnConfigureInternal(
          bp =>
          {
            bp.LootTableSmall = CommonTool.Append(bp.LootTableSmall, lootTableSmall ?? new BlueprintDungeonRoot.LootTypeWeight[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonRoot.LootTableSmall"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromLootTableSmall(params BlueprintDungeonRoot.LootTypeWeight[] lootTableSmall)
    {
      ValidateParam(lootTableSmall);
      return OnConfigureInternal(
          bp =>
          {
            bp.LootTableSmall = bp.LootTableSmall.Where(item => !lootTableSmall.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.LootTableBig"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetLootTableBig(BlueprintDungeonRoot.LootTypeWeight[]? lootTableBig)
    {
      ValidateParam(lootTableBig);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LootTableBig = lootTableBig;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonRoot.LootTableBig"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToLootTableBig(params BlueprintDungeonRoot.LootTypeWeight[] lootTableBig)
    {
      ValidateParam(lootTableBig);
      return OnConfigureInternal(
          bp =>
          {
            bp.LootTableBig = CommonTool.Append(bp.LootTableBig, lootTableBig ?? new BlueprintDungeonRoot.LootTypeWeight[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonRoot.LootTableBig"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromLootTableBig(params BlueprintDungeonRoot.LootTypeWeight[] lootTableBig)
    {
      ValidateParam(lootTableBig);
      return OnConfigureInternal(
          bp =>
          {
            bp.LootTableBig = bp.LootTableBig.Where(item => !lootTableBig.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.LootCRBonuses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetLootCRBonuses(BlueprintDungeonRoot.ValueWithWeight[]? lootCRBonuses)
    {
      ValidateParam(lootCRBonuses);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LootCRBonuses = lootCRBonuses;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonRoot.LootCRBonuses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToLootCRBonuses(params BlueprintDungeonRoot.ValueWithWeight[] lootCRBonuses)
    {
      ValidateParam(lootCRBonuses);
      return OnConfigureInternal(
          bp =>
          {
            bp.LootCRBonuses = CommonTool.Append(bp.LootCRBonuses, lootCRBonuses ?? new BlueprintDungeonRoot.ValueWithWeight[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonRoot.LootCRBonuses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromLootCRBonuses(params BlueprintDungeonRoot.ValueWithWeight[] lootCRBonuses)
    {
      ValidateParam(lootCRBonuses);
      return OnConfigureInternal(
          bp =>
          {
            bp.LootCRBonuses = bp.LootCRBonuses.Where(item => !lootCRBonuses.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.Loot"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetLoot(DungeonLootRoot loot)
    {
      ValidateParam(loot);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Loot = loot;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.Items"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetItems(BlueprintDungeonRoot.ItemsList[]? items)
    {
      ValidateParam(items);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Items = items;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonRoot.Items"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToItems(params BlueprintDungeonRoot.ItemsList[] items)
    {
      ValidateParam(items);
      return OnConfigureInternal(
          bp =>
          {
            bp.Items = CommonTool.Append(bp.Items, items ?? new BlueprintDungeonRoot.ItemsList[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonRoot.Items"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromItems(params BlueprintDungeonRoot.ItemsList[] items)
    {
      ValidateParam(items);
      return OnConfigureInternal(
          bp =>
          {
            bp.Items = bp.Items.Where(item => !items.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_Essentials"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="essentials"><see cref="Kingmaker.Blueprints.Items.Equipment.BlueprintItemEquipment"/></param>
    [Generated]
    public DungeonRootConfigurator SetEssentials(string[]? essentials)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Essentials = essentials.Select(name => BlueprintTool.GetRef<BlueprintItemEquipmentReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonRoot.m_Essentials"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="essentials"><see cref="Kingmaker.Blueprints.Items.Equipment.BlueprintItemEquipment"/></param>
    [Generated]
    public DungeonRootConfigurator AddToEssentials(params string[] essentials)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Essentials = CommonTool.Append(bp.m_Essentials, essentials.Select(name => BlueprintTool.GetRef<BlueprintItemEquipmentReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonRoot.m_Essentials"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="essentials"><see cref="Kingmaker.Blueprints.Items.Equipment.BlueprintItemEquipment"/></param>
    [Generated]
    public DungeonRootConfigurator RemoveFromEssentials(params string[] essentials)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = essentials.Select(name => BlueprintTool.GetRef<BlueprintItemEquipmentReference>(name));
            bp.m_Essentials =
                bp.m_Essentials
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_PackSpawnLoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="packSpawnLoot"><see cref="Kingmaker.Dungeon.Blueprints.BlueprintGenericPackLoot"/></param>
    [Generated]
    public DungeonRootConfigurator SetPackSpawnLoot(string? packSpawnLoot)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_PackSpawnLoot = BlueprintTool.GetRef<BlueprintGenericPackLootReference>(packSpawnLoot);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.TrapDisabledEvent"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetTrapDisabledEvent(string trapDisabledEvent)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TrapDisabledEvent = trapDisabledEvent;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.TrapDisableFailedEvent"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetTrapDisableFailedEvent(string trapDisableFailedEvent)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TrapDisableFailedEvent = trapDisableFailedEvent;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.TrapInteractionStartedEvent"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetTrapInteractionStartedEvent(string trapInteractionStartedEvent)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TrapInteractionStartedEvent = trapInteractionStartedEvent;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.TrapInteractionEndedEvent"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetTrapInteractionEndedEvent(string trapInteractionEndedEvent)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TrapInteractionEndedEvent = trapInteractionEndedEvent;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_FinalBossPortal"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="finalBossPortal"><see cref="Kingmaker.RandomEncounters.Settings.BlueprintSpawnableObject"/></param>
    [Generated]
    public DungeonRootConfigurator SetFinalBossPortal(string? finalBossPortal)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_FinalBossPortal = BlueprintTool.GetRef<BlueprintDungeonSpawnableReference>(finalBossPortal);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.SpecialObjects"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetSpecialObjects(BlueprintDungeonRoot.SpecialObjectsList[]? specialObjects)
    {
      ValidateParam(specialObjects);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.SpecialObjects = specialObjects;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonRoot.SpecialObjects"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToSpecialObjects(params BlueprintDungeonRoot.SpecialObjectsList[] specialObjects)
    {
      ValidateParam(specialObjects);
      return OnConfigureInternal(
          bp =>
          {
            bp.SpecialObjects = CommonTool.Append(bp.SpecialObjects, specialObjects ?? new BlueprintDungeonRoot.SpecialObjectsList[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonRoot.SpecialObjects"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromSpecialObjects(params BlueprintDungeonRoot.SpecialObjectsList[] specialObjects)
    {
      ValidateParam(specialObjects);
      return OnConfigureInternal(
          bp =>
          {
            bp.SpecialObjects = bp.SpecialObjects.Where(item => !specialObjects.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_Boons"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="boons"><see cref="Kingmaker.Dungeon.Blueprints.BlueprintDungeonBoon"/></param>
    [Generated]
    public DungeonRootConfigurator SetBoons(string[]? boons)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Boons = boons.Select(name => BlueprintTool.GetRef<BlueprintDungeonBoonReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonRoot.m_Boons"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="boons"><see cref="Kingmaker.Dungeon.Blueprints.BlueprintDungeonBoon"/></param>
    [Generated]
    public DungeonRootConfigurator AddToBoons(params string[] boons)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Boons = CommonTool.Append(bp.m_Boons, boons.Select(name => BlueprintTool.GetRef<BlueprintDungeonBoonReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonRoot.m_Boons"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="boons"><see cref="Kingmaker.Dungeon.Blueprints.BlueprintDungeonBoon"/></param>
    [Generated]
    public DungeonRootConfigurator RemoveFromBoons(params string[] boons)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = boons.Select(name => BlueprintTool.GetRef<BlueprintDungeonBoonReference>(name));
            bp.m_Boons =
                bp.m_Boons
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.ThemeBuffs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetThemeBuffs(BlueprintDungeonRoot.ThemeBuffSettings[]? themeBuffs)
    {
      ValidateParam(themeBuffs);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ThemeBuffs = themeBuffs;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonRoot.ThemeBuffs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToThemeBuffs(params BlueprintDungeonRoot.ThemeBuffSettings[] themeBuffs)
    {
      ValidateParam(themeBuffs);
      return OnConfigureInternal(
          bp =>
          {
            bp.ThemeBuffs = CommonTool.Append(bp.ThemeBuffs, themeBuffs ?? new BlueprintDungeonRoot.ThemeBuffSettings[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonRoot.ThemeBuffs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromThemeBuffs(params BlueprintDungeonRoot.ThemeBuffSettings[] themeBuffs)
    {
      ValidateParam(themeBuffs);
      return OnConfigureInternal(
          bp =>
          {
            bp.ThemeBuffs = bp.ThemeBuffs.Where(item => !themeBuffs.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.ThemeAudioScenes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetThemeAudioScenes(BlueprintDungeonRoot.ThemeAudioSettings[]? themeAudioScenes)
    {
      ValidateParam(themeAudioScenes);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ThemeAudioScenes = themeAudioScenes;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonRoot.ThemeAudioScenes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToThemeAudioScenes(params BlueprintDungeonRoot.ThemeAudioSettings[] themeAudioScenes)
    {
      ValidateParam(themeAudioScenes);
      return OnConfigureInternal(
          bp =>
          {
            bp.ThemeAudioScenes = CommonTool.Append(bp.ThemeAudioScenes, themeAudioScenes ?? new BlueprintDungeonRoot.ThemeAudioSettings[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonRoot.ThemeAudioScenes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromThemeAudioScenes(params BlueprintDungeonRoot.ThemeAudioSettings[] themeAudioScenes)
    {
      ValidateParam(themeAudioScenes);
      return OnConfigureInternal(
          bp =>
          {
            bp.ThemeAudioScenes = bp.ThemeAudioScenes.Where(item => !themeAudioScenes.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_TrapActor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="trapActor"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public DungeonRootConfigurator SetTrapActor(string? trapActor)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TrapActor = BlueprintTool.GetRef<BlueprintUnitReference>(trapActor);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.Traps"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetTraps(BlueprintDungeonRoot.TrapAndMinStage[]? traps)
    {
      ValidateParam(traps);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Traps = traps;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonRoot.Traps"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator AddToTraps(params BlueprintDungeonRoot.TrapAndMinStage[] traps)
    {
      ValidateParam(traps);
      return OnConfigureInternal(
          bp =>
          {
            bp.Traps = CommonTool.Append(bp.Traps, traps ?? new BlueprintDungeonRoot.TrapAndMinStage[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonRoot.Traps"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator RemoveFromTraps(params BlueprintDungeonRoot.TrapAndMinStage[] traps)
    {
      ValidateParam(traps);
      return OnConfigureInternal(
          bp =>
          {
            bp.Traps = bp.Traps.Where(item => !traps.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.ExperienceRewardForCompleteStageStart"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetExperienceRewardForCompleteStageStart(int experienceRewardForCompleteStageStart)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ExperienceRewardForCompleteStageStart = experienceRewardForCompleteStageStart;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.ExperienceRewardForCompleteStageStep"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonRootConfigurator SetExperienceRewardForCompleteStageStep(int experienceRewardForCompleteStageStep)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ExperienceRewardForCompleteStageStep = experienceRewardForCompleteStageStep;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonRoot.m_EnterPoints"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enterPoints"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    [Generated]
    public DungeonRootConfigurator SetEnterPoints(string[]? enterPoints)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_EnterPoints = enterPoints.Select(name => BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonRoot.m_EnterPoints"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enterPoints"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    [Generated]
    public DungeonRootConfigurator AddToEnterPoints(params string[] enterPoints)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_EnterPoints = CommonTool.Append(bp.m_EnterPoints, enterPoints.Select(name => BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonRoot.m_EnterPoints"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enterPoints"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    [Generated]
    public DungeonRootConfigurator RemoveFromEnterPoints(params string[] enterPoints)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = enterPoints.Select(name => BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(name));
            bp.m_EnterPoints =
                bp.m_EnterPoints
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}

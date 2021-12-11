using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Armies.TacticalCombat.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;
using Kingmaker.Corruption;
using Kingmaker.Craft;
using Kingmaker.Interaction;
using Kingmaker.RazerChroma;
using Kingmaker.ResourceLinks;
using Kingmaker.Settings;
using Kingmaker.Settings.Difficulty;
using Kingmaker.UI.SettingsUI;
using Kingmaker.Visual.Animation;
using Kingmaker.Visual.Sound;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>
  /// Configurator for <see cref="BlueprintRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintRoot))]
  public class RootConfigurator : BaseBlueprintConfigurator<BlueprintRoot, RootConfigurator>
  {
    private RootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RootConfigurator For(string name)
    {
      return new RootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintRoot>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_DefaultPlayerCharacter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="defaultPlayerCharacter"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public RootConfigurator SetDefaultPlayerCharacter(string? defaultPlayerCharacter)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DefaultPlayerCharacter = BlueprintTool.GetRef<BlueprintUnitReference>(defaultPlayerCharacter);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_SelectablePlayerCharacters"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="selectablePlayerCharacters"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public RootConfigurator SetSelectablePlayerCharacters(string[]? selectablePlayerCharacters)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SelectablePlayerCharacters = selectablePlayerCharacters.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintRoot.m_SelectablePlayerCharacters"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="selectablePlayerCharacters"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public RootConfigurator AddToSelectablePlayerCharacters(params string[] selectablePlayerCharacters)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SelectablePlayerCharacters = CommonTool.Append(bp.m_SelectablePlayerCharacters, selectablePlayerCharacters.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintRoot.m_SelectablePlayerCharacters"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="selectablePlayerCharacters"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public RootConfigurator RemoveFromSelectablePlayerCharacters(params string[] selectablePlayerCharacters)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = selectablePlayerCharacters.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name));
            bp.m_SelectablePlayerCharacters =
                bp.m_SelectablePlayerCharacters
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_PlayerFaction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="playerFaction"><see cref="Kingmaker.Blueprints.BlueprintFaction"/></param>
    [Generated]
    public RootConfigurator SetPlayerFaction(string? playerFaction)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_PlayerFaction = BlueprintTool.GetRef<BlueprintFactionReference>(playerFaction);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.CompanionsAI"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetCompanionsAI(bool companionsAI)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CompanionsAI = companionsAI;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_KingFlag"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="kingFlag"><see cref="Kingmaker.Blueprints.BlueprintUnlockableFlag"/></param>
    [Generated]
    public RootConfigurator SetKingFlag(string? kingFlag)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_KingFlag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(kingFlag);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.MinProjectileMissDeviation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetMinProjectileMissDeviation(float minProjectileMissDeviation)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MinProjectileMissDeviation = minProjectileMissDeviation;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.MaxProjectileMissDeviation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetMaxProjectileMissDeviation(float maxProjectileMissDeviation)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MaxProjectileMissDeviation = maxProjectileMissDeviation;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.HumanAnimationSet"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetHumanAnimationSet(AnimationSet humanAnimationSet)
    {
      ValidateParam(humanAnimationSet);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.HumanAnimationSet = humanAnimationSet;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_NewGamePreset"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="newGamePreset"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPreset"/></param>
    [Generated]
    public RootConfigurator SetNewGamePreset(string? newGamePreset)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_NewGamePreset = BlueprintTool.GetRef<BlueprintAreaPresetReference>(newGamePreset);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.StartGameActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetStartGameActions(ActionsBuilder? startGameActions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StartGameActions = startGameActions?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Dialog"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetDialog(DialogRoot dialog)
    {
      ValidateParam(dialog);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Dialog = dialog;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Cheats"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetCheats(CheatRoot cheats)
    {
      ValidateParam(cheats);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Cheats = cheats;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_RE"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="rE"><see cref="Kingmaker.RandomEncounters.Settings.RandomEncountersRoot"/></param>
    [Generated]
    public RootConfigurator SetRE(string? rE)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_RE = BlueprintTool.GetRef<RandomEncountersRootReference>(rE);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_GlobalMap"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetGlobalMap(GlobalMapRoot globalMap)
    {
      ValidateParam(globalMap);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_GlobalMap = globalMap;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Progression"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetProgression(ProgressionRoot progression)
    {
      ValidateParam(progression);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Progression = progression;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.CharGen"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetCharGen(CharGenRoot charGen)
    {
      ValidateParam(charGen);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.CharGen = charGen;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Prefabs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetPrefabs(Prefabs prefabs)
    {
      ValidateParam(prefabs);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Prefabs = prefabs;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.OccludedCharacterColors"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetOccludedCharacterColors(OccludedCharacterColors occludedCharacterColors)
    {
      ValidateParam(occludedCharacterColors);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.OccludedCharacterColors = occludedCharacterColors;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.UIRoot"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetUIRoot(UIRoot uIRoot)
    {
      ValidateParam(uIRoot);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.UIRoot = uIRoot;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Quests"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetQuests(QuestsRoot quests)
    {
      ValidateParam(quests);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Quests = quests;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Vendors"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetVendors(VendorsRoot vendors)
    {
      ValidateParam(vendors);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Vendors = vendors;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.SystemMechanics"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetSystemMechanics(SystemMechanicsRoot systemMechanics)
    {
      ValidateParam(systemMechanics);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.SystemMechanics = systemMechanics;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.StatusBuffs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetStatusBuffs(StatusBuffsRoot statusBuffs)
    {
      ValidateParam(statusBuffs);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.StatusBuffs = statusBuffs;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Cursors"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetCursors(CursorRoot cursors)
    {
      ValidateParam(cursors);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Cursors = cursors;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.WeatherSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetWeatherSettings(WeatherRoot weatherSettings)
    {
      ValidateParam(weatherSettings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.WeatherSettings = weatherSettings;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.DlcSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetDlcSettings(DlcRoot dlcSettings)
    {
      ValidateParam(dlcSettings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.DlcSettings = dlcSettings;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.NewGameSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetNewGameSettings(NewGameRoot newGameSettings)
    {
      ValidateParam(newGameSettings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.NewGameSettings = newGameSettings;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.SurfaceTypeData"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetSurfaceTypeData(SurfaceTypeData surfaceTypeData)
    {
      ValidateParam(surfaceTypeData);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.SurfaceTypeData = surfaceTypeData;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_InvisibleKittenUnit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="invisibleKittenUnit"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public RootConfigurator SetInvisibleKittenUnit(string? invisibleKittenUnit)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_InvisibleKittenUnit = BlueprintTool.GetRef<BlueprintUnitReference>(invisibleKittenUnit);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.OptimizationDummyUnit"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetOptimizationDummyUnit(PrefabLink? optimizationDummyUnit)
    {
      ValidateParam(optimizationDummyUnit);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.OptimizationDummyUnit = optimizationDummyUnit ?? Constants.Empty.PrefabLink;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_CoinItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="coinItem"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public RootConfigurator SetCoinItem(string? coinItem)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CoinItem = BlueprintTool.GetRef<BlueprintItemReference>(coinItem);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.LocalizedTexts"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetLocalizedTexts(LocalizedTexts localizedTexts)
    {
      ValidateParam(localizedTexts);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LocalizedTexts = localizedTexts;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.SettingsRoot"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SettingsRoot(UISettingsRoot settingsRoot)
    {
      ValidateParam(settingsRoot);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.SettingsRoot = settingsRoot;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_DifficultyList"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetDifficultyList(DifficultyPresetsList difficultyList)
    {
      ValidateParam(difficultyList);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DifficultyList = difficultyList;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.SettingsValues"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SettingsValues(SettingsValues settingsValues)
    {
      ValidateParam(settingsValues);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.SettingsValues = settingsValues;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.StealthEffectPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetStealthEffectPrefab(GameObject stealthEffectPrefab)
    {
      ValidateParam(stealthEffectPrefab);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.StealthEffectPrefab = stealthEffectPrefab;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.ExitStealthEffectPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetExitStealthEffectPrefab(GameObject exitStealthEffectPrefab)
    {
      ValidateParam(exitStealthEffectPrefab);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ExitStealthEffectPrefab = exitStealthEffectPrefab;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.WeaponModelSizing"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetWeaponModelSizing(WeaponModelSizeSettings weaponModelSizing)
    {
      ValidateParam(weaponModelSizing);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.WeaponModelSizing = weaponModelSizing;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.MountModelSizing"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetMountModelSizing(MountModelSizeSetting mountModelSizing)
    {
      ValidateParam(mountModelSizing);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.MountModelSizing = mountModelSizing;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Sound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetSound(SoundRoot sound)
    {
      ValidateParam(sound);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Sound = sound;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_CutscenesRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cutscenesRoot"><see cref="Kingmaker.Blueprints.Root.CutscenesRoot"/></param>
    [Generated]
    public RootConfigurator SetCutscenesRoot(string? cutscenesRoot)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CutscenesRoot = BlueprintTool.GetRef<CutscenesRoot.Reference>(cutscenesRoot);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_Kingdom"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="kingdom"><see cref="Kingmaker.Kingdom.Blueprints.KingdomRoot"/></param>
    [Generated]
    public RootConfigurator SetKingdom(string? kingdom)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Kingdom = BlueprintTool.GetRef<KingdomRootReference>(kingdom);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_CorruptionRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="corruptionRoot"><see cref="Kingmaker.Corruption.BlueprintCorruptionRoot"/></param>
    [Generated]
    public RootConfigurator SetCorruptionRoot(string? corruptionRoot)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CorruptionRoot = BlueprintTool.GetRef<BlueprintCorruptionRoot.Reference>(corruptionRoot);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_ArmyRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="armyRoot"><see cref="Kingmaker.Kingdom.Blueprints.ArmyRoot"/></param>
    [Generated]
    public RootConfigurator SetArmyRoot(string? armyRoot)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ArmyRoot = BlueprintTool.GetRef<ArmyRootReference>(armyRoot);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_CraftRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="craftRoot"><see cref="Kingmaker.Craft.CraftRoot"/></param>
    [Generated]
    public RootConfigurator SetCraftRoot(string? craftRoot)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CraftRoot = BlueprintTool.GetRef<CraftRoot.Reference>(craftRoot);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_LeadersRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="leadersRoot"><see cref="Kingmaker.Kingdom.Blueprints.LeadersRoot"/></param>
    [Generated]
    public RootConfigurator SetLeadersRoot(string? leadersRoot)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_LeadersRoot = BlueprintTool.GetRef<LeadersRootReference>(leadersRoot);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_MoraleRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="moraleRoot"><see cref="Kingmaker.Armies.Blueprints.MoraleRoot"/></param>
    [Generated]
    public RootConfigurator SetMoraleRoot(string? moraleRoot)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MoraleRoot = BlueprintTool.GetRef<MoraleRoot.Reference>(moraleRoot);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_TacticalCombat"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="tacticalCombat"><see cref="Kingmaker.Armies.TacticalCombat.Blueprints.BlueprintTacticalCombatRoot"/></param>
    [Generated]
    public RootConfigurator SetTacticalCombat(string? tacticalCombat)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TacticalCombat = BlueprintTool.GetRef<BlueprintTacticalCombatRoot.Reference>(tacticalCombat);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Calendar"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetCalendar(CalendarRoot calendar)
    {
      ValidateParam(calendar);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Calendar = calendar;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_Formations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="formations"><see cref="Kingmaker.Blueprints.Root.FormationsRoot"/></param>
    [Generated]
    public RootConfigurator SetFormations(string? formations)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Formations = BlueprintTool.GetRef<FormationsRootReference>(formations);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.RazerColorData"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetRazerColorData(RazerColorData razerColorData)
    {
      ValidateParam(razerColorData);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.RazerColorData = razerColorData;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Animation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetAnimation(AnimationRoot animation)
    {
      ValidateParam(animation);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Animation = animation;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Camping"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetCamping(CampingRoot camping)
    {
      ValidateParam(camping);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Camping = camping;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_FxRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="fxRoot"><see cref="Kingmaker.Blueprints.Root.Fx.FxRoot"/></param>
    [Generated]
    public RootConfigurator SetFxRoot(string? fxRoot)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_FxRoot = BlueprintTool.GetRef<FxRootReference>(fxRoot);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_HitSystemRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="hitSystemRoot"><see cref="Kingmaker.Visual.HitSystem.HitSystemRoot"/></param>
    [Generated]
    public RootConfigurator SetHitSystemRoot(string? hitSystemRoot)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_HitSystemRoot = BlueprintTool.GetRef<HitSystemRootReference>(hitSystemRoot);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_PlayerUpgradeActions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="playerUpgradeActions"><see cref="Kingmaker.Blueprints.Root.PlayerUpgradeActionsRoot"/></param>
    [Generated]
    public RootConfigurator SetPlayerUpgradeActions(string? playerUpgradeActions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_PlayerUpgradeActions = BlueprintTool.GetRef<PlayerUpgradeActionsRoot.Reference>(playerUpgradeActions);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_CustomCompanion"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="customCompanion"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public RootConfigurator SetCustomCompanion(string? customCompanion)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CustomCompanion = BlueprintTool.GetRef<BlueprintUnitReference>(customCompanion);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.CustomCompanionBaseCost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetCustomCompanionBaseCost(int customCompanionBaseCost)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CustomCompanionBaseCost = customCompanionBaseCost;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.StandartPerceptionRadius"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetStandartPerceptionRadius(int standartPerceptionRadius)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StandartPerceptionRadius = standartPerceptionRadius;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.AreaEffectAutoDestroySeconds"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetAreaEffectAutoDestroySeconds(int areaEffectAutoDestroySeconds)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AreaEffectAutoDestroySeconds = areaEffectAutoDestroySeconds;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.AnnoyingConditionsAutoDestroySeconds"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetAnnoyingConditionsAutoDestroySeconds(int annoyingConditionsAutoDestroySeconds)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AnnoyingConditionsAutoDestroySeconds = annoyingConditionsAutoDestroySeconds;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.DefaultDissolveTexture"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetDefaultDissolveTexture(Texture2D defaultDissolveTexture)
    {
      ValidateParam(defaultDissolveTexture);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.DefaultDissolveTexture = defaultDissolveTexture;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.Achievements"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetAchievements(AchievementsRoot achievements)
    {
      ValidateParam(achievements);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Achievements = achievements;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_UnitTypes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unitTypes"><see cref="Kingmaker.Blueprints.BlueprintUnitType"/></param>
    [Generated]
    public RootConfigurator SetUnitTypes(string[]? unitTypes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_UnitTypes = unitTypes.Select(name => BlueprintTool.GetRef<BlueprintUnitTypeReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintRoot.m_UnitTypes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unitTypes"><see cref="Kingmaker.Blueprints.BlueprintUnitType"/></param>
    [Generated]
    public RootConfigurator AddToUnitTypes(params string[] unitTypes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_UnitTypes = CommonTool.Append(bp.m_UnitTypes, unitTypes.Select(name => BlueprintTool.GetRef<BlueprintUnitTypeReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintRoot.m_UnitTypes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unitTypes"><see cref="Kingmaker.Blueprints.BlueprintUnitType"/></param>
    [Generated]
    public RootConfigurator RemoveFromUnitTypes(params string[] unitTypes)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = unitTypes.Select(name => BlueprintTool.GetRef<BlueprintUnitTypeReference>(name));
            bp.m_UnitTypes =
                bp.m_UnitTypes
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.TestUIStyles"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RootConfigurator SetTestUIStyles(TestUIStylesRoot testUIStyles)
    {
      ValidateParam(testUIStyles);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.TestUIStyles = testUIStyles;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_Dungeon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="dungeon"><see cref="Kingmaker.Dungeon.Blueprints.BlueprintDungeonRoot"/></param>
    [Generated]
    public RootConfigurator SetDungeon(string? dungeon)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Dungeon = BlueprintTool.GetRef<BlueprintDungeonRootReference>(dungeon);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_ConsoleRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="consoleRoot"><see cref="Kingmaker.Blueprints.Root.ConsoleRoot"/></param>
    [Generated]
    public RootConfigurator SetConsoleRoot(string? consoleRoot)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ConsoleRoot = BlueprintTool.GetRef<ConsoleRootReference>(consoleRoot);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_BlueprintTrapSettingsRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blueprintTrapSettingsRoot"><see cref="Kingmaker.Blueprints.BlueprintTrapSettingsRoot"/></param>
    [Generated]
    public RootConfigurator SetBlueprintTrapSettingsRoot(string? blueprintTrapSettingsRoot)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_BlueprintTrapSettingsRoot = BlueprintTool.GetRef<BlueprintTrapSettingsRootReference>(blueprintTrapSettingsRoot);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_InteractionRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="interactionRoot"><see cref="Kingmaker.Interaction.BlueprintInteractionRoot"/></param>
    [Generated]
    public RootConfigurator SetInteractionRoot(string? interactionRoot)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_InteractionRoot = BlueprintTool.GetRef<BlueprintInteractionRoot.Referense>(interactionRoot);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_BlueprintMythicsSettingsReference"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blueprintMythicsSettingsReference"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintMythicsSettings"/></param>
    [Generated]
    public RootConfigurator SetBlueprintMythicsSettingsReference(string? blueprintMythicsSettingsReference)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_BlueprintMythicsSettingsReference = BlueprintTool.GetRef<BlueprintMythicsSettingsReference>(blueprintMythicsSettingsReference);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRoot.m_CustomAiConsiderations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="customAiConsiderations"><see cref="Kingmaker.AI.Blueprints.CustomAiConsiderationsRoot"/></param>
    [Generated]
    public RootConfigurator SetCustomAiConsiderations(string? customAiConsiderations)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CustomAiConsiderations = BlueprintTool.GetRef<CustomAiConsiderationsRoot.Reference>(customAiConsiderations);
          });
    }
  }
}

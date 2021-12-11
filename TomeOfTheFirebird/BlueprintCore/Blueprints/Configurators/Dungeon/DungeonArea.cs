using BlueprintCore.Blueprints.Configurators.Area;
using BlueprintCore.Utils;
using Kingmaker.Dungeon.Blueprints;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Configurator for <see cref="BlueprintDungeonArea"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintDungeonArea))]
  public class DungeonAreaConfigurator : BaseAreaConfigurator<BlueprintDungeonArea, DungeonAreaConfigurator>
  {
    private DungeonAreaConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DungeonAreaConfigurator For(string name)
    {
      return new DungeonAreaConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DungeonAreaConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintDungeonArea>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonArea.DungeonSetting"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonAreaConfigurator SetDungeonSetting(DungeonStageSetting dungeonSetting)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DungeonSetting = dungeonSetting;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonArea.Rooms"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonAreaConfigurator SetRooms(DungeonRoomSettings[]? rooms)
    {
      ValidateParam(rooms);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Rooms = rooms;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonArea.Rooms"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonAreaConfigurator AddToRooms(params DungeonRoomSettings[] rooms)
    {
      ValidateParam(rooms);
      return OnConfigureInternal(
          bp =>
          {
            bp.Rooms = CommonTool.Append(bp.Rooms, rooms ?? new DungeonRoomSettings[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonArea.Rooms"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonAreaConfigurator RemoveFromRooms(params DungeonRoomSettings[] rooms)
    {
      ValidateParam(rooms);
      return OnConfigureInternal(
          bp =>
          {
            bp.Rooms = bp.Rooms.Where(item => !rooms.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonArea.SecretRooms"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonAreaConfigurator SetSecretRooms(DungeonRoomSettings[]? secretRooms)
    {
      ValidateParam(secretRooms);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.SecretRooms = secretRooms;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonArea.SecretRooms"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonAreaConfigurator AddToSecretRooms(params DungeonRoomSettings[] secretRooms)
    {
      ValidateParam(secretRooms);
      return OnConfigureInternal(
          bp =>
          {
            bp.SecretRooms = CommonTool.Append(bp.SecretRooms, secretRooms ?? new DungeonRoomSettings[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonArea.SecretRooms"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonAreaConfigurator RemoveFromSecretRooms(params DungeonRoomSettings[] secretRooms)
    {
      ValidateParam(secretRooms);
      return OnConfigureInternal(
          bp =>
          {
            bp.SecretRooms = bp.SecretRooms.Where(item => !secretRooms.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonArea.Traps"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonAreaConfigurator SetTraps(DungeonTrapLocator[]? traps)
    {
      ValidateParam(traps);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Traps = traps;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonArea.Traps"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonAreaConfigurator AddToTraps(params DungeonTrapLocator[] traps)
    {
      ValidateParam(traps);
      return OnConfigureInternal(
          bp =>
          {
            bp.Traps = CommonTool.Append(bp.Traps, traps ?? new DungeonTrapLocator[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonArea.Traps"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonAreaConfigurator RemoveFromTraps(params DungeonTrapLocator[] traps)
    {
      ValidateParam(traps);
      return OnConfigureInternal(
          bp =>
          {
            bp.Traps = bp.Traps.Where(item => !traps.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonArea.ThemeLightScenes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonAreaConfigurator SetThemeLightScenes(BlueprintDungeonArea.ThemeScene[]? themeLightScenes)
    {
      ValidateParam(themeLightScenes);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ThemeLightScenes = themeLightScenes;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonArea.ThemeLightScenes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonAreaConfigurator AddToThemeLightScenes(params BlueprintDungeonArea.ThemeScene[] themeLightScenes)
    {
      ValidateParam(themeLightScenes);
      return OnConfigureInternal(
          bp =>
          {
            bp.ThemeLightScenes = CommonTool.Append(bp.ThemeLightScenes, themeLightScenes ?? new BlueprintDungeonArea.ThemeScene[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonArea.ThemeLightScenes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonAreaConfigurator RemoveFromThemeLightScenes(params BlueprintDungeonArea.ThemeScene[] themeLightScenes)
    {
      ValidateParam(themeLightScenes);
      return OnConfigureInternal(
          bp =>
          {
            bp.ThemeLightScenes = bp.ThemeLightScenes.Where(item => !themeLightScenes.Contains(item)).ToArray();
          });
    }
  }
}

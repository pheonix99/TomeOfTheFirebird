using TomeOfTheFirebird.Config;
using JetBrains.Annotations;
using Kingmaker.Blueprints;
using System.Collections.Generic;

namespace TomeOfTheFirebird
{
    static class Resources
    {

        public static readonly Dictionary<BlueprintGuid, SimpleBlueprint> ModBlueprints = new Dictionary<BlueprintGuid, SimpleBlueprint>();
        public static T GetModBlueprint<T>(string name) where T : SimpleBlueprint
        {
            var assetId = ModSettings.Blueprints.GetGUID(name);
            ModBlueprints.TryGetValue(assetId, out var value);
            return value as T;
        }
        public static T GetBlueprint<T>(string id) where T : SimpleBlueprint
        {
#if DEBUG
            Main.Log($"Getting {id} of {typeof(T)}");
#endif
            var assetId = new BlueprintGuid(System.Guid.Parse(id));
            return GetBlueprint<T>(assetId);
        }
        public static T GetBlueprint<T>(BlueprintGuid id) where T : SimpleBlueprint
        {
            SimpleBlueprint asset = ResourcesLibrary.TryGetBlueprint(id);
            T value = asset as T;
            if (value == null) { Main.Error($"COULD NOT LOAD: {id} - {typeof(T)}"); }
            return value;
        }
        public static void AddBlueprint([NotNull] SimpleBlueprint blueprint)
        {
            AddBlueprint(blueprint, blueprint.AssetGuid);
        }
        public static void AddBlueprint([NotNull] SimpleBlueprint blueprint, string assetId)
        {
            var Id = BlueprintGuid.Parse(assetId);
            AddBlueprint(blueprint, Id);
        }
        public static void AddBlueprint([NotNull] SimpleBlueprint blueprint, BlueprintGuid assetId)
        {
            var loadedBlueprint = ResourcesLibrary.TryGetBlueprint(assetId);
            if (loadedBlueprint == null)
            {
                ModBlueprints[assetId] = blueprint;
                ResourcesLibrary.BlueprintsCache.AddCachedBlueprint(assetId, blueprint);
                blueprint.OnEnable();
                Main.LogPatch("Added", blueprint);
            }
            else
            {
                Main.Log($"Failed to Add: {blueprint.name}");
                Main.Log($"Asset ID: {assetId} already in use by: {loadedBlueprint.name}");
            }
        }

        public static T GetTabletopTweaksBlueprint<T>(string name) where T : SimpleBlueprint
        {
            var assetId = ModSettings.Blueprints.GetGUID(name);
            bool modBPExists = ModBlueprints.TryGetValue(assetId, out var value);
            if (modBPExists)
            {
                return value as T;
            }
            else
            {
                //Main.Log($"{name} not found locally");
                T blueprint = GetBlueprint<T>(assetId);
                if (blueprint != null)
                {

                    //Main.Log($"{name} located in Tabletop Tweaks");
                    //ModSettings.Blueprints.SetTTBPUsed(name, assetId);
                    return blueprint;
                }
                else
                {
                    //Main.Log($"{name} not built");
                    return null;
                }

            }

        }
    }
}

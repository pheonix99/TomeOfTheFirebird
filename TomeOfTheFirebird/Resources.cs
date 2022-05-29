using JetBrains.Annotations;
using Kingmaker.Blueprints;
using System.Collections.Generic;

namespace TomeOfTheFirebird
{
    static class Resources
    {
        /*
        public static readonly Dictionary<BlueprintGuid, SimpleBlueprint> ModBlueprints = new Dictionary<BlueprintGuid, SimpleBlueprint>();
        public static T GetModBlueprint<T>(string name) where T : SimpleBlueprint
        {
            var assetId = Main.TotFContext.Blueprints.GetGUID(name);
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
            if (value == null) { Main.TotFContext.Logger.LogError($"COULD NOT LOAD: {id} - {typeof(T)}"); }
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
                Main.TotFContext.Logger.LogPatch("Added", blueprint);
            }
            else
            {
                Main.TotFContext.Logger.Log($"Failed to Add: {blueprint.name}");
                Main.TotFContext.Logger.Log($"Asset ID: {assetId} already in use by: {loadedBlueprint.name}");
            }
        }

        public static T GetTabletopTweaksBlueprint<T>(string name) where T : SimpleBlueprint
        {
            var assetId = Main.TotFContext.Blueprints.GetGUID(name);
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
                    //Main.TotFContext.Blueprints.SetTTBPUsed(name, assetId);
                    return blueprint;
                }
                else
                {
                    //Main.Log($"{name} not built");
                    return null;
                }

            }

        }
        */
    }
}

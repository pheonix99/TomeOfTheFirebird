using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using TomeOfTheFirebird.New_Components;
using TomeOfTheFirebird.New_Content.WildTalents;

namespace TomeOfTheFirebird.Modified_Content.KineticistOverhaul
{
    public static class RationalizeElementalPrerequisites
    {
        static Func<PrequisiteKineticistElement> Fire;
        static Func<PrequisiteKineticistElement> Air;
        static Func<PrequisiteKineticistElement> Water;
        static Func<PrequisiteKineticistElement> Earth;
        static Func<PrequisiteKineticistElement> Wood;
        static Func<PrequisiteKineticistElement> Void;
        static Func<PrequisiteKineticistElement> Aether;

        public static void MakePrerequisites()
        {

            Fire = ()=>
            {
                IEnumerable<BlueprintFeatureReference> FireElements = KineticistHelpers.PrimaryFireFocuses.Select(x => BlueprintTool.GetRef<BlueprintFeatureReference>(x));
                FireElements = FireElements.Concat(KineticistHelpers.SecondaryFireFocuses.Select(x => BlueprintTool.GetRef<BlueprintFeatureReference>(x)));

                var req = new PrequisiteKineticistElement()
                {
                    Amount = 1,
                    m_Features = FireElements.ToArray(),
                    Element = "Fire"
                };

                return req;
            };
            Air = () =>
            {
                IEnumerable<BlueprintFeatureReference> AirElements = KineticistHelpers.PrimaryAirFocues.Select(x => BlueprintTool.GetRef<BlueprintFeatureReference>(x));
                AirElements = AirElements.Concat(KineticistHelpers.SecondaryAirFocues.Select(x => BlueprintTool.GetRef<BlueprintFeatureReference>(x)));

                var req = new PrequisiteKineticistElement()
                {
                    Amount = 1,
                    m_Features = AirElements.ToArray(),
                    Element = "Air"
                };

                return req;
            };
            Water = () =>
            {
                IEnumerable<BlueprintFeatureReference> WaterElements = KineticistHelpers.PrimaryWaterFocuses.Select(x => BlueprintTool.GetRef<BlueprintFeatureReference>(x));
                WaterElements = WaterElements.Concat(KineticistHelpers.SecondaryWaterFocuses.Select(x => BlueprintTool.GetRef<BlueprintFeatureReference>(x)));

                var req = new PrequisiteKineticistElement()
                {
                    Amount = 1,
                    m_Features = WaterElements.ToArray(),
                    Element = "Water"
                };

                return req;
            };
            Earth = () =>
            {
                IEnumerable<BlueprintFeatureReference> EarthElements = KineticistHelpers.PrimaryEarthFocuses.Select(x => BlueprintTool.GetRef<BlueprintFeatureReference>(x));
                EarthElements = EarthElements.Concat(KineticistHelpers.SecondaryEarthFocuses.Select(x => BlueprintTool.GetRef<BlueprintFeatureReference>(x)));

                var req = new PrequisiteKineticistElement()
                {
                    Amount = 1,
                    m_Features = EarthElements.ToArray(),
                    Element = "Earth"
                };

                return req;
            };
            Wood = () =>
            {
                IEnumerable<BlueprintFeatureReference> WoodElements = KineticistHelpers.PrimaryWoodFocuses.Select(x => BlueprintTool.GetRef<BlueprintFeatureReference>(x));
                WoodElements = WoodElements.Concat(KineticistHelpers.SecondaryWoodFocuses.Select(x => BlueprintTool.GetRef<BlueprintFeatureReference>(x)));

                var req = new PrequisiteKineticistElement()
                {
                    Amount = 1,
                    m_Features = WoodElements.ToArray(),
                    Element = "Wood"
                };

                return req;
            };
            Void = () =>
            {
                IEnumerable<BlueprintFeatureReference> VoidElements = KineticistHelpers.PrimaryVoidFocuses.Select(x => BlueprintTool.GetRef<BlueprintFeatureReference>(x));
                VoidElements = VoidElements.Concat(KineticistHelpers.SecondaryVoidFocuses.Select(x => BlueprintTool.GetRef<BlueprintFeatureReference>(x)));

                var req = new PrequisiteKineticistElement()
                {
                    Amount = 1,
                    m_Features = VoidElements.ToArray(),
                    Element = "Void"
                };

                return req;
            };
            Aether = () =>
            {
                IEnumerable<BlueprintFeatureReference> AetherElements = KineticistHelpers.PrimaryAetherFocues.Select(x => BlueprintTool.GetRef<BlueprintFeatureReference>(x));
                AetherElements = AetherElements.Concat(KineticistHelpers.SecondaryAetherFocues.Select(x => BlueprintTool.GetRef<BlueprintFeatureReference>(x)));

                var req = new PrequisiteKineticistElement()
                {
                    Amount = 1,
                    m_Features = AetherElements.ToArray(),
                    Element = "Aether"
                };

                return req;
            };
        }


    }
}

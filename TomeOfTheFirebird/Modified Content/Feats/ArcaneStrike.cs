using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Properties;
using TabletopTweaks.Core.NewComponents.Properties;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.New_Components.Properties;

namespace TomeOfTheFirebird.Modified_Content.Feats
{
    class ArcaneStrike
    {
        public static void AddDHSScaling()
        {
            var dhs = BlueprintTool.GetRef<BlueprintArchetypeReference>("8dff97413c63c1147be8a5ca229abefc");
            var fighter = BlueprintTool.GetRef<BlueprintCharacterClassReference>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var dd = BlueprintTool.GetRef<BlueprintCharacterClassReference>("72051275b1dbb2d42ba9118237794f7c");
            var scalar = TabletopTweaks.Core.Utilities.Helpers.CreateBlueprint<BlueprintUnitProperty>(Main.TotFContext, "ArcaneStrikeScalingUnitProperty", x => {
                x.AddComponent<CompositeCustomPropertyGetter>(x =>
                {
                    x.CalculationMode = CompositeCustomPropertyGetter.Mode.Highest;
                    
                    x.Properties = new CompositeCustomPropertyGetter.ComplexCustomProperty[]
                    {
                        
                        new CompositeCustomPropertyGetter.ComplexCustomProperty()
                        {
                            Property = new MaxCasterLevelPropertyGetter(),
                            Numerator = 1,
                            Denominator = 1,
                            Bonus = 0
                            
                        },
                         new CompositeCustomPropertyGetter.ComplexCustomProperty()
                         {
                             Property = new CompositeCustomPropertyGetter()
                             {
                                 CalculationMode = CompositeCustomPropertyGetter.Mode.Sum,
                                 Properties = new CompositeCustomPropertyGetter.ComplexCustomProperty[]
                                 {
                                     
                                     new CompositeCustomPropertyGetter.ComplexCustomProperty()
                                     {
                                         Property = new ClassLevelGetter()
                                         {
                                             m_Class = fighter,
                                             m_Archetype = dhs
                                         }
                                     },

                                     new CompositeCustomPropertyGetter.ComplexCustomProperty()
                                     {
                                         Property = new ClassLevelGetter()
                                         {
                                             m_Class = dd
                                         }
                                     }
                                 }
                             },
                             Numerator = 1,
                            Denominator = 1,
                            Bonus = 0
                         }
                    };
                });

            });
            if (Settings.IsDisabled("DragonheirScionArcaneStrikeScaling"))
                return;
            var arcanestrikebuff = BlueprintTool.Get<BlueprintBuff>("98ac795afd1b2014eb9fdf2b9820808f");
            var scalarConfig = arcanestrikebuff.GetComponent<ContextRankConfig>();
            if (scalarConfig.m_BaseValueType != ContextRankBaseValueType.MaxCasterLevel)
            {
                Main.TotFContext.Logger.LogError("Arcane Strike Has Already Had Its Scaling Changed, Aborting Patch");
                return;
            }
            else
            {
                scalarConfig.m_BaseValueType = ContextRankBaseValueType.CustomProperty;
                scalarConfig.m_CustomProperty = scalar.ToReference<BlueprintUnitPropertyReference>();
                Main.TotFContext.Logger.LogPatch(arcanestrikebuff);
                scalarConfig.m_Max = 40;
            }
        }
    }
}

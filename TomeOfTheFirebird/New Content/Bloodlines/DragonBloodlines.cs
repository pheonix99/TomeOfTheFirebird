using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TabletopTweaks.Core.Utilities;
using UniRx;

namespace TomeOfTheFirebird.New_Content.Bloodlines
{
    internal class DragonBloodlines
    {
        public static void Run()
        {
            LoadConstants();
        }

        static List<BlueprintFeature> StandardBloodragerBonusSpells = new List<BlueprintFeature>();

        private static void LoadConstants()
        {
        
            StandardBloodragerBonusSpells.Add(BlueprintTools.GetBlueprint<BlueprintFeature>("e8b16a8653bcc5e4a9c17b2bb07ca41f"));
            StandardBloodragerBonusSpells.Add(BlueprintTools.GetBlueprint<BlueprintFeature>("906b529e689eee54d98cc69d63309d1b"));

            StandardBloodragerBonusSpells.Add(BlueprintTools.GetBlueprint<BlueprintFeature>("19f788ffa8163ea479168c1b04207868"));


            StandardBloodragerBonusSpells.Add(BlueprintTools.GetBlueprint<BlueprintFeature>("174be67cf48f80d43a6b2976021a1d89"));
           
        }
        private static void Rebuild()
        {
            
        }

        private static void RebuildSorc()
        {

        }

        private class BloodragerDragonBloodlineParts
        {
            public BlueprintProgression prog;
            public bool vanilla; 
            public string DragonType;
            public BlueprintBuffReference BaseBuff;
            public BlueprintFeature WanderingFeature;
            public BlueprintFactionReference ClawsDisplayFeature;
            public List<Tuple<BlueprintFeatureReference, BlueprintBuffReference>> Claws;
            public Tuple<BlueprintFeatureReference, BlueprintBuffReference> Resistance;
            public BlueprintFeatureReference Breath;
            public BlueprintFeatureReference BreathCharge;
            
            public Tuple<BlueprintFeatureReference, BlueprintBuffReference> Wings;
            public BlueprintFeatureReference Capstone;
            public BlueprintFeatureReference prereqFeature;
            public BlueprintFeatureReference FormOfTheDragon;
        }

        private static BlueprintFeatureReference BRDragonGreenragerFeat => BlueprintTool.GetRef<BlueprintFeatureReference>("3d0b4942c400a7f448ca09e04edfb52a");
        private static BlueprintFeatureReference BRDragonNormalFeat => BlueprintTool.GetRef<BlueprintFeatureReference>("8a2a8d623f6cb574f9e0b6c82ae65c74");
        private static BlueprintFeatureSelectionReference BRDragonMMRager => BlueprintTool.GetRef<BlueprintFeatureSelectionReference>("40e0698d0af6454cb272b53d8002f946");

        private static BlueprintFeatureReference BRBreathWeaponCharge;
        private static BlueprintBuff BloodragerStandardRageBuff => BlueprintTools.GetBlueprint<BlueprintBuff>("5eac31e457999334b98f98b60fc73b2f");

        private static void MakeBlanksForApplyStep(BlueprintProgression bloodline, BloodragerDragonBloodlineParts parts)
        {
            if (parts.WanderingFeature == null)
            {
                parts.WanderingFeature = FeatureConfigurator.New(bloodline.name + "Wandering", Main.TotFContext.Blueprints.GetGUID(bloodline.name + "Wandering").ToString()).Configure();
                
            }
            if (parts.BaseBuff == null)
            {
                parts.BaseBuff = TabletopTweaks.Core.Utilities.Helpers.CreateBlueprint<BlueprintBuff>(Main.TotFContext, $"BloodragerDraconic{parts.DragonType}BaseBuff", bp =>
                {
                    bp.SetName(Main.TotFContext, $"{parts.DragonType} Dragon Bloodrage");
                    bp.SetDescription(Main.TotFContext, "");
                    bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                    bp.IsClassFeature = true;
                }).ToReference<BlueprintBuffReference>();
            }
        }


        private static BloodragerDragonBloodlineParts MakePartsFromVanilla(BlueprintProgression bloodline, bool vanilla, DamageEnergyType energy)
        {
            var result = new BloodragerDragonBloodlineParts();
            result.vanilla = vanilla;
            result.prog = bloodline;





            return result;
        }

        private static void MakeFakesForPartsStep(BlueprintProgression bloodline, bool vanilla)
        {

        }


        private static void ApplyBloodragerPartsToProgression(BloodragerDragonBloodlineParts parts)
        {
            parts.prog.LevelEntries = new LevelEntry[] {
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(1, parts.Claws[0].Item1, parts.prereqFeature, TotFBloodlineTools.BloodlineRequisiteFeature),
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(4, parts.Resistance.Item1, parts.Claws[1].Item1),

                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(6, BRDragonGreenragerFeat),
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(7, StandardBloodragerBonusSpells[0]),
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(8,   parts.Resistance.Item1, parts.Claws[2].Item1, parts.Breath, parts.BreathCharge),
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(9, BRDragonGreenragerFeat),
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(10, StandardBloodragerBonusSpells[1]),
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(12, BRDragonNormalFeat, parts.Claws[3].Item1, parts.Wings.Item1),
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(13, StandardBloodragerBonusSpells[2]),
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(15, BRDragonNormalFeat),
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(16, parts.Resistance.Item1, StandardBloodragerBonusSpells[3], parts.FormOfTheDragon, parts.BreathCharge),
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(18, BRDragonNormalFeat),
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(20, parts.Capstone, parts.BreathCharge)
                    };
            parts.prog.AddPrerequisite<PrerequisiteNoFeature>(c =>
            {
                c.Group = Prerequisite.GroupType.Any;
                c.m_Feature = TotFBloodlineTools.BloodlineRequisiteFeature;
            });
            parts.prog.AddPrerequisite<PrerequisiteFeature>(c =>
            {
                c.Group = Prerequisite.GroupType.Any;
                c.m_Feature = parts.prereqFeature;
            });
            parts.prog.UIGroups = new UIGroup[] {
                    TabletopTweaks.Core.Utilities.Helpers.CreateUIGroup(BRDragonNormalFeat, BRDragonGreenragerFeat)
                    };
            if (parts.WanderingFeature == null)
            {
                parts.WanderingFeature = BloodlineTools.CreateMixedBloodFeature(Main.TotFContext, parts.prog.name +"Wandering", parts.prog, bp =>
                {
                    bp.m_Icon = parts.prog.Icon;
                }).ToReference<BlueprintFeatureReference>();
            }
            if (parts.BaseBuff == null)
            {
                parts.BaseBuff = TabletopTweaks.Core.Utilities.Helpers.CreateBlueprint<BlueprintBuff>(Main.TotFContext, $"BloodragerDraconic{parts.DragonType}BaseBuff", bp =>
                {
                    bp.SetName(Main.TotFContext, $"{parts.DragonType} Dragon Bloodrage");
                    bp.SetDescription(Main.TotFContext, "");
                    bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                    bp.IsClassFeature = true;
                }).ToReference<BlueprintBuffReference>();
            }
           var ThisBloodrageBuff = parts.BaseBuff.Get();

            //TODO build claws setup!
            foreach (var v in parts.Claws)
            {
                ThisBloodrageBuff.AddConditionalBuff(v.Item1, v.Item2);
            }
            ThisBloodrageBuff.AddConditionalBuff(parts.Resistance.Item1, parts.Resistance.Item2);
            ThisBloodrageBuff.AddConditionalBuff(parts.Wings.Item1, parts.Wings.Item2);

            BloodragerStandardRageBuff.AddConditionalBuff(parts.prog, ThisBloodrageBuff);

            if (!Settings.IsTTTBaseEnabled())
                return;

            BloodlineTools.ApplyPrimalistException(parts.Resistance.Item1, 4, parts.prog);
            BloodlineTools.ApplyPrimalistException(parts.Breath, 8, parts.prog);
            BloodlineTools.ApplyPrimalistException(parts.Wings.Item1, 12, parts.prog);
            BloodlineTools.ApplyPrimalistException(parts.FormOfTheDragon, 16, parts.prog);
            BloodlineTools.ApplyPrimalistException(parts.Capstone, 20, parts.prog);
            if (!parts.vanilla)
            {
                BloodlineTools.RegisterBloodragerBloodline(parts.prog, parts.WanderingFeature);
               
            }
            TotFBloodlineTools.MetamagicSupport(parts.prog, BRDragonMMRager.Get());//Might or might not need
        }


        private static void RebuildBloodragerBloodline(BlueprintProgression dragon, string name, DamageEnergyType energyType)
        {
            //Build it like any other new bloodline with the following exceptions:
            //Shared resource for breath attacks
            //Shared natural armor buff - might need a central shared prog for anti-stacking
            //Share the baseline claws - weapons but not feature
            
            //Re-use the progression but wipe it



            
        }
    }
}

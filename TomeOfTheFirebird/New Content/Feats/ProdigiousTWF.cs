using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.Config;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.NewComponents;

namespace TomeOfTheFirebird.New_Content.Feats
{
    static class ProdigiousTWF
    {

        public static void AddProdigiousTWF()
        {
            var maker = MakerTools.MakeFeature("ProdigiousTWF", "Prodigious Two-Weapon Fighting", "You may fight with a one-handed weapon in your offhand as if it were a light weapon. In addition, you may use your Strength score instead of your Dexterity score for the purpose of qualifying for Two-Weapon Fighting and any feats with Two-Weapon Fighting as a prerequisite.");
            maker.SetRanks(1);
            maker.AddToFeatureGroups(FeatureGroup.Feat, FeatureGroup.CombatFeat);
            maker.SetReapplyOnLevelUp(true);
            maker.SetIsClassFeature(true);
            maker.PrerequisiteStat(Kingmaker.EntitySystem.Stats.StatType.Strength, 13);
            maker.AddToFeatureTags(FeatureTag.Attack, FeatureTag.Melee);
            maker.AddComponent(new TWFNoPenaltyFromNotLight());

            var result = maker.Configure();
            if (ModSettings.NewContent.Feats.IsDisabled("ProdigiousTWF")) { return; }

            FeatTools.AddAsFeat(result);
            AlterTWFFeatCascade();

            FeatureSelectionConfigurator.For(FeatTools.Selections.RangerStyleTwoWeaponSelection2.AssetGuidThreadSafe).AddToFeatures(result.AssetGuidThreadSafe);
            FeatureSelectionConfigurator.For(FeatTools.Selections.RangerStyleTwoWeaponSelection6.AssetGuidThreadSafe).AddToFeatures(result.AssetGuidThreadSafe);
            FeatureSelectionConfigurator.For(FeatTools.Selections.RangerStyleTwoWeaponSelection10.AssetGuidThreadSafe).AddToFeatures(result.AssetGuidThreadSafe);
            FeatureSelectionConfigurator.For(FeatTools.Selections.RangerStyleShieldSelection2.AssetGuidThreadSafe).AddToFeatures(result.AssetGuidThreadSafe);
            FeatureSelectionConfigurator.For(FeatTools.Selections.RangerStyleShieldSelection6.AssetGuidThreadSafe).AddToFeatures(result.AssetGuidThreadSafe);
            FeatureSelectionConfigurator.For(FeatTools.Selections.RangerStyleShieldSelection10.AssetGuidThreadSafe).AddToFeatures(result.AssetGuidThreadSafe);

            


        }

        private static void AlterTWFFeatCascade()
        {
            var Prodigious = Resources.GetTabletopTweaksBlueprint<BlueprintFeature>("ProdigiousTWF");

            var TWF = Resources.GetBlueprint<BlueprintFeature>("ac8aaf29054f5b74eb18f2af950e752d");

            var BashingFinish = Resources.GetBlueprint<BlueprintFeature>("0b442a7b4aa598d4e912a4ecee0500ff");
            var DoubleSlice = Resources.GetBlueprint<BlueprintFeature>("8a6a1920019c45d40b4561f05dcb3240");
            var ShieldMaster = Resources.GetBlueprint<BlueprintFeature>("dbec636d84482944f87435bd31522fcc");
            var ITWF = Resources.GetBlueprint<BlueprintFeature>("9af88f3ed8a017b45a6837eab7437629");
            var GTWF = Resources.GetBlueprint<BlueprintFeature>("c126adbdf6ddd8245bda33694cd774e8");
            var MTWF = Resources.GetBlueprint<BlueprintFeature>("c6afbb8c1a36a704a8041f35498f41a4");

            FeatTools.PatchFeatWithFeatLockedAlternateAbilityPrereqSimple(TWF, StatType.Dexterity, Prodigious, StatType.Strength);

            FeatTools.PatchFeatWithFeatLockedAlternateAbilityPrereqSimple(BashingFinish, StatType.Dexterity, Prodigious, StatType.Strength);
            FeatTools.PatchFeatWithFeatLockedAlternateAbilityPrereqSimple(DoubleSlice, StatType.Dexterity, Prodigious, StatType.Strength);
            FeatTools.PatchFeatWithFeatLockedAlternateAbilityPrereqSimple(ShieldMaster, StatType.Dexterity, Prodigious, StatType.Strength);
            FeatTools.PatchFeatWithFeatLockedAlternateAbilityPrereqSimple(ITWF, StatType.Dexterity, Prodigious, StatType.Strength);
            FeatTools.PatchFeatWithFeatLockedAlternateAbilityPrereqSimple(GTWF, StatType.Dexterity, Prodigious, StatType.Strength);
            FeatTools.PatchFeatWithFeatLockedAlternateAbilityPrereqSimple(MTWF, StatType.Dexterity, Prodigious, StatType.Strength);




        }



    }
}

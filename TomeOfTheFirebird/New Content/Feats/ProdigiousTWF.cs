using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using TabletopTweaks.Core.Utilities;
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

            var Prodigious = maker.Configure();
            if (Main.TotFContext.NewContent.Feats.IsDisabled("ProdigiousTWF")) { return; }

            TabletopTweaks.Core.Utilities.FeatTools.AddAsFeat(Prodigious);


            

            var TWF = BlueprintTools.GetBlueprint<BlueprintFeature>("ac8aaf29054f5b74eb18f2af950e752d");

            var BashingFinish = BlueprintTools.GetBlueprint<BlueprintFeature>("0b442a7b4aa598d4e912a4ecee0500ff");
            var DoubleSlice = BlueprintTools.GetBlueprint<BlueprintFeature>("8a6a1920019c45d40b4561f05dcb3240");
            var ShieldMaster = BlueprintTools.GetBlueprint<BlueprintFeature>("dbec636d84482944f87435bd31522fcc");
            var ITWF = BlueprintTools.GetBlueprint<BlueprintFeature>("9af88f3ed8a017b45a6837eab7437629");
            var GTWF = BlueprintTools.GetBlueprint<BlueprintFeature>("c126adbdf6ddd8245bda33694cd774e8");
            var MTWF = BlueprintTools.GetBlueprint<BlueprintFeature>("c6afbb8c1a36a704a8041f35498f41a4");

            Helpers.FeatTools.PatchFeatWithFeatLockedAlternateAbilityPrereqSimple(TWF, StatType.Dexterity, Prodigious, StatType.Strength);

            Helpers.FeatTools.PatchFeatWithFeatLockedAlternateAbilityPrereqSimple(BashingFinish, StatType.Dexterity, Prodigious, StatType.Strength);
            Helpers.FeatTools.PatchFeatWithFeatLockedAlternateAbilityPrereqSimple(DoubleSlice, StatType.Dexterity, Prodigious, StatType.Strength);
            Helpers.FeatTools.PatchFeatWithFeatLockedAlternateAbilityPrereqSimple(ShieldMaster, StatType.Dexterity, Prodigious, StatType.Strength);
            Helpers.FeatTools.PatchFeatWithFeatLockedAlternateAbilityPrereqSimple(ITWF, StatType.Dexterity, Prodigious, StatType.Strength);
            Helpers.FeatTools.PatchFeatWithFeatLockedAlternateAbilityPrereqSimple(GTWF, StatType.Dexterity, Prodigious, StatType.Strength);
            Helpers.FeatTools.PatchFeatWithFeatLockedAlternateAbilityPrereqSimple(MTWF, StatType.Dexterity, Prodigious, StatType.Strength);

            FeatureSelectionConfigurator.For(TabletopTweaks.Core.Utilities.FeatTools.Selections.RangerStyleTwoWeaponSelection2.AssetGuidThreadSafe).AddToFeatures(Prodigious.AssetGuidThreadSafe);
            FeatureSelectionConfigurator.For(TabletopTweaks.Core.Utilities.FeatTools.Selections.RangerStyleTwoWeaponSelection6.AssetGuidThreadSafe).AddToFeatures(Prodigious.AssetGuidThreadSafe);
            FeatureSelectionConfigurator.For(TabletopTweaks.Core.Utilities.FeatTools.Selections.RangerStyleTwoWeaponSelection10.AssetGuidThreadSafe).AddToFeatures(Prodigious.AssetGuidThreadSafe);
            FeatureSelectionConfigurator.For(TabletopTweaks.Core.Utilities.FeatTools.Selections.RangerStyleShieldSelection2.AssetGuidThreadSafe).AddToFeatures(Prodigious.AssetGuidThreadSafe);
            FeatureSelectionConfigurator.For(TabletopTweaks.Core.Utilities.FeatTools.Selections.RangerStyleShieldSelection6.AssetGuidThreadSafe).AddToFeatures(Prodigious.AssetGuidThreadSafe);
            FeatureSelectionConfigurator.For(TabletopTweaks.Core.Utilities.FeatTools.Selections.RangerStyleShieldSelection10.AssetGuidThreadSafe).AddToFeatures(Prodigious.AssetGuidThreadSafe);

            


        }



    }
}

using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
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
        static BlueprintFeature Prodigious;
        public static void AddProdigiousTWF()
        {
            FeatureConfigurator maker = MakerTools.MakeFeature("ProdigiousTWF", "Prodigious Two-Weapon Fighting", "You may fight with a one-handed weapon in your offhand as if it were a light weapon. In addition, you may use your Strength score instead of your Dexterity score for the purpose of qualifying for Two-Weapon Fighting and any feats with Two-Weapon Fighting as a prerequisite.");
            maker.SetRanks(1);
            maker.SetGroups(FeatureGroup.Feat, FeatureGroup.CombatFeat);
            maker.SetReapplyOnLevelUp(true);
            maker.SetIsClassFeature(true);
            maker.AddPrerequisiteStatValue(Kingmaker.EntitySystem.Stats.StatType.Strength, 13);
            maker.AddFeatureTagsComponent(FeatureTag.Attack| FeatureTag.Melee);
            maker.AddComponent(new TWFNoPenaltyFromNotLight());

            Prodigious = maker.Configure();
            if (Settings.IsDisabled("ProdigiousTWF")) { return; }

            TabletopTweaks.Core.Utilities.FeatTools.AddAsFeat(Prodigious);




            BlueprintFeature TWF = BlueprintTools.GetBlueprint<BlueprintFeature>("ac8aaf29054f5b74eb18f2af950e752d");

            BlueprintFeature BashingFinish = BlueprintTools.GetBlueprint<BlueprintFeature>("0b442a7b4aa598d4e912a4ecee0500ff");
            BlueprintFeature DoubleSlice = BlueprintTools.GetBlueprint<BlueprintFeature>("8a6a1920019c45d40b4561f05dcb3240");
            BlueprintFeature ShieldMaster = BlueprintTools.GetBlueprint<BlueprintFeature>("dbec636d84482944f87435bd31522fcc");
            BlueprintFeature ITWF = BlueprintTools.GetBlueprint<BlueprintFeature>("9af88f3ed8a017b45a6837eab7437629");
            BlueprintFeature GTWF = BlueprintTools.GetBlueprint<BlueprintFeature>("c126adbdf6ddd8245bda33694cd774e8");
            BlueprintFeature MTWF = BlueprintTools.GetBlueprint<BlueprintFeature>("c6afbb8c1a36a704a8041f35498f41a4");
            
            Helpers.MoreFeatTools.PatchFeatWithFeatLockedAlternateAbilityPrereqSimple(TWF, StatType.Dexterity, Prodigious, StatType.Strength);

            Helpers.MoreFeatTools.PatchFeatWithFeatLockedAlternateAbilityPrereqSimple(BashingFinish, StatType.Dexterity, Prodigious, StatType.Strength);
            Helpers.MoreFeatTools.PatchFeatWithFeatLockedAlternateAbilityPrereqSimple(DoubleSlice, StatType.Dexterity, Prodigious, StatType.Strength);
            Helpers.MoreFeatTools.PatchFeatWithFeatLockedAlternateAbilityPrereqSimple(ShieldMaster, StatType.Dexterity, Prodigious, StatType.Strength);
            Helpers.MoreFeatTools.PatchFeatWithFeatLockedAlternateAbilityPrereqSimple(ITWF, StatType.Dexterity, Prodigious, StatType.Strength);
            Helpers.MoreFeatTools.PatchFeatWithFeatLockedAlternateAbilityPrereqSimple(GTWF, StatType.Dexterity, Prodigious, StatType.Strength);
            Helpers.MoreFeatTools.PatchFeatWithFeatLockedAlternateAbilityPrereqSimple(MTWF, StatType.Dexterity, Prodigious, StatType.Strength);

            FeatureSelectionConfigurator.For(TabletopTweaks.Core.Utilities.FeatTools.Selections.RangerStyleTwoWeaponSelection2.AssetGuidThreadSafe).AddToAllFeatures(Prodigious.AssetGuidThreadSafe);
            FeatureSelectionConfigurator.For(TabletopTweaks.Core.Utilities.FeatTools.Selections.RangerStyleTwoWeaponSelection6.AssetGuidThreadSafe).AddToAllFeatures(Prodigious.AssetGuidThreadSafe);
            FeatureSelectionConfigurator.For(TabletopTweaks.Core.Utilities.FeatTools.Selections.RangerStyleTwoWeaponSelection10.AssetGuidThreadSafe).AddToAllFeatures(Prodigious.AssetGuidThreadSafe);
            FeatureSelectionConfigurator.For(TabletopTweaks.Core.Utilities.FeatTools.Selections.RangerStyleShieldSelection2.AssetGuidThreadSafe).AddToAllFeatures(Prodigious.AssetGuidThreadSafe);
            FeatureSelectionConfigurator.For(TabletopTweaks.Core.Utilities.FeatTools.Selections.RangerStyleShieldSelection6.AssetGuidThreadSafe).AddToAllFeatures(Prodigious.AssetGuidThreadSafe);
            FeatureSelectionConfigurator.For(TabletopTweaks.Core.Utilities.FeatTools.Selections.RangerStyleShieldSelection10.AssetGuidThreadSafe).AddToAllFeatures(Prodigious.AssetGuidThreadSafe);

            


        }

        public static void AddTwoWeaponDefense()
        {
            if (Settings.IsDisabled("ProdigiousTWF")) { return; }
            BlueprintFeature TWD = BlueprintTools.GetBlueprint<BlueprintFeature>("3eee747139f94b1d8d672c8bb63137d7");
            if (TWD != null)
            {
                Helpers.MoreFeatTools.PatchFeatWithFeatLockedAlternateAbilityPrereqSimple(TWD, StatType.Dexterity, Prodigious, StatType.Strength);
            }
        }

    }
}

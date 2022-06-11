using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.New_Components.Prerequisites;

namespace TomeOfTheFirebird.New_Content.Feats
{
    public static class BreathWeaponFeats
    {
        private static string[] SorcBloodlineBreathWeaponFeatureIDs = new string[] { "73939e14b956b884688a6e1dccf9c043", "a2a2caf3f73681643b0251c5561ce6ce", "9d7bb2a6d590ba0498992f6ce825f2cc", "e86286b52aeefb540a67c3c1af235167", "63718b3248898134eba94a139ea07313", "fcf0cb61b79b6fd47a6ed91f40820cea", "4d107a429575cb344bcba32a5b1a6abe", "9cbaf9563f8f6fb47810e0cbeb5e93ed", "a1cde01a9790834449d8f547ca52fc88", "a24420dcf53ad834783c0945882371d6" };

        private static string[] BloodragerBloodlineBreathWeaponFeatureIDs = new string[]
        {
            "9eb3980b50eff064090fb14c717e047e", "1eb9903ed2600574fa76d2545a1a55ac", "d3ab2068d426f224a89e3da640eb762d", "add37a4af38aab345a82e1c572770bbd", "c77f94d216144f145a3a4b4e615b4e87", "7dcfe929bc9003a45b1d4c5adf00be11","20693da8f467f6943931245f167e17a6","df0ff44d6fe42b543bd471342afcbc41","76148c4ea58ea40419a649b0f66ba5c9","7f9e9c9bb4d82e1469112283d9e6645d"
        };

        private static string[] ScaledFistBreathWeaponFeatureIDs = new string[]
        {
            "95784ae1838c0e14ba145ec1573f60fc",
             "b88794e3937a03e4d95f3048df2e6b85",
            "7497d32115317b643a7e76cfa9caf264",
                "a8c7ba9330f14b343b58210174a800ed",
        "d88d9faea279e8142adbda357bcc8377",
        "a546282f300c1d44f975cee6e01ebded",
        "463c31d209d21e340bc66cab9df728d7",
        "1ef82ad84f1691346af86067ed3d1f93",
        "9853668113c414d4d9053577e5cc1e32",
        "9e6f6a240b022c346b16038b20c238ce"

        };

      

        private static BlueprintFeature AbilityFocusBreathWeapons;

        private static BlueprintFeature EnergizedMaw;
        public static void BuildBreathWeaponFeats()
        {
            

        }

        public static void BuildAbilityFocusBreathWeapons()
        {
            var abilityFocusconfig = MakerTools.MakeFeature("AbilityFocusBreathWeapon", "Ability Focus - Breath Weapons", "Add +2 to breath weapon DCs");
            abilityFocusconfig.AddIncreaseSpellDescriptorDC(descriptor: new Kingmaker.Blueprints.Classes.Spells.SpellDescriptorWrapper(Kingmaker.Blueprints.Classes.Spells.SpellDescriptor.BreathWeapon), bonusDC: 2);

            abilityFocusconfig.AddToGroups(FeatureGroup.Feat);
            abilityFocusconfig.SetRanks(1);
            abilityFocusconfig.AddComponent<PrerequisiteBreathWeaponAccess>();

            var finished = abilityFocusconfig.Configure();
            if (Main.TotFContext.NewContent.Feats.IsDisabled("AbilityFocusBreathWeapons"))
                return;
            TabletopTweaks.Core.Utilities.FeatTools.AddAsFeat(finished);

        }

        public static void RegisterBreathAttack(BlueprintAbility breathAttack, bool worksAsPrequisite)
        {

        }

        public static void RegisterBreathEnabledShapeshift(BlueprintAbility blueprint)
        {

        }

    }
}

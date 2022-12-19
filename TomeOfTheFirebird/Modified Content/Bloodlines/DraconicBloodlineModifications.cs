using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Components;
using System.Linq;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Components;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.Modified_Content.Bloodlines
{
    class DraconicBloodlineModifications
    {
        public static string[] AllBaseGameDragonClawAbilities = new string[] {"120e51788082260498a961a38a4fa617",
                "f845e496f8f01d04f8f7c67b62151801",
                "ffebbc8fc1fc8b7449bdec1fab0779f4",
                "55fd2d4b5906d4d4f95f82dcc0bd6b1e",
                "f83de96081f99be47ae13beb8515211e",
                "a9afa9dbbf5c8f341bdb1ac801bf2a37",
                "962c818a4eb6bda48807e60d17dee876",
                "a8a647bf71f901240bb72648580b5f9e",
                "35d83033ca2abd14e83b8a41453ccb61",
                "93d053a695996ab4f8d5ed73a3ad1978",
                "66540e66ecead3649a282d3e340e9157",
                "0531d089e8bf4bd49867986a18a3ce4d",
                "01b84b8b79477a74481f19b9dd7b1fbd",
                "e4d48aeacde77254b9df3e8e17d5dd86",
                "6c9a37ae130da1a46b48113e91ffee36",
                "6c3e365ac6c28f947b5f3d9eebe94948",
                "424b28f3c0807db46a537b150092b3e3",
                "0fed2fbd0398bc548ab11c34179e3e52",
                "9644b6178d554154aa0de16a586fe7bf",
                "83df4e26aec72f74fb0a250f769cb2b9",
                "468aec11b69c64040929a0eb231c190b",
                "184117d257a92db47a626f89a9a7260c",
                "4dd112a5d15928d4da1f0651f9ae3816",
                "3a27e888cae24684695182fc53554261",
                "cc21b60762191b04eb1f3d1e30679b62",
                "b0d7e27160e9f0c4facfe37eda07e201",
                "e8177155408433c489c70028c823faf9",
                "dd1584878ecc429479773a8580394a3c",
                "8c9716bc50496f1488c8a418b9fc7d05",
                "eb0b2789613d0964eb73efd29ac67f67",
                "572c8c6d25eafc44bb6df322e14541f1",
                "776868fba5e120e429276434113042d9",
                "2caa6f370fbb5b34ab6ad307f0d93708",
                "e6fd21a3a07e4654089a39eb666e789b",
                "a0a8b8e7950f2b648af38095e76aa146",
                "85f3e48a9278b2e499582a3e5e3bda17",
                "a7379e2173493644088dec6f09158038",
                "87e7081370c84ba4faa4ea1ac0d173d2",
                "dd9768b309bdcbc43ae46102963fc211",
                "f617ad00079a75149949f79a3c15ee4a"};

        public static void BloodragerClawsOverhaul()
        {
            BlueprintBuff dragonRageBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("feff8e3877842f04c814d88dad8c8e7b");
            Conditional clawConditional = dragonRageBuff.Components.OfType<AddFactContextActions>().FirstOrDefault().Activated.Actions.OfType<Conditional>().FirstOrDefault(x => x.Comment == "Claws");
            if (clawConditional != null)
            {
                ConditionsBuilder newConditions = ConditionsBuilder.New().UseOr().HasFact("fdc6fd17009e61841a37f19deab50276").HasFact("3c7ad8aeb928f4143b7acc6f312a5671").HasFact("883412103cd588048b8bef5d76166e18").HasFact("dea42f81cb4a6c54fb2ba6395df7694f");
                clawConditional.ConditionsChecker = newConditions.Build();
                ActionsBuilder buildMaxLevelCascade = ActionsBuilder.New();

                
            }
            else
            {
                Main.TotFContext.Logger.Log("No Fishing For Claw COnditional Via Commanets");
            }
        }

        public static void SorcererClawsOverhaul()
        {

            string clawsDisplayName = "Dragon Claws";
            string clawsDesc = "Starting at 1st level, you can grow claws as a {g|Encyclopedia:Free_Action}free action{/g}. These claws are treated as {g|Encyclopedia:NaturalAttack}natural weapons{/g}, allowing you to make two claw {g|Encyclopedia:Attack}attacks{/g} as a full attack using your full {g|Encyclopedia:BAB}base attack bonus{/g}. Each of these attacks deals {g|Encyclopedia:Dice}1d4{/g} points of {g|Encyclopedia:Damage}damage{/g} plus your {g|Encyclopedia:Strength}Strength{/g} modifier (1d3 if you are Small). At 5th level, these claws are considered magic weapons for the purpose of overcoming {g|Encyclopedia:Damage_Reduction}DR{/g}. At 7th level, the damage increases by one step to 1d6 points of damage (1d4 if you are Small). At 11th level, these claws deal an additional 1d6 points of energy damage (type based on bloodline) on a successful hit. You can use your claws for a number of {g|Encyclopedia:Combat_Round}rounds{/g} per day equal to 3 + your {g|Encyclopedia:Charisma}Charisma{/g} modifier. These rounds do not need to be consecutive.";

            string[] blackDragSorcBloodlines = new string[] { "327c2663562f449280f698453c4efb4f", "7bd143ead2d6c3a409aad6ee22effe34", "cf448fafcd8452d4b830bcc9ca074189" };
            string[] whiteDragSorcBloodlines = new string[] { "fb85bb989c6645c095964708896e4c04", "b0f79497a0d1f4f4b8293e82c8f8fa0c", "7572e8c020a6b8a46bde3ab3ad8c6f70" };
            string[] redDragSorcBloodlines = new string[] { "98339eb151d643e79ef5608754047c4c", "8c6e5b3cf12f71e43949f52c41ae70a8", "d69a7785de1959c4497e4ff1e9490509" };
            string[] blueDragSorcBloodlines = new string[] { "eef4da3b9b4d4ab998ea1da43a310d46", "8a7f100c02d0b254d8f5f3affc8ef386", "82f76646a7f96ed4cafa18480adc0b8c" };
            string[] greenDragSorcBloodlines = new string[] { "3b85c2f9a43a4229ad59a9b684656c89", "7181be57d1cc3bc40bc4b552e4e4ce24", "6de526eeee72852448c5595f7a44a39d" };
            string[] goldDragSorcBloodlines = new string[] { "8db965d1e6ba4bb4877b8c6bd771ae68", "6c67ef823db8d7d45bb0ef82f959743d", "63c9d62a56e6921409a58de1ab9a9f9b" };
            string[] silverDragSorcBloodlines = new string[] { "a910e2dc166c4002b252fb9498d05066", "c7d2f393e6574874bb3fc728a69cc73a", "efabab987569bf54abf23848c250e4d5" };
            string[] bronzeDragSorcBloodlines = new string[] { "7e0f57d8d00464441974e303b84238ac", "7c0c303202114de4a87bfb46d01785ae", "468ecbdd58fbd6045a0a1888308031fe" };
            string[] copperDragSorcBloodlines = new string[] { "15c19f66ecc3426f809d9ad9bbad19e7", "b522759a265897b4f8f7a1a180a692e4", "2ad98f60b29ae604da0297037054080c" };
            string[] brassDragSorcBloodlines = new string[] { "7d90505fc2bd41ea9fbbd10bacd0fdd4", "5f9ecbee67db8364985e9d0500eb25f1", "c355b8777a3bda7429d863367bda3851" };

            string[][] allbloodlines = new string[][] { blackDragSorcBloodlines, whiteDragSorcBloodlines, redDragSorcBloodlines, blueDragSorcBloodlines, greenDragSorcBloodlines, goldDragSorcBloodlines, silverDragSorcBloodlines, bronzeDragSorcBloodlines, copperDragSorcBloodlines, brassDragSorcBloodlines };

            string t1DragonClawsGUID = "8700c7fd098671b438f51d11568c2c94";
            BlueprintItemWeapon t1claws = BlueprintTools.GetBlueprint<BlueprintItemWeapon>(t1DragonClawsGUID);

            bool hideclawFeatures = false;

            BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator t1Feature = MakerTools.MakeFeature("DragonClaws1d4DamageFeature", clawsDisplayName, clawsDesc, false, t1claws.Icon);
            t1Feature.AddAbilityResources(restoreAmount: true, resource: "5be91334e3de5aa458ade509cc16daff");

            BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator realt1Feature = MakerTools.MakeFeature("DragonClaws1d4DamageRealFeature", "DragonClawsT1", "", true);
            t1Feature.SetIsClassFeature(true).SetRanks(1);
            realt1Feature.SetIsClassFeature(true).SetRanks(1);


            BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator t2Feature = MakerTools.MakeFeature("DragonClaws1d4MagicDamageFeature", "DragonClawsT2", "", true);
            BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator realt2Feature = MakerTools.MakeFeature("DragonClaws1d4MagicDamageRealFeature", "DragonClawsT2", "", true);
            t2Feature.SetIsClassFeature(true).SetRanks(1);
            t2Feature.AddRemoveFeatureOnApply("DragonClaws1d4DamageRealFeature");
            realt2Feature.SetIsClassFeature(true).SetRanks(1);

            

            t1Feature.AddFeatureIfHasFact("DragonClaws1d4MagicDamageFeature", "DragonClaws1d4DamageRealFeature", not: true);

            BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator t3Feature = MakerTools.MakeFeature("DragonClaws1d6MagicDamageFeature", "DragonClawsT3", "", true);
            BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator realt3Feature = MakerTools.MakeFeature("DragonClaws1d6MagicDamageRealFeature", "DragonClawsT3", "", true);
            t3Feature.SetIsClassFeature(true).SetRanks(1);
            realt3Feature.SetIsClassFeature(true).SetRanks(1);
            t3Feature.AddRemoveFeatureOnApply("DragonClaws1d4MagicDamageRealFeature");
            t2Feature.AddFeatureIfHasFact("DragonClaws1d6MagicDamageFeature", "DragonClaws1d4MagicDamageRealFeature", not: true);

            BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator t4Feature = MakerTools.MakeFeature("DragonClaws1d6EnergyDamageFeature", "DragonClawsT4", "", true);
           
            t4Feature.SetIsClassFeature(true).SetRanks(1);
            t3Feature.AddRemoveFeatureOnApply("DragonClaws1d4MagicDamageRealFeature");
            t3Feature.AddFeatureIfHasFact("DragonClaws1d6EnergyDamageFeature", "DragonClaws1d6MagicDamageRealFeature", not: true);




            BuffConfigurator toggleBuff = MakerTools.MakeBuff("BloodlineDraconicUnifiedClawsBuffLevel1", clawsDisplayName, clawsDesc, t1claws.Icon);
            toggleBuff.AddEmptyHandWeaponOverride(weapon: "8700c7fd098671b438f51d11568c2c94");
            toggleBuff.SetIsClassFeature(true);
            toggleBuff.SetFlags(BlueprintBuff.Flags.StayOnDeath);
            toggleBuff.SetRanks(1);

            BuffConfigurator toggleBuff2 = MakerTools.MakeBuff("BloodlineDraconicUnifiedClawsBuffLevel2", clawsDisplayName, clawsDesc, t1claws.Icon);
            toggleBuff2.AddEmptyHandWeaponOverride(weapon: "8700c7fd098671b438f51d11568c2c94");
            toggleBuff2.AddOutgoingPhysicalDamageProperty(checkWeaponType: true, weaponType: "d4f7aee36efe0b54e810c9d3407b6ab3", addMagic: true);
            toggleBuff2.SetIsClassFeature(true);
            toggleBuff.SetRanks(1);
            toggleBuff2.SetFlags(BlueprintBuff.Flags.StayOnDeath);

            BuffConfigurator toggleBuff3 = MakerTools.MakeBuff("BloodlineDraconicUnifiedClawsBuffLevel3", clawsDisplayName, clawsDesc, t1claws.Icon);
            toggleBuff3.AddEmptyHandWeaponOverride(weapon: "18dc77b96c009804399c834e028d0552");
            toggleBuff3.AddOutgoingPhysicalDamageProperty(checkWeaponType: true, weaponType: "d4f7aee36efe0b54e810c9d3407b6ab3", addMagic: true);
            toggleBuff3.SetIsClassFeature(true);
            toggleBuff3.SetFlags(BlueprintBuff.Flags.StayOnDeath);
            toggleBuff3.SetRanks(1);

            BuffConfigurator toggleBuff4 = MakerTools.MakeBuff("BloodlineDraconicUnifiedClawsBuffLevel4", clawsDisplayName, clawsDesc, t1claws.Icon);
            toggleBuff4.AddEmptyHandWeaponOverride(weapon: "18dc77b96c009804399c834e028d0552");
            toggleBuff4.AddOutgoingPhysicalDamageProperty(checkWeaponType: true, weaponType: "d4f7aee36efe0b54e810c9d3407b6ab3", addMagic: true);
            toggleBuff4.SetIsClassFeature(true);
            toggleBuff4.SetFlags(BlueprintBuff.Flags.StayOnDeath);
            toggleBuff4.SetRanks(1);

            MakeExtraDice(toggleBuff4, DamageEnergyType.Acid, blackDragSorcBloodlines);
            MakeExtraDice(toggleBuff4, DamageEnergyType.Fire, redDragSorcBloodlines);
            MakeExtraDice(toggleBuff4, DamageEnergyType.Cold, whiteDragSorcBloodlines);
            MakeExtraDice(toggleBuff4, DamageEnergyType.Acid, greenDragSorcBloodlines);
            MakeExtraDice(toggleBuff4, DamageEnergyType.Electricity, blueDragSorcBloodlines);
            MakeExtraDice(toggleBuff4, DamageEnergyType.Fire, goldDragSorcBloodlines);
            MakeExtraDice(toggleBuff4, DamageEnergyType.Cold, silverDragSorcBloodlines);
            MakeExtraDice(toggleBuff4, DamageEnergyType.Fire, brassDragSorcBloodlines);
            MakeExtraDice(toggleBuff4, DamageEnergyType.Electricity, bronzeDragSorcBloodlines);
            MakeExtraDice(toggleBuff4, DamageEnergyType.Acid, copperDragSorcBloodlines);


            toggleBuff.SetStacking(StackingType.Replace);
            toggleBuff2.SetStacking(StackingType.Replace);
            toggleBuff3.SetStacking(StackingType.Replace);
            toggleBuff4.SetStacking(StackingType.Replace);
            toggleBuff.Configure();
            toggleBuff2.Configure();
            toggleBuff3.Configure();
            toggleBuff4.Configure();







            BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities.ActivatableAbilityConfigurator toggle1 = MakerTools.MakeToggle("DragonClawsT1ActivatableAbility", clawsDisplayName, clawsDesc, t1claws.Icon);
            BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities.ActivatableAbilityConfigurator toggle2 = MakerTools.MakeToggle("DragonClawsT2ActivatableAbility", clawsDisplayName, clawsDesc, t1claws.Icon);
            BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities.ActivatableAbilityConfigurator toggle3 = MakerTools.MakeToggle("DragonClawsT3ActivatableAbility", clawsDisplayName, clawsDesc, t1claws.Icon);
            BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities.ActivatableAbilityConfigurator toggle4 = MakerTools.MakeToggle("DragonClawsT4ActivatableAbility", clawsDisplayName, clawsDesc, t1claws.Icon);
            
            
            toggle1.SetBuff("BloodlineDraconicUnifiedClawsBuffLevel1");
            toggle2.SetBuff("BloodlineDraconicUnifiedClawsBuffLevel2");
            toggle3.SetBuff("BloodlineDraconicUnifiedClawsBuffLevel3");
            toggle4.SetBuff("BloodlineDraconicUnifiedClawsBuffLevel4");
            


            toggle1.SetActivationType(Kingmaker.UnitLogic.ActivatableAbilities.AbilityActivationType.WithUnitCommand);
            toggle2.SetActivationType(Kingmaker.UnitLogic.ActivatableAbilities.AbilityActivationType.WithUnitCommand);
            toggle3.SetActivationType(Kingmaker.UnitLogic.ActivatableAbilities.AbilityActivationType.WithUnitCommand);
            toggle4.SetActivationType(Kingmaker.UnitLogic.ActivatableAbilities.AbilityActivationType.WithUnitCommand);
            if (Main.TotFContext.Tweaks.Bloodlines.IsDisabled("UnlimitedSorcererBloodlineClaws"))
            {
                toggle1.AddActivatableAbilityResourceLogic(spendType: Kingmaker.UnitLogic.ActivatableAbilities.ActivatableAbilityResourceLogic.ResourceSpendType.NewRound, requiredResource:  "5be91334e3de5aa458ade509cc16daff").SetDeactivateImmediately(true).SetDeactivateIfCombatEnded(true);
                toggle2.AddActivatableAbilityResourceLogic(spendType: Kingmaker.UnitLogic.ActivatableAbilities.ActivatableAbilityResourceLogic.ResourceSpendType.NewRound, requiredResource:  "5be91334e3de5aa458ade509cc16daff").SetDeactivateImmediately(true).SetDeactivateIfCombatEnded(true);
                toggle3.AddActivatableAbilityResourceLogic(spendType: Kingmaker.UnitLogic.ActivatableAbilities.ActivatableAbilityResourceLogic.ResourceSpendType.NewRound, requiredResource:  "5be91334e3de5aa458ade509cc16daff").SetDeactivateImmediately(true).SetDeactivateIfCombatEnded(true);
                toggle4.AddActivatableAbilityResourceLogic(spendType: Kingmaker.UnitLogic.ActivatableAbilities.ActivatableAbilityResourceLogic.ResourceSpendType.NewRound, requiredResource:  "5be91334e3de5aa458ade509cc16daff").SetDeactivateImmediately(true).SetDeactivateIfCombatEnded(true);
                
                
            }
            else
            {
                toggle1.SetDeactivateIfCombatEnded(false).SetOnlyInCombat(false).SetDoNotTurnOffOnRest(true);
                toggle2.SetDeactivateIfCombatEnded(false).SetOnlyInCombat(false).SetDoNotTurnOffOnRest(true);
                toggle3.SetDeactivateIfCombatEnded(false).SetOnlyInCombat(false).SetDoNotTurnOffOnRest(true);
                toggle4.SetDeactivateIfCombatEnded(false).SetOnlyInCombat(false).SetDoNotTurnOffOnRest(true);

                foreach (string s in AllBaseGameDragonClawAbilities)
                {
                    BlueprintActivatableAbility claw = BlueprintTools.GetBlueprint<BlueprintActivatableAbility>(s);
                    claw.RemoveComponents<ActivatableAbilityResourceLogic>();
                    claw.DeactivateIfCombatEnded = false;
                    claw.OnlyInCombat = false;
                    claw.DeactivateImmediately = false;
                }
            }


            BlueprintActivatableAbility toggle1Build = toggle1.Configure();


            BlueprintActivatableAbility toggle2Build = toggle2.Configure();
            BlueprintActivatableAbility toggle3Build = toggle3.Configure();
            BlueprintActivatableAbility toggle4Build = toggle4.Configure();

            realt1Feature.AddFacts(new System.Collections.Generic.List<BlueprintCore.Utils.Blueprint<BlueprintUnitFactReference>>() { "DragonClawsT1ActivatableAbility" });
            realt2Feature.AddFacts(new System.Collections.Generic.List<BlueprintCore.Utils.Blueprint<BlueprintUnitFactReference>>() { "DragonClawsT2ActivatableAbility" });
            realt3Feature.AddFacts(new System.Collections.Generic.List<BlueprintCore.Utils.Blueprint<BlueprintUnitFactReference>>() { "DragonClawsT3ActivatableAbility" });
            t4Feature.AddFacts(new System.Collections.Generic.List<BlueprintCore.Utils.Blueprint<BlueprintUnitFactReference>>() { "DragonClawsT4ActivatableAbility" });
            BlueprintProgression blackBloodline = BlueprintTools.GetBlueprint<BlueprintProgression>("7bd143ead2d6c3a409aad6ee22effe34");





            BlueprintFeature t1build = t1Feature.Configure();
            realt1Feature.Configure();
            BlueprintFeature t2build = t2Feature.Configure();
            realt2Feature.Configure();
            BlueprintFeature t3build = t3Feature.Configure();
            realt3Feature.Configure();
            BlueprintFeature t4build = t4Feature.Configure();
           
            if (Main.TotFContext.Tweaks.Bloodlines.IsDisabled("CombineSorcererDragonClaws"))
                return;
            


            foreach (string s in allbloodlines.SelectMany(x => x))
            {
                BlueprintProgression v = BlueprintTools.GetBlueprint<BlueprintProgression>(s);
                foreach (LevelEntry l in v.LevelEntries)
                {
                    l.m_Features.RemoveAll(x => x.NameSafe().Contains("ClawsFeatureAddLevel"));
                }
                v.LevelEntries.FirstOrDefault(x => x.Level == 1)?.m_Features.Add(t1build.ToReference<BlueprintFeatureBaseReference>());
                v.LevelEntries.FirstOrDefault(x => x.Level == 5)?.m_Features.Add(t2build.ToReference<BlueprintFeatureBaseReference>());
                v.LevelEntries.FirstOrDefault(x => x.Level == 7)?.m_Features.Add(t3build.ToReference<BlueprintFeatureBaseReference>());
                v.LevelEntries.FirstOrDefault(x => x.Level == 11)?.m_Features.Add(t4build.ToReference<BlueprintFeatureBaseReference>());
            }


            void MakeExtraDice(BuffConfigurator buff, DamageEnergyType dmg, string[] bloodlines)
            {
                buff.AddComponent<ContextWeaponCategoryExtraDamageDice>(x =>
                {
                    x.DamageDice = new Kingmaker.RuleSystem.DiceFormula(1, Kingmaker.RuleSystem.DiceType.D6);
                    x.categories = new Kingmaker.Enums.WeaponCategory[] { Kingmaker.Enums.WeaponCategory.Claw };
                    x.Element = new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription()
                    {
                        Energy = dmg
                    };
                    ConditionsBuilder conditionsBuilder = ConditionsBuilder.New().UseOr();
                    foreach (string s in bloodlines)
                    {
                        conditionsBuilder.HasFact(s);
                    }
                    x.wielderCondition = conditionsBuilder.Build();
                });
            }
        }

    }
}

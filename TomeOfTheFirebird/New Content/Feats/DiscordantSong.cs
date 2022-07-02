using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using System.Linq;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.New_Content.Feats
{
    public class DiscordantSong
    {
        public static void Make()
        {
            var friendCondition = ConditionsBuilder.New().IsAlly();
            var enemyCondition = ConditionsBuilder.New().IsEnemy();
            var sound_burst = BlueprintTools.GetBlueprint<BlueprintAbility>("c3893092a333b93499fd0a21845aa265");
            string aoeFriendlyName = "DiscordantSongAreaOfEffectFriendly";
            string aoeEnemyName = "DiscordantSongAreaOfEffectHostile";
         
            var aoeFriendlyGUID = Main.TotFContext.Blueprints.GetGUID(aoeFriendlyName);
            var aoeHostileGUID = Main.TotFContext.Blueprints.GetGUID(aoeEnemyName);
            var DiscordantSongAllyBuff = MakerTools.MakeBuff("DiscordantSongAllyBuff", "Discordant Song (Friendly)", "Bardic performance is granting an extra 1d6 sonic damage to melee attacks and ranged attacks to targets in the performance area.", sound_burst.Icon);
            
            var DiscordantSongEnemyBuff = MakerTools.MakeBuff("DiscordantSongEnemyBuff", "Discordant Song (Hostile)", "Discordant Song is causing extra sonic damage on ranged hits.", sound_burst.Icon);
            var DiscordantSongEnemyBuffMade = DiscordantSongEnemyBuff.Configure();

            DiscordantSongAllyBuff.AdditionalDiceOnAttack(distanceLessEqual: new Kingmaker.Utility.Feet(),  attackType: Kingmaker.UnitLogic.Mechanics.Components.AdditionalDiceOnAttack.WeaponOptions.AllAttacks,  damageType: new DamageTypeDescription() { Type = DamageType.Energy, Energy = Kingmaker.Enums.Damage.DamageEnergyType.Sonic }, damageEntries: new(),  checkWeaponRangeType: true, rangeType: Kingmaker.Enums.WeaponRangeType.Melee, initiatorConditions: ConditionsBuilder.New(), targetConditions: ConditionsBuilder.New(), value: new Kingmaker.UnitLogic.Mechanics.ContextDiceValue() { BonusValue = 0, DiceCountValue = 1, DiceType = Kingmaker.RuleSystem.DiceType.D6 });
            
            DiscordantSongAllyBuff.AdditionalDiceOnAttack( distanceLessEqual:new Kingmaker.Utility.Feet(), attackType: Kingmaker.UnitLogic.Mechanics.Components.AdditionalDiceOnAttack.WeaponOptions.AllAttacks, damageType: new DamageTypeDescription() { Type = DamageType.Energy, Energy = Kingmaker.Enums.Damage.DamageEnergyType.Sonic }, damageEntries: new(), checkWeaponRangeType: true, rangeType: Kingmaker.Enums.WeaponRangeType.Ranged, initiatorConditions: ConditionsBuilder.New(), targetConditions: ConditionsBuilder.New().HasBuff("DiscordantSongEnemyBuff"), value: new Kingmaker.UnitLogic.Mechanics.ContextDiceValue() { BonusValue = 0, DiceCountValue = 1, DiceType = Kingmaker.RuleSystem.DiceType.D6 });

            var DiscordantSongAllyBuffMade = DiscordantSongAllyBuff.Configure();
            



            var DiscordantAoEFriendly = AbilityAreaEffectConfigurator.New(aoeFriendlyName, aoeFriendlyGUID.ToString());
            DiscordantAoEFriendly.SetFx(new Kingmaker.ResourceLinks.PrefabLink() {  });
            var DiscordantAoEHostile = AbilityAreaEffectConfigurator.New(aoeEnemyName, aoeHostileGUID.ToString());
            DiscordantAoEHostile.SetFx(new Kingmaker.ResourceLinks.PrefabLink() { });
            DiscordantAoEFriendly.SetTargetType(Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbilityAreaEffect.TargetType.Any);
            DiscordantAoEFriendly.SetIgnoreSleepingUnits(false);
            DiscordantAoEFriendly.SetShape(Kingmaker.UnitLogic.Abilities.Blueprints.AreaEffectShape.Cylinder);
            DiscordantAoEFriendly.SetSize(new Kingmaker.Utility.Feet(30f));
            
            DiscordantAoEFriendly.AddAbilityAreaEffectBuff(condition: friendCondition,  buff: DiscordantSongAllyBuffMade.AssetGuidThreadSafe);
     
            

               DiscordantAoEHostile.SetTargetType(Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbilityAreaEffect.TargetType.Enemy);
               DiscordantAoEHostile.SetIgnoreSleepingUnits(false);
               DiscordantAoEHostile.SetShape(Kingmaker.UnitLogic.Abilities.Blueprints.AreaEffectShape.Cylinder);
               DiscordantAoEHostile.SetSize(new Kingmaker.Utility.Feet(30f));
               DiscordantAoEHostile.AddAbilityAreaEffectBuff(condition: enemyCondition, buff: DiscordantSongEnemyBuffMade.AssetGuidThreadSafe);
               DiscordantAoEHostile.SetAggroEnemies(false);
               


            var DiscordantAoEFriendlyBuilt = DiscordantAoEFriendly.Configure();
            var DiscordantAoEHostileBuilt = DiscordantAoEHostile.Configure();
            var DiscordantSongBuff = MakerTools.MakeBuff("DiscordantSongBuff", "Performing Discordant Song", "Allies within 30 feet of you deal an extra 1d6 points of sonic damage with successful weapon attacks. This damage stacks with other energy damage a weapon might deal. Projectile weapons bestow this extra damage on their ammunition, but the extra damage is dealt only if the projectile hits a target within 30 feet of you.", sound_burst.Icon);
            var DiscordantSongBuff2 = MakerTools.MakeBuff("DiscordantSongBuff2", "Performing Discordant Song", "You Shouldn't See This!");
         
            Main.TotFContext.Logger.Log($"Friendly AOE Type is {DiscordantAoEFriendlyBuilt.GetType().ToString()}, guid is :{DiscordantAoEFriendlyBuilt.AssetGuidThreadSafe}");
            //DiscordantSongBuff.AddAreaEffect("79779e46999bca8469f9978a27fa58f7");
            //DiscordantSongBuff.AddAreaEffect("79779e46999bca8469f9978a27fa58f7");
            //DiscordantSongBuff.AddComponent(new AddAreaEffect() { m_AreaEffect = DiscordantAoEFriendlyBuilt.ToReference<BlueprintAbilityAreaEffectReference>() });
            DiscordantSongBuff.AddAreaEffect(DiscordantAoEFriendlyBuilt.AssetGuidThreadSafe);
            DiscordantSongBuff2.AddAreaEffect(DiscordantAoEHostileBuilt.AssetGuidThreadSafe);
            
            Main.TotFContext.Logger.Log("added friendly aoe");
           
            //DiscordantSongBuff.AddAreaEffect(DiscordantAoEHostileBuilt.AssetGuidThreadSafe);
            Main.TotFContext.Logger.Log("added enemy aoe");



            var DiscordantSongBuffMade = DiscordantSongBuff.Configure();
            var DiscordantSongBuff2Made = DiscordantSongBuff2.Configure();


           //DiscordantSongBuffMade.Components = DiscordantSongBuffMade.Components.Append(new AddAreaEffect() { m_AreaEffect = DiscordantAoEFriendlyBuilt.ToReference<BlueprintAbilityAreaEffectReference>() }).Append(new AddAreaEffect() { m_AreaEffect = DiscordantAoEHostileBuilt.ToReference<BlueprintAbilityAreaEffectReference>() }).ToArray();
           //DiscordantSongBuffMade.Components = DiscordantSongBuffMade.Components.Append(new AddAreaEffect() { m_AreaEffect = DiscordantAoEFriendlyBuilt.ToReference<BlueprintAbilityAreaEffectReference>() }).ToArray();


            var HatOfHearteningSong = BlueprintTools.GetBlueprint<BlueprintFeature>("c25df29d2599a81428a7badf51ebd4d1");
            var DiscordantFeatMaker = MakerTools.MakeFeature("DiscordantSong", "Discordant Song", "Whenever you are using bardic performance to create a spell-like or supernatural effect, allies within 30 feet of you deal an extra 1d6 points of sonic damage with successful weapon attacks. This damage stacks with other energy damage a weapon might deal. Projectile weapons bestow this extra damage on their ammunition, but the extra damage is dealt only if the projectile hits a target within 30 feet of you.");
            DiscordantFeatMaker.SetRanks(1);
            DiscordantFeatMaker.SetGroups(FeatureGroup.Feat);

            foreach(var v in HatOfHearteningSong.Components.OfType<BuffExtraEffects>())
            {
                DiscordantFeatMaker.AddBuffExtraEffects(v.CheckedBuff.AssetGuidThreadSafe, DiscordantSongBuffMade.AssetGuidThreadSafe);
                DiscordantFeatMaker.AddBuffExtraEffects(v.CheckedBuff.AssetGuidThreadSafe, DiscordantSongBuff2Made.AssetGuidThreadSafe);

            }
            //Bard or Skald
            DiscordantFeatMaker.AddPrerequisiteClassLevel("772c83a25e2268e448e841dcd548235f", 10, group: Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any);
            DiscordantFeatMaker.AddPrerequisiteClassLevel("6afa347d804838b48bda16acb0573dc0", 10, group: Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any);
            DiscordantFeatMaker.AddPrerequisiteArchetypeLevel(characterClass:"bfa11238e7ae3544bbeb4d0b92e897ec", archetype: "4d9a864eae278744aafa7ff23f2a6466", level: 10, group: Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any);
            DiscordantFeatMaker.AddPrerequisiteArchetypeLevel(characterClass:"e8f21e5b58e0569468e420ebea456124", archetype: "f8767821ec805bf479706392fcc3394c", level: 10, group: Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any); ;

            var DiscordantSong = DiscordantFeatMaker.Configure();

            if (Main.TotFContext.NewContent.Feats.IsEnabled("DiscordantSong"))
            {
                TabletopTweaks.Core.Utilities.FeatTools.AddAsFeat(DiscordantSong);
                




                FeatureSelectionConfigurator.For("94e2cd84bf3a8e04f8609fe502892f4f").AddToAllFeatures(DiscordantSong.AssetGuidThreadSafe);
                FeatureSelectionConfigurator.For("d2a8fde8985691045b90e1ec57e3cc57").AddToAllFeatures(DiscordantSong.AssetGuidThreadSafe);


            }
            


            //Make Feature

            //Add to feats / bard selector

            //Clone the apply area effect system from ze hat

            //Will need new feature



        }

    }
}

using BlueprintCore.Blueprints.Configurators.Abilities;
using BlueprintCore.Blueprints.Configurators.Buffs;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.AreaEffects;
using Kingmaker.UnitLogic.Buffs.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.Config;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.New_Content.Feats
{
    public class DiscordantSong
    {
        public static void Make()
        {
            var friendCondition = ConditionsBuilder.New().ContextConditionIsAlly();
            var enemyCondition = ConditionsBuilder.New().ContextConditionIsEnemy();
            var sound_burst = Resources.GetBlueprint<BlueprintAbility>("c3893092a333b93499fd0a21845aa265");
            string aoeFriendlyName = "DiscordantSongAreaOfEffectFriendly";
            string aoeEnemyName = "DiscordantSongAreaOfEffectHostile";
         
            var aoeFriendlyGUID = ModSettings.Blueprints.GetGUID(aoeFriendlyName);
            var aoeHostileGUID = ModSettings.Blueprints.GetGUID(aoeEnemyName);
            var DiscordantSongAllyBuff = MakerTools.MakeBuff("DiscordantSongAllyBuff", "Discordant Song", "Temp: Song grants 1d6 sonic damage", sound_burst.Icon);
            
            var DiscordantSongEnemyBuff = MakerTools.MakeBuff("DiscordantSongEnemyBuff", "Discordant Song", "Temp: Valid Target For Discordant Song Shooting", sound_burst.Icon);
            var DiscordantSongEnemyBuffMade = DiscordantSongEnemyBuff.Configure();

            DiscordantSongAllyBuff.AdditionalDiceOnAttack(new Kingmaker.Utility.Feet(0f), new DamageTypeDescription() { Type = DamageType.Energy, Energy = Kingmaker.Enums.Damage.DamageEnergyType.Sonic }, checkWeaponRangeType: true, rangeType: Kingmaker.Enums.WeaponRangeType.Melee, initiatorConditions: ConditionsBuilder.New(), targetConditions: ConditionsBuilder.New(), value: new Kingmaker.UnitLogic.Mechanics.ContextDiceValue() { BonusValue = 0, DiceCountValue = 1, DiceType = Kingmaker.RuleSystem.DiceType.D6 });
          
            DiscordantSongAllyBuff.AdditionalDiceOnAttack(new Kingmaker.Utility.Feet(0f), new DamageTypeDescription() { Type = DamageType.Energy, Energy = Kingmaker.Enums.Damage.DamageEnergyType.Sonic }, checkWeaponRangeType: true, rangeType: Kingmaker.Enums.WeaponRangeType.Ranged, initiatorConditions: ConditionsBuilder.New(), targetConditions: ConditionsBuilder.New().ContextConditionHasBuff(DiscordantSongEnemyBuffMade.AssetGuidThreadSafe), value: new Kingmaker.UnitLogic.Mechanics.ContextDiceValue() { BonusValue = 0, DiceCountValue = 1, DiceType = Kingmaker.RuleSystem.DiceType.D6 });

            var DiscordantSongAllyBuffMade = DiscordantSongAllyBuff.Configure();
            



            var DiscordantAoEFriendly = AbilityAreaEffectConfigurator.New(aoeFriendlyName, aoeFriendlyGUID.ToString());
            DiscordantAoEFriendly.SetFx(new Kingmaker.ResourceLinks.PrefabLink() {  });
            var DiscordantAoEHostile = AbilityAreaEffectConfigurator.New(aoeEnemyName, aoeHostileGUID.ToString());
            DiscordantAoEHostile.SetFx(new Kingmaker.ResourceLinks.PrefabLink() { });
            DiscordantAoEFriendly.SetTargetType(Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbilityAreaEffect.TargetType.Any);
            DiscordantAoEFriendly.SetIgnoreSleepingUnits(false);
            DiscordantAoEFriendly.SetShape(Kingmaker.UnitLogic.Abilities.Blueprints.AreaEffectShape.Cylinder);
            DiscordantAoEFriendly.SetSize(30);
            
            DiscordantAoEFriendly.AddAbilityAreaEffectBuff(friendCondition,  buff: DiscordantSongAllyBuffMade.AssetGuidThreadSafe);
     
            

               DiscordantAoEHostile.SetTargetType(Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbilityAreaEffect.TargetType.Enemy);
               DiscordantAoEHostile.SetIgnoreSleepingUnits(false);
               DiscordantAoEHostile.SetShape(Kingmaker.UnitLogic.Abilities.Blueprints.AreaEffectShape.Cylinder);
               DiscordantAoEHostile.SetSize(30);
               DiscordantAoEHostile.AddAbilityAreaEffectBuff(enemyCondition, buff: DiscordantSongEnemyBuffMade.AssetGuidThreadSafe);
               DiscordantAoEHostile.SetAggroEnemies(false);
               


            var DiscordantAoEFriendlyBuilt = DiscordantAoEFriendly.Configure();
            var DiscordantAoEHostileBuilt = DiscordantAoEHostile.Configure();
            var DiscordantSongBuff = MakerTools.MakeBuff("DiscordantSongBuff", "Performing Discordant Song", "Temp: Song grants 1d6 sonic damage", sound_burst.Icon);
            var DiscordantSongBuff2 = MakerTools.MakeBuff("DiscordantSongBuff2", "Performing Discordant Song", "Temp: Song grants 1d6 sonic damage");
            Main.Log($"Friendly AOE Type is {DiscordantAoEFriendlyBuilt.GetType().ToString()}, guid is :{DiscordantAoEFriendlyBuilt.AssetGuidThreadSafe}");
            //DiscordantSongBuff.AddAreaEffect("79779e46999bca8469f9978a27fa58f7");
            //DiscordantSongBuff.AddAreaEffect("79779e46999bca8469f9978a27fa58f7");
            //DiscordantSongBuff.AddComponent(new AddAreaEffect() { m_AreaEffect = DiscordantAoEFriendlyBuilt.ToReference<BlueprintAbilityAreaEffectReference>() });
            DiscordantSongBuff.AddAreaEffect(DiscordantAoEFriendlyBuilt.AssetGuidThreadSafe);
            DiscordantSongBuff.AddAreaEffect(DiscordantAoEHostileBuilt.AssetGuidThreadSafe);
            
            Main.Log("added friendly aoe");
           
            //DiscordantSongBuff.AddAreaEffect(DiscordantAoEHostileBuilt.AssetGuidThreadSafe);
            Main.Log("added enemy aoe");



            var DiscordantSongBuffMade = DiscordantSongBuff.Configure();
            var DiscordantSongBuff2Made = DiscordantSongBuff2.Configure();


           //DiscordantSongBuffMade.Components = DiscordantSongBuffMade.Components.Append(new AddAreaEffect() { m_AreaEffect = DiscordantAoEFriendlyBuilt.ToReference<BlueprintAbilityAreaEffectReference>() }).Append(new AddAreaEffect() { m_AreaEffect = DiscordantAoEHostileBuilt.ToReference<BlueprintAbilityAreaEffectReference>() }).ToArray();
           //DiscordantSongBuffMade.Components = DiscordantSongBuffMade.Components.Append(new AddAreaEffect() { m_AreaEffect = DiscordantAoEFriendlyBuilt.ToReference<BlueprintAbilityAreaEffectReference>() }).ToArray();


            var HatOfHearteningSong = Resources.GetBlueprint<BlueprintFeature>("c25df29d2599a81428a7badf51ebd4d1");
            var DiscordantFeatMaker = MakerTools.MakeFeature("DiscordantSong", "Discordant Song", "Temp: Song grants 1d6 sonic damage");
            DiscordantFeatMaker.SetRanks(1);
            DiscordantFeatMaker.SetFeatureGroups(FeatureGroup.Feat);

            foreach(var v in HatOfHearteningSong.Components.OfType<BuffExtraEffects>())
            {
                DiscordantFeatMaker.AddBuffExtraEffects(v.CheckedBuff.AssetGuidThreadSafe, DiscordantSongBuffMade.AssetGuidThreadSafe);
                DiscordantFeatMaker.AddBuffExtraEffects(v.CheckedBuff.AssetGuidThreadSafe, DiscordantSongBuff2Made.AssetGuidThreadSafe);

            }
            DiscordantFeatMaker.PrerequisiteClassLevel("772c83a25e2268e448e841dcd548235f", 10, group: Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any);
            DiscordantFeatMaker.PrerequisiteClassLevel("6afa347d804838b48bda16acb0573dc0", 10, group: Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any);

            var DiscordantSong = DiscordantFeatMaker.Configure();



            FeatTools.AddAsFeat(DiscordantSong);

            


            FeatureSelectionConfigurator.For("94e2cd84bf3a8e04f8609fe502892f4f").AddToFeatures(DiscordantSong.AssetGuidThreadSafe);
            FeatureSelectionConfigurator.For("d2a8fde8985691045b90e1ec57e3cc57").AddToFeatures(DiscordantSong.AssetGuidThreadSafe);



            


            //Make Feature

            //Add to feats / bard selector

            //Clone the apply area effect system from ze hat

            //Will need new feature



        }

    }
}

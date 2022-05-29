using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Components;
using TomeOfTheFirebird.Config;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.Reference;
using UnityEngine;

namespace TomeOfTheFirebird.New_Spells
{
    class ElementalShieldSpells
    {
        public static void Build()
        {
            Sprite shieldIcon = Resources.GetBlueprint<BlueprintAbility>("62888999171921e4dafb46de83f4d67d").Icon;
           

            var FireShieldWarmBuilder = MakerTools.MakeSpell("FireShieldWarm", "Fire Shield (Warm)", "This spell wreathes you in flame and causes damage to each creature that attacks you in melee.The flames also protect you from cold-based attacks. You take only half damage from cold-based attacks. If such an attack allows a Reflex save for half damage, you take no damage on a successful saving throw. \n Any creature striking you with its body or a hand-held weapon deals normal damage, but at the same time the attacker takes 1d6 points of fire damage + 1 point per caster level(maximum +15). If the attacker has spell resistance, it applies to this effect. Creatures wielding melee weapons with reach are not subject to this damage if they attack you.", shieldIcon, Kingmaker.Blueprints.Classes.Spells.SpellSchool.Evocation, new Kingmaker.Localization.LocalizedString(), LocalizedStrings.OneRoundPerLevelDuration);
            FireShieldWarmBuilder.AddSpellDescriptors(SpellDescriptor.Fire);
            var FireShieldColdBuilder = MakerTools.MakeSpell("FireShieldCold", "Fire Shield (Cold)", "This spell wreathes you in cold flame and causes damage to each creature that attacks you in melee.The flames also protect you from fire-based attacks. You take only half damage from fire-based attacks. If such an attack allows a Reflex save for half damage, you take no damage on a successful saving throw. \n Any creature striking you with its body or a hand-held weapon deals normal damage, but at the same time the attacker takes 1d6 points of cold damage + 1 point per caster level(maximum +15). If the attacker has spell resistance, it applies to this effect. Creatures wielding melee weapons with reach are not subject to this damage if they attack you.", shieldIcon, Kingmaker.Blueprints.Classes.Spells.SpellSchool.Evocation, new Kingmaker.Localization.LocalizedString(), LocalizedStrings.OneRoundPerLevelDuration);
            FireShieldColdBuilder.AddSpellDescriptors(SpellDescriptor.Cold);
            var VitrolicMistBuilder = MakerTools.MakeSpell("VitrolicMist", "Vitrolic Mist", "This spell wreathes you in acid mists and causes damage to each creature that attacks you in melee. The mists also protect you from acid-based attacks. You take only half damage from acid-based attacks. If such an attack allows a Reflex save for half damage, you take no damage on a successful saving throw. \n Any creature striking you with its body or a hand-held weapon deals normal damage, but at the same time the attacker takes 1d6 points of acid damage + 1 point per caster level(maximum +15). If the attacker has spell resistance, it applies to this effect. Creatures wielding melee weapons with reach are not subject to this damage if they attack you.", shieldIcon, Kingmaker.Blueprints.Classes.Spells.SpellSchool.Evocation, new Kingmaker.Localization.LocalizedString(), LocalizedStrings.OneRoundPerLevelDuration);
            VitrolicMistBuilder.AddSpellDescriptors(SpellDescriptor.Acid);

            FireShieldWarmBuilder.SetRange(AbilityRange.Personal).AllowTargeting(friends: true, self: true).SetAnimationStyle(Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Self).SetMetamagics(Metamagic.Quicken, Metamagic.Extend, Metamagic.Heighten, Metamagic.CompletelyNormal);
          
            FireShieldColdBuilder.SetRange(AbilityRange.Personal).AllowTargeting(friends: true, self: true).SetAnimationStyle(Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Self).SetMetamagics(Metamagic.Quicken, Metamagic.Extend, Metamagic.Heighten, Metamagic.CompletelyNormal);
       
            VitrolicMistBuilder.SetRange(AbilityRange.Personal).AllowTargeting(friends: true, self: true).SetAnimationStyle(Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Self).SetMetamagics(Metamagic.Quicken, Metamagic.Extend, Metamagic.Heighten, Metamagic.CompletelyNormal);
        

            var FireShieldWarmBuffBuilder = MakerTools.MakeBuff("FireShieldWarmBuff", "Fire Shield (Warm)", "You are wreathed in flame, causing damage to each creature that attacks you in melee. The flames also protect you from cold-based attacks. You take only half damage from cold-based attacks. If such an attack allows a Reflex save for half damage, you take no damage on a successful saving throw. \n Any creature striking you with its body or a hand-held weapon deals normal damage, but at the same time the attacker takes 1d6 points of fire damage + 1 point per caster level(maximum +15). If the attacker has spell resistance, it applies to this effect. Creatures wielding melee weapons with reach are not subject to this damage if they attack you.", shieldIcon).AddSpellDescriptors(SpellDescriptor.Fire);
            var FireShieldColdBuffBuilder = MakerTools.MakeBuff("FireShieldColdBuff", "Fire Shield (Cold)", "You are wreathed in cold flame, causing damage to each creature that attacks you in melee. The flames also protect you from fire-based attacks. You take only half damage from fire-based attacks. If such an attack allows a Reflex save for half damage, you take no damage on a successful saving throw. \n Any creature striking you with its body or a hand-held weapon deals normal damage, but at the same time the attacker takes 1d6 points of cold damage + 1 point per caster level(maximum +15). If the attacker has spell resistance, it applies to this effect. Creatures wielding melee weapons with reach are not subject to this damage if they attack you.", shieldIcon).AddSpellDescriptors(SpellDescriptor.Cold);

            
            var VitrolicMistBuffBuilder = MakerTools.MakeBuff("VitrolicMistBuff", "Vitrolic Mist", "You are wreathed in acid mists, causing damage to each creature that attacks you in melee. The mists also protect you from acid-based attacks. You take only half damage from acid-based attacks. If such an attack allows a Reflex save for half damage, you take no damage on a successful saving throw. \n Any creature striking you with its body or a hand-held weapon deals normal damage, but at the same time the attacker takes 1d6 points of acid damage + 1 point per caster level(maximum +15). If the attacker has spell resistance, it applies to this effect. Creatures wielding melee weapons with reach are not subject to this damage if they attack you.", shieldIcon).AddSpellDescriptors(SpellDescriptor.Acid);

            //TODO MAKE THE SR PART WORK
            ActionsBuilder fireBacklash = ActionsBuilder.New().DealDamage(new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription() { Type = Kingmaker.RuleSystem.Rules.Damage.DamageType.Energy, Energy = Kingmaker.Enums.Damage.DamageEnergyType.Fire }, value: new ContextDiceValue() { DiceCountValue = 1, BonusValue = new ContextValue() { ValueType = ContextValueType.Rank }, DiceType = Kingmaker.RuleSystem.DiceType.D6 });
            ActionsBuilder coldBacklash = ActionsBuilder.New().DealDamage(new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription() { Type = Kingmaker.RuleSystem.Rules.Damage.DamageType.Energy, Energy = Kingmaker.Enums.Damage.DamageEnergyType.Cold }, value: new ContextDiceValue() { DiceCountValue = 1, BonusValue = new ContextValue() { ValueType = ContextValueType.Rank }, DiceType = Kingmaker.RuleSystem.DiceType.D6 });
            ActionsBuilder acidBacklash = ActionsBuilder.New().DealDamage(new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription() { Type = Kingmaker.RuleSystem.Rules.Damage.DamageType.Energy, Energy = Kingmaker.Enums.Damage.DamageEnergyType.Acid }, value: new ContextDiceValue() { DiceCountValue = 1, BonusValue = new ContextValue() { ValueType = ContextValueType.Rank }, DiceType = Kingmaker.RuleSystem.DiceType.D6 });

            FireShieldWarmBuffBuilder.AddTargetAttackRollTrigger(true, onlyMelee: true, notReach: true, actionsOnAttacker: fireBacklash).AddContextRankConfig(new Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig() { m_Max = 15, m_UseMax = true }).AddComponent<ElementalBarrierDamageDivisor>(x => x.m_Type = Kingmaker.Enums.Damage.DamageEnergyType.Cold);

           
            FireShieldColdBuffBuilder.AddTargetAttackRollTrigger(true, onlyMelee: true, notReach: true, actionsOnAttacker: coldBacklash).AddContextRankConfig(new Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig() { m_Max = 15, m_UseMax = true }).AddComponent<ElementalBarrierDamageDivisor>(x => x.m_Type = Kingmaker.Enums.Damage.DamageEnergyType.Fire);
            VitrolicMistBuffBuilder.AddTargetAttackRollTrigger(true, onlyMelee: true, notReach: true, actionsOnAttacker: acidBacklash).AddContextRankConfig(new Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig() { m_Max = 15, m_UseMax = true }).AddComponent<ElementalBarrierDamageDivisor>(x => x.m_Type = Kingmaker.Enums.Damage.DamageEnergyType.Acid);

            var warmBuffBuilt = FireShieldWarmBuffBuilder.Configure();
            var coldBuffBuilt = FireShieldColdBuffBuilder.Configure();
            var acidBuffBuilt = VitrolicMistBuffBuilder.Configure();

            FireShieldWarmBuilder.RunActions(ActionsBuilder.New().ApplyBuff(warmBuffBuilt.AssetGuidThreadSafe, duration: MakerTools.GetContextDurationValue(DurationRate.Rounds, true), isFromSpell: true));
            FireShieldColdBuilder.RunActions(ActionsBuilder.New().ApplyBuff(coldBuffBuilt.AssetGuidThreadSafe, duration: MakerTools.GetContextDurationValue(DurationRate.Rounds, true), isFromSpell: true));
            VitrolicMistBuilder.RunActions(ActionsBuilder.New().ApplyBuff(acidBuffBuilt.AssetGuidThreadSafe, duration: MakerTools.GetContextDurationValue(DurationRate.Rounds, true), isFromSpell: true));

            var warmSpellBuilt = FireShieldWarmBuilder.Configure();
            var coldSpellBuilt = FireShieldColdBuilder.Configure();
            var acidSpellBuilt = VitrolicMistBuilder.Configure();

            var rootFireShieldBuilder = MakerTools.MakeSpell("FireShield", "Fire Shield", "This spell wreathes you in flame and causes damage to each creature that attacks you in melee.The flames also protect you from either cold-based or fire-based attacks, depending on if you choose cool or warm flames for your fire shield. \n Any creature striking you with its body or a hand-held weapon deals normal damage, but at the same time the attacker takes 1d6 points of damage + 1 point per caster level(maximum +15). This damage is either cold damage(if you choose a chill shield) or fire damage(if you choose a warm shield). If the attacker has spell resistance, it applies to this effect.Creatures wielding melee weapons with reach are not subject to this damage if they attack you.\n When casting this spell, you appear to immolate yourself, but the flames are thin and wispy, increasing the light level within 10 feet by one step, up to normal light.The color of the flames is blue or green if the chill shield is cast, violet or red if the warm shield is employed.The special powers of each version are as follows. \nChill Shield: The flames are cool to the touch.You take only half damage from fire-based attacks.If such an attack allows a Reflex save for half damage, you take no damage on a successful saving throw.\nWarm Shield: The flames are warm to the touch.You take only half damage from cold-based attacks. If such an attack allows a Reflex save for half damage, you take no damage on a successful saving throw.", shieldIcon, SpellSchool.Evocation, new Kingmaker.Localization.LocalizedString(), LocalizedStrings.OneRoundPerLevelDuration);
            rootFireShieldBuilder.SetRange(AbilityRange.Personal).AllowTargeting(friends: true, self: true).SetAnimationStyle(Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Self).SetMetamagics(Metamagic.Quicken, Metamagic.Extend, Metamagic.Heighten, Metamagic.CompletelyNormal );
     
            rootFireShieldBuilder.AddVariants(warmSpellBuilt.AssetGuidThreadSafe, coldSpellBuilt.AssetGuidThreadSafe);
            var rootFireIceSpell = rootFireShieldBuilder.Configure();
            if (ModSettings.NewContent.Spells.IsEnabled("FireShield"))
            {
                rootFireIceSpell.AddToSpellList(SpellTools.SpellList.AlchemistSpellList, 4);
                rootFireIceSpell.AddToSpellList(SpellTools.SpellList.BloodragerSpellList, 4);
                rootFireIceSpell.AddToSpellList(SpellTools.SpellList.MagusSpellList, 4);
                rootFireIceSpell.AddToSpellList(SpellTools.SpellList.WizardSpellList, 4);
                rootFireIceSpell.AddToSpellList(SpellTools.SpellList.SunDomainSpellList, 4);
                rootFireIceSpell.AddToSpellList(SpellTools.SpellList.FireDomainSpellList, 5);
                    

            }
            if (ModSettings.NewContent.Spells.IsEnabled("VitrolicMist"))
            {
                acidSpellBuilt.AddToSpellList(SpellTools.SpellList.AlchemistSpellList, 4);
                acidSpellBuilt.AddToSpellList(SpellTools.SpellList.BloodragerSpellList, 4);
                acidSpellBuilt.AddToSpellList(SpellTools.SpellList.MagusSpellList, 4);
                acidSpellBuilt.AddToSpellList(SpellTools.SpellList.WizardSpellList, 4);


            }


        }
        //        This spell wreathes you in flame and causes damage to each creature that attacks you in melee.The flames also protect you from either cold-based or fire-based attacks, depending on if you choose cool or warm flames for your fire shield.

        //Any creature striking you with its body or a hand-held weapon deals normal damage, but at the same time the attacker takes 1d6 points of damage + 1 point per caster level(maximum +15). This damage is either cold damage(if you choose a chill shield) or fire damage(if you choose a warm shield). If the attacker has spell resistance, it applies to this effect.Creatures wielding melee weapons with reach are not subject to this damage if they attack you.

        //When casting this spell, you appear to immolate yourself, but the flames are thin and wispy, increasing the light level within 10 feet by one step, up to normal light.The color of the flames is blue or green if the chill shield is cast, violet or red if the warm shield is employed.The special powers of each version are as follows.

        //Chill Shield: The flames are cool to the touch.You take only half damage from fire-based attacks.If such an attack allows a Reflex save for half damage, you take no damage on a successful saving throw.


        //Warm Shield: The flames are warm to the touch.You take only half damage from cold-based attacks. If such an attack allows a Reflex save for half damage, you take no damage on a successful saving throw.

        //        Vitriolic Mist

        //School evocation[acid]; Level alchemist 4, bloodrager 4, sorcerer/wizard 4, summoner/unchained summoner 4

        //CASTING

        //Casting Time 1 standard action
        //Components V, S, M (a piece of lemon rind)

        //EFFECT

        //Range personal
        //Target you
        //Duration 1 round/level(D)

        //DESCRIPTION

        //This functions as fire shield, except it wreathes you in yellow or green acidic mist instead of hot or cold flames.The spell deals acid damage to attackers and protects you against acid damage.This spell does not shed light.
    }
}

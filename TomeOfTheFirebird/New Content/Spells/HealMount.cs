﻿using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using System.Linq;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.New_Content.Spells
{
    public static class HealMount
    {
        public static void Build()
        {
            BlueprintAbility HealActual = BlueprintTools.GetBlueprint<BlueprintAbility>("ff8f1534f66559c478448723e16b6624");
            string desc = "This spell functions like heal, but it affects only the paladin’s special mount (typically a horse). \n Heal:Heal enables you to channel positive energy into a creature to wipe away injury and afflictions. It immediately ends any and all of the following adverse conditions affecting the target: ability damage, blinded, confused, dazed, dazzled, deafened, diseased, exhausted, fatigued, feebleminded, insanity, nauseated, poisoned, sickened, and stunned. It also cures 10 hit points of damage per level of the caster, to a maximum of 150 points at 15th level. \n Heal does not remove negative levels or restore permanently drained ability score points.";
            BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities.AbilityConfigurator healmountcastmaker = MakerTools.MakeSpell("HealMountCast", "Heal Mount", desc, HealActual.Icon, Kingmaker.Blueprints.Classes.Spells.SpellSchool.Conjuration, new Kingmaker.Localization.LocalizedString(), new Kingmaker.Localization.LocalizedString());
            healmountcastmaker.SetSpellDescriptor(SpellDescriptor.Cure| SpellDescriptor.RestoreHP);
            healmountcastmaker.AddAbilityTargetIsAnimalCompanion();


            BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities.AbilityConfigurator healMount = MakerTools.MakeSpell("HealMount", "Heal Mount", desc, HealActual.Icon, SpellSchool.Conjuration, new Kingmaker.Localization.LocalizedString(), new Kingmaker.Localization.LocalizedString());
            healMount.SetSpellDescriptor(SpellDescriptor.Cure | SpellDescriptor.RestoreHP);

            healMount.AllowTargeting(friends: true);
            healMount.SetEffectOnAlly(AbilityEffectOnUnit.Helpful);
            healMount.SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Touch);
            healMount.SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard);
            healMount.SetAvailableMetamagic(Metamagic.Quicken, Metamagic.Heighten, Metamagic.CompletelyNormal, Metamagic.Reach);
            healMount.SetLocalizedDuration(new Kingmaker.Localization.LocalizedString());
            healMount.SetLocalizedSavingThrow(new Kingmaker.Localization.LocalizedString());

            healmountcastmaker.AllowTargeting(friends: true);
            healmountcastmaker.SetEffectOnAlly(AbilityEffectOnUnit.Helpful);
            healmountcastmaker.SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Touch);
            healmountcastmaker.SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard);
            healmountcastmaker.SetAvailableMetamagic(Metamagic.Quicken, Metamagic.Heighten, Metamagic.CompletelyNormal, Metamagic.Reach);
            healmountcastmaker.SetLocalizedDuration(new Kingmaker.Localization.LocalizedString());
            healmountcastmaker.SetLocalizedSavingThrow(new Kingmaker.Localization.LocalizedString());

            ActionsBuilder actuallyDoHealing = ActionsBuilder.New().RemoveBuff("9934fedff1b14994ea90205d189c8759");//Daze
            actuallyDoHealing.RemoveBuff("09d39b38bb7c6014394b6daced9bacd3");//Stun
            actuallyDoHealing.HealTarget(new ContextDiceValue() { DiceCountValue = new ContextValue() { Value =0 }, DiceType = Kingmaker.RuleSystem.DiceType.Zero, BonusValue = new ContextValue() { ValueType = ContextValueType.Rank } });
            actuallyDoHealing.HealStatDamage(Kingmaker.UnitLogic.Mechanics.Actions.ContextActionHealStatDamage.StatDamageHealType.HealAllDamage, Kingmaker.UnitLogic.Mechanics.Actions.ContextActionHealStatDamage.StatClass.Any);
            actuallyDoHealing.RemoveBuff("187f88d96a0ef464280706b63635f2af");//Blind
            actuallyDoHealing.RemoveBuff("52e4be2ba79c8c94d907bdbaf23ec15f");//Glitterdust Blind
            actuallyDoHealing.RemoveBuff("df6d1025da07524429afbae248845ecc");//Dazzled
            actuallyDoHealing.RemoveBuffsByDescriptor(SpellDescriptor.Poison | SpellDescriptor.Disease | SpellDescriptor.Daze | SpellDescriptor.Sickened | SpellDescriptor.Fatigue | SpellDescriptor.Nauseated | SpellDescriptor.Exhausted | SpellDescriptor.Stun |SpellDescriptor.Confusion |SpellDescriptor.Blindness);
            actuallyDoHealing.RemoveBuff("53808be3c2becd24dbe572f77a7f44f8");//Insanity
            actuallyDoHealing.RemoveBuff("8b3b4c225fe0fb046bfa8881c3ddad0d");//Feeblemind
            actuallyDoHealing.RemoveBuff("88f1ab751a9555a40abe9d7743e865fb");//Seize Skin
            healMount.AddAbilityEffectRunAction(actuallyDoHealing);
            healMount.AddAbilitySpawnFx(prefabLink: HealActual.Components.OfType<AbilitySpawnFx>().FirstOrDefault().PrefabLink, anchor:AbilitySpawnFxAnchor.SelectedTarget);
            healMount.AddContextRankConfig(new ContextRankConfig()
            {
                m_Progression = ContextRankProgression.MultiplyByModifier,
                m_StepLevel = 10,
                m_Max = 150,
                m_UseMax = true
                
                


            });
            healMount.AddAbilityDeliverTouch(touchWeapon: "bb337517547de1a4189518d404ec49d4");

            BlueprintAbility healmountmade = healMount.Configure();
            healmountcastmaker.AddAbilityEffectStickyTouch(touchDeliveryAbility: healmountmade.AssetGuidThreadSafe);
            healmountcastmaker.AddAbilityDeliverTouch(touchWeapon: "bb337517547de1a4189518d404ec49d4");
            if (Settings.IsEnabled("HealMount"))
            {
                healmountcastmaker.AddToSpellLists(3, SpellList.Paladin);

                
            }
            BlueprintAbility castMade = healmountcastmaker.Configure();

            
        }

    }
}

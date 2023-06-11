using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;
using UnityEngine;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;

namespace TomeOfTheFirebird.New_Content.Spells
{
    internal class Fly
    {
        public static void Make()
        {

            var buffGUID = Main.TotFContext.Blueprints.GetGUID("FlyBuff");
            var spellGUID = Main.TotFContext.Blueprints.GetGUID("FlySpell");
            var touchGUID = Main.TotFContext.Blueprints.GetGUID("FlySpellTouch");
            var massSpellGUID = Main.TotFContext.Blueprints.GetGUID("MassFlySpell");

            Sprite flyIcon = AssetLoader.LoadInternal(Main.TotFContext, "Spells", "Fly.png");
            if (Settings.IsEnabled("Fly"))
            {
                var buff = BuffConfigurator.New("FlyBuff", buffGUID.ToString());
                buff.SetDisplayName("Fly.Name");
                buff.SetDescription("Fly.Desc");
                buff.SetIcon(flyIcon);
                buff.AddBuffDescriptorImmunity(descriptor: new Kingmaker.Blueprints.Classes.Spells.SpellDescriptorWrapper(Kingmaker.Blueprints.Classes.Spells.SpellDescriptor.Ground));
                buff.AddSpellImmunityToSpellDescriptor(descriptor: new Kingmaker.Blueprints.Classes.Spells.SpellDescriptorWrapper(Kingmaker.Blueprints.Classes.Spells.SpellDescriptor.Ground));
                buff.AddStatBonus(Kingmaker.Enums.ModifierDescriptor.Enhancement, stat: Kingmaker.EntitySystem.Stats.StatType.Speed, value: 10);
                buff.AddFormationACBonus(bonus: 3);
                buff.AddACBonusAgainstAttacks(againstMeleeOnly: true, armorClassBonus: 3, descriptor: Kingmaker.Enums.ModifierDescriptor.Dodge);
                buff.AddToFlags(flags: BlueprintBuff.Flags.IsFromSpell);
               var buffMade = buff.Configure();

                var touch = AbilityConfigurator.NewSpell("FlySpellTouch", touchGUID.ToString(), Kingmaker.Blueprints.Classes.Spells.SpellSchool.Transmutation, false);
                touch.SetIcon(flyIcon);
                touch.SetDisplayName("Fly.Name");
                touch.SetDescription("Fly.Desc");
                touch.SetLocalizedDuration(Duration.MinutePerLevel);
               
                touch.AllowTargeting(friends: true, self:true);
                touch.SetEffectOnAlly(AbilityEffectOnUnit.Helpful);
                touch.SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Touch);
                touch.SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard);
                touch.SetAvailableMetamagic(Metamagic.Quicken, Metamagic.Heighten, Metamagic.CompletelyNormal, Metamagic.Reach);
                touch.SetLocalizedSavingThrow(new Kingmaker.Localization.LocalizedString());
                touch.AddAbilityEffectRunAction(ActionsBuilder.New().ApplyBuff(buffMade.AssetGuidThreadSafe, durationValue: MakerTools.GetContextDurationValue(Kingmaker.UnitLogic.Mechanics.DurationRate.Minutes, true)));
                touch.AddAbilityDeliverTouch(touchWeapon: "bb337517547de1a4189518d404ec49d4");
                var touchMade = touch.Configure();
               
                
                var spell = AbilityConfigurator.NewSpell("FlySpell", spellGUID.ToString(), Kingmaker.Blueprints.Classes.Spells.SpellSchool.Transmutation, true);
                spell.SetIcon(flyIcon);
                spell.AddToSpellLists(3, SpellList.Alchemist, SpellList.Wizard, SpellList.Bloodrager, SpellList.Magus, SpellList.Shaman, SpellList.Witch);
                spell.SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard);
                spell.SetLocalizedDuration(Duration.MinutePerLevel);
                spell.AllowTargeting(friends: true, self:true);
                spell.SetEffectOnAlly(AbilityEffectOnUnit.Helpful);
                spell.SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Touch);
                spell.SetLocalizedSavingThrow(new Kingmaker.Localization.LocalizedString());
                spell.SetAvailableMetamagic(Metamagic.Quicken, Metamagic.Heighten, Metamagic.CompletelyNormal, Metamagic.Reach);
                
                spell.SetDisplayName("Fly.Name");
                spell.SetDescription("Fly.Desc");
                spell.AddSpellToMedium(3);
                spell.AddSpellToSpiritualist(3);
                spell.AddSpellToSummoner(3);
                spell.AddSpellToOccultist(3);
                spell.AddSpellToPsychic(3);
                spell.AddAbilityEffectStickyTouch(touchDeliveryAbility: touchMade.AssetGuidThreadSafe);
                spell.AddAbilityDeliverTouch(touchWeapon: "bb337517547de1a4189518d404ec49d4");

                spell.Configure();

                var massSpell = AbilityConfigurator.NewSpell("MassFlySpell", massSpellGUID.ToString(), Kingmaker.Blueprints.Classes.Spells.SpellSchool.Transmutation, true);
                massSpell.SetIcon(flyIcon);
              
                massSpell.SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard);
                massSpell.SetLocalizedDuration(Duration.MinutePerLevel);
                massSpell.AllowTargeting(self: true);
                massSpell.SetEffectOnAlly(AbilityEffectOnUnit.Helpful);
                massSpell.SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Self);
                massSpell.SetLocalizedSavingThrow(new Kingmaker.Localization.LocalizedString());
                massSpell.SetAvailableMetamagic(Metamagic.Quicken, Metamagic.Heighten, Metamagic.CompletelyNormal, Metamagic.Reach);
                massSpell.SetDisplayName("MassFly.Name");
                massSpell.SetDescription("MassFly.Desc");
                massSpell.AddSpellToPsychic(7);
                massSpell.AddToSpellLists(7,  SpellList.Wizard);
                massSpell.AddAbilityEffectRunAction(ActionsBuilder.New().ApplyBuff(buffMade.AssetGuidThreadSafe, durationValue: MakerTools.GetContextDurationValue(Kingmaker.UnitLogic.Mechanics.DurationRate.Minutes, true)).PartyMembers(ActionsBuilder.New().ApplyBuff(buffMade.AssetGuidThreadSafe, durationValue: MakerTools.GetContextDurationValue(Kingmaker.UnitLogic.Mechanics.DurationRate.Minutes, true))));
                massSpell.Configure();



                //TODO MASS FLY - level 7, 30 foot burst of fly, 10 minutes per level
            }
            else
            {
                AbilityConfigurator.New("FlySpell", spellGUID.ToString()).Configure();
                AbilityConfigurator.New("MassFlySpell", massSpellGUID.ToString()).Configure();
                AbilityConfigurator.New("FlySpellTouch", touchGUID.ToString()).Configure();
                
                BuffConfigurator.New("FlyBuff", buffGUID.ToString()).Configure();
            }
        }
        //The subject can fly at a speed of 60 feet (or 40 feet if it wears medium or heavy armor, or if it carries a medium or heavy load). It can ascend at half speed and descend at double speed, and its maneuverability is good. Using a fly spell requires only as much concentration as walking, so the subject can attack or cast spells normally. The subject of a fly spell can charge but not run, and it cannot carry aloft more weight than its maximum load, plus any armor it wears. The subject gains a bonus on Fly skill checks equal to 1/2 your caster level.
    }
}

using Kingmaker.ElementsSystem;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components
{
    class SpellstrikeAlikeComponent : UnitFactComponentDelegate<SpellstrikeAlikeComponentData>, IInitiatorRulebookHandler<RuleAttackWithWeapon>, IRulebookHandler<RuleAttackWithWeapon>, ISubscriber, IInitiatorRulebookSubscriber
    {
        public ConditionsChecker Condition;
		public BlueprintAbility PayloadBlueprint;
        public override void OnActivate()
        {
            base.OnActivate();
			Init(PayloadBlueprint, base.Context.SourceAbilityContext.Ability, base.Context.SourceAbilityContext);
		}

        public override void OnTurnOn()
        {
            base.OnTurnOn();
			Init(PayloadBlueprint, base.Context.SourceAbilityContext.Ability, base.Context.SourceAbilityContext);
        }

		private void Init(BlueprintAbility ability, AbilityData source, AbilityExecutionContext context)
		{
			if (this.Data.payload != null)
			{
				base.Owner.RemoveFact(this.Data.payload);
				
			}
			Data.payload = (Ability)base.Owner.AddFact(ability, null, null);

			Data.payload.OverrideParams = context.Params;
			Data.payload.Data.SpellSource = context.Params.SpellSource;
			Data.payload.Spellbook = context.Ability.Spellbook;
			
			MetamagicData metamagicData = source.MetamagicData;
			Metamagic metamagic = (metamagicData != null) ? metamagicData.MetamagicMask : ((Metamagic)0);
			if (metamagic != (Metamagic)0)
			{
				AbilityData data = Data.payload.Data;
				MetamagicData metamagicData2 = Data.payload.Data.MetamagicData;
				data.MetamagicData = (((metamagicData2 != null) ? metamagicData2.Clone() : null) ?? new MetamagicData());
				Data.payload.Data.MetamagicData.Add(metamagic);
			}
			
		}

		// Token: 0x0600BB57 RID: 47959 RVA: 0x0030F5D0 File Offset: 0x0030D7D0
		public override void OnDispose()
		{
			base.OnDispose();
			base.Owner.RemoveFact(this.Data.payload);
			
		}

		public void OnEventAboutToTrigger(RuleAttackWithWeapon evt)
        {
            
        }

        public void OnEventDidTrigger(RuleAttackWithWeapon evt)
        {
			if (!evt.AttackRoll.IsHit)
			{
				return;
			}
			if (this.Data.payload == null)
            {
                return;
            }
            if (!this.Condition.Check())
                return;
			if (evt.AttackRoll.Weapon.Blueprint.IsMelee)
			{
				Rulebook.Trigger<RuleCastSpell>(new RuleCastSpell(this.Data.payload, evt.AttackRoll.Target));
                
			}
		}
    }

   

    class SpellstrikeAlikeComponentData
    {
        public Ability payload;
    }


}

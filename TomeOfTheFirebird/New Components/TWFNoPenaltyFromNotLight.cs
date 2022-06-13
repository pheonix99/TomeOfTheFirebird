using Kingmaker.Enums;
using Kingmaker.Items;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Parts;
using Kingmaker.UnitLogic;
using Kingmaker.Utility;
using System.Linq;

namespace TomeOfTheFirebird.NewComponents
{
    public class TWFNoPenaltyFromNotLight : UnitFactComponentDelegate, ISubscriber, IInitiatorRulebookSubscriber, IInitiatorRulebookHandler<RuleCalculateAttackBonusWithoutTarget>, IRulebookHandler<RuleCalculateAttackBonusWithoutTarget>
	{
		public void OnEventAboutToTrigger(RuleCalculateAttackBonusWithoutTarget evt)
		{
			//This should make Prodigious TWF remove non-light off-hand weapon penalties.
			//Must test with heavy shield
			if (!evt.AllBonuses.Any(x=>x.Fact.Blueprint.AssetGuidThreadSafe== "6948b379c0562714d9f6d58ccbfa8faa"))
            {
				return;
            }

			//if (!evt.m_TemporaryModifiers.Any(x => x.Source.Blueprint.AssetGuidThreadSafe == ""))
			//	return;
			
			ItemEntityWeapon maybeWeapon = evt.Initiator.Body.PrimaryHand.MaybeWeapon;
			ItemEntityWeapon maybeWeapon2 = evt.Initiator.Body.SecondaryHand.MaybeWeapon;
			int num = 0;
			UnitPartWeaponTraining unitPartWeaponTraining = base.Owner.Get<UnitPartWeaponTraining>();
			if (evt.Initiator.Body.SecondaryHand.HasShield || evt.Weapon == null || evt.Weapon.IsShield)
			{
				return;
			}
			bool flag2 = base.Owner.State.Features.EffortlessDualWielding && unitPartWeaponTraining != null && unitPartWeaponTraining.IsSuitableWeapon(maybeWeapon2);
			if (!maybeWeapon2.Blueprint.IsLight && !maybeWeapon.Blueprint.Double && !maybeWeapon2.IsShield && !flag2)//This SHOULD cancel the -2 for using a heavy weapon in offhand?
			{
				num += 2;
				evt.AddModifier(num, base.Fact, ModifierDescriptor.UntypedStackable);
			}




		}

		public void OnEventDidTrigger(RuleCalculateAttackBonusWithoutTarget evt)
		{

		}
	}
}

using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Items;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.Utility;

namespace TomeOfTheFirebird.Components
{
    // Token: 0x02001A1F RID: 6687
    [AllowedOn(typeof(BlueprintAbility), false)]
	
	public class AbilityTargetHasSlashingPiercingWeaponInRelevantHand : BlueprintComponent, IAbilityTargetRestriction
	{
		// Token: 0x0600AEE3 RID: 44771 RVA: 0x002C95D1 File Offset: 0x002C77D1
		public bool IsTargetRestrictionPassed(UnitEntityData caster, TargetWrapper target)
		{
			if (target.Unit != null)
			{
				ItemEntityWeapon maybeWeapon = MainHand ? target.Unit.Body.PrimaryHand.MaybeWeapon : target.Unit.Body.SecondaryHand.MaybeWeapon;
				return maybeWeapon != null && (maybeWeapon.Blueprint.DamageType.Physical.Form == Kingmaker.Enums.Damage.PhysicalDamageForm.Slashing || maybeWeapon.Blueprint.DamageType.Physical.Form == Kingmaker.Enums.Damage.PhysicalDamageForm.Slashing) ;
			}
			return false;
		}

		// Token: 0x0600AEE4 RID: 44772 RVA: 0x002C9608 File Offset: 0x002C7808
		public string GetAbilityTargetRestrictionUIText(UnitEntityData caster, TargetWrapper target)
		{
			return $"{(MainHand ? "Main hand" : "Off hand")} weapon must be slashing or piercing";
		}

		public bool MainHand;
	}
}

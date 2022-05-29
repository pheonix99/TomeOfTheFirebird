namespace TomeOfTheFirebird.Tweaks
{
    //This don't work.

    static class FlawlessAttacks
    {/*
        [HarmonyPatch(typeof(RuleCalculateAttacksCount), "OnTrigger", new Type[] {typeof(RulebookEventContext) })]
        static bool Prefix(RuleCalculateAttacksCount __instance, RulebookEventContext context)
        {
            if (ModSettings.Tweaks.Mythic.IsDisabled("FlawlessAttacksAppliesToAttackCount"))
            {
                return true;
            }
            else if (!__instance.Initiator.State.Features.FlawlessAttacks)
            {
                return true;
            }
            else
            {
				
				__instance.Result.PrimaryHand.FlawlessAttacks = __instance.Initiator.State.Features.FlawlessAttacks;
				__instance.Result.SecondaryHand.FlawlessAttacks = __instance.Initiator.State.Features.FlawlessAttacks;
				int num = __instance.Initiator.Stats.BaseAttackBonus;
				int num2 = Math.Max(0, num / 4 - ((num % 4 == 0) ? 1 : 0));
				Main.Log($"Attack Count Modifier for {__instance.Initiator.CharacterName} in effect, calc'd new attack count {num2}");
				if (num2 > 3 && __instance.Initiator.Get<UnitPartCompanion>() == null)
				{
					num2 = 3;
				}
				HandSlot primaryHand = __instance.Initiator.Body.PrimaryHand;
				HandSlot handSlot = __instance.Initiator.Body.HandsAreEnabled ? __instance.Initiator.Body.SecondaryHand : null;
				ItemEntityWeapon maybeWeapon = primaryHand.MaybeWeapon;
				BlueprintItemWeapon blueprintItemWeapon = (maybeWeapon != null) ? maybeWeapon.Blueprint : null;
				BlueprintItemWeapon blueprintItemWeapon2;
				if (((handSlot != null) ? handSlot.MaybeShield : null) == null)
				{
					if (handSlot == null)
					{
						blueprintItemWeapon2 = null;
					}
					else
					{
						ItemEntityWeapon maybeWeapon2 = handSlot.MaybeWeapon;
						blueprintItemWeapon2 = ((maybeWeapon2 != null) ? maybeWeapon2.Blueprint : null);
					}
				}
				else if (!__instance.Initiator.Descriptor.State.Features.ShieldBash)
				{
					blueprintItemWeapon2 = null;
				}
				else
				{
					ItemEntityWeapon weaponComponent = handSlot.MaybeShield.WeaponComponent;
					blueprintItemWeapon2 = ((weaponComponent != null) ? weaponComponent.Blueprint : null);
				}
				BlueprintItemWeapon blueprintItemWeapon3 = blueprintItemWeapon2;
				bool flag = primaryHand.MaybeWeapon != null && primaryHand.MaybeWeapon.HoldInTwoHands;
				if ((((handSlot != null) ? handSlot.MaybeWeapon : null) == null || !handSlot.MaybeWeapon.HoldInTwoHands) && blueprintItemWeapon != null && (!blueprintItemWeapon.IsUnarmed || blueprintItemWeapon3 == null || blueprintItemWeapon3.IsUnarmed))
				{
					__instance.Result.PrimaryHand.AdditionalAttacks++;
					if (!blueprintItemWeapon.IsNatural || __instance.Initiator.Descriptor.State.Features.IterativeNaturalAttacks || __instance.ForceIterativeNaturalAttacks || blueprintItemWeapon.IsUnarmed)
					{
						__instance.Result.PrimaryHand.PenalizedAttacks += Math.Max(0, num2);
					}
				}
				if (!flag && blueprintItemWeapon3 != null && (!blueprintItemWeapon3.IsUnarmed || blueprintItemWeapon == null))
				{
					__instance.Result.SecondaryHand.AdditionalAttacks++;
					if (blueprintItemWeapon == null || blueprintItemWeapon.IsUnarmed || (blueprintItemWeapon.IsNatural && (__instance.Initiator.Descriptor.State.Features.IterativeNaturalAttacks || __instance.ForceIterativeNaturalAttacks)))
					{
						__instance.Result.SecondaryHand.PenalizedAttacks += Math.Max(0, num2);
					}
				}
				return false;
			}

        }
		*/
    }
}

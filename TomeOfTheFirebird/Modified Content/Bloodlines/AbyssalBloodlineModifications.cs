using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using System.Linq;
using TabletopTweaks.Core.Utilities;

namespace TomeOfTheFirebird.Modified_Content.Bloodlines
{
    class AbyssalBloodlineModifications
    {
        public static string[] AbyssalClaws = {"408b5ec07bf0fd1468d3f16ef569613a",
"ee7356a601de6bb40a4929d074337b48",
"fe7a7bebab335fc4e936e3f9d23fedb4",
"f68af48f9ebf32549b5f9fdc4edfd475" };
        public static void GiveInfiniteUses()
        {
            if (Main.TotFContext.Tweaks.Bloodlines.IsDisabled("UnlimitedSorcererBloodlineClaws"))
            {
                return;
            }
            foreach(string s in AbyssalClaws)
            {
                var claw = BlueprintTools.GetBlueprint<BlueprintActivatableAbility>(s);
                claw.Components.OfType<ActivatableAbilityResourceLogic>().FirstOrDefault().m_FreeBlueprint = claw.ToReference<BlueprintUnitFactReference>();
                claw.DeactivateIfCombatEnded = false;
                
                
            }
        }
    }
}

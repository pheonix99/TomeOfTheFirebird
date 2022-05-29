using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Weapons;
using TabletopTweaks.Core.Utilities;

namespace TomeOfTheFirebird.Crusade
{
    public static class MonavicsUseTwoHanders
    {
        public static void Do()
        {
            if (Main.TotFContext.Tweaks.Crusade.IsEnabled("MovanicDevasWeaponFix"))
            {

                BlueprintUnit Monavic = BlueprintTools.GetBlueprint<BlueprintUnit>("88547ce8c98f4797831b8d19494a474d");
                Monavic.Body.m_PrimaryHand = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("1d367acacbaf8504c99f0a38c0258468").ToReference<BlueprintItemEquipmentHandReference>();
            }
        }

    }
}

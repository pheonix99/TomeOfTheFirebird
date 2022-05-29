using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Weapons;
using TomeOfTheFirebird.Config;

namespace TomeOfTheFirebird.Crusade
{
    public static class MonavicsUseTwoHanders
    {
        public static void Do()
        {
            if (ModSettings.Tweaks.Crusade.IsEnabled("MovanicDevasWeaponFix"))
            {

                BlueprintUnit Monavic = Resources.GetBlueprint<BlueprintUnit>("88547ce8c98f4797831b8d19494a474d");
                Monavic.Body.m_PrimaryHand = Resources.GetBlueprint<BlueprintItemWeapon>("1d367acacbaf8504c99f0a38c0258468").ToReference<BlueprintItemEquipmentHandReference>();
            }
        }

    }
}

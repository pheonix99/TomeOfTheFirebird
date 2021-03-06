using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using Owlcat.Runtime.Core;
using System.Linq;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.Bugfixes
{
    public class RadianceLevel2Fix
    {
        public static void Fixes()
        {
            var radianceBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("f10cba2c41612614ea28b5fc2743bc4c");

            Main.TotFContext.Logger.Log("Patching Radiance +6");
            

            var buff = MakerTools.MakeBuff("Radiance+6HolyBuff", "Radiance Holy Hidden", "", radianceBuff.Icon);
            buff.SetFlags(BlueprintBuff.Flags.HiddenInUi, BlueprintBuff.Flags.StayOnDeath);
            buff.AddBuffEnchantSpecificWeaponWorn(enchantmentBlueprint: "28a9964d81fedae44bae3ca45710c140", weaponBlueprint: "cf5c1a507825f184dacbc3abe14b9db1");

            var builtBuff= buff.Configure();

            var apply = ActionsBuilder.New().ApplyBuffPermanent(builtBuff.AssetGuidThreadSafe, toCaster:true, asChild:true);

            var remove = ActionsBuilder.New().RemoveBuff(builtBuff.AssetGuidThreadSafe, toCaster: true);
            var HolyAvengerEnchant = BlueprintTools.GetBlueprint<BlueprintWeaponEnchantment>("119b0b2ddae69d4438e6a4bedff32412");

           var list =  HolyAvengerEnchant.Components.OfType<AddFactContextActions>().FirstOrDefault();
            if (Main.TotFContext.Bugfixes.Items.IsEnabled("FixRadianceFinalForm"))
            {

                list.Activated.Actions = list.Activated.Actions.Append<GameAction>(apply.Build().Actions[0]).ToArray();
                list.Deactivated.Actions = list.Activated.Actions.Append<GameAction>(remove.Build().Actions[0]).ToArray();
            }
                
        }

    }
}

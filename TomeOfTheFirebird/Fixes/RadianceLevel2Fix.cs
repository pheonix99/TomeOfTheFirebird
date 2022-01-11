using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Conditions.Builder;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using Owlcat.Runtime.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.Config;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.Fixes
{
    public class RadianceLevel2Fix
    {
        public static void Fixes()
        {
            var radianceBuff = Resources.GetBlueprint<BlueprintBuff>("f10cba2c41612614ea28b5fc2743bc4c");

            Main.Log("Patching Radiance +6");
            

            var buff = MakerTools.MakeBuff("Radiance+6HolyBuff", "Radiance Holy Hidden", "", radianceBuff.Icon);
            buff.SetFlags(BlueprintBuff.Flags.HiddenInUi, BlueprintBuff.Flags.StayOnDeath);
            buff.AddBuffEnchantSpecificWeaponWorn(enchantmentBlueprint: "28a9964d81fedae44bae3ca45710c140", weaponBlueprint: "cf5c1a507825f184dacbc3abe14b9db1");

            var builtBuff= buff.Configure();

            var apply = ActionsBuilder.New().ApplyBuff(builtBuff.AssetGuidThreadSafe, toCaster:true, asChild:true, permanent: true);

            var remove = ActionsBuilder.New().RemoveBuff(builtBuff.AssetGuidThreadSafe, toCaster: true);
            var HolyAvengerEnchant = Resources.GetBlueprint<BlueprintWeaponEnchantment>("119b0b2ddae69d4438e6a4bedff32412");

           var list =  HolyAvengerEnchant.Components.OfType<AddFactContextActions>().FirstOrDefault();
            list.Activated.Actions = list.Activated.Actions.Append<GameAction>(apply.Build().Actions[0]).ToArray();
            list.Deactivated.Actions = list.Activated.Actions.Append<GameAction>(remove.Build().Actions[0]).ToArray();

                
        }

    }
}

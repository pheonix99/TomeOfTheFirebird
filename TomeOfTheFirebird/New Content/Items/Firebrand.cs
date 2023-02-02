using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Content.Items
{
    class Firebrand
    {
        public static void Make()
        {
            string itemName = "Firebrand";
            string itemDesc = "";
            string itemSysName = "FirebrandBFS";
            BlueprintGuid guid = Main.TotFContext.Blueprints.GetGUID(itemSysName);
            LocalizedString name = LocalizationTool.CreateString(itemSysName + ".Name", itemName);
            LocalizedString desc = LocalizationTool.CreateString(itemSysName + ".Desc", itemDesc);
            var config = ItemWeaponConfigurator.New(itemSysName, guid.ToString()).SetDisplayNameText(name).SetDescriptionText(desc);
            config.AddToEnchantments("80bb8a737579e35498177e1e3c75899b");
            config.SetType("5f824fbb0766a3543bbd6ae50248688f");
            
        }
    }
}

using BlueprintCore.Blueprints.Configurators.Abilities;
using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Blueprints;
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
using TomeOfTheFirebird.New_Components;

namespace TomeOfTheFirebird.New_Content.Items
{
    class PaladinGear
    {
        public static void Build()
        {
            BuildMercy();
            BuildSmite();
            BuildMaster();



        }

        private static void BuildMaster()
        {
            //Combine both bracers and the extra smite ring into one kickass pair of bracers - 
        }

        private static void BuildSmite()
        {
            //+4 effective class level for smitage
            //Damage *and uses*?
        }

        public static BlueprintItemEquipmentWrist merciful;

        private static void BuildMercy()
        {
            var MercyFeature = MakerTools.MakeFeature("BracersOfTheMercifulKnightFeature", "Bracers Of The Merciful Knight Feature", "You Shouldn't See This", true);
            if (ModSettings.NewContent.Items.IsEnabled("BracersOfTheMercifulKnight"))
            {
                var LayOnHandsSelf = Resources.GetBlueprint<BlueprintAbility>("8d6073201e5395d458b8251386d72df1");

                LayOnHandsSelf.Components.OfType<ContextRankConfig>().FirstOrDefault().m_UseMax = false;//There's no reason for this and we don't want the item crapping out at 20

                var LayOnHandsOther = Resources.GetBlueprint<BlueprintAbility>("caae1dc6fcf7b37408686971ee27db13");

                LayOnHandsOther.Components.OfType<ContextRankConfig>().FirstOrDefault().m_UseMax = false;//There's no reason for this and we don't want the item crapping out at 20
                var LayOnHandsSpecial = Resources.GetBlueprint<BlueprintAbility>("8337cea04c8afd1428aad69defbfc365");

                LayOnHandsSpecial.Components.OfType<ContextRankConfig>().FirstOrDefault().m_UseMax = false;//There's no reason for this and we don't want the item crapping out at 20


                MercyFeature.AddComponent(new IncreaseSpecificSPellsCasterLevel() { spells = new BlueprintAbility[] { LayOnHandsSelf, LayOnHandsOther, LayOnHandsSpecial }, Descriptor = Kingmaker.Enums.ModifierDescriptor.Sacred, Value = new Kingmaker.UnitLogic.Mechanics.ContextValue() { Value = 4 } }).AddIncreaseResourceAmount("9dedf41d995ff4446a181f143c3db98c", 2);
            }
            //TODO - add resoration effect with smartness

            var mercyFeatureBuilt = MercyFeature.Configure();

            var enchant = MakerTools.MakeItemEnchantment("BracersOfTheMercifulKnightEnchant", "Bracers Of The Merciful Knight", "When worn by a paladin, she is considered four levels higher for the purposes of determining the uses per day and healing provided by her lay on hands class feature. This does not increase the power of her Channel Energy ability.", 1);
            enchant.AddUnitFeatureEquipment(mercyFeatureBuilt.AssetGuidThreadSafe);

            var enchantBuilt = enchant.Configure();

            BlueprintItemEquipment templateItem = Resources.GetBlueprint<BlueprintItemEquipmentWrist>("d68cea6c999eab4459c030c6588c1083");

            string itemSysName = "BracersOfTheMercifulKnight";
            string itemName = "Bracers Of The Merciful Knight";
            string itemDesc = "These golden bracers are engraved with images of celestial creatures.\n When worn by a paladin, she is considered four levels higher for the purposes of determining the uses per day and healing provided by her lay on hands class feature. This does not increase the power of her Channel Energy ability.";
            //TODO add the 1/day lesser resto on LoH
            var guid = ModSettings.Blueprints.GetGUID(itemSysName);
            LocalizedString name = LocalizationTool.CreateString(itemSysName + ".Name", itemName);
            LocalizedString desc = LocalizationTool.CreateString(itemSysName + ".Desc", itemDesc);
            var item = ItemEquipmentWristConfigurator.New(itemSysName, guid.ToString()).SetDisplayNameText(name).SetDescriptionText(desc);
            item.SetEnchantments(new string[] { enchantBuilt.AssetGuidThreadSafe });
            item.SetFlavorText(new LocalizedString());
            item.SetInventoryEquipSound("ArmorPlateEquip");
            item.SetInventoryTakeSound("ArmorPlatePut");
            item.SetInventoryPutSound("ArmorPlateTake");
            item.SetCR(10);
            item.SetCost(15600);
            item.SetIcon(templateItem.Icon);
            item.SetEquipmentEntity(templateItem.EquipmentEntity.AssetGuidThreadSafe);
            item.SetShardItem(templateItem.ShardItem.AssetGuidThreadSafe);
            item.SetNonIdentifiedNameText(new LocalizedString());
            item.SetNonIdentifiedDescriptionText(new LocalizedString());


             merciful = item.Configure();
        }

    }
}

using BlueprintCore.Blueprints.Configurators.Items;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Loot;
using TomeOfTheFirebird.Config;

namespace TomeOfTheFirebird.New_Content.Items
{
    class AddItemsToShop
    {
        public static void Add()
        {
            if (ModSettings.NewContent.Items.IsEnabled("BracersOfTheMercifulKnight"))
            {

                //var merciful = Resources.GetModBlueprint<BlueprintItemEquipmentWrist>("BracersOfTheMercifulKnight");
                var merciful = PaladinGear.merciful;


                LootItem add = new LootItem()
                {
                    m_Item = merciful.ToReference<BlueprintItemReference>(),
                    m_Type = LootItemType.Item,
                    m_Loot = null

                };


                var editArsinoe = SharedVendorTableConfigurator.For("d33d4c7396fc1d74c9569bc38e887e86").AddLootItemsPackFixed(add, 1).Configure();
            }
            if (ModSettings.NewContent.Items.IsEnabled("BracersOfTheAvengingKnight"))
            {

                //var merciful = Resources.GetModBlueprint<BlueprintItemEquipmentWrist>("BracersOfTheMercifulKnight");
                var merciful = PaladinGear.avengingItem;


                LootItem add = new LootItem()
                {
                    m_Item = merciful.ToReference<BlueprintItemReference>(),
                    m_Type = LootItemType.Item,
                    m_Loot = null

                };


                var editArsinoe = SharedVendorTableConfigurator.For("d33d4c7396fc1d74c9569bc38e887e86").AddLootItemsPackFixed(add, 1).Configure();
            }


        }

    }
}

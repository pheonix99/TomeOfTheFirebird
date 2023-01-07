using BlueprintCore.Blueprints.Configurators.Items;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Loot;

namespace TomeOfTheFirebird.New_Content.Items
{
    class AddItemsToShop
    {
        public static void Add()
        {
            if (Settings.IsEnabled("BracersOfTheMercifulKnight"))
            {

                //var merciful = Resources.GetModBlueprint<BlueprintItemEquipmentWrist>("BracersOfTheMercifulKnight");
                Kingmaker.Blueprints.Items.Equipment.BlueprintItemEquipmentWrist merciful = PaladinGear.merciful;


                LootItem add = new LootItem()
                {
                    m_Item = merciful.ToReference<BlueprintItemReference>(),
                    m_Type = LootItemType.Item,
                    m_Loot = null

                };


                Kingmaker.Blueprints.Items.BlueprintSharedVendorTable editArsinoe = SharedVendorTableConfigurator.For("d33d4c7396fc1d74c9569bc38e887e86").AddComponent<LootItemsPackFixed>(x => {
                    x.m_Item = add;
                    x.m_Count = 1;
                }).Configure(); ;
                Main.TotFContext.Logger.LogPatch("Added Merciful Knight", editArsinoe);
            }
            if (Settings.IsEnabled("BracersOfTheAvengingKnight"))
            {

                //var merciful = Resources.GetModBlueprint<BlueprintItemEquipmentWrist>("BracersOfTheMercifulKnight");
                Kingmaker.Blueprints.Items.Equipment.BlueprintItemEquipmentWrist merciful = PaladinGear.avengingItem;


                LootItem add = new LootItem()
                {
                    m_Item = merciful.ToReference<BlueprintItemReference>(),
                    m_Type = LootItemType.Item,
                    m_Loot = null

                };


                Kingmaker.Blueprints.Items.BlueprintSharedVendorTable editArsinoe = SharedVendorTableConfigurator.For("d33d4c7396fc1d74c9569bc38e887e86").AddComponent<LootItemsPackFixed>(x => {
                    x.m_Item = add;
                    x.m_Count = 1;
                }).Configure();
                Main.TotFContext.Logger.LogPatch("Added Avenging Knight", editArsinoe);
            }


        }

    }
}

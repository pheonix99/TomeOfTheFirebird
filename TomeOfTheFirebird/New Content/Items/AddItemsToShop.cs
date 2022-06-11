using BlueprintCore.Blueprints.Configurators.Items;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Loot;

namespace TomeOfTheFirebird.New_Content.Items
{
    class AddItemsToShop
    {
        public static void Add()
        {
            if (Main.TotFContext.NewContent.Items.IsEnabled("BracersOfTheMercifulKnight"))
            {

                //var merciful = Resources.GetModBlueprint<BlueprintItemEquipmentWrist>("BracersOfTheMercifulKnight");
                var merciful = PaladinGear.merciful;


                LootItem add = new LootItem()
                {
                    m_Item = merciful.ToReference<BlueprintItemReference>(),
                    m_Type = LootItemType.Item,
                    m_Loot = null

                };


                var editArsinoe = SharedVendorTableConfigurator.For("d33d4c7396fc1d74c9569bc38e887e86").AddComponent<LootItemsPackFixed>(x => {
                    x.m_Item = add;
                    x.m_Count = 1;
                }).Configure(); ; 
            }
            if (Main.TotFContext.NewContent.Items.IsEnabled("BracersOfTheAvengingKnight"))
            {

                //var merciful = Resources.GetModBlueprint<BlueprintItemEquipmentWrist>("BracersOfTheMercifulKnight");
                var merciful = PaladinGear.avengingItem;


                LootItem add = new LootItem()
                {
                    m_Item = merciful.ToReference<BlueprintItemReference>(),
                    m_Type = LootItemType.Item,
                    m_Loot = null

                };

                
                var editArsinoe = SharedVendorTableConfigurator.For("d33d4c7396fc1d74c9569bc38e887e86").AddComponent<LootItemsPackFixed>(x => {
                    x.m_Item = add;
                    x.m_Count = 1;
                }).Configure();
            }


        }

    }
}

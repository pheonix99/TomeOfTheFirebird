using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.New_Components;

namespace TomeOfTheFirebird.Modified_Content.Items
{
    class ItemFeatureSwapFactory
    {
        public static void Run(string feature, string item)
        {
            ItemEquipmentUsableConfigurator.For(item).AddComponent<ItemFeatureSwapPointerItemComponent>(x =>
            {

                x.m_blueprintFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
            }).Configure();

            FeatureConfigurator.For(feature).AddComponent<ItemFeatureSwapPointerFeatureComponent>(x =>
            {

                x.m_item = BlueprintTool.GetRef<BlueprintItemEquipmentUsableReference>(item);
            }).Configure();


        }
    }
}

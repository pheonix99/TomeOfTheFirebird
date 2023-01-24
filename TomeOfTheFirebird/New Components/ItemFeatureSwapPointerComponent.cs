using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components
{
    [AllowedOn(typeof(BlueprintItemEquipmentUsable))]
    
    class ItemFeatureSwapPointerItemComponent : BlueprintComponent
    {
       public BlueprintFeatureReference m_blueprintFeature;

        public BlueprintFeature Feature => m_blueprintFeature.Get();


    }

   
    [AllowedOn(typeof(BlueprintFeature))]
    class ItemFeatureSwapPointerFeatureComponent : BlueprintComponent
    {
        public BlueprintItemEquipmentUsableReference m_item;

        public BlueprintItemEquipmentUsable Item => m_item.Get();

    }
}

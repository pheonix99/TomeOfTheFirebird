using Kingmaker.UnitLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components
{
    public class AttachTwinSpellUnitPart : UnitFactComponentDelegate
    {
        public override void OnActivate()
        {
            OnTurnOn();
        }

       
        public override void OnTurnOn()
        {

            Owner.Ensure<UnitPartDoTwinSpell>();

        }

       
    }
}

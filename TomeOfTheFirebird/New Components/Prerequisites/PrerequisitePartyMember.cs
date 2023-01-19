using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.LevelUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components.Prerequisites
{
    class PrerequisitePartyMember : Prerequisite
    {// Token: 0x0200199D RID: 6557

        // Token: 0x0600B25C RID: 45660 RVA: 0x002E9E41 File Offset: 0x002E8041
        public override bool CheckInternal(FeatureSelectionState selectionState, UnitDescriptor unit, LevelUpState state)
        {
            return unit.Unit.IsMainCharacter == true || unit.Unit.IsStoryCompanion() == true || unit.Unit.IsCustomCompanion() == true;
        }

        // Token: 0x0600B25D RID: 45661 RVA: 0x002E9E59 File Offset: 0x002E8059
        public override string GetUITextInternal(UnitDescriptor unit)
        {
            return "";
        }

       

    }
}

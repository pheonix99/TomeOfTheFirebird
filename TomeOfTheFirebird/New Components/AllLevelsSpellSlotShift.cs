using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components
{
	[AllowedOn(typeof(BlueprintFeature), false)]
	public class AllLevelsSpellSlotShift : UnitFactComponentDelegate
	{
		public override void OnActivate()
		{
			AllLevelsSpellSlotShiftPart unitPartExtraSpellsPerDay = base.Owner.Ensure<AllLevelsSpellSlotShiftPart>();
			foreach (BlueprintSpellbookReference v in blueprintSpellbookReferences)
			{


				if (unitPartExtraSpellsPerDay.Changes.TryGetValue(v, out AllLevelsSpellSlotShiftPart.Shift levels))
				{
					levels.ShiftVal += Amount;
				}
				else
				{
					unitPartExtraSpellsPerDay.Changes.Add(v, new AllLevelsSpellSlotShiftPart.Shift { ShiftVal = Amount });
				}
			}

		}

		// Token: 0x0600C364 RID: 50020 RVA: 0x00315DF0 File Offset: 0x00313FF0
		public override void OnDeactivate()
		{
			base.OnDeactivate();
			AllLevelsSpellSlotShiftPart unitPartExtraSpellsPerDay = base.Owner.Ensure<AllLevelsSpellSlotShiftPart>();
			foreach (BlueprintSpellbookReference v in blueprintSpellbookReferences)
			{


				if (unitPartExtraSpellsPerDay.Changes.TryGetValue(v, out AllLevelsSpellSlotShiftPart.Shift levels))
				{
					levels.ShiftVal -= Amount;
				}
				else
				{
					unitPartExtraSpellsPerDay.Changes.Add(v, new AllLevelsSpellSlotShiftPart.Shift { ShiftVal = -Amount });
				}
			}
		}


		public int Amount;
		public BlueprintCharacterClassReference ClassReference;
		public List<BlueprintSpellbookReference> blueprintSpellbookReferences = new();
	}
}

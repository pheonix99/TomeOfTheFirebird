using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Root.Strings;
using Kingmaker.Localization;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Class.LevelUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components.Prerequisites
{

	[AllowMultipleComponents]
	public class PrerequisiteAbilityFromList : Prerequisite
	{

		public ReferenceArrayProxy<BlueprintAbility, BlueprintAbilityReference> Abilities
		{
			get
			{
				return this.m_Abilities;
			}
		}

		


		public override bool CheckInternal(FeatureSelectionState selectionState, UnitDescriptor unit, LevelUpState state)
		{
			int num = 0;
			foreach (BlueprintAbility blueprintFeature in this.Abilities)
			{
				if (unit.HasFact(blueprintFeature))
				{
					num++;
					if ( num >= this.Amount)
					{
						return true;
					}
				}
			}
			return false;
		}

		public string TempUIOverride = ""; 

		public override string GetUITextInternal(UnitDescriptor unit)
		{
			

			StringBuilder stringBuilder = new StringBuilder();
			if (this.Amount <= 1)
			{
				stringBuilder.Append(string.Format("{0}:\n", UIStrings.Instance.Tooltips.OneFrom));
			}
			else
			{
				stringBuilder.Append(string.Format(UIStrings.Instance.Tooltips.FeaturesFrom, this.Amount));
				stringBuilder.Append(":\n");
			}
			for (int i = 0; i < this.Abilities.Length; i++)
			{
				stringBuilder.Append(this.Abilities[i].Name ?? this.Abilities[i].name);
				if (i < this.Abilities.Length - 1)
				{
					stringBuilder.Append("\n");
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x040070FB RID: 28923
	
		public BlueprintAbilityReference[] m_Abilities;

		
		public int Amount;
	}
}

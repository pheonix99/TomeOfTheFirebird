using JetBrains.Annotations;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Root.Strings;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.LevelUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components.Prerequisites
{
    [AllowedOn(typeof(BlueprintFeature))]
    public class PrerequisiteClassLevelPerRank : Prerequisite
    {
        public BlueprintCharacterClassReference m_CharacterClass;
        public BlueprintCharacterClass CharacterClass
        {
            get
            {
                BlueprintCharacterClassReference characterClass = this.m_CharacterClass;
                if (characterClass == null)
                {
                    return null;
                }
                return characterClass.Get();
            }
        }
        public int[] requirements = new int[] { 1 };

        private int GetRequiredLevel(UnitDescriptor unit)
        {
            BlueprintFeature ownerFeature = OwnerBlueprint as BlueprintFeature;
            int currentRank = unit.Progression.Features.GetRank(ownerFeature);
            int requiredLevel;
            if (currentRank < requirements.Length)
            {
                requiredLevel = requirements[currentRank];
            }
            else
            {
                requiredLevel = requirements.Last();
            }
            return requiredLevel;
        }

        public override bool CheckInternal([CanBeNull] FeatureSelectionState selectionState, [NotNull] UnitDescriptor unit, [CanBeNull] LevelUpState state)
        {
            if (OwnerBlueprint is not BlueprintFeature)
                return false;

            
            return GetClassLevel (unit)>= GetRequiredLevel(unit);

        }

        private int GetClassLevel(UnitDescriptor unit)
        {
            int num = 0;
            foreach (ClassLevelsForPrerequisites classLevelsForPrerequisites in unit.Progression.Features.SelectFactComponents<ClassLevelsForPrerequisites>())
            {
                if (classLevelsForPrerequisites.FakeClass == this.CharacterClass)
                {
                    num += (int)(classLevelsForPrerequisites.Modifier * (double)unit.Progression.GetClassLevel(classLevelsForPrerequisites.ActualClass) + (double)classLevelsForPrerequisites.Summand);
                }
            }
            return unit.Progression.GetClassLevel(this.CharacterClass) + num;
        }

        public override string GetUITextInternal(UnitDescriptor unit)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Format("{0} {1}: {2}", this.CharacterClass.Name, UIStrings.Instance.Tooltips.Level, this.GetRequiredLevel(unit)));
            if (unit != null)
            {
                stringBuilder.Append("\n");
                stringBuilder.Append(string.Format(UIStrings.Instance.Tooltips.CurrentValue, this.GetClassLevel(unit)));
            }
            return stringBuilder.ToString();
        }
    }
}

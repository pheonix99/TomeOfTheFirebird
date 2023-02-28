using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.New_Components.BloodlineMutation;

namespace TomeOfTheFirebird.New_Content.Features
{
    class BloodHavoc
    {
        public static void Make()
        {
            if (Settings.IsEnabled("BloodHavoc"))
            {
                var config = MakerTools.MakeFeature("BloodHavocFeature", "Blood Havoc", "Whenever you cast a bloodrager or sorcerer spell that deals damage, add 1 point of damage per die rolled. This benefit applies only to damaging spells that belong to schools you have selected with Spell Focus or that are bloodline spells for your bloodline. ");
                config.AddComponent<BloodHavocComponent>();
                config.AddPrerequisiteClassLevel("d77e67a814d686842802c9cfd8ef8499", 4, group: Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any);
                config.AddPrerequisiteClassLevel("b3a505fb61437dc4097f43c3f8f9a4cf", 1, group: Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any);
                config.AddPrerequisiteArchetypeLevel(archetype: "d078b2ef073f2814c9e338a789d97b73", characterClass: "45a4607686d96a1498891b3286121780", level:1, group: Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any);
                if (Settings.IsEnabled("EldritchScionSage"))
                {
                    config.AddPrerequisiteArchetypeLevel(archetype: "EldritchScionSageArchetype", characterClass: "45a4607686d96a1498891b3286121780", level: 1, group: Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any);
                }
                config.AddPrerequisiteClassLevel("b3a505fb61437dc4097f43c3f8f9a4cf", 1, group: Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any);
                config.Configure();

                BloodlineMutations.AddToSelectors("BloodHavocFeature");

            }
            else
            {
                var config = MakerTools.MakeFeature("BloodHavocFeature", "Blood Havoc", "Whenever you cast a bloodrager or sorcerer spell that deals damage, add 1 point of damage per die rolled. This benefit applies only to damaging spells that belong to schools you have selected with Spell Focus or that are bloodline spells for your bloodline. ");
                
                
                config.Configure();

            }
        }
        /*
         * Although heirs to similar arcane bloodlines may share commonalities, the unique circumstances in which a bloodline enters a bloodrager or sorcerer’s lineage can result in the manifestation of particularly strange or unusual bloodline powers known as mutations. Whenever a bloodrager or a sorcerer gains a new bloodline power, she can swap her bloodline power for a bloodline mutation whose prerequisites she meets. Once this choice is made, it cannot be changed, and a bloodrager or sorcerer cannot swap a bloodline power that she has altered or replaced with an archetype for a bloodline mutation. A bloodrager need not be in a bloodrage to use her bloodline mutation powers.

Alternatively, a bloodrager or sorcerer can select a bloodline mutation in place of a bloodline bonus feat, provided her class level is at least equal to the level of the bloodline ability the mutation normally replaces. 
         */
        /*
         * Whenever you cast a bloodrager or sorcerer spell that deals damage, add 1 point of damage per die rolled. This benefit applies only to damaging spells that belong to schools you have selected with Spell Focus or that are bloodline spells for your bloodline. This ability replaces the sorcerer’s 1st-level bloodline power or the bloodrager’s 4th-level bloodline power.
         */
    }
}

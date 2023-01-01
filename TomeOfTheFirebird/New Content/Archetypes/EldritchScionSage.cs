using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.New_Content.Bloodlines;

namespace TomeOfTheFirebird.New_Content.Archetypes
{
    class EldritchScionSage
    {
        public static void Make()
        {
            var magus = BlueprintTool.Get<BlueprintCharacterClass>("45a4607686d96a1498891b3286121780");
            var escion = BlueprintTool.Get<BlueprintArchetype>("d078b2ef073f2814c9e338a789d97b73");
            var sagesorc = BlueprintTool.Get<BlueprintArchetype>("00b990c8be2117e45ae6514ee4ef561c");
            var ArcaneBloodlineRequisiteFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("60d8632e96739a74dbac23dd078d205d");
            var spellbook = TabletopTweaks.Core.Utilities.Helpers.CreateBlueprint<BlueprintSpellbook>(Main.TotFContext, "EldritchScionSageSpellbook", x => {
                x.AddComponent<AddCustomSpells>(x =>
                {
                    x.CasterLevel = 19;
                    x.Count = 6;
                    x.MaxSpellLevel = 6;
                    x.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>("ba0401fdeb4062f40a7aa95b6f07fe89");
                });
                x.Name = escion.Spellbook.Name;
                x.m_SpellsPerDay = escion.Spellbook.m_SpellsPerDay;
                x.m_SpellsKnown = escion.Spellbook.m_SpellsKnown;
                x.m_SpellList = escion.Spellbook.m_SpellList;
                x.CastingAttribute = Kingmaker.EntitySystem.Stats.StatType.Intelligence;
                x.Spontaneous = true;
                x.CantripsType = CantripsType.Cantrips;
                x.IsArcane = true;
            });


            var sysname = "EldritchScionSageArchetype";
            var bp = Main.TotFContext.Blueprints.GetGUID(sysname);
            var EScionSage = ArchetypeConfigurator.New(sysname, bp.ToString());
            EScionSage.SetLocalizedName(LocalizationTool.CreateString(sysname + ".Name", "Eldritch Scion (Sage)"));
            EScionSage.SetLocalizedDescription(LocalizationTool.CreateString(sysname + ".Desc", "Unlike typical magi, sage eldritch scions do not only study tomes of magic or spend time learning to combine martial and magical {g|Encyclopedia:Skills}skills{/g}. Rather, their magic comes from the knowledge and traditions that your bloodline accumulated through the generations, not just from force of personality. You use your {g|Encyclopedia:Intelligence}Intelligence{/g} to determine the effectiveness of your spells and magus class features like a normal magus, and to determine the effects of bloodline powers like a sage sorcerer."));
            EScionSage.SetReplaceSpellbook(spellbook);
            EScionSage.SetBuildChanging(true);
            EScionSage.SetParentClass(magus);
            EScionSage.AddPrerequisiteFeature(ArcaneBloodlineRequisiteFeature, group: Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any);
            
            EScionSage.AddToAddFeatures(1, "7d990675841a7354c957689a6707c6c2", "67657dbfaa0a47e4b5025a132c6e0403");//Sage Bloodline and DLC3 hidden feature
            EScionSage.AddToAddFeatures(14, "836879fcd5b29754eb664a090bd6c22f");//Improced spell combat
            EScionSage.AddToAddFeatures(18, "379887a82a7248946bbf6d0158663b5e");//Greater spell combat

            EScionSage.AddToRemoveFeatures(8, "836879fcd5b29754eb664a090bd6c22f");//Improved Spell Combat
            EScionSage.AddToRemoveFeatures(14, "379887a82a7248946bbf6d0158663b5e");//Greater Spell Combat
            EScionSage.AddToRemoveFeatures(4, "61fc0521e9992624e9c518060bf89c0f");//Spell Recall
            EScionSage.AddToRemoveFeatures(11, "0ef6ec1c2fdfc204fbd3bff9f1609490");//Improved Spell Recall
            var built = EScionSage.Configure();
            if (PheonixBloodline.BloodlineRequisiteFeature == null || Main.TotFContext.NewContent.Archetypes.IsDisabled("EldritchScionSage"))
                return;
            built.AddComponent<PrerequisiteNoFeature>(x =>
            {
                x.m_Feature = PheonixBloodline.BloodlineRequisiteFeature;
                x.Group = Prerequisite.GroupType.Any;
            });
           

            var sageRay = BlueprintTool.Get<BlueprintAbility>("d6e72a6f936f8954596451be15fd083a");
            sageRay.GetComponent<ContextRankConfig>().m_BaseValueType = ContextRankBaseValueType.SummClassLevelWithArchetype;
            sageRay.GetComponent<ContextRankConfig>().m_Class = sageRay.GetComponent<ContextRankConfig>().m_Class.AppendToArray(magus.ToReference<BlueprintCharacterClassReference>());
            sageRay.GetComponent<ContextRankConfig>().Archetype = (built.ToReference<BlueprintArchetypeReference>());

            magus.m_Archetypes = magus.m_Archetypes.AppendToArray(built.ToReference<BlueprintArchetypeReference>());

            var newArcana = BlueprintTool.Get<BlueprintParametrizedFeature>("c66e61dea38f3d8479a54eabec20ac99");
            newArcana.GetComponent<PrerequisiteArchetypeLevel>().Group = Prerequisite.GroupType.Any;
            newArcana.AddComponent<PrerequisiteArchetypeLevel>(x=> {
                x.m_CharacterClass = magus.ToReference<BlueprintCharacterClassReference>();
                x.m_Archetype = built.ToReference<BlueprintArchetypeReference>();
                x.Group = Prerequisite.GroupType.Any;
                x.Level = 1;
            
            });
        }

        public static void Link()
        {

        }
    }
}

﻿using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using TabletopTweaks.Core.Utilities;
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
            var spellbook = TabletopTweaks.Core.Utilities.Helpers.CreateBlueprint<BlueprintSpellbook>(Main.TotFContext, "EldritchScionSageSpellbook", x =>
            {
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
            EScionSage.SetLocalizedName(sysname + ".Name");
            EScionSage.SetLocalizedDescription(sysname + ".Desc");
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
            if (TotFBloodlineTools.BloodlineRequisiteFeature == null || Settings.IsDisabled("EldritchScionSage"))
                return;
            built.AddComponent<PrerequisiteNoFeature>(x =>
            {
                x.m_Feature = TotFBloodlineTools.BloodlineRequisiteFeature;
                x.Group = Prerequisite.GroupType.Any;
            });


            var sageRay = BlueprintTool.Get<BlueprintAbility>("d6e72a6f936f8954596451be15fd083a");
            sageRay.GetComponent<ContextRankConfig>().m_BaseValueType = ContextRankBaseValueType.SummClassLevelWithArchetype;
            sageRay.GetComponent<ContextRankConfig>().m_Class = sageRay.GetComponent<ContextRankConfig>().m_Class.AppendToArray(magus.ToReference<BlueprintCharacterClassReference>());
            sageRay.GetComponent<ContextRankConfig>().Archetype = (built.ToReference<BlueprintArchetypeReference>());

            magus.m_Archetypes = magus.m_Archetypes.AppendToArray(built.ToReference<BlueprintArchetypeReference>());

            var newArcana = BlueprintTool.Get<BlueprintParametrizedFeature>("c66e61dea38f3d8479a54eabec20ac99");
            newArcana.GetComponent<PrerequisiteArchetypeLevel>().Group = Prerequisite.GroupType.Any;
            newArcana.AddComponent<PrerequisiteArchetypeLevel>(x =>
            {
                x.m_CharacterClass = magus.ToReference<BlueprintCharacterClassReference>();
                x.m_Archetype = built.ToReference<BlueprintArchetypeReference>();
                x.Group = Prerequisite.GroupType.Any;
                x.Level = 1;

            });


        }

        public static void Link()
        {
            if (TotFBloodlineTools.BloodlineRequisiteFeature == null || Settings.IsDisabled("EldritchScionSage"))
                return;


            
            BlueprintFeatureSelection bloodlineselector = BlueprintTool.Get<BlueprintFeatureSelection>("24bef8d1bee12274686f6da6ccbc8914");
            var magus = BlueprintTool.GetRef<BlueprintCharacterClassReference>("45a4607686d96a1498891b3286121780");
            var escionsage = BlueprintTool.GetRef<BlueprintArchetypeReference>("EldritchScionSageArchetype");
            foreach (var v in bloodlineselector.m_AllFeatures)
            {
                var v2 = BlueprintTools.GetBlueprint<BlueprintProgression>(v.Guid);
                if (v2 != null)
                {
                    ProgressionConfigurator.For(v2).ModifyLevelEntries(x =>
                    {
                        foreach (var q in x.m_Features)
                        {

                            var feature = q.Get();
                            AddKnownSpell referant = feature.GetComponent<AddKnownSpell>();
                            if (referant != null)
                            {
                                q.Get().AddComponent<AddKnownSpell>(x =>
                                {
                                    x.m_Spell = referant.m_Spell;
                                    x.m_CharacterClass = magus;
                                    x.m_Archetype = escionsage;
                                    x.SpellLevel = referant.SpellLevel;
                                });
                                Main.TotFContext.Logger.LogPatch($"Proliferated spell {referant.m_Spell} onto Eldritch Scion - Sage", feature);
                            }
                        }

                    }).AddToArchetypes("EldritchScionSageArchetype").Configure();
                }
            }
        }
    }
}

using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Utilities;
using TomeOfTheFirebird.Config;
using TomeOfTheFirebird.Crusade;
using TomeOfTheFirebird.Fixes;
using TomeOfTheFirebird.Modified_Content.Crusade;
using TomeOfTheFirebird.New_Content.Feats;
using TomeOfTheFirebird.New_Content.Items;
using TomeOfTheFirebird.New_Content.Mercies;
using TomeOfTheFirebird.New_Content.Spells;
using TomeOfTheFirebird.New_Spells;
using TomeOfTheFirebird.NewContent.Features;
using TomeOfTheFirebird.QuestTweaks;
using TomeOfTheFirebird.Reference;

namespace TomeOfTheFirebird
{
    static class BuildContent
    {
        static BlueprintAbility gloomblind;
       
      
   
        static BlueprintAbility keenEdge;
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch
        {
            static bool Initialized;

            [HarmonyPriority(Priority.First)]
            static void Postfix()
            {
                if (Initialized) return;
                Initialized = true;
                Main.Log("Building new spells");
                
                 gloomblind = GloomblindBolts.BuildSpell();
               
                BoneFists.BuildSpell();
                TelekineticStrikes.BuildSpell();
                SpearOfPurity.BuildSpearOfPurity();

                ArcanistFixes.DoFixes();
                ChainsOfFire.BuildSpell();
                PurifierLimitedCures.AddPurifierLimitedCures();
                ElementalShieldSpells.Build();
                ProdigiousTWF.AddProdigiousTWF();
                HealMount.Build();
                keenEdge = KeenEdge.BuildSPell();
                FreezingSphere.Build();
                MonavicsUseTwoHanders.Do();
                CrusadeBuffTweaks.PermaMonsterSlayers();
                CrusadeBuffTweaks.PermaLocalProduction();
                DawnOfDragons.Fix();
                
                RadianceLevel2Fix.Fixes();
                PaladinGear.Build();
                ExtraMercies.Build();
              
                SunderingStrike.Build();
                DiscordantSong.Make();
                EntropicShield.Make();

                BlueprintFeature ActsBook = Resources.GetBlueprint<BlueprintFeature>("f16ea400ed67470b83cfd6c0dedbce6f");
                if (ActsBook.Icon != null)
                {
                    Main.Log($"Acts Of Iomedae reports Icon Name {ActsBook.Icon.name} ");
                    
                }
                else
                {
                    Main.Log($"Acts Of Iomedae Reports No Icon");
                }

            }
        }

        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch2
        {
            static bool Initialized;

            [HarmonyPriority(Priority.VeryLow)]
            static void Postfix()
            {
                if (Initialized) return;
                Initialized = true;
                Main.Log("Adding to spell lists");

                if (ModSettings.NewContent.Spells.IsEnabled("GloomblindBolts"))
                {
                    //TODO check bloodrager access
                    gloomblind.AddToSpellList(SpellTools.SpellList.BloodragerSpellList, 3);
                    gloomblind.AddToSpellList(SpellTools.SpellList.MagusSpellList, 3);
                    gloomblind.AddToSpellList(SpellTools.SpellList.WizardSpellList, 3);
                    gloomblind.AddToSpellList(SpellTools.SpellList.WitchSpellList, 3);
                }
                
               
                

                if (ModSettings.NewContent.Spells.IsEnabled("KeenEdge"))
                {
                    keenEdge.AddToSpellList(SpellTools.SpellList.BloodragerSpellList, 3);
                    keenEdge.AddToSpellList(SpellTools.SpellList.InquisitorSpellList, 3);
                    keenEdge.AddToSpellList(SpellTools.SpellList.MagusSpellList, 3);
                    keenEdge.AddToSpellList(SpellTools.SpellList.WizardSpellList, 3);
                }
                AddItemsToShop.Add();
                FixExtraHitsOnProcs.FixFirebrand();
                FixExtraHitsOnProcs.FixRandomWeaponsRiders();
                FixExtraHitsOnProcs.FixClawsOfSacredBeast();

                BoneFists.AddToLists();
                CavalierFixes.FixOrderAbilityDisplays();
                CavalierFixes.FixOrderOfTheStarChannelAssistance();
                ExtraMercies.AddToThings();
            }
        }

        private static void AddToSpellLists(BlueprintAbility spell)
        {
            Main.Log($"Adding {spell.Name} to spell lists");
            foreach(SpellListComponent f in spell.Components.OfType<SpellListComponent>())
            {
                Main.Log($"Adding {spell.Name} to ${f.SpellList.NameSafe()}");
                if (f.SpellList.AssetGuidThreadSafe == Guids.WizSpellList)
                {
                    AddToWizardSpellLists(spell, f.SpellLevel);
                }
                else if(f.SpellList.AssetGuidThreadSafe == Guids.ClericSpellList)
                {
                    SpellListConfigurator.For(Guids.ClericSpellList).AddToSpellsByLevel(new SpellLevelList(f.SpellLevel) { m_Spells = new List<BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    if (f.SpellLevel <= 6)
                    {
                        SpellListConfigurator.For(Guids.WarpriestSpellList).AddToSpellsByLevel(new SpellLevelList(f.SpellLevel) { m_Spells = new List<BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    }
                }
                else
                {
                    SpellListConfigurator.For(f.SpellList.AssetGuidThreadSafe).AddToSpellsByLevel(new SpellLevelList(f.SpellLevel) { m_Spells = new List<BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                }
                
            }
        }

        public static void AddToWizardSpellLists(BlueprintAbility spell, int level)
        {
            SpellListConfigurator.For(Guids.WizSpellList).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
            switch (spell.School)
            {
                case SpellSchool.None:
                    SpellListConfigurator.For(Guids.ThasAbj).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasConj).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.THasEnch).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasEvo).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasIllu).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasNecro).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasTrans).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    break;
                case SpellSchool.Abjuration:
                    SpellListConfigurator.For(Guids.WizAbjSpellList).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasAbj).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasConj).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.THasEnch).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                   
                    SpellListConfigurator.For(Guids.ThasIllu).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    
                    SpellListConfigurator.For(Guids.ThasTrans).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    break;
                case SpellSchool.Conjuration:
                    SpellListConfigurator.For(Guids.WizConjSpellList).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasAbj).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasConj).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.THasEnch).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasEvo).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    
                    SpellListConfigurator.For(Guids.ThasNecro).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    
                    break;
                case SpellSchool.Divination:
                    SpellListConfigurator.For(Guids.WizDivSpellList).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasAbj).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasConj).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.THasEnch).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasEvo).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasIllu).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasNecro).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasTrans).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    break;
                case SpellSchool.Enchantment:
                    SpellListConfigurator.For(Guids.WizEnchSpellList).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();

                    SpellListConfigurator.For(Guids.ThasAbj).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasConj).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.THasEnch).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasEvo).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasIllu).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();


                    SpellListConfigurator.For(Guids.FeyspeakerSpellList).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    break;
                case SpellSchool.Evocation:
                    SpellListConfigurator.For(Guids.WizEvocSpellList).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    
                    SpellListConfigurator.For(Guids.ThasConj).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.THasEnch).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasEvo).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasIllu).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    
                    SpellListConfigurator.For(Guids.ThasTrans).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    break;
                case SpellSchool.Illusion:
                    SpellListConfigurator.For(Guids.WizIlluSpellList).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasAbj).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    
                    SpellListConfigurator.For(Guids.THasEnch).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasEvo).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasIllu).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasNecro).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.FeyspeakerSpellList).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    
                    break;
                case SpellSchool.Necromancy:
                    SpellListConfigurator.For(Guids.WizNecSpellList).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                   
                    SpellListConfigurator.For(Guids.ThasConj).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    
                    SpellListConfigurator.For(Guids.ThasEvo).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasIllu).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasNecro).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasTrans).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    break;
                case SpellSchool.Transmutation:
                    SpellListConfigurator.For(Guids.WizTransSpellList).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasAbj).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasConj).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    
                    SpellListConfigurator.For(Guids.ThasEvo).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    
                    SpellListConfigurator.For(Guids.ThasNecro).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasTrans).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    break;
                case SpellSchool.Universalist:
                    SpellListConfigurator.For(Guids.ThasAbj).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasConj).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.THasEnch).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasEvo).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasIllu).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasNecro).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    SpellListConfigurator.For(Guids.ThasTrans).AddToSpellsByLevel(new SpellLevelList(level) { m_Spells = new List<Kingmaker.Blueprints.BlueprintAbilityReference>() { spell.ToReference<BlueprintAbilityReference>() } }).Configure();
                    break;
                default:
                    break;
            }
        }

    }
}

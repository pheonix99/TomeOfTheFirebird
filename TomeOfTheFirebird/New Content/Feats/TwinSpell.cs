using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;
using static TabletopTweaks.Core.MechanicsChanges.MetamagicExtention;

namespace TomeOfTheFirebird.New_Content.Feats
{
    /*
    static class TwinSpell
    {
        public static void AddTwinSpell()
        {
            var TwinSpellConfig = MakerTools.MakeFeature("TwinSpellFeat", LocalizationTool.GetString("TwinSpell.Name"), LocalizationTool.GetString("TwinSpell.Desc"));
            if (Settings.IsEnabled("TwinSpell"))
            {
                TwinSpellConfig.AddToGroups(FeatureGroup.Feat, FeatureGroup.WizardFeat);
                TwinSpellConfig.AddComponent<AddMetamagicFeat>(x => x.Metamagic = (Metamagic)TabletopTweaks.Core.MechanicsChanges.MetamagicExtention.CustomMetamagic.Twin);
                TwinSpellConfig.AddFeatureTagsComponent(Kingmaker.Blueprints.Classes.Selection.FeatureTag.Magic | Kingmaker.Blueprints.Classes.Selection.FeatureTag.Metamagic);
                TwinSpellConfig.AddPrerequisiteStatValue(Kingmaker.EntitySystem.Stats.StatType.Intelligence, 3);
                TwinSpellConfig.AddRecommendationRequiresSpellbook();
            }
            var TwinSpell = TwinSpellConfig.Configure();
            if (Settings.IsEnabled("TwinSpell"))
            {
                TabletopTweaks.Core.MechanicsChanges.MetamagicExtention.RegisterMetamagic(
                    context: Main.TotFContext,
                    metamagic: (Metamagic)TabletopTweaks.Core.MechanicsChanges.MetamagicExtention.CustomMetamagic.Twin,
                    name: "Twin",
                    icon: null,
                    defaultCost: 4,
                    favoriteMetamagic: null,
                    metamagicMechanics: TwinSpellMechanics.Instance,
                    metamagicFeat: TwinSpell);
            }
        }

        public static void UpdateSpells()
        {
            if (Settings.IsDisabled("TwinSpell"))
            {
                return;
            }

            var spells = SpellTools.GetAllSpells();
            foreach (var spell in spells)
            {
                bool validTwin = !spell.GetComponent<AbilityEffectStickyTouch>();
                if (validTwin)
                {
                    if (!spell.AvailableMetamagic.HasMetamagic((Metamagic)CustomMetamagic.Twin))
                    {
                        spell.AvailableMetamagic |= (Metamagic)CustomMetamagic.Twin;
                        Main.TotFContext.Logger.LogPatch("Enabled Twin Metamagic", spell);
                    }
                };
            }
        }


        private class TwinSpellMechanics : IRulebookHandler<RuleCastSpell>, ISubscriber
        {

            public static TwinSpellMechanics Instance = new();

            public void OnEventAboutToTrigger(RuleCastSpell evt)
            {

            }

            public void OnEventDidTrigger(RuleCastSpell evt)
            {
                var isSolidShadows = evt.Context?.HasMetamagic((Metamagic)CustomMetamagic.Twin) ?? false;
                if (!isSolidShadows)
                    return;

                if (evt.IsDuplicateSpellApplied || !evt.Success || evt.Spell.Blueprint.Type != AbilityType.Spell || (evt.Spell.Range == AbilityRange.Touch && evt.Spell.Blueprint.GetComponent<AbilityEffectStickyTouch>() != null))
                {
                    return;
                }


                Rulebook.Trigger<RuleCastSpell>(new RuleCastSpell(evt.Spell, evt.SpellTarget)
                {
                    IsDuplicateSpellApplied = true
                });
            }
        }
    }
    */
}

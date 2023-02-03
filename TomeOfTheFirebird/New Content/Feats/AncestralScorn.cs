using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.ElementsSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.NewEvents;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.New_Content.Feats
{
    class AncestralScorn
    {

        public static void Make()
        {
            string desc = "The fury you harbor for your fiendish ancestors gives evil outsiders great reason to fear you.\nBenefit: Whenever you successfully demoralize an outsider of the evil subtype with an Intimidate check, it becomes sickened for 1 round in addition to being affected by the normal effects of being demoralized. If you beat the DC by 5 or more, the creature is nauseated for 1 round instead.";

            if (Settings.IsEnabled("AncestralScorn"))
            {
                var config = MakerTools.MakeFeature("AncestralScorn", "Ancestral Scorn", desc, groups: FeatureGroup.Feat);
                config.AddPrerequisiteStatValue(Kingmaker.EntitySystem.Stats.StatType.SkillPersuasion, 5);
                config.AddPrerequisiteFeature("5c4e42124dc2b4647af6e36cf2590500", group:Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any);
                config.AddPrerequisiteFeature("5e464d1d5fd0e7a4380b6ce60ef2c83b", group:Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any);//Arue
                config.AddRecommendationHasFeature("ceea53555d83f2547ae5fc47e0399e14");
                config.AddRecommendationHasFeature("bcbd674ec70ff6f4894bb5f07b6f4095");
                config.AddRecommendationHasFeature("fc37b70e3d064a147a3a99db4a86ee12");
                config.AddComponent<AncestralScornComponent>();
                config.SetIsClassFeature();
                config.Configure();
            }
            else
            {
                MakerTools.MakeFeature("AncestralScorn", "Ancestral Scorn", desc).Configure();
            }
        }
        //Need to interpile Demoralize for this one

        /*
         *  Ancestral Scorn
Source Blood of Fiends pg. 24
The fury you harbor for your fiendish ancestors gives evil outsiders great reason to fear you.

Prerequisites: Intimidate 5 ranks, tiefling.

Benefit: Whenever you successfully demoralize an outsider of the evil subtype with an Intimidate check, it becomes sickened for 1 round in addition to being affected by the normal effects of being demoralized. If you beat the DC by 5 or more, the creature is nauseated for 1 round instead.

Normal: Demoralizing a foe with a successful Intimidate check causes it to become shaken for 1 round, +1 round for every 5 by which you beat the DC.
         */
    }

    public class AncestralScornComponent : UnitFactComponentDelegate, IInitiatorDemoralizeHandler
    {
        private static BlueprintFeature _evilSubtype;
        private static BlueprintFeature EvilSubtype
        {
            get
            {
                _evilSubtype ??= BlueprintTool.Get<BlueprintFeature>("5279fc8380dd9ba419b4471018ffadd1");
                return _evilSubtype;
            }
        }

        private static BlueprintFeature _outsiderType;
        private static BlueprintFeature OutsiderType
        {
            get
            {
                _outsiderType ??= BlueprintTool.Get<BlueprintFeature>("9054d3988d491d944ac144e27b6bc318");
                return _outsiderType;
            }
        }

        private static BlueprintBuff _sickened;
        private static BlueprintBuff Sickened
        {
            get
            {
                _sickened ??= BlueprintTool.Get<BlueprintBuff>("4e42460798665fd4cb9173ffa7ada323");
                return _sickened;
            }
        }

        private static BlueprintBuff _nauseated;
        private static BlueprintBuff Nauseated
        {
            get
            {
                _nauseated ??= BlueprintTool.Get<BlueprintBuff>("956331dba5125ef48afe41875a00ca0e");
                return _nauseated;
            }
        }

        public void AfterIntimidateSuccess(Demoralize action, RuleSkillCheck intimidateCheck, Buff appliedBuff)
        {
            var target = ContextData<MechanicsContext.Data>.Current?.CurrentTarget?.Unit;
            if (target is null)
            {

                return;
            }
            if (appliedBuff is null)
            {

                return;
            }

            var caster = Context.MaybeCaster;
            if (caster is null)
            {

                return;
            }

            if (!target.HasFact(EvilSubtype) || !target.HasFact(OutsiderType))
            {
                return;
            }

            target.AddBuff(Sickened, Context, new Rounds(1).Seconds);
            
            var succeedBy = intimidateCheck.RollResult - intimidateCheck.DC;
            
            if (succeedBy >= 5)
            {
                target.AddBuff(Nauseated, Context, new Rounds(1).Seconds);
            }
        }
    }
}

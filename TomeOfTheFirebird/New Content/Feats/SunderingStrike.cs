using BlueprintCore.Blueprints.Configurators.Buffs;
using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.Config;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.New_Content.Feats
{
    public class SunderingStrike
    {
        public static void Build()
        {
            var disarmingstrikebuff = Resources.GetBlueprint<BlueprintBuff>("a2a60c12e69603e47bb20218602a1119");

            var SunderingBuff = MakerTools.MakeBuff("SunderingStrikeBuff", "Sundering Strike (Hidden Buff)", "", disarmingstrikebuff.Icon);
            SunderingBuff.SetFlags(BlueprintBuff.Flags.HiddenInUi, BlueprintBuff.Flags.StayOnDeath);
            SunderingBuff.SetIsClassFeature(true);

            SunderingBuff.AddCombatManeuverOnCriticalHit(Kingmaker.RuleSystem.Rules.CombatManeuver.SunderArmor);

            var buffbuild = SunderingBuff.Configure();
            var stguid = ModSettings.Blueprints.GetGUID("SunderingStrikeToggleAbility");
            var SunderingToggle = ActivatableAbilityConfigurator.New("SunderingStrikeToggleAbility", stguid.ToString());
            SunderingToggle.SetGroup(Kingmaker.UnitLogic.ActivatableAbilities.ActivatableAbilityGroup.CombatManeuverStrike);
            SunderingToggle.SetBuff(buffbuild.AssetGuidThreadSafe);
            SunderingToggle.SetWeightInGroup(2);
            SunderingToggle.SetIsOnByDefault(true);
            SunderingToggle.SetDeactivateImmediately(true);
            SunderingToggle.SetActivationType(Kingmaker.UnitLogic.ActivatableAbilities.AbilityActivationType.OnUnitAction);
            SunderingToggle.SetIcon(disarmingstrikebuff.Icon);

            var toggle = SunderingToggle.Configure();

            var SunderingFeat = MakerTools.MakeFeature("SunderingStrike", "Sundering Strike", "Placeholder: On Crit, Use Sunder Armor", false);
            SunderingFeat.SetFeatureGroups(FeatureGroup.Feat, FeatureGroup.CombatFeat);
            SunderingFeat.SetRanks(1);
            SunderingFeat.SetIsClassFeature(true);
            SunderingFeat.AddFacts(new string[] { toggle.AssetGuidThreadSafe });
            SunderingFeat.PrerequisiteFeature("9719015edcbf142409592e2cbaab7fe1");
            SunderingFeat.PrerequisiteStat(Kingmaker.EntitySystem.Stats.StatType.Intelligence, 13);
            SunderingFeat.PrerequisiteStat(Kingmaker.EntitySystem.Stats.StatType.BaseAttackBonus, 5);
            SunderingFeat.SetFeatureTags(FeatureTag.Attack, FeatureTag.CombatManeuver);

            var sunderprocbuild = SunderingFeat.Configure();

            FeatureConfigurator.For("9719015edcbf142409592e2cbaab7fe1").AddToIsPrerequisiteFor(sunderprocbuild.AssetGuidThreadSafe);

            FeatTools.AddAsFeat(sunderprocbuild);
        }

    }
}

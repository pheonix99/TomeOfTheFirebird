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
          
            
            //var stguid = ModSettings.Blueprints.GetGUID("SunderingStrikeToggleAbility");
            var SunderingToggle = MakerTools.MakeToggle("SunderingStrikeToggleAbility", "Sundering Strike", "Whenever you score a critical hit with a melee attack, you can sunder your opponent’s weapon, in addition to the normal damage dealt by the attack. If your confirmation roll exceeds your opponent’s CMD, you may deal damage to your opponent’s weapon as if from the sunder combat maneuver (roll normal damage to the weapon separately). This does not provoke an attack of opportunity.", disarmingstrikebuff.Icon);
            //var SunderingToggle = ActivatableAbilityConfigurator.New("SunderingStrikeToggleAbility", stguid.ToString());
            
            SunderingToggle.SetGroup(Kingmaker.UnitLogic.ActivatableAbilities.ActivatableAbilityGroup.CombatManeuverStrike);
            SunderingToggle.SetDeactivateAfterFirstRound(false);
            SunderingToggle.SetDeactivateIfCombatEnded(false);
            SunderingToggle.SetOnlyInCombat(false);
            SunderingToggle.SetActivateOnUnitAction(Kingmaker.UnitLogic.ActivatableAbilities.AbilityActivateOnUnitActionType.Attack);
            SunderingToggle.SetActivateWithUnitCommand(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Free);
            SunderingToggle.SetBuff(buffbuild.AssetGuidThreadSafe);
            SunderingToggle.SetWeightInGroup(1);
            SunderingToggle.SetIsOnByDefault(true);
            SunderingToggle.SetDeactivateImmediately(true);
            SunderingToggle.SetActivationType(Kingmaker.UnitLogic.ActivatableAbilities.AbilityActivationType.OnUnitAction);
            SunderingToggle.SetIcon(disarmingstrikebuff.Icon);

            var toggle = SunderingToggle.Configure();

            var SunderingFeat = MakerTools.MakeFeature("SunderingStrike", "Sundering Strike", "Whenever you score a critical hit with a melee attack, you can sunder your opponent’s weapon, in addition to the normal damage dealt by the attack. If your confirmation roll exceeds your opponent’s CMD, you may deal damage to your opponent’s weapon as if from the sunder combat maneuver (roll normal damage to the weapon separately). This does not provoke an attack of opportunity.", false);
            SunderingFeat.SetFeatureGroups(FeatureGroup.Feat, FeatureGroup.CombatFeat);
            SunderingFeat.SetRanks(1);
            SunderingFeat.SetIsClassFeature(true);
            SunderingFeat.AddFacts(new string[] { toggle.AssetGuidThreadSafe });
            SunderingFeat.PrerequisiteFeature("9719015edcbf142409592e2cbaab7fe1");//Improved Sunder
            SunderingFeat.PrerequisiteFeature("9972f33f977fc724c838e59641b2fca5");//Power Attack
            SunderingFeat.PrerequisiteStat(Kingmaker.EntitySystem.Stats.StatType.Strength, 13);
            SunderingFeat.PrerequisiteStat(Kingmaker.EntitySystem.Stats.StatType.BaseAttackBonus, 9);
            SunderingFeat.SetFeatureTags(FeatureTag.Attack, FeatureTag.CombatManeuver);

            var sunderprocbuild = SunderingFeat.Configure();
            if (ModSettings.NewContent.Feats.IsEnabled("SunderingStrike"))
            {
                FeatureConfigurator.For("9719015edcbf142409592e2cbaab7fe1").AddToIsPrerequisiteFor(sunderprocbuild.AssetGuidThreadSafe);

                FeatTools.AddAsFeat(sunderprocbuild);
            }
        }

    }
}

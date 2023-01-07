using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.New_Components.TacticalFeatComponents;
using UnityEngine;

namespace TomeOfTheFirebird.New_Content.Feats
{
    class LastwallPhalanx
    {
        public static void Make()
        {
            Sprite icon = BlueprintTool.Get<BlueprintAbility>("808ab74c12df8784ab4eeaf6a107dbea").Icon;
            Func<bool> enabled = () => { return Settings.IsEnabled("LastwallPhalanx"); };
            TeamworkFeatFactory.Make("LastwallPhalanx", "Lastwall Phalanx", "You gain a sacred bonus to your AC against the attacks of evil creatures and a sacred bonus to saves against the spells and abilities of evil creatures equal to the number of adjacent allies who also have this feat.", enabled, x => {
                x.AddComponent<LastwallPhalanxComponent>();
                x.AddPrerequisiteAlignment(Kingmaker.UnitLogic.Alignments.AlignmentMaskType.Good);
                x.AddPrerequisiteStatValue(Kingmaker.EntitySystem.Stats.StatType.BaseAttackBonus, 3);

            }, icon, new Kingmaker.Blueprints.Classes.FeatureGroup[] { Kingmaker.Blueprints.Classes.FeatureGroup.CombatFeat }, FeatureTag.Defense | FeatureTag.SavingThrows);
            

        }
        /*
         * Lastwall Phalanx (Teamwork)
Source Champions of Purity pg. 23
When battling the terrifying hordes of Belkzen, you find strength in your shield brothers and sisters.

Prerequisites: Base attack bonus +3, good alignment.

Benefit: You gain a sacred bonus to your AC against the attacks of evil creatures and a sacred bonus to saves against the spells and abilities of evil creatures equal to the number of adjacent allies who also have this feat.
         */
    }
}

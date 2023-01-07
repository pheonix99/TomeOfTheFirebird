using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using System;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.New_Components.TacticalFeatComponents;
using UnityEngine;

namespace TomeOfTheFirebird.New_Content.Feats
{
    class SwarmStrike
    {

        public static void Make()
        {
            Sprite icon = BlueprintTool.Get<BlueprintFeature>("422dab7309e1ad343935f33a4d6e9f11").Icon;
            Func<bool> enabled = () => { return Settings.IsEnabled("SwarmStrike"); };
            TeamworkFeatFactory.Make("SwarmStrike", "Swarm Strike", "Whenever a foe provokes an attack of opportunity from you, you gain a +1 bonus on your attack roll, plus an additional +1 bonus for each ally who also has this feat and currently threatens that foe.", enabled, x => {
                x.AddComponent<SwarmStrikeComponent>();


            }, icon, new Kingmaker.Blueprints.Classes.FeatureGroup[] { Kingmaker.Blueprints.Classes.FeatureGroup.CombatFeat }, FeatureTag.Attack);


        }
        /*
         *  [PFS Legal] Swarm Strike (Teamwork)
Source Blood of the Moon pg. 19
You and your allies have trained to overwhelm foes like a swarm of rodents.

Benefit: Whenever a foe provokes an attack of opportunity from you, you gain a +1 bonus on your attack roll, plus an additional +1 bonus for each ally who also has this feat and currently threatens that foe.
         */
    }
}

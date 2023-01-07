using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.New_Components.TacticalFeatComponents;
using UnityEngine;

namespace TomeOfTheFirebird.New_Content.Feats
{
    class CoordinatedShot
    {
        public static void Make()
        {
            Sprite icon = BlueprintTool.Get<BlueprintFeature>("0da0c194d6e1d43419eb8d990b28e0ab").Icon;
            Func<bool> enabled = () => { return Settings.IsEnabled("CoordinatedShot"); };
            TeamworkFeatFactory.Make("CoordinatedShot", "Coordinated Shot", "If your ally with this feat is threatening an opponent and is not providing cover to that opponent against your ranged attacks, you gain a +1 bonus on ranged attacks against that opponent. If your ally with this feat is flanking that opponent with another ally (even if that other ally doesn’t have this feat), this bonus increases to +2.", enabled, x => {
                x.AddComponent<CoordinatedShotComponent>();
                x.AddPrerequisiteFeature("0da0c194d6e1d43419eb8d990b28e0ab");

            }, icon, new Kingmaker.Blueprints.Classes.FeatureGroup[] { Kingmaker.Blueprints.Classes.FeatureGroup.CombatFeat }, FeatureTag.Ranged  );
            if (enabled.Invoke())
            {
                FeatureConfigurator.For("0da0c194d6e1d43419eb8d990b28e0ab").SetIsPrerequisiteFor("CoordinatedShotFeat").Configure(delayed:true);
            }
            
            

            

        }
        /*
         *  [PFS Legal] Coordinated Shot (Combat, Teamwork)
Source Advanced Class Guide pg. 144
Your ranged attacks against an opponent take advantage of your ally’s positioning.

Prerequisites: Point-Blank Shot.

Benefit: If your ally with this feat is threatening an opponent and is not providing cover to that opponent against your ranged attacks, you gain a +1 bonus on ranged attacks against that opponent. If your ally with this feat is flanking that opponent with another ally (even if that other ally doesn’t have this feat), this bonus increases to +2.
         */
    }
}

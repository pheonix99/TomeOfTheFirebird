using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;

namespace TomeOfTheFirebird.Modified_Content.Spells
{
    internal class FormOfTheDragon
    {
        //Check that FOTD Gold/Copper/Bronze aren't implemented

        //FOTD-Gold 1 buff: 89669cfba3d9c15448c23b79dd604c41
        //FOTD-Bronze 1 buff: 1032d4ffb1c56444ca5bfce2c778614d
        //FOTD-Copper 1 buff: a4cc7169fb7e64a4a8f53bdc774341b1

        //FOTD GOLD 1 spell on scroll: 12e6785ca0f97a145a7c02a5f0fd155c
        //FOTD GOLD 2 spell on scroll: 72a3ccf67437f4342b2d23634271de77 - buff is 4300f60c00ecabc439deab11ce6d738a
        //FOTD GOLD 3 spell on scroll: c511266a705a6e94186cb51e0503775f - buff is ec6ad3612c4f0e340b54a11a0e78793d

        //FOTD Bronze 1 spell on scroll: f1103c097be761e489ee27a8d49a373b - buff is ec6ad3612c4f0e340b54a11a0e78793d

        public static void AddMissingFOTDs()
        {
            var fotd1 = AbilityConfigurator.For("f767399367df54645ac620ef7b2062bb");

            fotd1.EditComponent<AbilityVariants>(x =>
            {
                x.m_Variants = x.m_Variants.AppendToArray(new Kingmaker.Blueprints.BlueprintAbilityReference[] { BlueprintTool.GetRef<BlueprintAbilityReference>("12e6785ca0f97a145a7c02a5f0fd155c"), BlueprintTool.GetRef<BlueprintAbilityReference>("f1103c097be761e489ee27a8d49a373b"), BlueprintTool.GetRef<BlueprintAbilityReference>("f1103c097be761e489ee27a8d49a373b") });

            });
        }


        //Investigate report of off-model
    }
}

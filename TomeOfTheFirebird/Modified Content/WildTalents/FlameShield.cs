using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.NewComponents;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Components;

namespace TomeOfTheFirebird.Modified_Content.WildTalents
{
    class FlameShield
    {
        public static void PatchFlameSheild()
        {
            var buff = BlueprintTool.Get<BlueprintBuff>("23c0f0417981608479131d25d4349f7d");
            buff.AddComponent<ElementalBarrierDamageDivisor>(x =>
            {
                x.m_Type = Kingmaker.Enums.Damage.DamageEnergyType.Cold;
            });

            var ability = BlueprintTool.Get<BlueprintAbility>("c3a13237b17de5742a2dbf2da46f23d5");
            ability.AddComponent<AbilityRequirementHasBuff>(x =>
            {
                x.RequiredBuff = buff.ToReference<BlueprintBuffReference>();
                x.Not = true;
            });
        }

        /*
         * Flame Shield

Element(s) fire; Type utility (Sp); Level 5; Burn 1
Prerequisite(s) searing flesh

Flickering flames surround you until the next time your burn is removed. While your searing flesh infusion is active, any creature that strikes you with a melee attack takes an amount of fire damage equal to 1/2 your kineticist level unless it is using a reach weapon. If the creature also takes damage from your searing flesh, it applies fire resistance only once against the total damage from both effects. You also gain the protection from cold of a warm fire shield. An attack that would deal an amount of cold damage equal to at least double your kineticist level (before you applied the protection) freezes away your flame shield after you apply its protection, ending the flame shield early.
         */

        //Add protection from cold
    }
}

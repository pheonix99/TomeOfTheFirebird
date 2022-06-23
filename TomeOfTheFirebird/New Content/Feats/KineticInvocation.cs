using BlueprintCore.Utils;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Content.Feats
{
    class KineticInvocation
    {
        public static void MakeBlessingOfTheSalamanderInvocation()
        {
            var BlessingSpell = BlueprintTool.Get<BlueprintAbility>("9256a86aec14ad14e9497f6b60e26f3f");
        }

        public static void MakeHypnotismInvocation()
        {
            var hypnospell = BlueprintTool.Get<BlueprintAbility>("88367310478c10b47903463c5d0152b0");
        }

        public static void MakeAnimateDeadINvocation()
        {
            var AnimateSPell = BlueprintTool.Get<BlueprintAbility>("4b76d32feb089ad4499c3a1ce8e1ac27");
        }
        public static void MakeCommandDeadINvocation()
        {
            var CommandSPell = BlueprintTool.Get<BlueprintAbility>("0b101dd5618591e478f825f0eef155b4");
        }

        public static void MakeMindBlankINvocation()
        {
            var MindBLankSpell = BlueprintTool.Get<BlueprintAbility>("df2a0ba6b6dcecf429cbb80a56fee5cf");
        }
        /*
         *  Kinetic Invocation
Source Psychic Anthology pg. 24
You have learned to channel your element’s energy into the magic used by traditional spellcasters.

Prerequisites: Kineticist level 1st, elemental focus class feature.

Benefit: For each kineticist element to which you have access, you treat all spells associated with that element (see below) as utility wild talents of the listed level, which you can select as normal. Each has a burn cost of 1 unless otherwise noted, and any nonpermanent, non-instantaneous effects end when your burn is removed. Using this wild talent is considered psychic spellcasting (except for the purpose of prerequisites), and you must provide emotion and thought components, as well as material components where appropriate. In addition, some spells are restricted to certain races (as detailed on page 9 of Pathfinder RPG Advanced Race Guide). Your caster level for a spell is equal to your kineticist level, and the save DC for any spell is equal to 10 + the listed level of the spell + your Constitution modifier. At the GM’s discretion, other appropriate spells can be added to each element’s list.

Aether: Etheric shardsOA (5th), instant armorAPG (2nd), kinetic reverberationUC (2nd), protective spiritAPG (3rd), telekinetic chargeUC (4th; 2 burn).

Air: Air stepACG (2nd), body capacitanceACG (1st), cloak of windsAPG (3rd), cloud shapeARG (4th; self only), gaseous form (3rd), wind walk (6th).

Earth: Expeditious excavationAPG (2nd; 0 burn), groundswellARG (2nd), imprisonment (9th), rampartAPG (7th), slowing mudACG (4th), statue (7th; 0 burn; self only), stone shieldARG (1st).

Fire: Blessing of the salamanderAPG (5th; self only), boiling bloodUM (2nd), death candleARG (2nd), fury of the sunARG (2nd; 0 burn), hypnotic pattern (2nd), hypnotism (2nd; 0 burn), invigorateAPG (1st).

Void: Animate dead (3rd), command undead (2nd), death ward (4th), halt undead (3rd), life channelARG (1st; 0 burn; self only), mind blank (8th; self only), unliving rageACG (3rd).

Water: Fluid formAPG (6th), ride the wavesUM (4th), silent image (2nd; 0 burn), sleet storm (3rd), water breathing (3rd).

Wood: Command plants (4th), fairy ring retreatACG (7th; ends 1 hour after your burn is removed), goodberry (1st), grove of respiteAPG (4th), lesser restoration (2nd), ward of the seasonARG (3rd).

Special: Kineticists with the air affinity, earth affinity, fire affinity, or water affinity racial traits or the air, earth, fire, or water subtypes can select spells of the appropriate element as if they had this feat. Caligni (Pathfinder RPG Bestiary 5 66) and dhampir (Pathfinder RPG Bestiary 2 89) kineticists can select spells of the void element as if they had this feat. Gathlain (Pathfinder RPG Bestiary 4 122) and ghoran (Bestiary 5 119) kineticists can select spells of the wood element as if they had this feat. Such a character must still have access to the appropriate element to select spells this way. At the GM’s discretion, this benefit can be expanded to other races.
         * 
         */

        //Since I don't really consider paying a feat to unlock stuff alone kosher, free KI pick
    }
}

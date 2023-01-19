using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Content.Feats
{
    class BlastingCharge
    {
        /*
         * Blasting Charge
Source Advanced Class Guide pg. 143
You funnel the power of your bloodrage into a strike capable of erupting with arcane power.

Prerequisites: Base attack bonus +7, ability to cast 2nd-level bloodrager spells, bloodrage class feature.

Benefit: While you are bloodraging, at the end of a charge you can expend a bloodrager spell slot as a swift action to imbue your charge attack with extra power. You deal an additional 1d6 points of damage per level of the spell slot expended. This extra damage is force damage, and it’s not multiplied in the case of a critical hit.

If your bloodline has a specific energy type associated with it (such as the elemental or draconic bloodlines), you can choose to increase the damage to 1d8 points per level of the spell slot expended, and this extra damage is of that energy type.
         */

        //This is *roughly* equivalent to spellstriking on the charge with a class that can't normally do that
        //Loses the activate once, charge stays live till hit portion, but it's on charge - you can't spellstrike on charge via spell combat have to arm it first then charge and ... not sure how the UI on that works anyway.
        //However, 1d6 force / 1d8 elemental per SL on that is arse
        //Firey Runes exists and can be armed before combat, for one thing

        //Touch spell dice per level
        //1: 5 max
        //2: No pure damage melee i can think of but Scorching Ray tops out at 12 dice, ranged, salvo-fired
        //3: Vamp touch, 10 dice but neg and the temp hp
        //3: also bb, tops out at 5 * (CL/5) dice

        //Given action econ perks, 1 die per 2CL, max 2 die per spell level, with 2x on crit seems reasonable
        
    }
}

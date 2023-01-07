using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using System;

namespace TomeOfTheFirebird.New_Components
{
    public class ContextRankConfigShroudOfWater : ShroudOfWater
    {
        public override void OnTurnOn()
        {



            ModifiableValue stat = base.Owner.Stats.GetStat(this.Stat);

            int value;

            int cap = (int)Math.Floor((double)this.BaseValue.Calculate(base.Context) * 1.5);
            int boosted = this.BaseValue.Calculate(base.Context) + this.Boost.Calculate(base.Context);
            value = Math.Min(cap, boosted);


            stat.AddModifier(value, base.Runtime, this.Descriptor);
        }
        public ContextValue Boost;


    }
}

using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components
{
    public class CustomShroudOfWater : ShroudOfWater
    {
		public override void OnTurnOn()
		{
			ModifiableValue stat = base.Owner.Stats.GetStat(this.Stat);
			Feature fact = base.Owner.Progression.Features.GetFact(this.UpgradeFeature);
			List<Feature> extraFeatures = new();
			if (m_UpgradeFeature != null)
            {
				extraFeatures.AddRange(m_UpgradeFeatures.Select(x => base.Owner.Progression.Features.GetFact(x.Get())));
            }
			int rank = 0;
			if (fact != null)
            {
				rank = fact.GetRank();
            }
			foreach(Feature feature in extraFeatures)
            {
				rank += feature.GetRank();
            }
			int value = (rank > 0) ? Math.Min((int)Math.Floor((double)this.BaseValue.Calculate(base.Context) * 1.5), this.BaseValue.Calculate(base.Context) + rank) : this.BaseValue.Calculate(base.Context);
			stat.AddModifier(value, base.Runtime, this.Descriptor);
		}


		public List<BlueprintFeatureReference> m_UpgradeFeatures = new();
	}
}

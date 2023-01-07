using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Enums.Damage;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;

namespace TomeOfTheFirebird.New_Components
{
    class ArtifactEnabledWeaponAngelDamageDice : WeaponEnchantmentLogic, IInitiatorRulebookHandler<RuleCalculateWeaponStats>, IRulebookHandler<RuleCalculateWeaponStats>, ISubscriber, IInitiatorRulebookSubscriber
	{
	
		public BlueprintUnitFactReference MaximizeFeature
		{
			get
			{
				return this.m_MaximizeFeature;
			}
		}

		public BlueprintUnitFactReference ArtifactFeature
		{
			get
			{
				return this.m_ArtifactFeature;
			}
		}

		// Token: 0x0600C7E7 RID: 51175 RVA: 0x0032382C File Offset: 0x00321A2C
		public void OnEventAboutToTrigger(RuleCalculateWeaponStats evt)
		{
			if (evt.Weapon == base.Owner)
			{
				UnitEntityData maybeCaster = base.Context.MaybeCaster;
				if (maybeCaster != null && maybeCaster.HasFact(this.MaximizeFeature))
				{
					DamageDescription item = new DamageDescription
					{
						TypeDescription = new DamageTypeDescription
						{
							Type = DamageType.Energy,
							Energy = this.Element
						},
						Dice = new DiceFormula(this.BaseFormula.MaxValue(0, false), DiceType.One),
						SourceFact = base.Fact
					};
					evt.DamageDescription.Add(item);
					
				}
				else
				{
					DamageDescription item2 = new DamageDescription
					{
						TypeDescription = new DamageTypeDescription
						{
							Type = DamageType.Energy,
							Energy = this.Element
						},
						Dice = this.BaseFormula,
						SourceFact = base.Fact
					};
					evt.DamageDescription.Add(item2);
				}
				if (maybeCaster != null && maybeCaster.HasFact(this.ArtifactFeature))
                {
					
					if (maybeCaster.HasFact(this.MaximizeFeature))
					{
						DamageDescription item = new DamageDescription
						{
							TypeDescription = new DamageTypeDescription
							{
								Type = DamageType.Energy,
								Energy = this.Element
							},
							Dice = new DiceFormula(this.ExtraFormula.MaxValue(0, false), DiceType.One),
							SourceFact = base.Fact
						};
						evt.DamageDescription.Add(item);

					}
					else
					{
						DamageDescription item2 = new DamageDescription
						{
							TypeDescription = new DamageTypeDescription
							{
								Type = DamageType.Energy,
								Energy = this.Element
							},
							Dice = this.ExtraFormula,
							SourceFact = base.Fact
						};
						evt.DamageDescription.Add(item2);
					}
				}
			}
		}

		// Token: 0x0600C7E8 RID: 51176 RVA: 0x00003AE3 File Offset: 0x00001CE3
		public void OnEventDidTrigger(RuleCalculateWeaponStats evt)
		{
		}

		// Token: 0x0400822B RID: 33323
		public DiceFormula BaseFormula;
		public DiceFormula ExtraFormula;

		// Token: 0x0400822C RID: 33324
		public DamageEnergyType Element;

		// Token: 0x0400822D RID: 33325
		
		public BlueprintUnitFactReference m_MaximizeFeature;
		public BlueprintUnitFactReference m_ArtifactFeature;
	}
    
}

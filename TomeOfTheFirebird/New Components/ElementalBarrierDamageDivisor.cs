using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Enums.Damage;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TomeOfTheFirebird.Components
{
    class ElementalBarrierDamageDivisor : UnitFactComponentDelegate, ITargetRulebookHandler<RuleCalculateDamage>, IRulebookHandler<RuleCalculateDamage>, ISubscriber, ITargetRulebookSubscriber
    {
        // Token: 0x0600A094 RID: 41108 RVA: 0x00297EA8 File Offset: 0x002960A8
        public void OnEventAboutToTrigger(RuleCalculateDamage evt)
        {

            MechanicsContext context = evt.Reason.Context;
            if (context != null && !evt.ParentRule.HalfBecauseSavingThrow)
            {
                foreach (BaseDamage baseDamage in evt.DamageBundle.OfType<EnergyDamage>().Where(x => x.EnergyType == m_Type))
                {
                    baseDamage.IncreaseDeclineTo(DamageDeclineType.ByHalf);
                }
            }//TODO Make This Only Work On REF saves
            if (context != null && evt.ParentRule.HalfBecauseSavingThrow)
            {
                foreach (BaseDamage baseDamage2 in evt.DamageBundle.OfType<EnergyDamage>().Where(x => x.EnergyType == m_Type))
                {
                    baseDamage2.IncreaseDeclineTo(DamageDeclineType.Total);
                }
            }
        }

        // Token: 0x0600A095 RID: 41109 RVA: 0x00003AE3 File Offset: 0x00001CE3
        public void OnEventDidTrigger(RuleCalculateDamage evt)
        {
        }

        // Token: 0x04006BFE RID: 27646
        [SerializeField]
        public DamageEnergyType m_Type;


    }

}

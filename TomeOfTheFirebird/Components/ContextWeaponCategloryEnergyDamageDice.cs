﻿using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.Components
{

    [AllowedOn(typeof(BlueprintUnitFact))]
    [ComponentName("Damage bonus for specific weapon types")]
    public class ContextWeaponCategloryEnergyDamageDice : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateWeaponStats>, IRulebookHandler<RuleCalculateWeaponStats>, ISubscriber, IInitiatorRulebookSubscriber
    {
        public WeaponCategory[] categories;
        // Token: 0x04007F6D RID: 32621
        public DiceFormula EnergyDamageDice;

        // Token: 0x04007F6E RID: 32622
        public DamageTypeDescription Element;
        public void OnEventAboutToTrigger(RuleCalculateWeaponStats evt)
        {
            

            if (categories.Contains(evt.Weapon.Blueprint.Category))
            {

                DamageDescription item = new DamageDescription
                {
                    TypeDescription = Element,
                    Dice = this.EnergyDamageDice,
                    SourceFact = base.Fact
                };
                evt.DamageDescription.Add(item);
            }
        }

        public void OnEventDidTrigger(RuleCalculateWeaponStats evt)
        {

        }
    }
}

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Designers.Mechanics.Facts;
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
    public class ContextWeaponCategoryExtraDamageDice : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateWeaponStats>, IRulebookHandler<RuleCalculateWeaponStats>, ISubscriber, IInitiatorRulebookSubscriber
    {
        public WeaponCategory[] categories;

        public bool ToAllAttacks = false;
        // Token: 0x04007F6D RID: 32621
        public DiceFormula DamageDice;
        
        public bool Ascendant = false;
        
        // Token: 0x04007F6E RID: 32622
        public DamageTypeDescription Element;
        public void OnEventAboutToTrigger(RuleCalculateWeaponStats evt)
        {
              

            if ( ToAllAttacks || categories.Contains(evt.Weapon.Blueprint.Category))
            {
                bool localAscend = false;
                if ( base.Context.SourceAbilityContext != null && base.Context.SourceAbilityContext.Caster != null && Element.IsEnergy)
                {
                    if (Element.IsEnergy && base.Context.SourceAbilityContext.Caster.Facts.List.OfType<AscendantElement>().Any(x=>x.Element == Element.Energy))
                    {
                        localAscend = true;
                    }
                }

                
                DamageDescription item = new DamageDescription
                {
                    TypeDescription = Element,
                    Dice = this.DamageDice,
                    SourceFact = base.Fact,
                    IgnoreImmunities = Ascendant || localAscend
                };
                evt.DamageDescription.Add(item);
            }
        }

        public void OnEventDidTrigger(RuleCalculateWeaponStats evt)
        {

        }
    }
}

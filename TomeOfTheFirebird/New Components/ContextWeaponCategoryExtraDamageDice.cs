using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using System;
using System.Linq;

namespace TomeOfTheFirebird.Components
{
    [AllowMultipleComponents]
    [AllowedOn(typeof(BlueprintUnitFact))]
    [ComponentName("Damage bonus for specific weapon types")]
    public class ContextWeaponCategoryExtraDamageDice : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateWeaponStats>, IRulebookHandler<RuleCalculateWeaponStats>, ISubscriber, IInitiatorRulebookSubscriber
    {
        public ConditionsChecker wielderCondition;



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
                if (wielderCondition != null)
                {
                    using (base.Context.GetDataScope(evt.Initiator))
                    {
                        var result = this.wielderCondition.Check();

                        if (!result)
                            return;
                    }
                }

                bool localAscend = false;
                if ( base.Context.SourceAbilityContext != null && base.Context.SourceAbilityContext.Caster != null && Element.IsEnergy)
                {
                    
                    

                    if (Element.IsEnergy && base.Context.SourceAbilityContext.Caster.Progression.Features.SelectFactComponents<AscendantElement>().Any(x=>x.Element == Element.Energy))
                    {
                        
                        localAscend = true;
                        
                    }
                    else if (Element.IsEnergy)
                    {
                        
                    }
                }

                
                DamageDescription item = new DamageDescription
                {
                    TypeDescription = Element,
                    Dice = this.DamageDice,
                    SourceFact = base.Fact,
                    IgnoreImmunities = Ascendant || localAscend,
                    IgnoreReduction = Ascendant || localAscend
                };
                evt.DamageDescription.Add(item);
            }
        }

        public void OnEventDidTrigger(RuleCalculateWeaponStats evt)
        {

        }
    }
}

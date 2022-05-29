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
    public class ContextWeaponCategoryPhysDamageDiceWithChangeOnCondition : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateWeaponStats>, IRulebookHandler<RuleCalculateWeaponStats>,  ISubscriber, IInitiatorRulebookSubscriber
    {
        public WeaponCategory[] categories;
        public bool ToAllAttacks = false;

        public ConditionsChecker TargetConditions;

        public DiceFormula NormalDamage;

        public DiceFormula IncreasedDamage;

        public PhysicalDamageForm form; 

        public void OnEventAboutToTrigger(RuleCalculateWeaponStats evt)
        {
            
            //Main.Log($"Context-Scaled Phys Damage calc called. Set DmgType is  {form}");
            if (evt.Weapon == null)
            {
                //Main.Log($"Context-Scaled Phys Damage calc called on null weapon type");
                return;
            }
            else if (ToAllAttacks || categories.Contains(evt.Weapon.Blueprint.Category))
            {
                //Main.Log($"Context-Scaled Phys Damage calc called on correct weapon type");
                DamageDescription dmg;
                if (evt.AttackWithWeapon == null || evt.AttackWithWeapon.Target == null)
                {
                    //Main.Log("AttackWithWeapon.Target Is Null, This Should Mean Inventory Screen Modo");
                    dmg = MakeDamageDesc(evt, false);//Display default damage in inventory screen
                }
                else
                {
                   // Main.Log("AttackWithWeapon.Target Is Not Null, This Should Mean Combat Modo");
                    using (base.Context.GetDataScope(evt.AttackWithWeapon.Target))
                    {
                        
                       
                        dmg = MakeDamageDesc(evt, this.TargetConditions.Check());
                    }

                }
                //Main.Log($"Calc'd damage type is: {dmg.TypeDescription.Physical.Form}");
                evt.DamageDescription.Add(dmg);
            }
            else
            {
                //Main.Log($"Context-Scaled Phys Damage calc called on wrong weapon type - type is {evt.Weapon.Blueprint.Category}");
            }

        }

        private DamageDescription MakeDamageDesc(RuleCalculateWeaponStats evt, bool escalated)
        {
            DamageDescription weapon = evt.DamageDescription.FirstOrDefault(x => x.TypeDescription.IsPhysical);
            DamageDescription item = new DamageDescription
            {
                TypeDescription = new DamageTypeDescription
                {
                    Type = DamageType.Physical,
                    Physical = new DamageTypeDescription.PhysicalData()
                    {
                        Form = form

                    }

                },
                Dice = escalated ? this.IncreasedDamage: this.NormalDamage,
                SourceFact = base.Fact
            };
            if (weapon != null)
            {
                //Main.Log($"Setting weapon properties to match attack");
                item.TypeDescription.Physical.Material = weapon.TypeDescription.Physical.Material;
                item.TypeDescription.Physical.Enhancement = weapon.TypeDescription.Physical.Enhancement;
                item.TypeDescription.Physical.EnhancementTotal = weapon.TypeDescription.Physical.EnhancementTotal;

            }
            //Main.Log($"Calcing Context-Scaled Phys Damage for {evt.Weapon.Name}, formula is {item.Dice.ToString()}");
            return item;
        }
      
        public void OnEventDidTrigger(RuleCalculateWeaponStats evt)
        {

        }

       
    }
}

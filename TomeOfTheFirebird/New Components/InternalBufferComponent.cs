using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.ElementsSystem;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components
{
    [AllowedOn(typeof(BlueprintBuff))]
    class InternalBufferComponent : UnitFactComponentDelegate, IKineticistCalculateAbilityCostHandler, IGlobalSubscriber, ISubscriber, IKineticistAcceptBurnHandler, IUnitSubscriber
    {
        public int value = 1;
        public ActionList actions;
        public void HandleKineticistAcceptBurn(UnitPartKineticist kineticist, int burn, AbilityData ability)
        {
            //Main.TotFContext.Logger.Log("Calling InternalBufferComponent.HandleKineticistAcceptBurn");
            if (actions != null)
            {
                (this.Fact as IFactContextOwner)?.RunActionInContext(this.actions, kineticist.Owner.Unit);
            }
        }

        public void HandleKineticistCalculateAbilityCost(UnitDescriptor caster, BlueprintAbility abilityBlueprint, ref KineticistAbilityBurnCost cost)
        {
            if (!caster.Equals(this.Owner.Descriptor))
                return;
            int earlycost = cost.Total;
          

            AbilityKineticist burn_cost = abilityBlueprint.GetComponent<AbilityKineticist>();
            if (burn_cost != null && burn_cost.WildTalentBurnCost > 0)
            {
                //to make it work for wild talents
                cost.Decrease(value, KineticistBurnType.WildTalent);
            }
            else
            {
                cost.IncreaseGatherPower(value);
            }
            //Main.TotFContext.Logger.Log($"Calling InternalBufferComponent.HandleKineticistCalculateAbilityCost on {abilityBlueprint.name}, prebuffer cost is {earlycost} postbuffer is {cost.Total}");
        }
    }
}

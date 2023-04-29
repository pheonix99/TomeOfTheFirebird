using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.ElementsSystem;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.UnitLogic.Mechanics.Components;
using TomeOfTheFirebird.Modified_Content.Classes;

namespace TomeOfTheFirebird.New_Components
{
    [AllowedOn(typeof(BlueprintBuff))]
    class InternalBufferComponent : UnitFactComponentDelegate, IKineticistCalculateAbilityCostHandler, IGlobalSubscriber, ISubscriber, IKineticistAcceptBurnHandler, IUnitSubscriber
    {
        public int value = 1;
     
        public BlueprintAbilityResourceReference resource;
        
        public void HandleKineticistAcceptBurn(UnitPartKineticist kineticist, int burn, AbilityData ability)
        {
            

            if (!kineticist.Owner.Resources.HasEnoughResource(resource.Get(), value))
                return;
            kineticist.Owner.Resources.Spend(resource.Get(), value);
            Owner.RemoveFact(OwnerBlueprint as BlueprintUnitFact);
            //Main.TotFContext.Logger.Log("Calling InternalBufferComponent.HandleKineticistAcceptBurn");
            
        }

        public void HandleKineticistCalculateAbilityCost(UnitDescriptor caster, BlueprintAbility abilityBlueprint, ref KineticistAbilityBurnCost cost)
        {
            //TODO OVERHAUL TO POSTFIX AbilityKineticist.CalculateBurnCost to query this / after determining "passive" mitigation and pass a ref to the BP to a unitpart so we can tell if it's time to cost resources!

            if (!caster.Equals(this.Owner.Descriptor))
                return;
            if (!caster.Resources.HasEnoughResource(resource.Get(), value))
            {
                

                return;
            }
                
           
             
            
           
          

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

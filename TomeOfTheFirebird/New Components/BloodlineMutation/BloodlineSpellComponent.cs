using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components.BloodlineMutation
{
    [AllowMultipleComponents]
    public class BloodlineSpellComponent : UnitFactComponentDelegate
    {

        public BlueprintAbilityReference m_spell;
        public override void OnActivate()
        {
            OnTurnOn();
        }

        public override void OnDeactivate()
        {
            OnTurnOff();
        }

        public override void OnTurnOn()
        {
            
            base.OnTurnOn();
            var part = base.Owner.Ensure<UnitPartBloodlineSpellTracker>();
            part.RegisterBloodlineSpell(Fact, m_spell);


        }

        public override void OnTurnOff()
        {
            var part = base.Owner.Get<UnitPartBloodlineSpellTracker>();
            if (part != null)
                part.UnregisterBloodlineSpell(Fact, m_spell);

        }

        
    }

    public static class BloodlineSpellComponentAssistant
    {
        

        public static ProgressionConfigurator AddBloodlineSpellComponents(this ProgressionConfigurator progressionConfigurator)
        {
            List<BlueprintAbilityReference> spells = new();
            progressionConfigurator.EditComponents<AddKnownSpell>(x =>
            {

                if (!spells.Contains(x.m_Spell))
                {   
                    
                    spells.Add(x.m_Spell);
                }

            }, y => true);//Failsafe for spells living directly on the bloodline ...
            progressionConfigurator.ModifyLevelEntries(x =>
            {
                x.m_Features.ForEach(y =>
                {
                    y.Get().GetComponents<AddKnownSpell>().ForEach(z =>
                    {
                        if ( !spells.Contains(z.m_Spell))
                        {
                            spells.Add(z.m_Spell);
                        }
                    });

                });

            });

            
            foreach (BlueprintAbilityReference spell in spells)
            {
                progressionConfigurator.AddComponent<BloodlineSpellComponent>(x =>
                {
                    x.m_spell = spell;
                });
            }

            return progressionConfigurator;
        }
    }
}

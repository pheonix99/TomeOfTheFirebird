using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.FactLogic;
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
        public static FeatureConfigurator AddBloodlineSpellComponents(this FeatureConfigurator featureConfigurator)
        {
            List<BlueprintAbilityReference> spells = new();
            
            featureConfigurator.EditComponents<AddKnownSpell>(x =>
            {
                if (!spells.Contains(x.m_Spell))
                {
                    spells.Add(x.m_Spell);
                }

            }, y => true);
            foreach(BlueprintAbilityReference spell in spells)
            {
                featureConfigurator.AddComponent<BloodlineSpellComponent>(x =>
                {
                    x.m_spell = spell;
                });
            }

            return featureConfigurator;
        }
    }
}

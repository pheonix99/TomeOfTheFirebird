﻿using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using System.Collections.Generic;

namespace TomeOfTheFirebird.New_Components
{
    [AllowedOn(typeof(BlueprintAbility))]
    class AbilityRestrictionWildTalentCastCapper : BlueprintComponent, IAbilityRestriction
    {
        public string GetAbilityRestrictionUIText()
        {
            return "Ability stack limit reached";
        }

        public bool IsAbilityRestrictionPassed(AbilityData ability)
        {
            int actualcap = GetCap(ability.Caster);
            int ranks = GetRank(ability.Caster);

            return ranks < actualcap;
                
        }

        private int GetRank(UnitEntityData owner)
        {
            int ranks = 0;
            foreach (BlueprintUnitFactReference reference in m_facts)
            {
                int? rank = owner.Facts.Get(reference.Get())?.GetRank();
                if (rank.HasValue)
                {
                    ranks += rank.Value;
                }
            }
            if (IsDefense && m_MythicKineticDefense != null && owner.HasFact(m_MythicKineticDefense.Get()))
            {
                if (owner.Progression.MythicLevel > 0)
                    ranks += ( 1 + (owner.Progression.MythicLevel / 3));
            }
            
            return ranks;
        }


        private int GetCap(UnitEntityData owner)
        {
            int actualcap;
            if (useCapResource)
            {
                actualcap = owner.Resources.GetResource(m_CapResource.Get()).GetMaxAmount(owner);
                
            }
            else
            {
                actualcap = simplecap;
            }
            return actualcap;
        }
       
        public int simplecap;

        public bool useCapResource;

        public bool IsDefense;
        public BlueprintFeatureReference m_MythicKineticDefense;

        public List<BlueprintUnitFactReference> m_facts = new();

        public BlueprintAbilityResourceReference m_CapResource;
    }
}

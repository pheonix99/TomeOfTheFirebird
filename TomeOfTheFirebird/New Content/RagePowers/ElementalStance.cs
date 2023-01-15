using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Components;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.New_Components;
using UnityEngine;

namespace TomeOfTheFirebird.New_Content.RagePowers
{
    class ElementalStance
    {
        static List<BlueprintBuffReference> effectBuffs = new();
        static BlueprintFeatureSelectionReference selector;
        public static void Make()
        {

            Sprite icon = BlueprintTool.Get<BlueprintFeature>("da56a1b21032a374783fdf46e1a92adb").Icon;

            BlueprintFeatureReference MakeForElement(DamageEnergyType damage, Sprite localIcon)
            {
                if (localIcon == null)
                    localIcon = icon;
                string effectbuffssyname = $"ElementalStanceRagePower{damage.ToString()}EffectBuff";
                var effectBuffa = MakerTools.MakeBuff(effectbuffssyname, $"Elemental Stance ({damage.ToString()})", $"When the barbarian adopts this stance, her weapons are shrouded with {damage.ToString().ToLower()}. Her melee attacks deal 1d4 additional point of {damage.ToString().ToLower()}. damage. This damage increases to 1d6 points at 8th level. At 12th level, the barbarian’s critical hits deal an additional 1d10 points of {damage.ToString().ToLower()} damage (2d10 if the weapon deals ×3 damage on a critical hit, 3d10 if the weapon deals ×4 damage on a critical hit).");
                effectBuffa.AddComponent<ElementalStanceComponent>(x =>
                {
                    x.damage = damage;
                    x.scalar = new Kingmaker.UnitLogic.Mechanics.ContextValue()
                    {
                        ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Rank,
                        ValueRank = Kingmaker.Enums.AbilityRankType.DamageDiceAlternative
                    };

                });


                effectBuffs.Add(effectBuffa.Configure().ToReference<BlueprintBuffReference>());
                string switchbuffssyname = $"ElementalStanceRagePower{damage.ToString()}SwitchBuff";
                var switchBuff = MakerTools.MakeBuff(switchbuffssyname, $"Elemental Stance ({damage.ToString()})", $"When the barbarian adopts this stance, her weapons are shrouded with {damage.ToString().ToLower()}. Her melee attacks deal 1d4 additional point of {damage.ToString().ToLower()}. damage. This damage increases to 1d6 points at 8th level. At 12th level, the barbarian’s critical hits deal an additional 1d10 points of {damage.ToString().ToLower()} damage (2d10 if the weapon deals ×3 damage on a critical hit, 3d10 if the weapon deals ×4 damage on a critical hit).", localIcon);
                switchBuff.AddFactContextActions(activated: ActionsBuilder.New().Conditional(conditions: ConditionsBuilder.New().HasFact(fact: "da8ce41ac3cd74742b80984ccc3c9613"), ifTrue: ActionsBuilder.New().ApplyBuffPermanent(effectbuffssyname, isFromSpell: false, isNotDispelable: false, asChild: true)), deactivated: ActionsBuilder.New().RemoveBuff(effectbuffssyname));
                switchBuff.SetFlags(BlueprintBuff.Flags.StayOnDeath);

                var switchMade = switchBuff.Configure();


                void AddToOtherRage(string otherRage)
                {

                    BuffConfigurator.For(otherRage).AddFactContextActions(activated: ActionsBuilder.New().Conditional(ConditionsBuilder.New().HasFact(switchbuffssyname), ifTrue: ActionsBuilder.New().ApplyBuffPermanent(effectbuffssyname, isFromSpell: false, isNotDispelable: false, asChild: true)), deactivated: ActionsBuilder.New().RemoveBuff(effectbuffssyname)).Configure();
                }

                string toggleSysteName = $"ElementalStanceRagePower{damage.ToString()}ToggleAbility";
                var toggle = MakerTools.MakeToggle(toggleSysteName, $"Elemental Stance ({damage.ToString()})", $"When the barbarian adopts this stance, her weapons are shrouded with {damage.ToString().ToLower()}. Her melee attacks deal 1d4 additional point of {damage.ToString().ToLower()}. damage. This damage increases to 1d6 points at 8th level. At 12th level, the barbarian’s critical hits deal an additional 1d10 points of {damage.ToString().ToLower()} damage (2d10 if the weapon deals ×3 damage on a critical hit, 3d10 if the weapon deals ×4 damage on a critical hit).", localIcon);
                toggle.SetGroup(Kingmaker.UnitLogic.ActivatableAbilities.ActivatableAbilityGroup.BarbarianStance);
                toggle.SetIsOnByDefault(true);
                toggle.SetBuff(switchMade);

                var toggleMade = toggle.Configure();

                var StanceFeature = MakerTools.MakeFeature($"ElementalStanceRagePower{damage.ToString()}", $"Elemental Stance ({damage.ToString()})", $"When the barbarian adopts this stance, her weapons are shrouded with {damage.ToString().ToLower()}. Her melee attacks deal 1d4 additional point of {damage.ToString().ToLower()}. damage. This damage increases to 1d6 points at 8th level. At 12th level, the barbarian’s critical hits deal an additional 1d10 points of {damage.ToString().ToLower()} damage (2d10 if the weapon deals ×3 damage on a critical hit, 3d10 if the weapon deals ×4 damage on a critical hit).", false, localIcon);
                StanceFeature.AddFacts(new() { toggleMade });
                StanceFeature.SetRanks(1);

                AddToOtherRage("e29c5caf28c04d489a77f25e9b134c67");//DLC3 rage buff
                AddToOtherRage("7f528559113d4d58bc255da154e24bd6");//DLC3 Sickness Buff
                AddToOtherRage("3513326cd64f475781799685c57fa452");//Focust Rage Buff
                AddToOtherRage("da8ce41ac3cd74742b80984ccc3c9613");//Standard
                AddToOtherRage("ecc22ca1eea1bf6488a0d7c6ee2527d8");//Primalist


                return StanceFeature.Configure().ToReference<BlueprintFeatureReference>();
            }

            var fire = MakeForElement(DamageEnergyType.Fire, null);
            var acid = MakeForElement(DamageEnergyType.Acid, null);
            var cold = MakeForElement(DamageEnergyType.Cold, null);
            var shock = MakeForElement(DamageEnergyType.Electricity, null);

            FeatureSelectionConfigurator stanceSelectFeature;
            if (Settings.IsEnabled("RagePowerElementalStance"))
            {
                stanceSelectFeature = MakerTools.MakeFeatureSelector("ElementalStanceRagePowerSelector", "Elemental Stance", "When the barbarian adopts this stance, she chooses an energy type (acid, cold, electricity, or fire). Her melee attacks deal 1d4 additional point of damage of the chosen type. This damage increases to 1d6 points at 8th level. At 12th level, the barbarian’s critical hits deal an additional 1d10 points of energy damage of the same type (2d10 if the weapon deals ×3 damage on a critical hit, 3d10 if the weapon deals ×4 damage on a critical hit).", false, icon, FeatureGroup.RagePower);
                stanceSelectFeature.SetHideNotAvailibleInUI(false);
                stanceSelectFeature.AddToAllFeatures(fire, acid, cold, shock);
            }
            else
            {
                stanceSelectFeature = MakerTools.MakeFeatureSelector("ElementalStanceRagePowerSelector", "Elemental Stance", "When the barbarian adopts this stance, she chooses an energy type (acid, cold, electricity, or fire). Her melee attacks deal 1d4 additional point of damage of the chosen type. This damage increases to 1d6 points at 8th level. At 12th level, the barbarian’s critical hits deal an additional 1d10 points of energy damage of the same type (2d10 if the weapon deals ×3 damage on a critical hit, 3d10 if the weapon deals ×4 damage on a critical hit).", false, icon);
            }




            selector = stanceSelectFeature.Configure().ToReference<BlueprintFeatureSelectionReference>();
            /*
            if (Settings.IsEnabled("RagePowerElementalStance"))
            {
                FeatureSelectionConfigurator.For("28710502f46848d48b3f0d6132817c4e").AddToAllFeatures(selector.Guid).Configure();
                FeatureSelectionConfigurator.For("2476514e31791394fa140f1a07941c96").AddToAllFeatures(selector.Guid).Configure();
                FeatureSelectionConfigurator.For("0c7f01fbbe687bb4baff8195cb02fe6a").AddToAllFeatures(selector.Guid).Configure();
                FeatureSelectionConfigurator.For("609f0e5336084442a0dafa3abd4d31c5").AddToAllFeatures(selector.Guid).Configure();
               
                if (Settings.IsTTTBaseEnabled())
                {
                    FeatureSelectionConfigurator.For("6baf176bc22c4a41ba421bce3fcd9497").AddToAllFeatures(selector.Guid).Configure();
                   
                }
            }
            */
            //TODO check if need to patch on viking!




        }

        public static void Finish()
        {
            if (Settings.IsEnabled("RagePowerElementalStance"))
            {
                var lethalEffectBuff = BlueprintTool.Get<BlueprintBuff>("c6271b3183c48d54b8defd272bea0665");
                var lethalConfig = lethalEffectBuff.GetComponent<ContextRankConfig>();
                var editSelector = selector.Get();
                foreach (var v in effectBuffs)
                {
                    v.Get().AddContextRankConfig(x =>
                    {
                        x.m_BaseValueType = lethalConfig.m_BaseValueType;
                        x.m_Class = lethalConfig.m_Class;
                        x.Archetype = lethalConfig.Archetype;
                        x.m_AdditionalArchetypes = lethalConfig.m_AdditionalArchetypes;
                    });
                }
                var deadlyFeature = BlueprintTool.Get<BlueprintFeature>("c841ffa13d39ce442a408f57feb3cb8e");
                foreach (var comp in deadlyFeature.Components)
                {
                    if (comp is PrerequisiteClassLevel classLevel)
                    {
                        editSelector.AddComponent<PrerequisiteClassLevel>(x =>
                        {

                            x.m_CharacterClass = classLevel.m_CharacterClass;
                            x.Level = classLevel.Level;
                            x.Group = Prerequisite.GroupType.Any;
                        });
                    }
                    else if (comp is PrerequisiteArchetypeLevel arche)
                    {
                        editSelector.AddComponent<PrerequisiteArchetypeLevel>(x =>
                        {
                            x.m_CharacterClass = arche.m_CharacterClass;
                            x.Level = arche.Level;
                            x.m_Archetype = arche.m_Archetype;
                            x.Group = Prerequisite.GroupType.Any;
                        });

                    }
                }
            }
        }
    }
}

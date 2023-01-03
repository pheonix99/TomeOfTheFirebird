using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;
using static TabletopTweaks.Core.Utilities.Helpers;
using TomeOfTheFirebird.Helpers;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.FactLogic;
using TomeOfTheFirebird.New_Components;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.UnitLogic.Abilities.Components.AreaEffects;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.NewComponents;
using BlueprintCore.Utils;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;

namespace TomeOfTheFirebird.New_Content.Bloodlines
{
    static class PheonixBloodline
    {
        public static BlueprintFeatureReference BloodlineRequisiteFeature;
        public static BlueprintFeatureReference PhoenixBloodlineRequisiteFeature;
        public static void MakePheonixBloodline()
        {

            BloodlineRequisiteFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("e2cfd3cedf7c40088b25aa82d6db3c77").ToReference<BlueprintFeatureReference>();
            if (BloodlineRequisiteFeature == null)
                return;
            PhoenixBloodlineRequisiteFeature = CreateBloodlineRequisiteFeature();

            BlueprintFeatureReference CreateBloodlineRequisiteFeature()
            {
                var AberrantBloodlineRequisiteFeature = TabletopTweaks.Core.Utilities.Helpers.CreateBlueprint<BlueprintFeature>(Main.TotFContext, "PhoenixBloodlineRequisiteFeature", bp =>
                {
                    bp.IsClassFeature = true;
                    bp.HideInUI = true;
                    bp.Ranks = 1;
                    bp.HideInCharacterSheetAndLevelUp = true;
                    bp.SetName(Main.TotFContext, "Phoenix Bloodline");
                    bp.SetDescription(Main.TotFContext, "Phoenix Bloodline Requisite Feature");
                });
                Main.TotFContext.Logger.LogPatch("Created", AberrantBloodlineRequisiteFeature);
                return AberrantBloodlineRequisiteFeature.ToReference<BlueprintFeatureReference>();
            }
        }
        public static void MakePhoenixBloodragerBloodline()
        {
            if (BloodlineRequisiteFeature == null)
                return;
            var BloodragerStandardRageBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("5eac31e457999334b98f98b60fc73b2f");
            var BloodragerClass = BlueprintTools.GetBlueprint<BlueprintCharacterClass>("d77e67a814d686842802c9cfd8ef8499").ToReference<BlueprintCharacterClassReference>();
            var GreenragerArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>("5648585af75596f4a9fa3ae385127f57").ToReference<BlueprintArchetypeReference>();

            var BurningHands = BlueprintTools.GetBlueprint<BlueprintAbility>("4783c3709a74a794dbe7c8e7e0b1b038").ToReference<BlueprintAbilityReference>();
            var LesserRestoration = BlueprintTools.GetBlueprint<BlueprintAbility>("e84fc922ccf952943b5240293669b171").ToReference<BlueprintAbilityReference>();
            var CSW = BlueprintTools.GetBlueprint<BlueprintAbility>("6e81a6679a0889a429dec9cedcf3729c").ToReference<BlueprintAbilityReference>();
            var ControlledFireball = BlueprintTools.GetBlueprint<BlueprintAbility>("f72f8f03bf0136c4180cd1d70eb773a5").ToReference<BlueprintAbilityReference>();//If Fire Shield not set

            var FireShield = BlueprintTool.Get<BlueprintAbility>("FireShield").ToReference<BlueprintAbilityReference>();

            //Bonus Feats
            var CombatReflexes = BlueprintTools.GetBlueprint<BlueprintFeature>("0f8939ae6f220984e8fb568abbdfba95").ToReference<BlueprintFeatureReference>();
            var CriticalFocus = BlueprintTools.GetBlueprint<BlueprintFeature>("8ac59959b1b23c347a0361dc97cc786d").ToReference<BlueprintFeatureReference>();
            var DieHard = BlueprintTools.GetBlueprint<BlueprintFeature>("86669ce8759f9d7478565db69b8c19ad").ToReference<BlueprintFeatureReference>();
            var Dodge = BlueprintTools.GetBlueprint<BlueprintFeature>("97e216dbb46ae3c4faef90cf6bbe6fd5").ToReference<BlueprintFeatureReference>();
            var Endurance = BlueprintTools.GetBlueprint<BlueprintFeature>("54ee847996c25cd4ba8773d7b8555174").ToReference<BlueprintFeatureReference>();
            var ImprovedInitiative = BlueprintTools.GetBlueprint<BlueprintFeature>("797f25d709f559546b29e7bcb181cc74").ToReference<BlueprintFeatureReference>();
            var Mobility = BlueprintTools.GetBlueprint<BlueprintFeature>("2a6091b97ad940943b46262600eaeaeb").ToReference<BlueprintFeatureReference>();

            //BloodlinePowers

            //Dispelling Strikes
            var dispelCooldownConfig = MakerTools.MakeBuff("BloodragerPhoenixDispellingStrikesCooldown", "Dispelling Strikes Cooldown", "");
            dispelCooldownConfig.SetFlags(BlueprintBuff.Flags.HiddenInUi);
            var dispelCooldown = dispelCooldownConfig.Configure();

            var dispellingStrikesIcon = BlueprintTools.GetBlueprint<BlueprintFeature>("1b92146b8a9830d4bb97ab694335fa7c").Icon;

            var BloodragerPhoenixDispellingStrikesDisplay = CreateBlueprint<BlueprintFeature>(Main.TotFContext, "BloodragerPhoenixDispellingStrikesDisplay", x =>
            {
                x.SetName(Main.TotFContext, "Dispelling Strikes");
                x.IsClassFeature = true;
                x.SetDescription(Main.TotFContext, "At 1st level, when you confirm a critical hit against a target, you can also attempt to dispel the target as if you had cast dispel magic as a bloodrager spell and used the targeted dispel function. You can dispel only a single magical effect per use of this ability, and you can use this ability against a particular creature only once per day. At 8th level, you gain a +2 bonus on your dispel check when using this ability. At 20th level, you can attempt to dispel all magical effects on your target when using this ability.");
            });
            Main.TotFContext.Logger.LogPatch("Created", BloodragerPhoenixDispellingStrikesDisplay);
            var BloodragerPhoenixDispellingStrikesLevel1 = CreateBlueprint<BlueprintFeature>(Main.TotFContext, "BloodragerPhoenixDispellingStrikesLevel1", x =>
            {
                x.SetName(Main.TotFContext, "Dispelling Strikes");
                x.IsClassFeature = true;
                x.SetDescription(Main.TotFContext, "At 1st level, when you confirm a critical hit against a target, you can also attempt to dispel the target as if you had cast dispel magic as a bloodrager spell and used the targeted dispel function. You can dispel only a single magical effect per use of this ability, and you can use this ability against a particular creature only once per day. At 8th level, you gain a +2 bonus on your dispel check when using this ability. At 20th level, you can attempt to dispel all magical effects on your target when using this ability.");
                x.HideInCharacterSheetAndLevelUp = true;
                x.HideInUI = true;
                x.AddComponent<PrerequisiteFeature>(x =>
                {
                    x.m_Feature = BloodragerPhoenixDispellingStrikesDisplay.ToReference<BlueprintFeatureReference>();
                    x.CheckInProgression = true;
                });
            });
            Main.TotFContext.Logger.LogPatch("Created", BloodragerPhoenixDispellingStrikesLevel1);
            var BloodragerPhoenixDispellingStrikesBuffLevel1 = CreateBlueprint<BlueprintBuff>(Main.TotFContext, "BloodragerPhoenixDispellingStrikesLevel1Buff", x =>
            {
                x.SetName(Main.TotFContext, "Dispelling Strikes");
                x.IsClassFeature = true;
                x.SetDescription(Main.TotFContext, "At 1st level, when you confirm a critical hit against a target, you can also attempt to dispel the target as if you had cast dispel magic as a bloodrager spell and used the targeted dispel function. You can dispel only a single magical effect per use of this ability, and you can use this ability against a particular creature only once per day. At 8th level, you gain a +2 bonus on your dispel check when using this ability. At 20th level, you can attempt to dispel all magical effects on your target when using this ability.");
                x.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                x.AddComponent<AddInitiatorAttackRollTrigger>(y =>
                {
                    y.Action = ActionsBuilder.New().Conditional(ConditionsBuilder.New().HasBuffFromCaster(dispelCooldown), ifFalse: ActionsBuilder.New().DispelMagic(Kingmaker.UnitLogic.Mechanics.Actions.ContextActionDispelMagic.BuffType.FromSpells, Kingmaker.RuleSystem.Rules.RuleDispelMagic.CheckType.CasterLevel, ContextValues.Constant(10), maxCasterLevel: new Kingmaker.UnitLogic.Mechanics.ContextValue()
                    {
                        ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Rank,
                        ValueRank = Kingmaker.Enums.AbilityRankType.Default
                    },
                    countToRemove: new Kingmaker.UnitLogic.Mechanics.ContextValue()
                    {
                        Value = 1,
                        ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Simple
                    }, onlyTargetEnemyBuffs: true).ApplyBuff(dispelCooldown, ContextDuration.Fixed(1, Kingmaker.UnitLogic.Mechanics.DurationRate.Days))).Build();
                });
                x.AddContextRankConfig(y =>
                {

                    y.m_Type = Kingmaker.Enums.AbilityRankType.Default;
                    y.m_BaseValueType = Kingmaker.UnitLogic.Mechanics.Components.ContextRankBaseValueType.CharacterLevel;
                    y.m_Class = new BlueprintCharacterClassReference[]
                    {
                            BloodragerClass
                    };

                });



            });
            Main.TotFContext.Logger.LogPatch("Created", BloodragerPhoenixDispellingStrikesBuffLevel1);


            var BloodragerPhoenixDispellingStrikesLevel8 = CreateBlueprint<BlueprintFeature>(Main.TotFContext, "BloodragerPhoenixDispellingStrikesLevel8", x =>
            {
                x.SetName(Main.TotFContext, "Dispelling Strikes");
                x.IsClassFeature = true;
                x.SetDescription(Main.TotFContext, "At 1st level, when you confirm a critical hit against a target, you can also attempt to dispel the target as if you had cast dispel magic as a bloodrager spell and used the targeted dispel function. You can dispel only a single magical effect per use of this ability, and you can use this ability against a particular creature only once per day. At 8th level, you gain a +2 bonus on your dispel check when using this ability. At 20th level, you can attempt to dispel all magical effects on your target when using this ability.");
                x.HideInCharacterSheetAndLevelUp = true;
                x.HideInUI = true;
                x.AddComponent<RemoveFeatureOnApply>(x =>
                {
                    x.m_Feature = BloodragerPhoenixDispellingStrikesLevel1.ToReference<BlueprintUnitFactReference>();
                });
                x.AddComponent<PrerequisiteFeature>(x =>
                {
                    x.m_Feature = BloodragerPhoenixDispellingStrikesDisplay.ToReference<BlueprintFeatureReference>();
                    x.CheckInProgression = true;
                });
            });
            Main.TotFContext.Logger.LogPatch("Created", BloodragerPhoenixDispellingStrikesLevel8);
            var BloodragerPhoenixDispellingStrikesBuffLevel8 = CreateBlueprint<BlueprintBuff>(Main.TotFContext, "BloodragerPhoenixDispellingStrikesLevel8Buff", x =>
            {
                x.SetName(Main.TotFContext, "Dispelling Strikes");
                x.SetDescription(Main.TotFContext, "At 1st level, when you confirm a critical hit against a target, you can also attempt to dispel the target as if you had cast dispel magic as a bloodrager spell and used the targeted dispel function. You can dispel only a single magical effect per use of this ability, and you can use this ability against a particular creature only once per day. At 8th level, you gain a +2 bonus on your dispel check when using this ability. At 20th level, you can attempt to dispel all magical effects on your target when using this ability.");
                x.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                x.IsClassFeature = true;
                x.AddComponent<AddInitiatorAttackRollTrigger>(y =>
                {
                    y.Action = ActionsBuilder.New().Conditional(ConditionsBuilder.New().HasBuffFromCaster(dispelCooldown), ifFalse: ActionsBuilder.New().DispelMagic(Kingmaker.UnitLogic.Mechanics.Actions.ContextActionDispelMagic.BuffType.FromSpells, Kingmaker.RuleSystem.Rules.RuleDispelMagic.CheckType.CasterLevel, ContextValues.Constant(10), maxCasterLevel: new Kingmaker.UnitLogic.Mechanics.ContextValue()
                    {
                        ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Rank,
                        ValueRank = Kingmaker.Enums.AbilityRankType.Default
                    },
                    checkBonus: 2,
                    countToRemove: new Kingmaker.UnitLogic.Mechanics.ContextValue()
                    {
                        Value = 1,
                        ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Simple
                    }, onlyTargetEnemyBuffs: true).ApplyBuff(dispelCooldown, ContextDuration.Fixed(1, Kingmaker.UnitLogic.Mechanics.DurationRate.Days))).Build();
                });
                x.AddContextRankConfig(y =>
                {

                    y.m_Type = Kingmaker.Enums.AbilityRankType.Default;
                    y.m_BaseValueType = Kingmaker.UnitLogic.Mechanics.Components.ContextRankBaseValueType.CharacterLevel;
                    y.m_Class = new BlueprintCharacterClassReference[]
                    {
                            BloodragerClass
                    };

                });



            });
            Main.TotFContext.Logger.LogPatch("Created", BloodragerPhoenixDispellingStrikesBuffLevel8);
            var BloodragerPhoenixDispellingStrikesLevel20 = CreateBlueprint<BlueprintFeature>(Main.TotFContext, "BloodragerPhoenixDispellingStrikesLevel20", x =>
            {
                x.SetName(Main.TotFContext, "Dispelling Strikes");
                x.IsClassFeature = true;
                x.SetDescription(Main.TotFContext, "At 1st level, when you confirm a critical hit against a target, you can also attempt to dispel the target as if you had cast dispel magic as a bloodrager spell and used the targeted dispel function. You can dispel only a single magical effect per use of this ability, and you can use this ability against a particular creature only once per day. At 8th level, you gain a +2 bonus on your dispel check when using this ability. At 20th level, you can attempt to dispel all magical effects on your target when using this ability.");
                x.HideInCharacterSheetAndLevelUp = true;
                x.HideInUI = true;
                x.AddComponent<RemoveFeatureOnApply>(x =>
                {
                    x.m_Feature = BloodragerPhoenixDispellingStrikesLevel8.ToReference<BlueprintUnitFactReference>();
                });
                x.AddComponent<PrerequisiteFeature>(x =>
                {
                    x.m_Feature = BloodragerPhoenixDispellingStrikesDisplay.ToReference<BlueprintFeatureReference>();
                    x.CheckInProgression = true;
                });
            });
            Main.TotFContext.Logger.LogPatch("Created", BloodragerPhoenixDispellingStrikesLevel20);
            var BloodragerPhoenixDispellingStrikesBuffLevel20 = CreateBlueprint<BlueprintBuff>(Main.TotFContext, "BloodragerPhoenixDispellingStrikesLevel20Buff", x =>
            {
                x.SetName(Main.TotFContext, "Dispelling Strikes");
                x.IsClassFeature = true;
                x.SetDescription(Main.TotFContext, "At 1st level, when you confirm a critical hit against a target, you can also attempt to dispel the target as if you had cast dispel magic as a bloodrager spell and used the targeted dispel function. You can dispel only a single magical effect per use of this ability, and you can use this ability against a particular creature only once per day. At 8th level, you gain a +2 bonus on your dispel check when using this ability. At 20th level, you can attempt to dispel all magical effects on your target when using this ability.");
                x.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                x.AddComponent<AddInitiatorAttackRollTrigger>(y =>
                {
                    y.Action = ActionsBuilder.New().Conditional(ConditionsBuilder.New().HasBuffFromCaster(dispelCooldown), ifFalse: ActionsBuilder.New().DispelMagic(Kingmaker.UnitLogic.Mechanics.Actions.ContextActionDispelMagic.BuffType.FromSpells, Kingmaker.RuleSystem.Rules.RuleDispelMagic.CheckType.CasterLevel, ContextValues.Constant(10), maxCasterLevel: new Kingmaker.UnitLogic.Mechanics.ContextValue()
                    {
                        ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Rank,
                        ValueRank = Kingmaker.Enums.AbilityRankType.Default
                    },
                    checkBonus: 2,
                    onlyTargetEnemyBuffs: true).ApplyBuff(dispelCooldown, ContextDuration.Fixed(1, Kingmaker.UnitLogic.Mechanics.DurationRate.Days))).Build();
                });
                x.AddContextRankConfig(y =>
                {

                    y.m_Type = Kingmaker.Enums.AbilityRankType.Default;
                    y.m_BaseValueType = Kingmaker.UnitLogic.Mechanics.Components.ContextRankBaseValueType.CharacterLevel;
                    y.m_Class = new BlueprintCharacterClassReference[]
                    {
                            BloodragerClass
                    };

                });



            });
            Main.TotFContext.Logger.LogPatch("Created", BloodragerPhoenixDispellingStrikesBuffLevel20);
            var HeartOfFireFeature = CreateBlueprint<BlueprintFeature>(Main.TotFContext, "BloodragerPhoenixHeartOfFire", x =>
            {
                x.SetName(Main.TotFContext, "Heart Of Fire");
                x.IsClassFeature = true;
                x.SetDescription(Main.TotFContext, "At 4th level, you gain fire resistance 5. Whenever you are subjected to a magical healing effect from a cure spell, you regain 1 additional hit point per die rolled. At 8th level, your fire resistance increases to 10, and you regain 2 additional hit points per die rolled when you are healed by a cure spell.");
                x.IsClassFeature = true;
                x.Ranks = 2;
            });
            Main.TotFContext.Logger.LogPatch("Created", HeartOfFireFeature);
            var HeartOfFireBuff = CreateBlueprint<BlueprintBuff>(Main.TotFContext, "BloodragerPhoenixHeartOfFireBuff", x =>
            {
                x.SetName(Main.TotFContext, "HeartOfFire");
                x.SetDescription(Main.TotFContext, "At 4th level, you gain fire resistance 5. Whenever you are subjected to a magical healing effect from a cure spell, you regain 1 additional hit point per die rolled. At 8th level, your fire resistance increases to 10, and you regain 2 additional hit points per die rolled when you are healed by a cure spell.");
                x.IsClassFeature = true;
                x.AddComponent<AddDamageResistanceEnergy>(x =>
                {
                    x.Type = Kingmaker.Enums.Damage.DamageEnergyType.Fire;
                    x.Value = new Kingmaker.UnitLogic.Mechanics.ContextValue()
                    {
                        ValueRank = Kingmaker.Enums.AbilityRankType.Default,
                        ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Rank
                    };
                    x.ValueMultiplier = 5;
                });
                x.AddContextRankConfig(x =>
                {
                    x.m_Feature = HeartOfFireFeature.ToReference<BlueprintFeatureReference>();
                    x.m_BaseValueType = ContextRankBaseValueType.FeatureRank;
                });
                x.AddComponent<PhoenixHeartOfFireHealingComponent>(x =>
                {
                    x.healIncreasePerDie = new Kingmaker.UnitLogic.Mechanics.ContextValue()
                    {
                        ValueRank = Kingmaker.Enums.AbilityRankType.Default,
                        ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Rank
                    };
                });
                x.m_Flags = BlueprintBuff.Flags.HiddenInUi;
            });
            Main.TotFContext.Logger.LogPatch("Created", HeartOfFireBuff);
            var BlazingVitalityFeature = CreateBlueprint<BlueprintFeature>(Main.TotFContext, "BloodragerPhoenixBlazingVitality", x =>
            {
                x.SetName(Main.TotFContext, "Blazing Vitality");
                x.IsClassFeature = true;
                x.SetDescription(Main.TotFContext, "When tensions run high and your emotions flare, you let forth waves of restorative energy from within. At 8th level, you emit a 10-foot-radius aura of energizing fire while bloodraging. Any ally that ends their turn within this aura gains a number of temporary hit points equal to your Constitution modifier. These temporary hit points last for 1 minute.");
            });
            Main.TotFContext.Logger.LogPatch("Created", BlazingVitalityFeature);
            var BlazingVitalityEffectBuff = CreateBlueprint<BlueprintBuff>(Main.TotFContext, "BloodragerPhoenixBlazingVitalityEffectBuff", x =>
            {
                x.SetName(Main.TotFContext, "Blazing Vitality");
                x.SetDescription(Main.TotFContext, "When tensions run high and your emotions flare, you let forth waves of restorative energy from within. At 8th level, you emit a 10-foot-radius aura of energizing fire while bloodraging. Any ally that ends their turn within this aura gains a number of temporary hit points equal to your Constitution modifier. These temporary hit points last for 1 minute.");
                x.Stacking = StackingType.Replace;
                x.AddComponent<TemporaryHitPointsFromAbilityValue>(x =>
                {
                    x.RemoveWhenHitPointsEnd = true;
                    x.Value = new Kingmaker.UnitLogic.Mechanics.ContextValue()
                    {
                        ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Rank,
                        ValueRank = Kingmaker.Enums.AbilityRankType.Default
                    };
                });
                x.AddContextRankConfig(x =>
                {
                    x.m_Type = Kingmaker.Enums.AbilityRankType.StatBonus;
                    x.m_Stat = Kingmaker.EntitySystem.Stats.StatType.Constitution;
                });

            });
            Main.TotFContext.Logger.LogPatch("Created", BlazingVitalityEffectBuff);
            var BlazingVitalityArea = CreateBlueprint<BlueprintAbilityAreaEffect>(Main.TotFContext, "BloodragerPhoenixBlazingVitalityArea", x =>
            {
                x.AddComponent<AbilityAreaEffectBuff>(x =>
                {
                    x.Condition = new Kingmaker.ElementsSystem.ConditionsChecker()
                    {
                        Operation = Kingmaker.ElementsSystem.Operation.And,
                        Conditions = new Kingmaker.ElementsSystem.Condition[]
                        {
                            new ContextConditionIsAlly(){Not = false}
                        }
                    };
                    x.m_Buff = BlazingVitalityEffectBuff.ToReference<BlueprintBuffReference>();
                });
                x.Shape = AreaEffectShape.Cylinder;
                x.AggroEnemies = false;
                x.Size = new Kingmaker.Utility.Feet(10);
                x.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;

            });
            Main.TotFContext.Logger.LogPatch("Created", BlazingVitalityArea);
            var BlazingVitalityBuff = CreateBlueprint<BlueprintBuff>(Main.TotFContext, "BloodragerPhoenixBlazingVitalityBuff", x =>
             {
                 x.SetName(Main.TotFContext, "Blazing Vitality");
                 x.SetDescription(Main.TotFContext, "When tensions run high and your emotions flare, you let forth waves of restorative energy from within. At 8th level, you emit a 10-foot-radius aura of energizing fire while bloodraging. Any ally that ends their turn within this aura gains a number of temporary hit points equal to your Constitution modifier. These temporary hit points last for 1 minute.");
                 x.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                 x.IsClassFeature = true;
                 x.AddComponent<AddAreaEffect>(x =>
                 {
                     x.m_AreaEffect = BlazingVitalityArea.ToReference<BlueprintAbilityAreaEffectReference>();
                 });

             });
            Main.TotFContext.Logger.LogPatch("Created", BlazingVitalityBuff);
            var MoltenWingsFeature = CreateBlueprint<BlueprintFeature>(Main.TotFContext, "BloodragerPheonixMoltenWings", x =>
            {
                x.SetName(Main.TotFContext, "Molten Wings");
                x.SetDescription(Main.TotFContext, "At 12th level, you spout molten wings during bloodrage");
                x.IsClassFeature = true;
            });
            var CelestialWingsFeature = BlueprintTools.GetBlueprint<BlueprintBuff>("d596694ff285f3f429528547f441b1c0");

            var selfRezResource = CreateBlueprint<BlueprintAbilityResource>(Main.TotFContext, "BloodragerPhoenixSelfResurrectionResource", x =>
            {
                x.m_MaxAmount = new BlueprintAbilityResource.Amount()
                {
                    BaseValue = 1,
                    IncreasedByLevel = false,
                    IncreasedByStat = false
                };
                x.m_Min = 0;

            });
            Main.TotFContext.Logger.LogPatch("Created", selfRezResource);
            var SelfRezEffectBuff = CreateBlueprint<BlueprintBuff>(Main.TotFContext, "BloodragerPhoenixSelfResurrectionEffectBuff", x =>
            {
                x.SetName(Main.TotFContext, "Self-Resurrection");
                x.SetDescription(Main.TotFContext, "From the ashes of your body springs forth new life. At 16th level, once per day when you are reduced below 0 hit points while you are bloodraging, you can call upon the power in your blood to pull yourself back from death. This functions as a breath of life spell cast upon yourself. At 20th level, this instead functions as a heal spell, except that the healing can return you to life as per breath of life, using your bloodrager level as your caster level. Using this ability does not take an action. This ability does not function if your body is completely destroyed by an effect such as disintegrate.");
                x.IsClassFeature = true;
                x.AddComponent<AddImmortality>();
                x.AddComponent<AddIncomingDamageTrigger>(x =>
                {
                    x.ReduceBelowZero = true;
                    x.CompareType = Kingmaker.UnitLogic.Mechanics.CompareOperation.Type.Equal;
                    x.TargetValue = ContextValues.Constant(0);
                    x.Actions = ActionsBuilder.New().Conditional(ConditionsBuilder.New().CharacterClass(true, BloodragerClass, 20),
                        ifTrue: ActionsBuilder.New().RemoveBuff("9934fedff1b14994ea90205d189c8759").RemoveBuff("09d39b38bb7c6014394b6daced9bacd3").HealTarget(new Kingmaker.UnitLogic.Mechanics.ContextDiceValue()
                        {
                            DiceType = 0,
                            DiceCountValue = new Kingmaker.UnitLogic.Mechanics.ContextValue()
                            {
                                ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Simple,
                                Value = 0,

                            },
                            BonusValue = new Kingmaker.UnitLogic.Mechanics.ContextValue
                            {
                                ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Simple,
                                Value = 150//Can't get this one before heal caps!
                            }
                        }).HealStatDamage(ContextActionHealStatDamage.StatDamageHealType.HealAllDamage, ContextActionHealStatDamage.StatClass.Any, value: new Kingmaker.UnitLogic.Mechanics.ContextDiceValue()
                        {
                            DiceType = 0,
                            DiceCountValue = new Kingmaker.UnitLogic.Mechanics.ContextValue()
                            {
                                ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Simple,
                                Value = 0,

                            },
                            BonusValue = new Kingmaker.UnitLogic.Mechanics.ContextValue
                            {
                                ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Simple,
                                Value = 0
                            }
                        }).RemoveBuff("187f88d96a0ef464280706b63635f2af").RemoveBuff("52e4be2ba79c8c94d907bdbaf23ec15f").RemoveBuff("df6d1025da07524429afbae248845ecc")
                        .RemoveBuffsByDescriptor(new Kingmaker.Blueprints.Classes.Spells.SpellDescriptorWrapper()
                        {
                            m_IntValue = 229327104
                        }).RemoveBuff("53808be3c2becd24dbe572f77a7f44f8").RemoveBuff("8b3b4c225fe0fb046bfa8881c3ddad0d").RemoveBuff("88f1ab751a9555a40abe9d7743e865fb"),
                        ifFalse: ActionsBuilder.New().HealTarget(new Kingmaker.UnitLogic.Mechanics.ContextDiceValue()
                        {
                            DiceType = Kingmaker.RuleSystem.DiceType.D8,
                            DiceCountValue = ContextValues.Constant(5),
                            BonusValue = ContextValues.Rank(Kingmaker.Enums.AbilityRankType.Default)
                        })
                        ).ContextSpendResource(selfRezResource, ContextValues.Constant(1)).Conditional(ConditionsBuilder.New().Add<ContextConditionCasterHasResource>(x =>
                        {
                            x.Amount = 1;
                            x.m_Resource = selfRezResource.ToReference<BlueprintAbilityResourceReference>();


                        }), ifFalse: ActionsBuilder.New().RemoveSelf())
                    .Build();

                });
                x.AddContextRankConfig(x =>
                {
                    x.m_BaseValueType = ContextRankBaseValueType.ClassLevel;
                    x.m_StartLevel = -10;//Add Heart Of Fire to effect
                    x.m_Max = 25;

                });
            });
            Main.TotFContext.Logger.LogPatch("Created", SelfRezEffectBuff);
            var SelfRez = CreateBlueprint<BlueprintFeature>(Main.TotFContext, "BloodragerPhoenixSelfResurrection", x =>
            {
                x.SetName(Main.TotFContext, "Self-Resurrection");
                x.SetDescription(Main.TotFContext, "From the ashes of your body springs forth new life. At 16th level, once per day when you are reduced below 0 hit points while you are bloodraging, you can call upon the power in your blood to pull yourself back from death. This functions as a breath of life spell cast upon yourself. At 20th level, this instead functions as a heal spell, except that the healing can return you to life as per breath of life, using your bloodrager level as your caster level. Using this ability does not take an action. This ability does not function if your body is completely destroyed by an effect such as disintegrate.");
                x.IsClassFeature = true;
                x.Ranks = 1;
                x.m_Icon = BlueprintTools.GetBlueprint<BlueprintBuff>("9988e25ec217c0249a28213e7dc0017c").Icon;
                x.AddComponent<AddAbilityResources>(x =>
                {
                    x.m_Resource = selfRezResource.ToReference<BlueprintAbilityResourceReference>();
                    x.RestoreAmount = true;

                });
                x.AddComponent<AddRestTrigger>(x =>
                {
                    x.Action = ActionsBuilder.New().ApplyBuffPermanent(SelfRezEffectBuff, isFromSpell: false, isNotDispelable: true).Build();
                });
                x.AddComponent<AddFacts>(x =>
                {
                    x.m_Facts = new BlueprintUnitFactReference[]
                    {
                        SelfRezEffectBuff.ToReference<BlueprintUnitFactReference>()
                        
                    };
                    x.DoNotRestoreMissingFacts = true;
                });
                x.ReapplyOnLevelUp = false;
            });
            Main.TotFContext.Logger.LogPatch("Created", SelfRez);
            var PhoenixFireArea = CreateBlueprint<BlueprintAbilityAreaEffect>(Main.TotFContext, "BloodragerPhoenixFireArea", x =>
            {
                x.AddComponent<AbilityAreaEffectRunAction>(x =>
                {
                x.UnitEnter = new();
                x.UnitExit = new();
                x.UnitMove = new();

                x.Round = ActionsBuilder.New().Conditional(ConditionsBuilder.New().IsAlly(negate: true).IsInCombat(), ifTrue: ActionsBuilder.New().SavingThrow(type: Kingmaker.EntitySystem.Stats.SavingThrowType.Reflex, fromBuff: false, onResult: ActionsBuilder.New().DealDamage(new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription() { Type = Kingmaker.RuleSystem.Rules.Damage.DamageType.Energy, Energy = Kingmaker.Enums.Damage.DamageEnergyType.Fire }, ContextDice.Value(Kingmaker.RuleSystem.DiceType.D6, diceCount: ContextValues.Constant(4), bonus: ContextValues.Constant(0)), halfIfSaved: true, isAoE:true))).Build();
                });
                x.AddComponent<ContextCalculateAbilityParamsBasedOnClass>(x =>
                {
                    x.m_CharacterClass = BloodragerClass;
                    x.StatType = Kingmaker.EntitySystem.Stats.StatType.Constitution;
                });
                x.AffectEnemies = true;
                x.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Enemy;
                x.Shape = AreaEffectShape.Cylinder;
                x.Size = new Kingmaker.Utility.Feet(20);
            });
            Main.TotFContext.Logger.LogPatch("Created", PhoenixFireArea);
            var PheonixFireFeature = CreateBlueprint<BlueprintFeature>(Main.TotFContext, "BloodragerPhoenixFire", x =>
            {
                x.SetName(Main.TotFContext, "Phoenix Fire");
                x.IsClassFeature = true;
                x.SetDescription(Main.TotFContext, "The power of the phoenix brings righteous destruction to any who oppose it. At 20th level, while bloodraging, you gain the following effects: your melee attacks deal an additional 2d6 points of fire damage, any enemies within 20 feet of you must succeed at a Reflex save (DC = 10 + 1/2 your bloodrager level + your Constitution modifier) or take 4d6 points of fire damage at the start of their turn, and any creature that attacks you with a natural or non-reach weapon takes 1d6 points of fire damage (no save) with each successful hit.");
            });
            Main.TotFContext.Logger.LogPatch("Created", PheonixFireFeature);
            var PheonixFireBuff = CreateBlueprint<BlueprintBuff>(Main.TotFContext, "BloodragerPhoenixFireBuff", x =>
            {
                x.SetName(Main.TotFContext, "Phoenix Fire");
                x.IsClassFeature = true;
                x.SetDescription(Main.TotFContext, "The power of the phoenix brings righteous destruction to any who oppose it. At 20th level, while bloodraging, you gain the following effects: your melee attacks deal an additional 2d6 points of fire damage, any enemies within 20 feet of you must succeed at a Reflex save (DC = 10 + 1/2 your bloodrager level + your Constitution modifier) or take 4d6 points of fire damage at the start of their turn, and any creature that attacks you with a natural or non-reach weapon takes 1d6 points of fire damage (no save) with each successful hit.");
                x.AddComponent<AddAdditionalWeaponDamage>(x =>
                {
                    x.DamageType = new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription()
                    {
                        Type = Kingmaker.RuleSystem.Rules.Damage.DamageType.Energy,
                        Energy = Kingmaker.Enums.Damage.DamageEnergyType.Fire
                    };
                    x.Value = new Kingmaker.UnitLogic.Mechanics.ContextDiceValue()
                    {
                        DiceType = Kingmaker.RuleSystem.DiceType.D6,
                        DiceCountValue = ContextValues.Constant(2),
                        BonusValue = ContextValues.Constant(0)
                    };
                    x.CheckWeaponRangeType = true;
                    x.RangeType = Kingmaker.Enums.WeaponRangeType.Melee;
                });
                ActionsBuilder fireBacklash = ActionsBuilder.New().DealDamage(new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription() { Type = Kingmaker.RuleSystem.Rules.Damage.DamageType.Energy, Energy = Kingmaker.Enums.Damage.DamageEnergyType.Fire },value: ContextDice.Value(Kingmaker.RuleSystem.DiceType.D6, ContextValues.Constant(1), ContextValues.Constant(0)));
                x.AddComponent<AddTargetAttackRollTrigger>(x =>
                {
                    
                    x.OnlyMelee = true;
                    x.NotReach = true;
                    x.ActionsOnAttacker = fireBacklash.Build();
                });
                x.AddComponent<AddAreaEffect>(x =>
                {
                    x.m_AreaEffect = PhoenixFireArea.ToReference<BlueprintAbilityAreaEffectReference>();

                });
            });
            Main.TotFContext.Logger.LogPatch("Created", PheonixFireBuff);
            var BloodragerPhoenixFeatSelection = CreateBlueprint<BlueprintFeatureSelection>(Main.TotFContext, "BloodragerPhoenixFeatSelection", bp =>
            {
                bp.SetName(Main.TotFContext, "Bonus Feats");
                bp.SetDescription(Main.TotFContext, "Combat Reflexes, Critical Focus, Diehard, Dodge, Endurance, Improved Initiative, Mobility");
                bp.IsClassFeature = true;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.HideNotAvailibleInUI = true;

                bp.m_Features = new BlueprintFeatureReference[] {
                    CombatReflexes,
                    CriticalFocus,
                    DieHard,
                    Dodge,
                    Endurance,
                    ImprovedInitiative,
                    Mobility
                };
                bp.m_AllFeatures = bp.m_Features;
            });
            Main.TotFContext.Logger.LogPatch("Created", BloodragerPhoenixFeatSelection);
            var BloodragerPhoenixFeatSelectionGreenrager = CreateBlueprint<BlueprintFeatureSelection>(Main.TotFContext, "BloodragerPhoenixFeatSelectionGreenrager", bp =>
            {
                bp.SetName(BloodragerPhoenixFeatSelection.m_DisplayName);
                bp.SetDescription(BloodragerPhoenixFeatSelection.m_Description);
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.HideNotAvailibleInUI = true;

                bp.m_Features = BloodragerPhoenixFeatSelection.m_Features;
                bp.m_AllFeatures = bp.m_Features;
                bp.AddComponent<PrerequisiteNoArchetype>(c =>
                {
                    c.HideInUI = true;
                    c.m_CharacterClass = BloodragerClass;
                    c.m_Archetype = GreenragerArchetype;
                });
            });
            Main.TotFContext.Logger.LogPatch("Created", BloodragerPhoenixFeatSelectionGreenrager);
            //Bloodline Spells
            var BloodragerPhoenixSpell7 = CreateBlueprint<BlueprintFeature>(Main.TotFContext, "BloodragerPhoenixSpell7", bp =>
            {
                var spell = BurningHands;
                bp.SetName(Main.TotFContext, $"Bonus Spell — Burning Hands");
                bp.SetDescription(Main.TotFContext, "At 7th, 10th, 13th, and 16th levels, a bloodrager learns an additional spell derived from his bloodline.");
                bp.IsClassFeature = true;
                bp.AddComponent<AddKnownSpell>(c =>
                {
                    c.m_CharacterClass = BloodragerClass;
                    c.m_Spell = spell;
                    c.SpellLevel = 1;
                });
                bp.m_Icon = spell.Get().Icon;
            });
            Main.TotFContext.Logger.LogPatch("Created", BloodragerPhoenixSpell7);
            var BloodragerPhoenixSpell10 = CreateBlueprint<BlueprintFeature>(Main.TotFContext, "BloodragerPhoenixSpell10", bp =>
            {
                var spell = LesserRestoration;
                bp.SetName(Main.TotFContext, $"Bonus Spell — Lesser Restoration");
                bp.SetDescription(Main.TotFContext, "At 7th, 10th, 13th, and 16th levels, a bloodrager learns an additional spell derived from his bloodline.");
                bp.IsClassFeature = true;
                bp.AddComponent<AddKnownSpell>(c =>
                {
                    c.m_CharacterClass = BloodragerClass;
                    c.m_Spell = spell;
                    c.SpellLevel = 2;
                });
                bp.m_Icon = spell.Get().Icon;
            });

            Main.TotFContext.Logger.LogPatch("Created", BloodragerPhoenixSpell10);
            var BloodragerPhoenixSpell13 = CreateBlueprint<BlueprintFeature>(Main.TotFContext, "BloodragerPhoenixSpell13", bp =>
            {
                var spell = CSW;
                bp.SetName(Main.TotFContext, $"Bonus Spell — Cure Serious Wounds");
                bp.SetDescription(Main.TotFContext, "At 7th, 10th, 13th, and 16th levels, a bloodrager learns an additional spell derived from his bloodline.");
                bp.IsClassFeature = true;
                bp.AddComponent<AddKnownSpell>(c =>
                {
                    c.m_CharacterClass = BloodragerClass;
                    c.m_Spell = spell;
                    c.SpellLevel = 3;
                });
                bp.m_Icon = spell.Get().Icon;
            });
            Main.TotFContext.Logger.LogPatch("Created", BloodragerPhoenixSpell13);
            var BloodragerPhoenixSpell16 = CreateBlueprint<BlueprintFeature>(Main.TotFContext, "BloodragerPhoenixSpell16", bp =>
            {
                var spell = Main.TotFContext.NewContent.Spells.IsEnabled("FireShield") ? FireShield : ControlledFireball;
                bp.SetName(Main.TotFContext, $"Bonus Spell — {(Main.TotFContext.NewContent.Spells.IsEnabled("FireShield") ? "Fire Shield" : "Controlled Fireball")}");
                bp.SetDescription(Main.TotFContext, "At 7th, 10th, 13th, and 16th levels, a bloodrager learns an additional spell derived from his bloodline.");
                bp.IsClassFeature = true;
                bp.AddComponent<AddKnownSpell>(c =>
                {
                    c.m_CharacterClass = BloodragerClass;
                    c.m_Spell = spell;
                    c.SpellLevel = 4;
                });
                bp.m_Icon = spell.Get().Icon;
            });
            Main.TotFContext.Logger.LogPatch("Created", BloodragerPhoenixSpell16);

            string fourthSpell = Main.TotFContext.NewContent.Spells.IsEnabled("FireShield") ? "Fire Shield" : "Controlled Fireball";

            //Bloodline Core
            var BloodragerPhoenixBloodline = TabletopTweaks.Core.Utilities.Helpers.CreateBlueprint<BlueprintProgression>(Main.TotFContext, "BloodragerPhoenixBloodline", bp =>
            {
                bp.SetName(Main.TotFContext, "Phoenix");
                bp.SetDescription(Main.TotFContext, "One of your ancestors may have witnessed the fiery resurrection of a phoenix or been healed by the grace of this legendary bird. Whatever the case, the flames of the phoenix burn brightly within your soul, filling you with an inextinguishable vitality that can withstand the most harrowing of assaults. .\n"
                    + "When you bloodrage, vibrant energy boils forth from beneath your skin, granting you both the soothing warmth to heal a friend’s wounds and the brutal power to burn flesh from bone. Your rage is an awesome and terrible thing to behold, as the raw power of your untamed life force can allow you to pull yourself back from the grasp of death itself.\n"
                    + BloodragerPhoenixFeatSelection.Description
                    + $"\nBonus Spells: Burning Hands(7th), Lesser Restoration (10th), Cure Serious Wounds (13th), {fourthSpell} (16th).");
                bp.IsClassFeature = true;
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = BloodragerClass
                    }
                    };
                bp.Groups = new FeatureGroup[] { FeatureGroup.BloodragerBloodline };
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.GiveFeaturesForPreviousLevels = true;
                bp.LevelEntries = new LevelEntry[] {
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(1, BloodragerPhoenixDispellingStrikesDisplay, BloodragerPhoenixDispellingStrikesLevel1, PhoenixBloodlineRequisiteFeature, BloodlineRequisiteFeature),
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(4, HeartOfFireFeature),

                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(6, BloodragerPhoenixFeatSelectionGreenrager),
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(7, BloodragerPhoenixSpell7),
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(8,   HeartOfFireFeature, BlazingVitalityFeature, BloodragerPhoenixDispellingStrikesLevel8),
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(9, BloodragerPhoenixFeatSelectionGreenrager),
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(10, BloodragerPhoenixSpell10),
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(12, BloodragerPhoenixFeatSelection, MoltenWingsFeature),
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(13, BloodragerPhoenixSpell13),
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(15, BloodragerPhoenixFeatSelection),
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(16, SelfRez, BloodragerPhoenixSpell16),
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(18, BloodragerPhoenixFeatSelection),
                    TabletopTweaks.Core.Utilities.Helpers.CreateLevelEntry(20, BloodragerPhoenixDispellingStrikesLevel20, PheonixFireFeature)
                    };
                bp.AddPrerequisite<PrerequisiteNoFeature>(c =>
                {
                    c.Group = Prerequisite.GroupType.Any;
                    c.m_Feature = BloodlineRequisiteFeature;
                });
                bp.AddPrerequisite<PrerequisiteFeature>(c =>
                {
                    c.Group = Prerequisite.GroupType.Any;
                    c.m_Feature = PhoenixBloodlineRequisiteFeature;
                });
                bp.UIGroups = new UIGroup[] {
                    TabletopTweaks.Core.Utilities.Helpers.CreateUIGroup(BloodragerPhoenixFeatSelection, BloodragerPhoenixFeatSelectionGreenrager)
                    };
            });
            var BloodragerPhoenixBloodlineWandering = BloodlineTools.CreateMixedBloodFeature(Main.TotFContext, "BloodragerPheonixBloodlineWandering", BloodragerPhoenixBloodline, bp =>
            {
                bp.m_Icon = AssetLoader.LoadInternal(Main.TotFContext, folder: "Abilities", file: "Phoenix_Bloodline.png");
            });
            var BloodragerPhoenixBaseBuff = TabletopTweaks.Core.Utilities.Helpers.CreateBlueprint<BlueprintBuff>(Main.TotFContext, "BloodragerPhoenixBaseBuff", bp =>
            {
                bp.SetName(Main.TotFContext, "Phoenix Bloodrage");
                bp.SetDescription(Main.TotFContext, "");
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.IsClassFeature = true;
            });

            BloodragerPhoenixBaseBuff.AddConditionalBuff(BloodragerPhoenixDispellingStrikesLevel1, BloodragerPhoenixDispellingStrikesBuffLevel1);
            BloodragerPhoenixBaseBuff.AddConditionalBuff(BloodragerPhoenixDispellingStrikesLevel8, BloodragerPhoenixDispellingStrikesBuffLevel8);
            BloodragerPhoenixBaseBuff.AddConditionalBuff(BloodragerPhoenixDispellingStrikesLevel20, BloodragerPhoenixDispellingStrikesBuffLevel20);
            BloodragerPhoenixBaseBuff.AddConditionalBuff(HeartOfFireFeature, HeartOfFireBuff);
            BloodragerPhoenixBaseBuff.AddConditionalBuff(BlazingVitalityFeature, BlazingVitalityBuff);
            BloodragerPhoenixBaseBuff.AddConditionalBuff(MoltenWingsFeature, CelestialWingsFeature);
            BloodragerPhoenixBaseBuff.AddConditionalBuff(PheonixFireFeature, PheonixFireBuff);
            BloodragerStandardRageBuff.AddConditionalBuff(BloodragerPhoenixBloodline, BloodragerPhoenixBaseBuff);

            BloodlineTools.ApplyPrimalistException(HeartOfFireFeature, 4, BloodragerPhoenixBloodline);
            BloodlineTools.ApplyPrimalistException(BlazingVitalityFeature, 8, BloodragerPhoenixBloodline);
            BloodlineTools.ApplyPrimalistException(MoltenWingsFeature, 12, BloodragerPhoenixBloodline);
            BloodlineTools.ApplyPrimalistException(SelfRez, 16, BloodragerPhoenixBloodline);
            BloodlineTools.ApplyPrimalistException(PheonixFireFeature, 20, BloodragerPhoenixBloodline);
            ProgressionConfigurator.For(BloodragerClass.Get().Progression).AddToUIGroups(BloodragerPhoenixSpell7, BloodragerPhoenixSpell10, BloodragerPhoenixSpell13, BloodragerPhoenixSpell16).AddToUIGroups(BloodragerPhoenixDispellingStrikesDisplay, MoltenWingsFeature, SelfRez, PheonixFireFeature).Configure();
            if (Main.TotFContext.NewContent.Bloodlines.IsDisabled("BloodragerPhoenixBloodline")) { return; }
            BloodlineTools.RegisterBloodragerBloodline(BloodragerPhoenixBloodline, BloodragerPhoenixBloodlineWandering);

          

        }
    }
}

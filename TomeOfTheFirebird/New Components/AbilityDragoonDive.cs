using Kingmaker.Blueprints.Root;
using Kingmaker;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Commands;
using Kingmaker.Utility;
using Kingmaker.Visual.Animation.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kingmaker.ResourceLinks;
using UnityEngine;
using Kingmaker.Controllers;
using Kingmaker.View;
using Kingmaker.Localization;
using JetBrains.Annotations;
using Kingmaker.Blueprints;

namespace TomeOfTheFirebird.New_Components
{
    internal class AbilityDragoonDive : AbilityCustomLogic, IAbilityTargetRestriction
    {
        public override bool IsEngageUnit
        {
            get
            {
                return true;
            }
        }

        public override void Cleanup(AbilityExecutionContext context)
        {
            context.Caster.View.AgentASP.AvoidanceDisabled = false;
            context.Caster.View.AgentASP.MaxSpeedOverride = null;
            context.Caster.Descriptor.State.IsCharging = false;
            context.Caster.State.Features.IsUntargetable.Release();
            context.Caster.Descriptor.State.RemoveCondition(UnitCondition.DisableAttacksOfOpportunity, null);
        }

        public override IEnumerator<AbilityDeliveryTarget> Deliver(AbilityExecutionContext context, TargetWrapper target)
        {
            UnitEntityData caster = context.Caster;
            if (target.Unit == null)
            {
                PFLog.Default.Error("Target unit is missing", Array.Empty<object>());
                yield break;
            }
            Vector3 startPoint = caster.Position;
            caster.Descriptor.State.AddCondition(UnitCondition.DisableAttacksOfOpportunity, null, null);
            caster.Descriptor.AddBuff(BlueprintRoot.Instance.SystemMechanics.ChargeBuff, context, new TimeSpan?(1.Rounds().Seconds));


            caster.Descriptor.State.IsCharging = true;
            caster.View.StopMoving();
            AnimationActionHandle handle = caster.View.AnimationManager.CreateHandle(this.TakeOffAnimation.Load(false, false));
            caster.View.AnimationManager.Execute(handle);
            TimeSpan startTime = Game.Instance.TimeController.GameTime;
            bool wasHidden = false;
            while (Game.Instance.TimeController.GameTime - startTime < this.TakeoffTime.Seconds())
            {
                if (!wasHidden && Game.Instance.TimeController.GameTime - startTime > this.DisappearStartTime.Seconds())
                {
                    caster.View.Fader.Visible = false;
                    caster.View.Fader.Force();
                    wasHidden = true;
                }
                caster.CombatState.PreventAttacksOfOpporunityNextFrame = true;
                yield return null;
            }
            Vector3 endPoint = GetEndPoint(target, startPoint, caster);
            caster.State.Features.IsUntargetable.Retain();
            caster.Translocate(endPoint, new float?(caster.GetLookAtAngle(target.Unit.Position)));
            handle = caster.View.AnimationManager.CreateHandle(this.LandingAnimation.Load(false, false));
            caster.View.AnimationManager.Execute(handle);
            startTime = Game.Instance.TimeController.GameTime;
            bool wasShown = false;
            while (!handle.IsFinished && Game.Instance.TimeController.GameTime - startTime < this.LandingTime.Seconds())
            {
                if (Game.Instance.TurnBasedCombatController.WaitingForUI)
                {
                    yield return null;
                }
                else
                {
                    if (!wasShown && Game.Instance.TimeController.GameTime - startTime > this.AppearTime.Seconds())
                    {
                        caster.View.Fader.Visible = true;
                        caster.View.Fader.Force();
                        wasShown = true;
                    }
                    caster.CombatState.PreventAttacksOfOpporunityNextFrame = true;
                    yield return null;
                }
            }
            if (!target.Unit.State.IsDead)
            {
                UnitAttack unitAttack = new UnitAttack(target.Unit, null)
                {
                    IsCharge = true,
                    IsAttackFull = m_PounceFeature != null && caster.HasFact(m_PounceFeature),
                };
                unitAttack.IgnoreCooldown(null);
                unitAttack.Init(caster);
                caster.Commands.AddToQueueFirst(unitAttack);
            }
            yield break;
        }

       

        private static Vector3 GetEndPoint(TargetWrapper target, Vector3 startPoint, UnitEntityData caster)
        {
            Vector3 vector = target.Point - startPoint;
            float magnitude = vector.magnitude;
            return ObstacleAnalyzer.GetNearestNode(startPoint + vector.normalized * (magnitude - target.Unit.Corpulence - caster.Corpulence), null).position;
        }

        public string GetAbilityTargetRestrictionUIText(UnitEntityData caster, TargetWrapper target)
        {
            LocalizedString localizedString;
            this.CheckTargetRestriction(caster, target, out localizedString);
            return localizedString;
        }

        

        public bool IsTargetRestrictionPassed(UnitEntityData caster, TargetWrapper targetWrapper)
        {
            LocalizedString localizedString;
            return this.CheckTargetRestriction(caster, targetWrapper, out localizedString);
        }

        private bool CheckTargetRestriction(UnitEntityData caster, TargetWrapper targetWrapper, [CanBeNull] out LocalizedString failReason)
        {
            UnitEntityData unitEntityData = (targetWrapper != null) ? targetWrapper.Unit : null;
            if (unitEntityData == null)
            {
                failReason = BlueprintRoot.Instance.LocalizedTexts.Reasons.TargetIsInvalid;
                return false;
            }
            if (caster.RiderPart || caster.SaddledPart)
            {
                failReason = BlueprintRoot.Instance.LocalizedTexts.Reasons.AbilityDisabled;
                return false;
            }
            float magnitude = (unitEntityData.Position - caster.Position).magnitude;
            if (magnitude > AbilityCustomCharge.GetMaxRangeMeters(caster))
            {
                //TODO replace this with custom max-range logic later
                failReason = BlueprintRoot.Instance.LocalizedTexts.Reasons.TargetIsTooFar;
                return false;
            }
            
            failReason = null;
            return true;
        }

        // Token: 0x04008A28 RID: 35368
        public UnitAnimationActionLink TakeOffAnimation;

        // Token: 0x04008A29 RID: 35369
        public UnitAnimationActionLink LandingAnimation;

        public BlueprintFeatureReference m_PounceFeature;

        // Token: 0x04008A2A RID: 35370
        public float TakeoffTime = 1.2f;

        // Token: 0x04008A2B RID: 35371
        public float LandingTime = 1.5f;

        // Token: 0x04008A2C RID: 35372
        [InfoBox("Time from ability start before hiding unit view")]
        public float DisappearStartTime = 1.1f;

        // Token: 0x04008A2D RID: 35373
        [InfoBox("Time from teleporting and starting of LandingAnimation before show unit view")]
        public float AppearTime = 0.1f;
    }
}

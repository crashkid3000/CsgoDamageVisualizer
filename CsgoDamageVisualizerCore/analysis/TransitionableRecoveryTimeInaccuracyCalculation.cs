using CsgoDamageVisualizerCore.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerCore.analysis
{
    /// <summary>
    /// <para>This fire inaccuracy model applies to guns where the firing inaccuracy <i>does</i> change just from firing it.</para>
    /// <para>The most prominent examples of this are the AK-47 (where the recovery time increases when spraying) and the Negev (where it deceases).</para>
    /// <para>Guns with proper alternative fire modes (burst fire, scope, detachable silencer, ...) should use <c>ClassicRecoveryTimeInaccuracyCalculation</c></para>
    /// </summary>
    public class TransitionableRecoveryTimeInaccuracyCalculation: IRecoveryTimeInaccuracyCalculation
    {
        private InaccuracyAnalysis Analysis { get; init; }
        private Weapon CurrentWeapon { get; init; }
        /// <summary>
        /// Whether the user is currently standing or crouching
        /// </summary>
        private bool IsStanding { get; init; }

        public TransitionableRecoveryTimeInaccuracyCalculation(Weapon w, bool isStanding = true)
        {
            this.Analysis = new InaccuracyAnalysis(w);
            this.CurrentWeapon = w;
            this.IsStanding = isStanding;
        }

        public float Calculate(float userCycleTime, int shotToBeFired)
        {
            /* 
             * Use similar algorithm to Classic, but only do the following: smoothly swap recovery times. Leave everythin as is, and then try again
             */
            if (userCycleTime < CurrentWeapon.Cycletime)
            {
                throw new ArgumentOutOfRangeException($"Cycletime of the user is too fast for the weapon! userCycleTime {userCycleTime}, {CurrentWeapon.Name}'s cycletime {CurrentWeapon.Cycletime}");
            }
            if (shotToBeFired < 1)
            {
                throw new ArgumentOutOfRangeException($"shotToBeFired must be > 0! (is {shotToBeFired}");
            }
            if(Analysis.InaccuracyTransitionPeriod <= 0)
            {
                throw new ArgumentException($"The inaccuracy transition period of the weapon {CurrentWeapon.Name} must not be <= 0! (is {CurrentWeapon.RecoveryTransitionEndBullet} - {CurrentWeapon.RecoveryTransitionStartBullet} = {Analysis.InaccuracyTransitionPeriod}");
            }
            
            float recoveryTimeStart, recoveryTimeEnd, initialInaccuracy;

            //set initial inaccuracy
            if (IsStanding)
            {
                initialInaccuracy = Analysis.StandingInaccuracy;
                recoveryTimeStart = CurrentWeapon.RecoveryTimeStand;
                recoveryTimeEnd = CurrentWeapon.RecoveryTimeStandFinal;
            }
            else
            {
                initialInaccuracy = Analysis.CrouchingInaccuracy;
                recoveryTimeStart = CurrentWeapon.RecoveryTimeCrouch;
                recoveryTimeEnd = CurrentWeapon.RecoveryTimeCrouchFinal;
            }
            
            float fireInaccuracy = 0.0f;
            float oldInaccuracy = 0.0f;
            

            //Calculate new inaccuracy
            for (int i = 1; i < shotToBeFired; i++)
            {
                float averageRecoveryTime = this.CalculateRecoveryTime(i, recoveryTimeStart, recoveryTimeEnd);

                fireInaccuracy =
                    new InaccuracyCalculations().CalculateExtraInaccuracyAfterTime(
                        CurrentWeapon.InaccuracyFire + oldInaccuracy, averageRecoveryTime,userCycleTime);
                oldInaccuracy = fireInaccuracy;

                Debug.WriteLineIf(i == shotToBeFired - 1, $"[{i+1}] recoveryTime {averageRecoveryTime} - new inaccuracy {fireInaccuracy - oldInaccuracy}");
            }
            //return fireInaccuracies.Sum() + initialInaccuracy;
            return fireInaccuracy + initialInaccuracy;
        }

        /// <summary>
        /// <para>Calculate recovery time to be used by.</para>
        /// <para>The calculation returns the following:
        /// <list type="bullet">
        /// <item>shotNr &lt;= CurrentWeapon.RecoveryTransitionStartBullet: recoveryTimeStart</item>
        /// <item>CurrentWeapon.RecoveryTransitionStartBullet &lt; shotNr &lt;= CurrentWeapon.RecoveryTransitionEndBullet: The average of recoveryTimeStart and recoveryTimeEnd</item>
        /// <item>CurrentWeapon.RecoveryTransitionEndBullet &lt; shotNr: recoveryTimeEnd</item>
        /// </list></para>
        /// </summary>
        /// <param name="shotNr">The number of the shot to be fired</param>
        /// <param name="recoveryTimeStart">The initial recovery time</param>
        /// <param name="recoveryTimeEnd">The recovery time after the transition happened</param>
        /// <returns></returns>
        private float CalculateRecoveryTime(int shotNr, float recoveryTimeStart, float recoveryTimeEnd)
        {
            /*
             * TODO Make this work for tap-firing
             * This algorithm only works in case of spraying. If you tap-fire, the recoil resets in such a way that
             * the recoveryTime never transitions; if you fire more quickly, the recoveryTime should transition later and
             * more slowly than if you sprayed with the gun.
             *
             * Proposal for a formula: 
             */

            float recoveryTimeStartShareAbsolute = Math.Max(CurrentWeapon.RecoveryTransitionEndBullet - shotNr, 0);
            float recoveryTimeStartShare = recoveryTimeStartShareAbsolute / Analysis.InaccuracyTransitionPeriod;
            recoveryTimeStartShare = Math.Min(recoveryTimeStartShare, 1);
            float recoveryTimeEndShare = 1 - recoveryTimeStartShare;

            float averageRecoveryTime = recoveryTimeEndShare * recoveryTimeEnd + recoveryTimeStartShare  * recoveryTimeStart;

            return averageRecoveryTime;
        }



    }
}

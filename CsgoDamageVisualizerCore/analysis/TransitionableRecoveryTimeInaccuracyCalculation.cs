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

            float firingInaccuracy;
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

            List<float> fireInaccuracies = new List<float>();

            //Calculate new inaccuracy
            for (int i = 1; i < shotToBeFired; i++)
            {
                float recoveryTimeStartShareAbsolute = Math.Max(CurrentWeapon.RecoveryTransitionEndBullet - i, 0);
                float recoveryTimeStartShare = recoveryTimeStartShareAbsolute / Analysis.InaccuracyTransitionPeriod;
                recoveryTimeStartShare = Math.Min(recoveryTimeStartShare, 1);
                float recoveryTimeEndShare = 1 - recoveryTimeStartShare;
                float averageRecoveryTime = recoveryTimeEndShare * recoveryTimeEnd + recoveryTimeStartShare * recoveryTimeStart;
                
                float timePassedSinceFiring = userCycleTime * (shotToBeFired - i);
                float newInaccuracy = new InaccuracyCalculations().CalculateExtraInaccuracyAfterTime(CurrentWeapon.InaccuracyFire, averageRecoveryTime, timePassedSinceFiring);
                firingInaccuracy = newInaccuracy;
                fireInaccuracies.Add(firingInaccuracy);
                
                Debug.WriteLineIf(i == shotToBeFired - 1, $"[{i+1}] recoveryTime share (start/end) {recoveryTimeEndShare}/{recoveryTimeStartShare} - recoveryTime {averageRecoveryTime} - new inaccuracy {newInaccuracy}");
            }
            return fireInaccuracies.Sum() + initialInaccuracy;
        }

        //public float Calculate(float userCycleTime, int shotToBeFired)
        //{
        //    /* 
        //     * Use similar algorithm to Classic, but only do the following: smoothly swap recovery times. Leave everythin as is, and then try again
        //     */
        //    if (userCycleTime < CurrentWeapon.Cycletime)
        //    {
        //        throw new ArgumentOutOfRangeException($"Cycletime of the user is too fast for the weapon! userCycleTime {userCycleTime}, {CurrentWeapon.Name}'s cycletime {CurrentWeapon.Cycletime}");
        //    }
        //    if (shotToBeFired < 1)
        //    {
        //        throw new ArgumentOutOfRangeException($"shotToBeFired must be > 0! (is {shotToBeFired}");
        //    }
        //    if (Analysis.InaccuracyTransitionPeriod <= 0)
        //    {
        //        throw new ArgumentException($"The inaccuracy transition period of the weapon {CurrentWeapon.Name} must not be <= 0! (is {CurrentWeapon.RecoveryTransitionEndBullet} - {CurrentWeapon.RecoveryTransitionStartBullet} = {Analysis.InaccuracyTransitionPeriod}");
        //    }

        //    float retVal, recoveryTimeStart, recoveryTimeEnd, initialInaccuracy;

        //    //set initial inaccuracy
        //    if (IsStanding)
        //    {
        //        initialInaccuracy = Analysis.StandingInaccuracy;
        //        recoveryTimeStart = CurrentWeapon.RecoveryTimeStand;
        //        recoveryTimeEnd = CurrentWeapon.RecoveryTimeStandFinal;
        //    }
        //    else
        //    {
        //        initialInaccuracy = Analysis.CrouchingInaccuracy;
        //        recoveryTimeStart = CurrentWeapon.RecoveryTimeCrouch;
        //        recoveryTimeEnd = CurrentWeapon.RecoveryTimeCrouchFinal;
        //    }

        //    retVal = 0.0f;

        //    //Calculate new inaccuracy
        //    for (int i = 1; i < shotToBeFired; i++)
        //    {
        //        float recoveryTimeStartShareAbsolute = Math.Max(CurrentWeapon.RecoveryTransitionEndBullet - i, 0);
        //        float recoveryTimeStartShare = recoveryTimeStartShareAbsolute / Analysis.InaccuracyTransitionPeriod;
        //        recoveryTimeStartShare = Math.Min(recoveryTimeStartShare, 1);
        //        float recoveryTimeEndShare = 1 - recoveryTimeStartShare;
        //        float averageRecoveryTime = recoveryTimeEndShare * recoveryTimeEnd + recoveryTimeStartShare * recoveryTimeStart;

        //        float timePassedSinceFiring = userCycleTime * i;
        //        float newInaccuracy = new InaccuracyCalculations().CalculateExtraInaccuracyAfterTime(retVal + CurrentWeapon.InaccuracyFire, averageRecoveryTime, timePassedSinceFiring);
        //        retVal += newInaccuracy;

        //        Debug.WriteLineIf(i == shotToBeFired - 1, $"  recoveryTime share (start/end) {recoveryTimeEndShare}/{recoveryTimeStartShare} - recoveryTime {averageRecoveryTime} - new inaccuracy {newInaccuracy}");
        //    }
        //    return retVal + initialInaccuracy;
        //}

    }
}

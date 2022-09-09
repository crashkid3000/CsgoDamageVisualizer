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

        public float Calculate(float userCycleTime, int shotsFired)
        {
            /* 
             * Use similar algorithm to Classic, but only do the following: smoothly swap recovery times. Leave everythin as is, and then try again
             */
            return float.NaN;
        }

        //public float Calculate(float userCycleTime, int shotsFired)
        //{
        //    float retVal = 0.0f;
        //    float recoveryTimeStart = IsStanding ? CurrentWeapon.RecoveryTimeStand : CurrentWeapon.RecoveryTimeCrouch;
        //    float recoveryTimeFinal = IsStanding ? CurrentWeapon.RecoveryTimeStandFinal : CurrentWeapon.RecoveryTimeCrouchFinal;
        //    InaccuracyCalculations calculations = new InaccuracyCalculations();
        //    for(int i = 0; i < shotsFired; i++)
        //    {
        //        float shareOfFinalRecoveryTime = 1 - ((Math.Max(i, Math.Max(CurrentWeapon.RecoveryTransitionStartBullet, 0)) - CurrentWeapon.RecoveryTransitionEndBullet) / (float)Analysis.InaccuracyTransitionPeriod);
        //        float shareOfInitialRecoveryTime = 1 - shareOfFinalRecoveryTime;
        //        float averagedRecoveryTime = (shareOfInitialRecoveryTime * recoveryTimeStart) + (shareOfFinalRecoveryTime * recoveryTimeFinal);
        //        float sprayFactor = GetBulletSprayFactor(userCycleTime, i + 1, averagedRecoveryTime);
        //        float inaccuracyOfShot = calculations.CalculateExtraInaccuracyAfterTime(CurrentWeapon.InaccuracyFire, averagedRecoveryTime, sprayFactor * userCycleTime);
        //        retVal += inaccuracyOfShot;
        //        Debug.WriteLine($"  Added inaccuracy: {inaccuracyOfShot}");
        //    }

        //    return retVal;
        //}

        ///// <summary>
        ///// Estimates how much spraying actually took place, considering the bullets fired and how quickly they were fired apart from each other. Assumption: shots fired with always the same delay after each other
        ///// </summary>
        ///// <param name="userCycletime"></param>
        ///// <returns></returns>
        //private float GetBulletSprayFactor(float userCycletime, int shotsFired, float recoveryTime)
        //{
        //    float retVal = 0.0f;
        //    for(int i = 0; i < shotsFired; i++)
        //    {
        //        float sprayFactor = Math.Min(CurrentWeapon.Cycletime / userCycletime, 1);
        //        float decayedSprayFactor = (float)Math.Pow(InaccuracyCalculations.InaccuracyDecayExponent, sprayFactor / recoveryTime);
        //        retVal += decayedSprayFactor;
        //    }
        //    return shotsFired * CurrentWeapon.Cycletime / userCycletime; //todo: Use Cycletime, RecoveryTime, a value inbetween?
        //}




    }
}

using CsgoDamageVisualizerCore.model;
using CsgoDamageVisualizerCore.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerCore.analysis
{
    public class ClassicRecoveryTimeInaccuracyCalculation: IRecoveryTimeInaccuracyCalculation
    {
        private InaccuracyAnalysis Analysis { get; init; }
        private Weapon CurrentWeapon { get; init; }
        /// <summary>
        /// What position (standing/crouching) and what fire mode (primary/secondary) is curently in use
        /// </summary>
        private StationaryInaccuracy Position { get; init; }

        public ClassicRecoveryTimeInaccuracyCalculation(Weapon w, StationaryInaccuracy position = StationaryInaccuracy.STANDING)
        {
            this.Analysis = new InaccuracyAnalysis(w);
            this.CurrentWeapon = w;
            this.Position = position;
        }



        public float Calculate(float userCycleTime, int shotToBeFired)
        {
            if(userCycleTime < CurrentWeapon.Cycletime)
            {
                throw new ArgumentOutOfRangeException($"Cycletime of the user is too fast for the weapon! userCycleTime {userCycleTime}, weapon's cycletime {CurrentWeapon.Cycletime}");
            }
            if(shotToBeFired < 1)
            {
                throw new ArgumentOutOfRangeException($"shotToBeFired must be > 0! (is {shotToBeFired}");
            }

            float retVal;
            
            //set initial inaccuracy
            switch (Position)
            {
                case StationaryInaccuracy.STANDING: retVal = Analysis.StandingInaccuracy; break;
                case StationaryInaccuracy.STANDING_ALT: retVal = Analysis.StandingInaccuracyAlt; break;
                case StationaryInaccuracy.CROUCHING: retVal = Analysis.CrouchingInaccuracy; break;
                case StationaryInaccuracy.CROUCHING_ALT: retVal = Analysis.CrouchingInaccuracyAlt; break;
                default: throw new NotImplementedException($"No switch has been implemented for StationaryInaccuracy {Position}");
            }
            
            float recoveryTime, fireInaccuracy;
            recoveryTime = Position.IsStanding() ? CurrentWeapon.RecoveryTimeStand : CurrentWeapon.RecoveryTimeCrouch; //determine applicable recovery time, depending on the users Position
            fireInaccuracy = Position.IsPrimaryFireMode() ? CurrentWeapon.InaccuracyFire : CurrentWeapon.InaccuracyFireAlt; //determine applicable fire inaccuracy "penalty", depending on the users active fire mode
            
            //Calculate new inaccuracy
            for(int i = 1; i < shotToBeFired; i++)
            {
                float timePassedSinceFiring = userCycleTime * i;
                float newInaccuracy = new InaccuracyCalculations().CalculateExtraInaccuracyAfterTime(fireInaccuracy, recoveryTime, timePassedSinceFiring);
                retVal += newInaccuracy;
            }
            return retVal;
        }
    }
}

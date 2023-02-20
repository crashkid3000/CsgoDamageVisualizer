using CsgoDamageVisualizerCore.model;
using CsgoDamageVisualizerCore.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerCore.analysis
{
    /// <summary>
    /// Class that deals with analyzing the inaccuracy of a gun.
    /// </summary>
    public class InaccuracyAnalysis
    {
        private Weapon weapon;

        public InaccuracyAnalysis(Weapon weapon)
        {
            this.weapon = weapon;
        }   

        public float StandingInaccuracy { get { return weapon.Spread + weapon.InaccuracyStand; } }
        public float StandingInaccuracyAlt { get { return weapon.ValueOrBackupValue(weapon.SpreadAlt, weapon.Spread) + weapon.ValueOrBackupValue(weapon.InaccuracyStandAlt, weapon.InaccuracyStand); } }

        public float CrouchingInaccuracy { get { return weapon.Spread + weapon.InaccuracyCrouch; } }
        public float CrouchingInaccuracyAlt { get { return weapon.ValueOrBackupValue(weapon.SpreadAlt, weapon.Spread) + weapon.ValueOrBackupValue(weapon.InaccuracyCrouchAlt, weapon.InaccuracyCrouch); } }

        public float LadderInaccuracy { get { return weapon.Spread + (2 * weapon.InaccuracyLadder); } }
        public float LadderInaccuracyAlt { get { return weapon.ValueOrBackupValue(weapon.SpreadAlt, weapon.Spread) + (2 * weapon.ValueOrBackupValue(weapon.InaccuracyLadderAlt, weapon.InaccuracyLadder)); } }

        public float MovementInaccuracy { get { return StandingInaccuracy + weapon.InaccuracyMove; } }
        public float MovementInaccuracyAlt { get { return StandingInaccuracyAlt + weapon.ValueOrBackupValue(weapon.InaccuracyMoveAlt, weapon.InaccuracyMove); } }

        public float JumpingInitialInaccuracy { get { return this.StandingInaccuracy + weapon.InaccuracyJump + weapon.ValueOrBackupValue(weapon.InaccuracyJumpInitial, 0.0f) ; } }
        public float JumpingInitialInaccuracyAlt { get { return weapon.ValueOrBackupValue(weapon.SpreadAlt, weapon.Spread)
                    + weapon.ValueOrBackupValue(weapon.InaccuracyJumpAlt, weapon.InaccuracyJump)
                    + weapon.ValueOrBackupValue(weapon.ValueOrBackupValue(weapon.InaccuracyJumpInitialAlt, 0.0f), weapon.ValueOrBackupValue(weapon.InaccuracyJumpInitial, 0.0f)); } }

        public float JumpingApexInaccuracy { get { return this.StandingInaccuracy + weapon.InaccuracyJump + weapon.ValueOrBackupValue(weapon.InaccuracyJumpApex, 0.0f); } }
        public float JumpingApexInaccuracyAlt
        {
            get
            {
                return this.StandingInaccuracyAlt
                    + weapon.ValueOrBackupValue(weapon.InaccuracyJumpAlt, weapon.InaccuracyJump)
                    + weapon.ValueOrBackupValue(weapon.ValueOrBackupValue(weapon.InaccuracyJumpApexAlt, weapon.InaccuracyJumpApex), 0.0f);
            }
        }

        /// <summary>
        /// <para>How many bullet it takes to transition from the primary to the secondary</para><para><u>Unit:</u> 1 (bullets)</para>
        /// </summary>
        public int InaccuracyTransitionPeriod { get
            {
                if (weapon.RecoveryTransitionEndBullet != Weapon.NOT_FILLED_INT) { 
                    return weapon.RecoveryTransitionEndBullet - Math.Max(weapon.RecoveryTransitionStartBullet, 0);
                }
                else
                {
                    return Weapon.NOT_FILLED_INT;
                }
            } }

        [Obsolete($"will be replaced by implementations of {nameof(IRecoveryTimeInaccuracyCalculation)}")]
        public float CalculateInaccuracyAfterShotsFired(int shots, StationaryInaccuracy position=StationaryInaccuracy.STANDING, float timeBetweenShots = 0.0f)
        {
            timeBetweenShots = Math.Max(weapon.Cycletime, timeBetweenShots);

            for(int i = 0; i < shots; i++)
            {

            }

            return 0.0f;

        }

        [Obsolete($"will be replaced by implementations of {nameof(IRecoveryTimeInaccuracyCalculation)}")]
        private float CalculateInaccuracyAfterShotsFired(int shotsRemaining, int shotsTotal, float cycleTime, float weaponFireInaccuracy, float weaponRecoveryTime, StationaryInaccuracy position)
        {
            if (shotsRemaining == 0)
            {
                switch (position)
                {
                    case StationaryInaccuracy.STANDING: { return this.StandingInaccuracy; }
                    case StationaryInaccuracy.STANDING_ALT: { return this.StandingInaccuracyAlt; }
                    case StationaryInaccuracy.CROUCHING: { return this.CrouchingInaccuracy; }
                    case StationaryInaccuracy.CROUCHING_ALT: { return this.CrouchingInaccuracyAlt; }
                    default: { throw new NotImplementedException($"Switch for position {position} has yet to be implemented!"); }
                }
            }
            else
            {
                float recoveryTime;
                if(weapon.RecoveryTransitionEndBullet != Weapon.NOT_FILLED_INT) //if recovery time changed while firing -- weapon.RecoveryTransitionStartBullet is not always filled
                {
                    int weaponRecoveryTranstitionStartBullet = Math.Max(weapon.RecoveryTransitionStartBullet, 0);
                    int distanceFromStart = Math.Min(Math.Max(0, shotsTotal - shotsRemaining - weaponRecoveryTranstitionStartBullet), this.InaccuracyTransitionPeriod);
                    int distanceToFinish = Math.Min(Math.Max(0, shotsTotal - shotsRemaining - weapon.RecoveryTransitionEndBullet), this.InaccuracyTransitionPeriod);
                    if(position == StationaryInaccuracy.STANDING || position == StationaryInaccuracy.STANDING_ALT)
                    {
                        recoveryTime = (weapon.RecoveryTimeStand * distanceFromStart / this.InaccuracyTransitionPeriod) + (weapon.RecoveryTimeStandFinal * distanceToFinish / this.InaccuracyTransitionPeriod);
                    }
                }
                return new InaccuracyCalculations().CalculateExtraInaccuracyAfterTime(weaponFireInaccuracy, weaponRecoveryTime, cycleTime * shotsRemaining) + CalculateInaccuracyAfterShotsFired(shotsRemaining - 1, shotsTotal, cycleTime, weaponFireInaccuracy, weaponRecoveryTime, position);
            }
            
            
    }
    }
}

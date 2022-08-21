using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerCore.model
{
    public class Weapon
    {
        private string name;
        private string prefab;
        private string item_class;
        private bool terrorists;
        private bool counter_terrorists;
        private float heatPerShot;
        private float addonScale;
        private int tracerFrequency;
        private int tracerFrequencyAlt;
        private int primaryClipSize;
        private int primaryDefaultClipSize;
        private int secondaryDefaultClipSize;
        private bool isFullAuto;
        private int maxPlayerSpeed;
        private int inGamePrice;
        private float armorRatio;
        private int crosshairMinDistance;
        private int crosshairDeltaDistalce;
        private float cycletime;
        private float penetration;
        private int damage;
        private float headshotMultiplier;
        private int range;
        private float rangeModifier;
        private int bullets;
        private float flinchVelocityMultiplierLarge;
        private float flinchVelocityMultiplierSmall;
        private float spread;
        private float inaccuracyCrouch;
        private float inaccuracyStand;
        private float inaccuracyJumpInitial;
        private float inaccuracyJumpApex;
        private float inaccuracyJump;
        private float inaccuracyLand;
        private float inaccuracyLadder;
        private float inaccuracyFire;
        private float inaccuracyMove;
        private float recoveryTimeCrouch;
        private float recoveryTimeStand;
        private float recoilAngle;
        private float recoilAngleVariance;
        private float recoilMagnitude;
        private float recoilMagnitudeVariance;
        private int recoilSeed;
        private int primaryReserveAmmoMax;
        private float spreadAlt;
        private float inaccuracyCrouchAlt;
        private float inaccuracyStandAlt;
        private float inaccuracyJumpInitialAlt;
        private float inaccuracyJumpApexAlt;
        private float inaccuracyJumpAlt;
        private float inaccuracyLandAlt;
        private float inaccuracyLadderAlt;
        private float inaccuracyFireAlt;
        private float inaccuracyMoveAlt;
        private float inaccuracyAltSoundThreshold;
        private float recoveryTimeCrouchAlt;
        private float recoveryTimeStandAlt;
        private float recoilAngleAlt;
        private float recoilAngleVarianceAlt;
        private float recoilMagnitudeAlt;
        private float recoilMagnitudeVarianceAlt;
        private int recoveryTransitionStartBullet;
        private int recoveryTransitionEndBullet;
        private bool hasBurstFire;
        private float burstCycleTime;
        private float burstPauseTime;
        private bool hasDetachableSilencer;
        private bool isRevolver;

    }
}

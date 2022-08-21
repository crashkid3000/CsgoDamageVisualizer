using CsgoDamageVisualizerCore.loader.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerCore.model
{
    /// <summary>
    /// The stats of a weapon. Note that not every value needs to be filled.
    /// </summary>
    public class Weapon
    {
        public Weapon() { }

        public Weapon(CfgWeapon model) { 
            
        }

        public Weapon(CfgWeapon model, CfgWeapon prefab)
        {

        }

        #region fields

        private static readonly int NOT_FILLED_INT = -483792;
        private static readonly float NOT_FILLED_FLOAT = -425233.9f;

        private string name = "";
        private string prefab = "";
        private string item_class = "";
        private bool terrorists = false;
        private bool counter_terrorists = false;
        private float heatPerShot = NOT_FILLED_FLOAT;
        private float addonScale = NOT_FILLED_FLOAT;
        private int tracerFrequency = NOT_FILLED_INT;
        private int tracerFrequencyAlt = NOT_FILLED_INT;
        private int primaryClipSize = NOT_FILLED_INT;
        private int primaryDefaultClipSize = NOT_FILLED_INT;
        private int secondaryDefaultClipSize = NOT_FILLED_INT;
        private bool isFullAuto = false ;
        private int maxPlayerSpeed = NOT_FILLED_INT;
        private int inGamePrice = NOT_FILLED_INT;
        private float armorRatio = NOT_FILLED_FLOAT;
        private int crosshairMinDistance = NOT_FILLED_INT;
        private int crosshairDeltaDistalce = NOT_FILLED_INT;
        private float cycletime = NOT_FILLED_FLOAT;
        private float penetration = NOT_FILLED_FLOAT;
        private int damage = NOT_FILLED_INT;
        private float headshotMultiplier = NOT_FILLED_FLOAT;
        private int range = NOT_FILLED_INT;
        private float rangeModifier = NOT_FILLED_FLOAT;
        private int bullets = NOT_FILLED_INT;
        private float flinchVelocityMultiplierLarge = NOT_FILLED_FLOAT;
        private float flinchVelocityMultiplierSmall = NOT_FILLED_FLOAT;
        private float spread = NOT_FILLED_FLOAT;
        private float inaccuracyCrouch = NOT_FILLED_FLOAT;
        private float inaccuracyStand = NOT_FILLED_FLOAT;
        private float inaccuracyJumpInitial = NOT_FILLED_FLOAT;
        private float inaccuracyJumpApex = NOT_FILLED_FLOAT;
        private float inaccuracyJump = NOT_FILLED_FLOAT;
        private float inaccuracyLand = NOT_FILLED_FLOAT;
        private float inaccuracyLadder = NOT_FILLED_FLOAT;
        private float inaccuracyFire = NOT_FILLED_FLOAT;
        private float inaccuracyMove = NOT_FILLED_FLOAT;
        private float recoveryTimeCrouch = NOT_FILLED_FLOAT;
        private float recoveryTimeStand = NOT_FILLED_FLOAT;
        private float recoilAngle = NOT_FILLED_FLOAT;
        private float recoilAngleVariance = NOT_FILLED_FLOAT;
        private float recoilMagnitude = NOT_FILLED_FLOAT;
        private float recoilMagnitudeVariance = NOT_FILLED_FLOAT;
        private int recoilSeed = NOT_FILLED_INT;
        private int primaryReserveAmmoMax = NOT_FILLED_INT;
        private float spreadAlt = NOT_FILLED_FLOAT;
        private float inaccuracyCrouchAlt = NOT_FILLED_FLOAT;
        private float inaccuracyStandAlt = NOT_FILLED_FLOAT;
        private float inaccuracyJumpInitialAlt = NOT_FILLED_FLOAT;
        private float inaccuracyJumpApexAlt = NOT_FILLED_FLOAT;
        private float inaccuracyJumpAlt = NOT_FILLED_FLOAT;
        private float inaccuracyLandAlt = NOT_FILLED_FLOAT;
        private float inaccuracyLadderAlt = NOT_FILLED_FLOAT;
        private float inaccuracyFireAlt = NOT_FILLED_FLOAT;
        private float inaccuracyMoveAlt = NOT_FILLED_FLOAT;
        private float inaccuracyAltSoundThreshold = NOT_FILLED_FLOAT;
        private float recoveryTimeCrouchAlt = NOT_FILLED_FLOAT;
        private float recoveryTimeStandAlt = NOT_FILLED_FLOAT;
        private float recoilAngleAlt = NOT_FILLED_FLOAT;
        private float recoilAngleVarianceAlt = NOT_FILLED_FLOAT;
        private float recoilMagnitudeAlt = NOT_FILLED_FLOAT;
        private float recoilMagnitudeVarianceAlt = NOT_FILLED_FLOAT;
        private int recoveryTransitionStartBullet = NOT_FILLED_INT;
        private int recoveryTransitionEndBullet = NOT_FILLED_INT;
        private bool hasBurstFire = false;
        private float burstCycleTime = NOT_FILLED_FLOAT;
        private float burstPauseTime = NOT_FILLED_FLOAT;
        private bool hasDetachableSilencer = false;
        private bool isRevolver = false;

        #endregion fields

        #region base properties

        public string Name { get { return name; } init { if (name == "") { name = value; } else { Console.WriteLine($"Variable {nameof(Weapon)}.{nameof(Name)} alrady has a value assigned to it!"); } } }
        public string Prefab { get { return prefab; } init { if (prefab == "") { prefab = value; } else { Console.WriteLine($"Variable {nameof(Weapon)}.{nameof(Prefab)} alrady has a value assigned to it!"); } } }
        public string ItemClass { get { return item_class; } init { if (item_class == "") { item_class = value; } else { Console.WriteLine($"Variable {nameof(Weapon)}.{nameof(ItemClass)} alrady has a value assigned to it!"); } } }
        public bool Terrorists { get { return terrorists; } init { terrorists = value; } }
        public bool CounterTerrorists { get { return counter_terrorists; } init { counter_terrorists = value; } }
        public float HeatPerShot { get { return heatPerShot; } init { heatPerShot = value; } }
        public float AddonScale { get { return addonScale; } init { addonScale = value; } }
        public int TracerFrequency { get { return tracerFrequency; } init { tracerFrequency = value; } }
        public int TracerFrequencyAlt { get { return tracerFrequencyAlt; } init { tracerFrequencyAlt = value; } }
        public int PrimaryClipSize { get { return primaryClipSize; } init { primaryClipSize = value; } }
        public int PrimaryDefaultClipSize { get { return primaryDefaultClipSize; } init { primaryDefaultClipSize = value; } }
        public int SecondaryDefaultClipSize { get { return secondaryDefaultClipSize; } init { secondaryDefaultClipSize = value; } }
        public bool IsFullAuto { get { return isFullAuto; } init { isFullAuto = value; } }
        public int MaxPlayerSpeed { get { return maxPlayerSpeed; } init { maxPlayerSpeed = value; } }
        public int InGamePrice { get { return inGamePrice; } init { inGamePrice = value; } }
        public float ArmorRatio { get { return armorRatio; } init { armorRatio = value; } }
        public int CrosshairMinDistance { get { return crosshairMinDistance; } init { crosshairMinDistance = value; } }
        public int CrosshairDeltaDistalce { get { return crosshairDeltaDistalce; } init { crosshairDeltaDistalce = value; } }
        public float Cycletime { get { return cycletime; } init { cycletime = value; } }
        public float Penetration { get { return penetration; } init { penetration = value; } }
        public int Damage { get { return damage; } init { damage = value; } }
        public float HeadshotMultiplier { get { return headshotMultiplier; } init { headshotMultiplier = value; } }
        public int Range { get { return range; } init { range = value; } }
        public float RangeModifier { get { return rangeModifier; } init { rangeModifier = value; } }
        public int Bullets { get { return bullets; } init { bullets = value; } }
        public float FlinchVelocityMultiplierLarge { get { return flinchVelocityMultiplierLarge; } init { flinchVelocityMultiplierLarge = value; } }
        public float FlinchVelocityMultiplierSmall { get { return flinchVelocityMultiplierSmall; } init { flinchVelocityMultiplierSmall = value; } }
        public float Spread { get { return spread; } init { spread = value; } }
        public float InaccuracyCrouch { get { return inaccuracyCrouch; } init { inaccuracyCrouch = value; } }
        public float InaccuracyStand { get { return inaccuracyStand; } init { inaccuracyStand = value; } }
        public float InaccuracyJumpInitial { get { return inaccuracyJumpInitial; } init { inaccuracyJumpInitial = value; } }
        public float InaccuracyJumpApex { get { return inaccuracyJumpApex; } init { inaccuracyJumpApex = value; } }
        public float InaccuracyJump { get { return inaccuracyJump; } init { inaccuracyJump = value; } }
        public float InaccuracyLand { get { return inaccuracyLand; } init { inaccuracyLand = value; } }
        public float InaccuracyLadder { get { return inaccuracyLadder; } init { inaccuracyLadder = value; } }
        public float InaccuracyFire { get { return inaccuracyFire; } init { inaccuracyFire = value; } }
        public float InaccuracyMove { get { return inaccuracyMove; } init { inaccuracyMove = value; } }
        public float RecoveryTimeCrouch { get { return recoveryTimeCrouch; } init { recoveryTimeCrouch = value; } }
        public float RecoveryTimeStand { get { return recoveryTimeStand; } init { recoveryTimeStand = value; } }
        public float RecoilAngle { get { return recoilAngle; } init { recoilAngle = value; } }
        public float RecoilAngleVariance { get { return recoilAngleVariance; } init { recoilAngleVariance = value; } }
        public float RecoilMagnitude { get { return recoilMagnitude; } init { recoilMagnitude = value; } }
        public float RecoilMagnitudeVariance { get { return recoilMagnitudeVariance; } init { recoilMagnitudeVariance = value; } }
        public int RecoilSeed { get { return recoilSeed; } init { recoilSeed = value; } }
        public int PrimaryReserveAmmoMax { get { return primaryReserveAmmoMax; } init { primaryReserveAmmoMax = value; } }
        public float SpreadAlt { get { return spreadAlt; } init { spreadAlt = value; } }
        public float InaccuracyCrouchAlt { get { return inaccuracyCrouchAlt; } init { inaccuracyCrouchAlt = value; } }
        public float InaccuracyStandAlt { get { return inaccuracyStandAlt; } init { inaccuracyStandAlt = value; } }
        public float InaccuracyJumpInitialAlt { get { return inaccuracyJumpInitialAlt; } init { inaccuracyJumpInitialAlt = value; } }
        public float InaccuracyJumpApexAlt { get { return inaccuracyJumpApexAlt; } init { inaccuracyJumpApexAlt = value; } }
        public float InaccuracyJumpAlt { get { return inaccuracyJumpAlt; } init { inaccuracyJumpAlt = value; } }
        public float InaccuracyLandAlt { get { return inaccuracyLandAlt; } init { inaccuracyLandAlt = value; } }
        public float InaccuracyLadderAlt { get { return inaccuracyLadderAlt; } init { inaccuracyLadderAlt = value; } }
        public float InaccuracyFireAlt { get { return inaccuracyFireAlt; } init { inaccuracyFireAlt = value; } }
        public float InaccuracyMoveAlt { get { return inaccuracyMoveAlt; } init { inaccuracyMoveAlt = value; } }
        public float InaccuracyAltSoundThreshold { get { return inaccuracyAltSoundThreshold; } init { inaccuracyAltSoundThreshold = value; } }
        public float RecoveryTimeCrouchAlt { get { return recoveryTimeCrouchAlt; } init { recoveryTimeCrouchAlt = value; } }
        public float RecoveryTimeStandAlt { get { return recoveryTimeStandAlt; } init { recoveryTimeStandAlt = value; } }
        public float RecoilAngleAlt { get { return recoilAngleAlt; } init { recoilAngleAlt = value; } }
        public float RecoilAngleVarianceAlt { get { return recoilAngleVarianceAlt; } init { recoilAngleVarianceAlt = value; } }
        public float RecoilMagnitudeAlt { get { return recoilMagnitudeAlt; } init { recoilMagnitudeAlt = value; } }
        public float RecoilMagnitudeVarianceAlt { get { return recoilMagnitudeVarianceAlt; } init { recoilMagnitudeVarianceAlt = value; } }
        public int RecoveryTransitionStartBullet { get { return recoveryTransitionStartBullet; } init { recoveryTransitionStartBullet = value; } }
        public int RecoveryTransitionEndBullet { get { return recoveryTransitionEndBullet; } init { recoveryTransitionEndBullet = value; } }
        public bool HasBurstFire { get { return hasBurstFire; } init { hasBurstFire = value; } }
        public float BurstCycleTime { get { return burstCycleTime; } init { burstCycleTime = value; } }
        public float BurstPauseTime { get { return burstPauseTime; } init { burstPauseTime = value; } }
        public bool HasDetachableSilencer { get { return hasDetachableSilencer; } init { hasDetachableSilencer = value; } }
        public bool IsRevolver { get { return isRevolver; } init { isRevolver = value; } }

        #endregion base properties

        #region expanded properties

        #endregion expanded properties

    }
}

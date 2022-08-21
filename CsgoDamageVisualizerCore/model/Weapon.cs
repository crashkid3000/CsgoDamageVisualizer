using CsgoDamageVisualizerCore.loader.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerCore.model
{
    /// <summary>
    /// <para>The stats of a weapon. Note that not every value needs to be filled.</para>
    /// <para><u>Regarding "units"</u>: With entities in Source (incl. the player), they use so-called "units" to measure stuff. 1 unit = 1 inch ~= 2.54 cm</para>
    /// <para><u>Regarding "ia"</u>: I call them "inaccuracy units". I don't exactly know what they represent yet, but they can be added to each other. Also, the formula to convert a value to the "effective range" is 152.4 [mm]/x [ia]=range [m]</para>
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
        private int mayPlayerSpeedAlt = NOT_FILLED_INT;
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
        private float inaccuracyPitchShift = NOT_FILLED_FLOAT;
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
        /// <summary>
        /// The internal name of the weapon, usualy starting with "weapon_"
        /// </summary>
        public string Name { get { return name; } init { if (name == "") { name = value; } else { Console.WriteLine($"Variable {nameof(Weapon)}.{nameof(Name)} alrady has a value assigned to it!"); } } }
        /// <summary>
        /// The type of the weapon (secondary, machinegun etc). Only important for bots, mission design (e.g. kill X people with a <i>machinegun</i>), etc. and does not effect the player directly.
        /// </summary>
        public string Prefab { get { return prefab; } init { if (prefab == "") { prefab = value; } else { Console.WriteLine($"Variable {nameof(Weapon)}.{nameof(Prefab)} alrady has a value assigned to it!"); } } }
        /// <summary>
        /// The base class for this weapon model. While this is be irrelevant for most weapons, for (alternative) guns being able to be swapped out in the loadout system, this means that they usually inherit some stats from their "base model" and only overwrite what's necessary
        /// </summary>
        public string ItemClass { get { return item_class; } init { if (item_class == "") { item_class = value; } else { Console.WriteLine($"Variable {nameof(Weapon)}.{nameof(ItemClass)} alrady has a value assigned to it!"); } } }
        /// <summary>
        /// If the weapon is available to the T side
        /// </summary>
        public bool Terrorists { get { return terrorists; } init { terrorists = value; } }
        /// <summary>
        /// If the weapon is available to the CTs
        /// </summary>
        public bool CounterTerrorists { get { return counter_terrorists; } init { counter_terrorists = value; } }
        /// <summary>
        /// (Assumption) Defines how much muzzle smoke there is after firing
        /// </summary>
        public float HeatPerShot { get { return heatPerShot; } init { heatPerShot = value; } }
        /// <summary>
        /// (Unknown)
        /// </summary>
        public float AddonScale { get { return addonScale; } init { addonScale = value; } }
        /// <summary>
        /// <para>How frequently tracers are fired in the <i>primary</i> fire mode. If no secondary value is defined, the game will use this value for the secondary fire mode. 0 = no tracers.</para> <para>Unit: 1 (every <i>n</i>-th bullet)</para> 
        /// </summary>
        public int TracerFrequency { get { return tracerFrequency; } init { tracerFrequency = value; } }
        /// <summary>
        /// <para>How frequently tracers are fired in the <i>secondary</i> fire mode. If not defined, the game will use the value from the primary fire mode. 0 = no tracers.</para>Unit: 1 (every <i>n</i>-th bullet)<para></para> 
        /// </summary>
        public int TracerFrequencyAlt { get { return tracerFrequencyAlt; } init { tracerFrequencyAlt = value; } }
        /// <summary>
        /// <para>The size of a magazine/clip.</para> <para>Unit: 1 (<i>n</i> bullets)</para>
        /// </summary>
        public int PrimaryClipSize { get { return primaryClipSize; } init { primaryClipSize = value; } }
        /// <summary>
        /// (Unknown)
        /// </summary>
        public int PrimaryDefaultClipSize { get { return primaryDefaultClipSize; } init { primaryDefaultClipSize = value; } }
        /// <summary>
        /// (Unknown)
        /// </summary>
        public int SecondaryDefaultClipSize { get { return secondaryDefaultClipSize; } init { secondaryDefaultClipSize = value; } }
        /// <summary>
        /// If the fire button (left mouse button) is held, the gun will fire another bullet (true) or not (false)
        /// </summary>
        public bool IsFullAuto { get { return isFullAuto; } init { isFullAuto = value; } }
        /// <summary>
        /// <para>The maximum speed the player can move with the weapon in the <i>primary</i> fire mode. If no secondary value is defined, the game will use this value for the secondary fire mode. For reference: With a knife, the player moves at 250 u/s.</para> <para>Unit: units per second (u/s)</para>
        /// </summary>
        public int MaxPlayerSpeed { get { return maxPlayerSpeed; } init { maxPlayerSpeed = value; } }
        /// <summary>
        /// <para>The maximum speed the player can move with the weapon in the <i>secondary</i> fire mode. If not defined, the game will use the value from the primary fire mode. For reference: With a knife, the player moves at 250 u/s.</para> <para>Unit: units per second (u/s)</para> 
        /// </summary>
        public int MaxPlayerSpeedAlt { get { return mayPlayerSpeedAlt; } init { mayPlayerSpeedAlt = value; } }
        /// <summary>
        /// <para>The price of the weapon.</para><para>Unit: 1$ (US-Dollar)</para>
        /// </summary>
        public int InGamePrice { get { return inGamePrice; } init { inGamePrice = value; } }
        /// <summary>
        /// <para>The <i>double</i> of the armor penetration, stored as a multiplier.</para><para>Unit: 2</para>
        /// </summary>
        public float ArmorRatio { get { return armorRatio; } init { armorRatio = value; } }
        /// <summary>
        /// <para>For dynamic crosshairs: The minimum gap for the crosshair.</para><para>Unit: unknown</para>
        /// </summary>
        public int CrosshairMinDistance { get { return crosshairMinDistance; } init { crosshairMinDistance = value; } }
        /// <summary>
        /// <para>For dynamic crosshairs: How much the crosshair can open.</para><para>Unit: unknown</para>
        /// </summary>
        public int CrosshairDeltaDistalce { get { return crosshairDeltaDistalce; } init { crosshairDeltaDistalce = value; } }
        /// <summary>
        /// <para>The time delay between each bullet.</para><para>Unit: s</para>
        /// </summary>
        public float Cycletime { get { return cycletime; } init { cycletime = value; } }
        /// <summary>
        /// <para>A measurement for how well you can wallbang with the weapon.</para><para>Unit: unknown; but only values between 0.0-3.0 make a noticable difference</para>
        /// </summary>
        public float Penetration { get { return penetration; } init { penetration = value; } }
        /// <summary>
        /// <para>The raw damage dealt by the weapon, per bullet/pellet</para><para>Unit: 1HP (health point)</para>
        /// </summary>
        public int Damage { get { return damage; } init { damage = value; } }
        /// <summary>
        /// <para>A multiplier for how much more damage a headshot deals. Default is 4.0.</para><para>Unit: 1</para>
        /// </summary>
        public float HeadshotMultiplier { get { return headshotMultiplier; } init { headshotMultiplier = value; } }
        /// <summary>
        /// <para>The range wt which the bullet magically disappears at the latest.</para><para>Unit: unit</para>
        /// </summary>
        public int Range { get { return range; } init { range = value; } }
        /// <summary>
        /// <para>A multiplier describing much damage the bullet retains after 500 units.</para><para>Unit: 1</para>
        /// </summary>
        public float RangeModifier { get { return rangeModifier; } init { rangeModifier = value; } }
        /// <summary>
        /// <para>How many bullets/pellets are fired with each shot.</para><para>Unit: 1 (<i>n</i> bullets/pellets fired from one cartridge)</para>
        /// </summary>
        public int Bullets { get { return bullets; } init { bullets = value; } }
        /// <summary>
        /// <para>How much speed is retained after being hit anywhere (=tagging). This is a multiplier.</para><para>Unit: 1</para>
        /// </summary>
        public float FlinchVelocityMultiplierLarge { get { return flinchVelocityMultiplierLarge; } init { flinchVelocityMultiplierLarge = value; } }
        /// <summary>
        /// <para>(Assumption) How much speed is retained after being hit on the legs, but this is unconfirmed, so it may be a useless value after all. This is a multiplier.</para><para>Unit: 1</para>
        /// </summary>
        public float FlinchVelocityMultiplierSmall { get { return flinchVelocityMultiplierSmall; } init { flinchVelocityMultiplierSmall = value; } }
        /// <summary>
        /// <para>The base spread of the weapon in the <i>primary</i> fire mode. Note that the bullet density is skewed towards the center with this one, unlike other inaccuracy values. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
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
        public float InaccuracyPitchShift { get { return inaccuracyPitchShift; } init { inaccuracyPitchShift = value; } }
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

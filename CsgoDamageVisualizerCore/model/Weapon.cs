using CsgoDamageVisualizerCore.loader.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private int maxPlayerSpeedAlt = NOT_FILLED_INT;
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
        private float recoveryTimeCrouchFinal = NOT_FILLED_FLOAT;
        private float recoveryTimeStandFinal = NOT_FILLED_FLOAT;
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
        private bool aimsightCapable = false;
        private int aimsightFov = NOT_FILLED_INT;
        private int zoomLevels = NOT_FILLED_INT;
        private int zoomFov1 = NOT_FILLED_INT;
        private int zoomFov2 = NOT_FILLED_INT;
        private int killAward = NOT_FILLED_INT;

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
        public bool IsTerroristsBuyable { get { return terrorists; } init { terrorists = value; } }
        
        /// <summary>
        /// If the weapon is available to the CTs
        /// </summary>
        public bool IsCounterTerroristsBuyable { get { return counter_terrorists; } init { counter_terrorists = value; } }
        
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
        public int MaxPlayerSpeedAlt { get { return maxPlayerSpeedAlt; } init { maxPlayerSpeedAlt = value; } }
        
        /// <summary>
        /// <para>The price of the weapon.</para><para>Unit: $1 (US-Dollar)</para>
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
        public float HeadshotMultiplier { get { if (headshotMultiplier == NOT_FILLED_INT) { return 4.0f; } else { return headshotMultiplier; } } init { headshotMultiplier = value; } }
        
        /// <summary>
        /// <para>The range at which the bullet magically disappears at the latest.</para><para>Unit: unit</para>
        /// </summary>
        public int Range { get { return range; } init { range = value; } }
        
        /// <summary>
        /// <para>A multiplier describing much damage the bullet retains after 500 units.</para><para>Unit: 1</para>
        /// </summary>
        public float RangeModifier { get { return rangeModifier; } init { rangeModifier = value; } }
        
        /// <summary>
        /// <para>How many bullets/pellets are fired with each shot.</para><para>Unit: 1 (<i>n</i> bullets/pellets fired from one cartridge)</para>
        /// </summary>
        public int Bullets { get { if (bullets == NOT_FILLED_INT) { return 1; } else { return bullets; } } init { bullets = value; } }
        
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
        
        /// <summary>
        /// <para>The inaccuracy gained by crouching in the <i>primary</i> fire mode. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        public float InaccuracyCrouch { get { return inaccuracyCrouch; } init { inaccuracyCrouch = value; } }
        
        /// <summary>
        /// <para>The inaccuracy gained by standing in the <i>primary</i> fire mode. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        public float InaccuracyStand { get { return inaccuracyStand; } init { inaccuracyStand = value; } }
        
        /// <summary>
        /// <para>The additional inaccuracy gained by rising/falling in the <i>primary</i> fire mode. As it is tied to the vertical velocity, it is euqally as high as instantly after jumping as well as just before landing if jumping on a level plane. Additionally, the actual inaccuracy will exceed the specified value if the player if falling onto a lower plane due to the increased velocity. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        public float InaccuracyJumpInitial { get { return inaccuracyJumpInitial; } init { inaccuracyJumpInitial = value; } }
        
        /// <summary>
        /// <para>The inaccuracy set at the hightest point of the jump in the <i>primary</i> fire mode. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        public float InaccuracyJumpApex { get { return inaccuracyJumpApex; } init { inaccuracyJumpApex = value; } }
        
        /// <summary>
        /// <para>The additional inaccuracy gained by jumping in the <i>primary</i> fire mode. If the player jumps, then this value is added to the <c cref="InaccuracyJumpInitial">InaccuracyJumpInitial</c> for the total jumping inaccuracy. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        public float InaccuracyJump { get { return inaccuracyJump; } init { inaccuracyJump = value; } }
        
        /// <summary>
        /// <para>Additional inaccuracy gained immediately upon landing in the <i>primary</i> fire mode. Deprecated for all weapons as of 2016, afaik. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        public float InaccuracyLand { get { return inaccuracyLand; } init { inaccuracyLand = value; } }
        
        /// <summary>
        /// <para>Inaccuracy gained by being on a ladder in the <i>primary</i> fire mode. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        public float InaccuracyLadder { get { return inaccuracyLadder; } init { inaccuracyLadder = value; } }
        
        /// <summary>
        /// <para>Additional inaccuracy gained by firing a single shot in the <i>primary</i> fire mode. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        public float InaccuracyFire { get { return inaccuracyFire; } init { inaccuracyFire = value; } }
        
        /// <summary>
        /// <para>Inaccuracy gained by (horizontal/non-jumping, non-ladder) movement of the player. Is dependant on the players movement speed. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        public float InaccuracyMove { get { return inaccuracyMove; } init { inaccuracyMove = value; } }
        
        /// <summary>
        /// The time it takes for 90% of the <i>additional</i> inaccuracy to decay while crouching.</para><para>Unit: 1 s</para>
        /// </summary>
        public float RecoveryTimeCrouch { get { return recoveryTimeCrouch; } init { recoveryTimeCrouch = value; } }
        
        /// <summary>
        /// The time it takes for 90% of the <i>additional</i> inaccuracy to decay while standing.</para><para>Unit: 1 s</para>
        /// </summary>
        public float RecoveryTimeStand { get { return recoveryTimeStand; } init { recoveryTimeStand = value; } }
        
        /// <summary>
        /// <para>The initial rotation of the spray pattern in the <i>primary</i> fire mode. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1° (fka 1 deg)</para>
        /// </summary>
        public float RecoilAngle { get { return recoilAngle; } init { recoilAngle = value; } }
        
        /// <summary>
        /// <para>The width of the spray pattern, represented as the opening angle of a circular sector, in the <i>primary</i> fire mode. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1° (fka 1 deg)</para>
        /// </summary>
        public float RecoilAngleVariance { get { return recoilAngleVariance; } init { recoilAngleVariance = value; } }
        
        /// <summary>
        /// <para>The height of the spray pattern in the <i>primary</i> fire mode. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: unknown</para>
        /// </summary>
        public float RecoilMagnitude { get { return recoilMagnitude; } init { recoilMagnitude = value; } }
        
        /// <summary>
        /// <para>The variance within the height of the spray pattern in the <i>primary</i> fire mode. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: unknown</para>
        /// </summary>
        public float RecoilMagnitudeVariance { get { return recoilMagnitudeVariance; } init { recoilMagnitudeVariance = value; } }
        
        /// <summary>
        /// <para>The seed that generates the recoil pattern.</para><para>Unit: n/A</para>
        /// </summary>
        public int RecoilSeed { get { return recoilSeed; } init { recoilSeed = value; } }
        
        /// <summary>
        /// <para>The (maximum) ammount of extra bullets carried around.</para><para>Unit: 1 (bullet)</para>
        /// </summary>
        public int PrimaryReserveAmmoMax { get { return primaryReserveAmmoMax; } init { primaryReserveAmmoMax = value; } }
        
        /// <summary>
        /// <para>The base spread of the weapon in the <i>secondary</i> fire mode. Note that the bullet density is skewed towards the center with this one, unlike other inaccuracy values. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        public float SpreadAlt { get { return spreadAlt; } init { spreadAlt = value; } }
        
        /// <summary>
        /// <para>The inaccuracy gained by crouching in the <i>secondary</i> fire mode. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        public float InaccuracyCrouchAlt { get { return inaccuracyCrouchAlt; } init { inaccuracyCrouchAlt = value; } }
        
        /// <summary>
        /// <para>The inaccuracy gained by standing in the <i>secondary</i> fire mode. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        public float InaccuracyStandAlt { get { return inaccuracyStandAlt; } init { inaccuracyStandAlt = value; } }
        
        /// <summary>
        /// <para>The additional inaccuracy gained by rising/falling in the <i>secondary</i> fire mode. As it is tied to the vertical velocity, it is euqally as high as instantly after jumping as well as just before landing if jumping on a level plane. Additionally, the actual inaccuracy will exceed the specified value if the player if falling onto a lower plane due to the increased velocity. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        public float InaccuracyJumpInitialAlt { get { return inaccuracyJumpInitialAlt; } init { inaccuracyJumpInitialAlt = value; } }
        
        /// <summary>
        /// <para>The inaccuracy set at the hightest point of the jump in the <i>secondary</i> fire mode. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        public float InaccuracyJumpApexAlt { get { return inaccuracyJumpApexAlt; } init { inaccuracyJumpApexAlt = value; } }
        
        /// <summary>
        /// <para>The additional inaccuracy gained by jumping in the <i>secondary</i> fire mode. If the player jumps, then this value is added to the <c cref="InaccuracyJumpInitial">InaccuracyJumpInitial</c> for the total jumping inaccuracy. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        public float InaccuracyJumpAlt { get { return inaccuracyJumpAlt; } init { inaccuracyJumpAlt = value; } }
        
        /// <summary>
        /// <para>Additional inaccuracy gained immediately upon landing in the <i>secondary</i> fire mode. Deprecated for all weapons as of 2016, afaik. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        public float InaccuracyLandAlt { get { return inaccuracyLandAlt; } init { inaccuracyLandAlt = value; } }
        
        /// <summary>
        /// <para>Inaccuracy gained by being on a ladder in the <i>secondary</i> fire mode. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        public float InaccuracyLadderAlt { get { return inaccuracyLadderAlt; } init { inaccuracyLadderAlt = value; } }

        /// <summary>
        /// <para>Additional inaccuracy gained by firing a single shot in the <i>secondary</i> fire mode. Is dependant on the players movement speed. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        public float InaccuracyFireAlt { get { return inaccuracyFireAlt; } init { inaccuracyFireAlt = value; } }

        /// <summary>
        /// <para>Inaccuracy gained by (horizontal/non-jumping, non-ladder) movement of the player in the <i>secondary</i> fire mode. Is dependant on the players movement speed. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        public float InaccuracyMoveAlt { get { return inaccuracyMoveAlt; } init { inaccuracyMoveAlt = value; } }
        
        /// <summary>
        /// <para>How much the firing sound of the gun is pitched upwards if the gun is in the <i>secondary</i> fire mode.</para><para>Unit: (Assumption) 1 Hz</para>
        /// </summary>
        public float InaccuracyPitchShift { get { return inaccuracyPitchShift; } init { inaccuracyPitchShift = value; } }
        
        /// <summary>
        /// <para>How quickly the pitch shift happens</para><para>Unit: 1 s</para>
        /// </summary>
        public float InaccuracyAltSoundThreshold { get { return inaccuracyAltSoundThreshold; } init { inaccuracyAltSoundThreshold = value; } }
        
        /// <summary>
        /// The alternative time it takes for 90% of the <i>additional</i> inaccuracy to decay while crouching. If not defined, the game will always use the regular one.</para><para>Unit: 1 s</para>
        /// </summary>
        public float RecoveryTimeCrouchFinal { get { return recoveryTimeCrouchFinal; } init { recoveryTimeCrouchFinal = value; } }

        /// <summary>
        /// The alternative time it takes for 90% of the <i>additional</i> inaccuracy to decay while standing. If not defined, the game will always use the regular one.</para><para>Unit: 1 s</para>
        /// </summary>
        public float RecoveryTimeStandFinal { get { return recoveryTimeStandFinal; } init { recoveryTimeStandFinal = value; } }
        
        /// <summary>
        /// <para>The initial rotation of the spray pattern in the <i>secondary</i> fire mode. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1° (fka 1 deg)</para>
        /// </summary>
        public float RecoilAngleAlt { get { return recoilAngleAlt; } init { recoilAngleAlt = value; } }
        
        /// <summary>
        /// <para>The width of the spray pattern, represented as the opening angle of a circular sector, in the <i>secondary</i> fire mode. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1° (fka 1 deg)</para>
        /// </summary>
        public float RecoilAngleVarianceAlt { get { return recoilAngleVarianceAlt; } init { recoilAngleVarianceAlt = value; } }

        /// <summary>
        /// <para>The height of the spray pattern in the <i>secondary</i> fire mode. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: unknown</para>
        /// </summary>
        public float RecoilMagnitudeAlt { get { return recoilMagnitudeAlt; } init { recoilMagnitudeAlt = value; } }
        
        /// <summary>
        /// <para>The variance within the height of the spray pattern</para><para>Unit: unknown</para>
        /// </summary>
        public float RecoilMagnitudeVarianceAlt { get { return recoilMagnitudeVarianceAlt; } init { recoilMagnitudeVarianceAlt = value; } }

        /// <summary>
        /// <para>When the transition from the primary to the secondary fire mode starts</para><para>Unit: 1 (shot)</para>
        /// </summary>
        public int RecoveryTransitionStartBullet { get { return recoveryTransitionStartBullet; } init { recoveryTransitionStartBullet = value; } }

        /// <summary>
        /// <para>When the transition from the primary to the secondary fire mode end</para><para>Unit: 1 (shot)</para>
        /// </summary>
        public int RecoveryTransitionEndBullet { get { return recoveryTransitionEndBullet; } init { recoveryTransitionEndBullet = value; } }

        /// <summary>
        /// <para>Whether the cun has access to a 3-round burst fire mode (<c>true</c>) or not (<c>false</c>)</para>
        /// </summary>
        public bool HasBurstFire { get { return hasBurstFire; } init { hasBurstFire = value; } }

        /// <summary>
        /// <para>The time between each of the three shots</para><para>Unit: 1 s</para>
        /// </summary>
        public float BurstCycleTime { get { return burstCycleTime; } init { burstCycleTime = value; } }

        /// <summary>
        /// <para>The delay between each burst</para><para>Unit: 1 s</para>
        /// </summary>
        public float BurstPauseTime { get { return burstPauseTime; } init { burstPauseTime = value; } }

        /// <summary>
        /// <para>Whether the gun has a silencer than can be detached (<c>true</c>) or not (<c>false</c>)</para>
        /// </summary>
        public bool HasDetachableSilencer { get { return hasDetachableSilencer; } init { hasDetachableSilencer = value; } }

        /// <summary>
        /// <para>whether the gun is a double-action gun (with a delay before each shot on the primary fire mode) (<c>true</c>) or not (<c>false</c>)</para>
        /// </summary>
        public bool IsRevolver { get { return isRevolver; } init { isRevolver = value; } }

        /// <summary>
        /// Whether the gun has CoD-style aiming down sights (<c>true</c>) or not (<c>false</c>)
        /// </summary>
        public bool HasAimsights { get { return aimsightCapable; } init { aimsightCapable = value; } }

        /// <summary>
        /// <para>The FOV while aiming down sights</para><para>Unit: 1° (fka 1 deg)</para>
        /// </summary>
        public int AimsightFov { get { return aimsightFov; } init { aimsightFov = value; } }

        /// <summary>
        /// <para>The number of zoom levels for the gun</para><para>Unit: 1 (zoom level)</para>
        /// </summary>
        public int ZoomLevels { get { if (zoomLevels == NOT_FILLED_INT) { return 0; } else { return zoomLevels; } } init { zoomLevels = value; } }

        /// <summary>
        /// <para>The field of view for the first zoom level</para><para>Unit: 1° (fka 1 deg)</para>
        /// </summary>
        public int ZoomFov1 { get { return zoomFov1; } init { zoomFov1 = value; } }

        /// <summary>
        /// <para>The field of view for the second zoom level</para><para>Unit: 1° (fka 1 deg)</para>
        /// </summary>
        public int ZoomFov2 { get { return zoomFov2; } init { zoomFov2 = value; } }

        /// <summary>
        /// <para>The cash award for geting a kill with the gun</para><para>Unit: $1 (US-Dollar)</para>
        /// </summary>
        public int KillAward { get { if (killAward == NOT_FILLED_INT) { return 300; } else { return killAward; } } init { killAward = value; } }

        #endregion base properties

        #region expanded properties

        #endregion expanded properties

    }
}

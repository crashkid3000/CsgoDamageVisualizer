using CsgoDamageVisualizerCore.loader.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

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
            
            PropertyInfo[] properties = typeof(Weapon).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach(PropertyInfo property in properties)
            {
                WeaponPropertyMapping? weaponPropertyMappingAttribute = (WeaponPropertyMapping?) property.GetCustomAttribute(typeof(WeaponPropertyMapping));
                if (weaponPropertyMappingAttribute != null && weaponPropertyMappingAttribute.CfgWeaponFieldName != WeaponPropertyMapping.NO_CONVERSION)
                {
                    if(property.PropertyType.Equals(typeof(float)))
                    {
                        
                        property.SetValue(this, CfgWeapon.GetFloatValue(model, weaponPropertyMappingAttribute.CfgWeaponFieldName));
                    }
                    else
                    {
                        if(property.PropertyType.Equals(typeof(int)))
                        {
                            property.SetValue(this, CfgWeapon.GetIntValue(model, weaponPropertyMappingAttribute.CfgWeaponFieldName));
                        }
                        else
                        {
                            if (property.PropertyType.Equals(typeof(bool)))
                            {
                                property.SetValue(this, CfgWeapon.GetBoolValue(model, weaponPropertyMappingAttribute.CfgWeaponFieldName));
                            }
                            else
                            {
                                if(property.PropertyType == typeof(string))
                                {
                                    property.SetValue(this, CfgWeapon.GetStringValue(model, weaponPropertyMappingAttribute.CfgWeaponFieldName));
                                }
                                else
                                {
                                    throw new Exception("Cannot convert CfgWeapon to Weapon for type " + property.PropertyType.Name);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (!property.Name.Equals(nameof(Weapon.Name)) && (weaponPropertyMappingAttribute != null && !weaponPropertyMappingAttribute.CfgWeaponFieldName.Equals(WeaponPropertyMapping.NO_CONVERSION)))
                    {
                        Console.WriteLine($"Warning: No WeaponPropertyMapping has been set for property {nameof(Weapon)}.{property.Name}");
                    }
                }
            }

            this.Name = model.__name?.Substring(0, model.__name.Length - "_prefab".Length) ?? throw new NullReferenceException($"The {nameof(model.__name)} must not be null!");

        }

        public Weapon(CfgWeapon model, CfgWeapon prefab): this(prefab)
        {
            PropertyInfo[] properties = typeof(Weapon).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo property in properties)
            {
                WeaponPropertyMapping? weaponPropertyMappingAttribute = (WeaponPropertyMapping?)property.GetCustomAttribute(typeof(WeaponPropertyMapping));
                if (weaponPropertyMappingAttribute != null)
                {
                    if (property.PropertyType.Equals(typeof(float)))
                    {

                        property.SetValue(this, CfgWeapon.GetFloatValue(model, weaponPropertyMappingAttribute.CfgWeaponFieldName));
                    }
                    else
                    {
                        if (property.PropertyType.Equals(typeof(int)))
                        {
                            property.SetValue(this, CfgWeapon.GetIntValue(model, weaponPropertyMappingAttribute.CfgWeaponFieldName));
                        }
                        else
                        {
                            if (property.PropertyType.Equals(typeof(bool)))
                            {
                                property.SetValue(this, CfgWeapon.GetBoolValue(model, weaponPropertyMappingAttribute.CfgWeaponFieldName));
                            }
                            else
                            {
                                if (property.PropertyType == typeof(string))
                                {
                                    property.SetValue(this, CfgWeapon.GetStringValue(model, weaponPropertyMappingAttribute.CfgWeaponFieldName));
                                }
                                else
                                {
                                    throw new Exception("Cannot convert CfgWeapon to Weapon for type " + property.PropertyType.Name);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (!property.Name.Equals(nameof(Weapon.Name)) && (weaponPropertyMappingAttribute != null && !weaponPropertyMappingAttribute.CfgWeaponFieldName.Equals(WeaponPropertyMapping.NO_CONVERSION)))
                    {
                        Console.WriteLine($"Warning: No WeaponPropertyMapping has been set for property {nameof(Weapon)}.{property.Name}");
                    }
                }
            }

            this.Name = model.__name?.Substring(0, model.__name.Length - "_prefab".Length) ?? throw new NullReferenceException($"The {nameof(model.__name)} must not be null!");
        }

        #region fields

        private static readonly int NOT_FILLED_INT = -483792;
        private static readonly float NOT_FILLED_FLOAT = -425233.9f;
        private static readonly Dictionary<string, string> displayNameDictionary = new Dictionary<string, string>();

        private string name = "";
        private string prefab = "";
        private string item_class = "";
        private bool terrorists = false;
        private bool counterTerrorists = false;
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
        private int crosshairDeltaDistance = NOT_FILLED_INT;
        private float cycletime = NOT_FILLED_FLOAT;
        private float penetration = NOT_FILLED_FLOAT;
        private int damage = NOT_FILLED_INT;
        private float headshotMultiplier = NOT_FILLED_FLOAT;
        private int range = NOT_FILLED_INT;
        private float rangeModifier = NOT_FILLED_FLOAT;
        private int bullets = NOT_FILLED_INT;
        private float flinchVelocityModifierLarge = NOT_FILLED_FLOAT;
        private float flinchVelocityModifierSmall = NOT_FILLED_FLOAT;
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
        private int recoilSeedAlt = NOT_FILLED_INT;
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
        [WeaponPropertyMapping(nameof(CfgWeapon.__name))]
        public string Name { get { return name; } init { name = value; } }

        /// <summary>
        /// The type of the weapon (secondary, machinegun etc). Only important for bots, mission design (e.g. kill X people with a <i>machinegun</i>), etc. and does not effect the player directly.
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.prefab))]
        public string Prefab { get { return prefab; } init { prefab = value; } }
        
        /// <summary>
        /// The base class for this weapon model. While this is be irrelevant for most weapons, for (alternative) guns being able to be swapped out in the loadout system, this means that they usually inherit some stats from their nameof(CfgWeapon.) and only overwrite what's necessary
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.item_class))]
        public string ItemClass { get { return item_class; } init { item_class = value; } }
        
        /// <summary>
        /// If the weapon is available to the T side
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.terrorists))]
        public bool IsTerroristsBuyable { get { return terrorists; } init { terrorists = value; } }
        
        /// <summary>
        /// If the weapon is available to the CTs
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.counterTerrorists))]
        public bool IsCounterTerroristsBuyable { get { return counterTerrorists; } init { counterTerrorists = value; } }
        
        /// <summary>
        /// (Assumption) Defines how much muzzle smoke there is after firing
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.heatPerShot))]
        public float HeatPerShot { get { return heatPerShot; } init { heatPerShot = value; } }
        
        /// <summary>
        /// (Unknown)
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.addonScale))]
        public float AddonScale { get { return addonScale; } init { addonScale = value; } }
        
        /// <summary>
        /// <para>How frequently tracers are fired in the <i>primary</i> fire mode. If no secondary value is defined, the game will use this value for the secondary fire mode. 0 = no tracers.</para> <para>Unit: 1 (every <i>n</i>-th bullet)</para> 
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.tracerFrequency))]
        public int TracerFrequency { get { return tracerFrequency; } init { tracerFrequency = value; } }
        
        /// <summary>
        /// <para>How frequently tracers are fired in the <i>secondary</i> fire mode. If not defined, the game will use the value from the primary fire mode. 0 = no tracers.</para>Unit: 1 (every <i>n</i>-th bullet)<para></para> 
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.tracerFrequencyAlt))]
        public int TracerFrequencyAlt { get { return tracerFrequencyAlt; } init { tracerFrequencyAlt = value; } }
        
        /// <summary>
        /// <para>The size of a magazine/clip.</para> <para>Unit: 1 (<i>n</i> bullets)</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.primaryClipSize))]
        public int PrimaryClipSize { get { return primaryClipSize; } init { primaryClipSize = value; } }
        
        /// <summary>
        /// (Unknown)
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.primaryDefaultClipSize))]
        public int PrimaryDefaultClipSize { get { return primaryDefaultClipSize; } init { primaryDefaultClipSize = value; } }
        
        /// <summary>
        /// (Unknown)
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.secondaryDefaultClipSize))]
        public int SecondaryDefaultClipSize { get { return secondaryDefaultClipSize; } init { secondaryDefaultClipSize = value; } }
        
        /// <summary>
        /// If the fire button (left mouse button) is held, the gun will fire another bullet (true) or not (false)
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.isFullAuto))]
        public bool IsFullAuto { get { return isFullAuto; } init { isFullAuto = value; } }
        
        /// <summary>
        /// <para>The maximum speed the player can move with the weapon in the <i>primary</i> fire mode. If no secondary value is defined, the game will use this value for the secondary fire mode. For reference: With a knife, the player moves at 250 u/s.</para> <para>Unit: units per second (u/s)</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.maxPlayerSpeed))]
        public int MaxPlayerSpeed { get { return maxPlayerSpeed; } init { maxPlayerSpeed = value; } }
        
        /// <summary>
        /// <para>The maximum speed the player can move with the weapon in the <i>secondary</i> fire mode. If not defined, the game will use the value from the primary fire mode. For reference: With a knife, the player moves at 250 u/s.</para> <para>Unit: units per second (u/s)</para> 
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.maxPlayerSpeedAlt))]
        public int MaxPlayerSpeedAlt { get { return maxPlayerSpeedAlt; } init { maxPlayerSpeedAlt = value; } }
        
        /// <summary>
        /// <para>The price of the weapon.</para><para>Unit: $1 (US-Dollar)</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.inGamePrice))]
        public int InGamePrice { get { return inGamePrice; } init { inGamePrice = value; } }
        
        /// <summary>
        /// <para>The <i>double</i> of the armor penetration, stored as a multiplier.</para><para>Unit: 2</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.armorRatio))]
        public float ArmorRatio { get { return armorRatio; } init { armorRatio = value; } }
        
        /// <summary>
        /// <para>For dynamic crosshairs: The minimum gap for the crosshair.</para><para>Unit: unknown</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.crosshairMinDistance))]
        public int CrosshairMinDistance { get { return crosshairMinDistance; } init { crosshairMinDistance = value; } }
        
        /// <summary>
        /// <para>For dynamic crosshairs: How much the crosshair can open.</para><para>Unit: unknown</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.crosshairDeltaDistance))]
        public int CrosshairDeltaDistance { get { return crosshairDeltaDistance; } init { crosshairDeltaDistance = value; } }
        
        /// <summary>
        /// <para>The time delay between each bullet.</para><para>Unit: s</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.cycletime))]
        public float Cycletime { get { return cycletime; } init { cycletime = value; } }
        
        /// <summary>
        /// <para>A measurement for how well you can wallbang with the weapon.</para><para>Unit: unknown; but only values between 0.0-3.0 make a noticable difference</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.penetration))]
        public float Penetration { get { return penetration; } init { penetration = value; } }
        
        /// <summary>
        /// <para>The raw damage dealt by the weapon, per bullet/pellet</para><para>Unit: 1HP (health point)</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.damage))]
        public int Damage { get { return damage; } init { damage = value; } }
        
        /// <summary>
        /// <para>A multiplier for how much more damage a headshot deals. Default is 4.0.</para><para>Unit: 1</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.headshotMultiplier))]
        public float HeadshotMultiplier { get { if (headshotMultiplier == NOT_FILLED_INT) { return 4.0f; } else { return headshotMultiplier; } } init { headshotMultiplier = value; } }
        
        /// <summary>
        /// <para>The range at which the bullet magically disappears at the latest.</para><para>Unit: unit</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.range))]
        public int Range { get { return range; } init { range = value; } }
        
        /// <summary>
        /// <para>A multiplier describing much damage the bullet retains after 500 units.</para><para>Unit: 1</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.rangeModifier))]
        public float RangeModifier { get { return rangeModifier; } init { rangeModifier = value; } }
        
        /// <summary>
        /// <para>How many bullets/pellets are fired with each shot.</para><para>Unit: 1 (<i>n</i> bullets/pellets fired from one cartridge)</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.bullets))]
        public int Bullets { get { if (bullets == NOT_FILLED_INT) { return 1; } else { return bullets; } } init { bullets = value; } }
        
        /// <summary>
        /// <para>How much speed is retained after being hit anywhere (=tagging). This is a multiplier.</para><para>Unit: 1</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.flinchVelocityModifierLarge))]
        public float FlinchVelocityModifierLarge { get { return flinchVelocityModifierLarge; } init { flinchVelocityModifierLarge = value; } }
        
        /// <summary>
        /// <para>(Assumption) How much speed is retained after being hit on the legs, but this is unconfirmed, so it may be a useless value after all. This is a multiplier.</para><para>Unit: 1</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.flinchVelocityModifierSmall))]
        public float FlinchVelocityModifierSmall { get { return flinchVelocityModifierSmall; } init { flinchVelocityModifierSmall = value; } }
        
        /// <summary>
        /// <para>The base spread of the weapon in the <i>primary</i> fire mode. Note that the bullet density is skewed towards the center with this one, unlike other inaccuracy values. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.spread))]
        public float Spread { get { return spread; } init { spread = value; } }
        
        /// <summary>
        /// <para>The inaccuracy gained by crouching in the <i>primary</i> fire mode. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.inaccuracyCrouch))]
        public float InaccuracyCrouch { get { return inaccuracyCrouch; } init { inaccuracyCrouch = value; } }
        
        /// <summary>
        /// <para>The inaccuracy gained by standing in the <i>primary</i> fire mode. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.inaccuracyStand))]
        public float InaccuracyStand { get { return inaccuracyStand; } init { inaccuracyStand = value; } }
        
        /// <summary>
        /// <para>The additional inaccuracy gained by rising/falling in the <i>primary</i> fire mode. As it is tied to the vertical velocity, it is euqally as high as instantly after jumping as well as just before landing if jumping on a level plane. Additionally, the actual inaccuracy will exceed the specified value if the player if falling onto a lower plane due to the increased velocity. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.inaccuracyJumpInitial))]
        public float InaccuracyJumpInitial { get { return inaccuracyJumpInitial; } init { inaccuracyJumpInitial = value; } }
        
        /// <summary>
        /// <para>The inaccuracy set at the hightest point of the jump in the <i>primary</i> fire mode. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.inaccuracyJumpApex))]
        public float InaccuracyJumpApex { get { return inaccuracyJumpApex; } init { inaccuracyJumpApex = value; } }
        
        /// <summary>
        /// <para>The additional inaccuracy gained by jumping in the <i>primary</i> fire mode. If the player jumps, then this value is added to the <c cref="InaccuracyJumpInitial">InaccuracyJumpInitial</c> for the total jumping inaccuracy. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.inaccuracyJump))]
        public float InaccuracyJump { get { return inaccuracyJump; } init { inaccuracyJump = value; } }
        
        /// <summary>
        /// <para>Additional inaccuracy gained immediately upon landing in the <i>primary</i> fire mode. Deprecated for all weapons as of 2016, afaik. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.inaccuracyLand))]
        public float InaccuracyLand { get { return inaccuracyLand; } init { inaccuracyLand = value; } }
        
        /// <summary>
        /// <para>Inaccuracy gained by being on a ladder in the <i>primary</i> fire mode. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.inaccuracyLadder))]
        public float InaccuracyLadder { get { return inaccuracyLadder; } init { inaccuracyLadder = value; } }
        
        /// <summary>
        /// <para>Additional inaccuracy gained by firing a single shot in the <i>primary</i> fire mode. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.inaccuracyFire))]
        public float InaccuracyFire { get { return inaccuracyFire; } init { inaccuracyFire = value; } }
        
        /// <summary>
        /// <para>Inaccuracy gained by (horizontal/non-jumping, non-ladder) movement of the player. Is dependant on the players movement speed. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.inaccuracyMove))]
        public float InaccuracyMove { get { return inaccuracyMove; } init { inaccuracyMove = value; } }
        
        /// <summary>
        /// The time it takes for 90% of the <i>additional</i> inaccuracy to decay while crouching.</para><para>Unit: 1 s</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.recoveryTimeCrouch))]
        public float RecoveryTimeCrouch { get { return recoveryTimeCrouch; } init { recoveryTimeCrouch = value; } }
        
        /// <summary>
        /// The time it takes for 90% of the <i>additional</i> inaccuracy to decay while standing.</para><para>Unit: 1 s</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.recoveryTimeStand))]
        public float RecoveryTimeStand { get { return recoveryTimeStand; } init { recoveryTimeStand = value; } }
        
        /// <summary>
        /// <para>The initial rotation of the spray pattern in the <i>primary</i> fire mode. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1° (fka 1 deg)</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.recoilAngle))]
        public float RecoilAngle { get { return recoilAngle; } init { recoilAngle = value; } }
        
        /// <summary>
        /// <para>The width of the spray pattern, represented as the opening angle of a circular sector, in the <i>primary</i> fire mode. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: 1° (fka 1 deg)</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.recoilAngleVariance))]
        public float RecoilAngleVariance { get { return recoilAngleVariance; } init { recoilAngleVariance = value; } }
        
        /// <summary>
        /// <para>The height of the spray pattern in the <i>primary</i> fire mode. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: unknown</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.recoilMagnitude))]
        public float RecoilMagnitude { get { return recoilMagnitude; } init { recoilMagnitude = value; } }
        
        /// <summary>
        /// <para>The variance within the height of the spray pattern in the <i>primary</i> fire mode. If no secondary value is defined, the game will use this value for the secondary fire mode.</para><para>Unit: unknown</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.recoilMagnitudeVariance))]
        public float RecoilMagnitudeVariance { get { return recoilMagnitudeVariance; } init { recoilMagnitudeVariance = value; } }
        
        /// <summary>
        /// <para>The seed that generates the recoil pattern.</para><para>Unit: n/A</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.recoilSeed))]
        public int RecoilSeed { get { return recoilSeed; } init { recoilSeed = value; } }
        
        /// <summary>
        /// <para>The (maximum) ammount of extra bullets carried around.</para><para>Unit: 1 (bullet)</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.primaryReserveAmmoMax))]
        public int PrimaryReserveAmmoMax { get { return primaryReserveAmmoMax; } init { primaryReserveAmmoMax = value; } }
        
        /// <summary>
        /// <para>The base spread of the weapon in the <i>secondary</i> fire mode. Note that the bullet density is skewed towards the center with this one, unlike other inaccuracy values. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.spreadAlt))]
        public float SpreadAlt { get { return spreadAlt; } init { spreadAlt = value; } }
        
        /// <summary>
        /// <para>The inaccuracy gained by crouching in the <i>secondary</i> fire mode. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.inaccuracyCrouchAlt))]
        public float InaccuracyCrouchAlt { get { return inaccuracyCrouchAlt; } init { inaccuracyCrouchAlt = value; } }
        
        /// <summary>
        /// <para>The inaccuracy gained by standing in the <i>secondary</i> fire mode. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.inaccuracyStandAlt))]
        public float InaccuracyStandAlt { get { return inaccuracyStandAlt; } init { inaccuracyStandAlt = value; } }
        
        /// <summary>
        /// <para>The additional inaccuracy gained by rising/falling in the <i>secondary</i> fire mode. As it is tied to the vertical velocity, it is euqally as high as instantly after jumping as well as just before landing if jumping on a level plane. Additionally, the actual inaccuracy will exceed the specified value if the player if falling onto a lower plane due to the increased velocity. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.inaccuracyJumpInitialAlt))]
        public float InaccuracyJumpInitialAlt { get { return inaccuracyJumpInitialAlt; } init { inaccuracyJumpInitialAlt = value; } }
        
        /// <summary>
        /// <para>The inaccuracy set at the hightest point of the jump in the <i>secondary</i> fire mode. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.inaccuracyJumpApexAlt))]
        public float InaccuracyJumpApexAlt { get { return inaccuracyJumpApexAlt; } init { inaccuracyJumpApexAlt = value; } }
        
        /// <summary>
        /// <para>The additional inaccuracy gained by jumping in the <i>secondary</i> fire mode. If the player jumps, then this value is added to the <c cref="InaccuracyJumpInitial">InaccuracyJumpInitial</c> for the total jumping inaccuracy. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.inaccuracyJumpAlt))]
        public float InaccuracyJumpAlt { get { return inaccuracyJumpAlt; } init { inaccuracyJumpAlt = value; } }
        
        /// <summary>
        /// <para>Additional inaccuracy gained immediately upon landing in the <i>secondary</i> fire mode. Deprecated for all weapons as of 2016, afaik. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.inaccuracyLandAlt))]
        public float InaccuracyLandAlt { get { return inaccuracyLandAlt; } init { inaccuracyLandAlt = value; } }
        
        /// <summary>
        /// <para>Inaccuracy gained by being on a ladder in the <i>secondary</i> fire mode. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.inaccuracyLadderAlt))]
        public float InaccuracyLadderAlt { get { return inaccuracyLadderAlt; } init { inaccuracyLadderAlt = value; } }

        /// <summary>
        /// <para>Additional inaccuracy gained by firing a single shot in the <i>secondary</i> fire mode. Is dependant on the players movement speed. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.inaccuracyFireAlt))]
        public float InaccuracyFireAlt { get { return inaccuracyFireAlt; } init { inaccuracyFireAlt = value; } }

        /// <summary>
        /// <para>Inaccuracy gained by (horizontal/non-jumping, non-ladder) movement of the player in the <i>secondary</i> fire mode. Is dependant on the players movement speed. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1 ia</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.inaccuracyMoveAlt))]
        public float InaccuracyMoveAlt { get { return inaccuracyMoveAlt; } init { inaccuracyMoveAlt = value; } }
        
        /// <summary>
        /// <para>How much the firing sound of the gun is pitched upwards if the gun is in the <i>secondary</i> fire mode.</para><para>Unit: (Assumption) 1 Hz</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.inaccuracyPitchShift))]
        public float InaccuracyPitchShift { get { return inaccuracyPitchShift; } init { inaccuracyPitchShift = value; } }
        
        /// <summary>
        /// <para>How quickly the pitch shift happens</para><para>Unit: 1 s</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.inaccuracyAltSoundThreshold))]
        public float InaccuracyAltSoundThreshold { get { return inaccuracyAltSoundThreshold; } init { inaccuracyAltSoundThreshold = value; } }
        
        /// <summary>
        /// The alternative time it takes for 90% of the <i>additional</i> inaccuracy to decay while crouching. If not defined, the game will always use the regular one.</para><para>Unit: 1 s</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.recoveryTimeCrouchFinal))]
        public float RecoveryTimeCrouchFinal { get { return recoveryTimeCrouchFinal; } init { recoveryTimeCrouchFinal = value; } }

        /// <summary>
        /// The alternative time it takes for 90% of the <i>additional</i> inaccuracy to decay while standing. If not defined, the game will always use the regular one.</para><para>Unit: 1 s</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.recoveryTimeStandFinal))]
        public float RecoveryTimeStandFinal { get { return recoveryTimeStandFinal; } init { recoveryTimeStandFinal = value; } }
        
        /// <summary>
        /// <para>The initial rotation of the spray pattern in the <i>secondary</i> fire mode. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1° (fka 1 deg)</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.recoilAngleAlt))]
        public float RecoilAngleAlt { get { return recoilAngleAlt; } init { recoilAngleAlt = value; } }
        
        /// <summary>
        /// <para>The width of the spray pattern, represented as the opening angle of a circular sector, in the <i>secondary</i> fire mode. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: 1° (fka 1 deg)</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.recoilAngleVarianceAlt))]
        public float RecoilAngleVarianceAlt { get { return recoilAngleVarianceAlt; } init { recoilAngleVarianceAlt = value; } }

        /// <summary>
        /// <para>The height of the spray pattern in the <i>secondary</i> fire mode. If not defined, the game will use the value from the primary fire mode.</para><para>Unit: unknown</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.recoilMagnitudeAlt))]
        public float RecoilMagnitudeAlt { get { return recoilMagnitudeAlt; } init { recoilMagnitudeAlt = value; } }
        
        /// <summary>
        /// <para>The variance within the height of the spray pattern</para><para>Unit: unknown</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.recoilMagnitudeVarianceAlt))]
        public float RecoilMagnitudeVarianceAlt { get { return recoilMagnitudeVarianceAlt; } init { recoilMagnitudeVarianceAlt = value; } }

        /// <summary>
        /// The alternative recoild seed for the <i>secondary</i> fire mode.
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.recoilSeedAlt))]
        public int RecoilSeedAlt { get { return recoilSeedAlt; } init { recoilSeedAlt = value; } }
        
        /// <summary>
        /// <para>When the transition from the primary to the secondary fire mode starts</para><para>Unit: 1 (shot)</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.recoveryTransitionStartBullet))]
        public int RecoveryTransitionStartBullet { get { return recoveryTransitionStartBullet; } init { recoveryTransitionStartBullet = value; } }

        /// <summary>
        /// <para>When the transition from the primary to the secondary fire mode end</para><para>Unit: 1 (shot)</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.recoveryTransitionEndBullet))]
        public int RecoveryTransitionEndBullet { get { return recoveryTransitionEndBullet; } init { recoveryTransitionEndBullet = value; } }

        /// <summary>
        /// <para>Whether the cun has access to a 3-round burst fire mode (<c>true</c>) or not (<c>false</c>)</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.hasBurstFire))] 
        public bool HasBurstFire { get { return hasBurstFire; } init { hasBurstFire = value; } }

        /// <summary>
        /// <para>The time between each of the three shots</para><para>Unit: 1 s</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.burstCycleTime))] 
        public float BurstCycleTime { get { return burstCycleTime; } init { burstCycleTime = value; } }

        /// <summary>
        /// <para>The delay between each burst</para><para>Unit: 1 s</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.burstPauseTime))]
        public float BurstPauseTime { get { return burstPauseTime; } init { burstPauseTime = value; } }

        /// <summary>
        /// <para>Whether the gun has a silencer than can be detached (<c>true</c>) or not (<c>false</c>)</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.hasDetachableSilencer))] 
        public bool HasDetachableSilencer { get { return hasDetachableSilencer; } init { hasDetachableSilencer = value; } }

        /// <summary>
        /// <para>whether the gun is a double-action gun (with a delay before each shot on the primary fire mode) (<c>true</c>) or not (<c>false</c>)</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.isRevolver))] 
        public bool IsRevolver { get { return isRevolver; } init { isRevolver = value; } }

        /// <summary>
        /// Whether the gun has CoD-style aiming down sights (<c>true</c>) or not (<c>false</c>)
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.aimsightCapable))] 
        public bool HasAimsights { get { return aimsightCapable; } init { aimsightCapable = value; } }

        /// <summary>
        /// <para>The FOV while aiming down sights</para><para>Unit: 1° (fka 1 deg)</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.aimsightFov))]
        public int AimsightFov { get { return aimsightFov; } init { aimsightFov = value; } }

        /// <summary>
        /// <para>The number of zoom levels for the gun</para><para>Unit: 1 (zoom level)</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.zoomLevels))] 
        public int ZoomLevels { get { if (zoomLevels == NOT_FILLED_INT) { return 0; } else { return zoomLevels; } } init { zoomLevels = value; } }

        /// <summary>
        /// <para>The field of view for the first zoom level</para><para>Unit: 1° (fka 1 deg)</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.zoomFov1))] 
        public int ZoomFov1 { get { return zoomFov1; } init { zoomFov1 = value; } }

        /// <summary>
        /// <para>The field of view for the second zoom level</para><para>Unit: 1° (fka 1 deg)</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.zoomFov2))]
        public int ZoomFov2 { get { return zoomFov2; } init { zoomFov2 = value; } }

        /// <summary>
        /// <para>The cash award for geting a kill with the gun</para><para>Unit: $1 (US-Dollar)</para>
        /// </summary>
        [WeaponPropertyMapping(nameof(CfgWeapon.killAward))]
        public int KillAward { get { if (killAward == NOT_FILLED_INT) { return 300; } else { return killAward; } } init { killAward = value; } }

        #endregion base properties

        #region expanded properties

        /// <summary>
        /// The in-game name of the weapon
        /// </summary>
        public string DisplayName { get
            {
                if(displayNameDictionary.Count == 0)
                {
                    displayNameDictionary["weapon_deagle"] = "Desert Eagle";
                    displayNameDictionary["weapon_revolver"] = "R8 Revolver";
                    displayNameDictionary["weapon_elite"] = "Dual Berettas";
                    displayNameDictionary["weapon_fiveseven"] = "Five-seveN";
                    displayNameDictionary["weapon_glock"] = "Glock-18";
                    displayNameDictionary["weapon_hkp2000"] = "P2000";
                    displayNameDictionary["weapon_usp_silencer"] = "USP-S";
                    displayNameDictionary["weapon_p250"] = "P250";
                    displayNameDictionary["weapon_cz75a"] = "CZ-75 Auto";
                    displayNameDictionary["weapon_tec9"] = "Tec-9";

                    displayNameDictionary["weapon_mag7"] = "MAG-7";
                    displayNameDictionary["weapon_nova"] = "Nova";
                    displayNameDictionary["weapon_sawedoff"] = "Sawed-off";
                    displayNameDictionary["weapon_xm1014"] = "XM1014";
                    
                    displayNameDictionary["weapon_bizon"] = "PP-Bizon";
                    displayNameDictionary["weapon_mac10"] = "MAC-10";
                    displayNameDictionary["weapon_mp7"] = "MP7";
                    displayNameDictionary["weapon_mp5sd"] = "MP5SD";
                    displayNameDictionary["weapon_mp9"] = "MP9";
                    displayNameDictionary["weapon_p90"] = "P90";
                    displayNameDictionary["weapon_ump45"] = "UMP 45";
                    
                    displayNameDictionary["weapon_ak47"] = "AK-47";
                    displayNameDictionary["weapon_aug"] = "AUG";
                    displayNameDictionary["weapon_famas"] = "FAMAS";
                    displayNameDictionary["weapon_galilar"] = "Galil AR";
                    displayNameDictionary["weapon_m4a1"] = "M4A4";
                    displayNameDictionary["weapon_m4a1_silencer"] = "M4A1-S"; 
                    displayNameDictionary["weapon_sg556"] = "SG553";
                    
                    displayNameDictionary["weapon_m249"] = "M249";
                    displayNameDictionary["weapon_negev"] = "Negev";
                    
                    displayNameDictionary["weapon_ssg08"] = "SSG 08";
                    displayNameDictionary["weapon_scar20"] = "SCAR-20";
                    displayNameDictionary["weapon_g3sg1"] = "G3SG1";
                    displayNameDictionary["weapon_awp"] = "AWP";
                }
                if (displayNameDictionary.ContainsKey(this.Name))
                {
                    return displayNameDictionary[this.Name];
                }
                else
                {
                    return "<Unknown>";
                }
            } }

        /// <summary>
        /// Whether the gun has any zoom levels (<c>true</c>) or not (<c>false</c>)
        /// </summary>
        public bool HasZoomLevels { get { return ZoomLevels != 0; } }

        /// <summary>
        /// The inaccuracy immeadiately after jumping, i.e. the sum of <c>InaccuracyJump</c> and <c>InaccuracyJumpAlt</c>, in the <i>primary</i> fire mode.
        /// </summary>
        public float InacuracyJumpSum {  get { return InaccuracyJump + InaccuracyJumpInitial; } }

        /// <summary>
        /// The inaccuracy immeadiately after jumping, i.e. the sum of <c>InaccuracyJump</c> and <c>InaccuracyJumpAlt</c>, in the <i>primary</i> fire mode.
        /// </summary>
        public float InacuracyJumpAltSum { get { return InaccuracyJumpAlt + InaccuracyJumpInitialAlt; } }

        #endregion expanded properties

    }
}

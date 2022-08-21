using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CsgoDamageVisualizerCore.loader.model
{
    /// <summary>
    /// The raw stats gathered from the items_game.txt file
    /// </summary>
    public class CfgWeapon
    {
        internal string? __name;
        [CfgAttributeType(typeof(string))]
        internal string? prefab;
        [CfgAttributeType(typeof(string))]
        internal string? item_class;
        [CfgAttributeType(typeof(bool))]
        internal string? terrorists;
        [CfgAttributeType(typeof(bool))]
        [CfgAttributeName("counter-terrorists")]
        internal string? counterTerrorists;
        [CfgAttributeName("heat per shot")]
        internal string? heatPerShot;
        [CfgAttributeName("addon scale")]
        internal string? addonScale;
        [CfgAttributeType(typeof(int))]
        [CfgAttributeName("tracer frequency")]
        internal string? tracerFrequency;
        [CfgAttributeType(typeof(int))]
        [CfgAttributeName("tracer frequency alt")]
        internal string? tracerFrequencyAlt;
        [CfgAttributeType(typeof(int))]
        [CfgAttributeName("primary clip size")]
        internal string? primaryClipSize;
        [CfgAttributeType(typeof(int))]
        [CfgAttributeName("primary default clip size")]
        internal string? primaryDefaultClipSize;
        [CfgAttributeType(typeof(int))]
        [CfgAttributeName("secondary clip default size")]
        internal string? secondaryDefaultClipSize;
        [CfgAttributeType(typeof(bool))]
        [CfgAttributeName("is full auto")]
        internal string? isFullAuto;
        [CfgAttributeName("max player speed")]
        [CfgAttributeType(typeof(int))]
        internal string? maxPlayerSpeed;
        [CfgAttributeType(typeof(int))]
        [CfgAttributeName("in game price")]
        internal string? inGamePrice;
        [CfgAttributeName("armor ratio")]
        internal string? armorRatio;
        [CfgAttributeType(typeof(int))]
        [CfgAttributeName("crosshair min distance")]
        internal string? crosshairMinDistance;
        [CfgAttributeType(typeof(int))]
        [CfgAttributeName("crosshairDeltaDistance")]
        internal string? crosshairDeltaDistance;
        internal string? cycletime;
        internal string? penetration;
        [CfgAttributeType(typeof(int))]
        internal string? damage;
        [CfgAttributeName("headshot multiplier")]
        internal string? headshotMultiplier;
        [CfgAttributeType(typeof(int))]
        internal string? range;
        [CfgAttributeName("range modifier")]
        internal string? rangeModifier;
        [CfgAttributeType(typeof(int))]
        internal string? bullets;
        [CfgAttributeName("flinch velocity modifier large")]
        internal string? flinchVelocityModifierLarge;
        [CfgAttributeName("flinch velocity modifier small")]
        internal string? flinchVelocityModifierSmall;
        internal string? spread;
        [CfgAttributeName("inaccuracy crouch")]
        internal string? inaccuracyCrouch;
        [CfgAttributeName("inaccuracy stand")]
        internal string? inaccuracyStand;
        [CfgAttributeName("inaccuracy jump initial")]
        internal string? inaccuracyJumpInitial;
        [CfgAttributeName("inaccuracy jump apex")]
        internal string? inaccuracyJumpApex;
        [CfgAttributeName("inaccuracy jump")]
        internal string? inaccuracyJump;
        [CfgAttributeName("inaccuracy land")]
        internal string? inaccuracyLand;
        [CfgAttributeName("inaccuracy ladder")]
        internal string? inaccuracyLadder;
        [CfgAttributeName("inaccuracy fire")]
        internal string? inaccuracyFire;
        [CfgAttributeName("inaccuracy move")]
        internal string? inaccuracyMove;
        [CfgAttributeName("recovery time crouch")]
        internal string? recoveryTimeCrouch;
        [CfgAttributeName("recovery time stand")]
        internal string? recoveryTimeStand;
        [CfgAttributeName("recoil angle")]
        internal string? recoilAngle;
        [CfgAttributeName("recoil angle variance")]
        internal string? recoilAngleVariance;
        [CfgAttributeName("recoil magnitude")]
        internal string? recoilMagnitude;
        [CfgAttributeName("recoil magnitude variance")]
        internal string? recoilMagnitudeVariance;
        [CfgAttributeType(typeof(int))]
        [CfgAttributeName("recoil seed")]
        internal string? recoilSeed;
        [CfgAttributeType(typeof(int))]
        [CfgAttributeName("primary reserve ammo max")]
        internal string? primaryReserveAmmoMax;
        [CfgAttributeName("spread alt")]
        internal string? spreadAlt;
        [CfgAttributeName("inaccuracy crouch alt")]
        internal string? inaccuracyCrouchAlt;
        [CfgAttributeName("inaccuracy stand alt")]
        internal string? inaccuracyStandAlt;
        [Obsolete("Not used by CSGO game")]
        [CfgAttributeName("inaccuracy jump initial alt")]
        internal string? inaccuracyJumpInitialAlt;
        [Obsolete("Not used by CSGO game")]
        [CfgAttributeName("inaccuracy jump apex alt")]
        internal string? inaccuracyJumpApexAlt;
        [CfgAttributeName("inaccuracy jump alt")]
        internal string? inaccuracyJumpAlt;
        [CfgAttributeName("inaccuracy land alt")]
        internal string? inaccuracyLandAlt;
        [CfgAttributeName("inaccuracy ladder alt")]
        internal string? inaccuracyLadderAlt;
        [CfgAttributeName("inaccuracy fire alt")]
        internal string? inaccuracyFireAlt;
        [CfgAttributeName("inaccuracy move alt")]
        internal string? inaccuracyMoveAlt;
        [CfgAttributeName("inaccuracy alt sound threshold")]
        internal string? inaccuracyAltSoundThreshold;
        [CfgAttributeName("recovery time crouch alt")]
        internal string? recoveryTimeCrouchAlt;
        [CfgAttributeName("recovery time stand alt")]
        internal string? recoveryTimeStandAlt;
        [Obsolete("Not used by CSGO game")]
        [CfgAttributeName("recoil angle alt")]
        internal string? recoilAngleAlt;
        [CfgAttributeName("recoil angle variance alt")]
        internal string? recoilAngleVarianceAlt;
        [CfgAttributeName("recoil magnitude alt")]
        internal string? recoilMagnitudeAlt;
        [CfgAttributeName("recoil magnitude variance alt")]
        internal string? recoilMagnitudeVarianceAlt;
        [Obsolete("Not used by CSGO game")]
        [CfgAttributeType(typeof(int))]
        [CfgAttributeName("recoil seed alt")]
        internal string? recoilSeedAlt;
        [CfgAttributeType(typeof(int))]
        [CfgAttributeName("recovery transition start bullet")]
        internal string? recoveryTransitionStartBullet;
        [CfgAttributeType(typeof(int))]
        [CfgAttributeName("recovery transition end bullet")]
        internal string? recoveryTransitionEndBullet;
        [CfgAttributeType(typeof(bool))]
        [CfgAttributeName("has burst mode")]
        internal string? hasBurstFire;
        [CfgAttributeName("cycletime when in burst mode")]
        internal string? burstCycleTime;
        [CfgAttributeName("time between burst shots")]
        internal string? burstPauseTime;
        [CfgAttributeType(typeof(bool))]
        [CfgAttributeName("has silencer")]
        internal string? hasDetachableSilencer;
        [CfgAttributeType(typeof(bool))]
        [CfgAttributeName("is revolver")]
        internal string? isRevolver;


        static private Dictionary<string, string> attributeMap = new Dictionary<string, string>();
        static private Dictionary<string, Type> castTypeMap = new Dictionary<string, Type>();

        /// <summary>
        /// Creates the map of attribute names to field names. However, if one already exists, it returns that one.
        /// 
        /// The attribute names list maps the "keys" of the CFG file to the fields within this code. Type conversion and such happens at a later point.
        /// </summary>
        /// <returns>The attribute name map</returns>
        public static IReadOnlyDictionary<string, string> GetAttributeNameMap()
        {
            if(attributeMap.Count > 0)
            {
                return attributeMap;
            }

            Type cfgWeapon = typeof(CfgWeapon);

            foreach (FieldInfo field in cfgWeapon.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                CfgAttributeName? cfgAttributeName = (CfgAttributeName?) (field.GetCustomAttribute(typeof(CfgAttributeName)));
                string cfgName = cfgAttributeName?.Name ?? field.Name;
                attributeMap.Add(cfgName, field.Name);

            }

            return attributeMap;

        }

        /// <summary>
        /// Gets which data type the given attribute should be ideally cast to. Default value is float.
        /// </summary>
        /// <returns>The mapping of attribute names to their best matching data type</returns>
        public static IReadOnlyDictionary<string, Type> GetCastTypeMap()
        {
            if(castTypeMap.Count > 0)
            {
                return castTypeMap;
            }

            Type cfgWeapon = typeof(CfgWeapon);
            foreach(FieldInfo field in cfgWeapon.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                CfgAttributeType? cfgAttributeType = (CfgAttributeType?) (field.GetCustomAttribute(typeof(CfgAttributeType)));
                Type castType = cfgAttributeType?.GetType() ?? typeof(float);
                castTypeMap.Add(field.Name, castType);
            }

            return castTypeMap;

        }

        /// <summary>
        /// Sets the value of the given instance using reflection.
        /// </summary>
        /// <param name="instance">The instance whoose value shall be set.</param>
        /// <param name="memberName">The name of the member to be set</param>
        /// <param name="value">The new value</param>
        /// <exception cref="NullReferenceException">If the field with the memberName does not exist</exception>
        public static void SetValue(CfgWeapon instance, string memberName, string value)
        {
            FieldInfo field = typeof(CfgWeapon).GetField(memberName, BindingFlags.Instance | BindingFlags.NonPublic) ?? throw new NullReferenceException($"The member {memberName} was not found insice class {nameof(CfgWeapon)}"); ;
            field.SetValue(instance, value);
        }
    }
}

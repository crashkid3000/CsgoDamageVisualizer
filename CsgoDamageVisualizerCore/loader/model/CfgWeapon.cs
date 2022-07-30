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
    internal class CfgWeapon
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

        static private Dictionary<string, string> attributeMap;

        /// <summary>
        /// Creates the map of attribute names to field names. However, if one already exists, it reutrns that one.
        /// </summary>
        /// <returns>The attribute name map</returns>
        internal static IReadOnlyDictionary<string, string> GetAttributeNameMap()
        {
            if(attributeMap != null)
            {
                return attributeMap;
            }

            attributeMap = new Dictionary<string, string>();

            Type cfgWeapon = typeof(CfgWeapon);
            Attribute cfgAttribute
            foreach(FieldInfo field in cfgWeapon.GetFields())
            {
                CfgAttributeName? cfgAttributeName = (CfgAttributeName?) (field.GetCustomAttribute(typeof(CfgAttributeName)));
                string cfgName = cfgAttributeName?.Name ?? field.Name;
                attributeMap.Add(cfgName, field.Name);

            }

            return attributeMap;

        }
    }
}

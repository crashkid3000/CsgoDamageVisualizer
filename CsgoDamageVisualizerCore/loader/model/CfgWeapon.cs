using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerCore.loader.model
{
    /// <summary>
    /// The raw stats gathered from the items_game.txt file
    /// </summary>
    public class CfgWeapon
    {
        private string? __name;
        [CfgAttributeType(typeof(string))]
        private string? prefab;
        [CfgAttributeType(typeof(string))]
        private string? item_class;
        [CfgAttributeType(typeof(bool))]
        private string? terrorists;
        [CfgAttributeType(typeof(bool))]
        [CfgAttributeName("counter-terrorists")]
        private string? counterTerrorists;
        [CfgAttributeName("heat per shot")]
        private string? heatPerShot;
        [CfgAttributeName("addon scale")]
        private string? addonScale;
        [CfgAttributeType(typeof(int))]
        [CfgAttributeName("tracer frequency")]
        private string? tracerFrequency;
        [CfgAttributeType(typeof(int))]
        [CfgAttributeName("primary clip size")]
        private string? primaryClipSize;
        [CfgAttributeType(typeof(int))]
        [CfgAttributeName("primary default clip size")]
        private string? primaryDefaultClipSize;
        [CfgAttributeType(typeof(int))]
        [CfgAttributeName("secondary clip default size")]
        private string? secondaryDefaultClipSize;
        [CfgAttributeType(typeof(bool))]
        [CfgAttributeName("is full auto")]
        private string? isFullAuto;
        [CfgAttributeName("max player speed")]
        [CfgAttributeType(typeof(int))]
        private string? maxPlayerSpeed;
        [CfgAttributeType(typeof(int))]
        [CfgAttributeName("in game price")]
        private string? inGamePrice;
        [CfgAttributeName("armor ratio")]
        private string? armorRatio;
        [CfgAttributeType(typeof(int))]
        [CfgAttributeName("crosshair min distance")]
        private string? crosshairMinDistance;
        [CfgAttributeType(typeof(int))]
        [CfgAttributeName("crosshairDeltaDistance")]
        private string? crosshairDeltaDistance;
        private string? cycletime;
        private string? penetration;
        [CfgAttributeType(typeof(int))]
        private string? damage;
        [CfgAttributeName("headshot multiplier")]
        private string? headshotMultiplier;
        [CfgAttributeType(typeof(int))]
        private string? range;
        [CfgAttributeName("range modifier")]
        private string? rangeModifier;
        [CfgAttributeType(typeof(int))]
        private string? bullets;
        [CfgAttributeName("flinch velocity modifier large")]
        private string? flinchVelocityModifierLarge;
        [CfgAttributeName("flinch velocity modifier small")]
        private string? flinchVelocityModifierSmall;
        private string? spread;
        [CfgAttributeName("inaccuracy crouch")]
        private string? inaccuracyCrouch;
        [CfgAttributeName("inaccuracy stand")]
        private string? inaccuracyStand;
        [CfgAttributeName("inaccuracy jump initial")]
        private string? inaccuracyJumpInitial;
        [CfgAttributeName("inaccuracy jump apex")]
        private string? inaccuracyJumpApex;
        [CfgAttributeName("inaccuracy jump")]
        private string? inaccuracyJump;
        [CfgAttributeName("inaccuracy land")]
        private string? inaccuracyLand;
        [CfgAttributeName("inaccuracy ladder")]
        private string? inaccuracyLadder;
        [CfgAttributeName("inaccuracy fire")]
        private string? inaccuracyFire;
        [CfgAttributeName("inaccuracy move")]
        private string? inaccuracyMove;
        [CfgAttributeName("recovery time crouch")]
        private string? recoveryTimeCrouch;
        [CfgAttributeName("recovery time stand")]
        private string? recoveryTimeStand;
        [CfgAttributeName("recoil angle")]
        private string? recoilAngle;
        [CfgAttributeName("recoil angle variance")]
        private string? recoilAngleVariance;
        [CfgAttributeName("recoil magnitude")]
        private string? recoilMagnitude;
        [CfgAttributeName("recoil magnitude variance")]
        private string? recoilMagnitudeVariance;
        [CfgAttributeType(typeof(int))]
        [CfgAttributeName("recoil seed")]
        private string? recoilSeed;
        [CfgAttributeType(typeof(int))]
        [CfgAttributeName("primary reserve ammo max")]
        private string? primaryReserveAmmoMax;
        [CfgAttributeName("spread alt")]
        private string? spreadAlt;
        [CfgAttributeName("inaccuracy crouch alt")]
        private string? inaccuracyCrouchAlt;
        [CfgAttributeName("inaccuracy stand alt")]
        private string? inaccuracyStandAlt;
        [CfgAttributeName("inaccuracy jump alt")]
        private string? inaccuracyJumpAlt;
        [CfgAttributeName("inaccuracy land alt")]
        private string? inaccuracyLandAlt;
        [CfgAttributeName("inaccuracy ladder alt")]
        private string? inaccuracyLadderAlt;
        [CfgAttributeName("inaccuracy fire alt")]
        private string? inaccuracyFireAlt;
        [CfgAttributeName("inaccuracy move alt")]
        private string? inaccuracyMoveAlt;
        [CfgAttributeName("recovery time crouch alt")]
        private string? recoveryTimeCrouchAlt;
        [CfgAttributeName("recovery time stand alt")]
        private string? recoveryTimeStandAlt;
        [Obsolete("Not used by CSGO game")]
        [CfgAttributeName("recoil angle alt")]
        private string? recoilAngleAlt;
        [CfgAttributeName("recoil angle variance alt")]
        private string? recoilAngleVarianceAlt;
        [CfgAttributeName("recoil magnitude alt")]
        private string? recoilMagnitudeAlt;
        [CfgAttributeName("recoil magnitude variance alt")]
        private string? recoilMagnitudeVarianceAlt;
        [Obsolete("Not used by CSGO game")]
        [CfgAttributeType(typeof(int))]
        [CfgAttributeName("recoil seed alt")]
        private string? recoilSeedAlt;


    }
}

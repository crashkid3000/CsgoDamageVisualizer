using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerCore.analysis
{
    /// <summary>
    /// Basic calculations regarding CSGO's inaccuracy that doesn't directly relate to a weapon
    /// </summary>
    public class InaccuracyCalculations
    {

        /// <summary>
        /// <para>The radius of the head in CSGO.</para> <para><u>Unit:</u> 1 mm</para>
        /// </summary>
        public static float HeadRadius { get { return 152.4f; } } //6 inches/6 units

        /// <summary>
        /// <para>An assumption of the radius of the body hitbox for a guaranteed hit, i.e. the acutal hitbox is bigger than that.</para><para><u>Unit:</u> mm</para> 
        /// </summary>
        public static float BodyRadius { get { return 203.2f; } } //8 inches / 8 units

        /// <summary>
        /// The exponent, defining how much inaccuracy is left after one <c>RecoveryTimeXXX</c> period has passed
        /// </summary>
        public static float InaccuracyDecayExponent { get { return 0.1f; } } //unit: 1 

        /// <summary>
        /// <para>Calculates the accurate range for a headshot, i.e. where a bullet will 100% hit the head.</para>
        /// </summary>
        /// <param name="inaccuracy">The inaccuracy, in ia</param>
        /// <returns>The accurate range, in meters</returns>
        public float CalculateAccurateRangeForHeadshot(float inaccuracy)
        {
            return HeadRadius / inaccuracy;
        }

        /// <summary>
        /// <para>Calculates the accurate range for a bodyshot, i.e. where a bullet will 100% hit the body.</para>
        /// </summary>
        /// <param name="inaccuracy">The inaccuracy, in ia</param>
        /// <returns>The accurate range, in meters</returns>
        public float CalculateAccurateRangeForBodyshot(float inaccuracy)
        {
            return BodyRadius / inaccuracy;
        }

        /// <summary>
        /// Calculates the <i>diameter</i> of the accuracy circle (from the players POV) in pixels
        /// </summary>
        /// <param name="inaccuracy">The inaccuracy value of the gun</param>
        /// <param name="screenHeightFactor">A multiplier. The relative screen size to 1080px. For instance, if your screen was 500px in height, you'd provide 500/1080.</param>
        /// <returns>The size of the accuracy circle. <u>Unit:</u> px</returns>
        public int CalculateAccuracyCircleSize(float inaccuracy, float screenHeightFactor)
        {
            float retVal;
            if(inaccuracy < 5)
            {
                retVal = inaccuracy;
            }
            else
            {
                retVal = 0.72620713785864f * inaccuracy + 0.74723582925123f; //factors based on empirical research and linear regression. They match up very well for inaccuracy values <= 50, and shouldn't provide much error for greater inaccuracy values!
            }
            retVal = retVal * screenHeightFactor;
            return (int)Math.Round(retVal);
        }

        /// <summary>
        /// Calculates how much the extra inaccuracy remains since the extra inaccuracy has been added
        /// </summary>
        /// <param name="extraInaccuracy">The extra inaccuracy that will decay over time. <u>Unit:</u> 1 ia</param>
        /// <param name="recoveryTime">The recovery time of a weapon. <u>Unit:</u> 1 s</param>
        /// <param name="timeSinceGaining">The time that has passed since gaining that inaccuracy. <u>Unit:</u> 1 s</param>
        /// <returns>The remaining extra inaccuracy after time <c>timeSinceGaining</c> has passed. <u>Unit:</u> 1 s</returns>
        public float CalculateExtraInaccuracyAfterTime(float extraInaccuracy, float recoveryTime, float timeSinceGaining)
        {
            return extraInaccuracy * (float) Math.Pow(InaccuracyDecayExponent, timeSinceGaining / recoveryTime);
        }
        
    }
}

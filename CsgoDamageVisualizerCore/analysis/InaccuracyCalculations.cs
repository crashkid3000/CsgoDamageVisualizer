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
        /// <para>The radius of the head in CSGO.</para> <para>Unit:</u>mm</para><u>
        /// </summary>
        public float HeadRadius { get { return 152.4f; } } //6 inches/6 units

        /// <summary>
        /// <para>An assumption of the radius of the body hitbox for a guaranteed hit, i.e. the acutal hitbox is bigger than that.</para><para><u>Unit:</u> mm</para> 
        /// </summary>
        public float BodyRadius { get { return 203.2f; } } //8 inches / 8 units

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




    }
}

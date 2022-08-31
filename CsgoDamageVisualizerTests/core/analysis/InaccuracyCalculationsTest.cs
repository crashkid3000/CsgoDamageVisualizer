using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

using CsgoDamageVisualizerCore.analysis;

namespace CsgoDamageVisualizerTests.core.analysis
{
    [TestClass]
    public class InaccuracyCalculationsTest
    {
        private InaccuracyCalculations inaccuracyCalculations;

        public InaccuracyCalculationsTest()
        {
            this.inaccuracyCalculations = new InaccuracyCalculations();
        }

        [TestInitialize]
        public void setUp()
        {
            this.inaccuracyCalculations = new InaccuracyCalculations();
        }

        [TestMethod]
        public void CalculateAccurateRangeForHeadshot_withXm1014_ReturnsProperValue()
        {
            float xmInaccuracyStanding = 45.0f; //ia -- see BlackRetinas & SlothSuqadrons CSGO weapon spreadsheet for easy reference
            float xmInaccurateRange = 3.39f; //m -- see BlackRetinas & SlothSuqadrons CSGO weapon spreadsheet for easy reference

            float calculatedAccurateRange = inaccuracyCalculations.CalculateAccurateRangeForHeadshot(xmInaccuracyStanding);
            float roundedCAR = (float) Math.Round(calculatedAccurateRange, 2);

            Assert.AreEqual(xmInaccurateRange, roundedCAR);
        }

        [TestMethod]
        public void CalculateAccurateRangeForHeadshot_withAwpScoped_ReturnsProperValue()
        {
            float awpInaccuracyCrouching = 1.7f; //ia -- see BlackRetinas & SlothSuqadrons CSGO weapon spreadsheet for easy reference
            float awpInaccurateRange = 89.65f; //m -- see BlackRetinas & SlothSuqadrons CSGO weapon spreadsheet for easy reference

            float calculatedAccurateRange = inaccuracyCalculations.CalculateAccurateRangeForHeadshot(awpInaccuracyCrouching);
            float roundedCAR = (float)Math.Round(calculatedAccurateRange, 2);

            Assert.AreEqual(awpInaccurateRange, roundedCAR);
        }

        [TestMethod]
        public void CalculateAccurateRangeForBodyshot_withXm1014_ReturnsProperValue()
        {
            float xmInaccuracyStanding = 45.0f; //ia -- see BlackRetinas & SlothSuqadrons CSGO weapon spreadsheet for easy reference
            float xmInaccurateRange = 4.52f; //m

            float calculatedAccurateRange = inaccuracyCalculations.CalculateAccurateRangeForBodyshot(xmInaccuracyStanding);
            float roundedCAR = (float)Math.Round(calculatedAccurateRange, 2);

            Assert.AreEqual(xmInaccurateRange, roundedCAR);
        }

        [TestMethod]
        public void CalculateAccurateRangeForBodyshot_withAwpScoped_ReturnsProperValue()
        {
            float awpInaccuracyCrouching = 1.7f; //ia -- see BlackRetinas & SlothSuqadrons CSGO weapon spreadsheet for easy reference
            float awpInaccurateRange = 119.53f; //m

            float calculatedAccurateRange = inaccuracyCalculations.CalculateAccurateRangeForBodyshot(awpInaccuracyCrouching);
            float roundedCAR = (float)Math.Round(calculatedAccurateRange, 2);

            Assert.AreEqual(awpInaccurateRange, roundedCAR);
        }

        [TestMethod]
        public void CalculateAccuracyCircleSize_withTinyInaccuracyAndFullHd_ReturnsExactlyProperPixelValue()
        {
            float inaccuracy = 2.0f;
            int expectedSize = (int)inaccuracy; //from empirical analysis

            int calculatedSitze = inaccuracyCalculations.CalculateAccuracyCircleSize(inaccuracy, 1.0f);

            Assert.AreEqual(calculatedSitze, expectedSize);
        }

        [TestMethod]
        public void CalculateAccuracyCircleSize_withMediumOrHighInaccuracyAndFullHd_ReturnsRoughlyProperPixelValue()
        {
            float inaccuracy = 40.0f;
            int expectedSize = 30; //from empirical analysis

            int calculatedSize = inaccuracyCalculations.CalculateAccuracyCircleSize(inaccuracy, 1.0f);

            Assert.IsTrue(WithinErrorRangeAbsolute(expectedSize, calculatedSize, 1));
            Console.WriteLine($"The calculated size {calculatedSize} and the actual size {expectedSize} are still within the error range of +-{0.5f}");
        }

        [TestMethod]
        public void CalculateAccuracyCircleSize_withMediumOrHighInaccuracyAndSmolRes_ReturnsRoughlyProperPixelValue()
        {
            float screenSizeRelativeToFullHd = 0.73f;
            float inaccuracy = 40.0f;
            int expectedSize = (int)(30 * screenSizeRelativeToFullHd); //from empirical analysis
            
            int calculatedSize = inaccuracyCalculations.CalculateAccuracyCircleSize(inaccuracy, screenSizeRelativeToFullHd);

            Assert.IsTrue(WithinErrorRangeAbsolute(expectedSize, calculatedSize, 1));
            Console.WriteLine($"The calculated size {calculatedSize} and the actual size {expectedSize} are still within the error range of +-{0.5f}");
        }

        [TestMethod]
        public void CalculateExtraInaccuracyAfterTime_WithNoTimePassed_ReturnsInaccuracy()
        {
            float inaccuracy = 13.37f;

            float calculatedInaccuracy = inaccuracyCalculations.CalculateExtraInaccuracyAfterTime(inaccuracy, 0.42f, 0.0f);

            Assert.AreEqual(inaccuracy, calculatedInaccuracy);
        }

        [TestMethod]
        public void CalculateExtraInaccuracyAfterTime_WithOneRecoveryTimePreiodPassed_ReturnsDecayedInaccuracy()
        {
            float inaccuracy = 13.37f;
            float recoveryTime = 0.338576f;

            float calculatedInaccuracy = inaccuracyCalculations.CalculateExtraInaccuracyAfterTime(inaccuracy, recoveryTime, recoveryTime);

            Assert.AreEqual(inaccuracy * InaccuracyCalculations.InaccuracyDecayExponent, calculatedInaccuracy);
        }
        
        [TestMethod]
        public void CalculateExtraInaccuracyAfterTime_WithSomeTimePassed_ReturnsDecayedInaccuracy()
        {
            float extraInaccuracy = 13.37f;
            float recoveryTime = 0.338576f;
            float timePassed = 0.5f;
            float expectedInaccuracy = 0.4460238f;

            float calculatedInaccuracy = inaccuracyCalculations.CalculateExtraInaccuracyAfterTime(extraInaccuracy, recoveryTime, timePassed);

            Assert.AreEqual(expectedInaccuracy, calculatedInaccuracy);
        }

        private static bool WithinErrorRangeAbsolute(float expected, float actual, float errorRangeAbsolute) => actual <= expected + errorRangeAbsolute && actual >= expected - errorRangeAbsolute;
    }
}

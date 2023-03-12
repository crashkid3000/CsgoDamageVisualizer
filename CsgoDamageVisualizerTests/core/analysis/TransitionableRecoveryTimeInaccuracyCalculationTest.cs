using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsgoDamageVisualizerCore.analysis;
using CsgoDamageVisualizerCore.model;

namespace CsgoDamageVisualizerTests.core.analysis
{

    [TestClass]
    public class TransitionableRecoveryTimeInaccuracyCalculationTest
    {

        private TransitionableRecoveryTimeInaccuracyCalculation transitional_FiveseveN;
        private TransitionableRecoveryTimeInaccuracyCalculation transitional_Negev;

        public TransitionableRecoveryTimeInaccuracyCalculationTest()
        {
            CfgWeapon cfgFiveSeven = new CfgWeapon();
            CfgWeapon.SetValue(cfgFiveSeven, "__name", "fiveseven_prefab");
            CfgWeapon.SetValue(cfgFiveSeven, "cycletime", "0.15");
            CfgWeapon.SetValue(cfgFiveSeven, "spread", "2.0");
            CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyCrouch", "6.83");
            CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyStand", "9.1");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyJumpInitial", "78.79");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyJump", "109.0");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyLand", "0.188");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyLadder", "83.66");
            CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyFire", "25.0");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyMove", "136.01");
            CfgWeapon.SetValue(cfgFiveSeven, "recoveryTimeCrouch", "0.2");
            CfgWeapon.SetValue(cfgFiveSeven, "recoveryTimeStand", "0.2");
            //CfgWeapon.SetValue(cfgFiveSeven, "spreadAlt", "0.30");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyCrouchAlt", "3.05");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyStandAlt", "3.81");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyJumpAlt", "109.000");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyLandAlt", "0.188");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyLadderAlt", "138.758");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyFireAlt", "9.20");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyMoveAlt", "136.01");
            CfgWeapon.SetValue(cfgFiveSeven, "recoveryTimeCrouchFinal", "0.5");
            CfgWeapon.SetValue(cfgFiveSeven, "recoveryTimeStandFinal", "0.5");
            CfgWeapon.SetValue(cfgFiveSeven, "recoveryTransitionStartBullet", "0");
            CfgWeapon.SetValue(cfgFiveSeven, "recoveryTransitionEndBullet", "5");

            Weapon w = new Weapon(cfgFiveSeven);

            transitional_FiveseveN = new TransitionableRecoveryTimeInaccuracyCalculation(w);

            CfgWeapon cfgNegev = new CfgWeapon();
            CfgWeapon.SetValue(cfgNegev, "__name", "negev_prefab");
            CfgWeapon.SetValue(cfgNegev, "cycletime", "0.075");
            CfgWeapon.SetValue(cfgNegev, "spread", "2.0");
            CfgWeapon.SetValue(cfgNegev, "inaccuracyCrouch", "7.63");
            CfgWeapon.SetValue(cfgNegev, "inaccuracyStand", "10.17");
            //CfgWeapon.SetValue(cfgNegev, "inaccuracyJumpInitial", "118.27");
            //CfgWeapon.SetValue(cfgNegev, "inaccuracyJump", "292.23");
            //CfgWeapon.SetValue(cfgNegev, "inaccuracyLand", "0.398");
            //CfgWeapon.SetValue(cfgNegev, "inaccuracyLadder", "132.81");
            CfgWeapon.SetValue(cfgNegev, "inaccuracyFire", "30.0");
            //CfgWeapon.SetValue(cfgNegev, "inaccuracyMove", "159.14");
            CfgWeapon.SetValue(cfgNegev, "recoveryTimeCrouch", "0.250000");
            CfgWeapon.SetValue(cfgNegev, "recoveryTimeStand", "0.300000");
            //CfgWeapon.SetValue(cfgNegev, "spreadAlt", "0.30");
            //CfgWeapon.SetValue(cfgNegev, "inaccuracyCrouchAlt", "3.05");
            //CfgWeapon.SetValue(cfgNegev, "inaccuracyStandAlt", "3.81");
            //CfgWeapon.SetValue(cfgNegev, "inaccuracyJumpAlt", "109.000");
            //CfgWeapon.SetValue(cfgNegev, "inaccuracyLandAlt", "0.188");
            //CfgWeapon.SetValue(cfgNegev, "inaccuracyLadderAlt", "138.758");
            //CfgWeapon.SetValue(cfgNegev, "inaccuracyFireAlt", "9.20");
            //CfgWeapon.SetValue(cfgNegev, "inaccuracyMoveAlt", "136.01");
            CfgWeapon.SetValue(cfgNegev, "recoveryTimeCrouchFinal", "0.080000");
            CfgWeapon.SetValue(cfgNegev, "recoveryTimeStandFinal", "0.100000");
            CfgWeapon.SetValue(cfgNegev, "recoveryTransitionStartBullet", "9");
            CfgWeapon.SetValue(cfgNegev, "recoveryTransitionEndBullet", "12");

            Weapon w2 = new Weapon(cfgNegev);

            transitional_Negev = new TransitionableRecoveryTimeInaccuracyCalculation(w2);
            
        }

        [TestMethod]
        public void TransitionalAccuracy_Negev_WhileSprayingAndStanding()
        {
            //Arrange
            List<float> expectedInaccuracies = new List<float> { 12.17f, 29.04f, 38.53f, 43.86f, 46.86f, 48.55f, 49.50f, 50.03f, 50.33f, 50.50f, 44.77f, 34.38f, 21.45f, 19.16f, 18.75f, 18.67f, 18.66f, 18.66f, 18.66f, 18.66f};
            List<float> actualInaccuracies = new List<float>();
            float fireRate = 0.075f;
            InaccuracyCalculations ic = new InaccuracyCalculations();

            for (int i = 1; i <= expectedInaccuracies.Count; i++)
            {
                //Act
                //int i = bulletsFired;
                float inaccuracy = transitional_Negev.Calculate(fireRate, i);
                Console.WriteLine($"Shot {i} - Inaccuracy {Math.Round(inaccuracy, 2)} - Range {Math.Round(ic.CalculateAccurateRangeForHeadshot(inaccuracy), 2)}m");
                Console.WriteLine($"  Expected – {expectedInaccuracies[i - 1]}");

                //Adapt
                float roundedInaccuracy = (float)Math.Round(inaccuracy, 2);
                actualInaccuracies.Add(roundedInaccuracy);
                
            }
            //Assert
            CollectionAssert.AreEqual(expectedInaccuracies, actualInaccuracies);
        }

        [TestMethod]
        public void TransitionalInaccuracy_Negev_WhileTappingAndStanding()
        {
            //Arrange
            List<float> expectedInaccuracies = new List<float> { 12.17f, 16.57f, 17.22f, 17.31f, 17.33f, 17.33f, 17.33f, 17.33f, 17.33f, 17.33f, 17.33f, 17.33f, 17.33f, 17.33f, 17.33f };
            List<float> actualInaccuracies = new List<float>();
            float fireRate = 0.25f;
            InaccuracyCalculations ic = new InaccuracyCalculations();

            for (int i = 1; i <= expectedInaccuracies.Count; i++)
            {
                //Act
                //int i = bulletsFired;
                float inaccuracy = transitional_Negev.Calculate(fireRate, i);
                Console.WriteLine($"Shot {i} - Inaccuracy {Math.Round(inaccuracy, 2)} - Range {Math.Round(ic.CalculateAccurateRangeForHeadshot(inaccuracy), 2)}m");
                Console.WriteLine($"  Expected – {expectedInaccuracies[i - 1]}");

                //Adapt
                float roundedInaccuracy = (float)Math.Round(inaccuracy, 2);
                actualInaccuracies.Add(roundedInaccuracy);
                
            }
            //Assert
            CollectionAssert.AreEqual(expectedInaccuracies, actualInaccuracies);
        }

        [TestMethod]
        public void TransitionalAccuracy_FiveseveN_WhileSprayingAndStanding()
        {
            //Arrange
            List<float> expectedInaccuracies = new List<float>
                { 11.10f, 17.72f, 21.85f, 25.50f, 29.07f, 32.64f, 34.42f, 
            35.32f, 35.77f, 35.99f, 36.11f, 36.16f, 36.19f, 36.20f, 36.21f, 36.22f, 36.22f, 36.22f, 36.22f, 36.22f };
            List<float> actualInaccuracies = new List<float>();
            
            float fireRate = 0.15f;

            InaccuracyCalculations ic = new InaccuracyCalculations();
            for (int i = 1; i <= expectedInaccuracies.Count; i++)
            {
                //Act
                float inaccuracy = transitional_FiveseveN.Calculate(fireRate, i);
                Console.WriteLine($"Shot {i} - Inaccuracy {inaccuracy} - Range {Math.Round(ic.CalculateAccurateRangeForHeadshot(inaccuracy), 2)}m");
                
                float roundedInaccuracy = (float)Math.Round(inaccuracy, 2);
                actualInaccuracies.Add(roundedInaccuracy);
            }
            
            //Assert
            CollectionAssert.AreEqual(expectedInaccuracies, actualInaccuracies);
        }
        
        [TestMethod]
        public void TransitionalAccuracy_FiveseveN_WhileTappingAndStanding()
        {
            //Arrange
            List<float> expectedInaccuracies = new List<float>
                { 11.10f, 11.14f, 11.14f, 11.14f, 11.14f, 11.14f, 11.14f, 11.14f, 11.14f, 11.14f, 11.14f, 11.14f };
            List<float> actualInaccuracies = new List<float>();
            
            float fireRate = 0.55f;

            InaccuracyCalculations ic = new InaccuracyCalculations();
            for (int i = 1; i <= expectedInaccuracies.Count; i++)
            {
                //Act
                float inaccuracy = transitional_FiveseveN.Calculate(fireRate, i);
                Console.WriteLine($"Shot {i} - Inaccuracy {inaccuracy} - Range {Math.Round(ic.CalculateAccurateRangeForHeadshot(inaccuracy), 2)}m");
                
                float roundedInaccuracy = (float)Math.Round(inaccuracy, 2);
                actualInaccuracies.Add(roundedInaccuracy);
            }
            
            //Assert
            CollectionAssert.AreEqual(expectedInaccuracies, actualInaccuracies);
        }
        
    }
}

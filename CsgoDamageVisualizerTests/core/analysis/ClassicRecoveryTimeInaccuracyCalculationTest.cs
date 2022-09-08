using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsgoDamageVisualizerCore.analysis;
using CsgoDamageVisualizerCore.model;

namespace CsgoDamageVisualizerTests.core.analysis
{
    [TestClass]
    public class ClassicRecoveryTimeInaccuracyCalculationTest
    {
        private Weapon p2000;

        public ClassicRecoveryTimeInaccuracyCalculationTest()
        {
            CfgWeapon cfgP2000 = new CfgWeapon();
            CfgWeapon.SetValue(cfgP2000, "__name", "hkp2000_prefab");
            CfgWeapon.SetValue(cfgP2000, "cycletime", "0.17");
            CfgWeapon.SetValue(cfgP2000, "spread", "2.0");
            CfgWeapon.SetValue(cfgP2000, "inaccuracyCrouch", "3.68");
            CfgWeapon.SetValue(cfgP2000, "inaccuracyStand", "4.9");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyJumpInitial", "78.79");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyJump", "109.0");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyLand", "0.188");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyLadder", "83.66");
            CfgWeapon.SetValue(cfgP2000, "inaccuracyFire", "50.0");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyMove", "136.01");
            CfgWeapon.SetValue(cfgP2000, "recoveryTimeCrouch", "0.291277");
            CfgWeapon.SetValue(cfgP2000, "recoveryTimeStand", "0.349532");
            //CfgWeapon.SetValue(cfgFiveSeven, "spreadAlt", "0.30");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyCrouchAlt", "3.05");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyStandAlt", "3.81");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyJumpAlt", "109.000");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyLandAlt", "0.188");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyLadderAlt", "138.758");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyFireAlt", "9.20");
            //CfgWeapon.SetValue(cfgFiveSeven, "inaccuracyMoveAlt", "136.01");
            CfgWeapon.SetValue(cfgP2000, "recoveryTimeCrouchFinal", "0.29177");
            CfgWeapon.SetValue(cfgP2000, "recoveryTimeStandFinal", "0.349532");
            //CfgWeapon.SetValue(cfgP2000, "recoveryTransitionStartBullet", "0");
            //CfgWeapon.SetValue(cfgP2000, "recoveryTransitionEndBullet", "5");

            p2000 = new Weapon(cfgP2000);
        }

        [TestMethod]
        public void printInaccuracy_spraying()
        {
            int bulletsFired = 13;
            float userCycleTime = 0.17f;
            ClassicRecoveryTimeInaccuracyCalculation classic = new ClassicRecoveryTimeInaccuracyCalculation(p2000);

            for(int i = 1; i <= bulletsFired; i++)
            {
                float inaccuracy = classic.Calculate(userCycleTime, i);
                Debug.WriteLine($"Shot {i} - Inaccuracy {inaccuracy}");
            }
        }

        [TestMethod]
        public void Calculate_WhileSprayingAndStanding_Works()
        {
            int bulletsFired = 13;
            float userCycleTime = 0.17f;
            List<double> expectedValues = new List<double> { 6.90, 23.22, 28.54, 30.28, 30.84, 31.03, 31.09, 31.11, 31.12, 31.12, 31.12, 31.12, 31.12 }; //Values from BlackRetinas & SlothSuqadrons weapon spreadsheet
            List<double> actualRoundedValues = new List<double>();
            ClassicRecoveryTimeInaccuracyCalculation classic = new ClassicRecoveryTimeInaccuracyCalculation(p2000);

            for (int i = 1; i <= bulletsFired; i++)
            {
                float inaccuracy = classic.Calculate(userCycleTime, i);
                double rounded = Math.Round(inaccuracy, 2);
                actualRoundedValues.Add(rounded);
            }

            Assert.IsTrue(actualRoundedValues.SequenceEqual(expectedValues));
        }

        [TestMethod]
        public void Calculate_WhileSprayingAndCrouching_Works()
        {
            int bulletsFired = 13;
            float userCycleTime = 0.17f;
            List<double> expectedValues = new List<double> { 5.68, 18.72, 22.12, 23.01, 23.24, 23.30, 23.32, 23.32, 23.32, 23.32, 23.32, 23.32, 23.32 }; //Values from BlackRetinas & SlothSuqadrons weapon spreadsheet
            List<double> actualRoundedValues = new List<double>();
            ClassicRecoveryTimeInaccuracyCalculation classicCrouch = new ClassicRecoveryTimeInaccuracyCalculation(p2000, StationaryInaccuracy.CROUCHING);

            for (int i = 1; i <= bulletsFired; i++)
            {
                float inaccuracy = classicCrouch.Calculate(userCycleTime, i);
                double rounded = Math.Round(inaccuracy, 2);
                actualRoundedValues.Add(rounded);
            }

            Assert.IsTrue(actualRoundedValues.SequenceEqual(expectedValues));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsgoDamageVisualizerCore.analysis;
using CsgoDamageVisualizerCore.model;
using CsgoDamageVisualizerCore.loader.model;

namespace CsgoDamageVisualizerTests.core.analysis
{
    [TestClass]
    public class InaccuracyAnalysisTest
    {

        /*
         * Values in this test are all gathered from BlackRetinas & SlothSquadrons Weapon Spreadsheet
         * https://docs.google.com/spreadsheets/d/11tDzUNBq9zIX6_9Rel__fdAUezAQzSnh5AVYzCP060c/edit#gid=0
         *
         */

        private InaccuracyAnalysis inaccuracyAnalysis = new InaccuracyAnalysis(new Weapon());

        [TestInitialize]
        public void setUp()
        {
            CfgWeapon cfgSg556 = new CfgWeapon();
            CfgWeapon.SetValue(cfgSg556, "__name", "sg553_prefab");
            CfgWeapon.SetValue(cfgSg556, "spread", "0.6");
            CfgWeapon.SetValue(cfgSg556, "inaccuracyCrouch", "3.81");
            CfgWeapon.SetValue(cfgSg556, "inaccuracyStand", "5.81");
            CfgWeapon.SetValue(cfgSg556, "inaccuracyJumpInitial", "78.79");
            CfgWeapon.SetValue(cfgSg556, "inaccuracyJump", "109.0");
            CfgWeapon.SetValue(cfgSg556, "inaccuracyLand", "0.188");
            CfgWeapon.SetValue(cfgSg556, "inaccuracyLadder", "83.66");
            CfgWeapon.SetValue(cfgSg556, "inaccuracyFire", "7.95");
            CfgWeapon.SetValue(cfgSg556, "inaccuracyMove", "136.01");
            CfgWeapon.SetValue(cfgSg556, "recoveryTimeCrouch", "0.379204");
            CfgWeapon.SetValue(cfgSg556, "recoveryTimeStand", "0.452886");
            CfgWeapon.SetValue(cfgSg556, "spreadAlt", "0.30");
            CfgWeapon.SetValue(cfgSg556, "inaccuracyCrouchAlt", "3.05");
            CfgWeapon.SetValue(cfgSg556, "inaccuracyStandAlt", "3.81");
            CfgWeapon.SetValue(cfgSg556, "inaccuracyJumpAlt", "109.000");
            CfgWeapon.SetValue(cfgSg556, "inaccuracyLandAlt", "0.188");
            CfgWeapon.SetValue(cfgSg556, "inaccuracyLadderAlt", "138.758");
            CfgWeapon.SetValue(cfgSg556, "inaccuracyFireAlt", "9.20");
            CfgWeapon.SetValue(cfgSg556, "inaccuracyMoveAlt", "136.01");
            CfgWeapon.SetValue(cfgSg556, "recoveryTimeCrouchFinal", "0.379204");
            CfgWeapon.SetValue(cfgSg556, "recoveryTimeStandFinal", "0.452886");

            Weapon sg556 = new Weapon(cfgSg556);

            inaccuracyAnalysis = new InaccuracyAnalysis(sg556);
        }

        [TestMethod]
        public void StandingInaccuracyWorks()
        {
            float expectedValue = 6.41f;
            Assert.AreEqual(expectedValue, inaccuracyAnalysis.StandingInaccuracy);
        }

        [TestMethod]
        public void StandingInaccuracyAltWorks()
        {
            float expectedValue = 4.11f;
            Assert.AreEqual(expectedValue, inaccuracyAnalysis.StandingInaccuracyAlt);
        }

        [TestMethod]
        public void CrouchingInaccuracyWorks()
        {
            float expectedValue = 4.41f;
            Assert.AreEqual(expectedValue, inaccuracyAnalysis.CrouchingInaccuracy);
        }

        [TestMethod]
        public void CrouchingInaccuracyAltWorks()
        {
            float expectedValue = 3.35f;
            Assert.AreEqual(expectedValue, inaccuracyAnalysis.CrouchingInaccuracyAlt);
        }

        [TestMethod]
        public void MovingInaccuracyWorks()
        {
            float expectedValue = 142.42f;
            Assert.AreEqual(expectedValue, inaccuracyAnalysis.MovementInaccuracy);
        }

        [TestMethod]
        public void MovingInaccuracyAltWorks()
        {
            float expectedValue = 140.12f;
            Assert.AreEqual(expectedValue, inaccuracyAnalysis.MovementInaccuracyAlt);
        }

        [TestMethod]
        public void LadderInaccuracyWorks()
        {
            float expectedValue = 167.92f;
            Assert.AreEqual(expectedValue, (float)Math.Round(inaccuracyAnalysis.LadderInaccuracy, 2));
        }
        [TestMethod]

        public void LadderInaccuracyAltWorks()
        {
            float expectedValue = 277.82f;
            Assert.AreEqual(expectedValue, (float)Math.Round(inaccuracyAnalysis.LadderInaccuracyAlt, 2));
        }

        [TestMethod]
        public void JumpApexInaccuracyWorks()
        {
            float expectedValue = 115.41f;
            Assert.AreEqual(expectedValue, inaccuracyAnalysis.JumpingApexInaccuracy);
        }
        [TestMethod]

        public void JumpApexInaccuracyAltWorks()
        {
            float expectedValue = 113.11f;
            Assert.AreEqual(expectedValue, inaccuracyAnalysis.JumpingApexInaccuracyAlt);
        }

        [TestMethod]
        public void JumpInitialInaccuracyWorks()
        {
            float expectedValue = 194.2f;
            Assert.AreEqual(expectedValue, (float)Math.Round(inaccuracyAnalysis.JumpingInitialInaccuracy, 2));
        }
        [TestMethod]

        public void JumpInitialInaccuracyAltWorks()
        {
            float expectedValue = 109.3f;
            Assert.AreEqual(expectedValue, inaccuracyAnalysis.JumpingInitialInaccuracyAlt);
        }

    }
}

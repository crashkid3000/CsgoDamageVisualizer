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

        private TransitionableRecoveryTimeInaccuracyCalculation transitional;
        private ClassicRecoveryTimeInaccuracyCalculation classic;

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

            transitional = new TransitionableRecoveryTimeInaccuracyCalculation(w);
            classic = new ClassicRecoveryTimeInaccuracyCalculation(w);
        }

        [TestMethod]
        public void a()
        {
            int bulletsFired = 15;

            float fireRate = 0.15f;
            float standingInaccuracy = 11.0f;
            float inaccuracy = transitional.Calculate(fireRate, bulletsFired);
            Console.WriteLine($"After Bullet {bulletsFired} - Extra Inaccuracy {inaccuracy} - Total Inaccuracy {inaccuracy + standingInaccuracy}");
            
        }

        [TestMethod]
        public void classicInaccuracy()
        {
            int bulletsFired = 15;
            float fireRate = 0.15f;
            float standingInaccuracy = 11.0f;
            float inaccuracy = classic.Calculate(fireRate, bulletsFired);
            Console.WriteLine($"After Bullet {bulletsFired} - Extra Inaccuracy {inaccuracy} - Total Inaccuracy {inaccuracy + standingInaccuracy}");
        }


    }
}

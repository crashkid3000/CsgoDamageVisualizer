using CsgoDamageVisualizerCore.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsgoDamageVisualizerCore.analysis;

namespace CsgoDamageVisualizerTests.core.analysis
{

    [TestClass]
    public class MiscAnalysisTest
    {
        private Weapon weapon = new Weapon();
        private MiscAnalysis? analysis;

        [TestInitialize]
        public void setUp()
        {
            this.weapon = createWeapon();
            this.analysis = new MiscAnalysis(weapon);
        }
    
    
        private Weapon createWeapon()
        {
            Weapon retVal = new Weapon();
            typeof(Weapon).GetProperty(nameof(Weapon.MaxPlayerSpeed)).SetValue(retVal, 240);
            typeof(Weapon).GetProperty(nameof(Weapon.MaxPlayerSpeedAlt)).SetValue(retVal, 125);
            return retVal;
        }

        [TestMethod]
        public void MaxPlayerSpeedRelative_Works() {
            float expectedResult = weapon.MaxPlayerSpeed / MiscAnalysis.KnifeSpeed;
            Assert.AreEqual(expectedResult, analysis.MaxPlayerSpeedRelative);
        }

        [TestMethod]
        public void MaxPlayerSpeedAltRelative_Works()
        {
            float expectedResult = weapon.MaxPlayerSpeedAlt / MiscAnalysis.KnifeSpeed;
            Assert.AreEqual(expectedResult, analysis.MaxPlayerSpeedAltRelative);
        }
    }
}

using CsgoDamageVisualizerCore.analysis;
using CsgoDamageVisualizerCore.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerTests.core.analysis
{
    [TestClass]
    public class EconomyAnalysisTest
    {
        private Weapon weapon = new Weapon();
        private EconomyAnalysis? economyAnalysis;

        private Weapon createWeapon()
        {
            Weapon retVal = new Weapon();
            typeof(Weapon).GetProperty(nameof(Weapon.KillAward)).SetValue(retVal, 400);
            typeof(Weapon).GetProperty(nameof(Weapon.InGamePrice)).SetValue(retVal, 3750);
            return retVal;
        }

        [TestInitialize]
        public void setUp()
        {
            this.weapon = createWeapon();
            this.economyAnalysis = new EconomyAnalysis(weapon);
        }

        [TestMethod]
        public void KillAwardRelative_Works()
        {
            float expected = weapon.KillAward / (float)EconomyAnalysis.DefaultKillAward;
            Assert.AreEqual(expected, economyAnalysis.KillAwardRelative);
        }

        [TestMethod]
        public void KillsUntilAmortization_Works()
        {
            int expected = (int)Math.Ceiling(weapon.InGamePrice / (double)weapon.KillAward);
            Assert.AreEqual(expected, economyAnalysis.KillsUntilAmortized);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using CsgoDamageVisualizerCore.model;

namespace CsgoDamageVisualizerTests.core.model
{
    [TestClass]
    public class WeaponTest
    {

        private Dictionary<string, string> someCfgWeaponConfig = new Dictionary<string, string>();
        private Dictionary<string , string> someSubCfgWeaponConfig = new Dictionary<string , string>();
        private static readonly string DAMAGE_KEY = "damage";
        private static readonly string KILLAWARD_KEY = "killAward";
        private static readonly string ZOOMLEVELS_KEY = "zoomLevels";
        private static readonly string ZOOMFOV1_KEY = "zoomFov1";
        private static readonly string INACCURACYJUMP_KEY = "inaccuracyJump";
        private static readonly string INACCURACYJUMPINITIAL_KEY = "inaccuracyJumpInitial";
        private static readonly string NAME_KEY = "__name";
        private static readonly string PREFAB_STRING = "prefab";
        private static readonly string ITEMCLASS_STRING = "item_class";

        [TestInitialize] 
        public void SetUp()
        {
            someCfgWeaponConfig.Clear();
            someCfgWeaponConfig[DAMAGE_KEY] = "33";
            someCfgWeaponConfig[KILLAWARD_KEY] = "600";
            someCfgWeaponConfig[ZOOMLEVELS_KEY] = "1";
            someCfgWeaponConfig[ZOOMFOV1_KEY] = "60";
            someCfgWeaponConfig[INACCURACYJUMP_KEY] = "20";
            someCfgWeaponConfig[INACCURACYJUMPINITIAL_KEY] = "40";
            someCfgWeaponConfig[NAME_KEY] = "weapon_somegun_prefab";
            someCfgWeaponConfig[PREFAB_STRING] = "machinegun";
            someCfgWeaponConfig[ITEMCLASS_STRING] = someCfgWeaponConfig[NAME_KEY];

            someSubCfgWeaponConfig.Clear();
            someSubCfgWeaponConfig[DAMAGE_KEY] = "30";
            someSubCfgWeaponConfig[KILLAWARD_KEY] = "900";
            someSubCfgWeaponConfig[ITEMCLASS_STRING] = someCfgWeaponConfig[NAME_KEY];
            someSubCfgWeaponConfig[NAME_KEY] = "weapon_somegun_loudencer_prefab";

        }

        [TestMethod]
        public void Ctor_ConversionWorks()
        {
            CfgWeapon cfgWeapon = createSomeCfgWeapon();
            Weapon weapon = new Weapon(cfgWeapon);

            Assert.AreEqual(weapon.Name, someCfgWeaponConfig[NAME_KEY].Substring(0, someCfgWeaponConfig[NAME_KEY].Length - "_prefab".Length));
            Assert.AreEqual(weapon.KillAward, Convert.ToInt32(someCfgWeaponConfig[KILLAWARD_KEY]));
        }

        private CfgWeapon createSomeCfgWeapon()
        {
            CfgWeapon retVal = new CfgWeapon();
            CfgWeapon.SetValue(retVal, DAMAGE_KEY, someCfgWeaponConfig[DAMAGE_KEY]);
            CfgWeapon.SetValue(retVal, KILLAWARD_KEY, someCfgWeaponConfig[KILLAWARD_KEY]);
            CfgWeapon.SetValue(retVal, ZOOMLEVELS_KEY, someCfgWeaponConfig[ZOOMLEVELS_KEY]);
            CfgWeapon.SetValue(retVal, ZOOMFOV1_KEY, someCfgWeaponConfig[ZOOMFOV1_KEY]);
            CfgWeapon.SetValue(retVal, INACCURACYJUMP_KEY, someCfgWeaponConfig[INACCURACYJUMP_KEY]);
            CfgWeapon.SetValue(retVal, INACCURACYJUMPINITIAL_KEY, someCfgWeaponConfig[INACCURACYJUMPINITIAL_KEY]);
            CfgWeapon.SetValue(retVal, NAME_KEY, someCfgWeaponConfig[NAME_KEY]);
            CfgWeapon.SetValue(retVal, PREFAB_STRING, someCfgWeaponConfig[PREFAB_STRING]);
            return retVal;
        }

        private CfgWeapon createSomeCfgWeaponSubConfig()
        {
            CfgWeapon retVal = new CfgWeapon();
            CfgWeapon.SetValue(retVal, DAMAGE_KEY, someSubCfgWeaponConfig[DAMAGE_KEY]);
            CfgWeapon.SetValue(retVal, KILLAWARD_KEY, someSubCfgWeaponConfig[KILLAWARD_KEY]);
            CfgWeapon.SetValue(retVal, ITEMCLASS_STRING, someSubCfgWeaponConfig[ITEMCLASS_STRING]);
            CfgWeapon.SetValue(retVal, NAME_KEY, someSubCfgWeaponConfig[NAME_KEY]);
            return retVal;
        }
    }
}

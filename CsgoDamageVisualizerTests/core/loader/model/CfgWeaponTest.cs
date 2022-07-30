using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerTests.core.loader.model
{
    [TestClass]
    public class CfgWeaponTest
    {

        [TestMethod]
        public void GetAttributeNameMap_createsAttributeNameMap()
        {
            IReadOnlyDictionary<string, string> attributeMap = CfgWeapon.GetAttributeNameMap();

            Assert.IsNotNull(attributeMap);
            Assert.IsTrue(attributeMap.Count > 0);
        }

        [TestMethod]
        public void GetCastTypeMap_createsCastTypeMap()
        {
            IReadOnlyDictionary<string, Type> castTypeMap = CfgWeapon.GetCastTypeMap();

            Assert.IsNotNull(castTypeMap);
            Assert.IsTrue(castTypeMap.Count > 0);
        }


    }
}

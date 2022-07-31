using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsgoDamageVisualizerTests.core.loader.__testdriver;
using CsgoDamageVisualizerCore.loader;

namespace CsgoDamageVisualizerTests.core.loader
{
    [TestClass]
    public class ICsgoDamageVisualizerConfigTest
    {

        private ICsgoDamageVisualizerConfig? _config;

        [TestInitialize]
        public void TestInitialize() {
            ICsgoDamageVisualizerConfig.ConfigInstanceType = typeof(ICsgoDamageVisualizerConfigTestImpl);
            _config = ICsgoDamageVisualizerConfig.Instance; 
        }

        [TestMethod]
        public void Instace_objectCreationWorks()
        {
            Assert.IsNotNull(_config);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsgoDamageVisualizerTests.core.loader.__testdriver;
using CsgoDamageVisualizerCore.loader;
using CsgoDamageVisualizerCore.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        #region Instance creation tests

        [TestMethod]
        [Description("With a good setup, calling get creates the defined isntance")]
        public void Instace_objectCreationWorks()
        {
            Assert.IsNotNull(_config);
        }

        [TestMethod]
        [Description("With a good setup, the test subject only creates one instance")]
        public void Instance_trueSingletonCreated()
        {
            ICsgoDamageVisualizerConfig config2 = ICsgoDamageVisualizerConfig.Instance;
            Assert.ReferenceEquals(_config, config2);
        }

        [TestMethod]
        [Description("With a good setup including a set ConfigIsntanceType, that type is returned upon calling get")]
        public void ConfigInstanceType_SetCorrectType()
        {
            Type? expectedType = typeof(ICsgoDamageVisualizerConfigTestImpl);
            Type? configType = ICsgoDamageVisualizerConfig.ConfigInstanceType;
            Assert.AreEqual(configType, expectedType);
        }

        #endregion

        #region Loose coupling tests

        [TestMethod]
        [Description("With a good setup, the instance returns the defined cfg location")]
        public void GetCsgoInstallDir_ReturnsDefinedValueOfImpl()
        {
            Uri baseDir = new HelperMethods().GetProjectBaseDir(HelperMethods.Project.TEST);
            Uri definedUri = new Uri(baseDir, @"resources/core");
            Uri installDir = ICsgoDamageVisualizerConfig.Instance.GetCsgoInstallDir();
            Assert.AreEqual(definedUri, installDir);
        }

        #endregion

    }
}

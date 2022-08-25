using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

using CsgoDamageVisualizerCore.loader;
using CsgoDamageVisualizerTests.core.loader.__testdriver;

namespace CsgoDamageVisualizerTests.core.loader
{
    [TestClass]
    public class CfgLoaderTest
    {

        private CfgLoader? loader;

        [TestInitialize]
        public void refresh()
        {
            if(ICsgoDamageVisualizerConfig.ConfigInstanceType == null)
            {
                ICsgoDamageVisualizerConfig.ConfigInstanceType = typeof(ICsgoDamageVisualizerConfigTestImpl);
            }

            loader = new CfgLoader();
        }

        [TestMethod]
        public void LoadCfgFileAsync_LoadsLines()
        {
            Task<string[]> lines = loader.LoadCfgFileAsync();
            Console.WriteLine("Reading file");
            while (!lines.IsCompleted)
            {
                Console.Write(".");
                Thread.Sleep(5);
            }
            Console.WriteLine();
            Assert.IsNotNull(lines.Result);
        }

    }
}

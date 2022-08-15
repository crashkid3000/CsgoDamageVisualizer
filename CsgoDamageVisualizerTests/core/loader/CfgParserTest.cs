using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsgoDamageVisualizerCore.loader;

namespace CsgoDamageVisualizerTests.core.loader
{
    [TestClass]
    public class CfgParserTest
    {

        CfgParser? cfgParser;

        [TestInitialize]
        public void startUp()
        {
            cfgParser = new CfgParser();
        }


        [TestMethod]
        public void GetAttributeNameAndValueFromLine_WithWellFormedLine_ReturnsAttributeNameAndValue()
        {
            KeyValuePair<string, string> attribute = new KeyValuePair<string, string>("a key", "a keyhole");
            string testString = $"    \"{attribute.Key}\"       \"{attribute.Value}\"";
            Assert.AreEqual(attribute, cfgParser.GetAttributeNameAndValueFromLine(testString));
        }
    }
}

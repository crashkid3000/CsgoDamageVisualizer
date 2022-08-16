using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsgoDamageVisualizerCore.loader;
using CsgoDamageVisualizerTests.core.loader.__testdriver;

namespace CsgoDamageVisualizerTests.core.loader
{
    [TestClass]
    public class CfgParserTest
    {

        CfgParser cfgParser = new CfgParser();

        [TestInitialize]
        public void startUp()
        {
            ICsgoDamageVisualizerConfig.ConfigInstanceType = typeof(ICsgoDamageVisualizerConfigTestImpl);
            cfgParser = new CfgParser();
        }

        #region GetAttributeNameAndValueFromLine tests

        [TestMethod]
        public void GetAttributeNameAndValueFromLine_WithWellFormedLineAndSecondPairOfQuotes_ReturnsAttributeNameAndValue()
        {
            KeyValuePair<string, string> attribute = new KeyValuePair<string, string>("a key", "a keyhole");
            string testString = $"    \"{attribute.Key}\"       \"{attribute.Value}\"";
            Assert.AreEqual(attribute, cfgParser.GetAttributeNameAndValueFromLine(testString));
        }

        [TestMethod]
        public void GetAttributeNameAndValueFromLine_WithWellFormedLineButWithoutSecondPairOfQuotes_ReturnsAttributeNameAndValue()
        {
            KeyValuePair<string, string> attribute = new KeyValuePair<string, string>("a key", "a keyhole");
            string testString = $"    \"{attribute.Key}\"       {attribute.Value}";
            Assert.AreEqual(attribute, cfgParser.GetAttributeNameAndValueFromLine(testString));
        }

        [TestMethod]
        public void GetAttributeNameAndValueFromLine_WithWellFormedLineWithoutIndentation_ReturnsAttributeNameAndValue()
        {
            KeyValuePair<string, string> attribute = new KeyValuePair<string, string>("a key", "a keyhole");
            string testString = $"\"{attribute.Key}\"                  \"{attribute.Value}\"";
            Assert.AreEqual(attribute, cfgParser.GetAttributeNameAndValueFromLine(testString));
        }

        [TestMethod]
        public void GetAttributeNameAndValueFromLine_WithoutEndingQuotesForKey_ReturnsEmptyKeyValuePair()
        {
            KeyValuePair<string, string> attribute = new KeyValuePair<string, string>("a key", "a keyhole");
            string testString = $"{attribute.Key}\"                  \"{attribute.Value}\"";
            Assert.AreEqual(new KeyValuePair<string, string>(), cfgParser.GetAttributeNameAndValueFromLine(testString));
        }

        [TestMethod]
        public void GetAttributeNameAndValueFromLine_WithoutAnyQuotes_ReturnsEmptyKeyValuePair()
        {
            KeyValuePair<string, string> attribute = new KeyValuePair<string, string>("a key", "a keyhole");
            string testString = $"{attribute.Key}                  {attribute.Value}";
            Assert.AreEqual(new KeyValuePair<string, string>(), cfgParser.GetAttributeNameAndValueFromLine(testString));
        }

        #endregion

        [TestMethod]
        public void ParseCfgFile_WithTestDriverWorks()
        {
            IReadOnlyDictionary<string, CfgWeapon> retVal = cfgParser.ParseCfgFile();
            Assert.IsTrue(retVal.Count > 0);
        }

    }
}

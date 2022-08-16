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

        CfgParser cfgParser = new CfgParser();

        [TestInitialize]
        public void startUp()
        {
            cfgParser = new CfgParser();
        }


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

    }
}

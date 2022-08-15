using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsgoDamageVisualizerCore.utils;

namespace CsgoDamageVisualizerTests.core.utils
{
    [TestClass]
    public class ExtensionMethodsTest
    {
        [TestMethod]
        public void String_GetIndentationLevel_WithNoIndentation_ReturnsZero()
        {
            const int expectedIndentationLevel = 0;
            const string input = "this string has no indentation";
            Assert.AreEqual(input.GetSpaceIndentationLevel(), expectedIndentationLevel);
        }

        [TestMethod] 
        public void String_GetIndentationLevel_WithFourSpaces_ReturnsFour()
        {
            const int expectedIndentationLevel = 4;
            const string input = "    this string has no indentation";
            Assert.AreEqual(input.GetSpaceIndentationLevel(), expectedIndentationLevel);
        }

        [TestMethod]
        public void String_GetIndentationLevel_WithTwoTabs_ReturnsZero()
        {
            const int expectedIndentationLevel = 0;
            const string input = "\t\tthis string has no indentation";
            Assert.AreEqual(input.GetSpaceIndentationLevel(), expectedIndentationLevel);
        }

        [TestMethod]
        public void String_GetIndentationLevel_WithTwoTabsAndThreeSpaces_ReturnsThree()
        {
            const int expectedIndentationLevel = 3;
            const string input = " \t \t this string has no indentation";
            Assert.AreEqual(input.GetSpaceIndentationLevel(), expectedIndentationLevel);
        }
    }
}

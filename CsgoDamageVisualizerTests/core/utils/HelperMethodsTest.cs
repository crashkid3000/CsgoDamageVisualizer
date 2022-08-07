using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsgoDamageVisualizerCore.extensions;
using CsgoDamageVisualizerCore.utils;
using System.Text.RegularExpressions;

namespace CsgoDamageVisualizerTests.core.utils
{
    [TestClass]
    public class HelperMethodsTest
    {
        internal static bool? isLocalMachine;

        [TestInitialize]
        public void setup()
        {
            Uri projectBaseDir = new HelperMethods().GetProjectBaseDir(HelperMethods.Project.TEST);
            string csgoDamageVisualizerDir = Directory.GetParent(projectBaseDir.AbsolutePath).FullName;
            string testFilePath = Path.Combine(csgoDamageVisualizerDir, "dontDelete.txt");
            isLocalMachine = File.Exists(testFilePath);
        }


        [TestClass]
        public class GetProjectBaseDir
        {
            private const string baseDir = @"C:\\Users\\\s+\\source\\repos\\CsgoDamageVisualizer\";

            [TestMethod]
            public void GetProjectBaseDir_WithCore_RetunsCorrectDirectory()
            {
                string expectedPath = baseDir + "CsgoDamageVisualizerCore";
                string actualPath = new HelperMethods().GetProjectBaseDir(HelperMethods.Project.CORE).AbsolutePath;
                if(HelperMethodsTest.isLocalMachine ?? false)
                {
                    Assert.IsTrue(Regex.IsMatch(actualPath, expectedPath));
                }
                else
                {
                    if (!expectedPath.Equals(actualPath))
                    {
                        Console.WriteLine($"{nameof(GetProjectBaseDir_WithCore_RetunsCorrectDirectory)}: Mismatch between expected and actual path detected: {nameof(HelperMethods.Project.CORE)}");
                    }
                }
            }

            [TestMethod]
            public void GetProjectBaseDir_WithDesktop_RetunsCorrectDirectory()
            {
                string expectedPath = baseDir + "CSgtoDamageVisualizer";
                string actualPath = new HelperMethods().GetProjectBaseDir(HelperMethods.Project.DESKTOP).AbsolutePath;
                if (HelperMethodsTest.isLocalMachine ?? false)
                {
                    Assert.IsTrue(Regex.IsMatch(actualPath, expectedPath));
                }
                else
                {
                    if (!expectedPath.Equals(actualPath))
                    {
                        Console.WriteLine($"{nameof(GetProjectBaseDir_WithCore_RetunsCorrectDirectory)}: Mismatch between expected and actual path detected: {nameof(HelperMethods.Project.DESKTOP)}");
                    }
                }
            }

            [TestMethod]
            public void GetProjectBaseDir_WithAspx_RetunsCorrectDirectory()
            {
                string expectedPath = baseDir + "CsgoDamageVisualizerWeb";
                string actualPath = new HelperMethods().GetProjectBaseDir(HelperMethods.Project.ASPX).AbsolutePath;
                if (HelperMethodsTest.isLocalMachine ?? false)
                {
                    Assert.IsTrue(Regex.IsMatch(actualPath, expectedPath));
                }
                else
                {
                    if (!expectedPath.Equals(actualPath))
                    {
                        Console.WriteLine($"{nameof(GetProjectBaseDir_WithCore_RetunsCorrectDirectory)}: Mismatch between expected and actual path detected: {nameof(HelperMethods.Project.ASPX)}");
                    }
                }
            }

            [TestMethod]
            public void GetProjectBaseDir_WithTest_RetunsCorrectDirectory()
            {
                string expectedPath = baseDir + "CsgoDamageVisualizerTests";
                string actualPath = new HelperMethods().GetProjectBaseDir(HelperMethods.Project.TEST).AbsolutePath;
                if (HelperMethodsTest.isLocalMachine ?? false)
                {
                    Assert.IsTrue(Regex.IsMatch(actualPath, expectedPath));
                }
                else
                {
                    if (!expectedPath.Equals(actualPath))
                    {
                        Console.WriteLine($"{nameof(GetProjectBaseDir_WithCore_RetunsCorrectDirectory)}: Mismatch between expected and actual path detected: {nameof(HelperMethods.Project.TEST)}");
                    }
                }
            }

            [TestMethod]
            public void GetProjectBaseDir_WithSuper_RetunsCorrectDirectory()
            {
                string expectedPath = baseDir;
                string actualPath = new HelperMethods().GetProjectBaseDir(HelperMethods.Project.SUPER).AbsolutePath;
                if (HelperMethodsTest.isLocalMachine ?? false)
                {
                    Assert.IsTrue(Regex.IsMatch(actualPath, expectedPath));
                }
                else
                {
                    if (!expectedPath.Equals(actualPath))
                    {
                        Console.WriteLine($"{nameof(GetProjectBaseDir_WithCore_RetunsCorrectDirectory)}: Mismatch between expected and actual path detected: {nameof(HelperMethods.Project.SUPER)}");
                    }
                }
            }
        }
    }
}

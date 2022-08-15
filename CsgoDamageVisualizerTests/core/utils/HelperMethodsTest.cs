using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsgoDamageVisualizerCore.utils;
using System.Text.RegularExpressions;

namespace CsgoDamageVisualizerTests.core.utils
{
    [TestClass]
    public class HelperMethodsTest
    {
        private bool? isLocalMachine;

        [TestInitialize]
        public void setup()
        {
            Uri projectBaseDir = new HelperMethods().GetProjectBaseDir(HelperMethods.Project.SUPER);
            string testFilePath = projectBaseDir.AbsolutePath + "/dontDelete.txt";
            isLocalMachine = File.Exists(testFilePath);
            Console.WriteLine("Running tests " + (isLocalMachine ?? false ? "" : "NOT ") + "on the local machine");
        }


        
            private const string baseDir = @"C:\/Users\/\w+\/source\/repos\/CsgoDamageVisualizer\/";

            [TestMethod]
            public void GetProjectBaseDir_WithCore_RetunsCorrectDirectory()
            {
                string expectedPath = baseDir + "CsgoDamageVisualizerCore";
                string actualPath = new HelperMethods().GetProjectBaseDir(HelperMethods.Project.CORE).AbsolutePath;
                if(isLocalMachine ?? false)
                {
                    Assert.IsTrue(Regex.IsMatch(actualPath, expectedPath), $"{actualPath} doesnt match to {expectedPath}");
                }
                else
                {
                    if (!Regex.IsMatch(actualPath, expectedPath))
                    {
                        Console.Error.WriteLine($"{nameof(GetProjectBaseDir_WithCore_RetunsCorrectDirectory)}: Mismatch between expected and actual path detected: {nameof(HelperMethods.Project.CORE)}");
                    }
                }
            }

            [TestMethod]
            public void GetProjectBaseDir_WithDesktop_RetunsCorrectDirectory()
            {
                string expectedPath = baseDir + "CSgtoDamageVisualizer";
                string actualPath = new HelperMethods().GetProjectBaseDir(HelperMethods.Project.DESKTOP).AbsolutePath;
                if (isLocalMachine ?? false)
                {
                    Assert.IsTrue(Regex.IsMatch(actualPath, expectedPath), $"{actualPath} doesnt match to {expectedPath}");
                }
                else
                {
                    if (!Regex.IsMatch(actualPath, expectedPath))
                    {
                        Console.Error.WriteLine($"{nameof(GetProjectBaseDir_WithCore_RetunsCorrectDirectory)}: Mismatch between expected and actual path detected: {nameof(HelperMethods.Project.DESKTOP)}");
                    }
                }
            }

            [TestMethod]
            public void GetProjectBaseDir_WithAspx_RetunsCorrectDirectory()
            {
                string expectedPath = baseDir + "CsgoDamageVisualizerWeb";
                string actualPath = new HelperMethods().GetProjectBaseDir(HelperMethods.Project.ASPX).AbsolutePath;
                if (isLocalMachine ?? false)
                {
                    Assert.IsTrue(Regex.IsMatch(actualPath, expectedPath), $"{actualPath} doesnt match to {expectedPath}");
                }
                else
                {
                    if (!Regex.IsMatch(actualPath, expectedPath))
                    {
                        Console.Error.WriteLine($"{nameof(GetProjectBaseDir_WithCore_RetunsCorrectDirectory)}: Mismatch between expected and actual path detected: {nameof(HelperMethods.Project.ASPX)}");
                    }
                }
            }

            [TestMethod]
            public void GetProjectBaseDir_WithTest_RetunsCorrectDirectory()
            {
                string expectedPath = baseDir + "CsgoDamageVisualizerTests";
                string actualPath = new HelperMethods().GetProjectBaseDir(HelperMethods.Project.TEST).AbsolutePath;
                if (isLocalMachine ?? false)
                {
                    Assert.IsTrue(Regex.IsMatch(actualPath, expectedPath), $"{actualPath} doesnt match to {expectedPath}");
                }
                else
                {
                    if (!Regex.IsMatch(actualPath, expectedPath))
                    {
                        Console.Error.WriteLine($"{nameof(GetProjectBaseDir_WithCore_RetunsCorrectDirectory)}: Mismatch between expected and actual path detected: {nameof(HelperMethods.Project.TEST)}");
                    }
                }
            }

            [TestMethod]
            public void GetProjectBaseDir_WithSuper_RetunsCorrectDirectory()
            {
                Console.WriteLine("Running tests " + (isLocalMachine ?? false ? "" : "NOT ") + "on the local machine");
                string expectedPath = baseDir.Remove(baseDir.Length - 2);
                string actualPath = new HelperMethods().GetProjectBaseDir(HelperMethods.Project.SUPER).AbsolutePath;
                if (isLocalMachine ?? false)
                {
                    Assert.IsTrue(Regex.IsMatch(actualPath, expectedPath), $"{actualPath} doesnt match to {expectedPath}");
                }
                else
                {
                    if (!Regex.IsMatch(actualPath, expectedPath))
                    {
                        Console.Error.WriteLine($"{nameof(GetProjectBaseDir_WithCore_RetunsCorrectDirectory)}: Mismatch between expected and actual path detected: {nameof(HelperMethods.Project.SUPER)}");
                    }
                }
            }
        }
    
}

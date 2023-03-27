using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using CsgoDamageVisualizerCore.loader;
using CsgoDamageVisualizerCore.utils;

namespace CsgoDamageVisualizerTests.core.loader.__testdriver
{
    internal class Source2ConfigTestImpl : ICsgoDamageVisualizerConfig
    {

        public static ICsgoDamageVisualizerConfig GetInstance()
        {
            if (ICsgoDamageVisualizerConfig.ConfigInstanceType == null)
            {
                ICsgoDamageVisualizerConfig.ConfigInstanceType = typeof(ICsgoDamageVisualizerConfigTestImpl);
            }
            return ICsgoDamageVisualizerConfig.Instance;
        }

        public Uri GetCsgoInstallDir()
        {
            Uri baseDir = new HelperMethods().GetProjectBaseDir(HelperMethods.Project.TEST);
            string combined = Path.Combine(baseDir.AbsolutePath, "resources/core/s2");
            Uri retVal = new Uri(combined);
            return retVal;
        }
    }
}

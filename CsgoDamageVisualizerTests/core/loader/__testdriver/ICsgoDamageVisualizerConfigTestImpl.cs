using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsgoDamageVisualizerCore.loader;

namespace CsgoDamageVisualizerTests.core.loader.__testdriver
{
    internal class ICsgoDamageVisualizerConfigTestImpl : ICsgoDamageVisualizerConfig
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
            return new Uri("C:/somefolder/somefile.404");
        }
    }
}

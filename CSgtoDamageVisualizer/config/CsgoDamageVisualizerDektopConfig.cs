using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using CsgoDamageVisualizerCore.loader;

namespace CsgoDamageVisualizer.config
{
    internal class CsgoDamageVisualizerDektopConfig : ICsgoDamageVisualizerConfig
    {
        
        public static ICsgoDamageVisualizerConfig GetInstance()
        {
            if(ICsgoDamageVisualizerConfig.ConfigInstanceType == null)
            {
                ICsgoDamageVisualizerConfig.ConfigInstanceType = typeof(CsgoDamageVisualizerDektopConfig);
            }

            return ICsgoDamageVisualizerConfig.Instance;
        }

        public Uri GetCsgoInstallDir()
        {
            string dir = ReadKeyFromSettings<string>("csgoInstallDir");
            return new Uri(dir);
        }

        private T ReadKeyFromSettings<T>(string key)
        {
            var appSettings = ConfigurationManager.AppSettings;
            object result = appSettings[key] ?? "Not Found";
            return (T)result;
        }
    }
}

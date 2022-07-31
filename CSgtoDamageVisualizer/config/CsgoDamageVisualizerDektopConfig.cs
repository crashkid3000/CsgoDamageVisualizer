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

        private static CsgoDamageVisualizerDektopConfig? instance;


        
        public static ICsgoDamageVisualizerConfig GetInstance()
        {
            ICsgoDamageVisualizerConfig.SetInstanceType(typeof(CsgoDamageVisualizerDektopConfig));
            if(instance == null)
            {
                instance = new CsgoDamageVisualizerDektopConfig();
            }
            return instance;
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

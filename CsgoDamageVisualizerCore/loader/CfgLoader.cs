using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerCore.loader
{
    /// <summary>
    /// Class that handles the laoding of CSGO's items_game.txt file into memory
    /// </summary>
    public class CfgLoader
    {

        private ICsgoDamageVisualizerConfig iCsgoDamageVisualizerConfig;

        public CfgLoader()
        {
            this.iCsgoDamageVisualizerConfig = ICsgoDamageVisualizerConfig.Instance;
        }

        /// <summary>
        /// Loads the config file from the disk in an async manner. 
        /// </summary>
        /// <returns>Each line of the config file.</returns>
        public async Task<string[]> LoadCfgFileAsync()
        {
            Uri cfgLocation = GetConfigFileLocation();
#pragma warning disable CS8602 // Dereferenzierung eines möglichen Nullverweises.
            Task<string[]> readLines = File.ReadAllLinesAsync(cfgLocation.AbsoluteUri);
#pragma warning restore CS8602 // Dereferenzierung eines möglichen Nullverweises.
            return await readLines;
        }

        /// <summary>
        /// Gets the location of the items_game.txt from the CSGO install dir
        /// </summary>
        /// <returns></returns>
        private Uri? GetConfigFileLocation()
        {
            Uri installDir = iCsgoDamageVisualizerConfig.GetCsgoInstallDir();
            Uri retVal = new Uri(installDir, @"csgo\scripts\items\items_game.txt");
            return retVal;
        }
    }
}

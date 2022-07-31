using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoDamageVisualizerCore.loader
{
    public class CfgLoader
    {

        public CfgLoader()
        {
            iCsgoDamageVisualizerConfig = ICsgoDamageVisualizerConfig.Instance;
        }

        private ICsgoDamageVisualizerConfig iCsgoDamageVisualizerConfig;

        //Find CFG file

        //Load lines of CFG file

        //for each {: increase indentation level, for each }: decrease it

        //if line matches "weapon_\s*_prefab": create new CfgWeapon, save indentation level

        //if attribute list doesnt exist: create it

        //write attribute into instance

        //if current indentation level == that of the opening "weapon_\s*_prefab": save current CfgWeapon to list

        //next line...


        private string[] LoadCfgFile()
        {
            Uri cfgLocation = GetConfigFileLocation();
            Task<string[]> readLines = File.ReadAllLinesAsync(cfgLocation.AbsoluteUri);
            readLines.Wait();
            return readLines.Result;
        }

        private Uri? GetConfigFileLocation()
        {
            Uri installDir = iCsgoDamageVisualizerConfig.GetCsgoInstallDir();
            Uri retVal = new Uri(installDir, @"csgo\scripts\items\items_game.txt");
            return retVal;
        }
    }
}

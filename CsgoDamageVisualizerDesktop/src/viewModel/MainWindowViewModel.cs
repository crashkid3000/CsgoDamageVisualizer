using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CsgoDamageVisualizerCore.loader;
using CsgoDamageVisualizerCore.loader.model;
using CsgoDamageVisualizerCore.model;
using CsgoDamageVisualizerDesktop.viewModel.utils;
using OxyPlot;

namespace CsgoDamageVisualizerDesktop.viewModel
{
    internal class MainWindowViewModel
    {
        
        /// <summary>
        /// Holds the loaded, raw weapon info (without analysis). The key of each entry is the __name of the value of the entry.
        /// </summary>
        public Property<IReadOnlyDictionary<string, Weapon>> WeaponsProperty { get; set; }

        /// <summary>
        /// Saves the display name and the __name of each loaded weapon.
        /// </summary>
        public Property<IReadOnlyDictionary<string, string>> DisplayableWeaponsProperty { get; set; }

        /// <summary>
        /// Determines if we are currently loading new entries for the WeaponsProperty or not
        /// </summary>
        public Property<bool> IsLoadingWeaponsProperty { get; set; }

        private ICommand? loadWeaponsCommand;

        public ICommand LoadWeaponsCommand
        {
            get { 
                loadWeaponsCommand ??= new BasicCommand(async (param) =>
                {
                    IsLoadingWeaponsProperty.Value = true;

                    await Task.Run(() =>
                    {
                        CfgParser cfgParser = new CfgParser();
                        IReadOnlyDictionary<string, CfgWeapon> cfgWeapons = cfgParser.ParseCfgFile();

                        Debug.WriteLine($"  Loaded {cfgWeapons.Count} Weapons");

                        Dictionary<string, Weapon> weapons = new Dictionary<string, Weapon>();
                        Dictionary<string, string> displayableWeapons = new Dictionary<string, string>();

                        foreach(KeyValuePair<string, CfgWeapon> entry in cfgWeapons)
                        {
                            Weapon weapon;
                            string item_class = CfgWeapon.GetStringValue(entry.Value, "item_class");
                            if (entry.Key.Equals(item_class + "_prefab")) //i.e. the gun is based on a different gun
                            {
                                weapon = new Weapon(entry.Value);
                            }
                            else
                            {
                                CfgWeapon baseCfgWeapon = cfgWeapons[item_class + "_prefab"];
                                weapon = new Weapon(entry.Value, baseCfgWeapon);
                            }
                            weapons.Add(weapon.Name, weapon);
                            displayableWeapons.Add(weapon.DisplayName, weapon.Name);
                        }

                        WeaponsProperty.Value = new ReadOnlyDictionary<string, Weapon>(weapons);
                        DisplayableWeaponsProperty.Value = new ReadOnlyDictionary<string, string>(displayableWeapons);
                    });

                    IsLoadingWeaponsProperty.Value = false;


                });

                return loadWeaponsCommand;
            }
        }

        public MainWindowViewModel()
        {
            WeaponsProperty =
                new Property<IReadOnlyDictionary<string, Weapon>>(
                    new ReadOnlyDictionary<string, Weapon>(new Dictionary<string, Weapon>()));
            DisplayableWeaponsProperty =
                new Property<IReadOnlyDictionary<string, string>>(new ReadOnlyDictionary<string, string>(new Dictionary<string, string>()));
            IsLoadingWeaponsProperty = new Property<bool>(false);
        }
        
    }
}

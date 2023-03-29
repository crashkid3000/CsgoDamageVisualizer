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
using CsgoDamageVisualizerDesktop.viewModel.utils;
using OxyPlot;

namespace CsgoDamageVisualizerDesktop.viewModel
{
    internal class MainWindowViewModel
    {
        
        public Property<IReadOnlyDictionary<string, CfgWeapon>> WeaponsProperty { get; set; }
        public Property<bool> IsLoadingWeaponsProperty { get; set; }

        private ICommand? loadWeaponsCommand;

        public ICommand LoadWeaponsCommand
        {
            get { 
                loadWeaponsCommand ??= new BasicCommand(async (param) =>
                {
                    IsLoadingWeaponsProperty.Value = true;

                    await Task.Run(async () =>
                    {
                        CfgParser cfgParser = new CfgParser();
                        WeaponsProperty.Value = cfgParser.ParseCfgFile();
                        Debug.WriteLine($"  Loaded {WeaponsProperty.Value.Count} Weapons");
                    });

                    IsLoadingWeaponsProperty.Value = false;


                });

                return loadWeaponsCommand;
            }
        }

        public MainWindowViewModel()
        {
            WeaponsProperty =
                new Property<IReadOnlyDictionary<string, CfgWeapon>>(
                    new ReadOnlyDictionary<string, CfgWeapon>(new Dictionary<string, CfgWeapon>()));
            IsLoadingWeaponsProperty = new Property<bool>(false);
        }
        
    }
}

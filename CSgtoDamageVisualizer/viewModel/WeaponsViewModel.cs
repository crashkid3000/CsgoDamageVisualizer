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
    internal class WeaponsViewModel : INotifyPropertyChanged
    {
        
        public Property<IReadOnlyDictionary<string, CfgWeapon>> WeaponsProperty { get; set; }

        private ICommand? loadWeaponsCommand;

        public ICommand LoadWeaponsCommand
        {
            get
            {
                loadWeaponsCommand ??= new BasicCommand((param) =>
                    {
                        CfgParser cfgParser = new CfgParser();
                        WeaponsProperty.Value = cfgParser.ParseCfgFile();
                        Debug.WriteLine($"  Loaded {WeaponsProperty.Value.Count} Weapons");
                    });

                return loadWeaponsCommand;
            }
        }

        public WeaponsViewModel()
        {
            WeaponsProperty = new Property<IReadOnlyDictionary<string, CfgWeapon>>()
                { Value = new ReadOnlyDictionary<string, CfgWeapon>(new Dictionary<string, CfgWeapon>()) };
        }
        
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}

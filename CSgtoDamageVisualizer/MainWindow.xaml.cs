using CsgoDamageVisualizerDesktop.customUi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CsgoDamageVisualizer.config;
using CsgoDamageVisualizerCore.loader;
using CsgoDamageVisualizerCore.loader.model;

namespace CSgtoDamageVisualizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IReadOnlyDictionary<string, CfgWeapon> Weapons { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Type configType = typeof(CsgoDamageVisualizerDektopConfig);
            Console.WriteLine($"Loading with config {configType.Name}");
            ICsgoDamageVisualizerConfig.ConfigInstanceType = configType;

            Weapons = new ReadOnlyDictionary<string, CfgWeapon>(new Dictionary<string, CfgWeapon>());
            WeaponSelectionComboBox.ItemsSource = Weapons.Keys; //todo should probably use proper property binding
        }

        private void textBox_MouseEnter(object sender, MouseEventArgs e)
        {
            Console.WriteLine("enter");
            
            
        }

        private void RefreshWeaponFileMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            CfgParser cfgParser = new CfgParser();

            Weapons = cfgParser.ParseCfgFile();
            WeaponSelectionComboBox.ItemsSource = Weapons.Keys; //todo should probably use proper property binding

            Debug.WriteLine($"Loaded {Weapons.Count} weapons");
        }
    }
}

using CsgoDamageVisualizerDesktop.customUi;
using System;
using System.Collections;
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
using CsgoDamageVisualizerDesktop.viewModel;
using CsgoDamageVisualizerDesktop.viewModel.utils;

namespace CSgtoDamageVisualizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            Type configType = typeof(CsgoDamageVisualizerDektopConfig);
            Console.WriteLine($"Loading with config {configType.Name}");
            ICsgoDamageVisualizerConfig.ConfigInstanceType = configType;

            if (DataContext is MainWindowViewModel model)
            {
                model.IsLoadingWeaponsProperty.PropertyChanged += statusRectangle_setStatus;
            }
            

        }

        private void textBox_MouseEnter(object sender, MouseEventArgs e)
        {
            Console.WriteLine("enter");
        }

        private void statusRectangle_setStatus(object? sender, EventArgs args)
        {
            bool? newValue = (sender as Property<bool>)?.Value;

            if (newValue == true)
            {
                this.IsEnabled = false;
                StatusRect.Fill = new SolidColorBrush(Color.FromRgb(205, 50, 50));
            }

            if (newValue == false)
            {
                StatusRect.Fill = new SolidColorBrush(Color.FromRgb(50, 205, 50));
                this.IsEnabled = true;
            }
        }

    }
}

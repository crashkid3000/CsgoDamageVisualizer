using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using CsgoDamageVisualizerDesktop.viewModel;
using CsgoDamageVisualizerDesktop.viewModel.utils;
using ReactiveUI;

namespace CsgoDamageVisualizerDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowReactive
    {

        public MainWindowReactive()
        {
            InitializeComponent();
            
            ViewModel = new MainWindowViewModelReactive();
            
            // TODO: Move bindings from XAML to here

            // InitializeComponent();
            //
            // Type configType = typeof(CsgoDamageVisualizerDektopConfig);
            // Console.WriteLine($"Loading with config {configType.Name}");
            // ICsgoDamageVisualizerConfig.ConfigInstanceType = configType;
            //
            // if (DataContext is MainWindowViewModel model)
            // {
            //     model.IsLoadingWeaponsProperty.PropertyChanged += statusRectangle_setStatus;
            //
            //     model.LoadWeaponsCommand?.Execute(null);
            // }
            // else
            // {
            //     throw new InvalidDataContextException(typeof(MainWindowViewModel));
            // }
            //
            // WeaponSelectionComboBox.SelectionChanged += WeaponImage_updateForCurrentWeapon;

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

        private void WeaponImage_updateForCurrentWeapon(object? sender, SelectionChangedEventArgs eventArgs)
        {
            //change pic
            int pi = 3; //added items from event args, is type object (actually string)
        }

    }
}

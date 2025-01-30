using System;
using System.Collections.Generic;
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

namespace CsgoDamageVisualizerDesktop.customUi
{
    /// <summary>
    /// Interaktionslogik für CustomTooltip.xaml
    /// </summary>
    public partial class CustomTooltip : UserControl
    {

        public CustomTooltip()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ToolitpTextProperty = DependencyProperty.Register("TooltipText", typeof(string), typeof(CustomTooltip));
        public string TooltipText
        {
            get { return (string)GetValue(ToolitpTextProperty); }
            set { SetValue(ToolitpTextProperty, value); }
        }
    }
}

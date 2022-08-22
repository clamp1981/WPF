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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimationDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GridForCode_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0.0d;
            da.To = 1.0d;
            da.Duration = new Duration(new TimeSpan(0, 0, 10));
            LoadedEventLabelUseInCode.BeginAnimation(Grid.OpacityProperty, da);

        }

        private void GridForCode_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0.0d;
            da.To = 1.0d;
            da.Duration = new Duration(new TimeSpan(0, 0, 10));
            MouseEventLabelUseInCode.BeginAnimation(Grid.OpacityProperty, da);
        }
    }
}

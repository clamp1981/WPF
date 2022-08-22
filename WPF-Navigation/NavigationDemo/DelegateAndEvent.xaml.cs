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
using System.Windows.Shapes;

namespace NavigationDemo
{
    /// <summary>
    /// Interaction logic for DelegateAndEvent.xaml
    /// </summary>
    public partial class DelegateAndEvent : Window
    {
        public DelegateAndEvent()
        {
            InitializeComponent();
            ValueController.MinThresHoldReached += ValueController_MinThresHoldReached;
            ValueController.MaxThresHoldReached += ValueController_MaxThresHoldReached;
        }

        private void ValueController_MaxThresHoldReached(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Maximum value reached!!");
        }

        private void ValueController_MinThresHoldReached(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Minimum value reached!!");
        }
    }
}

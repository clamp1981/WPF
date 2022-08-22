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

namespace NavigationDemo
{
    /// <summary>
    /// Interaction logic for ValueUC.xaml
    /// </summary>
    public partial class ValueUC : UserControl
    {

        public event EventHandler<RoutedEventArgs> MinThresHoldReached;
        public virtual void OnMinThresHoldReached(RoutedEventArgs e)
        {
            MinThresHoldReached?.Invoke(this, e);
        }

        public event EventHandler<RoutedEventArgs> MaxThresHoldReached;
        public virtual void OnMaxThresHoldReached(RoutedEventArgs e)
        {
            MaxThresHoldReached?.Invoke(this, e);
        }
        public ValueUC()
        {
            InitializeComponent();
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            textBoxValue.Text = (Convert.ToInt32(textBoxValue.Text) + 10).ToString();
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            textBoxValue.Text = (Convert.ToInt32(textBoxValue.Text) - 10).ToString();
        }

        private void textBoxValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            int value = 0;
            if( Int32.TryParse((sender as TextBox).Text, out value) )
            {
                if( value < 0 )
                {
                    (sender as TextBox).Text = "0";
                    OnMinThresHoldReached(e);
                }
                else if( value >= 100 )
                {
                    (sender as TextBox).Text = "100";
                    OnMaxThresHoldReached(e);
                }

            }
           
                
        }
    }
}

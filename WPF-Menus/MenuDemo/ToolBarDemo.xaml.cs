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

namespace MenuDemo
{
    /// <summary>
    /// Interaction logic for ToolBarDemo.xaml
    /// </summary>
    public partial class ToolBarDemo : Window
    {
        public ToolBarDemo()
        {
            InitializeComponent();
            try
            {
                this.tbText.FontSize = Convert.ToDouble(this.tbFontSize.Text);                
            }
            catch( Exception ex )
            {
                this.tbText.FontSize = 10.0;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.tbText.Text = "";
        }

        private void tbFontSize_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;

            try
            {
                this.tbText.FontSize = Convert.ToDouble(this.tbFontSize.Text);
            }
            catch (Exception ex)
            {
                this.tbText.FontSize = 10.0;
                this.tbFontSize.Text = this.tbText.FontSize.ToString();
            }

            
        }

    }
}

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
    /// Interaction logic for StatusBarDemo.xaml
    /// </summary>
    public partial class StatusBarDemo : Window
    {
        int _progressValueStep = 10;
        public StatusBarDemo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (progressBar.Value <= 90)
                progressBar.Value += _progressValueStep;
            else
                status.Content = "Done!!";
        }
    }
}

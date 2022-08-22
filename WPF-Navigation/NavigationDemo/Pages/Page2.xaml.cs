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

namespace NavigationDemo.Pages
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {

        public event EventHandler<RoutedEventArgs> Page1Moved;
        public virtual void OnPage1Moved(RoutedEventArgs e)
        {
            Page1Moved?.Invoke(this, e);
        }
        public Page2()
        {
            InitializeComponent();
        }

        private void btnGoToPage1_Click(object sender, RoutedEventArgs e)
        {
            OnPage1Moved(e);
        }
    }
}

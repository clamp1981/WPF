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

namespace MSAppStoreClone.UserControls
{
    /// <summary>
    /// Interaction logic for AnAppWideStyleUC.xaml
    /// </summary>
    public partial class AnAppWideStyleUC : UserControl
    {
        public event EventHandler<MouseButtonEventArgs> AppClicked;
        protected virtual void OnAppClicked(MouseButtonEventArgs e)
        {
            AppClicked?.Invoke(this, e);
        }
        public AnAppWideStyleUC()
        {
            InitializeComponent();
        }

        private void UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OnAppClicked(e);
        }
    }
}

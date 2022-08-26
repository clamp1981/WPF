using MSAppStoreClone.UserControls;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace MSAppStoreClone.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {

        TopAppsUC TopApps = new TopAppsUC();
        AppsUC BestEnterApps = null;
        AppsUC UtilityApps = null;
        public HomePage()
        {
            InitializeComponent();
            MainStackPanel.Children.Add(TopApps);
            BestEnterApps = new AppsUC("Best Entertainment apps");
            UtilityApps = new AppsUC("Utility apps", true);
            MainStackPanel.Children.Add(BestEnterApps);
            MainStackPanel.Children.Add(UtilityApps);

        }
    }
}

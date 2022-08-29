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
        AppsUC GameApps = null;
        public HomePage()
        {
            InitializeComponent();
            MainStackPanel.Children.Add(TopApps);
            BestEnterApps = new AppsUC("Best Entertainment apps", DataBase.AppsMainType.EntertainmentApp );
            UtilityApps = new AppsUC("Utility apps", DataBase.AppsMainType.UtilityApp, true);
            GameApps = new AppsUC("Best Game apps", DataBase.AppsMainType.GameApp);
            MainStackPanel.Children.Add(BestEnterApps);
            MainStackPanel.Children.Add(UtilityApps);
            MainStackPanel.Children.Add(GameApps);

        }
    }
}

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
        public event EventHandler<AppClickedEventArges> AppClicked;
        protected virtual void OnAppClicked(AppClickedEventArges e)
        {
            AppClicked?.Invoke(this, e);
        }

        public event EventHandler<ViewMoreClickedEventArges> ViewMoreClicked;
        protected virtual void OnViewMoreClicked(ViewMoreClickedEventArges e)
        {
            ViewMoreClicked?.Invoke(this, e);
        }


        TopAppsUC TopApps = new TopAppsUC();
        AppsUC BestEnterApps = null;
        AppsUC UtilityApps = null;
        AppsUC GameApps = null;
        AppsUC FreeApps = null;
        public HomePage()
        {
            InitializeComponent();
            MainStackPanel.Children.Add(TopApps);
            BestEnterApps = new AppsUC("Best Entertainment apps", DataBase.AppsMainType.EntertainmentApp , DataBase.DisplayType.Best );
            UtilityApps = new AppsUC("Utility apps", DataBase.AppsMainType.UtilityApp, DataBase.DisplayType.All, true);
            GameApps = new AppsUC("Best Game apps", DataBase.AppsMainType.GameApp, DataBase.DisplayType.Best);
            FreeApps = new AppsUC("Free apps", DataBase.AppsMainType.None, DataBase.DisplayType.Free);

            BestEnterApps.AppClicked += Apps_AppClicked;
            UtilityApps.AppClicked += Apps_AppClicked;
            GameApps.AppClicked += Apps_AppClicked;
            FreeApps.AppClicked += Apps_AppClicked;

            BestEnterApps.ViewMoreClicked += Apps_ViewMoreClicked;
            UtilityApps.ViewMoreClicked += Apps_ViewMoreClicked;
            GameApps.ViewMoreClicked += Apps_ViewMoreClicked;
            FreeApps.ViewMoreClicked += Apps_ViewMoreClicked;

            MainStackPanel.Children.Add(BestEnterApps);
            MainStackPanel.Children.Add(UtilityApps);
            MainStackPanel.Children.Add(GameApps);
            MainStackPanel.Children.Add(FreeApps);

        }

        private void Apps_ViewMoreClicked(object sender, ViewMoreClickedEventArges e)
        {
            OnViewMoreClicked(e);
        }

        private void Apps_AppClicked(object sender, AppClickedEventArges e)
        {
            OnAppClicked(e);
        }
    }
}

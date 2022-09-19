using MSAppStoreClone.DataBase;
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

namespace MSAppStoreClone.UserControls.HambugerMenuViewrs
{
    /// <summary>
    /// UserControl1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HambugerMenuUCList : UserControl
    {
       
        List<HambugerMenuUC> AppList = new List<HambugerMenuUC>();
        public HambugerMenuUCList(AppsMainType appType, DisplaySortType sortType )
        {
            InitializeComponent();

             List<AppModel> apps = MockDB.GetAppModels(appType, sortType);

            foreach (var app in apps)
            {
                MainStackPanel.Children.Add(new HambugerMenuUC(app));               
            }
        }


        public void SetApps(AppsMainType appType, DisplaySortType sortType)
        {
            MainStackPanel.Children.Clear();
            List<AppModel> apps = MockDB.GetAppModels(appType, sortType);
            foreach (var app in apps)
            {
                MainStackPanel.Children.Add(new HambugerMenuUC(app));
            }
        }
    }
}

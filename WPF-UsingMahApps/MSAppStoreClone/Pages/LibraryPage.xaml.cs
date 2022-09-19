using MSAppStoreClone.DataBase;
using MSAppStoreClone.UserControls.HambugerMenuViewrs;
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

namespace MSAppStoreClone.Pages
{
    /// <summary>
    /// LibraryPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LibraryPage : Page
    {

        HambugerMenuHeader _header = new HambugerMenuHeader();
        HambugerMenuUCList _appList = null;
        
        public LibraryPage()
        {
            InitializeComponent();
            _header.SelectionChangedTypes += header_SelectionChangedTypes;
            UserControls.HambugerMenuViewrs.ComboBoxItem apptype = (UserControls.HambugerMenuViewrs.ComboBoxItem)(_header.GetMenuSelectedValue(MenuComboBoxType.AppType)) ;
            UserControls.HambugerMenuViewrs.ComboBoxItem sorttype = (UserControls.HambugerMenuViewrs.ComboBoxItem)_header.GetMenuSelectedValue(MenuComboBoxType.DisplaySort);
            _appList = new HambugerMenuUCList((AppsMainType)apptype.value, (DisplaySortType)sorttype.value);
            this.HeaderGrid.Children.Add(_header);

            this.MainStackPanel.Children.Add(_appList);

        }

        private void header_SelectionChangedTypes(object sender, SelectChangedComboBoxEventArgs e)
        {
            UserControls.HambugerMenuViewrs.ComboBoxItem apptype = (UserControls.HambugerMenuViewrs.ComboBoxItem)(_header.GetMenuSelectedValue(MenuComboBoxType.AppType));
            UserControls.HambugerMenuViewrs.ComboBoxItem sorttype = (UserControls.HambugerMenuViewrs.ComboBoxItem)_header.GetMenuSelectedValue(MenuComboBoxType.DisplaySort);
            _appList.SetApps((AppsMainType)apptype.value, (DisplaySortType)sorttype.value);
           
        }
    }
}

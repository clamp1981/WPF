using MSAppStoreClone.DataBase;
using MSAppStoreClone.UserControls;
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
    /// Interaction logic for DetailPage.xaml
    /// </summary>
    public partial class DetailPage : Page
    {

        DetailTopAppUC _topAppUc;
        DetailBottomAppUC _detailAppUc;
        public DetailPage(AppModel app)
        {
            InitializeComponent();

            _topAppUc = new DetailTopAppUC(app);
            _detailAppUc = new DetailBottomAppUC(app);
            MainStackPanel.Children.Add(_topAppUc);
            MainStackPanel.Children.Add(_detailAppUc);
        }
    }
}

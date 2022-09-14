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

namespace MSAppStoreClone.UserControls
{
    /// <summary>
    /// Interaction logic for DetailBottomAppUC.xaml
    /// </summary>
    public partial class DetailBottomAppUC : UserControl
    {
        public DetailBottomAppUC(AppModel app)
        {
            InitializeComponent();
            this.ProductDetail.Text = app.AppDetail;
            this.ScreenShotGrid.Children.Add(new ScreenShotUC(app.ScreenShotImagePathList));
        }
    }
}

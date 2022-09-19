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
    /// HambugerMenuUC.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HambugerMenuUC : UserControl
    {

        public HambugerMenuUC(AppModel app)
        {
            InitializeComponent();

            this.AppImage.Source = new BitmapImage(new Uri(app.MiniImagPath));
            this.AppNameTextBlock.Text = app.AppName;
            this.PurchasedLabel.Content = app.Purchased.ToString("d");
        }
    }
}

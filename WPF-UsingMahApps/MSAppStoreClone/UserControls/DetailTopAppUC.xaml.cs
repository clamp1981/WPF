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
    /// Interaction logic for DetailTopAppUC.xaml
    /// </summary>
    public partial class DetailTopAppUC : UserControl
    {
        public DetailTopAppUC(AppModel app)
        {
            InitializeComponent();

           
            this.ProductImage.Source = new BitmapImage(new Uri(app.ImagPath));
            this.ProductName.Text = app.AppName;
            this.ProductSummery.Text = app.AppSummary;
            this.ProducType.Content = app.AppTypeName;
            Hyperlink hyperlink = new Hyperlink();
            hyperlink.Inlines.Clear();
            hyperlink.Inlines.Add(app.AppName + " Inc");
            hyperlink.NavigateUri = new Uri("https://www.naver.com");
            //hyperlink.RequestNavigate += Hyperlink_RequestNavigate1;
            this.ProductCompany.Content = hyperlink;
        }
    }
}

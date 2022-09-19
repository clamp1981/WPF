using MahApps.Metro.Controls;
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
    /// Interaction logic for AnAppWideStyleUC.xaml
    /// </summary>
    public partial class AnAppWideStyleUC : MetroContentControl
    {
        public event EventHandler<AppClickedEventArges> AppClicked;
        protected virtual void OnAppClicked(AppClickedEventArges e)
        {
            AppClicked?.Invoke(this, e);
        }

        public AppModel Model { get; set; }
        public AnAppWideStyleUC(AppModel appModel)
        {
            InitializeComponent();
            Model = appModel;

            this.ProductImage.Source = new BitmapImage(new Uri(appModel.ImagPath));
            this.ProductName.Text = appModel.AppName;
            this.ProductPrice.Text = appModel.Price == 0.0 ? "Free" : string.Format("{0:#,0}", appModel.Price);
            this.ProductType.Text = appModel.AppTypeName;
        }

        private void UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OnAppClicked(new AppClickedEventArges(Model));
        }
    }
}

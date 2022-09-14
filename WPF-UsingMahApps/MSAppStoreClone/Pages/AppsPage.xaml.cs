using MSAppStoreClone.DataBase;
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
    /// Interaction logic for AppsPage.xaml
    /// </summary>
    public partial class AppsPage : Page
    {
        public event EventHandler<AppClickedEventArges> AppClicked;
        protected virtual void OnAppClicked(AppClickedEventArges e)
        {
            AppClicked?.Invoke(this, e);
        }



        List<AppModel> Apps;
        public AppsPage(AppsMainType type, DisplayType displayType)
        {
            InitializeComponent();
            this.Apps = MockDB.GetAppModels(type, displayType);

            foreach (var App in this.Apps)
            {
                AnAppUC app = new AnAppUC(App);
                app.AppClicked += App_AppClicked;
                this.AppsWrapPanel.Children.Add(app);
              
            }
           

            //var files = Directory.GetFiles(Environment.CurrentDirectory + @"..\..\..\Images", "*.png", SearchOption.TopDirectoryOnly).ToList();

            //foreach (var file in files)
            //{
            //    AnAppUC app = new AnAppUC();
            //    app.ProductImage.Source = new BitmapImage(new Uri(file));
            //    try
            //    {
            //        app.ProductName.Text = System.IO.Path.GetFileNameWithoutExtension(file).Split('-')[1];
            //    }
            //    catch( Exception ex )
            //    {
            //        Console.WriteLine(ex.Message);
            //    }

            //    this.AppsWrapPanel.Children.Add(app);

            //}


        }

        private void App_AppClicked(object sender, AppClickedEventArges e)
        {
            OnAppClicked(e);
        }
    }
}

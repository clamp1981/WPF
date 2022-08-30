using MSAppStoreClone.DataBase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace MSAppStoreClone.UserControls
{
    /// <summary>
    /// Interaction logic for AppsUC.xaml
    /// </summary>
    public partial class AppsUC : UserControl
    {

      
        bool IsAppUCWide = false;
        List<AppModel> Apps;

        public string Title
        {
            get { return (string )GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AppsTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string ), typeof(AppsUC), new PropertyMetadata(default(string)));



        public Orientation MainStackPanelOrientation
        {
            get { return (Orientation)GetValue(MainStackPanelOrientationProperty); }
            set { SetValue(MainStackPanelOrientationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MainStackPanelOrientationProperty =
            DependencyProperty.Register("MainStackPanelOrientation", typeof(Orientation), typeof(AppsUC), new PropertyMetadata(default(Orientation)));




        public double MainPanelWidth
        {
            get { return (double)GetValue(MainPanelWidthProperty); }
            set { SetValue(MainPanelWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MainPanelWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MainPanelWidthProperty =
            DependencyProperty.Register("MainPanelWidth", typeof(double), typeof(AppsUC), new PropertyMetadata(default(double)));





        public AppsUC( string title , AppsMainType type, DisplayType displayType,  bool isWide = false)
        {
            InitializeComponent();
            
            this.Title = title;
            this.DataContext = this;
            this.Apps = MockDB.GetAppModels(type , displayType );
            this.IsAppUCWide = isWide;
            if (isWide)
                this.MainStackPanelOrientation = Orientation.Vertical;
            else
                this.MainStackPanelOrientation = Orientation.Horizontal;

        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.MainPanelWidth = this.ActualWidth;
            if (this.IsAppUCWide == false)
            {
                
                int count = Convert.ToInt32(Math.Truncate(this.ActualWidth / 150));
                Debug.WriteLine($"UserControl_SizeChanged MainStackPanel width : {this.MainStackPanel.ActualWidth}, width : {this.ActualWidth}, count : {count}");
                if (count == this.MainStackPanel.Children.Count)
                    return;


              
                if (count > this.MainStackPanel.Children.Count)
                {
                    int addcount = count + this.MainStackPanel.Children.Count;

                    if (Apps.Count <= addcount)
                        addcount = Apps.Count;
                   
                    for (int i = this.MainStackPanel.Children.Count; i < addcount; i++)
                    {
                        AddApps(new AnAppUC(), Apps[i]);

                    }
                }
                else
                {
                    int removeCount = this.MainStackPanel.Children.Count - count;
                    for (int i = 0; i < removeCount; i++)
                    {
                        this.MainStackPanel.Children.RemoveAt(this.MainStackPanel.Children.Count - 1);
                        
                    }
                }
            }
           
            

        }

        private void AddApps(UserControl uc, AppModel appModel)
        {
            dynamic app = null;
            if(this.IsAppUCWide == false)
                app = uc as AnAppUC;
            else
                app = uc as AnAppWideStyleUC;
            //AnAppUC app = new AnAppUC();
            app.ProductImage.Source = new BitmapImage(new Uri(appModel.ImagPath));
            try
            {
                app.ProductName.Text = appModel.AppName;
                app.ProductPrice.Text = appModel.Price == 0.0 ? "Free" : string.Format("{0:#,0}",  appModel.Price );
                app.ProductType.Text = appModel.AppTypeName;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            this.MainStackPanel.Children.Add(app);
           
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //if( this.IsAppUCWide == false )
            //{
            //    int count = Convert.ToInt32(Math.Truncate(this.ActualWidth / 150));
            //    if (count >= Apps.Count)
            //        count = Apps.Count;

            //    for (int i = 0; i < count; i++)
            //    {
            //        AddApps(new AnAppUC(),  Apps[i]);
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < 3; i++)
            //    {
            //        AddApps(new AnAppWideStyleUC(), Apps[i]);

            //        //AnAppWideStyleUC app = new AnAppWideStyleUC();
            //        //app.ProductImage.Source = new BitmapImage(new Uri(Apps[i].ImagPath));
            //        //try
            //        //{
            //        //    app.ProductName.Text = Apps[i].AppName;
            //        //    app.ProductPrice.Text = Apps[i].Price == 0.0 ? "Free" : Apps[i].Price.ToString("{0:#.0}");
            //        //    app.ProductType.Text = Apps[i].AppTypeName;
            //        //}
            //        //catch (Exception ex)
            //        //{
            //        //    Console.WriteLine(ex.Message);
            //        //}
            //        //this.MainStackPanel.Children.Add(app);
            //    }
            //}
            

            
        }
    }
}

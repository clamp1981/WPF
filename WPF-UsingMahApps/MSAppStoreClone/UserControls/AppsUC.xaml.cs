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

        List<string> Files = Directory.GetFiles(Environment.CurrentDirectory + @"..\..\..\Images", "*.png", SearchOption.TopDirectoryOnly).ToList();
        bool IsAppUCWide = false;
        MockDB MockDataBase = new MockDB();

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





        public AppsUC( string title , AppsMainType type,  bool isWide = false)
        {
            InitializeComponent();
            
            this.Title = title;
            this.DataContext = this;
            this.Apps = MockDataBase.GetAppModels(type);
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
                    for (int i = this.MainStackPanel.Children.Count; i < addcount; i++)
                    {
                        if (i >= Apps.Count)
                            return;

                        AnAppUC app = new AnAppUC();                       
                        app.ProductImage.Source = new BitmapImage(new Uri(Apps[i].ImagPath));
                        try
                        {
                            app.ProductName.Text = Apps[i].AppName;
                            app.ProductPrice.Text = Apps[i].Price == 0.0 ? "Free" : Apps[i].Price.ToString();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        this.MainStackPanel.Children.Add(app);
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
            //else
            //{
            //    foreach (var item in this.MainStackPanel.Children)
            //    {
            //        AnAppWideStyleUC app = item as AnAppWideStyleUC;
            //        app.Width = this.ActualWidth;
            //    }
            //}
            

        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if( this.IsAppUCWide == false )
            {
                int count = Convert.ToInt32(Math.Truncate(this.ActualWidth / 150));
                for (int i = 0; i < count; i++)
                {
                    AnAppUC app = new AnAppUC();
                    app.ProductImage.Source = new BitmapImage(new Uri(Files[i]));
                    try
                    {
                        app.ProductName.Text = System.IO.Path.GetFileNameWithoutExtension(Files[i]).Split('-')[1];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    this.MainStackPanel.Children.Add(app);
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    AnAppWideStyleUC app = new AnAppWideStyleUC();
                    app.ProductImage.Source = new BitmapImage(new Uri(Files[i]));
                    try
                    {
                        app.ProductName.Text = System.IO.Path.GetFileNameWithoutExtension(Files[i]).Split('-')[1];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    this.MainStackPanel.Children.Add(app);
                }
            }
            

            
        }
    }
}

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
    /// Interaction logic for AnAppUC.xaml
    /// </summary>
    public partial class AnAppUC : UserControl
    {

        public event EventHandler<AppClickedEventArges> AppClicked;
        protected virtual void OnAppClicked(AppClickedEventArges e)
        {
            AppClicked?.Invoke(this, e);
        }



        public Visibility Liked01Visibility
        {
            get { return (Visibility)GetValue(Liked01VisibilityProperty); }
            set { SetValue(Liked01VisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Liked01Visibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Liked01VisibilityProperty =
            DependencyProperty.Register("Liked01Visibility", typeof(Visibility), typeof(AnAppUC), new PropertyMetadata(default(Visibility)));

        public Visibility Liked02Visibility
        {
            get { return (Visibility)GetValue(Liked02VisibilityProperty); }
            set { SetValue(Liked02VisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Liked01Visibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Liked02VisibilityProperty =
            DependencyProperty.Register("Liked02Visibility", typeof(Visibility), typeof(AnAppUC), new PropertyMetadata(default(Visibility)));

        public Visibility Liked03Visibility
        {
            get { return (Visibility)GetValue(Liked03VisibilityProperty); }
            set { SetValue(Liked03VisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Liked01Visibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Liked03VisibilityProperty =
            DependencyProperty.Register("Liked03Visibility", typeof(Visibility), typeof(AnAppUC), new PropertyMetadata(default(Visibility)));

        public Visibility Liked04Visibility
        {
            get { return (Visibility)GetValue(Liked04VisibilityProperty); }
            set { SetValue(Liked04VisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Liked01Visibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Liked04VisibilityProperty =
            DependencyProperty.Register("Liked04Visibility", typeof(Visibility), typeof(AnAppUC), new PropertyMetadata(default(Visibility)));

        public Visibility Liked05Visibility
        {
            get { return (Visibility)GetValue(Liked05VisibilityProperty); }
            set { SetValue(Liked05VisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Liked01Visibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Liked05VisibilityProperty =
            DependencyProperty.Register("Liked05Visibility", typeof(Visibility), typeof(AnAppUC), new PropertyMetadata(default(Visibility)));



        public AppModel Model { get; set; }
        public AnAppUC(AppModel appModel)
        {
            InitializeComponent();
            this.DataContext = this;
            Model = appModel;



            Liked01Visibility = Visibility.Hidden;
            Liked02Visibility = Visibility.Hidden;
            Liked03Visibility = Visibility.Hidden;
            Liked04Visibility = Visibility.Hidden;
            Liked05Visibility = Visibility.Hidden;


            this.ProductImage.Source = new BitmapImage(new Uri(appModel.ImagPath));
            this.ProductName.Text = appModel.AppName;
            this.ProductPrice.Text = appModel.Price == 0.0 ? "Free" : string.Format("{0:#,0}", appModel.Price);
            this.ProductType.Text = appModel.AppTypeName;

            if(appModel.Liked == 1)
                Liked01Visibility = Visibility.Visible;
            else if(appModel.Liked == 2)
            {
                Liked01Visibility = Visibility.Visible;
                Liked02Visibility = Visibility.Visible;
            }
            else if (appModel.Liked == 3)
            {
                Liked01Visibility = Visibility.Visible;
                Liked02Visibility = Visibility.Visible;
                Liked03Visibility = Visibility.Visible;
            }
            else if (appModel.Liked == 4)
            {
                Liked01Visibility = Visibility.Visible;
                Liked02Visibility = Visibility.Visible;
                Liked03Visibility = Visibility.Visible;
                Liked04Visibility = Visibility.Visible;
            }
            else if (appModel.Liked == 5)
            {
                Liked01Visibility = Visibility.Visible;
                Liked02Visibility = Visibility.Visible;
                Liked03Visibility = Visibility.Visible;
                Liked04Visibility = Visibility.Visible;
                Liked05Visibility = Visibility.Visible;
            }

            this.Liked.Text = appModel.Liked.ToString();
        }

        private void ProductImage_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OnAppClicked(new AppClickedEventArges(Model));
        }
    }
}


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
    /// Interaction logic for MenuUC.xaml
    /// </summary>
    public partial class MenuUC : UserControl
    {
        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }




        public Visibility ClickedBarVisibility
        {
            get { return (Visibility)GetValue(ClickedBarVisibilityProperty); }
            set { SetValue(ClickedBarVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ClickedBarVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClickedBarVisibilityProperty =
            DependencyProperty.Register("ClickedBarVisibility", typeof(Visibility), typeof(MenuUC), new PropertyMetadata(default(Visibility)));


        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(string), typeof(MenuUC), new PropertyMetadata(default(string)));


        public MenuUC( string imagePath )
        {
            InitializeComponent();
            this.ImageSource = imagePath;
            this.ClickedBarVisibility = Visibility.Hidden;
            this.DataContext = this;

        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //this.ClickedBarVisibility = this.ClickedBarVisibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
        }
    }
}

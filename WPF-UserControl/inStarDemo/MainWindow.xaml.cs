using inStaDemo.UserControls;
using inStarDemo.Models;
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

namespace inStaDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainStackPanel.Children.Add(new VideoPostUC(new VideoPostModel()));
            MainStackPanel.Children.Add(new PicturePostUC(new PicturePostModel()));
            //MainStackPanel.Children.Add(new VideoPostUC(new VideoPostModel()));
            //MainStackPanel.Children.Add(new VideoPostUC(new VideoPostModel()));
        }

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if( e.VerticalChange > 0 )
            {
                int adjustment = 400;
                if( e.VerticalOffset + e.ViewportHeight + adjustment >= e.ExtentHeight )
                {
                    MainStackPanel.Children.Add(new PicturePostUC(new PicturePostModel()));
                }
            }
        }
    }
}

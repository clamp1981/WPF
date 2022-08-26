﻿using System;
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
        int ContentCount = 0;
        public string Title
        {
            get { return (string )GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AppsTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string ), typeof(AppsUC), new PropertyMetadata(default(string)));


        public AppsUC( string title )
        {
            InitializeComponent();
            
            this.Title = title;
            this.DataContext = this;

           


        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ContentCount == 0)
                return;

            int count = Convert.ToInt32(Math.Truncate( this.ActualWidth / 150) );
            Debug.WriteLine($"UserControl_SizeChanged MainStackPanel width : {this.MainStackPanel.ActualWidth}, width : { this.ActualWidth}, count : {count}");
            if ( count == this.MainStackPanel.Children.Count )
                return;

            if (count > this.MainStackPanel.Children.Count)
            {
                int addcount = count + this.MainStackPanel.Children.Count;
                for (int i = this.MainStackPanel.Children.Count; i < addcount; i++)
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
                int removeCount = this.MainStackPanel.Children.Count - count;
                for (int i = 0; i < removeCount; i++)
                {
                    this.MainStackPanel.Children.RemoveAt(this.MainStackPanel.Children.Count-1);
                }
            }
           
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
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

            ContentCount = count;
        }
    }
}

﻿using MSAppStoreClone.DataBase;
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

        public AppModel Model { get; set; }
        public AnAppUC(AppModel appModel)
        {
            InitializeComponent();
            Model = appModel;

            this.ProductImage.Source = new BitmapImage(new Uri(appModel.ImagPath));
            this.ProductName.Text = appModel.AppName;
            this.ProductPrice.Text = appModel.Price == 0.0 ? "Free" : string.Format("{0:#,0}", appModel.Price);
            this.ProductType.Text = appModel.AppTypeName;
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

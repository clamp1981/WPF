using MSAppStoreClone.DataBase;
using MSAppStoreClone.UserControls.HambugerMenuViewrs;
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

namespace MSAppStoreClone.Pages
{
    /// <summary>
    /// LibraryPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LibraryPage : Page
    {


        MyLibraryUC myLibrary = new MyLibraryUC();
        public LibraryPage()
        {
            InitializeComponent();

            this.MainStackPanel.Children.Add(myLibrary);
        }

       

     
    }
}

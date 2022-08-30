using MSAppStoreClone.Pages;
using System.Windows;


namespace MSAppStoreClone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        HomePage MainHomePage { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            MainHomePage = new HomePage();
            MainHomeFrame.Content = MainHomePage;
        }
    }
}

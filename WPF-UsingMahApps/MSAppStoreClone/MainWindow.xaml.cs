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
        DetailPage AppDetailPage { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            MainHomePage = new HomePage();
            MainHomePage.AppClicked += MainHomePage_AppClicked;
            MainHomeFrame.Content = MainHomePage;
        }

        private void MainHomePage_AppClicked(object sender, UserControls.AppClickedEventArges e)
        {
            AppDetailPage = new DetailPage(e.SelectAppModel);
            MainHomeFrame.Content = AppDetailPage;
        }
    }
}

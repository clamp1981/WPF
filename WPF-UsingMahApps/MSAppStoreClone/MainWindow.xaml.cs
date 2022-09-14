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

        AppsPage AppsPage { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            MainHomePage = new HomePage();
            MainHomePage.AppClicked += MainHomePage_AppClicked;
            MainHomePage.ViewMoreClicked += MainHomePage_ViewMoreClicked;
            MainHomeFrame.Content = MainHomePage;
        }

        private void MainHomePage_ViewMoreClicked(object sender, UserControls.ViewMoreClickedEventArges e)
        {
            AppsPage = new AppsPage( e.Title, e.MainType, e.AppDisplayType);
            AppsPage.AppClicked += AppsPage_AppClicked;
            MainHomeFrame.Content = AppsPage;
        }

        private void AppsPage_AppClicked(object sender, UserControls.AppClickedEventArges e)
        {
            AppDetailPage = new DetailPage(e.SelectAppModel);
            MainHomeFrame.Content = AppDetailPage;
        }

        private void MainHomePage_AppClicked(object sender, UserControls.AppClickedEventArges e)
        {
            AppDetailPage = new DetailPage(e.SelectAppModel);
            MainHomeFrame.Content = AppDetailPage;
        }
    }
}

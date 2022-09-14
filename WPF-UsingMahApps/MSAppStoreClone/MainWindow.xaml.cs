using MSAppStoreClone.Pages;
using System.Windows;
using System.Windows.Controls;

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

        public int CurrentIndex { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            this.CurrentIndex = 0;
            MainHomePage = new HomePage();
            MainHomePage.AppClicked += AppsPage_AppClicked;
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
            SetFrameContent(AppDetailPage);
        }

        

        private void TabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.CurrentIndex == (sender as TabControl).SelectedIndex)
                return;
            
            this.CurrentIndex = (sender as TabControl).SelectedIndex;
            if( this.CurrentIndex == 0 )
            {
                MainHomeFrame.NavigationService.RemoveBackEntry();
                MainHomeFrame.Content = MainHomePage;
            }
            else 
            {
                var selTab = (sender as TabControl).SelectedItem as TabItem;
                if (this.CurrentIndex == 1)
                {
                    AppsPage = new AppsPage(selTab.Header.ToString(), DataBase.AppsMainType.None, DataBase.DisplayType.All);
                    AppsPage.AppClicked += AppsPage_AppClicked;
                }
                else
                {
                    AppsPage = new AppsPage(selTab.Header.ToString(), DataBase.AppsMainType.GameApp, DataBase.DisplayType.All);
                    AppsPage.AppClicked += AppsPage_AppClicked;
                }

               
                SetFrameContent(AppsPage, true );


            }
            
        }

        private void SetFrameContent( object page, bool isRemveBack = false )
        {
            if( isRemveBack )
            {
                MainHomeFrame.NavigationService.RemoveBackEntry();
                MainAppFrame.NavigationService.RemoveBackEntry();
                MainGameFrame.NavigationService.RemoveBackEntry();
            }
           
            if (this.CurrentIndex == 0)
            {               
                MainHomeFrame.Content = page;
            }
               
            else if (this.CurrentIndex == 1)
            {               
                MainAppFrame.Content = page;
            }                
            else
            {              
                MainGameFrame.Content = page;
            }
               
        }
    }
}

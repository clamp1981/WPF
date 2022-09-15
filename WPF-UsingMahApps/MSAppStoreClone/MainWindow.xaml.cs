using MSAppStoreClone.DataBase;
using MSAppStoreClone.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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

        SearchResultPage SearchAppsPage { get; set; }

        public int CurrentIndex { get; set; }



        public Visibility PrevVisiblity
        {
            get { return (Visibility)GetValue(PrevVisiblityProperty); }
            set { SetValue(PrevVisiblityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PrevVisiblity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PrevVisiblityProperty =
            DependencyProperty.Register("PrevVisiblity", typeof(Visibility), typeof(MainWindow), new PropertyMetadata(default(Visibility)));







        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.CurrentIndex = 0;
          

            MainHomePage = new HomePage();
            MainHomePage.AppClicked += AppsPage_AppClicked;
            MainHomePage.ViewMoreClicked += MainHomePage_ViewMoreClicked;
            SetFrameContent(MainHomePage);
           
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

            
            RemoveTabBackEntry(this.CurrentIndex);
            this.CurrentIndex = (sender as TabControl).SelectedIndex;
            if( this.CurrentIndex == 0 )
            {
                //RemoveBackContent(this.MainHomeFrame);
                SetFrameContent(MainHomePage);
            }
            else 
            {
                var selTab = (sender as TabControl).SelectedItem as TabItem;
                if (this.CurrentIndex == 1)
                {
                    //RemoveBackContent(this.MainAppFrame);
                    AppsPage = new AppsPage(selTab.Header.ToString(), DataBase.AppsMainType.None, DataBase.DisplayType.All);
                    AppsPage.AppClicked += AppsPage_AppClicked;
                }
                else
                {
                    //RemoveBackContent(this.MainGameFrame);
                    AppsPage = new AppsPage(selTab.Header.ToString(), DataBase.AppsMainType.GameApp, DataBase.DisplayType.All);
                    AppsPage.AppClicked += AppsPage_AppClicked;
                }
               
                SetFrameContent(AppsPage );
            }
            
        }

        private void SetFrameContent( object page )
        {
            Debug.WriteLine("Set Content()************");
            if (this.CurrentIndex == 0)
            {              
                this.MainHomeFrame.Content = page;                     
            }
            else if (this.CurrentIndex == 1)
            {                
                this.MainAppFrame.Content = page;                      
            }                
            else
            {               
                this.MainGameFrame.Content = page;                       
            }


        }



        private void Frame_ContentRendered(object sender, EventArgs e)
        {
            RemoveTabBackEndtryByFrame(sender as Frame, true);
        }

        private void RemoveTabBackEntry( int index )
        {            
            if (index == 0)
                RemoveTabBackEndtryByFrame(this.MainHomeFrame);              
            else if (index == 1)
                RemoveTabBackEndtryByFrame(this.MainAppFrame);          
            else
                RemoveTabBackEndtryByFrame(this.MainGameFrame);
            

           
        }

        private void RemoveTabBackEndtryByFrame(Frame frame , bool isCheckMainPage = false )
        {
            NavigationService servies = null;
            if (isCheckMainPage)
            {
                object main_obj = null;
                if (frame == this.MainHomeFrame)
                    main_obj = MainHomePage;
                else
                    main_obj = AppsPage;
                if (frame.Content == main_obj)
                {
                    servies = frame.NavigationService;
                }
            }
            else
                servies = frame.NavigationService;

            if (servies == null)
            {
                if(frame.NavigationService.CanGoBack )
                    this.PrevVisiblity = Visibility.Visible;
                else
                    this.PrevVisiblity = Visibility.Hidden;
                return;
            }



            while (servies.CanGoBack)
            {
                servies.RemoveBackEntry();
            }

            if (servies.CanGoBack)
                this.PrevVisiblity = Visibility.Visible;
            else
                this.PrevVisiblity = Visibility.Hidden;
        }



        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            NavigationService servies = null;
            if (this.CurrentIndex == 0)
                servies = this.MainHomeFrame.NavigationService;
            else if (this.CurrentIndex == 1)
                servies = this.MainAppFrame.NavigationService;
            else
                servies = this.MainGameFrame.NavigationService;
            if (servies != null)
            {
                if (servies.CanGoBack)
                    servies.GoBack();


            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(SearchText.Text))
                return;

            SearchAppsPage = new SearchResultPage(SearchText.Text);
            SetFrameContent(SearchAppsPage);
        }
    }
}

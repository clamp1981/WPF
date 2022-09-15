using MSAppStoreClone.DataBase;
using MSAppStoreClone.UserControls;
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
    /// SearchResultPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SearchResultPage : Page
    {



        public string SearchText
        {
            get { return (string)GetValue(SearchTextProperty); }
            set { SetValue(SearchTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SearchText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SearchTextProperty =
            DependencyProperty.Register("SearchText", typeof(string), typeof(SearchResultPage), new PropertyMetadata(default(string)));


        private string _searchText = "";

        WrapPanel _warpPanel = new WrapPanel();
        public SearchResultPage( string searchText )
        {
            InitializeComponent();
            this.DataContext = this;
            _warpPanel.Orientation = Orientation.Horizontal;
            this.SearchText = $"\"{searchText}\"";
            this._searchText = searchText;

            AppModel app = MockDB.GetAppModel(this._searchText);
            if (app != null)
            {
                SearchResultStackPanel.Children.Add(new DetailTopAppUC(app));
            }

        }

       
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {            
            SearchResultStackPanel.Children.Add(this._warpPanel);

            List<AppModel> apps = MockDB.GetAppModels(this._searchText);
            foreach (var appitem in apps)
            {
                AnAppUC an_app = new AnAppUC(appitem);
                //an_app.AppClicked += App_AppClicked;
                this._warpPanel.Children.Add(an_app);

            }
        }
    }
}

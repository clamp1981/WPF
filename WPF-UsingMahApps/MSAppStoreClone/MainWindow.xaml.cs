using MSAppStoreClone.Pages;
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

namespace MSAppStoreClone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MenuUC HomeMenu { get; set; }
        public MenuUC AppMenu { get; set; }
        public MenuUC GameMenu { get; set; }
        public MenuUC LibraryMenu { get; set; }
        public MenuUC HelpMenu { get; set; }


        public AppsPage AppPage { get; set; }
        public HomePage HomePage { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            //Uri uri = new Uri("pack://application:,,,/Images/Menu/home.png");
            HomeMenu = new MenuUC(Environment.CurrentDirectory + @"\..\..\Images\Menu\home.png", Common.MenuTypes.Home);
            AppMenu = new MenuUC(Environment.CurrentDirectory + @"\..\..\Images\Menu\Apps.png", Common.MenuTypes.Apps);
            GameMenu = new MenuUC(Environment.CurrentDirectory + @"\..\..\Images\Menu\game.png", Common.MenuTypes.Games);
            MainMenuStackPanel_Top.Children.Add(HomeMenu);
            MainMenuStackPanel_Top.Children.Add(AppMenu);
            MainMenuStackPanel_Top.Children.Add(GameMenu);
            LibraryMenu = new MenuUC(Environment.CurrentDirectory + @"\..\..\Images\Menu\library.png", Common.MenuTypes.Libray);
            HelpMenu = new MenuUC(Environment.CurrentDirectory + @"\..\..\Images\Menu\Help.png", Common.MenuTypes.Games);
            MainMenuStackPanel_Bottom.Children.Add(LibraryMenu);
            MainMenuStackPanel_Bottom.Children.Add(HelpMenu);

            HomePage = new HomePage();
            MainPageFram.Content = HomePage;
        }
    }
}

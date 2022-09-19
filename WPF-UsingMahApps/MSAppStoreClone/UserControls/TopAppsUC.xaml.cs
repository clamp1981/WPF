using System;
using System.Collections.Generic;
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

    public enum TopAppsButtonType
    {
        TopApps,
        TopGames,
        Featured
       
    }

    public class TopAppsButtonClickedEventArgs : EventArgs
    {
        public TopAppsButtonType ButtonType { get; private set; }
        public TopAppsButtonClickedEventArgs(TopAppsButtonType buttonType )
        {
            this.ButtonType = buttonType;
        }
    }
    /// <summary>
    /// Interaction logic for TopAppsUC.xaml
    /// </summary>
    public partial class TopAppsUC : UserControl
    {
        public event EventHandler<TopAppsButtonClickedEventArgs> TopAppsButtonClicked;
        protected virtual void OnTopAppsButtonClicked(TopAppsButtonClickedEventArgs e)
        {
            TopAppsButtonClicked?.Invoke( this, e );
        }
        public TopAppsUC()
        {
            InitializeComponent();

            var files = Directory.GetFiles(Environment.CurrentDirectory + @"..\..\..\Images\Home", "*.png", SearchOption.TopDirectoryOnly).ToList();
            Random rand = new Random();

            List<int> indexs = new List<int>();
            int iSelect;
            for (int i = 0; i < 5; i++) //필요한 갯수 입력 필요, 6번
            {
                do
                {
                    iSelect = new Random().Next(0, 5);
                }
                while (indexs.Contains(iSelect));

                indexs.Add(iSelect);

            }

            this.MainImage.Source = new BitmapImage(new Uri(files[indexs[0]]));
            this.SubImage01.Source = new BitmapImage(new Uri(files[indexs[1]]));
            this.SubImage02.Source = new BitmapImage(new Uri(files[indexs[2]]));
            this.SubImage03.Source = new BitmapImage(new Uri(files[indexs[3]]));
            this.SubImage04.Source = new BitmapImage(new Uri(files[indexs[4]]));
        }

        private void TopAppsButton_Click(object sender, RoutedEventArgs e)
        {
            OnTopAppsButtonClicked( new TopAppsButtonClickedEventArgs( TopAppsButtonType.TopApps ));
        }

        private void FeaturedButton_Click(object sender, RoutedEventArgs e)
        {
            OnTopAppsButtonClicked(new TopAppsButtonClickedEventArgs(TopAppsButtonType.Featured));
        }

        private void TopGamesButton_Click(object sender, RoutedEventArgs e)
        {
            OnTopAppsButtonClicked(new TopAppsButtonClickedEventArgs(TopAppsButtonType.TopGames));
        }

    }
}

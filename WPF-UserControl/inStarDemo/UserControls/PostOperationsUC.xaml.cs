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

namespace inStaDemo.UserControls
{
    /// <summary>
    /// Interaction logic for PostOperationsUC.xaml
    /// </summary>
    public partial class PostOperationsUC : UserControl
    {
        public bool PostLiked { get; set; }
        public PostOperationsUC()
        {
            InitializeComponent();
            PostLiked = false;
        }

        private void imageLike_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TogglePostLiked();
        }

        public void TogglePostLiked()
        {
            string uri = Environment.CurrentDirectory + @"\..\..\icons\";
            uri += PostLiked ? "like.png" : "liked.png";
            imageLike.Source = new BitmapImage(new Uri(uri, UriKind.RelativeOrAbsolute));
            PostLiked = !PostLiked;
        }
    }
}

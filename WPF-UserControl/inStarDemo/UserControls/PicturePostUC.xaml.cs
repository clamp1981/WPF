using inStarDemo.Models;
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
    /// Interaction logic for PicturePostUC.xaml
    /// </summary>
    public partial class PicturePostUC : UserControl
    {
        public PicturePostUC(PicturePostModel model)
        {
            InitializeComponent();
            this.ImageOfPost.Source = model.PostImage;
        }

        private void ContentControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PostOp.TogglePostLiked();
        }
    }
}

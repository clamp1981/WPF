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

namespace MSAppStoreClone.UserControls
{
    /// <summary>
    /// ScreenShotUC.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ScreenShotUC : UserControl
    {
        List<Image> ScreenShotImageList;
        public ScreenShotUC( List<string> imagPaths )
        {
            InitializeComponent();
            ScreenShotImageList = new List<Image>();
            ScreenShotList.ItemsSource = ScreenShotImageList;

            foreach (var path in imagPaths)
            {
                Image image = new Image();
                image.Margin = new Thickness(5);
                image.Source = new BitmapImage( new Uri(path) );
                image.Height = 200;
                image.Width = 300;
                ScreenShotImageList.Add(image);
            }
        }

        private void ScrollLeftButton_Click(object sender, RoutedEventArgs e)
        {
            MainScrollViewer.ScrollToHorizontalOffset(MainScrollViewer.HorizontalOffset + 10);
        }

        private void ScrollRightButton_Click(object sender, RoutedEventArgs e)
        {
            MainScrollViewer.ScrollToHorizontalOffset(MainScrollViewer.HorizontalOffset - 10);
        }

        private void ScrollRightButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }


        /// <summary>
        /// 마우스 휠 이벤트 무시 하고 상위 컨트롤에 마우스 휠 이벤트 보내기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
            var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
            eventArg.RoutedEvent = UIElement.MouseWheelEvent;
            eventArg.Source = sender;

            var parent = ((Control)sender).Parent as UIElement;
            parent.RaiseEvent(eventArg);
        }
    }
}

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
using System.Windows.Shapes;

namespace MenuDemo
{
    /// <summary>
    /// Interaction logic for ContextMenuDemo.xaml
    /// </summary>
    public partial class ContextMenuDemo : Window
    {
        public ContextMenuDemo()
        {
            InitializeComponent();
        }

        private void RichTextBox_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {           
            ContextMenu cm = this.FindResource("cmRichTextBox") as ContextMenu;
            cm.PlacementTarget = sender as RichTextBox;
            
            cm.IsOpen = true;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            var selection = richTextBox.Selection;
            if (selection.IsEmpty)
                return;

            if (item.Header.Equals("Bold"))
                selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            else if(item.Header.Equals("Italic"))
                selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
        }

        private void richTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void MenuItem_Checked(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            var selection = richTextBox.Selection;
            if (selection.IsEmpty)
                return;

            if (item.Header.Equals("Bold"))
                selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            else if (item.Header.Equals("Italic"))
                selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
        }

        private void MenuItem_Unchecked(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            var selection = richTextBox.Selection;
            if (selection.IsEmpty)
                return;

            if (item.Header.Equals("Bold"))
                selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);
            else if (item.Header.Equals("Italic"))
                selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Normal);
        }
    }
}

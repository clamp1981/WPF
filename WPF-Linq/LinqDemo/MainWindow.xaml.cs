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

namespace LinqDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<int> _basicList = null;
        public MainWindow()
        {
            InitializeComponent();
            _basicList = new List<int>() { 2, 4, 5, 6, 1, 7, 8, 9 };

            string list = ConvertListToString(_basicList);
            this.NumberListLabel.Content = list;
            this.ResultNumberListLabel.Content = list;
        }


        private string ConvertListToString( List<int> numbers )
        {
            string list = "";
            foreach (var number in numbers)
            {
                if (number == numbers.Last())
                    list += number.ToString();
                else
                    list += number.ToString() + ",";
            }

            return list;
        }

        private void btnOddNumbers_Click(object sender, RoutedEventArgs e)
        {
            this.ResultNumberListLabel.Content = ConvertListToString(_basicList.Where(x => (x % 2) != 0).ToList());
        }

        private void btnBasicNumbers_Click(object sender, RoutedEventArgs e)
        {
            this.ResultNumberListLabel.Content = ConvertListToString(_basicList);
        }

        private void btnEvenNumbers_Click(object sender, RoutedEventArgs e)
        {
            this.ResultNumberListLabel.Content = ConvertListToString(_basicList.Where(x => (x % 2) == 0).ToList());
        }
    }
}

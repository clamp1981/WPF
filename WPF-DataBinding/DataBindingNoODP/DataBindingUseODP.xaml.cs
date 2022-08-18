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

namespace DataBindingNoODP
{

    public enum Taste
    {
        Sweet = 0,
        Sour,
        Bitter,
        Salty
    }

    public enum Countries
    {
        Korea = 0,
        China,
        Japan,
        Rusia
    }


    /// <summary>
    /// Interaction logic for DataBindingUseODB.xaml
    /// </summary>
    public partial class DataBindingUseODP : Window
    {
        public DataBindingUseODP()
        {
            InitializeComponent();
        }
    }
}

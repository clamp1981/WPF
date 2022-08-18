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

namespace GridDemo
{
    /// <summary>
    /// Interaction logic for CatYears.xaml
    /// </summary>
    public partial class CatYears : Window
    {
        public CatYears()
        {
            InitializeComponent();
        }

        private void tbCatBirthYear_KeyUp(object sender, KeyEventArgs e)
        {
            if( e.Key == Key.Enter )
            {
                try
                {
                    int catYear= Convert.ToInt32(tbCatBirthYear.Text);
                    string catage = "";
                    if (catYear <= 1)
                    {
                        catage = $"Your Cat is 0~15 years old";
                    }                       
                    else if(catYear >= 2 && catYear < 25 )
                    {
                        catage = $"Your Cat is {(((catYear - 2) * 4) + 24).ToString()} years old";
                       
                    }
                    else
                    {
                        catage = "You enter a value that is not between 0-25.";
                    }
                    this.tblockCatAge.Text = catage;
                }
                catch ( Exception ex )
                {
                    this.tblockCatAge.Text = $"Your Cat is 0 years old";
                }
               
            }

        }
    }
}

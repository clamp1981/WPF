using Microsoft.Win32;
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

namespace Dialogs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            op.Filter = "Text Files(*.txt)|*.txt";
            if( op.ShowDialog() == true )
            {
                DisplayText(op.FileName);
            }
        }

        private void DisplayText( string path )
        {
            string text = File.ReadAllText(path);
            richTextBox.AppendText(text);
        }

        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sp = new SaveFileDialog();
            sp.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            sp.Filter = "Text Files(*.txt)|*.txt";           
            if( sp.ShowDialog() == true )
            {
                if (sp.FileName != "")
                {
                    File.WriteAllText(sp.FileName, GetRichTextBoxData());
                }
            }
        }

        private string GetRichTextBoxData()
        {
            TextRange textRange = new TextRange(
                           richTextBox.Document.ContentStart,
                           richTextBox.Document.ContentEnd
                       );

            return textRange.Text;
        }
    }
}

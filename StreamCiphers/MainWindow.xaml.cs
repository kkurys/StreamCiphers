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

namespace StreamCiphers
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

        private void generator_checked(object sender, RoutedEventArgs e)
        {
            fileTB.IsEnabled = false;
            modeGB.IsEnabled = false;
        }

        private void encryption_checked(object sender, RoutedEventArgs e)
        {
            fileTB.IsEnabled = true;
            
            RadioButton checkedRB = (RadioButton)sender;
            if (checkedRB.Name == "ex3")
            {
                modeGB.IsEnabled = true;
            }
            else
            {
                modeGB.IsEnabled = false;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ex1.IsChecked = true;
            encrypt.IsChecked = true;
            outputTB.IsEnabled = false;
            fileTB.IsEnabled = false;
            modeGB.IsEnabled = false;
        }
    }
}

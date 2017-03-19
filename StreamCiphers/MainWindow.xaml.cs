using StreamCiphers_Logic;
using System.Windows;
using System.Windows.Controls;

namespace StreamCiphers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LFSR lfsr = new LFSR();
        AutokeyCiphertext autokey = new AutokeyCiphertext();

        ICipher _cipher;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void generator_checked(object sender, RoutedEventArgs e)
        {
            fileTB.IsEnabled = false;
            modeGB.IsEnabled = false;

            _cipher = lfsr;
        }

        private void encryption_checked(object sender, RoutedEventArgs e)
        {
            fileTB.IsEnabled = true;
            
            RadioButton checkedRB = (RadioButton)sender;
            var _radiobutton = sender as RadioButton;
            if (_radiobutton.Name == "ex2")
            {
                // _cipher = autokey;
            }
            else
            {
                // _cipher = ...;
            }
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
            fileTB.IsEnabled = true;

        }

        private void runButton_Click(object sender, RoutedEventArgs e)
        {
            var _seed = seedTB.Text;
            var _polynomial = polynomialTB.Text;

            _cipher.Init(_seed, _polynomial);

            var result = _cipher.GetOutput();
            outputTB.Text = result;
        }
    }
}

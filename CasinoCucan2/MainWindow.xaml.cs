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

namespace CasinoCucan2
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

        private void OpenReg_Click(object sender, RoutedEventArgs e)
        {
            RegWindow regOpenWindow = new RegWindow();
            regOpenWindow.Show();
            Close();
        }

        private void OpenLogIn_Click(object sender, RoutedEventArgs e)
        {
            LogInWindow logInOpenWindow = new LogInWindow();
            logInOpenWindow.Show();
            Close();
        }
    }
}

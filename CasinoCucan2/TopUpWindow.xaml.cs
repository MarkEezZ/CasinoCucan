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
using System.IO;

namespace CasinoCucan2
{
    /// <summary>
    /// Логика взаимодействия для TopUpWindow.xaml
    /// </summary>
    public partial class TopUpWindow : Window
    {
        public int topUppedBalance;
        User temoraryUser;
        TextBlock _textBlockBalance;
        public TopUpWindow(User user, TextBlock textBlockBalance)
        {
            InitializeComponent();
            temoraryUser = user;
            _textBlockBalance = textBlockBalance;
        }

        public void confirmTopUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                topUppedBalance = Convert.ToInt32(amountTopUp.Text);
                temoraryUser.Balance += topUppedBalance;
                _textBlockBalance.Text = Convert.ToString(temoraryUser.Balance);

                Close();
            } catch
            {
                MessageBox.Show("You are near of the Int limit", "Error!");
            }
        }
    }
}

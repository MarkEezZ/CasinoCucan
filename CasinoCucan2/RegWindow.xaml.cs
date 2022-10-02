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
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
        }

        private void ApplyRegButton_Click(object sender, RoutedEventArgs e)
        {
            login.Text = login.Text.Trim();
            pass1.Text = pass1.Text.Trim();
            pass2.Text = pass2.Text.Trim();

            if (!string.IsNullOrEmpty(login.Text) && login.Text.Length <= 20 && !login.Text.Contains(" "))
            {
                if (!string.IsNullOrEmpty(pass1.Text) && pass1.Text.Length <= 20 && !login.Text.Contains(" "))
                {
                    if (pass2.Text == pass1.Text)
                    {
                        using (FileStream stream = new FileStream("C:/Users/goog5/Desktop/My Github/CasinoCucan2/CasinoCucan2/userData/usersList.txt", FileMode.Append))
                        {
                            string userData = login.Text + " " + pass2.Text;
                            byte[] userDataByte = Encoding.Default.GetBytes(userData);

                            stream.Write(userDataByte, 0, userDataByte.Length);
                        }
                        File.AppendAllText("C:/Users/goog5/Desktop/My Github/CasinoCucan2/CasinoCucan2/userData/usersList.txt", "\n");

                        using (FileStream stream2 = new FileStream("C:/Users/goog5/Desktop/My Github/CasinoCucan2/CasinoCucan2/userData/" + login.Text + "Balance.txt", FileMode.Create))
                        {
                            string startBalance = "0";
                            byte[] startBalanceByte = Encoding.Default.GetBytes(startBalance);

                            stream2.Write(startBalanceByte, 0, startBalanceByte.Length);
                        }

                        MainWindow mainOpenWindow = new MainWindow();
                        mainOpenWindow.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Passwords missmatch. Please, try again.", "Error!");
                    }
                }
                else
                {
                    MessageBox.Show("Password is incorrect. Please, try again.", "Error!");
                }
            }
            else
            {
                MessageBox.Show("Login field filled in incorrect.", "Error!");
            }
        }

        private void exitRegButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

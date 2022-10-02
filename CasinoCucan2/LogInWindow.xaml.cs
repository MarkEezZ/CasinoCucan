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
    /// Логика взаимодействия для LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        string[] userList;
        public string gettedLogin;
        public string gettedPass;

        public LogInWindow()
        {
            InitializeComponent();
            userList = File.ReadAllLines("C:/Users/goog5/Desktop/My Github/CasinoCucan2/CasinoCucan2/userData/usersList.txt");
        }

        private void ApplyLogInButton_Click(object sender, RoutedEventArgs e)
        {
            login.Text = login.Text.Trim();
            pass.Text = pass.Text.Trim();
            gettedLogin = login.Text;
            gettedPass = pass.Text;

            string userDataLog = login.Text + " " + pass.Text;
            int likenessCounter = 0;
            foreach (string element in userList)
            {
                if (userDataLog == element)
                {
                    likenessCounter++;
                }
            }

            if (likenessCounter == 1)
            {
                GameWindow gameOpenWindow = new GameWindow(gettedLogin, gettedPass);
                gameOpenWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("User is not found", "Error");
            }
        }

        private void exitRegButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

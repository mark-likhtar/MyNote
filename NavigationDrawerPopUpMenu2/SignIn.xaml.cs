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
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;

namespace MyNote
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
        }

        public UserDbContext db = new UserDbContext();

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (textboxName.Text.Length == 0)
            {
                errormessage.Text = "Введите имя.";
                textboxName.Focus();
            }
            else if (!Regex.IsMatch(textboxName.Text, @"^\w"))
            {
                errormessage.Text = "Введите имя";
                textboxName.Select(0, textboxName.Text.Length);
                textboxName.Focus();
            }
            else
            {
                string login = textboxName.Text;
                string password = PasswordBox.Password;

                if (db.Users.FirstOrDefault(x => x.Login == login)?.Password == password)
                {
                    User user = db.Users.FirstOrDefault(x => x.Login == login);
                     
                    MainWindow welcome = new MainWindow(user);
                    
                welcome.Show();
                Close();
                }
                else
                {
                    errormessage.Text = "Неверный логин или пароль!";
                }


                



               
                

                
            }
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            SignUp registration = new SignUp();
            registration.Show();

        }
    }
}

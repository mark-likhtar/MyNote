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
using System.Text.RegularExpressions;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace MyNote
{
    /// <summary>
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }
       

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Reset()
        {
            textboxFirstName.Text = "";
            textboxLastName.Text = "";
            textboxName.Text = "";
            PasswordBox.Password = "";
        }

        async private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (textboxName.Text.Length == 0 || textboxFirstName.Text.Length == 0 || textboxLastName.Text.Length == 0)
            {
                errormessage.Text = "Введите данные";
                textboxName.Focus();
                await Task.Delay(2000);
                errormessage.Text = "";
            }
            else if (!Regex.IsMatch(textboxName.Text, @"\w[0-9a-zA-Z]"))
            {
                errormessage.Text = "Введите корректный логин";
                textboxName.Select(0, textboxName.Text.Length);
                textboxName.Focus();
                await Task.Delay(2000);
                errormessage.Text = "";
            }
            else
            {
                string firstname = textboxFirstName.Text;
                string lastname = textboxLastName.Text;
                string login = textboxName.Text;
                string password = PasswordBox.Password;
                if (PasswordBox.Password.Length == 0 || !Regex.IsMatch(password, @"^\w[0-9a-zA-Z]"))
                {
                    errormessage.Text = "Введите пароль";
                    PasswordBox.Focus();
                    await Task.Delay(2000);
                    errormessage.Text = "";
                }
                else
                {
                     using (UserDbContext db = new UserDbContext())
                    {
                        User user = new User
                        {
                            FirstName = firstname,
                            LastName = lastname,
                            Login = login,
                            Password = password
                        };

                        db.Users.Add(user);
                        db.SaveChanges();   
                    }
                    errormessage.Text = "Зерегестрирован";
                    Reset();
                    await Task.Delay(2000);
                    errormessage.Text = "";
                }
            }
            
        }

        private void DragEvent(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}

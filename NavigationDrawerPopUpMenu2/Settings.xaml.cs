using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyNote
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }
        public UserDbContext db = new UserDbContext();
        public User user = MainWindow.user;

        async private void changeLogin_Click(object sender, RoutedEventArgs e)
        {
            errors.Text = "";
            string Login = newLogin.Text;
            if (Login != "" && Regex.IsMatch(Login, @"^\w[0-9a-zA-Z]"))
            {
                db.Database.ExecuteSqlCommand("Update Users set Login = '" + Login + "' where Id=" + user.Id);
                db.SaveChanges();
                errors.Text = "Логин сменен";
                await Task.Delay(2000);
                errors.Text = "";
            }
            else { errors.Text = "Введите новый логин";
                await Task.Delay(2000);
                errors.Text = "";
            }
    }

        async private void changePassword_Click(object sender, RoutedEventArgs e)
        {
            string oldPas = oldPassword.Text;
            string newPas = newPassword.Text;
            if (oldPas == user.Password)
            {
                if (newPas != "" && Regex.IsMatch(newPas, @"^\w[0-9a-zA-Z]"))
                {
                    db.Database.ExecuteSqlCommand("Update Users set Password = '" + newPas + "' where Id =" + user.Id);
                    db.SaveChanges();
                    errors.Text = "Пароль сменен";
                    await Task.Delay(2000);
                    errors.Text = "";
                }
                else { errors.Text = "Введите новый пароль";
                    await Task.Delay(2000);
                    errors.Text = "";
                }
            }
            else { errors.Text = "Неверный пароль";
                await Task.Delay(2000);
                errors.Text = "";
            }
    }

        async private void changeFirst_Click(object sender, RoutedEventArgs e)
        {
            errors.Text = "";
            string first = newName.Text;
            if (first != "")
            {
                db.Database.ExecuteSqlCommand("Update Users set FirstName = '" + first + "' where Id=" + user.Id);
                db.SaveChanges();
                errors.Text = "Имя изменено";
                await Task.Delay(2000);
                errors.Text = "";
            }
            else { errors.Text = "Введите новое имя";
                await Task.Delay(2000);
                errors.Text = "";
            }
        }

        async private void changeLast_Click(object sender, RoutedEventArgs e)
        {
            errors.Text = "";
            string last = newLastName.Text;
            if (last != "")
            {
                db.Database.ExecuteSqlCommand("Update Users set LasrName = '" + last + "' where Id=" + user.Id);
                db.SaveChanges();
                errors.Text = "Фамилия изменена";
                await Task.Delay(2000);
                errors.Text = "";
            }
            else { errors.Text = "Введите новую фамилию";
                await Task.Delay(2000);
                errors.Text = "";
            }
        }
    }
}

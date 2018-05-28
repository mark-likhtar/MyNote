using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;


namespace MyNote
{
    public partial class NoteControl : UserControl
    {
        public List<Note> notesList;
        public UserDbContext db = new UserDbContext();
        public User user = MainWindow.user;
        public NoteControl()
        {
            InitializeComponent();

        }
        int noteId;

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string keyword = searchData.Text;
            var notess = db.Database.SqlQuery<Note>("Select * from Notes where Title like '%" + keyword + "%' and User_Id = " + user.Id).ToList();
            foreach (var note in notess)
            {
                grdEmployee.ItemsSource = notess;
            }

        }

        private void ShowNotes()
        {
            notesList = db.Notes.Where(u => u.User.Id == user.Id).ToList();
            grdEmployee.ItemsSource = notesList;
        }

        private void grdEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Note row = (Note)grdEmployee.SelectedItem;
            if (row != null)
            {
                noteId = row.Id;
                search_Copy.Text = row.Title.ToString();
                textBoxText.Text = row.Text.ToString();
                DatePick.Text = row.Time.ToShortDateString();
            }
        }

        async private void Update_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = DatePick.DisplayDate;
            string title = search_Copy.Text;
            string notes = textBoxText.Text;
            db.Database.ExecuteSqlCommand("Update Notes set Title='" + title + "', Text='" + notes + "' ,Time='" + date + "' where Id = " + noteId);
            db.SaveChanges();
            var notess = db.Database.SqlQuery<Note>("Select * from Notes where User_Id = " + user.Id).ToList();
            foreach (var note in notess)
            {
                grdEmployee.ItemsSource = notess;
            }
            errors.Text = "Изменено";
            await Task.Delay(2000);
            errors.Text = "";

        }

        async private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Note item = grdEmployee.SelectedItem as Note;
            Archive addItem = new Archive
            {
                Title = item.Title,
                Text = item.Text,
                Time = item.Time,
                User_Id = item.User_Id
            };
            db.Archives.Add(addItem);
            db.Database.ExecuteSqlCommand("Delete from Notes where Id=" + item.Id);
            db.SaveChanges();
            ShowNotes();
            errors.Text = "Удалено";
            await Task.Delay(2000);
            errors.Text = "";

        }

        public void Reset()
        {
            search_Copy.Text = "";
            textBoxText.Text = "";
            DatePick.Text = "";
        }
        public Timer timer;


        async private void Save_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = DatePick.DisplayDate;
            string title = search_Copy.Text;
            string notes = textBoxText.Text;

            if (title != "" && notes != "" && date != null)
            {
                Note note = new Note
                {
                    Title = title,
                    Time = date,
                    Text = notes,
                    User_Id = user.Id
                };
                db.Notes.Add(note);
                db.SaveChanges();
                ShowNotes();
                Reset1();
                errors.Text = "Добавлено";
                await Task.Delay(2000);
                errors.Text = "";

            } else { errors.Text = "Заполните поля";
                await Task.Delay(2000);
                errors.Text = "";
            }
        }


       
        public void Reset1()
        {
            search_Copy.Text = "";
            textBoxText.Text = "";
        }

        private void textBoxText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            using (UserDbContext db = new UserDbContext())
            {

                ShowNotes();
            }
        }
    }
}

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
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;


namespace MyNote
{
    /// <summary>
    /// Interação lógica para UserControlHome.xam
    /// </summary>
    public partial class UserControlHome : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DQVBACB; Initial Catalog=MyNote; Integrated Security=True;");
        public List<Note> notes;
        public UserDbContext db = new UserDbContext();
        public User user = MainWindow.user;
        public UserControlHome()
        {
            InitializeComponent();
            

        }


        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string keyword = searchData.Text;
            string CmdString = "SELECT * FROM Note WHERE Title LIKE '%" + keyword + "%' ";
            SqlCommand sqlCmd = new SqlCommand(CmdString, con);
            DataTable dt = new DataTable("Employee");
            SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
            sda.Fill(dt);
            grdEmployee.ItemsSource = dt.DefaultView;
        }

        private void grdEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Reset()
        {
            search_Copy.Text = "";
            textBoxText.Text = "";
            DatePick.Text = "";
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = DatePick.DisplayDate;
            string title = search_Copy.Text;
            string notes = textBoxText.Text;
            
            if (title != "" && notes!="")
            {
                Note note = new Note
                {
                    Title = title,
                    Time = date,
                    Text = notes,
                    User_Id= user.Id
                };
                db.Notes.Add(note);
                db.SaveChanges();
                Reset1();

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
               
                notes = db.Notes.Where(u => u.User.Id == user.Id).ToList();
                grdEmployee.ItemsSource = notes;
            }
        }
    }
}

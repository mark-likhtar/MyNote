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

namespace MyNote
{
    /// <summary>
    /// Логика взаимодействия для ArchiveWrap.xaml
    /// </summary>
    public partial class ArchiveWrap : UserControl
    {
        public ArchiveWrap()
        {
            InitializeComponent();
        }
        public UserDbContext db = new UserDbContext();
        private void delArchive_Click(object sender, RoutedEventArgs e)
        {
            var delId = this.delItem.Tag.ToString();
            db.Database.ExecuteSqlCommand("Delete from Archives where Id=" + delId);
            db.SaveChanges();
            ArchiveControl.arwnd.AddArchiveChildren();
        }

        private void backNotice_Click(object sender, RoutedEventArgs e)
        {

            var addId = this.backItem.Tag.ToString();
            var archivesList = db.Archives.Where(u => u.Id.ToString() == addId).ToList();
            foreach (var n in archivesList)
            {
                Note note = new Note
                {
                    Title = n.Title,
                    Text = n.Text,
                    Time = n.Time,
                    User_Id = n.User_Id
                };
                db.Notes.Add(note);
                db.SaveChanges();
                db.Database.ExecuteSqlCommand("Delete from Archives where Id=" + addId);
                db.SaveChanges();
                ArchiveControl.arwnd.AddArchiveChildren();


            }
        }
    }
}

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
    /// Логика взаимодействия для ArchiveControl.xaml
    /// </summary>
    public partial class ArchiveControl : UserControl
    {
        public ArchiveControl()
        {
            InitializeComponent();
            AddArchiveChildren();
            arwnd = this;
        }

        public UserDbContext db = new UserDbContext();
        public User user = MainWindow.user;
        public static ArchiveControl arwnd;


        public void AddArchiveChildren()
        {
            var archivesList = db.Archives.Where(u => u.User.Id == user.Id).ToList();
            wrapArchive.Children.Clear();
            foreach (var n in archivesList)
            {

                ArchiveWrap item = new ArchiveWrap();
                item.ArchiveText.Text = n.Text;
                item.ArchiveTitle.Text = n.Title;
                item.ArchiveDate.Text = n.Time.ToString();
                item.delItem.Tag = n.Id;
                item.backItem.Tag = n.Id;
                wrapArchive.Children.Add(item);
            }
        }
    }
}

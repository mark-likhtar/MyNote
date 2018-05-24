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
    /// Логика взаимодействия для NoticeWrap.xaml
    /// </summary>
    public partial class NoticeWrap : UserControl
    {
        public NoticeWrap()
        {
            InitializeComponent();
        }

        public UserDbContext db = new UserDbContext();
        private void delItem_Click(object sender, RoutedEventArgs e)
        {
            var delId = this.delItem.Tag.ToString();
            db.Database.ExecuteSqlCommand("Delete from Notices where Id=" + delId);
            db.SaveChanges();
            NoticeControl.ntwnd.AddNoticeChildren();
            //MessageBox.Show(delId);
            // var noticesList = db.Notices.ToList();
            //var noticesDel = db.Notices.Where(n => n.Id.ToString() == delId).ToList();

        }
    }
}

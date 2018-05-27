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
    /// Interação lógica para UserControlCreate.xam
    /// </summary>
    public partial class NoticeControl : UserControl
    {

        
        public UserDbContext db = new UserDbContext();
        public User user = MainWindow.user;
        public static NoticeControl ntwnd;
        public NoticeControl()
        {
            InitializeComponent();
            AddNoticeChildren();
            ntwnd = this;
        }

        

        private void delItem_Click(object sender, RoutedEventArgs e)
        {
            var deleteNotice = db.Notices.Where(u => u.User.Id == user.Id).ToList();
            var did = this.Tag;
            MessageBox.Show(did.ToString());
        }

        async private void AddNotice_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateNotice = new DateTime();
            if (NoticeData.DisplayDate.Date != null && NoticeTime.SelectedTime!= null)
            {  dateNotice = NoticeData.DisplayDate.Date + NoticeTime.SelectedTime.Value.TimeOfDay; }
            if (dateNotice < DateTime.Now)
            {
                errors.Text = "Некорректная дата";
                await Task.Delay(2000);
                errors.Text = "";
            }
            else
            {
                string noticeText = NoticeText.Text;
                if (noticeText != "" && dateNotice != null)
                {
                    Notice notice = new Notice
                    {
                        Text = noticeText,
                        Time = dateNotice,
                        User_Id = user.Id
                    };
                    db.Notices.Add(notice);
                    db.SaveChanges();
                    AddNoticeChildren();
                    ResetNotice();
                }
                else
                {
                    errors.Text = "Заполните поля";
                    await Task.Delay(2000);
                    errors.Text = "";
                }
            }
        }

        public void AddNoticeChildren()
        {
            var noticesList = db.Notices.Where(u => u.User.Id == user.Id).ToList();
            wrapNotice.Children.Clear();
            foreach (var n in noticesList)
            {

                NoticeWrap item = new NoticeWrap();
                item.NoticeText.Text = n.Text;
                item.NoticeDate.Text = n.Time.ToString();
                item.delItem.Tag = n.Id;
                wrapNotice.Children.Add(item);
            }
        }

        private void ResetNotice()
        {
            NoticeText.Text = "";
            NoticeData.Text = "";
            NoticeTime.Text = "";
        }
    }
}

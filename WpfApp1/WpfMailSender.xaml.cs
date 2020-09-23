using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;
using Microsoft.Win32;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для WpfMailSender.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {

        
        public WpfMailSender()
        {
            InitializeComponent();

        }

        private void ButtonSendMail_OnClick(object sender, RoutedEventArgs e)
        {
            List<string> listMails = new List<string> {"kanadei@mail.ru"};
            foreach (var mail in listMails)
            {
                using (MailMessage mm = new MailMessage("kanadeiar@gmail.com", mail))
                {
                    mm.Subject = "Привет из C#";
                    mm.Body = "Привет!";
                    mm.IsBodyHtml = false;
                    using (SmtpClient sc = new SmtpClient("smtp.gmail.com", 587))
                    {
                        sc.EnableSsl = true;
                        sc.Credentials = new NetworkCredential("kanadeiar@gmail.com", PasswordBox.Password);
                        try
                        {
                            sc.Send(mm);
                            SendEndWindow window = new SendEndWindow();
                            window.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Не удалось отправить!\n" + ex.ToString());
                        }
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет мир!");
            
            MailMessage mm = new MailMessage("kanadeiar@gmail.com","kanadei@mail.ru");
            mm.Subject = "Заголовок окна";
            mm.Body = "Содержимое письма";
            mm.IsBodyHtml = false;

            //https://myaccount.google.com/lesssecureapps
            SmtpClient sc = new SmtpClient("smtp.gmail.com",587);
            sc.EnableSsl = true;
            sc.Credentials = new NetworkCredential("kanadeiar@gmail.com", "");
            try
            {
                sc.Send(mm);
                Console.WriteLine("Письмо отправлено!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            

            Console.ReadKey();
        }
    }
}

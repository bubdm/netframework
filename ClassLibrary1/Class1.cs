using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        public static double GetSqrt(double x)
        {
            return Math.Sqrt(x);
        }
        public string SayHello(string name)
        {
            if (name == null)
                throw new ArgumentNullException("Not Parameter");
            return "Hello " + name;
        }

        public bool Good(string name, int age)
        {
            if (name.Length < 3)
                return false;
            if (age <= 0)
                return true;
            return true;
        }



        public string TemplateFolder { get; set; }
        public string FromTemplate(string name, string level)
        {
            string path = Path.Combine(TemplateFolder, "ExamCreatedTemplate.txt");
            string template = File.ReadAllText(path);
            template = template.Replace("{Name}", name);
            template = template.Replace("{Level}", level);

            return template;
        }
    }
}

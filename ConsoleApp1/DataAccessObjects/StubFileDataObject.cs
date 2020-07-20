using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataAccessObjects
{
    /// <summary> Объект-заглушка, фиктивное получение файлов из каталога </summary>
    public class StubFileDataObject : IDataAccess
    {
        public List<string> GetFiles()
        {
            List<string> list = new List<string>();
            list.Add("file1.txt");
            list.Add("file2.log");
            list.Add("file3.exe");
            list.Add("main.log");
            return list;
        }
    }
}

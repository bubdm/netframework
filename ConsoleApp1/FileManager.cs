using ConsoleApp1.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class FileManager
    {
        IDataAccess dataAccess; //уменьшение связанности применением IDataAccess
        public FileManager() //стандартный конструктор
        {
            dataAccess = new FileDataObject();
        }
        public FileManager(IDataAccess dataAccess) //тестировочный конструктор
        {
            this.dataAccess = dataAccess;
        }
        /// <summary> Поиск файла </summary>
        public bool FindFile(string filename)
        {
            List<string> files = dataAccess.GetFiles();
            foreach (var file in files)
            {
                if (file.Contains(filename))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

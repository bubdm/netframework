using ConsoleApp1.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

// InternalsVisibleTo - указывает, что типы, которые обычно доступны только в текущей сборке будут доступны также в сборке,
// которая определена в параметрах.
[assembly: InternalsVisibleTo("ClassLibrary1.Tests")]
namespace ConsoleApp1
{
    class FileManager
    {
        private IDataAccess dataAccess;

        public FileManager()
        {
            dataAccess = DataAccessFactory.Create();
        }

        /// <summary> Поиск файла </summary>
        public bool FindFile(string filename) //внедрение зависимости через интерфейс
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

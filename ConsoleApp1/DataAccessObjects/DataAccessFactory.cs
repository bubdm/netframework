using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataAccessObjects
{
    public class DataAccessFactory
    {
        private static IDataAccess dataAccess;
        /// <summary> Создание стандартного или заглушного класса </summary>
        internal static IDataAccess Create()
        {
            if (dataAccess != null)
                return dataAccess;
            return new FileDataObject();
        }
        [Conditional("DEBUG")]
        public static void SetDataAccessObject(IDataAccess customDataAccess)
        {
            dataAccess = customDataAccess;
        }
    }
}

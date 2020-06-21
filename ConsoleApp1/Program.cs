using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MyNumber
    {
        public int N { get; set; }
        public MyNumber(int n) => N = n;
        public static implicit operator int(MyNumber n) => n.N;
        public override string ToString()
        {
            return $"Класс: {N}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyNumber n = new MyNumber(1);
            Console.WriteLine(n);
            Console.ReadKey();
        }
    }
}

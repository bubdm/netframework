using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        class MySuperPuperArray
        {
            private int[] arr1; //приватный массив
            private int[] arr2; //приватный массив
            private int[] arr3; //приватный массив
            public MySuperPuperArray(int size)
            {
                arr1 = new int[size];
                arr2 = new int[size];
                arr3 = new int[size];
            }
            /// <summary> Индексатор-матрешка </summary>
            /// <param name="i">номер элемента</param>
            /// <param name="number">номер массива</param>
            /// <returns>элемент</returns>
            public int this[int i, int number]
            {
                get
                {
                    switch (number)
                    {
                        case 1: return arr1[i];
                        case 2: return arr2[i];
                        case 3: return arr3[i];
                        default: throw new ArgumentOutOfRangeException("Не делайте так!!!");
                    }
                }
                set
                {
                    switch (number)
                    {
                        case 1: arr1[i] = value; break;
                        case 2: arr2[i] = value; break;
                        case 3: arr3[i] = value; break;
                        default: throw new ArgumentOutOfRangeException("Никода не делайте!!!");
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            var mySuper = new MySuperPuperArray(10);
            for (int i = 0; i < 10; i++)
            {
                mySuper[i, 1] = i;
            }
            Console.WriteLine("Тест!");
            Console.ReadKey();
        }


    }
}

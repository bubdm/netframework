﻿using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Наша курсовая работа ***");
            while (true)
            {
                Console.WriteLine("\nВыберите домашнюю работу (q-выход):");
                Console.WriteLine("1 - Домашняя работа \"Написать программу Анкета\"" +
                                  " (выполнил: Тестов Тест Тестович)");
                string line = Console.ReadLine();
                if (String.Equals(line,"q"))
                    break;
                int.TryParse(line, out int numberHomeWork);
                switch (numberHomeWork)
                {
                    case 1:
                        Testov.Demo(); //демонстрация
                        break;
                    default:
                        Console.WriteLine("Нет домашней работы под таким номером!");
                        break;
                }
            }
            Console.WriteLine("Нажмите любую кнопку для выхода ...");
            Console.ReadKey();
        }
    }
}

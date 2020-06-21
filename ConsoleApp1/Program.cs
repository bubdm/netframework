using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MyUser
    {
        public string Name { get; set; }
        public MyUser(string name)
        {
            Name = name;
        }
        public void Say(string mes)
        {
            Console.WriteLine($"{Name} сказал {mes}");
            eventSay?.Invoke(this, mes);
        }
        //событие - что-нить сказать
        private Action<object, string> eventSay;
        public event Action<object, string> EventSay
        {
            add
            {
                Console.WriteLine($"{Name} стали слушать");
                eventSay += value;
            }
            remove
            {
                Console.WriteLine($"{Name} перестали слушать");
                if (eventSay != null) eventSay -= value;
            }
        }
        public void PrintHears()
        {
            foreach (var el in eventSay.GetInvocationList())
            {
                if (el.Target is MyUser user)
                {
                    Console.WriteLine(user.Name);
                }
            }
        }
        public void Hear(object obj, string mes)
        {
            var user = obj as MyUser;
            Console.WriteLine($"Человек {Name} услышал >>> {user.Name} сказал {mes}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyUser user1 = new MyUser("Федя");
            user1.Say("Привет мир!");
            Console.WriteLine();
            MyUser user2 = new MyUser("Петя");
            user1.EventSay += user2.Hear;
            user1.Say("Еще раз привет!");
            MyUser user3 = new MyUser("Дима");
            user1.EventSay += user3.Hear;
            Console.WriteLine("\nСлушают первого:");
            user1.PrintHears();
            Console.ReadKey();
        }
    }
}

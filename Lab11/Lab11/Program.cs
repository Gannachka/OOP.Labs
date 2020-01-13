﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
  
    class Program
    {
        static void Main(string[] args)
        {
            List <Time> list1= new List<Time>();
            Time time1 = new Time(21, 59, 2);
            Time time2 = new Time(16, 34, 56);
            Time time3 = new Time(4, 0, 45);
            Time time4 = new Time(11, 11, 30);
            Time time5 = new Time(23, 59, 59);
            Time time6 = new Time(12, 20, 34);
            Time time7 = new Time(1, 16, 32);
            Time time8 = new Time(19, 34, 23);
            Time time9 = new Time(9, 23, 27);
            Time time10 = new Time(23, 50, 25);
            list1.Add(time1);
            list1.Add(time2);
            list1.Add(time3);
            list1.Add(time4);
            list1.Add(time5);
            list1.Add(time6);
            list1.Add(time7);
            list1.Add(time8);
            list1.Add(time9);
            list1.Add(time10);
            Console.WriteLine();
            var result1 = from elem in list1 where elem.Hour == 4 && elem.Minute == 0 && elem.Second == 45 select elem;
            foreach (Time elem in result1)
                Console.WriteLine(elem);
            Console.WriteLine();
            var result2 = list1.OrderBy(s=>s.Hour);
            foreach (Time elem in result2)
                Console.WriteLine(elem);
            Console.WriteLine();
            Console.WriteLine("Утро");
            var morning = from elem in list1 where elem.Hour >5 && elem.Hour < 12 select elem;
            foreach (Time elem in morning)
                Console.WriteLine(elem);
            Console.WriteLine();
            Console.WriteLine("День");
            var day = from elem in list1 where elem.Hour >= 12 && elem.Hour < 16 select elem;
            foreach (Time elem in day)
                Console.WriteLine(elem);
            Console.WriteLine();
            Console.WriteLine("Вечер");
            var evening = from elem in list1 where elem.Hour >=16 && elem.Hour < 21 select elem;
            foreach (Time elem in evening)
                Console.WriteLine(elem);
            Console.WriteLine();
            Console.WriteLine("Ночь");
            var night = from elem in list1 where elem.Hour >=21 || elem.Hour <= 5 select elem;
            foreach (Time elem in night)
                Console.WriteLine(elem);
            Console.WriteLine();
            Console.WriteLine("Совпадают часы и минуты");
            var equal = from elem in list1 where elem.Hour == elem.Minute select elem;
            foreach (Time elem in equal)
                Console.WriteLine(elem);
            Console.WriteLine();
            int[] keys = { 21, 16, 4, 11, 23, 12, 1, 19, 9, 23 };
            var sometype = list1
                .Join(
                keys,
                w => w.Hour,
                q => q,
                (w, q) => new
                {
                    id = string.Format("{0}", q),
                    elem = w,
                }
                );
            foreach (var elem in sometype)
                Console.WriteLine(elem);
            List<User> users = new List<User>
            {
                new User {Name="Алина", Age=18, Languages = new List<string> {"английский", "белорусский" }},
                new User {Name="Вероника", Age=18, Languages = new List<string> {"английский", "французский" }},
                new User {Name="Никита", Age=20, Languages = new List<string> {"английский", "немецкий" }},
                new User {Name="Ксюша", Age=19, Languages = new List<string> {"испанский", "русский" }}
            };
            var selectedUsers = from user in users
                                from lang in user.Languages
                                where user.Age < 19
                                where lang == "английский"
                                select user;
            foreach (User user in selectedUsers)
                Console.WriteLine("{0} - {1}", user.Name, user.Age);
            decimal sum2 = users.Sum(k => k.Age);
            Console.WriteLine(sum2);
            string[] soft = { "Microsoft", "Google", "Apple" };
            string[] hard = { "Apple", "IBM", "Samsung" };

            var result = soft.Except(hard);
            foreach (string s in result)
                Console.WriteLine(s);
            Console.WriteLine();
            var result3 = soft.Concat(hard).Distinct().OrderBy(s => s.Length);
            foreach (string st in result3)
                Console.WriteLine(st);
        }
    }
}

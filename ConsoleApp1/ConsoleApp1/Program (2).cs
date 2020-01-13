using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"Минимальное допустимое число типа ulong {ulong.MinValue}");
            Console.WriteLine("Введите строку");
            string str1 = Console.ReadLine();
            string str2 = str1.Trim(new char[] { 'o', 'd', '!' });
            Console.WriteLine(str2);
            string[][] jaggedArray = new string[3][];
            jaggedArray[0] = new string[] { "a", "b", "c" };
            jaggedArray[1] = new string[] { "d", "e", "f" };
            jaggedArray[2] = new string[] { "g", "h", "i" };
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    System.Console.Write("{0}{1}", jaggedArray[i][j], j == (jaggedArray[i].Length - 1) ? "" : " ");
                }
                System.Console.WriteLine();
            }
            Card[] arr = new Card[5];
            Card a = new Card(11728732, 76126, 1);
            Card b = new Card(53921410, 5770, 1);
            Card c = new Card(17321898, 1660, 1);
            Card d = new Card(17321898, 10770, 1);
            Card e = new Card(17321898, 59346, 1);
            arr[0] = a;
            arr[1] = b;
            arr[2] = c;
            arr[3] = d;
            arr[4] = e;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{arr[i].ToString()}");
            }
            Card temp;
            for (int i = 0; i < arr.Length; i++)
                for (int j = i + 1; j < arr.Length; j++)
                    if (arr[i].Sum > arr[j].Sum)
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
            Console.WriteLine();
            for (int i=0; i<arr.Length; i++)
            {
                Console.WriteLine($"{arr[i].ToString()}");
            }
            Picture p = new Picture(5);
            p.gr[0] = new Point(1, 2);
            p.gr[1] = new Circle(3, 4, 5);
            p.gr[2] = new Point(6, 7);
            p.gr[3] = new Circle(8, 9, 10);
            p.gr[4] = new Point(11, 12);

            p.print();

            Console.ReadKey();
        }
    }
}

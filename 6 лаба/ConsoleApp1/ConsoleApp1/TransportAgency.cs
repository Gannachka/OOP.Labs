using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp1
{
    class TransportAgency
    {
        public Transport this[int i]
        {
            get
            {
                return list[i];
            }
        }
        public  List<Transport> list;
        
        public TransportAgency()
        {
            list = new List<Transport>();
        }
        public  void Add(Transport t)
        {
            list.Add(t);
        }
        public  void Remove(Transport t)
        {
            list.Remove(t);
        }
        public  void Show()
        {
            foreach(Transport t in list)
                Console.WriteLine(t+"\n");
        }


    }
    class Controller
    {
        public static void SortTransports(TransportAgency t)
        {
            Console.WriteLine("Класс контроллер остортировал Transport Agency по расходу топлива");
            t.list.Sort();
        }
        public static void ShowSpeed(int min,int max,TransportAgency t)
        {
            Console.WriteLine($"Транспорт со скоростью от {min} до {max}");
            foreach(Transport k in t.list)
            {
                if(k.Speed>min&&k.Speed<max)
                    Console.WriteLine(k+"\n");
            }
        }
        public static int GetAllCost(TransportAgency t)
        {
            int sum = 0;
            foreach(Transport k in t.list)
            {
                sum += k.Cost;
            }
            return sum;
        }
    }
}


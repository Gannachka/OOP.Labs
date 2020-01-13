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
            Car c1 = new Car("Audi", "black", 120, "J-500-1");
            Car c2 = new Car("WalkSwagen", "blue", 120, "e-500-1");
            Car c3 = new Car("Sitroen", "green", 130, "rw-500-1");
            Car c4 = new Car("Audi", "black", 120, "J-500-1");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++");
            c1.GetInfo();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++");
            ((IEngine)c1).GetInfo();
            Console.WriteLine(c1.Equals(c4));
            Console.WriteLine(c1.Equals(c2));
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++");
            c3.GetInfo();

            IEngine n = c3 as IEngine;
            if (n != null)
                n.GetInfo();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++");
            Train t1 = new Train("BelTrain", "blue", 100, true, 8);
            Train t2 = new Train("BelTrain", "green", 100, true, 8);
            Train t3 = new Train("BelTrain", "white", 70, false, 8);
            Train t4 = new Train("BelTrain", "blue", 120, false, 8);
            Train t5 = new Train("BelTrain", "orange", 100, true, 8);
            Transport tt1 = t1 as Transport;
            Transport tt2 = c1 as Transport;
            Console.WriteLine(tt1 is IEngine);
            Train t6 = tt2 as Train;
            if (t6 != null)
                Console.WriteLine("Первую машину удалось привести к типу Train");
            else
                Console.WriteLine("Преобразование не удалось");
            Printer p1 = new Printer();
            
            Transport tt5 = new Car("Opel", "white", 111, "J-213-1");
            Transport[] mass = { c1, c2, c3, t1, tt1, tt2, tt5 };
            foreach (Transport t in mass)
            {
                Console.WriteLine();
                p1.IAmPrinting(t);
            }


        }
    }
}

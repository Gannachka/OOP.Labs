using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car("Audi", "black", 120,10000,20, "k213-2", TypeOfCar.Passenger);
            Car c2 = new Car("Audi", "black", 144, 20000, 14, "kk-12", TypeOfCar.Passenger);
            Car c3 = new Car("Nissan", "black", 80, 15000, 15, "213-2", TypeOfCar.Passenger);
            Car c4 = new Car("Jeep", "black", 50, 18000, 9, "wet-213", TypeOfCar.Passenger);
            Car c5 = new Car("Lada", "black", 60, 8000, 20, "kre3-2", TypeOfCar.Gruz);
            Train t1 = new Train("BelTrain", "orange", 120, 20000, 30, true, 8);
            Train t2 = new Train("BelTrain", "white", 60, 10000, 20, false, 10);
            Train t3 = new Train("BelTrain", "black", 120, 20000, 25, true, 16);
            TransportAgency t = new TransportAgency();
            t.Add(c1);
            t.Add(c2);
            t.Add(c3);
            t.Add(c4);
            t.Add(c5);
            t.Add(t1);
            t.Add(t2);
            t.Add(t3);
            Console.WriteLine("Агенство до сортировки:");
            t.Show();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Стоимость всего транспорта:");
            Console.WriteLine(Controller.GetAllCost(t));
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++");
            t.Remove(c4);
            Controller.SortTransports(t);
            t.Show();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++");
            Controller.ShowSpeed(90, 150,t);
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine(t[2]);
            try
            {
                bool flag = true;
                Console.WriteLine("Exeption");
                Console.WriteLine($"Введите тип транспорта:(BelExpress or car)");
                string val1 = Console.ReadLine();
                t1.Label = val1;

            }
            catch (TransportTypeExeption ex)
            {
                t3.Label = "BelExpress";
                Console.WriteLine(ex.Message + "\n" + ex.TargetSite + "\n" + ex.StackTrace);

            }
            finally
            {
                Console.WriteLine("\n Блок finally");
            }
            Console.ReadKey();
        }
    }
}

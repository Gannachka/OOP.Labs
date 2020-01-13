using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Card : IComparable
    {
        Card[] data;
        Random RandomNumber = new Random();
        public int ExpData { get; set; }
        public int Sum { get; set; }
        public int Number { get; set; }
        static string Bank = "qwsdef";
        public int CompareTo(object obj)
        {
            return 0;
        }
        public Card(int number, int sum, int expdata)
        {
            Number = number;
            Sum = sum;
            ExpData = ExpData;
        }
        public override string ToString()
        {
            return $"Номер: {Number} ExpData: {ExpData} Сумма: {Sum}";
        }
    }
}

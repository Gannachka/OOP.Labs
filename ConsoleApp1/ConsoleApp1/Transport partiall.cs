using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Printer
    {
        public virtual void IAmPrinting(Transport t)
        {
            Console.WriteLine(t.GetType());
            Console.WriteLine(t.ToString());

        }
    }
    abstract partial class Transport
    {
        public override string ToString()
        {
            return $"{Label} марки,{Color} цвета,со скоростью {Speed}";
        }

    }
}

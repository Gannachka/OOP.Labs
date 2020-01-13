using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    class Program
    {

        static void Main(string[] args)
        {
            Reflector reflector = new Reflector("Lab12.Transport");
            reflector.AboutClass();
            reflector.PublicMethods();
            reflector.Fields();
            reflector.Properties();
            reflector.Interfaces();
            reflector.SpecifiedMethods("Object");
            reflector.RunTimeMethod(typeof(Transport),"toString");
        }
    }
}


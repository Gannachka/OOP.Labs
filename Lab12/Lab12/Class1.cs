using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Lab12
{
    interface Interable
    {
        void toString();
    }

    public  class Transport : Interable
    {
        protected int number;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }
        private int speed;
        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }
        protected int cost;
        public int Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
            }
        }
        virtual public void toString()
        {
            Console.WriteLine("Используем toString в классе Transport Номер " + number + " Скорость " + speed + " Объект едет в " + cost);
        }

        public Transport(int a, int b = 2, int c = 2)
        {
            number = a;
            cost = b;
            speed = c;
        }
        public Transport(int x)
        {
            number = x;
            cost = x;
            speed = x;
        }
    }
    public class Reflector
    {
        public Type type;
        public Reflector(string type)
        {
            this.type = Type.GetType(type, false, true);
        }
        public void AboutClass()
        {
            using (StreamWriter fstream = new StreamWriter("class.txt", false))
            {
                foreach (MemberInfo info in type.GetMembers())
                {
                   fstream.WriteLine(info.DeclaringType + " - " + info.MemberType + " - " + info.Name);
                }
            }
        }
        public void PublicMethods()
        {
            using (StreamWriter fstream = new StreamWriter("methods.txt", false))
            {
                foreach (MethodInfo method in type.GetMethods())
                {
                    if (method.IsPublic)
                    {
                        fstream.WriteLine(method.Name);
                    }
                }
            }
        }
        public void SpecifiedMethods(string arg)
        {
            using (StreamWriter fstream = new StreamWriter("specified_methods.txt", false))
            {
                foreach (MethodInfo method in type.GetMethods())
                {
                    ParameterInfo[] parameters = method.GetParameters();
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        if (arg.Contains(parameters[i].ParameterType.Name))
                        {
                            fstream.Write(method.ReturnType.Name + " - " + method.Name + " ( ");
                            fstream.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                        }
                    }
                }
            }
        }
        public void Fields()
        {
            using (StreamWriter fstream = new StreamWriter("fields.txt", false))
            {
                foreach (FieldInfo field in type.GetFields())
                {
                    fstream.Write(field.FieldType + " - " + field.Name);
                }
            }
        }
        public void Properties()//cвойство
        {
            using (StreamWriter fstream = new StreamWriter("properties.txt", false))
            {
                foreach (PropertyInfo prorertie in type.GetProperties())
                {
                    fstream.Write(prorertie.PropertyType + " - " + prorertie.Name);
                }
            }
        }
        public void Interfaces()
        {
            using (StreamWriter fstream = new StreamWriter("interfaces.txt", false))
            {
                foreach (Type interfaces in type.GetInterfaces())
                {
                    fstream.Write(interfaces.Name);
                }
            }
        }
        public void RunTimeMethod(Type type, string method)
        {
            Assembly asm = Assembly.LoadFrom(@"D:\2 курс\ООП\OOP-labs-1.0\Lab12\Lab12\obj\Debug\Lab12.exe");
            int k = 3;
            object programm = Activator.CreateInstance(type,k);
            MethodInfo newMethod = type.GetMethod(method);
            object result = newMethod.Invoke(programm, new object[] { });
            Console.WriteLine("Method of another instanse: {0}\nMethod's value: {1}", method, result);
        }
    }
}

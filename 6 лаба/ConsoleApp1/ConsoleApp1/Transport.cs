using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp1
{
    public struct Info
    {
        public string color;
        public string label;
    }
    //obj.CompareTo(obj2)
    public abstract partial class Transport:IComparable<Transport>
    {
        public int CompareTo(Transport t)
        {
            return this.Expenditure.CompareTo(t.Expenditure);
        }
        protected Info info;
        protected int speed;
        public int Cost { get; set; }
        public int Expenditure { get; set; }//Расход топлива
        public string Color
        {
            get => info.color;
            set => info.color = value;
        }
        public string Label
        {
            get => info.label;
            set => info.label = value;
        }
        public int Speed
        {
            get => speed;
            set
            {
                if (value > MaxSpeed)
                    speed = MaxSpeed;
                else
                    speed = value;
            }
        }
        public Transport(string label,string color,int speed,int cost,int exp)
        {
            Label = label;
            Color = color;
            Speed = speed;
            Cost = cost;
            Expenditure = exp;
            
        }
        public abstract int MaxSpeed { get; }
       


    }

    interface IEngine
    {
         string NameOfEngine { get; set; }
         void GetInfo();
    }
    public enum TypeOfCar {Passenger,Gruz,Bus}
    public class Car : Transport, IEngine
    {
        public Car(string label, string color, int speed,int cost,int exp, string name,TypeOfCar type) : base(label, color, speed,cost,exp)
        {
            NameOfEngine = name;
            TypeCar = type;
        }
        private string type;
        public TypeOfCar TypeCar
        {          
            set
            {
                if (value == TypeOfCar.Bus)
                    type = "автобус";
                if(value == TypeOfCar.Passenger)
                    type = "Пассажирская";
                if (value == TypeOfCar.Gruz)
                    type = "Грузовая";
            }
        }
        public override int MaxSpeed { get => 240; }
        public string NameOfEngine { get; set; }
        public virtual void GetInfo()
        {
            Console.WriteLine("машина " + base.ToString());
        }
         void IEngine.GetInfo()
         {
            GetInfo();
            Console.WriteLine("С двигателем:"+NameOfEngine+" типа:"+type );
         }
        public override int GetHashCode()
        {
            return Color.GetHashCode() + Label.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return GetHashCode().Equals(obj.GetHashCode());
        }
        public override string ToString()
        {
            return base.ToString();
        }

    }
    interface IExpress
    {
        bool IsExpress { get; set; }
        void GetInfo();
    }
    sealed public class Train:Transport,IExpress
    {
        public bool IsExpress { get; set; }
        public override int MaxSpeed
        {
            get
            {
                if (IsExpress)
                    return 150;
                else
                    return 100;
            }
        }
        private int vagonsNum;
        public int Vagon
        {
            get => vagonsNum;
            set
            {
                if (value < 0)
                    vagonsNum = 1;
                else
                    vagonsNum = value;
            }
        }
        public Train(string label, string color, int speed,int cost,int exp, bool express,int count) : base(label, color, speed,cost,exp)
        {
            IsExpress = express;
            Vagon = count;
        }
        public void GetInfo()
        {
            Console.WriteLine("Поезд " + base.ToString());
        }
        void IExpress.GetInfo()
        {
            GetInfo();
            Console.WriteLine("Экспресс:"+IsExpress);
            Console.WriteLine("MAx Speed:"+MaxSpeed);
        }


              
    }
}

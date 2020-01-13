using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public struct Info
    {
        public string color;
        public string label;
    }

    public abstract partial class Transport
    {
       
        protected Info info;
        protected int speed;
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
        public Transport(string label,string color,int speed)
        {
            Label = label;
            Color = color;
            Speed = speed;
            
        }
        public abstract int MaxSpeed { get; }
       


    }

    interface IEngine
    {
         string NameOfEngine { get; set; }
         void GetInfo();
    }

    public class Car : Transport, IEngine
    {
        public Car(string label, string color, int speed, string name) : base(label, color, speed)
        {
            NameOfEngine = name;
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
            Console.WriteLine("С двигателем:"+NameOfEngine);
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
        public Train(string label, string color, int speed, bool express,int count) : base(label, color, speed)
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

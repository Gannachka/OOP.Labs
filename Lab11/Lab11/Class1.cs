using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Languages { get; set; }
        public User()
        {
            Languages = new List<string>();
        }
    }
    public class Time
    {
        private int hour;
        public int Hour
        {
            get
            {
                return hour;
            }
            set
            {
                hour = value;
            }
        }
        private int minute;
        public int Minute
        {
            get
            {
                return minute;
            }
            set
            {
                minute = value;
            }
        }
        private int second;
        public int Second
        {
            get
            {
                return second;
            }
            set
            {
                second = value;
            }
        }

        public Time(int yourhour, int yourminute, int yoursecond)//с параметрами
        {
            if (yourhour < 0 || yourhour > 24 || yourminute < 0 || yourminute > 59 || yoursecond < 0 || yoursecond > 59)
            {
                Console.WriteLine("Упс, неправильно");
            }
            else
            {
                hour = yourhour;
                minute = yourminute;
                Second = yoursecond;
            }
            Console.WriteLine(Hour.ToString() + ":" + Minute.ToString() + ":" + Second.ToString());
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Time time = (Time)obj;
            return this.Hour == time.Hour && this.Minute == time.Minute && this.Second == time.Second;
        }
        public override int GetHashCode()
        {
            int Hash = 369;
            Hash = Second > Minute ? Second : Minute;
            Hash = (Hash * 47) + Second.GetHashCode();
            return Hash;
        }
        public override string ToString()
        {
            return Hour.ToString() + ":" + Minute.ToString() + ":" + Second.ToString();
        }
    }
}

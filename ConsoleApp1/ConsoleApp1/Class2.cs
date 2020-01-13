using System.Collections.Generic;
using System.Drawing;
using System.Management;
using System.Linq;
using System;

namespace ConsoleApp1
{
    abstract class GraphicObject { }

    class Point : GraphicObject
    {
        public int x;
        public int y;
        public Point(int x, int y) { this.x = x; this.y = y; }
        public override string ToString() { return "I am point (" + x + ", " + y + ')'; }
    }

    class Circle : Point
    {
        int radius;
        public Circle(int x, int y, int r) : base(x, y) { radius = r; }
        public override string ToString() { return "I am circle (" + x + ", " + y + ") with r = " + radius; }
    }

    class Picture
    {
        public GraphicObject[] gr;
        public Picture(int CountOfElements) { gr = new GraphicObject[CountOfElements]; }
        void Sort()
        {
            GraphicObject temp;
            for (int i = 0; i < gr.Length; i++)
                for (int j = i + 1; j < gr.Length; j++)
                    if (gr[i] is Circle && gr[j] is Point)
                    {
                        temp = gr[i];
                        gr[i] = gr[j];
                        gr[j] = temp;
                    }
        }
        public void print()
        {
            Sort();
            for (int i = 0; i < gr.Length; i++)
                Console.WriteLine(gr[i]);
        }
    }
}


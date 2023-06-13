using System;
using System.Collections.Generic;

namespace ShapeNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            shapes.Add(new Square("Red", 5));
            shapes.Add(new Rectangle("Blue", 3, 4));
            shapes.Add(new Circle("Green", 2.5));

            foreach (var shape in shapes)
            {
                Console.WriteLine($"Color: {shape.Color}, Area: {shape.GetArea()}");
            }
            Console.ReadLine();
        }
    }
}

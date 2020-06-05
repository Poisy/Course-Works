using System;

namespace POI
{
    class Program
    {
        static void Main()
        {
            Rectangle rectangle1 = new Rectangle(new Point(-6, -2), new Point(2, 5));
            Rectangle rectangle2 = new Rectangle(new Point(7, 2), new Point(-1, -4));
            Rectangle rectangle3 = new Rectangle(new Point(12, -3), new Point(9, 6));
            Rectangle rectangle4 = new Rectangle(new Point(-4, 1), new Point(-9, 4));

            Console.WriteLine(Rectangle.GetIntersection(rectangle1, rectangle2));
            Console.WriteLine(Rectangle.GetIntersection(rectangle2, rectangle1));
            Console.WriteLine(Rectangle.GetIntersection(rectangle2, rectangle3));
            Console.WriteLine(Rectangle.GetIntersection(rectangle1, rectangle3));
            Console.WriteLine(Rectangle.GetIntersection(rectangle1, rectangle4));
            Console.WriteLine(Rectangle.GetIntersection(rectangle4, rectangle2));
        }
    }
}

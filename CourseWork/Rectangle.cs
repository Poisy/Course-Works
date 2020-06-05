using System;

namespace POI
{
    // Represents a Rectangle
    public class Rectangle
    {
        private Point point1;
        private Point point2;

        // Set's the two diagonal Points of the Rectangle
        public Rectangle(Point point1, Point point2) => SetPoints(point1, point2);

        // Get's the Points of the Rectangle
        public Point[] GetPoints() => new Point[] { point1, point2 };

        // Set's the two diagonal Points of the Rectangle
        public void SetPoints(Point point1, Point point2)
        {
            this.point1 = point1;
            this.point2 = point2;
        }

        // Get's the Area of the Rectangle
        public double Area()
        {
            return CalculateSide(point1.X, point2.X) * CalculateSide(point1.Y, point2.Y);
        }

        // Calculate one side of the Rectangle
        private static double CalculateSide(double value1, double value2)
        {
            return Math.Abs(value1 - value2);
        }

        // Get the Intersection Area of this and another Rectangle
        public static double GetIntersection(Rectangle rectangle1, Rectangle rectangle2)
        {
            return GetIntersection(rectangle1, rectangle2, true);
        }

        // Get the Intersection Area of two Rectangles 
        private static double GetIntersection(Rectangle rectangle1, Rectangle rectangle2, bool repeat)
        {

            double r1x1 = rectangle1.point1.X;
            double r1y1 = rectangle1.point1.Y;
            double r1x2 = rectangle1.point2.X;
            double r1y2 = rectangle1.point2.Y;
            double r2x1 = rectangle2.point1.X;
            double r2y1 = rectangle2.point1.Y;
            double r2x2 = rectangle2.point2.X;
            double r2y2 = rectangle2.point2.Y;

            double a = 0;
            double b = 0;


            if (r1x1 < r2x1 && r1x2 > r2x1)
            {
                if (r2x2 > r1x1) a = CalculateSide(r1x2, r2x1);
                else a = CalculateSide(r1x1, r2x1);
            }
            else if (r1x1 < r2x2 && r1x2 > r2x2)
            {
                if (r2x1 > r1x2) a = CalculateSide(r2x2, r1x2);
                else a = CalculateSide(r2x2, r1x1);
            }
            else if (r1x2 < r2x1 && r1x1 > r2x1)
            {
                if (r2x2 > r1x2) a = CalculateSide(r2x1, r1x1);
                else a = CalculateSide(r1x2, r2x1);
            }
            else if (r1y2 < r2y2 && r1y1 > r2y2)
            {
                if (r2x1 > r1x2) a = CalculateSide(r2y2, r1y1);
                else a = CalculateSide(r2y2, r2y1);
            }


            if (r1y1 < r2y1 && r1y2 > r2y1)
            {
                if (r2y2 > r1y1) b = CalculateSide(r1y2, r2y1);
                else b = CalculateSide(r2y1, r1y1);
            }
            else if (r1y1 < r2y2 && r1y2 > r2y2)
            {
                if (r1y1 > r2y1) b = CalculateSide(r2y2, r1y2);
                else b = CalculateSide(r2y2, r1y1);
            }
            else if (r1y2 < r2y1 && r1y1 > r2y1)
            {
                if (r1y1 > r2y2) b = CalculateSide(r2y1, r1y2);
                else b = CalculateSide(r2y1, r1y1);
            }
            else if (r1y2 < r2y2 && r1y1 > r2y2)
            {
                if (r2y1 > r1y1) b = CalculateSide(r2y2, r1y1);
                else b = CalculateSide(r2y2, r1y2);
            }


            if (repeat && (a == 0 || b == 0))
            {
                return GetIntersection(rectangle2, rectangle1, false);
            }

            return a * b;
        }
    }
}

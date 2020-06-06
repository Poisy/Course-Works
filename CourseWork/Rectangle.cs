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
            double r1x1 = rectangle1.point1.X;
            double r1y1 = rectangle1.point1.Y;
            double r1x2 = rectangle1.point2.X;
            double r1y2 = rectangle1.point2.Y;
            double r2x1 = rectangle2.point1.X;
            double r2y1 = rectangle2.point1.Y;
            double r2x2 = rectangle2.point2.X;
            double r2y2 = rectangle2.point2.Y;

            double a = GetIntersectionSide(r1x1, r1x2, r2x1, r2x2);
            double b = GetIntersectionSide(r1y1, r1y2, r2y1, r2y2);

            return a * b;
        }

        // Tries to get possible side between two rectangles given with 4 coordinates
        private static double GetIntersectionSide(double coor1, double coor2, double coor3, double coor4)
        {
            if (coor1 < coor3 && coor2 > coor3)
            {
                if (coor4 > coor1) return CalculateSide(coor2, coor3);
                else return CalculateSide(coor1, coor3);
            }
            else if (coor1 < coor4 && coor2 > coor4)
            {
                if (coor1 > coor3) return CalculateSide(coor4, coor1);
                else return CalculateSide(coor4, coor2);
            }
            else if (coor2 < coor3 && coor1 > coor3)
            {
                if (coor4 > coor3) return CalculateSide(coor3, coor1);
                else return CalculateSide(coor2, coor3);
            }
            else if (coor2 < coor4 && coor1 > coor4)
            {
                if (coor3 > coor2) return CalculateSide(coor4, coor1);
                else return CalculateSide(coor4, coor2);
            }

            return 0;
        }
    }
}

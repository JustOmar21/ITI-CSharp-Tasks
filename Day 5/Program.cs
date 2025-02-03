using System;

namespace Day_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //oldTask();
            newTask();
        }

        static void newTask()
        {
            Point3D[] points = { new Point3D(2,3,10), new Point3D(1, 2, 5), new Point3D(2, 1, 10), new Point3D(1, 1, 1) };
            Array.Sort(points);
            foreach(var  point in points)
            {
                Console.WriteLine((string)point);
            }
        }
        
        static void oldTask()
        {
            int x, y, z;
            Point3D p1 = null, p2 = null;
            for (int i = 0; i < 2; i++)
            {
                if (i % 2 == 0)
                {
                    do
                    {
                        Console.Write($"Point {i + 1}'s X : ");
                    } while (!int.TryParse(Console.ReadLine(), out x));

                    do
                    {
                        Console.Write($"Point {i + 1}'s Y : ");
                    } while (!int.TryParse(Console.ReadLine(), out y));

                    do
                    {
                        Console.Write($"Point {i + 1}'s Z : ");
                    } while (!int.TryParse(Console.ReadLine(), out z));

                    p1 = new Point3D(x, y, z);
                }
                else
                {
                    do
                    {
                        Console.Write($"Point {i + 1}'s X : ");
                    } while (!int.TryParse(Console.ReadLine(), out x));

                    do
                    {
                        Console.Write($"Point {i + 1}'s Y : ");
                    } while (!int.TryParse(Console.ReadLine(), out y));

                    do
                    {
                        Console.Write($"Point {i + 1}'s Z : ");
                    } while (!int.TryParse(Console.ReadLine(), out z));

                    p2 = new Point3D(x, y, z);
                }
            }
            Console.WriteLine($"{p1}\n{p2}\nP1 == P2 = {p1 == p2}");
        }

        class Point3D(int x, int y, int z) : ICloneable , IComparable
        {
            public int X { get { return x; } set { x = value; } }
            public int Y { get { return y; } set { y = value; } }
            public int Z { get { return z; } set { z = value; } }

            public override string ToString()
            {
                return $"Point Coordinates : ({X},{Y},{Z})";
            }

            public static bool operator ==(Point3D p1, Point3D p2)
            {
                return p1.X == p2.X && p1.Y == p2.Y && p1.Z == p2.Z;
            }

            public static bool operator !=(Point3D p1, Point3D p2)
            {
                return !(p1 == p2);
            }

            public static explicit operator string(Point3D point)
            {
                return point.ToString();
            }

            public override bool Equals(object? obj)
            {
                if (obj == null || obj.GetType() != typeof(Point3D)) return false;
                Point3D p2 = obj as Point3D;
                return this.X == p2.X && this.Y == p2.Y && this.Z == p2.Z;
            }

            public object Clone()
            {
                return new Point3D(X, Y, Z);
            }

            public int CompareTo(object? obj)
            {
                if(obj is Point3D)
                {
                    if(obj is null)
                    {
                        return -1;
                    }
                    else
                    {
                        var point = obj as Point3D;
                        int result;

                        result = this.X.CompareTo(point.X);
                        if (result != 0) return result;

                        result = this.Y.CompareTo(point.Y);
                        if (result != 0) return result;

                        return this.Z.CompareTo(point.Z);
                    }
                }
                else
                {
                    throw new InvalidCastException("The object you sent is not of type Point3D");
                }
            }
        }
        static class MathO
        {
            public static double Add(double x, double y) { return x + y; }
            public static double substract(double x, double y) { return x - y; }
            public static double Multiply(double x, double y) { return x * y; }
            public static double Divide(double x, double y)
            {
                if (y == 0)
                {
                    //Console.WriteLine("Cannot Divide by zero, replacing it with one");
                    //y = 1;
                    throw new DivideByZeroException();
                }
                return x / y;
            }


        }
    }
}

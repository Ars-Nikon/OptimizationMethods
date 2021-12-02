using System;

namespace LR1
{
    internal class Program
    {
        static double Funct(double a, double b, double c,double x)
        {
            return a * Math.Pow(x, 2) + b * x + c;
        }

        static void Main(string[] args)
        {
            var a = -2d;
            var b = 2d;
            var c = 2d;
            double x = 0;

            if (a==0)
            {
                Console.WriteLine("Нету экстремумы");
                return;
            }
                x = -b / (2 * a);
                Console.WriteLine($"F(x)={Funct(a,b,c,x)}, x={x}");
        }
    }
}

using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2
{
    static internal class Methods
    {
        static private int Fibonachi(int n)
        {
            if (n == 0 || n == 1) return n;

            return Fibonachi(n - 1) + Fibonachi(n - 2);
        }
        static public void UniformSearch(int a, int b, int n, Func<double, double> Funct)
        {

            var fxi = new Dictionary<int, double>();

            for (int i = 1; i <= n; i++)
            {
                int xi = a + i * (b - a) / (n + 1);
                var F = Funct(xi);
                if (!double.IsNaN(F))
                {
                    fxi.Add(xi, Funct(xi));
                }
            }

            var Min = fxi.
                Where(x => x.Value == fxi.Min(y => y.Value)).
                ToList();

            var Max = fxi.
                Where(x => x.Value == fxi.Max(y => y.Value)).
                ToList();

            Console.WriteLine("Метод равномерного поиска");
            Console.WriteLine($"Iterations= {n}");

            Console.WriteLine("Min:");
            var table = new ConsoleTable("F(x)", "x");
            Min?.ForEach(x => table.AddRow(x.Value, x.Key));
            table.Write(Format.Alternative);

            Console.WriteLine("Max:");
            table = new ConsoleTable("F(x)", "x");
            Max?.ForEach(x => table.AddRow(x.Value, x.Key));
            table.Write(Format.Alternative);
        }

        static public void Dichotomies(double a, double b, double e, double delt, Func<double, double> Funct)
        {
            int i = 0;
            while ((b - a) / 2 > e)
            {
                double x1 = (a + b - delt) / 2;
                double x2 = (a + b + delt) / 2;
                if (x1 < x2)
                {
                    double t = x1;
                    x1 = x2;
                    x2 = t;

                }

                var Fx1 = Funct(x1);
                var Fx2 = Funct(x2);
                if (double.IsNaN(Fx1) || double.IsNaN(Fx2))
                {
                    continue;
                }

                if (Fx1 <= Fx2)
                {
                    b = x2;
                }
                else
                {
                    a = x1;
                }
                i++;
            }

            Console.WriteLine("Метод дихотомии");
            Console.WriteLine($"Iterations= {i}");
            var table = new ConsoleTable("F(x)", "x");
            table.AddRow(Funct((a + b) / 2), (a + b) / 2);
            table.Write(Format.Alternative);
        }

        static public void GoldenSection(double a, double b, double e, Func<double, double> Funct)
        {

            Console.WriteLine("Метод золотого сечения");
            Console.WriteLine("Min:");
            GoldenSectionHelper(a, b, e, Funct, (x, y) => x >= y);
            Console.WriteLine("Max:");
            GoldenSectionHelper(a, b, e, Funct, (x, y) => x <= y);
        }

        static private void GoldenSectionHelper(double a, double b, double e, Func<double, double> Funct, Func<double, double, bool> action)
        {
            double PHI = (1 + Math.Sqrt(5)) / 2;

            double x1;
            double x2;
            var i = 0;
            while (true)
            {
                x1 = b - (b - a) / PHI;
                x2 = a + (b - a) / PHI;
                if (action(Funct(x1), Funct(x2)))
                {
                    a = x1;
                }
                else
                {
                    b = x2;
                }
                if (Math.Abs(b - a) < e)
                    break;
                i++;
            }

            Console.WriteLine($"Iterations= {i}");
            var table = new ConsoleTable("F(x)", "x");
            table.AddRow(Funct((a + b) / 2), (a + b) / 2);
            table.Write(Format.Alternative);
        }

        static public void Fibon(double a, double b, double e, Func<double, double> Funct)
        {
            Console.WriteLine("Метод фибоначчи");
            Console.WriteLine("Min:");
            FibonHelper(a, b, e, Funct, (x, y) => x > y);
            Console.WriteLine("Max:");
            FibonHelper(a, b, e, Funct, (x, y) => x < y);
        }

        static private void FibonHelper(double a, double b, double e, Func<double, double> Funct, Func<double, double, bool> action)
        {
            int n = (int)((b - a) / e);
            int k = 0;

            for (int i = 1; ; i++)
            {
                if (Fibonachi(i) < n)
                {
                    continue;
                }
                k = i;
                break;
            }

            double l = (b - a) / Fibonachi(k);

            double x1, x2;
            double Fx1, Fx2;


            for (int i = k - 2; i != 0; i--)
            {
                x1 = a + l * Fibonachi(i);
                x2 = b - l * Fibonachi(i);


                Fx1 = Funct(x1);
                Fx2 = Funct(x2);

                if (double.IsNaN(Fx1) || double.IsNaN(Fx2))
                {
                    continue;
                }

                if (action(Fx1,Fx2))
                {
                    b = x2;
                }
                else
                {
                    a = x1;
                }
            }

            Console.WriteLine($"Iterations= {k - 2}");
            var table = new ConsoleTable("F(x)", "x");
            table.AddRow(Funct((a + b) / 2), (a + b) / 2);
            table.Write(Format.Alternative);
        }


    }
}

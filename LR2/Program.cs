using System;
using System.Collections.Generic;
using System.Linq;

namespace LR2
{
    internal class Program
    {
        static double Funct(double x)
        {
             return Math.Pow((25 - Math.Pow(x, 2)), 0.5);
            // return Math.Pow(Math.Pow((Math.Pow(x,2)-1),2),1/3);
        }
        static double DerFunct(double x)
        {
            return -(x / Math.Sqrt(25 - Math.Pow(x, 2)));
        }


        static void Main(string[] args)
        {

            //  унимодальна на отрезке   Метод равномерного поиска
            /*
          int a = -6;
            int b = 6;
            int  e = 1;

           int n = (b - a) / e - 1;

           var fxi = new Dictionary<int, double>();

           for (int i = 1; i <= n; i++)
           {
               int xi = a + i * (b - a) / (n + 1);
               fxi.Add(xi, Funct(xi));
           }

           var Min = fxi.Where(x => x.Value == fxi.Min(y => y.Value)).ToList();
           var Max = fxi.Where(x => x.Value == fxi.Max(y => y.Value)).ToList();
           */


            //Метод дихотомии
            /*
            double a = -6;
            double b = 6;
            double e = 0.1;
            double delt = 0.02;


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

                if (Fx1 <= Fx2)
                {
                    b = x2;
                }
                else
                {
                    a = x1;
                }
            }

            var F = Funct((a + b) / 2);
            */


            // Метод золотого сечения.
            /*
            double a = -6;
            double b = 6;
            double e = 0.1;
            double en = Math.Abs(b-a);
            double t = (Math.Sqrt(5) + 1)/2;

            double x1 = a + (b - a) / (t + 1);
            double x2 = b - (b - a) / (t + 1); ;
            var Fx1 = Funct(x1);
            var Fx2 = Funct(x2);

            while (en<e)
            {
                if (Fx1 < Fx2)
                {
                    b = x2;
                    x2 = x1;
                    Fx2 = Fx1;
                    x1 = a + (b - a) / (t + 1);
                    Fx1 = Funct(x1);
                }
                else
                {
                    a = x1;
                    x1 = x2;
                    Fx1 = Fx2;
                    x2= b - (b - a) / (t + 1);
                    Fx2 = Funct(x2);
                }
            }

            var F = Funct((a + b) / 2);
            Console.WriteLine();
            */

        }
    }
}

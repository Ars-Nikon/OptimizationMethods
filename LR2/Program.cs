using System;
using System.Collections.Generic;
using System.Linq;

namespace LR2
{
    internal class Program
    {
        static double Funct(double x)
        {
            // return Math.Pow((25 - Math.Pow(x, 2)), 0.5);
            //  return Math.Pow(Math.Pow((Math.Pow(x,2)-1),2),1/3);
            // return Math.Pow(x, 4) + Math.Exp(-x);
            return  2 * Math.Pow(x, 2) + 2 * x + 2;
        }
        static double DerFunct(double x)
        {
            return -(x / Math.Sqrt(25 - Math.Pow(x, 2)));
        }
        static void Main(string[] args)
        {
            Methods.UniformSearch(-6, 6, 1, Funct);

            Methods.Dichotomies(-6, 6, 0.1, 0.001, Funct);

            Methods.GoldenSection(-6, 6, 0.001, Funct);

            Methods.Fibon(-6, 6, 0.01, Funct);
        }
    }
}

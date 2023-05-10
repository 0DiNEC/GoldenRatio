using System;

namespace goldenRatio
{
    public class GoldenSectionSearch
    {
        private const double Phi = 1.618033988749895; // Золотое сечение
        public static double FindMinimum(Func<double, double> function, double a, double b, double epsilon)
        {
            double x1 = b - (b - a) / Phi;
            double x2 = a + (b - a) / Phi;
            double f1 = function(x1);
            double f2 = function(x2);

            while (Math.Abs(b - a) > epsilon)
            {
                if (f1 < f2)
                {
                    b = x2;
                    x2 = x1;
                    f2 = f1;
                    x1 = b - (b - a) / Phi;
                    f1 = function(x1);
                }
            }

            return (a + b) / 2;
        }
    }
    internal class Program
    {
        public static double PowFunction(double x)
        {
            return x * x;
        }

        static void Main(string[] args)
        {

            double a = double.NaN,
                   b = double.NaN,
                   epsilon = double.NaN;

            Console.Write("Введите начальную левую границу интервала, (по умолчанию : -1)  :");
            if (!Double.TryParse(Console.ReadLine(), out a))
                a = -1;

            Console.Write("Введите начальную правую границу интервала, (по умолчанию: 1)  :");
            if (!Double.TryParse(Console.ReadLine(), out b))
                b = 1;
            
            Console.Write("Введите необходимую точность по умолчанию (0.0001)  : ");
            if (!Double.TryParse(Console.ReadLine(), out epsilon))
                epsilon = 0.0001;


            double minimumF = GoldenSectionSearch.FindMinimum(PowFunction, a, b, epsilon);
            Console.WriteLine("Минимум функции: " + minimumF);

            Console.ReadKey();
        }
    }
}

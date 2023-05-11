using System;

namespace goldenRatio
{
    public class GoldenSectionSearch
    {
        private const double Phi = 1.618033988749895; // Золотое сечение

        // Метод для поиска минимума функции одной переменной методом золотого сечения
        /// <param name="a">Начальное значение интервала.</param>
        /// <param name="b">Конечное значение интервала.</param>
        /// <param name="epsilon">Точность.</param>
        /// <returns>Значение минимума функции.</returns>
        public static double FindMinimum(Func<double, double> function, double a, double b, double epsilon)
        {
            // Инициализация переменных для значения x1, x2, f1, f2
            double x1 = b - (b - a) / Phi;
            double x2 = a + (b - a) / Phi;
            double f1 = function(x1);
            double f2 = function(x2);

            // Цикл выполняется до достижения необходимой точности
            while (Math.Abs(b - a) > epsilon)
            {
                if (f1 < f2)
                {
                    // Обновление значений интервала, x2, f2, x1, f1 в случае, когда f1 < f2
                    b = x2;
                    x2 = x1;
                    f2 = f1;
                    x1 = b - (b - a) / Phi;
                    f1 = function(x1);
                }
                else
                {
                    // Обновление значений интервала, x1, f1, x2, f2 в случае, когда f1 >= f2
                    a = x1;
                    x1 = x2;
                    f1 = f2;
                    x2 = a + (b - a) / Phi;
                    f2 = function(x2);
                }
            }
            // Возврат найденного минимума как среднего значения интервала
            return (a + b) / 2;
        }
    }
    internal class Program
    {
        // Пример функции, для которой ищем минимум (квадрат функции)
        public static double PowFunction(double x)
        {
            return x * x;
        }

        public static double LocalMinF(double x)
        {
            return Math.Pow(x, 4) - 4 * Math.Pow(x, 2) + 5;
        }

        public static double Func(double x)
        {
            return Math.Pow(x, 3) - 6 * Math.Pow(x, 2) + 9 * x + 2;
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

            Console.Write("Введите необходимую точность \n (чем меньше точность тем более качественный результат, однако значение должно быть больше 0) по умолчанию (0.001)  : ");
            if (!Double.TryParse(Console.ReadLine(), out epsilon))
                epsilon = 0.001;

            if (epsilon <= 0)
                epsilon = 0.001;


            try
            {
              double minimumF = Math.Round(GoldenSectionSearch.FindMinimum(PowFunction, a, b, epsilon), 5);
                Console.WriteLine("Минимум функции: " + minimumF);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Произошла ошибка: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}
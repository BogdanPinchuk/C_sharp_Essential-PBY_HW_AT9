using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp4
{
    /// <summary>
    /// Арифметична операція
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    delegate double AO(double a, double b);

    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // набір допутимих опреацій
            string arrayOper = "+-/*";

            // Алгоритм Дейкстри
            for (; ; )
            {
                // чистка консолі
                Console.Clear();

                #region Перше число
                // введеня даних
                Console.Write("Введіть число: a = ");

                // зчитування числа
                bool next = double.TryParse(Console.ReadLine()
                    .Replace(".", ","), out double a);

                // перевірка чи не було ввежено неправильно
                if (!next)
                {
                    Console.WriteLine("\n\tПомилка введення даних.\n" +
                        "\tСпробувати ще раз?");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                #endregion

                #region Арифметична операція
                // введеня даних
                Console.Write("Введіть арифметичну опрецію: ");

                // зчитування операції
                string oper = Console.ReadLine();

                // аналіз чи введений 1 символ і чи введена АО є в наборі
                if (!(oper.Length == 1 &&
                    arrayOper.Contains(oper)))
                {
                    Console.WriteLine("\n\tПомилка введення даних.\n" +
                        "\tСпробувати ще раз?");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                #region Друге число
                // введеня даних
                Console.Write("Введіть число: b = ");

                // зчитування числа
                next = double.TryParse(Console.ReadLine()
                    .Replace(".", ","), out double b);

                // перевірка чи не було ввежено неправильно
                if (!next)
                {
                    Console.WriteLine("\n\tПомилка введення даних.\n" +
                        "\tСпробувати ще раз?");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                // створення делегата який виконуватиме АО
                AO del = default;

                // аналіз вибраної операції
                switch (oper)
                {
                    case "+":   // лямда-вираз
                        del = (x, y) => x + y;
                        break;
                    case "-":   // лямда-вираз
                        del = (x, y) => x - y;
                        break;
                    case "*":   // лямда-вираз
                        del = (x, y) => x * y;
                        break;
                    case "/":   // анонімний метод
                        del = delegate (double x, double y)
                        {
                            if (a == 0 && b == 0)
                            {
                                return double.NaN;
                            }
                            else if (a > 0 && b == 0)
                            {
                                return double.PositiveInfinity;
                            }
                            else if (a < 0 && b == 0)
                            {
                                return double.NegativeInfinity;
                            }
                            else
                            {
                                return a / b;
                            }
                        };
                        break;
                }

                // вивід результату
                Console.WriteLine($"\n\tРезультат: {a} {oper} {b} = {del(a, b):N2}");

                #region Повтор
                Console.WriteLine("\n\tСпробувати ще раз?");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    continue;
                }
                else
                {
                    break;
                } 
                #endregion
            }
        }

        #region Арифметичні операції, які можна було б присвоїти делегату
        /// <summary>
        /// Сума чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static double Add(double a, double b) => a + b;
        /// <summary>
        /// Різниця чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static double Sub(double a, double b) => a - b;
        /// <summary>
        /// Добуток чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static double Mul(double a, double b) => a * b;
        /// <summary>
        /// Частка чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static double Div(double a, double b)
        {
            // перевірка на 0
            double temp = default;

            // врахування виключень
            if (a == 0 && b == 0)
            {
                temp = double.NaN;
            }
            else if (a > 0 && b == 0)
            {
                temp = double.PositiveInfinity;
            }
            else if (a < 0 && b == 0)
            {
                temp = double.NegativeInfinity;
            }
            else
            {
                temp = a / b;
            }

            return temp;
        } 
        #endregion

    }
}

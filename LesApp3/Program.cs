using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp3
{
    delegate int MyDelegate(int number);

    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // для випадкового числа
            Random rnd = new Random();

            // випадкове число
            int a = rnd.Next(sbyte.MinValue, sbyte.MaxValue);

            // вивід числа
            Console.WriteLine($"\n\tВипакове число: a = {a}\n");

            // делегат
            MyDelegate del = Method0;
            Console.WriteLine("\t++a = " + del.Invoke(a));

            del = Method1;
            Console.WriteLine("\t--a = " + del.Invoke(a));

            del = Method2;
            Console.WriteLine("\ta++ = " + del.Invoke(a));

            del = Method3;
            Console.WriteLine("\ta-- = " + del.Invoke(a));

            // повторення
            DoExitOrRepeat();
        }

        #region Набір методів
        static int Method0(int number) => ++number;
        static int Method1(int number) => --number;
        static int Method2(int number) => number++;
        static int Method3(int number) => number--;
        #endregion

        /// <summary>
        /// Метод виходу або повторення методу Main()
        /// </summary>
        static void DoExitOrRepeat()
        {
            Console.WriteLine("\n\nСпробувати ще раз: [т, н]");
            Console.Write("\t");
            var button = Console.ReadKey(true);

            if ((button.KeyChar.ToString().ToLower() == "т") ||
                (button.KeyChar.ToString().ToLower() == "n")) // можливо забули переключити розкладку клавіатури
            {
                Console.Clear();
                Main();
                // без використання рекурсії
                //Process.Start(Assembly.GetExecutingAssembly().Location);
                //Environment.Exit(0);
            }
            else
            {
                // закриває консоль
                Environment.Exit(0);
            }
        }
    }
}

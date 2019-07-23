using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// "Створити клас-делегат" ???

namespace LesApp2
{
    delegate void MyDelegate();

    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // Набір екземплярів делегатів в масиві
            MyDelegate[] delegates = new MyDelegate[5]
            {
                Method0,
                Method1,
                Method2,
                Method3,
                Method4
            };

            // результуючий делегат
            MyDelegate resultDelegate;

            resultDelegate = delegates[0];

            // комбінування делегатів вище вказаних
            for (int i = 1; i < delegates.Length; i++)
            {
                resultDelegate += delegates[i];
            }

            // виконання делегата
            resultDelegate.Invoke();

            // міняємо місцями
            delegates[1] = Method4;
            delegates[4] = Method1;

            for (int i = 1; i < delegates.Length; i++)
            {
                resultDelegate -= delegates[i];
                resultDelegate += delegates[i];
            }

            // виконання делегата
            resultDelegate.Invoke();

            // повторення
            DoExitOrRepeat();
        }

        #region Набір методів
        static void Method0()
        {
            Console.Write("\n\tЗдравствуйте ");
        }

        static void Method1()
        {
            Console.WriteLine("уважаемые господа.");
        }

        static void Method2()
        {
            Console.Write("\tСегодня мы ");
        }

        static void Method3()
        {
            Console.Write("изучим ");
        }

        static void Method4()
        {
            Console.WriteLine("делегаты.");
        }
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

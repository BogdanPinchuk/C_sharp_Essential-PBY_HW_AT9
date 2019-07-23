using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    /// <summary>
    /// Делегат предіката
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    delegate bool Predicate(string s);
    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // тестовий масив
            string[] array = new string[]
            {
                "Моя кошка любит корм",
                "Сколько гор во всем мире?",
                "Монте-Карло город казино",
                "Дорога в никуда",
                "Моя мама печет пироги",
                "Масик кличка моего кота"
            };

            // Створюємо делегат
            Predicate delPred = Analуsіs;

            // Вивід результату
            Console.WriteLine("Результат аналізу:\n");

            // аналізуємо через розширений метод
            // чи відповідають рядки певним умовам, 
            // якщо так то виводимо рядок
            array.ExtentionMethod(delPred);

            // повторення
            DoExitOrRepeat();
        }

        /// <summary>
        /// Аналіз рядка на те чи він відповідає умовам його відображення
        /// </summary>
        static bool Analуsіs(string s)
        {
            // перевіряємо чи рядок починається на "м" і містить "ор"
            if (s.ToLower().StartsWith("м") &&
                s.ToLower().Contains("ор"))
            {
                // виводимо що це выдповідає умові
                return true;
            }

            return false;
        }

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

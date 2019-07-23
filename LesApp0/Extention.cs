using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    /// <summary>
    /// Клас для методів розширення
    /// </summary>
    static class Extention
    {
        /// <summary>
        /// Метод розришення для масиву рядків
        /// </summary>
        /// <param name="array">масив рядків</param>
        /// <param name="pred">делегет-предікат</param>
        public static void ExtentionMethod(this string[] array, Predicate pred)
        {
            // правпор на те чи щось знайдено із вхідного масиву
            bool find = false;

            // перебираємо вхідний масив
            for (int i = 0; i < array.Length; i++)
            {
                // перевіряємо чи рядок  відповідає умовам
                if (pred(array[i]))
                {
                    // 
                    Console.WriteLine("\t" + array[i]);
                    find = true;
                }
            }

            // якщо нічого не найдено, то виведем сповіщення
            if (!find)
            {
                Console.WriteLine("\n\tНе знайдено жодного рядка який би відповідав умові.");
            }
        }

    }
}

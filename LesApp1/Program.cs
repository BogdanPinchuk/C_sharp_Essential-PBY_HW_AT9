using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// На основі 9 теми про делегати із 011 прикладу
// необхідно замінити анонімний делегат звичайним методом
// із 14 рядка по оригінальному прикладу і 23 в даному

namespace LesApp1
{
    delegate Delegate3 Functional(Delegate1 delegate1, Delegate2 delegate2);
    delegate string Delegate1();
    delegate string Delegate2();
    delegate string Delegate3();

    class Program
    {
        /// <summary>
        /// Для виведення результатів двох делегатів і доступу донього 3-го методу
        /// </summary>
        private static string forDel3;

        public static Delegate3 MethodF(Delegate1 delegate1, Delegate2 delegate2)
        {
            #region Cтарий варіант, який необхідно замінити
#if false
            
            return delegate { return delegate1.Invoke() + delegate2.Invoke(); }; 
#endif
            #endregion

            #region Аналог старого варіанту який не підходить, так як в старих версіях це не реалізувало б замикання
#if false
            return () => delegate1.Invoke() + delegate2.Invoke(); 
#endif
            #endregion

            #region Варіант з використанням Nested функції (локальної функції)
#if false
            // але в такому випадку втрачається смисл передавати в даний метод вхідні дані,
            // так як реалізація конкатанації рядків відбуваєтсья в методі AnonymousMethod()
            //return AnonymousMethod;

            // локальна функція
            string NestedMethod()
            {
                return delegate1.Invoke() + delegate2.Invoke();
            }

            // ще простіше простіше скориставшись локальною функцією  
            return NestedMethod;
#endif
            #endregion

            #region Варіант з використанням статичних методів (можна і через звичайні, що практично дублюватиме логіку)
#if false
            // приймаємо два делегата, виконуємо і результат заносимо в поле
            ResBothDel(delegate1, delegate2);
            // зчитуємо дані з поля і передаємо їх іншим методом
            return ForDel3;
#endif
            #endregion

            #region Варіант з використанням Extention - методів розширення
#if true
            // можна  було б назвати: методика "кидок через плече"
            return ResDel12(delegate1, delegate2).ExMethodDel12;
#endif
            #endregion
        }

        public static string Method1() { return "Hello "; }
        public static string Method2() { return "world!"; }

        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            Functional functional = new Functional(MethodF);

            Delegate3 delegate3 = functional.Invoke(new Delegate1(Method1), new Delegate2(Method2));

            Console.WriteLine(delegate3.Invoke());

            // Delay.
            Console.ReadKey();
        }

        #region Додаткові методи для варіанту заміною звичайними методами
        /// <summary>
        /// Метод який приймає результати 2 двох делегатів і повертає дані в поле
        /// </summary>
        /// <param name="del1">Delegate1</param>
        /// <param name="del2">Delegate2</param>
        private static void ResBothDel(Delegate1 del1, Delegate2 del2)
        {
            forDel3 = del1() + del2();
        }
        /// <summary>
        /// Повернення даних з поля (запис метода inline)
        /// </summary>
        /// <returns></returns>
        private static string ForDel3() => forDel3;
        #endregion

        #region Додаткові методи для варіанту розшинення
        private static string ResDel12(Delegate1 del1, Delegate2 del2)
        {
            return del1() + del2();
        }
        #endregion

    }

    /// <summary>
    /// Клас щоб скористатися методами розширення
    /// </summary>
    static class Extention
    {
        /// <summary>
        /// Метод розширення який визивається на рядку і повертає цей же рядок, 
        /// але сам є методом який необхідний щоб його прийняв Delegate3
        /// </summary>
        /// <param name="resOfDel12">змінна на якій відбувається виклик, або змінна якою передається рядок</param>
        /// <returns></returns>
        public static string ExMethodDel12(this string resOfDel12) => resOfDel12;
        
    }

}

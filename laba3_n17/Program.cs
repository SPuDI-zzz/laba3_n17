using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3_n17
{
    internal class Program
    {
        /* Метод возвращает массив, содержащий множители параметра
        num. После выполнения метода out-параметр numfactors
       будет содержать количество найденных множителей. */
        static public int[] findfactors(int num, out int numfactors)
        {
            int[] facts = new int[10]; // Размер 10 взят
                                       // произвольно
            int i, j;


            // Находим множители и помещаем их в массив facts.
            for (i = 2, j = 0; i < num / 2 + 1; i++)
                if ((num % i) == 0)
                {
                    facts[j] = i;
                    j++;
                }
            facts[j] = num;
            j++;
            numfactors = j;
            return facts;

        }
// метод возвращает массив множителей максимального значения
// строки n_str матрицы in_arr рамера size * size.
// Размер массива - результата — numfactors.

         static int[] test(int size, int n_str, ref int[,] in_arr,
         out int numfactors)
         {
            int[] facts = new int[10]; // Размер 10 взят
                                        // произвольно
            int i;
            int max = in_arr[n_str, 0];
            for (i = 1; i < size; i++)
                if (in_arr[n_str, i] > max)
                    max = in_arr[n_str, i];
            return findfactors(max, out numfactors);
         }
        public static void Main()
        {
            const int n = 5;
            int numfactors;
            int[,] in_arr = new int[n, n];
            int[] factors;
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    in_arr[i, j] = rnd.Next(100);
            Console.WriteLine("произвольно заданная матрица:");
            for (int i = 0; i < in_arr.GetLength(0); i++)
            {
                for (int j = 0; j < in_arr.GetLength(1); j++)
                    Console.Write("\t" + in_arr[i, j]);
                Console.WriteLine();
            }
            
       
            for (int j = 0; j < n; j++)
            {
                factors = test(n, j, ref in_arr, out numfactors);
                Console.WriteLine("Множители max {0} строки: ", j);
                for (int i = 0; i < numfactors; i++)
                    Console.Write(factors[i] + " ");
                Console.WriteLine();
            }
        }
    }
}

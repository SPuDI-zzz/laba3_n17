using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*В данной матрице размером n * n для каждого столбца найти убывающую серию наибольшей длины*/

namespace laba3_n17
{
    internal class Program
    {
        static public int[,] inArr;
        /*Метод возвращает массив, содержащий множители параметра
       num.После выполнения метода out-параметр numfactors
      будет содержать количество найденных множителей.*/
        /*static public int[] findfactors(int num, out int numfactors)
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
        }*/

        static int CorrectIntInput()
        {
            bool isCorr;
            int res;
            do
            {
                isCorr = int.TryParse(Console.ReadLine(), out res);
                if (!isCorr)
                {
                    Console.Write("Ошибка. Повторите ввод: ");
                }
            } while (!isCorr);
            return res;
        }

        static int InputN()
        {
            Console.Write("Введите размер матрицы n: ");
            int n = CorrectIntInput();
            while (n < 1)
            {
                Console.Write("Ошибка. Введите размер матрицы n (1 или больше): ");
                n = CorrectIntInput();
            }
            return n;
        }

        static int[] Task(int inLength, int col, ref int[,] inArr, out int outLen)
        {
            int[] res = new int[inLength];
            int curLen = 0, maxLen = 0, curMin = int.MaxValue;
            for (int i = 0; i < inLength; i++)
            {
                if (inArr[i, col] < curMin)
                {
                    curMin = inArr[i, col];
                    curLen++;
                    if (curLen > maxLen)
                    {
                        maxLen = curLen;
                        for (int k = 0; k < maxLen; k++)
                        {
                            res[k] = inArr[k, col];
                        }
                    }
                }
                else
                {
                    curMin = int.MaxValue;
                    curLen = 0;
                }
            }
            outLen = maxLen;
            return res;
        }

        public static void Main()
        {
            int n = InputN();
            inArr = new int[n, n];

            Console.WriteLine("Введите массив построчно");
            for (int i = 0; i < n; i++)
            {
                bool isCorr;
                do
                {
                    Console.Write("Строка {0}: ", i + 1);
                    string[] subs = Console.ReadLine().Split(' ');
                    isCorr = subs.Length == n;
                    for (int j = 0; j < n && isCorr; j++)
                    {
                        isCorr &= int.TryParse(subs[j], out inArr[i, j]);
                    }
                    if (!isCorr)
                    {
                        Console.WriteLine("Ошибка. Повторите ввод данной строки");
                    }
                } while (!isCorr);
            }

            /*Random rnd = new Random();

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    inArr[i, j] = rnd.Next(100);
            Console.WriteLine("произвольно заданная матрица:");
            for (int i = 0; i < inArr.GetLength(0); i++)
            {
                for (int j = 0; j < inArr.GetLength(1); j++)
                    Console.Write("\t" + inArr[i, j]);
                Console.WriteLine();
            }*/

            Console.WriteLine("Ответ:");
            for (int j = 0; j < n; j++)
            {
                int[] outArr = Task(n, j, ref inArr, out int length);
                Console.Write("Серия {0} столбца: ", j + 1);
                for (int i = 0; i < length; i++)
                {
                    Console.Write(outArr[i] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}

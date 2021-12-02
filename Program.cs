using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newCHM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(" Введите количество переменных: ");
            int n = Convert.ToInt32(Console.ReadLine());
            double[,] Arr = new double[n, n + 1];
            Vvod(n, Arr);
            double[,] B = new double[n, n + 1];
            for (int i = 0; i < n; i++)
            {
                Console.Write(" Введите свободный элемент уравнения " + (i + 1) + ": ");
                Arr[i, n] = Convert.ToDouble(Console.ReadLine());
            }
            int c = 0;
            Resh(n, Arr, c, B);
            double[] ix = new double[n];
            for (int i = 0; i < n; i++)
                B[i, 0] = 0;
            ixi(n, B, ix);
            for (int i = 0; i < n; i++)
                Console.WriteLine(" x" + (i + 1) + "= " + ix[i]);
            Console.ReadKey();
        }
        static void Resh(int n, double[,] Arr, int c, double[,] B)
        {
            double[,] Arr1 = new double[n, n];

            for (int i = 0; i < n + 1; i++)
            {
                B[c, i] = Arr[0, i] / Arr[0, 0];
            }
            for (int i = 1; i < n; i++)
                for (int j = 1; j < n + 1; j++)
                {
                    {
                        Arr1[i - 1, j - 1] = Arr[i, j] - Arr[i, 0] * B[c, j];
                    }
                }
            n--;
            c++;
            if (n > 0)
            {
                Resh(n, Arr1, c, B);
            }
        }
        static void Vvod(int n, double[,] Arr)
        {
            int i, j;
            Console.WriteLine(" Введите матрицу: ");
            for (i = 0; i < n; i++)
                for (j = 0; j < n; j++)
                {
                    Console.Write(" Элемент " + (i + 1) + (j + 1) + "=");
                    Arr[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                    Console.Write(Arr[i, j] + "\t");
                Console.WriteLine();
            }
        }
        static void ixi(int n, double[,] B, double[] ix)
        {
            for (int j = 0; j < n; j++)
            {
                ix[n - j - 1] = B[n - j - 1, j + 1];
            }
            for (int j = n - 2; j >= 0; j--)
            {
                for (int i = 1; i < n; i++)
                {
                    ix[j] = ix[j] - B[j, n - j - i] * ix[n - i];
                }
            }
        }
    }
}



using System;
using System.Threading.Tasks;

namespace HomeWork_6
{
    class Program
    { 
        static void Main(string[] args)
        {
            
            int[,] A = new int[100, 100];
            int[,] B = new int[100, 100];
            int[,] C = new int[100, 100]; ;

            FillMatrix(A);
            FillMatrix(B);

            Console.WriteLine("\nМатрица A:");
            PrintMatrix(A);
            Console.WriteLine("\nМатрица B:");
            PrintMatrix(B);
            Console.WriteLine("\nМатрица C = A * B:");

            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount > 2
                                          ? Environment.ProcessorCount - 1 : 1
            };

            Parallel.Invoke(() =>
            {
                C = Multiplication(A, B);
            });

            PrintMatrix(C);
            Console.ReadKey();
        }

        static void FillMatrix(int[,] matrix)
        {
            Random matrixValue = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    matrix[i, j] = matrixValue.Next(0, 10);
                }
            }
        }

        static int[,] Multiplication(int[,] a, int[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            int[,] r = new int[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }
        static void PrintMatrix(int[,] a)
        {
            Console.WriteLine();
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0} ", a[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}


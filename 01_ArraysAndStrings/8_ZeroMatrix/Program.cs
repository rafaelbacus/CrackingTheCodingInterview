using System;
using System.Collections.Generic;
using System.Threading;

namespace _8_ZeroMatrix
{
    class Program
    {
        private static int[,] matrix;
        private static Stack<int[]> zeroLocations;
        private static int rowCount;
        private static int columnCount;

        static void Main(string[] args)
        {
            /*
                Write an algorithm such that if an element in an MxN matrix is 0,
                its entire row and column are set to 0.
            */

            Console.WriteLine("Enter number of rows:");
            rowCount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter number of columns:");
            columnCount = Convert.ToInt32(Console.ReadLine());

            CreateMatrix();
            PrintMatrix();

            FindZeros();

            ZeroMatrix();
            PrintMatrix();

            Console.ReadKey();
        }

        static void ZeroMatrix()
        {
            FindZeros();

            for (int i = 0; i < zeroLocations.Count; i++)
            {
                int[] location = zeroLocations.Pop();

                ZeroOutRow(location[0]);
                ZeroOutColumn(location[1]);
            }
        }

        static void ZeroOutRow(int row)
        {
            for (int column = 0; column < columnCount; column++)
            {
                matrix[row, column] = 0;
            }
        }

        static void ZeroOutColumn(int column)
        {
            for (int row = 0; row < rowCount; row++)
            {
                matrix[row, column] = 0;
            }
        }

        static void FindZeros()
        {
            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    if (matrix[row, column] == 0)
                    {
                        zeroLocations.Push(new int[2]{row, column});
                    }
                }
            }
        }

        static void CreateMatrix()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int min = 0;
            int max = 10;

            matrix = new int[rowCount, columnCount];

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    matrix[i, j] = rand.Next(min, max);
                }
            }

            zeroLocations = new Stack<int[]>();
        }

        static void PrintMatrix()
        {
            Console.WriteLine();

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
} 
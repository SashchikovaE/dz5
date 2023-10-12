using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tumakov6
{
    internal class Program
    {
        static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows1 = matrix1.GetLength(0);
            int cols1 = matrix1.GetLength(1);
            int rows2 = matrix2.GetLength(0);
            int cols2 = matrix2.GetLength(1);

            if (cols1 != rows2)
            {
                throw new Exception("невозможно выполнить умножение матриц с данными размерностями");
            }
            int[,] result = new int[rows1, cols2];

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    for (int k = 0; k < cols1; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return result;
        }
        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("упражнение 2");
            int[,] matrix1 =
            {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
            };

            int[,] matrix2 =
            {
            { 10, 11 },
            { 12, 13 },
            { 14, 15 }
            };
            try
            {
                int[,] result = MultiplyMatrices(matrix1, matrix2);
                PrintMatrix(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            Console.ReadLine();

            Console.WriteLine("упражнение 3");
            double[,] temperature = new double[12, 30];
            Random random = new Random();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    temperature[i, j] = random.Next(-30, 30);
                }
            }
            double[] averageTemperatures = CalculateAverageTemperatures(temperature);
            Array.Sort(averageTemperatures);
            Console.WriteLine("отсортированный массив средних температур:");
            foreach (double Temperature in averageTemperatures)
            {
                Console.WriteLine(temperature);
            }
            Console.ReadKey();
        }
        static double[] CalculateAverageTemperatures(double[,] temperature)
        {
            double[] averageTemperatures = new double[12];

            for (int i = 0; i < 12; i++)
            {
                double sum = 0;
                for (int j = 0; j < 30; j++)
                {
                    sum += temperature[i, j];
                }
                averageTemperatures[i] = sum / 30;
            }

            return averageTemperatures;
        }
    }
}

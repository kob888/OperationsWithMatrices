using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsWithMatrix
{
    public class MatricesOperations
    {
        /// <summary>
        /// Метод выполняет операцию сложения
        /// </summary>
        public int[,] Addition(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
                throw new Exception("Сложение невозможно. Матрицы разного размера.");

            int[,] result = new int[matrix1.GetLength(0), matrix1.GetLength(1)];

            for (int row = 0; row < matrix1.GetLength(0); row++)
            {
                for (int column = 0; column < matrix1.GetLength(1); column++)
                {
                    result[row, column] = matrix1[row, column] + matrix2[row, column];
                }
            }

            return result;
        }


        /// <summary>
        /// Метод выполняет операцию вычитания
        /// </summary>
        public int[,] Subtract(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
                throw new Exception("Вычитание невозможно. Матрицы разного размера.");

            int[,] result = new int[matrix1.GetLength(0), matrix1.GetLength(1)];

            for (int row = 0; row < matrix1.GetLength(0); row++)
            {
                for (int column = 0; column < matrix1.GetLength(1); column++)
                {
                    result[row, column] = matrix1[row, column] - matrix2[row, column];
                }
            }

            return result;
        }


        /// <summary>
        /// Метод выполняет операцию умножения
        /// </summary>
        public int[,] Multiplication(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
                throw new Exception("Умножение невозможно. Количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");

            int[,] result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];

            for (int row = 0; row < matrix1.GetLength(0); row++)
            {
                for (int column = 0; column < matrix2.GetLength(1); column++)
                {
                    for (int i = 0; i < matrix2.GetLength(0); i++)
                    {
                        result[row, column] += matrix1[row, i] * matrix2[i, column];
                    }
                }
            }

            return result;
        }


        /// <summary>
        /// Метод выполняет операцию транспонирования
        /// </summary>
        public int[,] Transpose(int[,] matrix)
        {
            int[,] result = new int[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    result[i, j] = matrix[j, i];
                }
            }
            return result;
        }
    }
}

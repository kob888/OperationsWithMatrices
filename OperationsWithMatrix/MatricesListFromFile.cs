using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsWithMatrix
{
    class MatricesListFromFile
    {
        /// <summary>
        /// Метод возвращает список матриц в файле
        /// </summary>
        public List<int[,]> GetMatricesList(StreamReader reader)
        {            
            var matricesList = MatricesFromFile(reader);

            Console.WriteLine("Число матриц в файле: " + matricesList.Count);

            return matricesList;
        }

        /// <summary>
        /// Метод принимает поток, выполняет чтение файла, составляет и возвращает список матриц
        /// </summary>
        private List<int[,]> MatricesFromFile(StreamReader reader)
        {
            var arraysList = new List<int[]>();
            var matricesList = new List<int[,]>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                if (!string.IsNullOrWhiteSpace(line))
                {                    
                    int[] array = line.Trim().Split(' ').Select(Int32.Parse).ToArray();
                    
                    arraysList.Add(array);
                    continue;
                }

                if (arraysList.Count < 1)
                    continue;

                matricesList.Add(NewMatrix(arraysList));

                arraysList = new List<int[]>();
            }

            if (arraysList.Count > 0)
                matricesList.Add(NewMatrix(arraysList));

            return matricesList;
        }

        /// <summary>
        /// Метод получает список массивов и генерирует из них двумерный массив (матрицу)
        /// </summary>
        private int[,] NewMatrix(List<int[]> matrix)
        {           
           int[,] newMatrix = new int[matrix.Count, matrix[0].Length];

            for (int i = 0; i < matrix.Count; i++)
            {
                var array = matrix[i];

                for (int j = 0; j < matrix[0].Length; j++)
                {
                    newMatrix[i, j] = array[j];
                }
            }

            return newMatrix;
        }


    }
}

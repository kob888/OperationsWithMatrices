using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsWithMatrix
{
    public class FileAction
    {
        string act = "";
        MatricesListFromFile matricesFromFile;
        MatricesOperations operation;

        /// <summary>
        /// Метод получает полный путь к файлу и передает его на чтение методу ReadFile.
        /// Полученный список матриц распределяет для транспонирования или сложения/вычитания/умножения.
        /// </summary>
        public void Calculate(string path)
        {
            var matricesList = ReadFile(path);        
            
            if (act.ToLower() == "transpose")
                CreateResultFile(path, TransposeOperationResult(matricesList));
            else
                CreateResultFile(path, MatricesOperationsResult(matricesList));
        }

        /// <summary>
        /// Метод читает файл, и путем исполнения метода GetMatricesList, возвращает список с матрицами, которые содержит файл
        /// </summary>
        private List<int[,]> ReadFile(string path)
        {
            if (String.IsNullOrEmpty(path) || String.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException();

            matricesFromFile = new MatricesListFromFile();
            var matricesList = new List<int[,]>();

            using (StreamReader reader = new StreamReader(path))
            {
                act = reader.ReadLine();                                  // Читаем строку с названием операции
                reader.ReadLine();                                        // Пустая строка    

                matricesList = matricesFromFile.GetMatricesList(reader);
            }            

            return matricesList;           
        }


        /// <summary>
        /// Метод возвращает матрицу - результат выбранной операции (сложение / вычитание / умножение) 
        /// </summary>
        private int[,] MatricesOperationsResult(List<int[,]> matricesList)
        {
            if (matricesList.Count < 1)
                throw new ArgumentNullException("");

            operation = new MatricesOperations();

            int[,] result = matricesList[0];

            for (int i = 1; i < matricesList.Count; i++)
            {
                if (act.ToLower() == "add")
                {
                    Console.WriteLine("Выполняется операция сложения (" + i + ")...");
                    result = operation.Addition(result, matricesList[i]);
                }              
                else if (act.ToLower() == "subtract")
                {
                    Console.WriteLine("Выполняется операция вычитания (" + i + ")...");
                    result = operation.Subtract(result, matricesList[i]);
                }
                else if (act.ToLower() == "multiply")
                {
                    Console.WriteLine("Выполняется операция умножения (" + i + ")...");
                    result = operation.Multiplication(result, matricesList[i]);
                }
                else
                    throw new ArgumentException("Недопустимая операция с матрицей. Неверное имя: " + act + ". Список допустимых операций: multiply, add, subtract, transpose.");
            }

            return result;
        }

        /// <summary>
        /// Метод передает матрицы в класс MatricesOperations для транспонирования,
        /// и возвращает список транспонированных матриц.
        /// </summary>
        private List<int[,]> TransposeOperationResult(List<int[,]> matricesList)
        {
            if (matricesList.Count < 1)
                throw new ArgumentNullException("");

            Console.WriteLine("Выполняется операция транспонирования...");
            int i = 1;

            operation = new MatricesOperations();
            List<int[,]> transposeList = new List<int[,]>();

            foreach(var matrix in matricesList)
            {
                Console.WriteLine("Транспонируем матрицу №" + i);
                var result = operation.Transpose(matrix);
                transposeList.Add(result);
                i++;
            }

            return transposeList;
        }

        /// <summary>
        /// Метод получает полный путь с именем исполняемого файла, и возвращает строку для файла с результатом
        /// </summary>
        private string OutputFileName (string path)
        {
            var fileName = Path.GetFileNameWithoutExtension(path);
            var directory = Path.GetDirectoryName(path);

            var output = directory + "\\" + fileName + "_result.txt";

            return output;
        }

        /// <summary>
        /// Метод записывает результат (одну матрицу) в новый файл, и сохраняет его в исходную папку 
        /// </summary>
        private void CreateResultFile(string path, int[,] matrixList)
        {
            var fileName = OutputFileName(path);
            Console.WriteLine("Записываем результаты в новый файл " + Path.GetFileNameWithoutExtension(fileName));

            using (StreamWriter output = File.AppendText(fileName))
            {
                for (int i = 0; i < matrixList.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixList.GetLength(1); j++)
                    {
                        output.Write(string.Format("{0} ", matrixList[i, j]));
                    }
                    output.Write(Environment.NewLine);
                }
            }
            Console.WriteLine("Данные записаны.");
        }

        /// <summary>
        /// Метод записывает результат (список транспонированных матриц) в новый файл, и сохраняет его в исходную папку
        /// </summary>
        private void CreateResultFile(string path, List<int[,]> matrixList)
        {
            var fileName = OutputFileName(path);
            Console.WriteLine("Записываем результаты в новый файл " + Path.GetFileNameWithoutExtension(fileName));

            using (StreamWriter output = File.AppendText(fileName))
            {
                foreach (var item in matrixList)
                {
                    for (int i = 0; i < item.GetLength(0); i++)
                    {
                        for (int j = 0; j < item.GetLength(1); j++)
                        {
                            output.Write(string.Format("{0} ", item[i, j]));
                        }
                        output.Write(Environment.NewLine);
                    }
                    output.WriteLine();
                }
            }
            Console.WriteLine("Данные записаны.");
        }


    }
}

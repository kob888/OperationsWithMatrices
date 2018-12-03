using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsWithMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя директории с файлами:");
            var folder = Console.ReadLine();

            Console.WriteLine("Директория получена, программа начинает работу.");
            
            DirectoryManipulation start = new DirectoryManipulation(folder);
            start.StartCalculations();            

            Console.WriteLine();
            Console.WriteLine("Конец работы программы. Нажмите любую клавишу...");
        
            Console.ReadKey();
        }
    }
}

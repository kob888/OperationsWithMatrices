using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsWithMatrix
{
    public class DirectoryManipulation
    {
        private string folder;
        FileAction action;

        public DirectoryManipulation(string folder)
        {
            this.folder = folder;
        }
        

        public string[] GetFileList()
        {
            var filesList = Directory.GetFiles(folder);

            Console.WriteLine("Файлов в директории: " + filesList.Length);

            return filesList;
        }

        /// <summary>
        /// Метод передает каждый файл директории в метод Calculate класса FileAction
        /// </summary>
        public void StartCalculations()
        {
            action = new FileAction();

            foreach (var file in GetFileList())
            {
                Console.WriteLine("Файл " + Path.GetFileNameWithoutExtension(file) + " в работе...");
                action.Calculate(file);
            }
        }


    }
}

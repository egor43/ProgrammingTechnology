using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProgrammingTechnology
{
    //Класс "Converter" - статический
    //Представляет собой инструмент преобразования из "сырого" массива элементов,
    //находящихся в текстовом файле, в массив целочисленных значений.
    //
    //Ответственный: Саматов Д. 
    
    /// <summary>
    /// Класс конвертера.
    /// </summary>
    static class Converter
    {
        /// <summary>
        /// Массив возможных символов-разделителей.
        /// </summary>
        public static char[] DefaultSeparators
        { get { return new char[] { ',', ';', ':', '.', '/', '\\', '*', '=', '^', '!', '?', '%', '$', '@', '#', '~' }; } }

        /// <summary>
        /// Метод, производящий конвертацию данных из текстового файла с расширением .txt в массив целых чисел типа int.
        /// </summary>
        /// <param name="path">Путь к текстовому файлу с расширением .txt.</param>
        /// <param name="separators">Массив символов-разделителей, отделяющих числа друг от друга.</param>
        /// <returns>Массив целых чисел типа int.</returns>
        public static int[] Convert(string path, char[] separators)
        {
            List<int> listArray = new List<int>();//Временный лист чисел для добавления чисел из файла.
            string read;//Строка для чтения из файла построчно.
            int tmpInt;//Временная переменная для хранения преобразованного из строки числа.
            
            StreamReader sReader = new StreamReader(path);
            try
            {
                while ((read = sReader.ReadLine()) != null)
                {
                    foreach (var v in read.Split(separators))
                    {
                        if (int.TryParse(v.Trim(' '), out tmpInt))
                        {
                            listArray.Add(tmpInt);
                        }
                        else if (v.Trim(' ') != "")
                        {
                            throw new ArgumentException("Файл содержит недопустимые символы.");
                        }
                    }
                }
                sReader.Close();
            }
            catch
            {
                return listArray.ToArray();
            }

            return listArray.ToArray();
        }

        /// <summary>
        /// Метод тестирования конвертера.
        /// Конвертер преобразует тестовые файлы, если удачно - тест пройден, иначе - тест не пройден.
        /// </summary>
        /// <returns>Словарь, где ключ - имя тестируемого файла, значение - удачно ли прошел тест.</returns>
        public static Dictionary<string, bool> Test()
        {
            Dictionary<string, bool> test_result = new Dictionary<string, bool>();
            if (!Directory.Exists("ConverterTestFiles"))
            {
                test_result.Add("FolderNotFound", false);
                return test_result;
            }
            DirectoryInfo dir = new DirectoryInfo("ConverterTestFiles");

            foreach (var v in dir.GetFiles())
            {
                try
                {
                    Convert(v.FullName, DefaultSeparators);
                    test_result.Add(v.Name, true);
                }
                catch
                {
                    test_result.Add(v.Name, false);
                }
            }

            return test_result;
        }
    }
}

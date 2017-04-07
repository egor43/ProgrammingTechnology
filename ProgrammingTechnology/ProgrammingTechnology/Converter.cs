using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProgrammingTechnology
{
    //Класс "Converter" - статический
    //Представляет собой инструмент преобразования из "сырго" массива элементов,
    //находящихся в текстовом файле, в массив целочисленных значений.
    //
    //Ответственный: Саматов Д. 
    
    /// <summary>
    /// Класс конвертера.
    /// </summary>
    static class Converter
    {
        /// <summary>
        /// Метод, производящий конвертацию данных из текстового файла с расширением .txt в массив целых чисел типа int.
        /// </summary>
        /// <param name="path">Путь к текстовому файлу с расширением .txt.</param>
        /// <param name="separators">Массив символов-разделителей, отделяющих числа.</param>
        /// <returns>Массив целых чисел типа int.</returns>
        public static int[] Convert(string path, char[] separators)
        {
            List<int> listArray = new List<int>();//Временный лист чисел для добавления чисел из файла.
            string read;//Строка для чтения из файла построчно.
            int tmpInt;//Временная переменная для хранения преобразованного из строки исла.

            StreamReader sReader = new StreamReader(path);            
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

            return listArray.ToArray();
        }
    }
}

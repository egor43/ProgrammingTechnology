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
    
    static class Converter
    {
        public static int[] Convert(string path, char[] separators)
        {
            List<int> listArray = new List<int>();

            string read;
            string[] tmpString;
            int tmpInt;

            StreamReader sReader = new StreamReader(path);            
            while ((read = sReader.ReadLine()) != null)
            {
                tmpString = read.Split(separators);
                foreach (var v in tmpString)
                    if (int.TryParse(v.Trim(' '), out tmpInt))
                        listArray.Add(tmpInt);
                    else
                        if (v.Trim(' ') != "")
                            throw new ArgumentException("Файл содержит недопустимые символы.");                
            }
            sReader.Close();

            int[] intArray = listArray.ToArray();

            return listArray.ToArray();
        }
    }
}

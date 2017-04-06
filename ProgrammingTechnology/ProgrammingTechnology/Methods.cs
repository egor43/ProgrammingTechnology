using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingTechnology
{
    //Класс "Methods" - статический
    //Представляет собой хранилище методов сортировок.
    //Класс предоставляет инструменты для работы с методами сортировок.
    //
    //Ответственный: Шамхалов Р. 

    static class Methods
    {
        private static int[] GnomeSort(int[] Input)
        {
            int index = 0;
            while (index < Input.Length)
            {
                if (index == 0 || Input[index - 1] <= Input[index]) index++;
                else
                {
                    int cash = Input[index];
                    Input[index] = Input[index - 1];
                    Input[index - 1] = cash; 
                    index--;
                }
            }
            return Input;
        }
        
        static void swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        
       public static int[] BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                for (int j = i + 1; j < array.Length; j++)
                    if (array[i] > array[j])
                        swap(array,i,j);    
           
            return array;
        }

        /// <summary>
        /// Метод демонстрирует производительность только на многопоточных процессорах
        /// </summary>
       public static int[] OddEvenSort(int[] array)
        {
            for (int i = 0; i < array.Count(); i++)
            {
                if (i % 2 == 0) // текущая позиция нечетная
                {
                    for (int j = 2; j < array.Length; j += 2)
                        if (array[j] < array[j - 1])
                            swap(array, j, j - 1);
                }
                else
                {
                    for (int j = 1; j < array.Length; j += 2)                    
                        if (array[j] < array[j - 1])
                            swap(array, j, j - 1);
                }
            }       
            return array;
        }
    }
}

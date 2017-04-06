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
        
       public static int[] BubbleSort(int[] array)
        {
            int temp;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }                   
                }            
            }
            return array;
        }
     /// <summary>
     /// Метод демонстрирует производительность только на многопоточных процессорах
     /// </summary>
    static int[] OddEvenSort(int[] array)
        {
            int temp ;
            for (int i = 0; i < array.Count(); i++)
            {
                if (i % 2 == 0) //нечетные
                {
                    for (int j = 2; j < array.Length; j += 2)
                    {
                        if (array[j] < array[j - 1])
                        {
                            temp = array[j];
                            array[j] = array[j - 1];
                            array[j - 1] = temp;
                        }
                    }
                }
                else
                {
                    for (int j = 1; j < array.Length; j += 2)
                    {
                        if (array[j] < array[j - 1])
                        {
                            temp = array[j];
                            array[j] = array[j - 1];
                            array[j - 1] = temp;
                        }
                    }
                }
            }
            return array;
        }
    }
}

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
        
       /// <summary>
       /// Метод обмена местами двух элементов в массиве.
       /// </summary> 
       private static void swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        
        /// <summary>
        /// Сортировка пузырьковая.
        /// Суть алгоритма закючается в том, чтобы проходя n-1 раз по массиву, каждый проход сравнивать элементы попарно и, 
        /// если порядок в паре неверный, выполнять обмен элементов.
        /// </summary>
        private static int[] BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                for (int j = i + 1; j < array.Length; j++)
                    if (array[i] > array[j])
                        swap(array,i,j);    
           
            return array;
        }

        /// <summary>
        /// Сортировка чет-нечет.
        /// Представляет собой модификацию пузырьковой сортировки разработанную для использования на параллельных процессорах. 
        /// Суть модификации в том, чтобы независимо сравнивать элементы массива под чётными и нечётными индексами с последующими элементами.
        /// </summary>
       private static int[] OddEvenSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0) 
                {//для нечетных
                    for (int j = 2; j < array.Length; j += 2)
                        if (array[j] < array[j - 1])
                            swap(array, j, j - 1);
                }
                else 
                {//для четных
                    for (int j = 1; j < array.Length; j += 2)                    
                        if (array[j] < array[j - 1])
                            swap(array, j, j - 1);
                }
            }       
            return array;
        }
    }
}

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
        private static int[] MergeSort(int[] mas) //сортировка слиянием
        {
            if (mas.Length == 1) return mas;
            int middle = mas.Length / 2;

            // массивы для разбиения входного массива на две части
            int[] left = new int[middle];
            int[] right = new int[mas.Length - middle];

            // заполнение данными из входного массива
            for (int i = 0; i < middle; i++)
                left[i] = mas[i];
            for (int i = 0; i < mas.Length - middle; i++)
                right[i] = mas[i + middle];

            // рекурсивно вызываем функцию разбиения входного массива, рабиваем на части, содержащие по два числа из входного массива
            left = MergeSort(left);
            right = MergeSort(right);

            int leftptr = 0;
            int rightptr = 0;

            int[] sorted = new int[mas.Length];

            // слияние упорядоченных частей исходного массива
            for (int i = 0; i < mas.Length; i++)
            {
                if (rightptr == right.Length || ((leftptr < left.Length) && (left[leftptr] <= right[rightptr])))
                {
                    sorted[i] = left[leftptr];
                    leftptr++;
                }
                else if (leftptr == left.Length || ((rightptr < right.Length) && (right[rightptr] <= left[leftptr])))
                {
                    sorted[i] = right[rightptr];
                    rightptr++;
                }
            }

            return sorted;
        }

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
        
        private static int [] Sheker(int[] array)
        {
            // левая и правая границы сортируемой области массива
            int left = 0, right = array.Length - 1;
            bool flag = true; // наличие перемещений

            /* Выполнение цикла пока левая граница не сомкнётся с правой
               или пока в массиве имеются перемещения */
            while ((left < right) && flag == true)
            {
                flag = false;
                for (int i = left; i < right; i++)  //двигаемся слева направо
                {
                    if (array[i] > array[i + 1]) // если следующий элемент меньше текущего,
                    {                           // меняем их местами
                        int t = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = t;
                        flag = true;      // перемещения в этом цикле были
                    }
                }
                right--; // сдвигаем правую границу на предыдущий элемент

                for (int i = right; i > left; i--)  //двигаемся справа налево
                {
                    if (array[i - 1] > array[i]) // если предыдущий элемент больше текущего,
                    {                           // меняем их местами
                        int t = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = t;
                        flag = true;    // перемещения в этом цикле были
                    }
                }
                left++; // сдвигаем левую границу на следующий элемент
            }

            return array;
        }
    }
}

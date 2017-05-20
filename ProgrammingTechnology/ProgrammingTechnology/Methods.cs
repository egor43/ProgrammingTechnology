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
        private Dictionary<string,bool> Test_InsertionSort()
        {
            string name="InsertionSort";
            int[] t1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] t2 = new int[] { };
            int[] t3 = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            int[] t4 = new int[] { 9, 64, 7, -6, 5, 64, 3, 2, -1, 0 };
            int[] t5 = new int[] { 5};
            int[] t6 = new int[] { -5, -10, -8, -7,  -3};
          
            Dictionary<string,bool> test = new Dictionary<string,bool>();
            
            #if Debug
            test.Add(name,Check_Array(InsertionSort(t1)));
             test.Add(name,Check_Array(InsertionSort(t2)));
             test.Add(name,Check_Array(InsertionSort(t3)));
             test.Add(name,Check_Array(InsertionSort(t4)));
             test.Add(name,Check_Array(InsertionSort(t5)));
             test.Add(name,Check_Array(InsertionSort(t6)));
            #else
           test.Add(name,Check_Array(InsertionSort(t1)));
             test.Add(name,Check_Array(InsertionSort(t2)));
             test.Add(name,Check_Array(InsertionSort(t3)));
            #endif
            return test;
        }
        
        private Dictionary<string,bool> Test_MergeSort()
        {
            string name="MergeSort";
            int[] t1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] t2 = new int[] { };
            int[] t3 = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            int[] t4 = new int[] { 9, 64, 7, -6, 5, 64, 3, 2, -1, 0 };
            int[] t5 = new int[] { 5};
            int[] t6 = new int[] { -5, -10, -8, -7,  -3};
          
            Dictionary<string,bool> test = new Dictionary<string,bool>();
            
            #if Debug
            test.Add(name,Check_Array(MergeSort(t1)));
             test.Add(name,Check_Array(MergeSort(t2)));
             test.Add(name,Check_Array(MergeSort(t3)));
             test.Add(name,Check_Array(MergeSort(t4)));
             test.Add(name,Check_Array(MergeSort(t5)));
             test.Add(name,Check_Array(MergeSort(t6)));
            #else
           test.Add(name,Check_Array(MergeSort(t1)));
             test.Add(name,Check_Array(MergeSort(t2)));
             test.Add(name,Check_Array(MergeSort(t3)));
            #endif
            return test;
        }

        //Омеличева Наталья (Сортировка вставками)
        private static int[] InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int value = array[i]; // текущее значение
                int j = i;
                while (j > 0 && array[j - 1] > value) // идем по массиву влево и переставляем текущее значение до тех пор, пока оно не станет больше значения слева
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = value;
            }
            return array;
        }

        //Омеличева Наталья (Сортировка слиянием)
        private static int[] MergeSort(int[] mas)
        {
            if (mas.Length <= 1) return mas;
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
    }
}

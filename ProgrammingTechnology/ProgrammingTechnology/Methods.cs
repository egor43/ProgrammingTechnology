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

        private static int [] SelectionSort(int[] Insert)//сортировка выбором
        {

            int minEl, kesh;
            int length = Insert.Length;

            for (int index = 0; index < length - 1; index++)
            {
                //устанавливаем начальное значение минимального индекса 
                minEl = index;

                //находим индекс минимального элемента 
                for (int j = index + 1; j < length; j++)
                {
                    if (Insert[j] < Insert[minEl])
                    {
                        minEl = j;
                    }
                }

                //меняем местами значения
                if (minEl != index)
                {
                    kesh = Insert[index];
                    Insert[index] = Insert[minEl];
                    Insert[minEl] = kesh;
                }
                return Insert;
          }
            private Dictionary<string, bool> SelectionSort_Test() 
            { 
                string name = "SelectionSort"; 
                int[] t1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; 
                int[] t2 = new int[] { }; 
                int[] t3 = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }; 
                int[] t4 = new int[] { 1, 1, 2, 3, 3, 5, 6 }; 
                int[] t5 = new int[] { 1, 2, 3, 3, 5, 6 }; 
                int[] t6 = new int[] { -1, -1, -2, -3, -3, -5, -6 }; 
                int[] t7 = new int[] { -1, -2, -3, -3, -5, -6 }; 
                int[] t8 = new int[] { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 }; 
                int[] t9 = new int[] { 0, 1, 2, -3, 4, -4, 3, 2, 1, 0 }; 
                Dictionary<string, bool> test_dic = new Dictionary<string, bool>(); 
                #if Debug 
                test_dic.Add(name,Check_Array(SelectionSort(t1))); 
                test_dic.Add(name,Check_ArraySelectionSort(t2))); 
                test_dic.Add(name,Check_Array(SelectionSortt3))); 
                test_dic.Add(name,Check_Array(SelectionSort(t4))); 
                test_dic.Add(name,Check_Array(SelectionSort(t5))); 
                test_dic.Add(name,Check_Array(SelectionSort(t6))); 
                test_dic.Add(name,Check_Array(SelectionSort(t7))); 
                test_dic.Add(name,Check_Array(SelectionSort(t8))); 
                test_dic.Add(name,Check_Array(SelectionSort(t9))); 
                #else 
                test_dic.Add(name, Check_Array(SelectionSort(t1))); 
                test_dic.Add(name, Check_Array(SelectionSort(t2))); 
                test_dic.Add(name, Check_Array(SelectionSort(t3))); 
                test_dic.Add(name, Check_Array(SelectionSort(t8))); 
                test_dic.Add(name, Check_Array(SelectionSort(t9))); 
                #endif 
                return test_dic; 
            }
        }
    }
}

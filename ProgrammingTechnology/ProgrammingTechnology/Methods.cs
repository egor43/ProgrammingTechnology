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
        //Для Пети
        static private Dictionary<string,Func<int[], int[]>> DicMetSor=new Dictionary<string,Func<int[],int[]>> {
                                                                                    {"SelectionSort", SelectionSort},
                                                                                    {"BubbleSort", BubbleSort},
                                                                                    {"OddEvenSort", OddEvenSort},
                                                                                    {"CombSor",CombSor},
                                                                                    {"InsertionSort",InsertionSort},
                                                                                    {"MergeSort",MergeSort},
                                                                                    {"GnomeSort",GnomeSort},
                                                                                    {"Sheker",Sheker},
                                                                                    {"FlagBubbleSort",FlagBubbleSort}};
       //Для Егора, а потом для Пети
       static private Dictionary<int, string> DicIdName =new Dictionary<int, string> {{1,"SelectionSort"},
                                                                                      {2,"BubbleSort"},
                                                                                      {3,"OddEvenSort"},
                                                                                      {4,"CombSor"},
                                                                                      {5,"InsertionSort"},
                                                                                      {6,"MergeSort"},
                                                                                      {7,"GnomeSort"},
                                                                                      {8,"Sheker"},
                                                                                      {9,"FlagBubbleSort"}};
        
        //Александр Попов (Сортировка выбором)
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
        
        //Лебедев Михаил (Сортировка расческой)
        private static int[] CombSor(int[] array)
        {
            int h = array.Length; // начальный шаг
            bool swapped = false; // наличие перемещений

            while ((h > 1) || swapped)
            {
                if (h > 1)
                    h = (int)(h / 1.247330950103979); // Фактор уменьшения

                swapped = false;

                for (int i = 0; h + i < array.Length; ++i) // пока сравниваемый элемент в массиве
                {
                    /*если позиция текущего элемента следует после позиции другого элемента, 
                      меняем их местами */
                    if (array[i].CompareTo(array[i + h]) > 0)                              
                    {
                        swap(array,i,i+h);
                        swapped = true;
                    }
                }
            }
            return array;
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
        
        //Мезенцев Александр (Гномья сортировка)
        private static int[] GnomeSort(int[] Input)
        {
            int index = 0;
            while (index < Input.Length)
            {
                if (index == 0 || Input[index - 1] <= Input[index]) index++;
                else
                {
                    swap(Input,index,index-1);
                    index--;
                }
            }
            return Input;
        }
        
        //Лебедев Михаил (Шейкерная сортировка)
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
                    { 
                        swap(array,i,i+1);  // меняем их местами
                        flag = true;      // перемещения в этом цикле были
                    }
                }
                right--; // сдвигаем правую границу на предыдущий элемент

                for (int i = right; i > left; i--)  //двигаемся справа налево
                {
                    if (array[i - 1] > array[i]) // если предыдущий элемент больше текущего,
                    {    
                        swap(array,i,i-1);  // меняем их местами
                        flag = true;    // перемещения в этом цикле были
                    }
                }
                left++; // сдвигаем левую границу на следующий элемент
            }

            return array;
        }
        
        /// <summary>
        /// Сортировка пузырьковая с флагом.
        /// Алгоритм, являеется модернизацией классической пузырьковой сортировки. Цикл перебора останавливается, когда элементы отсортированы.
        /// </summary>
        private static int[] FlagBubbleSort(int[] array)
        {
            bool flag = false;
            for (int i = 0; i < array.Length && flag != true; i++){
             flag = true;
                for (int j = i + 1; j < array.Length; j++)
                    if (array[i] > array[j]){
                        swap(array,i,j);    
                        flag = false;
                    }
            }
            return array;
        }
    }
}

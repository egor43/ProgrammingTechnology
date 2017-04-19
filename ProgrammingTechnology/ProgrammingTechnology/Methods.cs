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
    //
    //Ответственный: Шамхалов Р. 

    static class Methods
    {
        static int[] ModifiedBubbleSort(int[] input)
        {
            int i = 0;
            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (int j = 0; j < input.Length - i - 1; j++)
                {
                    if (input[j] > input[j + 1])
                    {
                        int cash = input[j];
                        input[j] = input[j + 1];
                        input[j + 1] = cash;
                        sorted = false;
                    }
                }
                ++i;
            }
            return input;
        }
    }
}

using System;
using System.Collections.Generic;

namespace ProgrammingTechnology
{
    using System.Diagnostics;
    //Класс "Decorator" - статический
    //Представляет собой инструмент для обработки методов.
    //Класс обрабатывает полезную информацию о ходе работы методов.
    // 
    //Ответственный: Георгиевский П. 

    // Делегат используемый для методов сортировки, на вход идет неотсортированный массив.
    using MethodInfo_Pair = KeyValuePair<string, Func<int[], int[]>>;

    static class Decorator
    {
        private static MethodInfo ExceptionOutOfRangeMethodInfo = new MethodInfo("Метод не найден", -1, -1);
        private static MethodInfo ExceptionErrorMethodInfo = new MethodInfo("Ошибка при вызове метода", -1, -1);

        public delegate void MethodClose();
        public static event MethodClose CloseMethod;

        /// <summary>
        /// Запускает методы сортировки с идентификаторами из methodIDs для массива array.
        /// </summary>
        /// <param name="methodIDs">Список содержащий идентификаторы методов которые требуется запустить</param>
        /// <param name="array">Массив для сортировки</param>
        /// <returns>Список результатов вызова методов</returns>
        public static List<MethodInfo> RunMethods(List<int> methodIDs, int[] array)
        {
            List<MethodInfo> decRes = new List<MethodInfo>();

            // Бежим по всем полученым делегатам и вызываем данные методы.
            for (int i = 0; i < methodIDs.Count; i++) {
                // РУСЯ: плс сделай понормальному сам видишь как это некрасиво
                try
                {
                    MethodInfo_Pair methodInputInfo = new MethodInfo_Pair(Methods.DicIdName[methodIDs[i]], Methods.DicMetSor[Methods.DicIdName[methodIDs[i]]]);
                    decRes.Add(RunMethod(methodInputInfo, array));
                }
                catch (IndexOutOfRangeException e)
                {
                    decRes.Add(ExceptionOutOfRangeMethodInfo);
                }
                catch(Exception e)
                {
                    decRes.Add(ExceptionErrorMethodInfo);
                }
            }

            return decRes;
        }

        // Вызывает метод из пары "метод+имя" methodInputInfo для массива array.
        private static MethodInfo RunMethod(MethodInfo_Pair methodInputInfo, int[] array)
        {
            MethodInfo outStruct; int[] sortedArray;
            Stopwatch timer = new Stopwatch();

            timer.Start();
            sortedArray = methodInputInfo.Value(array);
            timer.Stop();

            outStruct.name      = methodInputInfo.Key;
            outStruct.time      = (int)timer.Elapsed.TotalSeconds;                 // Время в секундах.
            outStruct.capacity  = sortedArray.Length;   // Спорный вопрос: на кой черт метод возвращает размер обработанного массива,
                                                        // если мы вызываем все методы для одного массива за раз и этот размер не меняется со временем.

            if(CloseMethod!=null)
            {
                CloseMethod.Invoke();
            }

            return outStruct;
        }

        public static Dictionary<string,bool> Test()
        {
            Dictionary<string, bool> test_result=new Dictionary<string, bool>();
            List<int> test_methodIDlist = new List<int>
            {
                -1
            };
            int[] test_array = new int[] { 1, 3, 2};

            List<MethodInfo> test_resList = RunMethods(test_methodIDlist, test_array);
            test_result.Add("Проверка на ввод несуществующего метода", !test_resList[0].Equals(ExceptionOutOfRangeMethodInfo));

            test_methodIDlist = new List<int>
            {
                1,2
            };
            test_resList = RunMethods(test_methodIDlist, test_array);
            test_result.Add("Проверка на неизменность размера массива", test_resList[0].capacity== test_resList[1].capacity);
            return test_result;
        }
    }
}

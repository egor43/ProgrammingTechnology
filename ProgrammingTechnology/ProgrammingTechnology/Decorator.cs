using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingTechnology
{
    //Класс "Decorator" - статический
    //Представляет собой инструмент для обработки методов.
    //Класс обрабатывает полезную информацию о ходе работы методов.
    // 
    //Ответственный: Георгиевский П. 

    // Делегат используемый для методов сортировки, на вход идет неотсортированный массив.
    public delegate int[] STD_SortingMethod(int[] array);

    static class Decorator
    {
        /// <summary>
        /// Запускает методы сортировки с идентификаторами из methodIDs для массива array.
        /// </summary>
        /// <param name="methodIDs">Список содержащий идентификаторы методов которые требуется запустить</param>
        /// <param name="array">Массив для сортировки</param>
        /// <returns>Список результатов вызова методов</returns>
        public static List<MethodInfo> RunMethods(List<int> methodIDs, int[] array)
        {
            List<MethodInfo> decRes = new List<MethodInfo>();
            List<KeyValuePair<STD_SortingMethod, string>> methodsDelegates = new List<KeyValuePair<STD_SortingMethod, string>>(); // TODO: Нужен метод возращающий список пар "метод+имя" на 
                                                                                                                                  // вход которого идет список ID методов.

            // Бежим по всем полученым делегатам и вызываем данные методы.
            foreach (var method in methodsDelegates)
                decRes.Add(RunMethod(method, array));

            return decRes;
        }

        // Вызывает метод из пары "метод+имя" methodInputInfo для массива array. TODO: Решить нужно ли возвращать сортированный массив
        private static MethodInfo RunMethod(KeyValuePair<STD_SortingMethod, string> methodInputInfo, int[] array)
        {
            MethodInfo outStruct; int[] sortedArray; int time;

            time = DateTime.Now.Second;
            sortedArray = methodInputInfo.Key(array);
            time -= DateTime.Now.Second;

            outStruct.name      = methodInputInfo.Value;
            outStruct.time      = time;                 // Время в секундах. TODO: Решить нужно ли хранить время в более точном формате/в виде структуры DateTime.
            outStruct.capacity  = sortedArray.Length;   // Спорный вопрос: на кой черт метод возвращает размер обработанного массива,
                                                        // если мы вызываем все методы для одного массива за раз и этот размер не меняется со временем.

            return outStruct;
        }
    }
}

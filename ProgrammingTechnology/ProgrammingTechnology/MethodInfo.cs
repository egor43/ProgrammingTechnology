using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingTechnology
{
    //Структура "MethodInfo"
    //Представляет одну порцию информации о работе метода.
    //
    //Ответственный: Мышко Е. 

   public struct MethodInfo
    {
        //Переменные:
        public string name; //Имя метода
        public int time; //Время выполнения метода
        public int capacity; //Объем массива, который метод обработал
        
        //Конструктор:
        public MethodInfo(string name, int time, int capacity)
        {
            this.name = name;
            this.time = time;
            this.capacity = capacity;
        }
    }
}

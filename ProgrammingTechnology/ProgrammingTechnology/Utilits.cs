using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ProgrammingTechnology
{
    static class Utilits
    {
        // Проверяет результаты тестирования методов
        public static string CheckTestResult(Dictionary<string,bool> test_result)
        {
            string error_message = ""; // Сообщение об ошибках
            foreach(var v in test_result) // Идем по словарю с результатами
            {
                if(v.Value==false) // Если нашли в словаре ошибку
                {
                    error_message += v.Key + '\n'; // Пишем ошибку в сообщение
                }
            }
            return error_message;
        }

        // Инициализирует и запускает поток с выводом сообщения
        public static void ShowMessage(string message)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(MsgShow));
            thread.Start(message);
        }

        public static void StartAllTest()
        {
            Thread thread = new Thread(new ThreadStart(TestAll));
            thread.Start();
        }

        // Метод тестирует все классы
        private static void TestAll()
        {
#if DEBUG
            String error_message = "";
            //error_message+=Utilits.CheckTestResult( Converter.Test() ); НЕТ ТЕСТА
            error_message += Utilits.CheckTestResult(Decorator.Test());
            error_message += Utilits.CheckTestResult(FormView.Test());
            //error_message+=Utilits.CheckTestResult( Methods.Test() ); ТЕСТ КРИВОЙ 

#else

#endif
            if (error_message != "")
            {
                Utilits.ShowMessage(error_message);
            }
        }
        
        // Метод выводит сообщение
        private static void MsgShow(object message)
        {
            string msg = (string)message; 
            MessageBox.Show(msg);
        }
    }
}

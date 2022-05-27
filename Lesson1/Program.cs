using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Lesson1
{
    internal static class Program
    {
        private static Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var rest = new Restaurant();
            while (true)
            {
                Console.WriteLine("Привет! Желаете забронировать столик?\n1 - мы уведомим Вас по смс (асинхронно)" +
                                  "\n2 - подождите на линии, мы Вас оповестим (синхроннно)"); //приглашаем ко вводу
                if (!int.TryParse(Console.ReadLine(), out var choice) && choice is not (1 or 2))
                {
                    Console.WriteLine("Введите, пожалуйста 1 или 2"); //всегда нужно защититься от невалидного ввода
                    continue;
                }
                
                var stopWatch = new Stopwatch();
                stopWatch.Start(); //замерим потраченное нами время на бронирование, ведь наше время - самое дорогое что у нас есть
                if (choice == 1)
                {
                    rest.BookFreeTableAsync(1); //забронируем с ответом по смс
                }
                else
                {
                    rest.BookFreeTable(1); //забронируем по звонку
                }

                Console.WriteLine("Спасибо за Ваше обращение!"); //клиента всегда нужно порадовать благодарностью
                stopWatch.Stop();
                var ts = stopWatch.Elapsed; 
                Console.WriteLine($"{ts.Seconds:00}:{ts.Milliseconds:00}"); //выведем потраченное нами время
            }
        }
    }
}
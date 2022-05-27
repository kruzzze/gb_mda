﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Restaraunt.Booking
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var rest = new Restaurant.Booking.Restaurant();
            while (true)
            {
                await Task.Delay(10000);
                
                //считаем что если уж позвонили, то столик забронировать хотим
                Console.WriteLine("Привет! Желаете забронировать столик?");
                
                var stopWatch = new Stopwatch();
                stopWatch.Start(); //замерим потраченное нами время на бронирование,
                                   //ведь наше время - самое дорогое что у нас есть

                rest.BookFreeTableAsync(1); //забронируем с ответом по смс

                Console.WriteLine("Спасибо за Ваше обращение!"); //клиента всегда нужно порадовать благодарностью
                stopWatch.Stop();
                var ts = stopWatch.Elapsed; 
                Console.WriteLine($"{ts.Seconds:00}:{ts.Milliseconds:00}"); //выведем потраченное нами время
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

namespace Lesson1
{
    public class Restaurant
    {
        private readonly List<Table> _tables = new ();

        public Restaurant()
        {
            for (ushort i = 1; i <= 10; i++)
            {
                _tables.Add(new Table(i));
            }
        }

        public void BookFreeTable(int countOfPersons)
        {
            Console.WriteLine("Добрый день! Подождите секунду я подберу столик и подтвержу вашу бронь, оставайтесь на линии");
            bool? success;
            Table table;
            do
            {
                table = _tables.FirstOrDefault(t => t.SeatsCount > countOfPersons
                                                    && t.State == State.Free);
                Thread.Sleep(1000 * 5); //у нас нерасторопные менеджеры, 5 секунд они находятся в поисках стола
                success = table?.SetState(State.Booked);
                    
            } while (success is null or false);
            
            Console.WriteLine(table is null 
                ? $"К сожалению, сейчас все столики заняты" 
                : $"Готово! Ваш столик номер {table.Id}");
        }
        
        public void BookFreeTableAsync(int countOfPersons)
        {
            Console.WriteLine("Добрый день! Подождите секунду я подберу столик и подтвержу вашу бронь, Вам придет уведомление");
            Task.Run(async () =>
            {
                bool? success;
                Table table;
                // do
                // {
                    table = _tables.FirstOrDefault(t => t.SeatsCount > countOfPersons
                                                        && t.State == State.Free);
                    Console.WriteLine(table.Id);
                    await Task.Delay(1000 * 2); //у нас нерасторопные менеджеры, 5 секунд они находятся в поисках стола
                    success = table?.SetState(State.Booked);
                    
               // } while (success is null or false);
                
                Console.WriteLine(table is null 
                    ? $"УВЕДОМЛЕНИЕ: К сожалению, сейчас все столики заняты" 
                    : $"УВЕДОМЛЕНИЕ: Готово! Ваш столик номер {table.Id}");
            });
        }
    }
}
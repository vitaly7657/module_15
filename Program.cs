using System;
using System.Threading;
using System.Threading.Tasks;

namespace module_15
{
    internal class Program
    {
        static void Method1()
        {
            var threadName = Thread.CurrentThread;
            threadName.Name = "Method1_Thread";
            Console.WriteLine($"Поток {threadName.Name} начат");
            for (int i= 0; i < 5; i++)
            {
                Console.WriteLine($"Метод: Method1 | Задержка: 1 сек. | Поток: {threadName.Name} | Итерация: {i+1}");
                Thread.Sleep(1000);                
            }
            Console.WriteLine($"Поток {threadName.Name} завершён");
        }

        static void Method2()
        {
            string taskName = "Method2_Task";
            Console.WriteLine($"Поток {taskName} начат");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Метод: Method2 | Задержка: 2 сек. | Поток: {taskName}   | Итерация: {i + 1}");
                Thread.Sleep(2000);
            }
            Console.WriteLine($"Поток {taskName} завершён");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("---Программа начата---");

            Thread thread = new Thread(Method1); //создание потока thread
            thread.Start(); //запуск потока thread

            Task task = new Task(Method2); //создание потока task
            
            task.Start(); //запуск потока task

            task.Wait(); //ожидание завершения потока task

            Console.WriteLine("---Программа завершена---");
            Console.ReadKey();
        }
    }
}

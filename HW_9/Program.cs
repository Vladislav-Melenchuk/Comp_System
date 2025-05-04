using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        List<int> numbers = new List<int> { 1, 125, 35, 28, 5, 54 };

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Просмотр");
            Console.WriteLine("2. Найти минимум");
            Console.WriteLine("3. Найти максимум");
            Console.WriteLine("4. Найти среднее значение");
            Console.WriteLine("5. Найти сумму");
            Console.WriteLine("6. Все операции");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите опцию: ");

            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Лист: " + string.Join(", ", numbers));
                    break;

                case "2":
                    int min = await Task.Run(() => numbers.Min());
                    Console.WriteLine($"Минимум: {min}");
                    break;

                case "3":
                    int max = await Task.Run(() => numbers.Max());
                    Console.WriteLine($"Максимум: {max}");
                    break;

                case "4":
                    double avg = await Task.Run(() => numbers.Average());
                    Console.WriteLine($"Среднее: {avg:F2}");
                    break;

                case "5":
                    int sum = await Task.Run(() => numbers.Sum());
                    Console.WriteLine($"Сумма: {sum}");
                    break;

                case "6":
                    var minTask = Task.Run(() => numbers.Min());
                    var maxTask = Task.Run(() => numbers.Max());
                    var avgTask = Task.Run(() => numbers.Average());
                    var sumTask = Task.Run(() => numbers.Sum());

                    await Task.WhenAll(minTask, maxTask, avgTask, sumTask);

                    Console.WriteLine($"Минимум: {minTask.Result}");
                    Console.WriteLine($"Максимум: {maxTask.Result}");
                    Console.WriteLine($"Среднее: {avgTask.Result:F2}");
                    Console.WriteLine($"Сумма: {sumTask.Result}");
                    break;


                case "0":
                    Console.WriteLine("Выход...");
                    return;

                default:
                    Console.WriteLine("Неверный ввод. Повторите попытку.");
                    break;
            }
        }
    }
}

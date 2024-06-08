using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyConsoleClient
{
    class ConsoleProgram
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            string baseUrl = "http://localhost:5056/api/calculator";
        
            Console.WriteLine("Введите первое число:");
            string inputA = Console.ReadLine()!;
            Console.WriteLine("Введите второе число:");
            string inputB = Console.ReadLine()!;

            int a, b;

            if (int.TryParse(inputA, out a) && int.TryParse(inputB, out b))
            {
                System.Console.WriteLine("Выберите действие: (+, -, *, /)");
                string operation = System.Console.ReadLine()!;
        
                string endpoint = operation switch
                {
                    "+" => $"{baseUrl}/add?a={a}&b={b}",
                    "-" => $"{baseUrl}/subtract?a={a}&b={b}",
                    "*" => $"{baseUrl}/multiply?a={a}&b={b}",
                    "/" => $"{baseUrl}/divide?a={a}&b={b}",
                    _ => throw new InvalidCastException("Invalid operation")
                };

                HttpResponseMessage response = await client.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                System.Console.WriteLine($"Результат: {result}");
            }
            else
            {
                Console.WriteLine("Ошибка: Введите корректные целые числа.");
            }
        }
    }
}


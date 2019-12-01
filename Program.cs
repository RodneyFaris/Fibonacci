using System;
using Microsoft.Extensions.DependencyInjection;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IFibonacciService, FibonacciService>()
                .BuildServiceProvider();

            var fib = serviceProvider.GetService<IFibonacciService>();
            
             Console.CancelKeyPress += new ConsoleCancelEventHandler((s, a) =>
            {
                Console.Clear();
                a.Cancel = false; 
                Environment.Exit(0);
            });
                
            do
            {
                Console.Write("Enter fibonacci sequence number: ");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int value))
                {
                    var seq = fib.Evaluate(value);
                    Console.WriteLine($"{input}th Fibonacci: {seq}");
                }
                else
                {
                    Console.WriteLine("Invalid number");
                }
            } while (true);

        }
    }
}

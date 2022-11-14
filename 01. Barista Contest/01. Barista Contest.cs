using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Barista_Contest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coffee = new Queue<int>(Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());

            Stack<int> milk = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());

            Dictionary<string, int> coffeeDrink= new Dictionary<string, int>
            {
                {"Cortado",50},
                {"Espresso",75},
                {"Capuccino",100},
                {"Americano",150},
                {"Latte",200 }

            };
            Dictionary<string, int> order = new Dictionary<string, int>
            {
                {"Cortado",0},
                {"Espresso",0},
                {"Capuccino",0},
                {"Americano",0},
                {"Latte",0 }
            };

            while(coffee.Count!=0 && milk.Count != 0)
            {
                int m = coffee.Peek();
                int n = milk.Peek();

                int sum = 0;
                sum = n + m;

                if (coffeeDrink.ContainsValue(sum))
                {
                    coffee.Dequeue();
                    milk.Pop();

                    if (sum == 50)
                    {
                        order["Cortado"]++;
                    }
                    else if (sum == 75)
                    {
                        order["Espresso"]++;
                    }
                    else if(sum == 100)
                    {
                        order["Capuccino"]++;

                    }
                    else if (sum == 150)
                    {
                        order["Americano"]++;

                    }
                    else if (sum == 200)
                    {
                        order["Latte"]++;
                    }


                }
                else
                {
                    coffee.Dequeue();
                    int number = milk.Peek()-5;
                    milk.Pop();
                    milk.Push(number);
                }

            }

            if(coffee.Count==0 && milk.Count==0) 
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
                Console.WriteLine("Coffee left: none");
                Console.WriteLine("Milk left: none");

                var orders = order.OrderBy(y => y.Value).OrderByDescending(x => x.Key)
                    .Where(y => y.Value > 0).ToDictionary(y => y.Key, y => y.Value);

                foreach (var item in orders.OrderBy(y=>y.Value))
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }

            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");

                if (coffee.Count == 0)
                {
                    Console.WriteLine("Coffee left: none");
                }
                else
                {
                    Console.WriteLine($"Coffee left: {String.Join(", ",coffee)}");
                }

                if (milk.Count == 0)
                {
                    Console.WriteLine("Milk left: none");
                }
                else
                {
                    Console.WriteLine($"Milk left: {String.Join(", ",milk)}");
                }

                var orders = order.OrderBy(y => y.Value).OrderByDescending(x => x.Key)
                    .Where(y => y.Value > 0).ToDictionary(y => y.Key, y => y.Value);

                foreach (var item in orders.OrderBy(y=>y.Value))
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
    }
}

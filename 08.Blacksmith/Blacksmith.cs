using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Blacksmith
{
    internal class Program
    {
        static void Main()
        {
            Queue<int> sword = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToList());
            Stack<int> quantity = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToList());
            int count = 0;

            Dictionary<string, int> elements = new Dictionary<string, int>
            {
                {"Gladius",70},
                {"Shamshir",80 },
                {"Katana",90 },
                {"Sabre",110 },
                {"Broadsword",150 }

            };

            SortedDictionary<string, int> items = new SortedDictionary<string, int>
            {
                 {"Gladius",0},
                {"Shamshir",0 },
                {"Katana",0 },
                {"Sabre",0 },
                {"Broadsword",0 }
            };

            while (quantity.Count != 0 && sword.Count != 0)
            {
                int steel = sword.Peek();
                int carbon = quantity.Peek();
                int sum = steel + carbon;

                if (elements.ContainsValue(sum))
                {
                    sword.Dequeue();
                    quantity.Pop();
                    if(sum == 70)
                    {
                        items["Gladius"]++;
                        count++;
                    }
                    else if(sum == 80)
                    {
                        items["Shamshir"]++;
                        count++;
                    }
                    else if(sum==90)
                    {
                        items["Katana"]++;
                        count++;
                    }
                    else if (sum == 110)
                    {
                        items["Sabre"]++;
                        count++;
                    }
                    else if (sum == 150)
                    {
                        items["Broadsword"]++;
                        count++;
                    }

                }
                else
                {
                    sword.Dequeue();
                    quantity.Pop();
                    int increase = carbon+ 5;
                    quantity.Push(increase);
                }


            }


            if (count >= 1)
            {
                Console.WriteLine($"You have forged {count} swords.");

            }
            else
            {
                Console.WriteLine($"You did not have enough resources to forge a sword.");

            }


            if (sword.Count == 0)
            {
                Console.WriteLine("Steel left: none");

            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ", sword)}");

            }
            if (quantity.Count == 0)
            {
                Console.WriteLine("Carbon left: none");

            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", quantity)}");

            }

            foreach (var item in items.Where(x => x.Value > 0))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}

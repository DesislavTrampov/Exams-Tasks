using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Barista_Contest
{
    public class Program
    {
        static void Main(string[] args)
        {

         Queue<int> guest = new Queue<int>(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList());

         Stack<int> plate = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList());

            
            int grams = 0;

            while ( guest.Count != 0 
                && plate.Count !=0 )
            {
                int difference = 0;
                int n = guest.Peek();
                int m = plate.Peek();
                difference = m - n;

                if (difference < 0)
                {
                    int firstItem = plate.Pop();
                    int secondItem = plate.Pop() + firstItem;
                    plate.Push(secondItem);
                }

                if (difference >= 0) 
                {
                    guest.Dequeue();
                    plate.Pop();
                    grams += difference;
                }
            }

            if (guest.Count == 0)
            {
                Console.WriteLine($"Plates: {String.Join(" ",plate)}");
                Console.WriteLine($"Wasted grams of food: {grams}");
            }

            if (plate.Count == 0)
            {
                Console.WriteLine($"Guests: {String.Join(" ",guest)}");
                Console.WriteLine($"Wasted grams of food: {grams}");
            }
        }
    }
}

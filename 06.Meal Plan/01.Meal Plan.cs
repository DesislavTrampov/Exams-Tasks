using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Globalization;

namespace _Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {
         Queue<string> meal = new Queue<string>(Console.ReadLine().Split(" ").ToList());
         Stack<int> calories = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToList());
         
            int count = 0;


            while ( calories.Count > 0 && meal.Count>0) 
            {
                string currentmeal = meal.Peek();
                int currentcalories = calories.Peek();

                if ( currentmeal== "salad")
                {
                    int sum = currentcalories - 350;
                    meal.Dequeue();
                    calories.Pop();
                    calories.Push(sum);
                    count++;
                    if ( sum <= 0 )
                    {
                        calories.Pop();

                        if (calories.Count > 0)
                        {
                            int nextorder = calories.Peek();
                            nextorder += sum;
                            calories.Pop();
                            calories.Push(nextorder);
                        }
                       
                    }

                }
                else if( currentmeal== "soup")
                {
                    int sum = currentcalories - 490;
                    meal.Dequeue();
                    calories.Pop();
                    calories.Push(sum);
                    count++;
                    if (sum <= 0)
                    {
                        calories.Pop();
                        if (calories.Count > 0)
                        {
                            int nextorder = calories.Peek();
                            nextorder += sum;
                            calories.Pop();
                            calories.Push(nextorder);

                        }
                        
                    }

                }
                else if(currentmeal== "pasta")
                {
                    int sum = currentcalories - 680;
                    meal.Dequeue();
                    calories.Pop();
                    calories.Push(sum);
                    count++;
                    if (sum <= 0)
                    {
                        calories.Pop();

                        if ( calories.Count > 0)
                        {
                            int nextorder = calories.Peek();
                            nextorder += sum;
                            calories.Pop();
                            calories.Push(nextorder);
                        }
                        
                    }

                }
                else if ( currentmeal== "steak")
                {
                    int sum = currentcalories - 790;
                    meal.Dequeue();
                    calories.Pop();
                    calories.Push(sum);
                    count++;
                    if (sum <= 0)
                    {
                        calories.Pop();
                        if ( calories.Count > 0 )
                        {
                            int nextorder = calories.Peek();
                            nextorder += sum;
                            calories.Pop();
                            calories.Push(nextorder);
                        }
                       
                    }

                }


            }

            if (meal.Count == 0)
            {
                Console.WriteLine($"John had {count} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ",calories)} calories.");
            }

            if (meal.Count > 0)
            {
                Console.WriteLine($"John ate enough, he had {count} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ",meal)}.");
            }




        }
    }
}
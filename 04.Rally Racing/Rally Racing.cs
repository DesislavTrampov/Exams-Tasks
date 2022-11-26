using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Drawing;

namespace _2_Rally_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            string carNumber = Console.ReadLine().Trim();
            int currentrow = 0;
            int currentcol = 0;
            List<int> tunel  = new List<int>();
            int km = 0;
            bool isvalid = false;

            for (int row = 0; row < n; row++)
            {
                string cmd = Console.ReadLine().Replace(" ","").ToString();
                for(int col = 0; col < n; col++)
                {
                    matrix[row, col] = cmd[col];

                    if (matrix[row,col] == 'T')
                    {
                        tunel.Add(row);
                        tunel.Add(col);
                    }

                    if (matrix[row,col] == 0)
                    {
                        currentcol=col;
                        currentrow = row;
                    }
                   
                }
            }
            string command = Console.ReadLine();
             while (command != "End")
            {
                

                if (command == "right")
                {
                    
                    if (isvalid)
                    {
                        command= Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        currentcol++;
                        if (matrix[currentrow, currentcol] == '.')
                        {
                            km += 10;
                        }
                        

                    }

                }
                else if (command == "left")
                {
                    if (isvalid)
                    {
                        command = Console.ReadLine();
                        continue;
                        
                    }
                    else
                    {
                        currentcol--;
                        if (matrix[currentrow, currentcol] == '.')
                        {
                            km += 10;
                        }

                    }
                }
                else if (command== "up")
                {
                    if (isvalid)
                    {
                        
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        currentrow--;
                        if (matrix[currentrow, currentcol] == '.')
                        {
                            km += 10;
                        }

                    }
                }
                else if (command== "down")
                {
                    if (isvalid)
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        currentrow++;
                        if (matrix[currentrow, currentcol] == '.')
                        {
                            km += 10;
                        }

                    }
                }
                if (matrix[currentrow, currentcol] == 'T')
                {
                    matrix[currentrow, currentcol] = '.';

                    km += 30;
                    currentrow = tunel[2];
                    currentcol = tunel[3];

                    matrix[currentrow, currentcol] = '.';


                }

                if (matrix[currentrow, currentcol] == 'F')
                {
                    matrix[currentrow, currentcol] = 'C';
                    isvalid = true;
                    km += 10;
                    break;
                }

                



                command = Console.ReadLine();
            }

             if (command == "End")
            {
                matrix[currentrow, currentcol] = 'C';
                Console.WriteLine($"Racing car {string.Format("{0:00}",carNumber)} DNF.");
                Console.WriteLine($"Distance covered {km} km.");
            }
            else
            {
                Console.WriteLine($"Racing car {carNumber} finished the stage!");
                Console.WriteLine($"Distance covered {km} km.");
            }

            
            for (int row = 0; row < n; row++)
            {
                for(int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }

        }
    }
}
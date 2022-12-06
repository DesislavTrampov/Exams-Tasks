using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Drawing;

namespace _Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int blackT = 0;
            int whiteT = 0;
            int summerT = 0;
            int eaten = 0;
            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine().Replace(" ",String.Empty);

                for(int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }


            string cmd = Console.ReadLine();
            while(cmd != "Stop the hunt") 
            {
                string[] token = cmd.Split(' ');
                string command = token[0];
                int row = int.Parse(token[1]);
                int col = int.Parse(token[2]);

                if (command == "Collect")
                {

                    if (isvalid(row, col, matrix))
                    {
                        char position = matrix[row, col];

                        matrix[row, col] = '-';

                        if (position == 'B')
                        {
                            blackT++;
                        }
                        else if (position == 'S')
                        {
                            summerT++;
                        }
                        else if (position == 'W')
                        {
                            whiteT++;
                        }
                    }

                }

                if(command == "Wild_Boar")
                {
                    string input = token[3];
                    switch(input)
                    {
                        case
                            "up":
                            {
                                while (isvalid(row, col, matrix))
                                {
                                    char curentpositions = matrix[row, col];
                                    if (curentpositions == 'W'|| curentpositions == 'B' || curentpositions == 'S')
                                    {
                                        matrix[row, col] = '-';
                                        eaten++;
                                    }
                                    row -= 2;
                                }
                            }
                            break;
                        case "down":
                            {
                                while (isvalid(row, col, matrix))
                                {
                                    char curentpositions = matrix[row, col];
                                    if (curentpositions == 'W' || curentpositions == 'B' || curentpositions == 'S')
                                    {
                                        matrix[row, col] = '-';
                                        eaten++;
                                    }
                                    row += 2;
                                }

                            }
                            break;
                        case "right":
                            {
                                while (isvalid(row, col, matrix))
                                {
                                    char curentpositions = matrix[row, col];
                                    if (curentpositions == 'W' || curentpositions == 'B' || curentpositions == 'S')
                                    {
                                        matrix[row, col] = '-';
                                        eaten++;
                                    }
                                    col += 2;
                                }

                            }
                            break;
                        case "left":
                            {
                                while (isvalid(row, col, matrix))
                                {
                                    char curentpositions = matrix[row, col];
                                    if (curentpositions == 'W' || curentpositions == 'B' || curentpositions == 'S')
                                    {
                                        matrix[row, col] = '-';
                                        eaten++;
                                    }
                                    col -= 2;
                                }

                            }
                            break;
                    }

                }

                cmd = Console.ReadLine();
            }

            Console.WriteLine($"Peter manages to harvest {blackT} black, {summerT} summer, and {whiteT} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eaten} truffles.");




            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col]+" ");
                }
                Console.WriteLine();
            }


        }
        public static bool isvalid(int row,int col, char[,] matrix)
        {
            if (row>=0 && row<matrix.GetLength(0) && col>=0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Super_Mario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int livesMario = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rows][];
            int currentRow = 0;
            int currentCol = 0;
            int enemyRow = 0;
            int enemyCol = 0;
            bool isMarioDeath = false;
            bool isMarioSavedPrincess = false;
            char[] chars = null;
            for (int i = 0; i < rows; i++)
            {
                chars = Console.ReadLine().ToCharArray();

                matrix[i] = chars;
            }

            for (int row = 0; row < rows; row++)
            {

                for (int col = 0; col < matrix[row].Length; col++)
                {

                    if (matrix[row][col] == 'M')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            string command = Console.ReadLine();
            while (true)
            {
                
                List<string> commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();
                string direction = commands[0];
                enemyRow = int.Parse(commands[1]);
                enemyCol = int.Parse(commands[2]);
                matrix[enemyRow][enemyCol] = 'B';
                if (direction == "W")
                {
                    if (currentRow - 1 >= 0)
                    {
                        matrix[currentRow][currentCol] = '-';
                        currentRow--;
                    }

                }
                if (direction == "S")
                {
                    if (currentRow + 1 < rows)
                    {
                        matrix[currentRow][currentCol] = '-';
                        currentRow++;
                    }
                }
                if (direction == "A")
                {
                    if (currentCol - 1 >= 0)
                    {
                        matrix[currentRow][currentCol] = '-';
                        currentCol--;
                    }
                }
                if (direction == "D")
                {
                    if (currentCol + 1 < matrix[currentRow].Length)
                    {
                        matrix[currentRow][currentCol] = '-';
                        currentCol++;
                    }
                }
                livesMario--;
                if (matrix[currentRow][currentCol] == 'P')
                {
                    matrix[currentRow][currentCol] = '-';
                    isMarioSavedPrincess = true;
                    break;
                }
                if (livesMario <= 0)
                {
                   
                    matrix[currentRow][currentCol] = 'X';
                    isMarioDeath = true;
                    break;
                }
                if (matrix[currentRow][currentCol] == 'B')
                {
                    livesMario -= 2;
                    if (livesMario <= 0)
                    {
                        isMarioDeath = true;
                        matrix[currentRow][currentCol] = 'X';
                        break;
                    }

                    command = Console.ReadLine();
                    continue;
                }



                command = Console.ReadLine();
            }
            if (isMarioDeath)
            {
                Console.WriteLine($"Mario died at {currentRow};{currentCol}.");
            }
            if (isMarioSavedPrincess)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {livesMario}");
            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < chars.Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}
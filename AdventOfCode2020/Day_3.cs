using System;

namespace AdventOfCode2020
{
    class Day_3 // https://adventofcode.com/2020/day/3
    {
        public string[] GetStringInput()
        {
            return System.IO.File.ReadAllLines(@"Input\Day 3\input.txt");
        }

        public int CheckCollision(int incY, int incX)
        {
            int trees = 0, cell = 0;
            string[] input = GetStringInput();

            for(int row = 0; row < input.Length; row += incX)
            {
                if (input[row][cell] == '#')
                    trees++;
                cell = (cell + incY) % 31;
            }
            return trees;
        }

        public void RunPart1()
        {
            Console.WriteLine($"Part 1: {CheckCollision(3,1)}");
        }

        public void RunPart2()
        {
            double trees = CheckCollision(1,1);
            trees *= CheckCollision(3,1);
            trees *= CheckCollision(5,1);
            trees *= CheckCollision(7,1);
            trees *= CheckCollision(1, 2);
            Console.WriteLine($"Part 2: {trees}");
        }
    }
}

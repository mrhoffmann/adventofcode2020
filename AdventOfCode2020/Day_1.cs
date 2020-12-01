﻿using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class Day_1 //https://adventofcode.com/2020/day/1
    {
        /// <summary>
        /// Get string input from file
        /// </summary>
        public string[] GetStringInput()
        {
            return System.IO.File.ReadAllLines(@"Input\Day 1\input.txt");
        }

        /// <summary>
        /// Return input as an int
        /// </summary>
        public List<int> GetIntInput()
        {
            List<int> retval = new List<int>();
            foreach(string s in GetStringInput())
            {
                retval.Add(int.Parse(s));
            }
            return retval;
        }

        /// <summary>
        /// Run the script for part 1
        /// </summary>
        public void RunPart1()
        {
            List<int> input = GetIntInput();

            int[] options = new int[2];
            foreach(int i in input)
                foreach(int j in input)
                    if(i + j == 2020)
                    {
                        options[0] = i;
                        options[1] = j;
                    }

            Console.WriteLine($"{options[0]} + {options[1]} = 2020\n{options[0]} * {options[1]} = {options[0] * options[1]}");
            Console.ReadKey();
        }

        /// <summary>
        /// Run the script for part 2
        /// </summary>
        public void RunPart2()
        {
            List<int> input = GetIntInput();

            int[] options = new int[3];
            foreach (int i in input)
                foreach (int j in input)
                    foreach (int k in input)
                        if (i + j + k == 2020 && i != j && i != k && j != i && j != k && k != i && k != j)
                        {
                            options[0] = i;
                            options[1] = j;
                            options[2] = k;
                        }
                    

            Console.WriteLine($"{options[0]} + {options[1]} + {options[2]} = 2020\n{options[0]} * {options[1]} * {options[2]} = {options[0] * options[1] * options[2]}");
            Console.ReadKey();
        }
    }
}
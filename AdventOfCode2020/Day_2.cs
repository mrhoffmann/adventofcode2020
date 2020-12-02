using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AdventOfCode2020
{
    class Day_2
    {
        public string[] GetStringInput()
        {
            return System.IO.File.ReadAllLines(@"Input\Day 2\input.txt");
        }

        public int[] GetRange(string row)
        {
            string retval = row.Substring(0, row.IndexOf(" "));
            return new int[2] { int.Parse(retval.Split("-")[0]), int.Parse(retval.Split("-")[1]) };
        }

        public char GetChar(string row)
        {
            return row.Substring(row.IndexOf(" ")+1, 1)[0];
        }

        public string GetPassword(string row)
        {
            return row.Substring(row.IndexOf(":") + 2, row.Length - (row.IndexOf(":") + 2));
        }

        public void RunPart1()
        {
            int     ValidPasswords  = 0;
            foreach(string row in GetStringInput())
            {
                int[]   range       = GetRange(row);
                char    needle      = GetChar(row);
                string  haystack    = GetPassword(row);

                int     counter     = 0;
                foreach (char c in haystack)
                {
                    if(c == needle)
                    {
                        counter++;
                    }
                }

                if(counter >= range[0] && counter <= range[1])
                {
                    ValidPasswords++;
                }
            }
            Console.WriteLine(ValidPasswords);
        }

        public void RunPart2()
        {
            int     ValidPasswords  = 0;
            foreach (string row in GetStringInput())
            {
                int[]   range       = GetRange(row);
                        range[0]    = range[0] - 1;
                        range[1]    = range[1] - 1;
                char    needle      = GetChar(row);
                string  haystack    = GetPassword(row);

                if (haystack[range[0]] == needle && haystack[range[0]] != haystack[range[1]] || haystack[range[1]] == needle && haystack[range[0]] != haystack[range[1]])
                {
                    ValidPasswords++;
                }
            }
            Console.WriteLine(ValidPasswords);
        }
    }
}

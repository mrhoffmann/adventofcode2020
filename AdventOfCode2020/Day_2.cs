using System;

namespace AdventOfCode2020
{
    class Day_2 : Recurring // https://adventofcode.com/2020/day/2
    {
        private readonly string[] input = GetInput(2);

        public int[] GetRange(string row)
        {
            return new int[2] { int.Parse(row.Substring(0, row.IndexOf(" ")).Split("-")[0]), int.Parse(row.Substring(0, row.IndexOf(" ")).Split("-")[1]) };
        }

        public char GetChar(string row)
        {
            return row.Substring(row.IndexOf(" ") + 1, 1)[0];
        }

        public string GetPassword(string row)
        {
            return row.Substring(row.IndexOf(":") + 2, row.Length - (row.IndexOf(":") + 2));
        }

        public override void RunPartA()
        {
            int     ValidPasswords  = 0;
            foreach(string row in input)
            {
                int[]   range       = GetRange(row);
                char    needle      = GetChar(row);
                string  haystack    = GetPassword(row);

                int     counter     = 0;
                foreach (char c in haystack)
                    if(c == needle)
                        counter++;

                if (counter >= range[0] && counter <= range[1])
                    ValidPasswords++;
            }
            Console.WriteLine(ValidPasswords);
        }

        public override void RunPartB()
        {
            int     ValidPasswords  = 0;
            foreach (string row in input)
            {
                int[]   range       = GetRange(row);
                        range[0]    = range[0] - 1;
                        range[1]    = range[1] - 1;
                char    needle      = GetChar(row);
                string  haystack    = GetPassword(row);

                if (haystack[range[0]] == needle && haystack[range[0]] != haystack[range[1]] || haystack[range[1]] == needle && haystack[range[0]] != haystack[range[1]])
                    ValidPasswords++;
            }
            Console.WriteLine(ValidPasswords);
        }
    }
}

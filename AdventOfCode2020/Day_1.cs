using System.Collections.Generic;

namespace AdventOfCode2020
{
    class Day_1 : Recurring // https://adventofcode.com/2020/day/1
    {
        private readonly string[] input = GetInput(1);

        private List<int> GetIntInput()
        {
            List<int> retval = new List<int>();
            foreach(string s in input)
                retval.Add(int.Parse(s));
            return retval;
        }

        public override string RunPartA()
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

            return $"{options[0]} + {options[1]} = 2020\n{options[0]} * {options[1]} = {options[0] * options[1]}";
        }

        public override string RunPartB()
        {
            List<int> input = GetIntInput();

            int[] options = new int[3];
            foreach (int i in input)
                foreach (int n in input)
                    foreach (int t in input)
                        if (i + n + t == 2020 && i != n && i != t && n != i && n != t && t != i && t != n)
                        {
                            options[0] = i;
                            options[1] = n;
                            options[2] = t;
                        }

            return $"{options[0]} + {options[1]} + {options[2]} = 2020\n{options[0]} * {options[1]} * {options[2]} = {options[0] * options[1] * options[2]}";
        }
    }
}

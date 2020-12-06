using System.Collections.Generic;

namespace AdventOfCode2020
{
    class Day_6 : Recurring // https://adventofcode.com/2020/day/6
    {
        private readonly string[] input = GetInput(6);

        private List<string> Divide()
        {
            int currIndex = 0;
            List<string> retval = new List<string>()
            {
                ""
            };
            foreach (string s in input)
            {
                if (string.IsNullOrWhiteSpace(s) || string.IsNullOrEmpty(s))
                {
                    currIndex++;
                    retval.Add("");
                }
                else
                    retval[currIndex] += $"{s},";
            }
            return retval;
        }

        public override string RunPartA()
        {
            int retval = 0;
            foreach (string s in Divide())
            {
                string added = "";
                foreach (string t in s.Split(","))
                    foreach (char c in t)
                        if (!added.Contains(c))
                        {
                            retval++;
                            added += $",{c}";
                        }
            }
            return retval.ToString();
        }

        public override string RunPartB()
        {
            int retval = 0;
            foreach(string s in Divide())
            {
                int length = s.Split(",").Length - 1;
                Dictionary<char, int> occurrences = new Dictionary<char, int>();
                foreach (char c in s)
                    if (c != ',') {
                        if (occurrences.ContainsKey(c))
                            occurrences[c]++;
                        else
                            occurrences.Add(c, 1);
                    }
                foreach (char k in occurrences.Keys)
                    retval += occurrences[k] == length ? 1 : 0;
            }
            return retval.ToString();
        }
    }
}

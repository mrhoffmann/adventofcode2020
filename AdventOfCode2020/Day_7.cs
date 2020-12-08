using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    class Day_7 : Recurring // https://adventofcode.com/2020/day/7
    {
        private readonly static Regex regex1 = new Regex(@"(\w.+?)(\s)?bag(s?)(\s)?(contain)?");
        private readonly static string[][] input = GetInput(7).Select(x => regex1.Matches(x)).Select(x => x.OfType<Match>().Select(y => y.Groups[1].Value).ToArray()).ToArray();

        public override string RunPartA()
        {
            var part1 = solve("shiny gold").ToArray().Distinct().Count();

            IEnumerable<string> solve(string needle)
            {
                foreach (string s in input.Where(x => x.Skip(1).Any(y => y.EndsWith(needle))).Select(x => x.First()))
                {
                    yield return s;
                    foreach (var c in solve(s))
                        yield return c;
                }
            }

            return part1.ToString();
        }

        public override string RunPartB()
        {
            var part2 = solve("shiny gold").ToArray().Count() - 1;

            IEnumerable<string[]> solve(string needle)
            {
                foreach (string[] s in input.Where(x => x.First() == needle))
                {
                    yield return s;
                    foreach (string t in s.Skip(1))
                    {
                        var m = new Regex(@"(\d+)\s?(.+)").Match(t);
                        if (m.Success)
                            for (int i = 0; i < int.Parse(m.Groups[1].Value); i++)
                                foreach (var d in solve(m.Groups[2].Value))
                                    yield return d;
                    }
                }
            }

            return part2.ToString();
        }
    }
}

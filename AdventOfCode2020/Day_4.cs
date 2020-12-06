using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    class Day_4 : Recurring // https://adventofcode.com/2020/day/4
    {
        private readonly string[] mustContain = new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};
        private readonly string[] input = GetInput(4);

        private List<string> RebuildInput(string[] input)
        {
            int currentIndex = 0;
            List<string> passports = new List<string>
            {
                ""
            };
            for (int i = 0; i < input.Length; i++)
                if (string.IsNullOrEmpty(input[i]))
                {
                    currentIndex++;
                    passports.Add("");
                }
                else
                    passports[currentIndex] += input[i] + " ";

            return passports;
        }

        private bool Validate(string key, string value)
        {
            bool retval = false;
            
            if (key == "byr")
            {

                if (value.Length == 4)
                {
                    if (int.TryParse(value, out int temp))
                    {
                        if (temp >= 1920 && temp <= 2002)
                        {
                            retval = true;
                        }
                    }
                }
            }
            else if (key == "iyr")
            {
                if (value.Length == 4)
                {
                    if (int.TryParse(value, out int temp))
                    {
                        if (temp >= 2010 && temp <= 2020)
                        {
                            retval = true;
                        }
                    }
                }
            }
            else if (key == "eyr")
            {
                if (value.Length == 4)
                {
                    if (int.TryParse(value, out int temp))
                    {
                        if (temp >= 2020 && temp <= 2030)
                        {
                            retval = true;
                        }
                    }
                }
            }
            else if (key == "hgt")
            {
                if (value.EndsWith("cm") || value.EndsWith("in"))
                {
                    int temp = int.Parse(value.Substring(0, value.Length - 2));
                    if (value.EndsWith("cm"))
                        retval = temp >= 150 && temp <= 193;
                    else
                        retval = temp >= 59 && temp <= 76;
                }
            }
            else if (key == "hcl")
            {
                retval = new System.Text.RegularExpressions.Regex("^#(?:[0-9a-fA-F]{3}){1,2}$").Match(value).Success;
            }
            else if (key == "ecl")
            {
                retval = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Any(value.Contains);
            }
            else if (key == "pid")
            {
                retval = new System.Text.RegularExpressions.Regex("^[0-9]{9}$").Match(value).Success;
            }
            return retval;
        }

        public override string RunPartA()
        {
            int validPassports = 0;
            foreach (string s in RebuildInput(input))
            {
                bool valid = true;
                foreach (string t in mustContain)
                    if (!s.Contains(t))
                        valid = false;

                validPassports += valid ? 1 : 0;
            }
            return validPassports.ToString();
        }

        public override string RunPartB()
        {
            int validPassports = 0;
            foreach (string s in RebuildInput(input))
            {
                bool valid = true;
                foreach (string r in mustContain)
                    if (!s.Contains(r)) valid = false;

                if (valid)
                {
                    string[] values = s.Split(" ");
                    foreach (string t in values)
                    {
                        if (!string.IsNullOrEmpty(t))
                        {
                            string key = t.Split(":")[0];
                            string value = t.Split(":")[1];
                            if (key != "cid")
                            {
                                valid = Validate(key, value);
                                if (valid == false) break;
                            }
                        }
                    }
                }

                validPassports += valid ? 1 : 0;
            }
            return validPassports.ToString();
        }
    }
}

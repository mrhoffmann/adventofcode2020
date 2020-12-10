using System.Collections.Generic;

namespace AdventOfCode2020
{
    class Day_8 : Recurring // https://adventofcode.com/2020/day/8
    {
        private readonly string[] _input = GetInput(8);

        public override string RunPartA()
        {
            return Routine(_input)[1].ToString();
        }

        private string[] Routine(string[] param0)
        {
            int accumulator = 0;
            string[] retval = new string[2];
            List<int> ran = new List<int>();
            int action = 0; bool run = true;

            while (run)
            {
                ran.Add(action);
                string s        = param0[action];
                string[] words  = s.Split(" ");
                int value       = int.Parse(words[1]);
                action          += words[0] == "jmp" ? value : 1;
                accumulator     += words[0] == "acc" ? value : 0;

                if ( ran.Contains( action ) )
                {
                    run = false;
                    retval = new string[] { "1", accumulator.ToString() };
                }
                else if(action >= param0.Length)
                {
                    run = false;
                    retval = new string[] { "0", accumulator.ToString() };
                }
            }

            return retval;
        }

        public override string RunPartB()
        {
            int i = 0, length = _input.Length;
            bool run = true;
            string old = "";
            string[] retval;
            do
            {
                if (i != 0) _input[i - 1] = old;
                bool found = false;

                while (!found && i < length)
                {
                    string[] words = _input[i].Split(" ");
                    if (words[0] == "nop")
                    {
                        found = true;
                        old = _input[i];
                        _input[i] = old.Replace("nop", "jmp");
                    }
                    else if (words[0] == "jmp")
                    {
                        found = true;
                        old = _input[i];
                        _input[i] = old.Replace("jmp", "nop");
                    }
                    else
                        i++;
                }

                retval = Routine(_input);
                if (retval[0] != "1")
                    run = false;
                else
                    _input[i] = old;
                i++;
            } while (run && i < length);
            return retval[1];
        }
    }
}

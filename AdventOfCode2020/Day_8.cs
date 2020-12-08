using System.Collections.Generic;

namespace AdventOfCode2020
{
    class Day_8 : Recurring // https://adventofcode.com/2020/day/8
    {
        private readonly string[] input = GetInput(8);

        public override string RunPartA()
        {
            return Routine(input).Accumulator.ToString();
        }

        private ProgramCodeResult Routine(string[] param0)
        {
            int accumulator = 0;
            ProgramCodeResult retval = new ProgramCodeResult();
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
                    retval = new ProgramCodeResult() { Infinite = true, Accumulator = accumulator };
                }
                else if(action >= param0.Length)
                {
                    run = false;
                    retval = new ProgramCodeResult() { Infinite = false, Accumulator = accumulator };
                }
            }

            return retval;
        }

        private ProgramCodeResult IsInfinite()
        {
            int i = 0, length = input.Length;
            bool run = true;
            string old = "";
            ProgramCodeResult retval;
            do
            {
                if (i != 0) input[i - 1] = old;
                bool found = false;

                while (!found && i < length)
                {
                    string[] words  = input[i].Split(" ");
                    if (words[0]    == "nop")
                    {
                        found       = true;
                        old         = input[i];
                        input[i]    = old.Replace("nop", "jmp");
                    }
                    else if (words[0] == "jmp")
                    {
                        found       = true;
                        old         = input[i];
                        input[i]    = old.Replace("jmp", "nop");
                    }
                    else
                        i++;
                }

                retval = Routine(input);
                if (!retval.Infinite)
                    run = false;
                else
                    input[i] = old;
                i++;
            } while (run && i < length);
            return retval;
        }

        public override string RunPartB()
        {
            return IsInfinite().Accumulator.ToString();
        }
    }

    class ProgramCodeResult
    {
        public bool Infinite = false;
        public int Accumulator = 0;
    }
}

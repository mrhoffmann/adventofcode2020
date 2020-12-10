using System;
using System.Linq;

namespace AdventOfCode2020
{
    class Day_9 : Recurring // https://adventofcode.com/2020/day/9
    {
        private readonly double[] _input = Array.ConvertAll(GetInput(9), double.Parse);

        public override string RunPartA()
        {
            int stepper = 25; double retval = -1;
            for ( int i = stepper; i < _input.Length; i++ )
            {
                bool breakOp = true;
                double[] prev = _input.Skip(i - stepper).Take(i).ToArray();
                for (int j = 0; j < prev.Length; j++)
                    for (int k = 0; k < prev.Length; k++)
                        if(prev[j] != prev[k])
                            if (prev[j] + prev[k] == _input[i])
                                breakOp = false;
                if (breakOp)
                    retval = _input[i];
            }
            return retval.ToString();
        }

        public override string RunPartB()
        {
            double weakness = double.Parse(RunPartA());
            string answer = "";
            for (int i = 0; i < _input.Length; i++)
            {
                double sum = _input[i], minVal = _input[i], maxVal = _input[i];
                for (int j = i + 1; j < _input.Length; j++)
                {
                    sum += _input[j];
                    minVal = minVal > _input[j] ? _input[j] : minVal;
                    maxVal = maxVal > _input[j] ? maxVal : _input[j];

                    if (sum == weakness) answer = $"{minVal} {maxVal} = {minVal+maxVal}";
                    if (answer.Length > 0) break;
                }
                if (answer.Length > 0) break;
            }

            return answer;
        }
    }
}

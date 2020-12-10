using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class Day_5 : Recurring // https://adventofcode.com/2020/day/5
    {
        private readonly string[] _input = GetInput(5);
        private readonly List<int> _seatIds = new List<int>();

        public override string RunPartA()
        {
            int partA = 0;
            foreach (string s in _input)
            {
                int row = 0, column = 0;
                for (int i = 0; i < 7; i++) row += s[i] == 'B' ? (int)Math.Pow(2, 6 - i) : 0;
                for (int i = 7; i < 10; i++) column += s[i] == 'R' ? (int)Math.Pow(2, 9 - i) : 0;

                int seatId = row * 8 + column;
                partA = partA > seatId ? partA : seatId;
                _seatIds.Add(seatId);
            }
            _seatIds.Sort();
            return partA.ToString();
        }

        public override string RunPartB()
        {
            int lId = -1, partB = -1;
            for (int i = 0; i < _seatIds.Count; i++)
            {
                if (lId != -1 && _seatIds[i] - lId == 2)
                    partB = _seatIds[i] - 1;
                lId = _seatIds[i];
            }
            return partB.ToString();
        }
    }
}

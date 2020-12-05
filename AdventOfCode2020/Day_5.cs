using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class Day_5 : Recurring
    {
        private readonly string[] input = GetInput(5);
        private List<int> seatIds = new List<int>();

        public override void RunPartA()
        {
            int partA = 0;
            foreach (string s in input)
            {
                int row = 0, column = 0;
                for (int i = 0; i < 7; i++) row += s[i] == 'B' ? (int)Math.Pow(2, 6 - i) : 0;
                for (int i = 7; i < 10; i++) column += s[i] == 'R' ? (int)Math.Pow(2, 9 - i) : 0;

                int seatId = row * 8 + column;
                partA = partA > seatId ? partA : seatId;
                seatIds.Add(seatId);
            }
            seatIds.Sort();
            Console.WriteLine(partA);
        }

        public override void RunPartB()
        {
            int lId = -1;
            for (int i = 0; i < seatIds.Count; i++)
            {
                if (lId != -1 && seatIds[i] - lId == 2)
                    Console.WriteLine(seatIds[i] - 1);
                lId = seatIds[i];
            }
        }
    }
}

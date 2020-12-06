namespace AdventOfCode2020
{
    class Day_3 : Recurring // https://adventofcode.com/2020/day/3
    {
        private readonly string[] input = GetInput(3);

        private int CheckCollision(int incY, int incX)
        {
            int trees = 0, cell = 0;
            for(int row = 0; row < input.Length; row += incX)
            {
                if (input[row][cell] == '#')
                    trees++;
                cell = (cell + incY) % 31;
            }
            return trees;
        }

        public override string RunPartA()
        {
            return CheckCollision(3, 1).ToString();
        }

        public override string RunPartB()
        {
            double trees = CheckCollision(1,1);
            trees       *= CheckCollision(3,1);
            trees       *= CheckCollision(5,1);
            trees       *= CheckCollision(7,1);
            trees       *= CheckCollision(1, 2);
            return trees.ToString();
        }
    }
}

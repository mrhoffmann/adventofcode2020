using System;

namespace AdventOfCode2020
{
    abstract class Recurring
    {
        /// <summary>
        /// Run the whole day, part a and b.
        /// </summary>
        public virtual void Run()
        {
            RunPartA();
            RunPartB();
            Console.ReadKey();
        }

        public static string[] GetInput( int day )
        {
            return System.IO.File.ReadAllLines($@"Input\Day {day}\input.txt");
        }

        /// <summary>
        /// Run part A of the day, in some cases must be ran first.
        /// <para>Please only execute Run.</para>
        /// </summary>
        public abstract void RunPartA();

        /// <summary>
        /// Run part B of the day.
        /// <para>Please only execute Run.</para>
        /// </summary>
        public abstract void RunPartB();
    }
}

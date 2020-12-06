using System;

namespace AdventOfCode2020
{
    /// <summary>
    /// Made to replace the need for recurring code in each class.
    /// </summary>
    abstract class Recurring
    {
        /// <summary>
        /// Run the whole day, part a and b.
        /// </summary>
        public virtual void Run()
        {
            Console.WriteLine(RunPartA());
            Console.WriteLine(RunPartB());
            Console.ReadKey();
        }

        /// <summary>
        /// Retriew the input for the given day.
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public static string[] GetInput( int day )
        {
            return System.IO.File.ReadAllLines($@"Input\Day {day}\input.txt");
        }

        /// <summary>
        /// Run part A of the day, in some cases must be ran first.
        /// <para>Please only execute Run.</para>
        /// </summary>
        public abstract string RunPartA();

        /// <summary>
        /// Run part B of the day.
        /// <para>Please only execute Run.</para>
        /// </summary>
        public abstract string RunPartB();
    }
}

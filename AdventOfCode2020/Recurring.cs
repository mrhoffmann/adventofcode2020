using System;
using System.Linq;
using System.Net;

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
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine($"Part A: {RunPartA()} - {watch.ElapsedMilliseconds}ms");
            watch.Stop();
            watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine($"Part B: {RunPartB()} - {watch.ElapsedMilliseconds}ms");
            watch.Stop();
            Console.ReadKey();
        }

        public static string[] GetInput(int day)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var wcl = new WebClient();
            wcl.Headers.Add($"Cookie: session=");
            string[] retval = wcl.DownloadString($"https://adventofcode.com/2020/day/{day}/input").Split("\n").Where(x => x.Length > 0).ToArray();
            Console.WriteLine($"Get input: {watch.ElapsedMilliseconds}ms");
            return retval;
        }

        /// <summary>
        /// Run part A of the day, in some cases must be ran first.
        /// <para>Please only execute Run.</para>
        /// </summary>
        public virtual string RunPartA()
        {
            return "";
        }

        /// <summary>
        /// Run part B of the day.
        /// <para>Please only execute Run.</para>
        /// </summary>
        public virtual string RunPartB()
        {
            return "";
        }
}
}

using Solutions.Day2.Library;
using System;
using System.IO;
using System.Linq;

namespace Solutions.Day2
{
    internal class Day2Solution
    {
        public static void Run()
        {
            var data = File.ReadAllLines("Day2/puzzle_input.txt");
            Console.WriteLine($"Day 2, part 1: {Part1(data)}");
            Console.WriteLine($"Day 2, part 2: {Part2(data)}\n");
        }

        private static int Part1(string[] data)
        {
            int count = 0;
            foreach (var line in data)
            {
                var policy = new Policy(line);

                var instances = policy.Password.Count(x => x == policy.Char);

                // Short-circuit if incremenet if number of instances is outside of range
                if (instances < policy.Pos1 || instances > policy.Pos2) continue;

                count++;
            }

            return count;
        }

        private static int Part2(string[] data)
        {
            int count = 0;

            foreach (var line in data)
            {
                var policy = new Policy(line);

                bool firstMatch = policy.Password[policy.Pos1] == policy.Char;
                bool secondMatch = policy.Password[policy.Pos2] == policy.Char;

                // Increment if XOR
                if (firstMatch ^ secondMatch) count++;
            }

            return count;
        }
    }
}
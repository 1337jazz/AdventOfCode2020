using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Solutions.Day3
{
    public class Day3Solution
    {
        public static void Run()
        {
            var data = File.ReadAllLines("Day3/puzzle_input.txt");
            Console.WriteLine($"Day 3, part 1: {Part1(data)}");
            Console.WriteLine($"Day 3, part 2: {Part2(data)}\n");
        }

        private static long Part1(string[] data, int right = 3, int down = 1)
        {
            var modData = new List<string>();
            int numTrees = 0, col = 0, row = 0;

            // Extend each line by 1000 times
            foreach (var line in data)
                modData.Add(new StringBuilder().Insert(0, line, 1000).ToString());

            foreach (var line in modData.Skip(1))
            {
                row++;
                if (row % down != 0) continue;
                col = col + right > line.Length - 1 ? line.Length - 1 : col + right;
                numTrees = line[col] == '#' ? numTrees + 1 : numTrees;
            }

            return numTrees;
        }

        private static long Part2(string[] data)
        {
            var slope1 = Part1(data, 1);
            var slope2 = Part1(data, 3);
            var slope3 = Part1(data, 5);
            var slope4 = Part1(data, 7);
            var slope5 = Part1(data, 1, 2);

            return checked(slope1 * slope2 * slope3 * slope4 * slope5);
        }
    }
}
using Solutions.Day4.Library;
using System;
using System.IO;

namespace Solutions.Day4
{
    public class Day4Solution
    {
        public static void Run()
        {
            var data = File.ReadAllLines("Day4/puzzle_input.txt");
            Console.WriteLine($"Day 4, part 1: {Part1(data)}");
            Console.WriteLine($"Day 4, part 2: {Part2(data)}\n");
        }

        private static int Part1(string[] data)
        {
            var passports = Passport.PassportifyList(data);
            var validCount = 0;

            foreach (var passport in passports)
                if (passport.IsValidPart1)
                    validCount++;

            return validCount;
        }

        private static int Part2(string[] data)
        {
            var passports = Passport.PassportifyList(data);
            var validCount = 0;

            foreach (var item in passports)
                if (item.IsValidPart2) validCount++;

            return validCount;
        }
    }
}
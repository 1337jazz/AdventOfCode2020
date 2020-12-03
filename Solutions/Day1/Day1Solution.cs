using System;
using System.IO;

namespace Solutions.Day1
{
    internal class Day1Solution
    {
        public static void Run()
        {
            var data = File.ReadAllLines("Day1/puzzle_input.txt");
            Console.WriteLine($"Day 1, part 1: {Part1(data)}");
            Console.WriteLine($"Day 2, part 2: {Part2(data)}\n");
        }

        private static int Part1(string[] data)
        {
            // Test each number against every other number
            for (int i = 0; i < data.Length; i++)
            {
                int firstNumber = int.Parse(data[i]);

                // Nested loop 1
                for (int j = 1; j < data.Length; j++)
                {
                    int secondNumber = int.Parse(data[j]);

                    int sum = firstNumber + secondNumber;

                    if (sum == 2020)
                        return firstNumber * secondNumber;
                }
            }
            return 0;
        }

        private static int Part2(string[] data)
        {
            // Test each number against every other number
            for (int i = 0; i < data.Length; i++)
            {
                int firstNumber = int.Parse(data[i]);

                // Nested loop 1
                for (int j = 1; j < data.Length; j++)
                {
                    int secondNumber = int.Parse(data[j]);

                    // Nested loop 2
                    for (int k = 2; k < data.Length; k++)
                    {
                        int thirdNumber = int.Parse(data[k]);
                        int sum = firstNumber + secondNumber + thirdNumber;

                        if (sum == 2020)
                            return firstNumber * secondNumber * thirdNumber;
                    }
                }
            }
            return 0;
        }
    }
}
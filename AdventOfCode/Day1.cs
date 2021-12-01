using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public static class Day1
    {
        public static void Part2()
        {
            var count = 0;
            var outputString = new List<string>();
            var slidingWindow = new int[3];
            int? prevSum = null;
            for (var i = 0; i < slidingWindow.Length; i++)
            {
                var rawInput = Console.ReadLine();
                if (string.IsNullOrEmpty(rawInput))
                    break;

                var input1 = int.Parse(rawInput);

                slidingWindow[i] = input1;

                if (i != slidingWindow.Length - 1) continue;

                if (prevSum is null)
                {
                    prevSum = slidingWindow.Sum();
                }
                else
                {
                    var curSum = slidingWindow.Sum();
                    var diff = curSum > prevSum;
                    outputString.Add(slidingWindow.Sum() + " " + diff);
                    if (diff)
                        count++;

                    prevSum = curSum;
                }

                slidingWindow[0] = slidingWindow[1];
                slidingWindow[1] = slidingWindow[2];
                slidingWindow[2] = 0;
                i = 1;
            }

            outputString.ForEach(Console.WriteLine);
            Console.WriteLine(count);
        }

        public static void Part1()
        {
            var input1 = "";
            var count = 0;
            while (true)
            {
                var input2 = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input1))
                {
                    input1 = input2;
                    continue;
                }

                var int1 = int.Parse(input1);
                var int2 = int.Parse(input2);

                var diff = int2 - int1;

                input1 = input2;

                if (diff > 0)
                    count++;

                if (input2 is "6632") break;
            }

            Console.WriteLine(count);
        }
    }
}
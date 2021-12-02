using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public static class Day2
    {
        public static void Part2()
        {
            var input = "";
            var x = 0;
            var y = 0;
            var aim = 0;
            while (true)
            {
                var rawInput = Console.ReadLine();
                if (string.IsNullOrEmpty(rawInput))
                    break;

                var split = rawInput.Split(' ');
                var direction = split[0];
                var magnitude = int.Parse(split[1]);
                
                switch (direction)
                {
                    case "forward":
                        x += magnitude;
                        y += aim * magnitude;

                        break;
                    case "down":
                        aim += magnitude;
                        break;
                    case "up":
                        aim -= magnitude;
                        break;
                }


            }

            Console.WriteLine(Math.Abs(x * y));
        }

        public static void Part1()
        {
            var input = "";
            var x = 0;
            var y = 0;
            while (true)
            {
                var rawInput = Console.ReadLine();
                if (string.IsNullOrEmpty(rawInput))
                    break;

                var split = rawInput.Split(' ');
                var direction = split[0];
                var magnitude = int.Parse(split[1]);


                switch (direction)
                {
                    case "forward":
                        x += magnitude;
                        break;
                    case "down":
                        y -= magnitude;
                        break;
                    case "up":
                        y += magnitude;
                        break;
                }

            }

            Console.WriteLine(Math.Abs(x * y));
        }
    }
}
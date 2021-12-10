using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode
{
    public static class Day5
    {
        public static void Part1()
        {
            var path = @"C:\Repositories\AdventOfCode\AdventOfCode\Inputs\Day5Input.txt";
            var lines = System.IO.File.ReadAllLines(path);

            var points = new List<Point>();

            foreach (var str in lines)
            {
                var split = str.Replace(" ", "").Split("->");
                var s1 = split[0].Split(",").ToList().Select(int.Parse).ToList();
                var p1 = new Point(s1.ElementAt(0), s1.ElementAt(1));
                
                var s2 = split[1].Split(",").ToList().Select(int.Parse).ToList();
                var p2 = new Point(s2.ElementAt(0), s2.ElementAt(1));

                if (p1.X != p2.X && p1.Y != p2.Y)
                    continue;
                
                points.AddRange(GetRanges(p1, p2));
            }

            points = points.OrderBy(p => p.X).ThenBy(p=> p.Y).ToList();
            var distinct = points.Distinct().ToList();
            Console.WriteLine(points.Count - distinct.Count);
            
        }

        private static IEnumerable<Point> GetRanges(Point p1, Point p2)
        {
            var points = new List<Point>();
            if (p1.X == p2.X)
            {
                var diff = Math.Abs(p2.Y - p1.Y);
                for (var i = 0; i <= diff; i++)
                {
                    var y = Math.Min(p2.Y, p1.Y);
                    var newPoint = new Point(p1.X, y + i);
                    points.Add(newPoint);

                }
            }
            else
            {
                var diff = Math.Abs(p2.X - p1.X);
                for (var i = 0; i <= diff; i++)
                {
                    var x = Math.Min(p2.X, p1.X);
                    var newPoint = new Point(x + i, p1.Y );
                    points.Add(newPoint);
                }
            }

            return points;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public static class Day4
    {
        private class Board
        {
            private const int D = 5;
            
            private readonly List<int[][]> _grids = new();

            public Board(string[] raw)
            {
                var i = 0;
                int[][] grid = null;
                foreach(var str in raw)
                // for (var i = 0; i < raw.Length; i++)
                {
                    if (grid == null)
                    {
                        grid = new int[D][];
                        for (var j = 0; j < D; j++)
                            grid[j] = new int[D];
                    }

                    
                    if (string.IsNullOrWhiteSpace(str))
                    {
                        i = 0;
                        _grids.Add(grid);
                        grid = null;
                        continue;
                    }

                    var strings = str.Split(" ").ToList();
                    strings.RemoveAll(string.IsNullOrWhiteSpace);
                    for (var j = 0; j < strings.Count; j++)
                    {
                        var numStr = strings[j];
                        grid[i][j] = int.Parse(numStr);
                    }

                    i++;
                }
                
            }

            public int UpdateBoardPart1(int num)
            {
                for (var index = 0; index < _grids.Count; index++)
                {
                    var grid = _grids[index];
                    for (var i = 0; i < D; i++)
                    {
                        for (var j = 0; j < D; j++)
                        {
                            if (grid[i][j] == num)
                            {
                                grid[i][j] = 0;
                            }
                        }
                    }
                }

                foreach (var grid in _grids)
                {
                    
                    for (var i = 0; i < D; i++)
                    {
                        var x = grid[i].ToList();
                        var y = new[]{grid[0][i],grid[1][i],grid[2][i],grid[3][i],grid[4][i]}.ToList();

                        if (x.Sum() == 0 || y.Sum() == 0)
                            return num * CalculateScore(grid);
                    }
                }
                
                return -1;
            }
            public int? UpdateBoardPart2(int num)
            {
                
                for (var index = 0; index < _grids.Count; index++)
                {
                    var grid = _grids[index];
                    for (var i = 0; i < D; i++)
                    {
                        for (var j = 0; j < D; j++)
                        {
                            if (grid[i][j] == num)
                            {
                                grid[i][j] = 0;
                            }
                        }
                    }
                }

                int? result = null;
                for (var index = 0; index < _grids.Count; index++)
                {
                    var grid = _grids[index];
                    for (var i = 0; i < D; i++)
                    {
                        var x = grid[i].ToList();
                        var y = new int[] {grid[0][i], grid[1][i], grid[2][i], grid[3][i], grid[4][i]}.ToList();

                        if (x.Sum() == 0 || y.Sum() == 0)
                        {
                            result = num * CalculateScore(grid);

                            _grids.Remove(grid);
                        }
                    }
                }

                return result;            
            }

            private static int CalculateScore(int[][] grid)
            {
                var sum = 0;
                for (int i = 0; i < D; i++)
                {
                    sum += grid[i].Sum();
                }

                return sum;
            }

            public void PrintBoard()
            {
                for (var index = 0; index < _grids.Count; index++)
                {                    
                    Console.WriteLine($"~~~~~~~~~{index}~~~~~~~~");

                    var grid = _grids[index];
                    for (var i = 0; i < D; i++)
                    {
                        for (var j = 0; j < D; j++)
                        {
                            Console.Write($"{grid[i][j]} ");
                        }

                        Console.Write(Environment.NewLine);
                    }

                }
            }
        }
        public static void Part1()
        {
            var path = @"C:\Repositories\AdventOfCode\AdventOfCode\Day4Input1.txt";
            var lines = System.IO.File.ReadAllLines(path);

            var board = new Board(lines);
            board.PrintBoard();

            var input = Console.ReadLine();
            if (input == null) return;
            
            foreach (var num in input.Split(","))
            {
                var res = board.UpdateBoardPart1(int.Parse(num));
                if (res > -1)
                {
                    Console.WriteLine(res);
                    return;
                }
            }
        }
        
        public static void Part2()
        {
            var path = @"C:\Repositories\AdventOfCode\AdventOfCode\Day4Input1.txt";
            var lines = System.IO.File.ReadAllLines(path);

            var board = new Board(lines);
            board.PrintBoard();

            var input = Console.ReadLine();
            if (input == null) return;

            int? result = null;
            foreach (var num in input.Split(","))
            {
                var n = board.UpdateBoardPart2(int.Parse(num));
                result = n ?? result;
            }
            Console.WriteLine(result);
        }
    }
}
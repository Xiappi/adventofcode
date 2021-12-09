using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public static class Day3
    {
        /*
         * I've given up making these efficient until it matters
         */
        public static void Part2()
        {
            
            var inputs = new List<string>();

            while (true)
            {
                var rawInput = Console.ReadLine();
                if (string.IsNullOrEmpty(rawInput))
                    break;
                inputs.Add(rawInput);
            }

            var length = inputs[0].Length;
            var oxygenInputs = inputs;
            var co2Inputs = inputs;

            var oxygenVal = "";
            var co2Val = "";

            for (int i = 0; i < length; i++)
            {
                var zeroCount = 0;
                var oneCount = 0;

                var i1 = i;
                oxygenInputs.ForEach(str =>
                {
                    if (str[i1].Equals('0'))
                        zeroCount++;
                    else
                    {
                        oneCount++;
                    }
                });
                
                if (zeroCount > oneCount)
                {
                    oxygenInputs = oxygenInputs.Where(str => str[i].Equals('0')).ToList();
                    // co2Inputs = co2Inputs.Where(str => str[i].Equals('1')).ToList();

                }
                else if (zeroCount <= oneCount)
                {
                    oxygenInputs = oxygenInputs.Where(str => str[i].Equals('1')).ToList();
                    // co2Inputs = co2Inputs.Where(str => str[i].Equals('0')).ToList();
                }

                if (oxygenInputs.Count == 1)
                {
                    oxygenVal = oxygenInputs[0];
                    break;
                }
            }
            
            for (int i = 0; i < length; i++)
            {
                var zeroCount = 0;
                var oneCount = 0;

                var i1 = i;
                co2Inputs.ForEach(str =>
                {
                    if (str[i1].Equals('0'))
                        zeroCount++;
                    else
                    {
                        oneCount++;
                    }
                });
                
                if (zeroCount > oneCount)
                {
                    // oxygenInputs = oxygenInputs.Where(str => str[i].Equals('0')).ToList();
                    co2Inputs = co2Inputs.Where(str => str[i].Equals('1')).ToList();

                }
                else if (zeroCount <= oneCount)
                {
                    // oxygenInputs = oxygenInputs.Where(str => str[i].Equals('1')).ToList();
                    co2Inputs = co2Inputs.Where(str => str[i].Equals('0')).ToList();
                }

                if (co2Inputs.Count == 1)
                {
                    co2Val = co2Inputs[0];
                    break;
                }
            }
            Console.WriteLine(Convert.ToInt32(oxygenVal, 2) * Convert.ToInt32(co2Val, 2));
        }

        private class Val
        {
            public char Letter { get; set; }
            public int Count { get; set; }
        }
        public static void Part1()
        {
            List<Val>[] dict= null;
            int x = 0;
            while (true)
            {
                var rawInput = Console.ReadLine();
                if (string.IsNullOrEmpty(rawInput))
                    break;

                dict ??= new List<Val>[rawInput.Length];
 
                for(int i = 0; i < rawInput.Length; i++)
                {
                    var c = rawInput[i];
                    dict[i] ??= new List<Val>();
                    
                    var item = dict[i].Find(s => s.Letter == c);
                    if (item == default(Val))
                    {
                        dict[i].Add(new Val(){Letter = c, Count = 1});
                    }
                    else
                    {
                        dict[i][dict[i].IndexOf(item)].Count++;
                    }
                }

                x++;
            }

            var gamma = "";
            var epsilon = "";
            foreach (var t in dict)
            {
                var max = char.MinValue;
                var min = char.MinValue;

                for (int j = 0; j < t.Count-1; j++)
                {
                    if (t[j].Count > t[j + 1].Count)
                    {
                        max = t[j].Letter;
                        min = t[j+1].Letter;

                    }
                    else
                    {
                        max = t[j+1].Letter;
                        min = t[j].Letter;

                    }
                }

                gamma += max;
                epsilon += min;
            }
            
            Console.WriteLine();
            Console.WriteLine(Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2));

        }
    }
}
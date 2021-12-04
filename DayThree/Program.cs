using System;
using System.Collections.Generic;
using System.Linq;

namespace DayThree
{
    class Program
    {
        static void Main(string[] args)
        {
            PartOne();
            PartTwo();
        }

        class pos {
            public int on { get; set; }
            public int off { get; set; }
        }

        static Dictionary<int, pos> CountValues(string[] lines)
        {
            Dictionary<int, pos> dict = new();
            for(int i = 0; i < lines[0].Length; i++)
            {
                dict.Add(i, new pos());
            }
            foreach(var line in lines)
            {
                for(int i = 0; i < line.Length; i++)
                {
                    if(line[i] == '1'){
                        dict[i].on++;
                    }else{
                        dict[i].off++;
                    }
                }
            }
            return dict;
        }

        static void PartOne()
        {
            string[] lines = System.IO.File.ReadAllLines(@"./input.txt");
            
            var dict = CountValues(lines);
            
            string mostCommonBit = "";
            string leastCommonBit = "";

            for(int i = 0; i < lines[0].Length; i++)
            {
               if(Convert.ToInt32(dict[i].on) > Convert.ToInt32(dict[i].off)){
                   mostCommonBit += "1";
                   leastCommonBit += "0";
               }else{
                   mostCommonBit += "0";
                   leastCommonBit += "1";
               }
            }
            int mcb = Convert.ToInt32(mostCommonBit, 2);
            int lcb = Convert.ToInt32(leastCommonBit, 2);

            System.Console.WriteLine(mcb*lcb);
        }

        static string GetOxygetnGeneratorRating(string[] lines)
        {
            List<string> possibleAnswers = lines.ToList();
            List<string> newPossibleAnswers = new();
            var dict = CountValues(lines);

            for(int i = 0; i < lines[0].Length; i++)
            {
                
                char mostCommonBit = dict[i].on >= dict[i].off ? '1' : '0';
                foreach(var pa in possibleAnswers)
                {
                    if(pa[i] == mostCommonBit){
                        newPossibleAnswers.Add(pa);
                    }
                }
                possibleAnswers = newPossibleAnswers;
                newPossibleAnswers = new();
                dict = CountValues(possibleAnswers.ToArray());
            }
            return possibleAnswers[0];
        }

        static string GetCo2ScrubberRating(string[] lines)
        {
            List<string> possibleAnswers = lines.ToList();
            List<string> newPossibleAnswers = new();
            var dict = CountValues(lines);

            for(int i = 0; i < lines[0].Length; i++)
            {
                
                char mostCommonBit = dict[i].off <= dict[i].on ? '0' : '1';
                foreach(var pa in possibleAnswers)
                {
                    if(pa[i] == mostCommonBit){
                        newPossibleAnswers.Add(pa);
                    }
                }
                possibleAnswers = newPossibleAnswers;
                newPossibleAnswers = new();
                if(possibleAnswers.Count() <= 1){
                    return possibleAnswers[0];
                }
                dict = CountValues(possibleAnswers.ToArray());
            }
            System.Console.WriteLine(possibleAnswers.Count());
            return possibleAnswers[0];
        }

        static void PartTwo()
        {

            string[] lines = System.IO.File.ReadAllLines(@"./input.txt");

            var oxygenGeneratorRating = GetOxygetnGeneratorRating(lines);
            var co2ScrubberRating = GetCo2ScrubberRating(lines);

            System.Console.WriteLine(oxygenGeneratorRating);
            System.Console.WriteLine(co2ScrubberRating);

            System.Console.WriteLine(Convert.ToInt32(oxygenGeneratorRating, 2) * Convert.ToInt32(co2ScrubberRating, 2));
            

        }
    }
}

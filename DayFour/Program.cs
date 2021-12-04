using System;
using System.Collections.Generic;
using System.Linq;

namespace DayFour
{
    class Program
    {
        static void Main(string[] args)
        {
            PartOne();
            PartTwo();
        }

        static List<Board> ReadBoards(string[] lines, List<int> numbers)
        {
            List<Board> boards = new();
            Board b = new();
            var lines_list = lines.ToList();
            lines_list.RemoveRange(0, 2);
            foreach(var line in lines_list)
            {
                if(line.Length == 0)
                {
                    boards.Add(b);
                    b = new();
                    continue;
                }
                b.AddRow(line.Split().ToList());
            }
            return boards;
        }

        static void PartOne()
        {
            string[] lines = System.IO.File.ReadAllLines(@"./input.txt");
            
            var numbers_str = lines[0].Split(',');

            List<int> numbers = numbers_str.Select(int.Parse).ToList();

            var boards = ReadBoards(lines, numbers);

            foreach(var number in numbers)
            {
                foreach(var board in boards)
                {
                    var w = board.MarkNumber(number);
                    if(w > 0)
                    {
                        System.Console.WriteLine(board.SumOfEmpty() * number);
                        return;
                    }
                }
            }
            
        }

        private static void PartTwo()
        {
            string[] lines = System.IO.File.ReadAllLines(@"./input.txt");
            
            var numbers_str = lines[0].Split(',');

            List<int> numbers = numbers_str.Select(int.Parse).ToList();

            var boards = ReadBoards(lines, numbers);

            foreach(var number in numbers)
            {
                var nBoards = boards.ToArray().ToList();
                foreach(var board in nBoards)
                {
                    var w = board.MarkNumber(number);
                    if(w > 0)
                    {
                        if(nBoards.Count == 1)
                        {
                            System.Console.WriteLine(board.SumOfEmpty() * number);
                        }
                        boards.Remove(board);
                    }
                }
            }
        }
        
    }
}

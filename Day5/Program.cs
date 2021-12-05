using System;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            PartOne();
            PartTwo();
        }

        private static void PartOne()
        {
            string[] lines = System.IO.File.ReadAllLines(@"./input.txt");
            int dimension = 1000;
            int[] grid = new int[dimension*dimension];

            foreach(var line in lines)
            {
                var cords = line.Replace(" -> ", ",").Split(",");
                int curX = Convert.ToInt32(cords[0]);
                int curY = Convert.ToInt32(cords[1]);
                int tarX = Convert.ToInt32(cords[2]);
                int tarY = Convert.ToInt32(cords[3]);
                if(curY != tarY && curX != tarX){ continue; }
                grid[curX + curY*dimension] += 1;
                do
                {
                    if(curX < tarX){ curX += 1; }
                    if(curY < tarY){ curY += 1; }
                    if(curX > tarX){ curX -= 1; }
                    if(curY > tarY){ curY -= 1; }
                    grid[curX + curY*dimension] += 1;
                }
                while(!(curX == tarX && curY == tarY));
            }
            int counter = 0;
            for(int i = 0; i < grid.Length; i++)
            {
                if(grid[i] > 1)
                {
                    counter++;
                }
            }
            System.Console.WriteLine(counter);
        }

        private static void PartTwo()
        {
            string[] lines = System.IO.File.ReadAllLines(@"./input.txt");
            int dimension = 1000;
            int[] grid = new int[dimension*dimension];

            foreach(var line in lines)
            {
                var cords = line.Replace(" -> ", ",").Split(",");
                int curX = Convert.ToInt32(cords[0]);
                int curY = Convert.ToInt32(cords[1]);
                int tarX = Convert.ToInt32(cords[2]);
                int tarY = Convert.ToInt32(cords[3]);
                grid[curX + curY*dimension] += 1;
                do
                {
                    if(curX < tarX){ curX += 1; }
                    if(curY < tarY){ curY += 1; }
                    if(curX > tarX){ curX -= 1; }
                    if(curY > tarY){ curY -= 1; }
                    grid[curX + curY*dimension] += 1;
                }
                while(!(curX == tarX && curY == tarY));
            }
            int counter = 0;
            for(int i = 0; i < grid.Length; i++)
            {
                // if(i % 10 == 0)
                // {
                //     System.Console.WriteLine("");
                // }
                // Console.Write($"{grid[i]} ");
                if(grid[i] > 1)
                {
                    counter++;
                }
            }
            System.Console.WriteLine(counter);
        }
    }
}

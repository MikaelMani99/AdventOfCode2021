using System;

namespace DayTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            PartOne();
            PartTwo();
        }

        static void PartOne()
        {
            string[] lines = System.IO.File.ReadAllLines(@"./input.txt");
            int x = 0;
            int y = 0;
            foreach(var line in lines){
                var s = line.Split(" ");
                var command = s[0];
                var value = Convert.ToInt32(s[1]);

                switch(command)
                {
                    case "forward":
                        x += value;
                        break;
                    case "down":
                        y += value;
                        break;
                    case "up":
                        y -= value;
                        break;
                    
                }
            }
            System.Console.WriteLine(x*y);
        }
        static void PartTwo()
        {
            string[] lines = System.IO.File.ReadAllLines(@"./input.txt");
            int x = 0;
            int y = 0;
            int aim = 0;
            foreach(var line in lines){
                var s = line.Split(" ");
                var command = s[0];
                var value = Convert.ToInt32(s[1]);

                switch(command)
                {
                    case "forward":
                        x += value;
                        y += aim * value;
                        break;
                    case "down":
                        aim += value;
                        break;
                    case "up":
                        aim -= value;
                        break;
                    
                }
            }
            System.Console.WriteLine(x*y);
        }
    }
}

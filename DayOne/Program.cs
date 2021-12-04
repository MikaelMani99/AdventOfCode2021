using System;

namespace DayOne
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
            
            int count = 0;
            for(var i = 1; i < lines.Length; i++){
                if(Convert.ToInt32(lines[i-1]) < Convert.ToInt32(lines[i]))
                {
                    count++;
                }                
            }
            System.Console.WriteLine(count);
        }

        static void PartTwo()
        {
            string[] lines = System.IO.File.ReadAllLines(@"./input.txt");

            int count = 0; 

            for(var i = 3; i < lines.Length; i++){
                var sum1 = Convert.ToInt32(lines[i-3]) + Convert.ToInt32(lines[i-2]) + Convert.ToInt32(lines[i-1]);
                var sum2 = Convert.ToInt32(lines[i-2]) + Convert.ToInt32(lines[i-1]) + Convert.ToInt32(lines[i]);
                
                if(sum1 < sum2)
                {
                    count++;
                }
            }
            System.Console.WriteLine(count);
        }
    }
}

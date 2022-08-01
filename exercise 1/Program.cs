using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Exercise pattern
            Console.Write("\n----------print the pattern-----------");
            pattern:
                Console.Write("\nenter any number from 1 to 26 : ");
                int pattern = Convert.ToInt32(Console.ReadLine());

            if (pattern <= 0 || pattern > 26)
            {
                goto pattern;
            }

            for (int i = 0; i < pattern; i++)
            {
                //int x = 65;
                for (int j = 0; j <= i; j++)
                {
                    Console.Write((char)(j + 65) + " ");
                    //x++;
                }
                for (int k = i-1; k >= 0; k--)
                {
                    Console.Write((char)(k + 65) + " ");
                }
                Console.ReadLine();
            }
        }
    }
}

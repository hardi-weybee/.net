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
            // Exercise pattern
            Console.Write("\n----------print the pattern-----------");
            pattern:
                Console.Write("\nEnter any number from 1 to 26 : ");
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



            // sorting without using inbuilt method
            Console.WriteLine("\n-----------Sorting in ascending order---------------");
            int[] array = {74, 489, 78, 37, 2, 38, 55, 90, 68, 267};
            int t = 0;
            Console.WriteLine("\nArray before sorting");
            foreach(int x in array)
            {
                Console.Write(x + " ");
            }

            for(int i=0; i<array.Length; i++)
            {
                for(int j=i+1; j<array.Length; j++)
                {
                    if(array[i] > array[j])
                    {
                        t = array[i];
                        array[i] = array[j];
                        array[j] = t;
                    }
                }
            }     
            Console.WriteLine("\n\nArray after sorting");
            foreach(int y in array)
            {
                Console.Write(y + " ");
            }
            Console.ReadLine();
        }
    }
}

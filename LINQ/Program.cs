using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // LINQ syntax
            // 1. Query
            Console.WriteLine("\n------------------------LINQ Syntax-------------------");
            Console.Write("\n---1. LINQ Query Example---\n");

            List<string> s = new List<string> { "Kakashi", "Naruto", "Minato" };
            var res = from name in s
                      where name == "Kakashi"
                      select name;
            foreach (var i in res)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();


            // 2. method
            Console.Write("\n---2. LINQ Method Example---\n");

            var result = s.Where(n => n == "Naruto").ToList();
            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();


            // 3. mixed
            Console.Write("\n---3. LINQ Mixed Example---\n");

            List<int> numbers = new List<int> { 45, 43, -443, 65, -45 };
            var result1 = (from sub in numbers
                           where sub > 0
                           select sub).Sum();
            Console.Write(result1);

            Console.ReadLine();



            // lambda expression
            Console.WriteLine("\n\n------------------------Lambda Expression-------------------");

            List<string> s1 = new List<string> { "Naruto", "Hinata", "Jiraya", "Naruto" };

            IEnumerable<string> str = s1.Select(a => a);
            foreach (var i in str)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();


            // aggregate function
            // 1. min() function
            Console.WriteLine("\n\n------------------------Aggregate Function-------------------");
            Console.Write("\n---1. Min() Function---");

            int[] array = { 74, 63, 2, 4387, 09, 65, 89, 213 };
            Console.Write("\nArray elements are : ");
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }

            int MinNumber = array.Min();
            Console.WriteLine("\nThe minimum number from given array is " + MinNumber);
            Console.ReadLine();


            // 2. max() function
            Console.Write("\n---2. Max() Function---");

            Console.Write("\nArray elements are : ");
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }

            int MaxNumber = array.Max();
            Console.WriteLine("\nThe maximum number from given array is " + MaxNumber);
            Console.ReadLine();


            // 3. sum() function
            Console.Write("\n---3. Sum() Function---");

            Console.Write("\nArray elements are : ");
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }

            int sum = array.Sum();
            Console.WriteLine("\nThe addition of the array elements is " + sum);
            Console.ReadLine();


            // 4. count() function
            Console.Write("\n---4. Count() Function---");

            Console.Write("\nArray elements are : ");
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }

            int count = array.Count();
            Console.WriteLine("\nThere are " + count + " numbers of elements");
            Console.ReadLine();


            // 5. aggregate() function
            Console.Write("\n---5. Aggregate() Function---");

            Console.Write("\nArray elements are : ");
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            int multiply = array.Aggregate((a, b) => a * b);
            Console.WriteLine("\nThe multiplication of array elements is " + multiply);

            string[] strlist = { "Chandler", "Monica", "Phoebe", "Joey", "Ross", "Rachel" };
            string concat = strlist.Aggregate((a, b) => a + ", " + b);
            Console.WriteLine("\nMy Favourite charaters are " + concat);

            Console.ReadLine();


            // sorting operators
            // 1. order by
            Console.WriteLine("\n\n------------------------Sorting Operators-------------------");
            Console.Write("\n---1. OrderBy---");

            List<Students> info = new List<Students>
            {
                new Students() { ID = 1, Name = "Kakashi", Gender = "Male", Address = new List<string> { "34", "Seltice Way", "Boise" } },
                new Students() { ID = 2, Name = "Naruto", Gender = "Male", Address = new List<string> { "2429", "Doctors Drive", "Torrance" } },
                new Students() { ID = 3, Name = "Hinata", Gender = "Female", Address = new List<string> { "85", " Locust Street", "Valdosta" } },
                new Students() { ID = 4, Name = "Sakura", Gender = "Female", Address = new List<string> { "245", "Bruce Street", "Saint Louis" } },
                new Students() { ID = 5, Name = "Itachi", Gender = "Male", Address = new List<string> { "789", "Cameron Road", "Buffalo" } },
            };
        }
    }

    class Students
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public List<string> Address { get; set; }
    }
}

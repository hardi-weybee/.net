using System;
using System.Collections.Generic;
using System.Collections;
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

            List<int> s1 = new List<int> { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            var result = s1.Where(n => n > 30);
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

            List<string> lambda = new List<string> { "Naruto", "Hinata", "Jiraya", "Naruto" };

            IEnumerable<string> str = lambda.Select(a => a);
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
            Console.Write("\n---1. OrderBy---\n");

            List<Students> info = new List<Students>
            {
                new Students() { ID = 1, Name = "Kakashi", Gender = "Male", Address = new List<string> { "34", "Seltice Way", "Boise" } },
                new Students() { ID = 2, Name = "Naruto", Gender = "Male", Address = new List<string> { "2429", "Doctors Drive", "Torrance" } },
                new Students() { ID = 3, Name = "Hinata", Gender = "Female", Address = new List<string> { "85", " Locust Street", "Valdosta" } },
                new Students() { ID = 4, Name = "Sakura", Gender = "Female", Address = new List<string> { "245", "Bruce Street", "Saint Louis" } },
                new Students() { ID = 5, Name = "Itachi", Gender = "Male", Address = new List<string> { "789", "Cameron Road", "Buffalo" } },
            };

            var StudentOrderBY = info.OrderBy(x => x.Name);
            foreach (var i in StudentOrderBY)
            {
                Console.WriteLine($"ID : {i.ID},  Name : {i.Name},  Gender : {i.Gender},  Address : {String.Join(", ", i.Address)}");
            }
            Console.ReadLine();


            // 2. order by descending
            Console.Write("\n---2. OrderByDescending---\n");

            var StudentOrderByDesc = info.OrderByDescending(x => x.Name);
            foreach (var i in StudentOrderByDesc)
            {
                Console.WriteLine($"ID : {i.ID},  Name : {i.Name},  Gender : {i.Gender},  Address : {String.Join(", ", i.Address)}");
            }
            Console.ReadLine();


            // 3. then by
            Console.Write("\n---3. ThenBy---\n");

            var StudentThenBy = info.OrderBy(x => x.Name).ThenBy(x => x.ID);
            foreach (var i in StudentThenBy)
            {
                Console.WriteLine($"ID : {i.ID},  Name : {i.Name},  Gender : {i.Gender},  Address : {String.Join(", ", i.Address)}");
            }
            Console.ReadLine();


            // 4. then by descending
            Console.Write("\n---4. ThenByDescending---\n");

            var StudentThenByDesc = info.OrderBy(x => x.Name).ThenByDescending(x => x.ID);
            foreach (var i in StudentThenByDesc)
            {
                Console.WriteLine($"ID : {i.ID},  Name : {i.Name},  Gender : {i.Gender},  Address : {String.Join(", ", i.Address)}");
            }
            Console.ReadLine();


            // partition operator
            // 1. take
            Console.WriteLine("\n\n------------------------Partition Operators-------------------");
            Console.Write("\n---1. Take---\n");

            List<string> Series = new List<string> { "Friends", "Naruto", "Big Bang Theory", "The Office", "Full Metal Alchemist", "Breaking bad" };
            IEnumerable<string> takeOperator = Series.Take(2);
            //IEnumerable<string> takeOperator = (from s in Anime select s).Take(2);

            foreach (string i in takeOperator)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();


            // 2. takewhile
            Console.Write("\n---2. TakeWhile---\n");

            IEnumerable<string> takeWhileOperator = Series.TakeWhile(x => x.Contains("r"));
            //IEnumerable<string> takeWhileOperator = (from s in Series select s).TakeWhile(x => x.Contains("r"));

            foreach (string i in takeWhileOperator)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();


            // 3. skip
            Console.Write("\n---3. Skip---\n");

            IEnumerable<string> skipOperator = Series.Skip(2);
            //IEnumerable<string> skipOperator = (from s in Series select s).Skip(2);

            foreach (string i in skipOperator)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();


            // 4. skipwhile
            Console.Write("\n---4. SkipWhile---\n");

            IEnumerable<string> skipWhileOperator = Series.SkipWhile(x => x.StartsWith("F"));
            //IEnumerable<string> skipWhileOperator = (from s in Series select s).SkipWhile(x => x.Contains("r"));

            foreach (string i in skipWhileOperator)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();


            // conversion operator
            // 1. tolist()
            Console.WriteLine("\n\n------------------------Conversion Operators-------------------");
            Console.Write("\n---1. ToList()---\n");

            string[] Country = { "India", "USA", "Canada", "Germany", "Australia" };
            List<string> list = Country.ToList();
            //List<string> list = (from s in Country select s).ToList();

            foreach (string i in list)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();


            // 2. toarray()
            Console.Write("\n---2. ToArray()---\n");

            //List<string> Series = new List<string> { "Friends", "Naruto", "Big Bang Theory", "The Office", "Full Metal Alchemist", "Breaking bad" };            // already declared upward....here just for reference
            string[] arrayto = Series.ToArray();
            //string[] arrayto = (from a in Series select a).ToArray();

            foreach (string i in arrayto)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();


            // 3. tolookup()
            Console.Write("\n---3. ToLookUp()---\n");

            var lookup = info.ToLookup(x => x.Gender);
            //var lookup = (from s in info select s).ToLookup(x => x.Gender);

            foreach(var pair in lookup)
            {
                Console.WriteLine(pair.Key);
                foreach(var innerPair in lookup[pair.Key])
                {
                    Console.WriteLine($"ID : {innerPair.ID}\tName : {innerPair.Name}\tGender : {innerPair.Gender}\tAddress : {String.Join(", ", innerPair.Address)}");
                }
            }
            Console.ReadLine();
            

            // 4. cast()
            Console.Write("\n---4. Cast()---\n");

            List<string> castt = new List<string> { "Rajkot", "Ahmedabad", "Surat", "Junagadh" };

            IEnumerable<string> castFinal = castt.Cast<string>();
            foreach(var item in castFinal)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();


            // 5. oftype()
            Console.Write("\n---5. OfType()---\n");

            ArrayList Chocolate = new ArrayList() { "KitKat", 67, "Snickers", "5 Star", 32 };
            
            IEnumerable<string> type = Chocolate.OfType<string>();
            foreach(var i in type)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();


            // 6. asenumerable()
            Console.Write("\n---6. AsEnumerable()---\n");

            List<string> enumerable = new List<string> { "Car", "Pen", "Paper", "Book", "Bottle" };
            //List<int> enumerable = new List<int> { 675, 89723, 24, 8709, 67, 326 };
            
            var store = enumerable.AsEnumerable();
            foreach(var i in store)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();


            // 7. todictionary()
            Console.Write("\n---7. ToDictionary()---\n");

            var dict = info.ToDictionary(x => x.Name, x => x.Gender );
            foreach(var i in dict)
            {
                Console.WriteLine(i.Key + "  " + i.Value);
            }
            Console.ReadLine();


            // element operators
            // 1. first()
            Console.WriteLine("\n\n------------------------Element Operators-------------------");
            Console.Write("\n---1. First()---\n");

            //List<string> Series = new List<string> { "Friends", "Naruto", "Big Bang Theory", "The Office", "Full Metal Alchemist", "Breaking bad" };            // already declared upward....here just for reference
            
            string one = Series.First();
            //string one = (from a in Series select a).First();

            Console.Write($"First element from list is : {one}");
            Console.ReadLine();


            // 2. firstordefault()
            Console.Write("\n---2. FirstOrDefault()---\n");

            List<string> empty = new List<string> { };
          
            string two = empty.FirstOrDefault();
            //string two = (from a in empty select a).FirstOrDefault();
          
            Console.Write($"First element from empty list is : {two}");
            Console.ReadLine();


            // 3. last()
            Console.Write("\n---3. Last()---\n");

            string three = Series.Last();
            //string three = (from a in Series select a).Last();

            Console.Write($"Last element from list is : {three}");
            Console.ReadLine();


            // 4. lastordefault()
            Console.Write("\n---4. lastordefault()---\n");

            string four = empty.LastOrDefault();
            //string four = (from a in empty select a).LastOrDefault();

            Console.Write($"Last element from empty list is : {four}");
            Console.ReadLine();


            // 5. elementat()
            Console.Write("\n---5. ElementAt()---\n");

            string five = Series.ElementAt(2);
            //string five = (from a in Series select a).ElementAt(2);

            Console.Write($"Element at specified index from list is : {five}");
            Console.ReadLine();


            // 6. ElementAtOrDefault()
            Console.Write("\n---6. ElementAtOrDefault()---\n");

            string six = Series.ElementAtOrDefault(4);
            string six1 = Series.ElementAtOrDefault(10);
            //string six = (from a in Series select a).ElementAtOrDefault(2);

            Console.Write($"Element at specified index from list is : {six}");
            Console.Write($"\nElement at specified index from list is : {six1}");
            Console.ReadLine();


            // 7. single()
            Console.Write("\n---7. Single()---\n");
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

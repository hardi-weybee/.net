using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    class Program
    {
        // functions
        void FirstFunction()
        {
            Console.Write("\n--------------------functions----------------------");
            Console.Write("\nThis is my First Function.");
            Console.ReadLine();
        }

        void SecondFunction(string msg)
        {
            Console.Write("\nThis is my First Function with parameter : " + msg);
            Console.ReadLine();
        }

        string ThirdFunction(string message)
        {
            Console.Write("\nThis is my First Function with parameter and return type.");
            //Console.ReadLine();
            return message;
        }

        void CallByValue(int num)
        {
            num += num;
            Console.Write("\nValue in function : " + num);
            //Console.ReadLine();
        }

        void CallByReference(ref int numb)
        {
            numb += numb;
            Console.Write("\nvalue in function : " + numb);
            //Console.ReadLine();
        }

        void OutParamater(out int num1, out int num2)
        {
            int n = 50;
            num1 = n;
            num2 = n;
            num1 += num1;
            num2 *= num2;
        }

        void ArraytoFunction(int[] array)
        {
            Console.Write("\n\nThese are the elements in array : ");
            for(int i=0; i<array.Length; i++)
            {
                Console.Write(array[i] + " ");
                //Console.ReadLine();
            }
        }

        void MaxNumber(int[] array)
        {
            int max = array[0];
            for(int i=1; i<array.Length; i++)
            {
                if(max < array[i])
                {
                    max = array[i];
                }
            }
            Console.Write("\n\nThe maximum number from array is " + max);
            //Console.ReadLine();
        }

        void MinNumber(int[] array)
        {
            int min = array[0];
            for(int i=0; i<array.Length; i++)
            {
                if(min > array[i])
                {
                    min = array[i];
                }
            }
            Console.Write("\nThe minimum number from array is " + min);
            Console.ReadLine();
        }

        // params
        void ParamsFunction(params int[] n)
        {
            for(int i=0; i<n.Length; i++)
            {
                Console.Write(n[i]);
                Console.ReadLine();
            }
        }

        void ParamsObject(params object[] str)
        {
            for(int i=0; i<str.Length; i++)
            {
                Console.Write(str[i]);
                Console.ReadLine();
            }
        }

        // array class and methods
        void Print(int[] array)
        {
            foreach(Object a in array)
            {
                Console.Write(a + " ");
            }
        }


        // object and class
        public class Student
        {
            public string name;
            public int age;
            public static float rateOfInterest;
            public static int count = 0;

            // default constructor
            public Student()
            {
                Console.Write("\n------This is CONSTRUCTOR-------");
            }

            // destructor
            ~Student()
            {
                Console.Write("\n------This is DESTRUCTOR---------");
                Console.ReadLine();
            }

            // parameterized constructor and this keyword
            public Student(string name, int age)
            {
                this.name = name;
                this.age = age;
                count++;
            }

            static Student()
            {
                rateOfInterest = 3.3f;
            }

            //public void Insert(string str, int number)
            //{
            //    name = str;
            //    age = number;
            //}

            public void Print()
            {
                Console.WriteLine(name + " " + age + " " + rateOfInterest);
            }
        }

        // structs
        public struct Planet
        {
            public string name;

            public Planet(string str)
            {
                name = str;
            }
        }

        // enum
        public enum Months
        {
            Jan, Feb, Mar, Apr, May, June, July, Aug, Sept, Oct, Nov, Dec
        }

        // inheritance
        public class Vehicles
        {
            public string color = "Black";

            public void Vehicle()
            {
                Console.Write("\nA Truck is also a vehicle");
            }
        }

        public class Car : Vehicles
        {
            public int numberOfAirbags = 3;

            public void Items()
            {
                Console.Write("\nElectric vehicle is also a vehicle");
            }
        }

        // aggregation
        public class Address
        {
            public string addressLine, city, state;

            public Address(string addressLine, string city, string state)
            {
                this.addressLine = addressLine;
                this.city = city;
                this.state = state;
            }
        }

        public class Employees
        {
            public string nameOfEmployee;
            public Address address;

            public Employees(string nameOfEmployee, Address address)
            {
                this.nameOfEmployee = nameOfEmployee;
                this.address = address;
            }
        }


        // member overloading
        public static class Operations
        {
            public static int Addition(int x, int y)
            {
                return x + y;
            }

            public static float Addition(float x, float y)
            {
                return x + y;
            }
        }


        // method overriding
        public class Animal
        {
            public string s = "Partner";
            public virtual void Walk()
            {
                Console.Write("\nWalking " + s);
            }
        }
        public class Dog : Animal
        {
            public override void Walk()
            {
                base.Walk();
                Console.Write("\nDog is walking");
            }
        }

        // method overriding (base class constructor internally)
        public class Book
        {
            public string s1 = "Great wall";
            public Book()
            {
                Console.Write("\nBook is " + s1);
            }
        }
        public class Page : Book
        {
            public Page()
            {
                Console.Write("\nBook has 560 pages");
            }
        }


        // polymorphism
        public class Series
        {
            public virtual void Cast()
            {
                Console.Write("\nThe best charactersss");
            }
        }
        public class Friends : Series
        {
            public sealed override void Cast()
            {
                Console.Write("\nChandler is the best character");
            }
        }

        //// sealed
        //public class Chandler:Friends
        //{
        //    public override void Cast()
        //    {
        //        Console.Write("\nChandlerrrrrrrrrrrrrr");
        //    }
        //}
        public class Naruto : Series
        {
            public override void Cast()
            {
                Console.Write("\nKakashi is the best character");
            }
        }

        // abstract
        public abstract class Country
        {
            public abstract void State();
        }
        public class India : Country
        {
            public override void State()
            {
                Console.Write("\nThere are 28 states in India");
            }
        }
        public class US : Country
        {
            public override void State()
            {
                Console.Write("\nThere are 50 states in US");
            }
        }

        // interface
        public interface Chocolate
        {
            void Cocoa();
        }
        public class Dark : Chocolate
        {
            public void Cocoa()
            {
                Console.Write("\n50-90% Cocoa is present");
            }
        }
        public class Milk : Chocolate
        {
            public void Cocoa()
            {
                Console.Write("\n20-30% Cocoa is present");
            }
        }

        // encapsulation
        class Students
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Standard { get; set; }
        }


        // user defined exception
        public class MyException : Exception
        {
            public MyException(string msg) : base(msg)
            {

            }
        }
        static void Okay(int i)
        {
            if (i < 100)
            {
                throw new MyException("Number is less than 100");
            } 
        }



        static void Main(string[] args)
        {

            Console.WriteLine("Hello There !!");
            Console.ReadLine();

            // Arithmetic operations
            Console.Write("-------------Arithmetic operations-------------------");
        goto1:
            Console.Write("\nEnter first number for arithmetic operations: ");
            int a = Convert.ToInt32(Console.ReadLine());

            if (a == 0)
            {
                goto goto1;
            }

        goto2:
            Console.Write("Enter second number for arithmetic operations: ");
            int b = Convert.ToInt32(Console.ReadLine());

            if (b == 0)
            {
                goto goto2;
            }

            int sum = a + b;
            int subtract = a - b;
            int multiply = a * b;
            int divide = a / b;
            int mod = a % b;

            Console.WriteLine($"\nsum of {a} + {b} = {sum}");
            Console.WriteLine($"subtraction of {a} - {b} = {subtract}");
            Console.WriteLine($"multiplication of {a} * {b} = {multiply}");
            Console.WriteLine($"division of {a} / {b} = {divide}");
            Console.WriteLine($"mod of {a} % {b} = {mod}");
            Console.ReadLine();



            // swapping two number without using third variable

            Console.Write("--------------Swapping of numbers---------------");
            Console.Write("\nEnter first number for swapping: ");
            int firstnumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number for swapping: ");
            int secondnumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"before swapping: {firstnumber}, {secondnumber}");

            //try other way without addition and substraction

            //firstnumber = firstnumber + secondnumber;
            //secondnumber = firstnumber - secondnumber;
            //firstnumber = firstnumber - secondnumber;

            firstnumber *= secondnumber;
            secondnumber = firstnumber / secondnumber;
            firstnumber /= secondnumber;

            Console.Write($"after swapping: {firstnumber}, {secondnumber}");
            Console.ReadLine();


            // functions
            // 1. function with no parameter and return type
            Program first = new Program();
            first.FirstFunction();


            // 2. function with parameter but no return type
            first.SecondFunction("Hardi");


            // 3. function with parameter and return type
            string mes = first.ThirdFunction("Hardi");
            Console.Write("\nHey " + mes);     // parameter passing
            Console.ReadLine();


            // 4. call by value in function 
            int num = 100;
            Console.Write("\n----------------Call by value--------------------");
            Console.Write("\nValue before function call : " + num);
            first.CallByValue(num);
            Console.Write("\nValue after function call : " + num);
            Console.ReadLine();


            // 5. call by reference in function
            int number = 100;
            Console.Write("\n------------------Call by reference-------------------");
            Console.Write("\nValue before function call : " + number);
            first.CallByReference(ref number);
            Console.Write("\nvalue after function call : " + number);
            Console.ReadLine();


            // 6. out parameter
            //int num1;
            Console.Write("\n------------------out parameter-------------------");
            //Console.Write("\nvalue before function call : " + num1);
            first.OutParamater(out int num1, out int num2);
            Console.Write("\nvalue after function call : " + num1);
            Console.Write("\nvalue after function call : " + num2);
            Console.ReadLine();


            // Arrays
            // 1. Single dimensional array
            int[] array1 = { 10, 10, 10, 10, 10 };

            //for(int i=0; i<array1.Length; i++)
            //{
            //    Console.Write(array1[i]);
            //    Console.ReadLine();
            //}
            Console.WriteLine("\n-----------------Arrays--------------------");
            foreach (int i in array1)
            {
                Console.Write(i + " ");
                //Console.ReadLine();
            }


            // 2. Passing arrays to function
            int[] array2 = { 25, 10, 20, 15, 40, 50 };
            int[] array3 = { 12, 23, 44, 11, 54 };

            first.ArraytoFunction(array2);
            first.ArraytoFunction(array3);

            // Max and Min number from array
            int[] array4 = { 25, 10, 20, 15, 40, 50 };
            //int[] array5 = { 12, 23, 44, 11, 54 };

            first.MaxNumber(array4);
            //first.MaxNumber(array5);

            first.MinNumber(array4);
            //first.MinNumber(array5);


            // 3. multi dimensional array
            int[,] array6 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            Console.WriteLine("\n-------------multidimensional array-------------");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(array6[i, j] + " ");
                }
                Console.ReadLine();
            }


            // 4. jagged array (array of array)
            int[][] array7 = new int[3][]
            {
                new int[] { 38, 58, 29, 23, 38, 487, 239, 60, 437, 57},
                new int[] { 25, 10, 20, 15, 40, 50 },
                new int[] { 12, 23, 44, 11, 54 }
            };

            Console.WriteLine("\n----------jagged array------------");
            for (int i = 0; i < array7.Length; i++)
            {
                for (int j = 0; j < array7[i].Length; j++)
                {
                    Console.Write(array7[i][j] + " ");
                }
                Console.ReadLine();
            }


            // 5. params
            Console.WriteLine("\n-----------params-----------");
            first.ParamsFunction(10, 20, 30, 40, 50);

            first.ParamsObject("Hello Everyone", "Good to see you", 10000);


            // 6. array class and methods
            int[] array8 = { 47, 39, 1, 59, 89, 55 };
            int[] array9 = new int[6];

            Console.Write("\n------array methods---------");

            Console.Write("\nLength of array element is " + array8.Length);

            Array.Sort(array8);
            Console.Write("\nsorted array elements : ");
            first.Print(array8);

            Console.Write("\nindex of element 30 in array : " + Array.IndexOf(array8, 30));

            Array.Reverse(array8);
            Console.Write("\narray is reversed : ");
            first.Print(array8);

            Array.Copy(array8, array9, array8.Length);
            Console.Write("\narray is copied to second array having element : ");
            first.Print(array9);
            Console.ReadLine();


            // 7. command line argument
            Console.Write("\n------------command line arguments------------");
            Console.Write("\nargument length : " + args.Length);
            Console.Write("\narguments are :");
            foreach (Object obj in args)
            {
                Console.Write(obj);
            }
            Console.ReadLine();




            // Exercise pattern

            Console.Write("\n----------print the pattern-----------");
        p:
            Console.Write("\nEnter any number from 1 to 26 : ");
            int pattern = Convert.ToInt32(Console.ReadLine());

            if (pattern <= 0 || pattern > 26)
            {
                goto p;
            }

            for (int i = 0; i < pattern; i++)
            {
                //int x = 65;
                for (int j = 0; j <= i; j++)
                {
                    Console.Write((char)(j + 65) + " ");
                    //x++;
                }
                for (int k = i - 1; k >= 0; k--)
                {
                    Console.Write((char)(k + 65) + " ");
                }
                Console.ReadLine();
            }


            // Object and class 
            Student info = new Student()
            {
                name = "Hardi",
                age = 21

            };
            Console.Write("\n" + info.name + " " + info.age);
            Console.ReadLine();

            Console.WriteLine("\n\n-------------Displaying data through method--------------\n");
            Student s1 = new Student("Rishit", 21);
            Student s2 = new Student("Misari", 20);
            //s1.Insert("Rishit", 21);
            //s2.Insert("Misari", 20);
            s1.Print();
            s2.Print();
            Console.Write("\nTotal Objects are : " + Student.count);
            Console.ReadLine();


            // struct
            Console.WriteLine("\n\n------------Struct-------------------");
            Planet one = new Planet("Mercury");
            Planet two = one;
            one.name = "Earth";
            Console.Write("\nFirst Planet is " + two.name);
            Console.ReadLine();


            // enum
            int x = (int)Months.Feb;
            int y = (int)Months.May;
            int z = (int)Months.Dec;
            Console.WriteLine("\n\n-----------Enumerators------------\n");
            Console.WriteLine($"February : {x}");
            Console.WriteLine($"May : {y}");
            Console.WriteLine($"December : {z}");

            foreach (Months d in Enum.GetValues(typeof(Months)))
            {
                Console.WriteLine(d);
            }
            Console.ReadLine();


            // inheritance
            Console.WriteLine("------------Class inheritance---------------");
            Car c1 = new Car();
            Console.Write("\nVehicle color is : " + c1.color);
            Console.Write("\nVehicle has " + c1.numberOfAirbags + " number of airbags");


            // inheritance (methods)
            Console.WriteLine("\n\n------------Method inheritance---------------");
            c1.Vehicle();
            c1.Items();
            Console.ReadLine();


            // aggregation
            Console.WriteLine("\n\n------------------Aggregation-----------------------");
            Address a1 = new Address("Ring road", "Rajkot", "Gujarat");
            Employees e1 = new Employees("Hardi", a1);
            Console.Write("\n" + e1.nameOfEmployee + ", " + a1.addressLine + ", " + a1.city + ", " + a1.state);
            Console.ReadLine();


            // member overloading
            Console.WriteLine("\n\n----------------Member Overloading-------------------");
            Console.Write(Operations.Addition(2, 5));
            Console.Write("\n" + Operations.Addition(2.2f, 5.6f));
            Console.ReadLine();


            // method overriding
            Console.WriteLine("\n\n--------------Method overriding--------------------");
            Dog dog = new Dog();
            dog.Walk();

            Console.WriteLine("\n\n-------Method overriding (base class constructor)--------");
            Page p = new Page();
            Console.ReadLine();


            // ploymorphism
            Console.WriteLine("\n\n-----------------Ploymorphism-----------------");
            Friends fr = new Friends();
            Naruto na = new Naruto();

            Series[] ser = { fr, na };
            foreach (Series s in ser)
            {
                s.Cast();
            }

            //Series s;
            //s = new Series();
            //s.Cast();
            //s = new Friends();
            //s.Cast();
            //s = new Naruto();
            //s.Cast();
            Console.ReadLine();


            // abstract
            Console.WriteLine("\n\n-----------------Abstraction-----------------");
            Country c;
            c = new India();
            c.State();
            c = new US();
            c.State();
            Console.ReadLine();


            // interface
            Console.WriteLine("\n\n-----------------Interface-----------------");
            Chocolate choco;
            choco = new Dark();
            choco.Cocoa();
            choco = new Milk();
            choco.Cocoa();
            Console.ReadLine();


            // encapsulation
            Console.WriteLine("\n\n-----------------Encapsulation-----------------");
            Students st = new Students();
            st.ID = "1";
            st.Name = "Misari";
            st.Standard = "7th";

            Console.WriteLine("ID = " + st.ID);
            Console.WriteLine("Name = " + st.Name);
            Console.WriteLine("Standard = " + st.Standard);
            Console.ReadLine();


            // exception handling (try-catch)
            Console.WriteLine("\n\n-----------------Exception handling-----------------");
            try
            {
                int start = 5;
                int end = 0;
                int div = start / end;
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                Console.Write("\n\nFinalyyyyyyyyyyyyyyyyyyyyyyyy");
            }
            Console.Write("\nNext stage");
            Console.ReadLine();


            // user defined exception
            Console.WriteLine("\n\n-----------------User defined exception-----------------");
            try
            {
                Console.Write("Enter any positive number to check whether it gives exception or not :");
                int any = Convert.ToInt32(Console.ReadLine());
                Okay(any);
            }
            catch (MyException e)
            {
                Console.Write(e);
            }
            Console.Write("\nContinue.........");
            Console.ReadLine();


            // checked and unchecked
            Console.WriteLine("\n\n-----------------Checked and Unchecked-----------------");

            // without using checkced
            int h = int.MaxValue;
            Console.Write("Without using checked : " + (h + 10));

            //// using checked
            //checked
            //{
            //    int h1 = int.MaxValue;
            //    Console.Write(h1 + 10);
            //}

            // using unchecked
            unchecked
            {
                int h2 = int.MaxValue;
                Console.Write("\nUsing unchecked : " + (h2 + 2));
            }
            Console.ReadLine();


            // system exception
            Console.WriteLine("\n\n-----------------SystemException-----------------");
            try
            {
                string[] arr = new string[5];
                arr[10] = "Good Morning";
            }
            catch (SystemException e)
            {
                Console.Write(e);
            }
            Console.ReadLine();


            // collection
            // 1. list<>
            Console.WriteLine("\n\n------------------------Collection-------------------");
            Console.Write("\n---1. List---\n");
            List<string> l = new List<string> { "Kakashi Hatake", "Minato Namikaze", "Naruto Uzumaki", "Chandler Bing", "Phoebe Buffay" };
            l.Add("Kakashi Hatake");
            //l.Add("Minato Namikaze");
            //l.Add("Naruto Uzumaki");
            //l.Add("Chandler Bing");
            //l.Add("Phoebe Buffay");
            //l.Remove("Minato Namikaze");

            for (int i = 0; i < l.Count; i++)
            {
                string s = l[i];
                Console.WriteLine(s);
            }
            Console.ReadLine();
          

            // 2. hashset<>
            Console.Write("\n---2. HashSet---\n");
            HashSet<float> Hash = new HashSet<float> { 4.5f, 9f, 7894.4f, 9f };

            foreach(float val in Hash)
            {
                Console.WriteLine(val);
            }
            Console.ReadLine();


            // 3. sortedset<>
            Console.Write("\n---3. SortedSet---\n");
            SortedSet<int> sorted = new SortedSet<int> { 85, 843, 256, 9, 27, 08, 345, 85, 9 };
            
            foreach(int val in sorted)
            {
                Console.WriteLine(val);
            }
            Console.ReadLine();


            // 4. stack<>
            Console.Write("\n---4. Stack---\n");
            Stack<int> stacked = new Stack<int>();
            stacked.Push(5);
            stacked.Push(43);
            stacked.Push(3);
            stacked.Push(9023);
            stacked.Push(12);
            stacked.Push(3);

            Console.Write("Values in stack : ");
            foreach(int val in stacked)
            {
                Console.Write(val + " ");
            }

            Console.Write("\n\nLast element in stack : " + stacked.Peek());
            Console.Write("\nElement poped from stack : " + stacked.Pop() + "\n");
            Console.ReadLine();


            // 5. queue<>
            Console.Write("\n---5. Queue---\n");
            Queue<string> q = new Queue<string>();
            q.Enqueue("Kakashi Hatake");
            q.Enqueue("Minato Namikaze");
            q.Enqueue("Naruto Uzumaki");
            q.Enqueue("Chandler Bing");
            q.Enqueue("Phoebe Buffay");

            foreach(string val in q)
            {
                Console.WriteLine(val);
            }
            Console.Write("\nFirst element in queue : " + q.Peek());
            Console.Write("\nElement poped from queue : " + q.Dequeue() + "\n");
            Console.ReadLine();


            // 6. linkedlist<>
            Console.Write("\n---6. LinkedList---\n");
            LinkedList<string> llist = new LinkedList<string>();
            llist.AddLast("Kakashi Hatake");
            llist.AddLast("Minato Namikaze");
            llist.AddFirst("Chandler Bing");
            llist.AddLast("Kakashi Hatake");

            LinkedListNode<string> node = llist.Find("Kakashi Hatake");
            llist.AddBefore(node, "Phoebe Buffay");
            llist.AddAfter(node, "Naruto Uzumaki");
            //llist.RemoveLast();
            
            foreach (string val in llist)
            {
                Console.WriteLine(val);
            }          
            Console.ReadLine();


            // 7. dictionary<>
            Console.Write("\n---7. Dictionary---\n");
            Dictionary<int, string> dict = new Dictionary<int, string> { { 3, "Peter" }, { 1, "Emma" }, { 2, "Ross" }, { 4, "Misari" } };
            dict.Add(5, "Emma");
            dict.Remove(2);           
            
            foreach(KeyValuePair<int, string> val in dict)
            {
                //Console.WriteLine(val);
                Console.WriteLine(val.Key + " " + val.Value);
            }
            Console.ReadLine();


            // 8. sorteddictionary<>
            Console.Write("\n---8. SortedDictionary---\n");
            SortedDictionary<int, string> sdict = new SortedDictionary<int, string> { { 2, "Ross" }, { 3, "Peter" }, { 1, "Emma" },  { 5, "Emma" }, { 4, "Misari" } };
            sdict.Remove(5);
            
            foreach(KeyValuePair<int, string> val in sdict)
            {
                Console.WriteLine(val.Key + " " + val.Value);
            }
            Console.ReadLine();


            // 9. sortedlist<>
            Console.Write("\n---9. SortedList---\n");
            SortedList<int, string> sl = new SortedList<int, string> { { 2, "Ram" }, { 1, "Krishna" }, { 4, "Sita" }, { 3, "Laxmi" } };

            foreach(KeyValuePair<int, string> val in sl)
            {
                Console.WriteLine(val.Key + " " + val.Value);
            }
            Console.ReadLine();
        }
    }
}

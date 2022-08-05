using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    class Program
    {
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
                Console.Write("\n\nThis statement is of Finally");
            }
            Console.Write("\nContinue clicking enter...");
            Console.ReadLine();


            // user defined exception
            Console.WriteLine("\n\n-----------------User defined exception-----------------");
            try
            {
                Console.Write("\nEnter any positive number to check whether it gives exception or not :");
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
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {

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

            foreach (float val in Hash)
            {
                Console.WriteLine(val);
            }
            Console.ReadLine();


            // 3. sortedset<>
            Console.Write("\n---3. SortedSet---\n");
            SortedSet<int> sorted = new SortedSet<int> { 85, 843, 256, 9, 27, 08, 345, 85, 9 };

            foreach (int val in sorted)
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
            foreach (int val in stacked)
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

            foreach (string val in q)
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

            foreach (KeyValuePair<int, string> val in dict)
            {
                //Console.WriteLine(val);
                Console.WriteLine(val.Key + " " + val.Value);
            }
            Console.ReadLine();


            // 8. sorteddictionary<>
            Console.Write("\n---8. SortedDictionary---\n");
            SortedDictionary<int, string> sdict = new SortedDictionary<int, string> { { 2, "Ross" }, { 3, "Peter" }, { 1, "Emma" }, { 5, "Emma" }, { 4, "Misari" } };
            sdict.Remove(5);

            foreach (KeyValuePair<int, string> val in sdict)
            {
                Console.WriteLine(val.Key + " " + val.Value);
            }
            Console.ReadLine();


            // 9. sortedlist<>
            Console.Write("\n---9. SortedList---\n");
            SortedList<int, string> sl = new SortedList<int, string> { { 2, "Ram" }, { 1, "Krishna" }, { 4, "Sita" }, { 3, "Laxmi" } };

            foreach (KeyValuePair<int, string> val in sl)
            {
                Console.WriteLine(val.Key + " " + val.Value);
            }
            Console.ReadLine();
        }
    }
}

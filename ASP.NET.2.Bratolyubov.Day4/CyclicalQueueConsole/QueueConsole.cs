using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using СyclicalQueueLibrary;

namespace CyclicalQueueConsole
{
    class QueueConsole
    {
        static void Main(string[] args)
        {
            СyclicalQueue<int> ar = new СyclicalQueue<int>();
            int i;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Delete");
                Console.WriteLine("3. Clear");
                Console.WriteLine("4. Show");
                Console.WriteLine("5. Contains");
                Console.WriteLine("\n0. Exit");
                Console.Write("\n> ");

                i = IntInput(0, 5);

                Console.Clear();

                if (i == 1)
                {
                    Console.Write("> ");
                    ar.Enqueue(IntInput());
                }
                if (i == 2)
                    ar.Dequeue();
                if (i == 3)
                    ar.Clear();
                if (i == 4)
                {
                    foreach (int a in ar)
                        Console.WriteLine(a);

                    Console.ReadKey();
                }
                if(i==5)
                {
                    Console.Write("> ");
                    Console.WriteLine(ar.Contains(IntInput()));
                    Console.ReadKey();
                }
            }


        }

        public static int IntInput(int from, int to)
        {
            int t;
            while (true)
            {
                try
                {
                    t = Convert.ToInt32(Console.ReadLine());
                    if (t < from || t > to)
                        throw new Exception();
                    break;
                }
                catch (Exception ex)
                {
                    Console.Write("Error! Wrong input. Try again\n>");
                }
            }
            return t;
        }

        public static int IntInput()
        {
            int t;
            while (true)
            {
                try
                {
                    t = Convert.ToInt32(Console.ReadLine());

                    break;
                }
                catch (Exception ex)
                {
                    Console.Write("Error! Wrong input. Try again\n>");
                }
            }
            return t;
        }
    }
}

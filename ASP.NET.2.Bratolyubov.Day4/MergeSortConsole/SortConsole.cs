using MergeSortLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortConsole
{
    class SortConsole
    {
        static void Main(string[] args)
        {
            Console.Write("Ammount of numbers> ");
            int[] ar = new int[IntInput(2)];


            Random randNum = new Random();
            for (int i = 0; i < ar.Length; i++)
                ar[i] = randNum.Next(0, 100);
            Console.Clear();
            Console.WriteLine("Before:");
            WriteArray(ar);
            MergeMethod.Sort(ar);
            Console.WriteLine("After:");
            WriteArray(ar);
            Console.ReadKey();
        }

        public static int IntInput(int from)
        {
            int t;
            while (true)
            {
                try
                {
                    t = Convert.ToInt32(Console.ReadLine());
                    if (t < from)
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

        public static void WriteArray(int[] ar)
        {
            for (int i = 0; i < ar.Length; i++)
                Console.WriteLine(ar[i]);
        }
    }
}

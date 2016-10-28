using System;
using System.Linq;
using BubbleSortLibrary;
using System.Collections;

namespace BubbleSortConsole
{
    class BubbleSortConsole
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Write("Enter ammount of rows(2-100)> ");
            int len = IntInput(2, 100);

            int[][] ar = new int[len][];


            int j;
            Random randNum = new Random();
            for (int i = 0; i < ar.Length; i++)
            {
                ar[i] = new int[randNum.Next(2, 10)];
                for (j = 0; j < ar[i].Length; j++)
                {
                    ar[i][j] = randNum.Next(0, 99);
                }
            }

            Console.Clear();
            Console.WriteLine("Method:");
            Console.WriteLine("1. By max element");
            Console.WriteLine("2. By min element");
            Console.WriteLine("3. By sum of elements");
            Console.WriteLine("4. By max element desc");
            Console.WriteLine("5. By min element desc");
            Console.Write("6. By sum of elements desc\n>");
            int m = IntInput(1, 6);

            Console.Clear();
            Console.WriteLine("Before:");
            WriteArray(ar);
            IComparer[] methods = { BubbleMethod.ByMaxElement(), BubbleMethod.ByMinElement(), BubbleMethod.BySumOfElements(),
            BubbleMethod.ByMaxElementDesc(), BubbleMethod.ByMinElementDesc(), BubbleMethod.BySumOfElementsDesc()};
            BubbleMethod.Sort(ar, methods[m - 1]);
            Console.WriteLine("\nAfter:");
            WriteArray(ar);

            Console.Read();
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

        public static void WriteArray(int[][] ar)
        {
            int j;
            Console.WriteLine(" Min | Max | Sum");
            for (int i = 0; i < ar.Length; i++)
            {
                Console.Write("{0,4} |{1,4} |{2,4} :",ar[i].Min(), ar[i].Max(), ar[i].Sum());
                for (j = 0; j < ar[i].Length; j++)
                {
                    Console.Write("{0,3}", ar[i][j]);
                    if (j == ar[i].Length - 1)
                        Console.WriteLine();
                }
            }
        }
    }


}

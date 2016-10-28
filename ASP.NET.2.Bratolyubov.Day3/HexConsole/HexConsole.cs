using System;
using HexLibrary;

namespace HexConsole
{
    class HexConsole
    {
        static void Main(string[] args)
        {
            long num;
            IFormatProvider hexFormatter = new HexStringFormatter();
            while (true)
            {
                Console.Write("Enter number> ");
                num = IntInput();
                Console.WriteLine(string.Format(hexFormatter, "Hex: {0:H}", num));
            }
            
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

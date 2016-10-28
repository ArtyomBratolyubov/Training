using System;
using System.Collections;
using System.Linq;

[assembly: CLSCompliant(true)]
namespace BubbleSortLibrary
{
    /// <summary>
    /// Contains bubble sorting method
    /// </summary>
    public class BubbleMethod
    {
        #region private classes
        //Respresents comparator based on max element of array
        private class ArrayComparerByMaxElement : IComparer
        {
            public int Compare(object x, object y)
            {
                int[] ar1 = (int[])x;
                int[] ar2 = (int[])y;

                int m1 = ar1.Max();
                int m2 = ar2.Max();

                if (m1 > m2)
                    return 1;

                if (m1 < m2)
                    return -1;

                else
                    return 0;
            }

        }
        //Respresents comparator based on min element of array
        private class ArrayComparerByMinElement : IComparer
        {
            public int Compare(object x, object y)
            {
                int[] ar1 = (int[])x;
                int[] ar2 = (int[])y;

                int m1 = ar1.Min();
                int m2 = ar2.Min();

                if (m1 > m2)
                    return 1;

                if (m1 < m2)
                    return -1;

                else
                    return 0;
            }
        }
        //Respresents comparator based on sum of elements of array
        private class ArrayComparerBySumOFElements : IComparer
        {
            public int Compare(object x, object y)
            {
                int[] ar1 = (int[])x;
                int[] ar2 = (int[])y;

                int m1 = ar1.Sum();
                int m2 = ar2.Sum();

                if (m1 > m2)
                    return 1;

                if (m1 < m2)
                    return -1;

                else
                    return 0;
            }
        }

        //Respresents comparator based on max element of array for desc sort
        private class ArrayComparerByMaxElementDesc : IComparer
        {
            public int Compare(object x, object y)
            {
                int[] ar1 = (int[])x;
                int[] ar2 = (int[])y;

                int m1 = ar1.Max();
                int m2 = ar2.Max();

                if (m1 > m2)
                    return -1;

                if (m1 < m2)
                    return 1;

                else
                    return 0;
            }
        }
        //Respresents comparator based on min element of array for desc sort
        private class ArrayComparerByMinElementDesc : IComparer
        {
            public int Compare(object x, object y)
            {
                int[] ar1 = (int[])x;
                int[] ar2 = (int[])y;

                int m1 = ar1.Min();
                int m2 = ar2.Min();

                if (m1 > m2)
                    return -1;

                if (m1 < m2)
                    return 1;

                else
                    return 0;
            }
        }
        //Respresents comparator based on sum of elements of array for desc sort
        private class ArrayComparerBySumOFElementsDesc : IComparer
        {
            public int Compare(object x, object y)
            {
                int[] ar1 = (int[])x;
                int[] ar2 = (int[])y;

                int m1 = ar1.Sum();
                int m2 = ar2.Sum();

                if (m1 > m2)
                    return -1;

                if (m1 < m2)
                    return 1;

                else
                    return 0;
            }
        }

        #endregion

        #region public metods

        /// <summary>
        /// Sorts the array using bubble method
        /// </summary>
        /// <param name="array">Two-dimensional array to sort</param>
        /// <param name="comparer">Comparer object implementing sorting method</param>
        public static void Sort(int[][] array,IComparer comparer)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (comparer == null)
                throw new ArgumentNullException("comparer");
            for (int i = 0; i < array.Length; i++)
                if (array[i] == null)
                    throw new ArgumentNullException(string.Format("array[{0}]", i));

            SortHelper(array,comparer);
        }

        /// <summary>
        /// Returns new instance of array comparer(by max element in array)
        /// </summary>
        /// <returns>ArrayComparerByMaxElement object</returns>
        public static IComparer ByMaxElement()
        {
            return new ArrayComparerByMaxElement();
        }
        /// <summary>
        /// Returns new instance of array comparer(by min element in array)
        /// </summary>
        /// <returns>ArrayComparerByMinElement object</returns>
        public static IComparer ByMinElement()
        {
            return new ArrayComparerByMinElement();
        }
        /// <summary>
        /// Returns new instance of array comparer(by sum of element in array)
        /// </summary>
        /// <returns>ArrayComparerBySumOFElements object</returns>
        public static IComparer BySumOfElements()
        {
            return new ArrayComparerBySumOFElements();
        }
        /// <summary>
        /// Returns new instance of array comparer for desc sorting(by max element in array)
        /// </summary>
        /// <returns>ArrayComparerByMaxElement object</returns>
        public static IComparer ByMaxElementDesc()
        {
            return new ArrayComparerByMaxElementDesc();
        }
        /// <summary>
        /// Returns new instance of array comparer for desc sorting(by min element in array)
        /// </summary>
        /// <returns>ArrayComparerByMinElement object</returns>
        public static IComparer ByMinElementDesc()
        {
            return new ArrayComparerByMinElementDesc();
        }
        /// <summary>
        /// Returns new instance of array comparer for desc sorting(by max element in array)
        /// </summary>
        /// <returns>ArrayComparerByMaxElement object</returns>
        public static IComparer BySumOfElementsDesc()
        {
            return new ArrayComparerBySumOFElementsDesc();
        }

        #endregion

        #region private methods
        /// <summary>
        /// Implementation of bubble sorting method
        /// </summary>
        /// <param name="ar">wo-dimensional array to sort</param>
        /// <param name="comparer">Comparer object implementing sorting method</param>
        private static void SortHelper(int[][] ar,IComparer comparer)
        {
            int i, j;
            int[] temp;

            for (i = ar.Length - 1; i > 0; i--)
            {
                for (j = 0; j < i; j++)
                {
                    if (comparer.Compare(ar[j],ar[j+1])==1)
                    {
                        temp = ar[j];
                        ar[j] = ar[j + 1];
                        ar[j + 1] = temp;
                    }
                }
            }
        }
        #endregion
    }
}

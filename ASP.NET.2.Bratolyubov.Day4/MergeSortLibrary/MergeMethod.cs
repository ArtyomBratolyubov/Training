using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortLibrary
{
    /// <summary>
    /// Contains merge sort method
    /// </summary>
    public static class MergeMethod
    {
        #region public methods
        /// <summary>
        /// Sorts the array using merge method
        /// </summary>
        /// <param name="array">Array of int's</param>
        public static void Sort(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException("array");

            SortHelper(array);
        }

        #endregion

        #region private methods

        //Runs the sorting process
        private static void SortHelper(int[] a)
        {
            int[] tmpArray = new int[a.Length];

            mergeSort(a, tmpArray, 0, a.Length - 1);
        }

        //Recursive method of merge sorting
        private static void mergeSort(int[] a, int[] tmpArray, int left, int right)
        {
            if (left < right)
            {
                int center = (left + right) / 2;

                mergeSort(a, tmpArray, left, center);
                mergeSort(a, tmpArray, center + 1, right);
                merge(a, tmpArray, left, center + 1, right);
            }
        }

        //Merges two arrays
        private static void merge(int[] a, int[] tmpArray, int leftPos, int rightPos, int rightEnd)
        {
            int leftEnd = rightPos - 1;
            int tmpPos = leftPos;
            int numElements = rightEnd - leftPos + 1;

            while (leftPos <= leftEnd && rightPos <= rightEnd)
                if (a[leftPos] <= a[rightPos])
                    tmpArray[tmpPos++] = a[leftPos++];
                else
                    tmpArray[tmpPos++] = a[rightPos++];

            while (leftPos <= leftEnd)
                tmpArray[tmpPos++] = a[leftPos++];

            while (rightPos <= rightEnd)
                tmpArray[tmpPos++] = a[rightPos++];

            for (int i = 0; i < numElements; i++, rightEnd--)
                a[rightEnd] = tmpArray[rightEnd];

        }

        #endregion
    }
}

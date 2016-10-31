using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СyclicalQueueLibrary
{
    /// <summary>
    /// Implements an enumerator for a Сyclical Queue
    /// </summary>
    /// <typeparam name="T">Any type</typeparam>
    internal class СyclicalQueueEnumerable<T> : IEnumerator<T>
    {
        #region private fields
        private T[] ar;

        private int position;
        private int head;
        private int index;
        private int count;

        #endregion

        #region public methods
        /// <summary>
        /// Initializes a new instance of the enumerator 
        /// </summary>
        /// <param name="ar">Queue array</param>
        /// <param name="head">Head postion</param>
        /// <param name="count">Number of elements in array</param>
        public СyclicalQueueEnumerable(T[] ar, int head, int count)
        {
            this.ar = ar;
            position = -1;
            this.head = head;
            index = 0;
            this.count = count;
        }

        /// <summary>
        /// Returns current element of the queue
        /// </summary>
        public T Current
        {
            get
            {
                try
                {
                    return ar[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {

        }

        /// <summary>
        /// Makes a transition to the next element in queue
        /// </summary>
        /// <returns>True if there is more elements, otherwise false</returns>
        public bool MoveNext()
        {
            if (index == count)
                return false;

            if (position == -1)
                position = head;
            else
                position++;

            if (position == ar.Length)
                position = 0;
            index++;
            return true;
        }

        /// <summary>
        /// Resest the position of the enumerator
        /// </summary>
        public void Reset()
        {
            position = -1;
            index = 0;
        }

        #endregion
    }

    /// <summary>
    /// Represents queue based on cyclical array
    /// </summary>
    /// <typeparam name="T">Any type</typeparam>
    public class СyclicalQueue<T> : IEnumerable<T>
    {
        #region private fields
        private T[] ar;

        private int head;
        private int tail;
        private int capacity;

        private int count;
        #endregion

        #region public properties

        /// <summary>
        /// The ammount of objects in queue
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the queue class that is empty and has the default initial capacity
        /// </summary>
        public СyclicalQueue()
        {
            capacity = 8;
            Clear();
        }

        /// <summary>
        /// Initializes a new instance of the queue class thatis empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The initial number of elements that the queue contain</param>
        public СyclicalQueue(int capacity)
        {
            this.capacity = capacity;
            Clear();
        }

        #endregion

        #region public methods
        /// <summary>
        /// Adds an object to the end of the queue
        /// </summary>
        /// <param name="ob">The object to add </param>
        public void Enqueue(T ob)
        {
            if (tail == head & count != 0)
                ExtendArray();

            ar[tail] = ob;
            tail++;

            if (tail == ar.Length)
                tail = 0;

            count++;
        }

        /// <summary>
        /// Removes and returns the object at the beginning of queue
        /// </summary>
        /// <returns>The object that is removed from the beginning</returns>
        public T Dequeue()
        {
            if (count == 0)
                throw new InvalidOperationException();

            int t = head;

            head++;

            if (head == ar.Length)
                head = 0;

            count--;

            return ar[t];
        }

        /// <summary>
        /// Returns the object at the beginning of the queue without removing it
        /// </summary>
        /// <returns>The object at the beginning</returns>
        public T Peek()
        {
            return ar[head];
        }

        /// <summary>
        /// Removes all objects from the queue
        /// </summary>
        public void Clear()
        {
            ar = new T[capacity];
            count = 0;
            head = 0;
            tail = 0;
        }

        /// <summary>
        /// Determines whether an element is in the queue
        /// </summary>
        /// <param name="ob">The object to locate in the queue</param>
        /// <returns>true if item is found in the queue otherwise, false</returns>
        public bool Contains(T ob)
        {
            if (ob == null)
                throw new ArgumentNullException("ob");

            foreach (T o in this)
                if (ob.Equals(o))
                    return true;

            return false;
        }

        /// <summary>
        /// Enumerates the elements of a queue
        /// </summary>
        /// <returns>New</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new СyclicalQueueEnumerable<T>(ar, head, count);
        }

        #endregion

        #region private methods

        private void ExtendArray()
        {
            T[] newAr = new T[ar.Length * 2];

            for (int i = 0; i < ar.Length; i++, head++)
            {
                if (head == ar.Length)
                    head = 0;
                newAr[i] = ar[head];
            }
            head = 0;
            tail = ar.Length;
            ar = newAr;

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}

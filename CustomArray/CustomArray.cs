using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomArray
{
    public class CustomArray<T> : IEnumerable<T>
    {
        /// <summary>
        /// Should return first index of array
        /// </summary>
        private int first;
        public int First
        {
            get => this.first;
            private set => this.first = value;
        }

        /// <summary>
        /// Should return last index of array
        /// </summary>
        public int Last
        {
            get => this.First + this.Length - 1;
        }

        /// <summary>
        /// Should return length of array
        /// <exception cref="ArgumentException">Thrown when value was smaller than 0</exception>
        /// </summary>
        private int length;
        public int Length
        {
            get => this.length;
            private set => length = value;
        }

        /// <summary>
        /// Should return array 
        /// </summary>
        private T[] array;
        public T[] Array
        {
            get => array;
            set
            {
                array = value;
            }
        }


        /// <summary>
        /// Constructor with first index and length
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="length">Length</param>         
        public CustomArray(int first, int length)
        {
            if (length <= 0) throw new ArgumentException(nameof(Length), "Error");
            else
            {
                this.first = first;
                this.length = length;
                this.array = new T[length];
            }
        }


        /// <summary>
        /// Constructor with first index and collection  
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="list">Collection</param>
        ///  <exception cref="NullReferenceException">Thrown when list is null</exception>
        /// <exception cref="ArgumentException">Thrown when count is smaler than 0</exception>
        public CustomArray(int first, IEnumerable<T> list)
        {
            if (list is null)
            {
                NullReferenceException e = new NullReferenceException("list is null");
                throw e;
            }
            else
            {
                if (list.Count() <= 0) throw new ArgumentException(nameof(list), "Error");
                this.array = list.ToArray();
                this.First = first;
                this.Length = array.Length;
            }
        }

        /// <summary>
        /// Constructor with first index and params
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="list">Params</param>
        ///  <exception cref="ArgumentNullException">Thrown when list is null</exception>
        /// <exception cref="ArgumentException">Thrown when list without elements </exception>
        public CustomArray(int first, params T[] list)
        {
            if (list is null) throw new ArgumentNullException(nameof(list), "Error");
            else
            {
                if (list.Count() == 0) throw new ArgumentException(nameof(list), "Error");
                this.array = list;
                this.First = first;
                this.Length = list.Count();
            }
        }

        /// <summary>
        /// Indexer with get and set  
        /// </summary>
        /// <param name="item">Int index</param>        
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown when index out of array range</exception> 
        /// <exception cref="ArgumentNullException">Thrown in set  when value passed in indexer is null</exception>
        public T this[int item]
        {
            get
            {
                if (item < this.First || item > this.First + this.Length) throw new ArgumentException(nameof(item), "Error");
                else return Array[item - this.First];
            }
            set
            {
                if (value is null) throw new ArgumentNullException(nameof(value), "Error");
                else if (item >= this.First + this.Length || item < this.First) throw new ArgumentException(nameof(value), "Error");
                else Array[item - this.First] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Array.GetEnumerator();
        }
    }
}

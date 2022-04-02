using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListLibrary
{
    public class MyCustomList <T> : IEnumerable<T>
    {
        private T[] _storage { get; set; }
        public int Count { get; set; }

        public T this[int Index]
        {
            get
            {
                if(Index < Count)
                {
                    return _storage[Index];
                }
                throw new Exception();
            }

            set
            {
                if (Index < Count)
                {
                    _storage[Index] = value;
                }
                throw new Exception();
            }

        }

        
        /// <summary>
        /// The total number of available slots in the array
        /// </summary>
        private int _capacity;
        public int Capacity
        {
            get
            {
                return _capacity;
            }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("Index was out of range. Must be non-negative and less than the size of the collection.");
                _capacity = value;
            }
        }

        public MyCustomList():this(2)
        {

        }

        public MyCustomList(int newCapacity)
        {
            Capacity = newCapacity;
            _storage = new T[newCapacity];
        }

        /// <summary>
        /// to add an item to My list
        /// </summary>
        /// <param name="item">İtem to be added</param>
        public void Add(T item)
        {
            if (Count == Capacity)
            {
                Resize();
            }
            _storage[Count] = item;
            Count++;
        }


        /// <summary>
        /// Inserts an element into the CustomLibrary.Collections.CustomList`1 at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        public void Insert(int index, T item)
        {
            ThrowIfIndexOutOfRange(index);

            if (Count == Capacity)
            {
                Resize();
            }

            for (int i = Count; i > index; i--)
            {
                _storage[i] = _storage[i - 1];
            }

            _storage[index] = item;
            Count++;
        }


        /// <summary>
        /// Doubles the size of our CustomLibrary.Collections.CustomList`1
        /// </summary>
        public void Resize()
        {
            T[] resizedList = new T[Capacity + 10];
            for (int i = 0; i < Capacity; i++)
            {
                resizedList[i] = _storage[i];
            }

            _storage = resizedList;
            Capacity += 10;
        }

        /// <summary>
        /// to delete all items from the my list
        /// </summary>
        public void Clear()
        {
            _storage = new T[Capacity];
            Count = 0;
        }

        /// <summary>
        /// Determines whether an element is in the CustomLibrary.Collections.CustomList`1
        /// </summary>
        /// <param name="item">yoxlanilacaq item</param>
        /// <returns>list item i ehtiva edirse true etmirse false </returns>
        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_storage[i].Equals(item))
                {
                    return true;
                }
            }
            return false;

        }

        /// <summary>
        /// list daxilinde gonderilen Item a ilk rast gelindiydeki indexi tapir
        /// </summary>
        /// <param name="item"></param>
        /// <returns>item list de varsa ilk rasladiqindaki indexi qaytarir yoxdusa -1 qaytarir </returns>
        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_storage[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// list daxilinde gonderilen Item a son rast gelindiydeki indexi tapir
        /// </summary>
        /// <param name="item"></param>
        /// <returns> item list de varsa son rasladiqindaki indexi qaytarir yoxdusa -1 qaytarir </returns>
        public int LastIndexOf(T item)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                if (_storage[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Reverses the order of the elements in the entire CustomLibrary.Collections.CustomList`1
        /// </summary>
        public void Reverse()
        {
            T swap;

            for (int i = 0; i*i < Count; i++)
            {
                swap = _storage[i];
                _storage[i] = _storage[Count - i - 1];
                _storage[Count - i - 1] = swap;

            }
        }


        /// <summary>
        /// Searches for an element that matches the conditions
        /// </summary>
        /// <param name="match">a representative who determines the conditions of the element to be searched.</param>
        /// <returns> The first element that meets the specified conditions </returns>
        public T Find(Predicate<T> match)
        {

            for (int i = 0; i < Count; i++)
            {
                if (match(_storage[i]))
                {
                    return _storage[i];
                }
            }

            return default(T);

        }


        /// <summary>
        /// Receives all elements that meet the specified conditions predicate.
        /// </summary>
        /// <param name="match">The representative who determines the conditions of the elements look for.</param>
        /// <returns> </returns>
        public MyCustomList<T> FindAll(Predicate<T> match)
        {

            MyCustomList<T> items = new MyCustomList<T>();
            for (int i = 0; i < Count; i++)
            {
                if (match(_storage[i]))
                {
                    items.Add(_storage[i]);
                }
            }
            return items;

        }

        /// <summary>
        /// Throw if index out range
        /// </summary>
        /// <param name="index"></param>
        private void ThrowIfIndexOutOfRange(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("Index out of range");
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _storage[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

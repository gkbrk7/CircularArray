using System;
using System.Collections;

namespace CircularArrayImplementation.DataStructures
{
    public class CircularArray<T> : IEnumerable, IEnumerator
    {
        private T[] _array;
        private T[] _tempArray;
        private int Position = -1;
        public CircularArray()
        {
            _array = new T[0];
        }

        // Additional Length Definition for Array
        // public CircularArray(int length)
        // {
        //     if (length > 0)
        //         _array = new T[length];
        //     else
        //         _array = new T[0];
        // }
        public T this[int index]
        {
            get { return _array[index % _array.Length]; }
            set { _array[index % _array.Length] = value; }
        }

        /// <summary>
        /// Prints all n element (in order) starting from the given index
        /// It works very well with primitive data types. It also works with objects but you cannot see their properties you can only see as an object output
        /// </summary>
        /// <param name="index"></param>
        [ObsoleteAttribute("This method is reserved just only for testing purposes.", true)]
        public void SortByIndex(int index)
        {
            for (int i = index; i < _array.Length + index; i++)
            {
                System.Console.Write(_array[i % _array.Length] + " ");
            }
        }

        /// <summary>
        /// Add item to array
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(T item)
        {
            _tempArray = _array;
            _array = new T[_array.Length + 1];
            for (int i = 0; i < _tempArray.Length; i++)
            {
                _array[i] = _tempArray[i];
            }
            _array[_array.Length - 1] = item;
        }

        public void AddRange(params T[] items)
        {
            _tempArray = _array;
            _array = new T[_array.Length + items.Length];
            for (int i = 0; i < _tempArray.Length; i++)
            {
                _array[i] = _tempArray[i];
            }
            for (int i = _tempArray.Length; i < _array.Length; i++)
            {
                _array[i] = items[i - _tempArray.Length];
            }

        }

        /// <summary>
        /// Removes element from the list by given index
        /// /// </summary>
        /// <param name="index"></param>
        public void RemoveItem(int index)
        {
            try
            {
                // Guarantee that the index is inside the array length
                index = index % _array.Length;
                _tempArray = _array;
                _array = new T[_array.Length - 1];
                int j = 0;
                for (int i = 0; i < _tempArray.Length; i++)
                {
                    if (i == index)
                    {
                        continue;
                    }
                    else
                    {
                        _array[j] = _tempArray[i];
                        j++;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }

        public bool MoveNext()
        {
            if (Position < _array.Length - 1)
            {
                ++Position;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            Position = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        /// <summary>
        /// Perform left rotation of array by specific count
        /// This algorithm provides O(n * count) time complexity and auxiliary space complexity O(d) where storing the first d elements in a temp array. 
        /// </summary>
        /// <param name="count">Specify the position to shift each element by count</param>
        public void LeftRotate(int count)
        {
            T element;
            for (int i = 0; i < count; i++)
            {
                element = _array[0];
                for (int j = 1; j < _array.Length; j++)
                {
                    _array[j - 1] = _array[j];
                }
                _array[_array.Length - 1] = element;
            }
        }

        /// <summary>
        /// Perform right rotation of array by specific count
        /// This algorithm provides O(n * count) time complexity and auxiliary space complexity O(d) where storing the first d elements in a temp array. In this case auxiliary space complexity is O(1)
        /// </summary>
        /// <param name="count">Specify the position to shift each element by count</param>
        public void RightRotate(int count)
        {
            T element;
            for (int i = 0; i < count; i++)
            {
                element = _array[_array.Length - 1];
                for (int j = _array.Length - 1; j > 0; j--)
                {
                    _array[j] = _array[j - 1];
                }
                _array[0] = element;
            }
        }

        /// <summary>
        /// Reversal Algorithm for efficient rotation of an array. Specify the count to rotate each element in the array.
        /// This algorithm provides O(n) time complexity and auxiliary space complexity O(1).
        /// Assume array rotation direction is right.
        /// </summary>
        public void ReversalRotate(int count)
        {
            int subLength = _array.Length - count;
            T temp;
            for (int i = 0; i < subLength / 2; i++)
            {
                temp = _array[i];
                _array[i] = _array[subLength - 1 - i];
                _array[subLength - 1 - i] = temp;
            }
            for (int i = subLength; i < (subLength + count / 2); i++)
            {
                temp = _array[i];
                _array[i] = _array[i + 1];
                _array[i + 1] = temp;
            }
            for (int i = 0; i < _array.Length / 2; i++)
            {
                temp = _array[i];
                _array[i] = _array[_array.Length - 1 - i];
                _array[_array.Length - 1 - i] = temp;
            }
        }

        /// <summary>
        /// This algorithm extends one by one rotation by dividing array into sub-arrays with respect to greatest common divisor of rotation count and the number of elements inside the array. 
        /// This algorithm provides O(n) time complexity and auxiliary space complexity O(1).
        /// Assume array rotation direction is left.
        /// </summary>
        public void JugglingRotate(int count)
        {
            int j, k;
            int gcd = GCD(_array.Length, count);
            T temp;
            for (int i = 0; i < gcd; i++)
            {
                temp = _array[i];
                j = i;
                while (true)
                {
                    k = j + count;
                    if (k >= _array.Length)
                        k = k - _array.Length;
                    if (k == i)
                        break;
                    _array[j] = _array[k];
                    j = k;
                }
                _array[j] = temp;
            }
        }

        private int GCD(int length, int count)
        {
            if (count == 0)
                return length;
            else
                return GCD(count, length % count);
        }

        public int Length => _array.Length;

        public object Current => _array[Position];

    }
}
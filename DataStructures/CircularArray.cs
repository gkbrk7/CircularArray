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
        public CircularArray(int length)
        {
            if (length > 0)
                _array = new T[length];
            else
                _array = new T[0];
        }
        public T this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }

        /// <summary>
        /// Prints all n element (in order) starting from the given index
        /// /// </summary>
        /// <param name="index"></param>
        public void ListByIndex(int index)
        {
            for (int i = index; i < _array.Length + index; i++)
            {
                System.Console.Write("{0} ", _array[i % _array.Length]);
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

        public void AddRange(T[] items)
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
        /// This algorithm provides O(n) time complexity and no extra space complexity.
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

        public int Length => _array.Length;

        public object Current => _array[Position];

    }
}
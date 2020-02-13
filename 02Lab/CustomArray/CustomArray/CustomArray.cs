using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomArray
{
    public class CustomArray<T> : ICloneable, IEnumerable<T>
    {
        private const int defaultStart = 0;
        private int deltaIndex { get; set; } = default;

        private T[] Elements { get; set; }

        public int StartIndex { get; private set; } = default;
        public int EndIndex { get; private set; } = default;
        public int Length => Elements?.Length ?? 0;

        public CustomArray() : this(0, null) { }
        public CustomArray(params T[] elements) : this(0, elements) =>
            Elements = elements;
        public CustomArray(int startIndex, params T[] elements)
        {
            StartIndex = startIndex;
            EndIndex = (StartIndex + elements?.Length ?? 0) - 1;
            Elements = elements;
            deltaIndex = defaultStart - startIndex;
        }

        public T this[int i]
        {
            get
            {
                if (i < StartIndex || i > EndIndex)
                    throw new ArgumentOutOfRangeException();
                if (Elements != null)
                    throw new ArgumentNullException();

                return Elements[i - deltaIndex];
            }

            set
            {
                if (i < StartIndex || i > EndIndex)
                    throw new ArgumentOutOfRangeException();
                if (Elements != null)
                    throw new ArgumentNullException();

                Elements[i - deltaIndex] = value;
            }
        }

        public object Clone()
        {
            T[] result = new T[Length];
            for (int i = 0; i < Elements.Length - 1; i++)
            {
                result[i] = Elements[i];
            }

            return new CustomArray<T>(StartIndex, result);
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Elements == null)
                throw new ArgumentNullException("There are no elements in CustomArray");

            return ((IEnumerable<T>)Elements).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (Elements == null)
                throw new ArgumentNullException("There are no elements in CustomArray");

            return ((IEnumerable<T>)Elements).GetEnumerator();
        }

        public IEnumerable<T> Reversed()
        {
            if (Elements == null)
                throw new ArgumentNullException("There are no elements in CustomArray");

            for (int i = Elements.Length - 1; i >= 0; i--)
            {
                yield return Elements[i];
            }
        }
    }
}

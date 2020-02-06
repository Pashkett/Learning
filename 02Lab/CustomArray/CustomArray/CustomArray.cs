using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomArray
{
    public class CustomArray<T> : ICloneable, IEnumerable<T>
    {
        private int deltaIndex { get; set; } = default;

        public T[] Elements { get; private set; }
        public int StartIndex { get; private set; } = default;
        public int EndIndex { get; private set; } = default;
        public int Length => Elements.Length;

        public CustomArray() : this(0, 0, null) { }
        public CustomArray(params T[] elements) : this(0, elements.Length, elements) =>
            Elements = elements;
        public CustomArray(int startIndex, int endIndex, params T[] elements)
        {
            StartIndex = startIndex;
            EndIndex = endIndex;
            Elements = elements;
            deltaIndex = 0 - startIndex;
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

            return new CustomArray<T>(StartIndex, EndIndex, result);
        }

        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)Elements).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<T>)Elements).GetEnumerator();

        public IEnumerable<T> Reversed()
        {
            for (int i = Elements.Length - 1; i >= 0; i--)
            {
                yield return Elements[i];
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomArray
{
    public class CustomArray<T> : ICloneable, IEnumerable<T>
    {
        public T[] Elements { get; private set; }
        public int InitialIndex { get; private set; } = 0;
        public int Length
        {
            get => Elements.Length;
        }


        public CustomArray() : this(0, null) { }
        public CustomArray(params T[] elements) : this(0, elements) =>
            Elements = elements;
        public CustomArray(int startingIndex, params T[] elements)
        {
            InitialIndex = startingIndex;
            Elements = elements;
        }

        public object Clone()
        {
            T[] result = new T[Length];
            for (int i = 0; i < Elements.Length - 1; i++)
            {
                result[i] = Elements[i];
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

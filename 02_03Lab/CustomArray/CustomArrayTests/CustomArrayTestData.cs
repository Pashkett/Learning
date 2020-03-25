using CustomArray;
using System.Collections;

namespace CustomArrayTests
{
    class EndIndexTest : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { new CustomArray<string>("Hello", "World"), 1 };
            yield return new object[] { new CustomArray<string>(-1, "Hello", "World"), 0 };
            yield return new object[] { new CustomArray<string>(-12, "Hello", "World", "Now"), -10 };
            yield return new object[] { new CustomArray<int>(-100, new int[] { 1, 2, 3, 4 }), -97 };
        }
    }


    class StartIndexTest : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { new CustomArray<string>("Hello", "World"), 0 };
            yield return new object[] { new CustomArray<string>(-1, "Hello", "World"), -1 };
            yield return new object[] { new CustomArray<string>(-12, "Hello", "World", "Now"), -12 };
            yield return new object[] { new CustomArray<int>(-100, new int[] { 1, 2, 3, 4 }), -100 };
        }
    }


    class LengthTest : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { new CustomArray<string>("Hello", "World"), 2 };
            yield return new object[] { new CustomArray<string>(-1, "Hello", "World"), 2 };
            yield return new object[] { new CustomArray<string>(-12, "Hello", "World", "Now"), 3 };
            yield return new object[] { new CustomArray<int>(-100, new int[] { 1, 2, 3, 4 }), 4 };
        }
    }


    class IndexerTestData
    {
        static object[] GetIndexerOutOrRangeException =
        {
            new object[] {new CustomArray<string>("he", "llo", "wo", "rld", "!"), 5},
            new object[] {new CustomArray<int>(-1, new int[] { 1, 2, 3, 4, 5}), -2 },
            new object[] {new CustomArray<int>(-1, new int[] { 1, 2, 3, 4, 5}), -7 },
            new object[] {new CustomArray<int>(-1, new int[] { 1, 2, 3, 4, 5}), 12 },
        };

        static object[] GetIndexerNullException =
        {
            new object[] {new CustomArray<string>(), 5},
            new object[] {new CustomArray<int>(), -2 },
            new object[] {new CustomArray<int>(), -7 },
            new object[] {new CustomArray<int>(), 12 },
        };

        static object[] GetIndexerValidCases =
        {
            new object[] {new CustomArray<string>("he", "llo", "wo", "rld", "!"), 0, "he"},
            new object[] {new CustomArray<int>(-1, new int[] { 1, 2, 3, 4, 5}), 0, 2 },
            new object[] {new CustomArray<int>(-1, new int[] { 1, 2, 3, 4, 5}), -1, 1 },
            new object[] {new CustomArray<int>(-1, new int[] { 1, 2, 3, 4, 5}), 3, 5 },
        };

        static object[] SetIndexerValidCases =
        {
            new object[] {new CustomArray<string>("mm", "llo", "wo", "rld", "!"), 0, "he", "he"},
            new object[] {new CustomArray<int>(-1, new int[] { 1, 0, 3, 4, 5}), 0, 2, 2 },
            new object[] {new CustomArray<int>(-1, new int[] { 0, 2, 3, 4, 5}), -1, 1, 1 },
            new object[] {new CustomArray<int>(-1, new int[] { 1, 2, 3, 4, 0}), 3, 5, 5 },
        };
    }
}
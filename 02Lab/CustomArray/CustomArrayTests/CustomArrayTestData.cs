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
}

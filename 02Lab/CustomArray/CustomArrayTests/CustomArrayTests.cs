using NUnit.Framework;
using CustomArray;

namespace CustomArrayTests
{
    [TestFixture]
    public class Tests
    {
        [TestCaseSource(typeof(EndIndexTest))]
        public void EndIndexesTest<T>(CustomArray<T> customArray, int endIndex) => 
            Assert.AreEqual(endIndex, customArray.EndIndex);

        [TestCaseSource(typeof(StartIndexTest))]
        public void StartIndexesTest<T>(CustomArray<T> customArray, int startIndex) => 
            Assert.AreEqual(startIndex, customArray.StartIndex);

        [TestCaseSource(typeof(LengthTest))]
        public void LengthTest<T>(CustomArray<T> customArray, int length) =>
            Assert.AreEqual(length, customArray.Length);
    }
}
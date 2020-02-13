using NUnit.Framework;
using CustomArray;

namespace CustomArrayTests
{
    [TestFixture]
    public class Tests
    {
        /// <summary>
        /// Assert that "End Index" works correctly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="customArray"></param>
        /// <param name="endIndex"></param>
        [TestCaseSource(typeof(EndIndexTest))]
        public void EndIndexesTest<T>(CustomArray<T> customArray, int endIndex) => 
            Assert.AreEqual(endIndex, customArray.EndIndex);

        /// <summary>
        /// Assert that "Start Index" works correctly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="customArray"></param>
        /// <param name="startIndex"></param>
        [TestCaseSource(typeof(StartIndexTest))]
        public void StartIndexesTest<T>(CustomArray<T> customArray, int startIndex) => 
            Assert.AreEqual(startIndex, customArray.StartIndex);

        /// <summary>
        /// Assert that custom array "Length" works correctly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="customArray"></param>
        /// <param name="length"></param>
        [TestCaseSource(typeof(LengthTest))]
        public void LengthTest<T>(CustomArray<T> customArray, int length) =>
            Assert.AreEqual(length, customArray.Length);
    }
}
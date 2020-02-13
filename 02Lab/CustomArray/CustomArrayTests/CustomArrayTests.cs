using System;
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
        [TestCaseSource(typeof(EndIndexTest))]
        public void EndIndexesTest<T>(CustomArray<T> customArray, int endIndex)
        {
            Assert.AreEqual(endIndex, customArray.EndIndex);
        }

        /// <summary>
        /// Assert that "Start Index" works correctly
        /// </summary>
        [TestCaseSource(typeof(StartIndexTest))]
        public void StartIndexesTest<T>(CustomArray<T> customArray, int startIndex)
        {
            Assert.AreEqual(startIndex, customArray.StartIndex);
        }

        /// <summary>
        /// Assert that custom array "Length" works correctly
        /// </summary>
        [TestCaseSource(typeof(LengthTest))]
        public void LengthTest<T>(CustomArray<T> customArray, int length)
        {
            Assert.AreEqual(length, customArray.Length);
        }

        /// <summary>
        /// Assert that custom array returns right ArgumentOutOfRangeException
        /// </summary>
        [TestCaseSource(typeof(IndexerTestData), "GetIndexerOutOrRangeException")]
        public void GetIndexerOutOfRangeException<T>(CustomArray<T> customArray, int index)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => GetIndex(customArray, index));
        }

        /// <summary>
        /// Assert that custom array returns right ArgumentNullException
        /// </summary>
        [TestCaseSource(typeof(IndexerTestData), "GetIndexerNullException")]
        public void GetIndexerNullException<T>(CustomArray<T> customArray, int index)
        {
            Assert.Throws<ArgumentNullException>(() => GetIndex(customArray, index));
        }

        /// <summary>
        /// Assert that custom array returns right element by index
        /// </summary>
        [TestCaseSource(typeof(IndexerTestData), "GetIndexerValidCases")]
        public void GetIndexersValidCases<T>(CustomArray<T> customArray, int index, T validValue)
        {
            Assert.AreEqual(validValue, GetIndex(customArray, index));
        }

        /// <summary>
        /// Assert that custom array returns right element by index
        /// </summary>
        [TestCaseSource(typeof(IndexerTestData), "SetIndexerValidCases")]
        public void SetIndexersValidCases<T>(CustomArray<T> customArray, int index, T setValue, T expectedValue)
        {
            customArray[index] = setValue;
            Assert.AreEqual(expectedValue, GetIndex(customArray, index));
        }

        /// <summary>
        /// Method for testing indexers
        /// </summary>
        private T GetIndex<T>(CustomArray<T> customArray, int index) => 
            customArray[index];
    }
}
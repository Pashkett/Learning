using System;
using NUnit.Framework;
using CustomArray;


namespace CustomArrayTests
{
    [TestFixture]
    public class CustomArrayTests
    {
        /// <summary>
        /// Assert that "End Index" works correctly
        /// </summary>
        [TestCaseSource(typeof(EndIndexTest))]
        public void Property_GetEndIndex_ValidCases<T>(CustomArray<T> customArray, int endIndex)
        {
            Assert.AreEqual(endIndex, customArray.EndIndex);
        }

        /// <summary>
        /// Assert that "Start Index" works correctly
        /// </summary>
        [TestCaseSource(typeof(StartIndexTest))]
        public void Property_GetStartIndex_ValidCases<T>(CustomArray<T> customArray, int startIndex)
        {
            Assert.AreEqual(startIndex, customArray.StartIndex);
        }

        /// <summary>
        /// Assert that custom array "Length" works correctly
        /// </summary>
        [TestCaseSource(typeof(LengthTest))]
        public void Property_GetLength_ValidCases<T>(CustomArray<T> customArray, int length)
        {
            Assert.AreEqual(length, customArray.Length);
        }

        /// <summary>
        /// Assert that custom array returns right ArgumentOutOfRangeException
        /// </summary>
        [TestCaseSource(typeof(IndexerTestData), "GetIndexerOutOrRangeException")]
        public void Indexer_GetIndex_OutOfRangeException<T>(CustomArray<T> customArray, int index)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => customArray[index].ToString());
        }

        /// <summary>
        /// Assert that custom array returns right ArgumentNullException
        /// </summary>
        [TestCaseSource(typeof(IndexerTestData), "GetIndexerNullException")]
        public void Indexer_GetIndex_NullException<T>(CustomArray<T> customArray, int index)
        {
            Assert.Throws<ArgumentNullException>(() => customArray[index].ToString());
        }

        /// <summary>
        /// Assert that custom array returns right element by index
        /// </summary>
        [TestCaseSource(typeof(IndexerTestData), "GetIndexerValidCases")]
        public void Indexer_GetIndex_ValidCase<T>(CustomArray<T> customArray, int index, T validValue)
        {
            Assert.AreEqual(validValue, customArray[index]);
        }

        /// <summary>
        /// Assert that custom array returns right element by index
        /// </summary>
        [TestCaseSource(typeof(IndexerTestData), "SetIndexerValidCases")]
        public void Inexer_SetIndex_ValidCases<T>(CustomArray<T> customArray, int index, T setValue, T expectedValue)
        {
            customArray[index] = setValue;

            Assert.AreEqual(expectedValue, customArray[index]);
        }
    }
}
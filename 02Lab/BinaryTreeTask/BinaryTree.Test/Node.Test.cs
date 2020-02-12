using System;
using NUnit.Framework;
using BinaryTreeTask;

namespace BinaryTree.Test
{
    [TestFixture]
    public class NodeTest
    {
        /// <summary>
        /// Assert that "Less Than" operator works correctly
        /// </summary>
        [TestCaseSource(typeof(NodeTestData), "LessThanCases")]
        public void LessThanOperatorTest<T>(Node<T> n1, Node<T> n2)
            where T : IComparable
        {
            bool expected = true;

            Assert.AreEqual(expected, ReturnComparisonLessThan(n1, n2));
        }

        /// <summary>
        /// Assert that "Grater Than" operator works correctly
        /// </summary>
        [TestCaseSource(typeof(NodeTestData), "GraterThanCases")]
        public void GraterThanOperatorTest<T>(Node<T> n1, Node<T> n2)
            where T : IComparable
        {
            bool expected = true;

            Assert.AreEqual(expected, ReturnComparisonGraterThan(n1, n2));
        }

        /// <summary>
        /// Assert that "Less Than" operator thows correct exception
        /// </summary>
        [TestCaseSource(typeof(NodeTestData), "CasesForExceptionsTesting")]
        public void LessThanOperatorExceptions<T>(Node<T> n1, Node<T> n2)
            where T : IComparable
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ReturnComparisonLessThan(n1, n2));

            Assert.AreEqual("Nodes should not be null.", ex.ParamName);
        }

        /// <summary>
        /// Assert that "Grater Than" operator thows correct exception
        /// </summary>
        [TestCaseSource(typeof(NodeTestData), "CasesForExceptionsTesting")]
        public void GraterThanOperatorExceptions<T>(Node<T> n1, Node<T> n2)
            where T : IComparable
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ReturnComparisonGraterThan(n1, n2));

            Assert.AreEqual("Nodes should not be null.", ex.ParamName);
        }

        private bool ReturnComparisonGraterThan<T>(Node<T> n1, Node<T> n2)
            where T : IComparable
        {
            return n1 > n2;
        }

        private bool ReturnComparisonLessThan<T>(Node<T> n1, Node<T> n2)
            where T : IComparable
        {
            return n1 < n2;
        }
    }
}
using System;
using NUnit.Framework;
using BinaryTreeTask;

namespace BinaryTree.Test
{
    [TestFixture]
    public class NodeTest
    {
        private Node<int> node1;
        private Node<int> node2;
        private Node<int> node3;


        [SetUp]
        public void Setup()
        {
            node1 = new Node<int>(1);
            node2 = new Node<int>(2);
            node3 = null;
        }

        /// <summary>
        /// Assert that Less Than operator works correctly
        /// </summary>
        [Test]
        public void LessThanOperatorTest()
        {
            bool expected = true;
            Assert.AreEqual(expected, node1 < node2);
        }

        /// <summary>
        /// Assert that Grater Than operator works correctly
        /// </summary>
        [Test]
        public void GraterThanOperatorTest()
        {
            bool expected = false;
            Assert.AreEqual(expected, node1 > node2);
        }

        /// <summary>
        /// Assert that Less Than operator thows correct exception
        /// </summary>
        [Test]
        public void LessThanOperatorExceptions()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ReturnComparisonLessThan());

            Assert.AreEqual("Nodes should not be null.", ex.ParamName);
        }

        /// <summary>
        /// Assert that Grater Than operator thows correct exception
        /// </summary>
        public void GraterThanOperatorExceptions()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ReturnComparisonGraterThan());

            Assert.AreEqual("Nodes should not be null.", ex.ParamName);
        }

        private bool ReturnComparisonGraterThan()
        {
            return node1 > node3;
        }
        
        private bool ReturnComparisonLessThan()
        {
            return node1 < node3;
        }
    }
}
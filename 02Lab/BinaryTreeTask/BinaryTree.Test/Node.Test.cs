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


        [SetUp]
        public void Setup()
        {
            node1 = new Node<int>(1);
            node2 = new Node<int>(2);
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
    }
}
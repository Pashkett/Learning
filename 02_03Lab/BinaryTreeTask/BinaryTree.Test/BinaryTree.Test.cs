using NUnit.Framework;
using BinaryTreeTask;

namespace BinaryTree.Test
{
    [TestFixture]
    public class BinaryTreeTest
    {
        private BinaryTree<int> binaryTree1;

        [SetUp]
        public void Setup()
        {
            binaryTree1 = new BinaryTree<int>();

            binaryTree1.Add(4);
            binaryTree1.Add(5);
            binaryTree1.Add(6);
            binaryTree1.Add(7);
            binaryTree1.Add(8);
            binaryTree1.Add(9);
            binaryTree1.Add(10);
        }

        /// <summary>
        /// Assert that numbers contains current values in nodes
        /// </summary>
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        public void ContainsNode_ReturnIntNode_ValidCases(int value)
        {
            var result = binaryTree1.ContainsNode(value);

            Assert.IsTrue(result, $"{value} should be true");
        }
    }
}

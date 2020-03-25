using BinaryTreeTask;

namespace BinaryTree.Test
{
    class NodeTestData
	{
        static object[] LessThanCases =
        {
            new object[] {new Node<int>(10), new Node<int>(18) },
            new object[] {new Node<int>(11), new Node<int>(12) },
            new object[] {new Node<int>(12), new Node<int>(13) },
            new object[] {new Node<double>(12.12), new Node<double>(14.001)},
            new object[] {new Node<string>("aaa"), new Node<string>("bbb") },
        };

        static object[] GraterThanCases =
        {
            new object[] {new Node<int>(10), new Node<int>(8) },
            new object[] {new Node<int>(11), new Node<int>(9) },
            new object[] {new Node<int>(12), new Node<int>(7) },
            new object[] {new Node<double>(12.12), new Node<double>(0.001)},
            new object[] {new Node<string>("bbb"), new Node<string>("aaa") },
        };

        static object[] CasesForExceptionsTesting =
        {
            new object[] {new Node<int>(10), null },
            new object[] {null, new Node<int>(12) },
            new object[] {new Node<int>(12), null },
            new object[] {null, new Node<double>(14.001)}
        };
    }
}
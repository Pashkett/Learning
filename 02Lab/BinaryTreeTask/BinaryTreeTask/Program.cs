using System;

namespace BinaryTreeTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Binary tree:");
            BinaryTree<int> tree = new BinaryTree<int>();
            Node<int> root = new Node<int>();

            tree.Insert(4);
            tree.Insert(2);
            tree.Insert(5);
            tree.Insert(1);
            tree.Insert(3);
            Console.WriteLine(tree.ToString());
        }
    }
}

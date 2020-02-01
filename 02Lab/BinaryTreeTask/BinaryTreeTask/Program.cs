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

            tree.InsertNode(4);
            tree.InsertNode(2);
            tree.InsertNode(5);
            tree.InsertNode(1);
            tree.InsertNode(3);
            
            foreach (var item in tree)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}

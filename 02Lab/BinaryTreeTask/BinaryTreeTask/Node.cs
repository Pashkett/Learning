using System;
using System.Diagnostics.CodeAnalysis;

namespace BinaryTreeTask
{
    public class Node<T> : IComparable<Node<T>>
        where T : IComparable<T>
    {
        public T Data { get; set; }
        public Node<T> NodeLeft { get; set; }
        public Node<T> NodeRight { get; set; }
        public Node() { }
        public Node(T data) => Data = data;

        public int CompareTo(Node<T> other)
        {
            if (other == null) return 1;

            return Data.CompareTo(other.Data);
        }

        public override string ToString() => Data.ToString();

        public static bool operator > (Node<T> node1, Node<T> node2)
        {
            if (node1 == null || node2 == null)
                throw new ArgumentNullException("Nodes should not be null.");

            return node1.CompareTo(node2) == 1;
        }

        public static bool operator < (Node<T> node1, Node<T> node2)
        {
            if (node1 == null || node2 == null)
                throw new ArgumentNullException("Nodes should not be null.");

            return node1.CompareTo(node2) == -1;
        }
    }
}

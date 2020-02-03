using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTreeTask
{
    public class BinaryTree<T> : IEnumerable<T>
        where T : IComparable
    {
        private Node<T> root;
        private int count;

        public int Count => count;

        public delegate void BinaryTreeHandler(string message);
        public event BinaryTreeHandler TreeClearing; 
        public event BinaryTreeHandler AddingElement;

        public BinaryTree() => root = null;

        public void InsertNode(T data)
        {
            if (root == null)
            {
                AddingElement?.Invoke($"Root element {data.ToString()} was added.");
                root = new Node<T>(data);
            }
            else
                InsertRec(root, new Node<T>(data));
        }

        private void InsertRec(Node<T> root, Node<T> newNode)
        {
            if (newNode < root)
            {
                if (root.NodeLeft == null)
                {
                    root.NodeLeft = newNode;
                    AddingElement?.Invoke($"New Left node {newNode.ToString()} element was added.");
                }
                else
                {
                    InsertRec(root.NodeLeft, newNode);
                }
            }
            else
            {
                if (root.NodeRight == null)
                {
                    root.NodeRight = newNode;
                    AddingElement?.Invoke($"New Right node {newNode.ToString()} element was added.");
                }
                else
                    InsertRec(root.NodeRight, newNode);
            }
        }
        
        public bool ContainsNode(T data)
        {
            Node<T> parentNode;
            return FindCurrentAndParent(data, out parentNode) != null;
        }

        private Node<T> FindCurrentAndParent(T data, out Node<T> parentNode)
        {
            Node<T> current = root;
            parentNode = null;
            Node<T> searchableNode = new Node<T>(data);

            while (current != null)
            {
                if (searchableNode < current)
                {
                    parentNode = current;
                    current = current.NodeLeft;
                }
                else if (searchableNode > current)
                {
                    parentNode = current;
                    current = current.NodeRight;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        public void ClearTree()
        {
            root = null;
            count = 0;
            TreeClearing?.Invoke($"Current binary tree was cleared at {DateTime.Now}");
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() =>
            BinaryTreeEnumerator();

        public IEnumerator GetEnumerator() =>
            BinaryTreeEnumerator();

        public IEnumerator<T> BinaryTreeEnumerator()
        {
            if (root != null)
            {
                Stack<Node<T>> stack = new Stack<Node<T>>();

                Node<T> current = root;
                bool goLeftNext = true;

                stack.Push(current);

                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.NodeLeft != null)
                        {
                            stack.Push(current);
                            current = current.NodeLeft;
                        }
                    }

                    yield return current.Data;

                    if (current.NodeRight != null)
                    {
                        current = current.NodeRight;
                        goLeftNext = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }
    }
}

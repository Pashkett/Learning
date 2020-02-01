using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTreeTask
{
    public class BinaryTree<T> : IEnumerable
        where T : IComparable<T>
    {
        private Node<T> root;
        private int count;

        public Node<T> Root
        {
            get => root;
        }

        public int Count
        {
            get => count;
        }

        public BinaryTree() => root = null;

        public void InsertNode(T data)
        {
            if (root == null)
                root = new Node<T>(data);
            else
                InsertRec(root, new Node<T>(data));
        }

        private void InsertRec(Node<T> root, Node<T> newNode)
        {
            //Checked in root method
            //if (root == null)
            //    root = newNode;

            if (newNode < root)
            {
                if (root.NodeLeft == null)
                    root.NodeLeft = newNode;
                else
                    InsertRec(root.NodeLeft, newNode);
            }
            else
            {
                if (root.NodeRight == null)
                    root.NodeRight = newNode;
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
        }

        public IEnumerator GetEnumerator()
        {
            return BinaryTreeEnumerator();
        }

        public IEnumerator BinaryTreeEnumerator()
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

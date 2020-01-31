using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;

namespace BinaryTreeTask
{
    public class BinaryTree<T> : IEnumerable
        where T: IComparable<T>
    {
        private Node<T> root;
        public Node<T> Root 
        { 
            get => root;
        }
        public BinaryTree() => root = null;

        public void Insert(T data)
        {
            if (root == null)
            {
                root = new Node<T>(data);
                return;
            }

            InsertRec(root, new Node<T>(data));
        }

        private void InsertRec(Node<T> root, Node<T> newNode)
        {
            if (root == null)
                root = newNode;

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

        private void DisplayTree(Node<T> root)
        {
            if (root == null) return;

            DisplayTree(root.NodeLeft);
            Console.Write(root.Data + " ");
            DisplayTree(root.NodeRight);
        }

        public void DisplayTree() => DisplayTree(root);

       public IEnumerator GetEnumerator()
        {
            return new BinaryTreeEnumerator<T>(this);
        }
    }

    public class BinaryTreeEnumerator<T> : IEnumerator
        where T : IComparable<T>
    {
        private BinaryTree<T> binaryTree;
        
        private Node<T> currentNode;
        
        private bool leftReturned = false;

        public object Current
        {
            get => currentNode;
        }

        public BinaryTreeEnumerator(BinaryTree<T> tree) 
        {
            if (binaryTree == null || binaryTree.Root == null)
                    throw new ArgumentNullException("Binary tree or root element of Binary tree should not equals null");

            binaryTree = tree;
            currentNode = tree.Root;
        }

        public bool MoveNext()
        {
            return true;
        }

        public void Reset() => currentNode = binaryTree.Root;
    }
}

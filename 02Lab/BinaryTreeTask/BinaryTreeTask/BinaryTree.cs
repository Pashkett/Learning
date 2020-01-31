using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;

namespace BinaryTreeTask
{
    public class BinaryTree<T> : IEnumerable<T>
        where T: IComparable<T>
    {
        private Node<T> root;
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

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.ObjectModel;

namespace Laba1_Tree
{
    class BinaryTree<T>: Collection<T>, IEquatable<T> where T : IComparable
    {
        public Node<T> Root { get; private set; }

        public BinaryTree()
        {
            Root = null;
        }
        public BinaryTree(Node<T> root)
        {
            Root = root;
        }
        public override int GetHashCode()
        {
            return (Root != null ? Root.GetHashCode() : 0);
        }

        public new void Add(T elem)
        {
            Node<T> previous;
            previous = null;
            Node<T> current = Root;

            while (current != null)
            {
                previous = current;
                if (current.Data.CompareTo(elem) > 0)
                {
                    current = current.Left;
                }
                else if (current.Data.CompareTo(elem) < 0)
                {
                    current = current.Right;
                }
                else return;
            }

            Node<T> node = new Node<T>(elem);
            if (previous == null)
            {
                Root = node;
            }
            else
            {
                if (previous.Data.CompareTo(elem) > 0)
                {
                    previous.Left = node;
                }
                else
                    previous.Right = node;
            }
        }

        public void Delete(T data)
        {
            Delete(Root, data);
        }
        private Node<T> Delete(Node<T> node, T data)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Data.CompareTo(data) > 0)
            {
                node.Left = Delete(node.Left, data);
            }
            else if (node.Data.CompareTo(data) < 0)
            {
                node.Right = Delete(node.Right, data);
            }
            else
            {
                if (node.Left == null)
                {
                    return node.Right;
                }
                else if (node.Right == null)
                {
                    return node.Left;
                }

                T tempData = node.Right.Data;
                while (node.Right.Left != null)
                {
                    tempData = node.Right.Left.Data;
                    node.Right = node.Right.Left;
                }

                node.Data = tempData;
                node.Right = Delete(node.Right, node.Data);
            }

            return node;
        }
        
        public Node<T> Search(T data)
        {
            return Search(Root, data);
        }

        private Node<T> Search(Node<T> node, T data)
        {
            if (node == null || node.Data.CompareTo(data) == 0)
            {
                return node;
            }
            if (node.Data.CompareTo(data) > 0)
            {
                return Search(node.Left, data);
            }
            return Search(node.Right, data);
        }
        
        public void PrintLowToHigh()
        {
            PrintLowToHigh(Root);
        }

        private void PrintLowToHigh(Node<T> node)
        {
            if (node != null)
            {
                PrintLowToHigh(node.Left);
                Console.WriteLine(node.Data);
                PrintLowToHigh(node.Right);
            }
        }
        
                
        public void PrintHighToLow()
        {
            PrintHighToLow(Root);
        }

        private void PrintHighToLow(Node<T> node)
        {
            if (node != null)
            {
                PrintHighToLow(node.Right);
                Console.Write(node.Data);
                PrintHighToLow(node.Left);
            }
        }

        protected bool Equals(BinaryTree<T> other)
        {
            return Equals(Root, other.Root);
        }

        public bool Equals(T other)
        {
            return Search(Root, other) != null;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BinaryTree<T>) obj);
        }
    }
}
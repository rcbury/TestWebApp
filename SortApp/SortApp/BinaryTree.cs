using System;
using System.Collections;
using System.Collections.Generic;

namespace SortApp
{
    public class BinaryTree<T> where T : IComparable
    {
        public Node<T> Root { get; set; }
        bool isFirst = true;

        public void Add(T val)
        {
            if (Root == null)
            {
                Root = new Node<T>();
            }
            if ((Root.Value == null || Root.Value.Equals(default(T))) && isFirst)
            {
                Root.Value = val;
                isFirst = false;
            }
            else
            {
                AddToSubtree(val);
            }
        }

        private void AddToSubtree(T val)
        {
            Node<T> currNode = Root;
            while (true)
            {
                if (val.CompareTo(currNode.Value) < 0)
                {
                    if (currNode.Left == null)
                    {
                        currNode.Left = new Node<T>(val);
                        break;
                    }
                    else currNode = currNode.Left;
                }
                else
                {
                    if (currNode.Right == null)
                    {
                        currNode.Right = new Node<T>(val);
                        break;
                    }
                    else currNode = currNode.Right;
                }
            }
        }

        public bool Contains(T value)
        {
            if (Root == null)
                return false;
            Node<T> currNode = Root;
            while (currNode != null)
            {
                if (value.CompareTo(currNode.Value) == 0)
                    return true;
                else if (value.CompareTo(currNode.Value) > 0)
                    currNode = currNode.Right;
                else
                    currNode = currNode.Left;
            }
            return false;
        }
    }

    public class Node<T>: IEnumerable<T> where T : IComparable
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node<T> Parent { get; set; }

        public Node()
        {

        }

        public Node(T val)
        {
            Value = val;
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            if (Left != null)
            {
                foreach (var node in Left)
                {
                    yield return node;
                }
            }
            if (!Value.Equals(default(T)))
            {
                yield return Value;
            }
            else if (Parent != null)
            {
                yield return default(T);
            }

            if (Right != null)
            {
                foreach (var node in Right)
                {
                    yield return node;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

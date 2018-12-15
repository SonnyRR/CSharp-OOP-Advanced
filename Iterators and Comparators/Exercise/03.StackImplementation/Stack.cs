namespace _03.StackImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IEnumerable<T>
    {
        private Node<T> currentNode;

        public Stack()
        {
            this.currentNode = null;
        }

        public void Push(T item)
        {
            if (currentNode == null)
            {
                this.currentNode = new Node<T>(item);
            }

            else
            {
                var tempNode = this.currentNode;
                this.currentNode = new Node<T>(item);
                this.currentNode.prevVal = tempNode;
            }
        }

        public void Pop()
        {
            if (this.currentNode != null)
            {
                Node<T> currentNodeTemp = this.currentNode;
                this.currentNode = this.currentNode.prevVal;

                // garbage collect ??
                currentNodeTemp = null;
            }

            else
            {
                throw new InvalidOperationException("No elements");
            }
        }
        private class Node<TVal>
        {
            public TVal value { get; set; }
            public Node<TVal> prevVal { get; set; }

            public Node(TVal value)
            {
                this.value = value;
                this.prevVal = null;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> iterNode = this.currentNode;

            while (iterNode != null)
            {
                yield return iterNode.value;

                iterNode = iterNode.prevVal;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

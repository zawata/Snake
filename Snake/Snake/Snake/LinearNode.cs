using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    public class LinearDoubleNode<T>
    {
        private LinearDoubleNode<T> next, prev;
        private T element;

        public LinearDoubleNode()
        {
            next = null;
            prev = null;
            element = default(T);
        }
        public LinearDoubleNode(T elem)
        {
            next = null;
            prev = null;
            element = elem;
        }
        public LinearDoubleNode<T> getNext()
        {
            return next;
        }
        public void setNext(LinearDoubleNode<T> node)
        {
            next = node;
        }
        public LinearDoubleNode<T> getPrev()
        {
            return prev;
        }
        public void setPrev(LinearDoubleNode<T> node)
        {
            prev = node;
        }
        public T getElement()
        {
            return element;
        }
        public void setElement(T elem)
        {
            element = elem;
        }
    }

}

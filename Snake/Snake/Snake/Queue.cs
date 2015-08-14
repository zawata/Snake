using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
        public static class LinkedQueue<T>
    {
        private int count;
        private LinearNode<T> head, tail; //front, back

        public LinkedQueue()
        {
            count = 0;
            head = tail = null;
        }
        public void enqueue(T element)
        {
            LinearNode<T> node = new LinearNode<T>(element);
    
            if (isEmpty())
                head = node;
            else
                tail.setNext(node);
    
            tail = node;
            count++;
        }
        public T dequeue()
        {
            if (isEmpty())
                throw new Exception("queue");
    
            T result = head.getElement();
            head = head.getNext();
            count--;
    
            if (isEmpty())
                tail = null;
    
            return result;
        }
        public T first()
        {
            return head.getElement();
        }

        public bool isEmpty()
        {
            return count == 0;
        }
        public int size()
        {
        	return count;
        }
        public String toString()
        {
        	LinearNode<T> node = head;
        	
        	String returner = "";
            for(int i = size(); i > 0; i--) {
            	returner += (node.getElement() + " ");
            	node = node.getNext();
            }
            return returner;
        }
    }
}

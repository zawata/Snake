using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    public static class LinkedQueue<T>
    {
        private static int count;
        private static LinearNode<T> head, tail; //front, back

        public static void enqueue(T element)
        {
            LinearNode<T> node = new LinearNode<T>(element);
    
            if (isEmpty())
                head = node;
            else
                tail.setNext(node);
    
            tail = node;
            count++;
        }
        public static T dequeue()
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
        public static T first()
        {
            return head.getElement();
        }

        public static bool isEmpty()
        {
            return count == 0;
        }
        public static int size()
        {
        	return count;
        }
        public static String toString()
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.ComponentModel;
using System.Security.Policy;

namespace GALinkedListDoubly_EdnalynnLaxa
{
    // Define a generic class called DoublyLinkedList.
    // The 'T' here is a type parameter that allows this class to work with various data types.
    class DoublyLinkedList<T> //A generic type is declared by including a type parameter, represented by <T> , after the type name, such as in TypeName<T>
    {

        // Nested class LinkedListNode representing elements in the doubly linked list.
        class LinkedListNode<T>
        {
            public T Value { get; set; }                    // Data stored in the node.
            public LinkedListNode<T> Next { get; set; }     // Reference to the next node.
            public LinkedListNode<T> Previous { get; set; } // Reference to the previous node.

            public LinkedListNode(T value) // Declares constructor for LinkedListNode class, set as public so this can be called anywhere within the code
            {
                //INITIALIZATION 

                Value = value;// Value passed to the constructor as value
                Next = null; // Sets NEXT property as Null 
                Previous = null; //Sets Prevous property to NULL 
            }
            // Produces a new LinkedListNode object when prompt 
            //Implements the provided value w/in the node's value property
            //Initializes the value Next & Previous as Null defining that the node is 
            //in moment isolated but not connected to the nodes list. 

            //VALUES regarding NEXT AND PREVIOUS play a crucial role to maintaining 
            //connection details in the list. 
        }

        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count;

        public int Count
        {
            get { return count; }
        }

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        // Add an element to the end of the list.
        public void Add(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Previous = tail;
                tail.Next = newNode;
                tail = newNode;
            }

            count++;
        }

        // Display elements from head to tail.
        public void DisplayForward()
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                Console.Write($"{current.Value} -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }

        // Display elements from tail to head.
        public void DisplayBackward()
        {
            LinkedListNode<T> current = tail;
            while (current != null)
            {
                Console.Write($"{current.Value} -> ");
                current = current.Previous;
            }
            Console.WriteLine("null");
        }

        // Remove an element by value.
        public bool Remove(T value)
        {
            LinkedListNode<T> current = head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (current == head) head = head.Next;
                    if (current == tail) tail = tail.Previous;
                    if (current.Next != null) current.Next.Previous = current.Previous;
                    if (current.Previous != null) current.Previous.Next = current.Next;

                    count--;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        // Access elements by index using an indexer.
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();

                LinkedListNode<T> current = head;
                for (int i = 0; i < index; i++)
                    current = current.Next;

                return current.Value;
            }
        }

        // Insert an element at a specific index.
        public void InsertAtIndex(int index, T value)
        {
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            LinkedListNode<T> newNode = new LinkedListNode<T>(value);

            if (index == 0)
            {
                newNode.Next = head;

                if (head != null)
                {
                    head.Previous = newNode;
                }

                head = newNode;

                if (count == 0)
                {
                    tail = newNode;
                }
            }
            else if (index == count)
            {
                newNode.Previous = tail;
                tail.Next = newNode;
                tail = newNode;
            }
            else
            {
                LinkedListNode<T> current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                newNode.Previous = current;
                current.Next.Previous = newNode;
                current.Next = newNode;
            }

            count++;
        }

        // Insert an element at the beginning of the list.
        public void InsertAtFront(T value)
        {
            InsertAtIndex(0, value);
        }

        // Insert an element at the end of the list.
        public void InsertAtEnd(T value)
        {
            InsertAtIndex(count, value);
        }

        // Remove an element at a specific index.
        public void RemoveAtIndex(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            LinkedListNode<T> current = head;

            if (index == 0)
            {
                head = current.Next;

                if (head != null)
                {
                    head.Previous = null;
                }

                if (count == 1)
                {
                    tail = null;
                }
            }
            else if (index == count - 1)
            {
                current = tail;
                tail = current.Previous;
                tail.Next = null;
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Previous.Next = current.Next;
                current.Next.Previous = current.Previous;
            }

            count--;
        }

        // Remove the element at the beginning of the list.
        public void RemoveAtFront()
        {
            RemoveAtIndex(0);
        }

        // Remove the element at the end of the list.
        public void RemoveAtEnd()
        {
            RemoveAtIndex(count - 1);
        }

        // Clear the entire linked list, resetting it to an empty state.
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
    }

}
    //A singly linked list node has a reference to the next node, allowing you to move forward,
    //like a chain of connected beads.

    // A doubly linked list node has references to both the next and previous nodes,
    // allowing you to move both forward and backward in the list, like a two-way street.

    //What is a Doubly Linked List Node

   // A doubly linked list node is a crucial component of a doubly linked list, containing:

    //Data element storage.
    //Two pointers or references: one to the next node, one to the previous node.
    //Support for efficient forward and backward traversal.
    //Facilitation of dynamic sizing and flexible insertions/removals.
    //Foundation for complex data structures and algorithms.



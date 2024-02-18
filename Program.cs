using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Net;
using System.Reflection;

namespace GALinkedListDoubly_EdnalynnLaxa
{ /// <summary>
    //EDNA LYNN LAXA 
    //COMPUTER PROGRAMMING V 
    //ASSIGNMENT: GA LINKED LIST DOUBLY 
    //FEBRUARY 14,2024 

    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> linkedList = new DoublyLinkedList<int>();

            // Add elements
            linkedList.Add(10);
            linkedList.Add(20);
            linkedList.Add(30);
            linkedList.Add(40); //added for testing details
            linkedList.Add(50); //added for testing details 

          

            // Display forward and backward
            Console.WriteLine("Forward:");
            linkedList.DisplayForward();
            Console.WriteLine("Backward:");
            linkedList.DisplayBackward();

            // Remove an element
            if (linkedList.Remove(20))
                Console.WriteLine("20 removed");
    
        // Access element by index
            Console.WriteLine($"Element at index 1: {linkedList[1]}");

            Console.ReadLine();
        }

        //Edna Lynn's Take: 
        //A data structure called a doubly linked list arranges elements among several linked nodes.
        //Every node has the following:

        //The actual information you wish to store, such as strings or numbers, is called data.
        //Next pointer: A pointer to the node in the list that comes after it.

        //A pointer to the node in the list that came before it.
        //You can: thanks to this two-way connection

        //Efficiently add or delete components from any position.
        //Go through the list both ways (forward and backward).

        //You can go smoothly in either direction if you imagine it as a train with each vehicle connected
        //to the one in front and behind it.When you need quick insertion, deletion, and bidirectional traversal,
        //doubly linked lists come in handy.

        //MY DEFINITION OF A NODE 
        //WHAT IS A NODE: 
        //An essential component of many data structures, including linked lists, trees, and graphs, is a node.
        //It can be seen as a single entity with links to other nodes and data.


    }
    //What is a Doubly Linked List: A doubly linked list is a linear data structure similar to
    //a singly linked list, but with an additional feature: each node contains two references,
    //one to the next node and one to the previous node. This allows traversal in both directions,
    //forward and backward.

    //Why is it Important: The key advantage of a doubly linked list is its ability to traverse
    //in both directions, making operations like reversing the list, navigating backwards,
    //or modifying elements near the end more efficient compared to a singly linked list.
    //It's particularly useful in scenarios where bi-directional navigation is crucial.




}
    
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructureConApp
{
    /// <summary>
    /// A linked list collection capable of basic operations such as
    /// Add, Remove, Find and Enumarate.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SinglyLinkedList<T> : System.Collections.Generic.ICollection<T>
    {
        /// <summary>
        /// The first node in the linked list or null if empty.
        /// </summary>
        public SinglyLinkedListNode<T> Head
        {
            get;
            private set;
        }

        /// <summary>
        /// The last node in the linked list or null if empty.
        /// </summary>
        public SinglyLinkedListNode<T> Tail
        {
            get;
            private set;
        }

        #region Add

        /// <summary>
        /// Adds the specified value to start of linked list
        /// </summary>
        /// <param name="nodeValue">The value to add to the start of the linked list</param>
        public void AddFirst(T nodeValue)
        {
            AddFirst(new SinglyLinkedListNode<T>(nodeValue));
        }

        /// <summary>
        /// Adds the specified node to start of linked list
        /// </summary>
        /// <param name="node">The node to add to the start of the linked list</param>
        public void AddFirst(SinglyLinkedListNode<T> node)
        {
            //Save the Head Node so we don't lose it
            SinglyLinkedListNode<T> tempHeadNode = Head;

            //Point head node to the new node (New Node passed in the parameter)
            Head = node;

            //Insert the rest of the list behind the Head Node
            Head.NextNode = tempHeadNode;

            Count++;

            if (Count == 1)
            {
                //If the list was empty then Head and Tail should- 
                //both point to the new node
                Tail = Head;
            }
        }

        /// <summary>
        /// Adds the specified value to end of linked list
        /// </summary>
        /// <param name="nodeValue">The value to add to the end of the linked list</param>
        public void AddLast(T nodeValue)
        {
            AddLast(new SinglyLinkedListNode<T>(nodeValue));
        }

        /// <summary>
        /// Adds the specified node to end of linked list
        /// </summary>
        /// <param name="node">The node to add to the end of the linked list</param>
        public void AddLast(SinglyLinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.NextNode = node;
            }

            Tail = node;
        }

        #endregion

        #region Remove

        /// <summary>
        /// Removes the first node from the linked list
        /// </summary>
        public void RemoveFirst()
        {
            if (Count != 0)
            {
                //Before: Head--> 3 --> 5
                //After: Head---------> 5
                Head = Head.NextNode;
                Count--;

                if (Count == 0)
                {
                    Tail = null;
                }
            }
        }

        /// <summary>
        /// Removes the last node from the linked list
        /// </summary>
        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    //Before: Head--> 3 --> 5 --> 7
                    //        Tail = 7
                    //After: Head--> 3 --> 5 --> null
                    //       Tail = 5

                    SinglyLinkedListNode<T> currentNode = Head;
                    while (currentNode.NextNode != Tail)
                    {
                        currentNode = currentNode.NextNode;
                    }

                    currentNode.NextNode = null;
                    Tail = currentNode;
                }
                Count--;
            }
        }

        #endregion

        #region ICollection

        /// <summary>
        /// The number of items currently in the linked list.
        /// </summary>
        public int Count
        {
            get;
            private set;
        }

        /// <summary>
        /// True if the collection is readonly, false otherwise.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Removes all the nodes from the linked list.
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Returns true if the linked list contains the specified item,
        /// false otherwise.
        /// </summary>
        /// <param name="nodeValue">The Node value to search for</param>
        /// <returns>True if the item is found, false otherwise.</returns>
        public bool Contains(T nodeValue)
        {
            SinglyLinkedListNode<T> currentNode = Head;

            while (currentNode != null)
            {
                if (currentNode.NodeValue.Equals(nodeValue))
                {
                    return true;
                }

                currentNode = currentNode.NextNode;
            }
            return false;
        }

        /// <summary>
        /// Copies the node values into the specified array.
        /// </summary>
        /// <param name="array">The array to copy the linked list values</param>
        /// <param name="arrayIndex">The index in the array to start copying at</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            SinglyLinkedListNode<T> currentNode = Head;
            while (currentNode != null)
            {
                array[arrayIndex++] = currentNode.NodeValue;
                currentNode = currentNode.NextNode;
            }
        }

        /// <summary>
        /// Removes the first occurence of the item from the linked list-
        /// (Searching from Head to Tail).
        /// </summary>
        /// <param name="nodeValue">The node value to remove from the list.</param>
        /// <returns>True if the node value found and removed, false otherwise.</returns>
        public bool Remove(T nodeValue)
        {
            SinglyLinkedListNode<T> previousNode = null;
            SinglyLinkedListNode<T> currentNode = Head;

            //1: Empty Linked List - do nothing
            //2: Single Node - Previous node is null
            //3: Many nodes -
            //  a: node to remove is the first node from the linked list
            //  b: node to remove is the middle or last node from the linked list

            while (currentNode != null)
            {
                if (currentNode.NodeValue.Equals(nodeValue))
                {
                    //It's a node in the middle or last
                    if (previousNode != null)
                    {
                        //Case 3b
                        previousNode.NextNode = currentNode.NextNode;

                        if (currentNode.NextNode == null)
                        {
                            Tail = previousNode;
                        }
                        Count--;
                    }
                    else
                    {
                        //Case 2 or 3a
                        RemoveFirst();
                    }
                    return true;
                }
                previousNode = currentNode;
                currentNode = currentNode.NextNode;
            }
            return false;
        }

        /// <summary>
        /// Adds specified value to the front of the linked list
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            AddFirst(item);
        }

        /// <summary>
        /// Enumerates over the linked list values from Head to Tail
        /// </summary>
        /// <returns>A Head to Tail enumerator</returns>
        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
        {
            SinglyLinkedListNode<T> currentNode = Head;
            while (currentNode != null)
            {
                yield return currentNode.NodeValue;
                currentNode = currentNode.NextNode;
            }
        }

        /// <summary>
        /// Enumerates over the linked list values from Head to Tail
        /// </summary>
        /// <returns>A Head to Tail enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.Generic.IEnumerable<T>)this).GetEnumerator();
        }
        #endregion
    }

    class SinglyLinkedList
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> lstSinglyLinkedList = new SinglyLinkedList<int>();

            lstSinglyLinkedList.Add(3);
            lstSinglyLinkedList.Add(5);
            lstSinglyLinkedList.Add(7);

            PrintNodeList(lstSinglyLinkedList);
        }

        private static void PrintNodeList(SinglyLinkedList<int> itemsSinglyLinkedList)
        {
            foreach (var item in itemsSinglyLinkedList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(itemsSinglyLinkedList.Contains(5));

            //You can use predefined methods like AddFirst, AddLast, Remove, Contains, Clear to perform operations.
            //Just write itemsSinglyLinkedList. and you will get all the methods in the suggestion box.

            Console.ReadKey();
        }
    }

    public class Test
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Test(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}

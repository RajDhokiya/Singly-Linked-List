using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureConApp
{
    public class SinglyLinkedListNode<T>
    {
        /// <summary>
        /// Node Value in the Linked List
        /// </summary>
        public T NodeValue { get; set; }

        /// <summary>
        /// The Next Node in the Linked List (Null if last Node)
        /// </summary>
        public SinglyLinkedListNode<T> NextNode { get; set; }

        /// <summary>
        /// Constructs a new node with the specified value
        /// </summary>
        /// <param name="nodeValue">Node Value</param>
        public SinglyLinkedListNode(T nodeValue)
        {
            NodeValue = nodeValue;
        }
    }
}

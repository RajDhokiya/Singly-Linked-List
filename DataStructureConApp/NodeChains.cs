using System;

namespace DataStructureConApp
{
    class Node
    {
        public int NodeValue { get; set; }
        public Node NextNode { get; set; }
    }
    class NodeChains
    {
        //static void Main(string[] args)
        //{
        //    // | 3 | null |
        //    Node firstNode = new Node { NodeValue = 3 };

        //    // | 3 | null |    | 5 | null |
        //    Node middleNode = new Node { NodeValue = 5 };

        //    // | 3 | -----|--> | 5 | null |
        //    firstNode.NextNode = middleNode;

        //    // | 3 | -----|--> | 5 | null |     | 7 | null |
        //    Node lastNode = new Node { NodeValue = 7 };

        //    // | 3 | -----|--> | 5 | ---|------>| 7 | null |
        //    middleNode.NextNode = lastNode;

        //    PrintNodeList(firstNode);
        //}

        private static void PrintNodeList(Node node)
        {
            while(node!=null)
            {
                Console.WriteLine(node.NodeValue);
                node = node.NextNode;
            }
            Console.ReadKey();
        }
    }
}

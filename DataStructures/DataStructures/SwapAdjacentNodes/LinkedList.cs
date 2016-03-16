using Sid.Practice.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapAdjacentNodes
{
    public class LinkedList
    {
        private SinglyNode rootNode;

        public LinkedList()
        {
            rootNode = null;
        }

        public void Insert(int data)
        {
            var newNode = new SinglyNode(data);
            if (rootNode == null)
            {
                rootNode = newNode;
            }
            else
            {
                var currentNode = rootNode;
                while (currentNode.NextNode != null)
                {
                    currentNode = currentNode.NextNode;
                }

                currentNode.NextNode = newNode;
            }
        }

        public void Reverse()
        {
            if (rootNode == null)
            {
                return;
            }

            var currentNode = rootNode;
            var nextNode = currentNode.NextNode;
            var tempNode = nextNode.NextNode;
            while (nextNode != null)
            {
                tempNode = nextNode.NextNode;
                nextNode.NextNode = currentNode;
                currentNode = nextNode;
                nextNode = tempNode;
            }

            rootNode.NextNode = null;
            rootNode = currentNode;
        }

        public void Swap()
        {

        }

        public void Display()
        {
            if (rootNode == null)
            {
                Console.WriteLine("Empty");
                return;
            }

            var currentNode = rootNode;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.NodeValue);
                currentNode = currentNode.NextNode;
            }
        }
    }
}

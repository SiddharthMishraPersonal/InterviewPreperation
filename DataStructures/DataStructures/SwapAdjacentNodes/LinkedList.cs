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

        public SinglyNode Reverse(SinglyNode rootNode)
        {
            if (rootNode == null)
            {
                return null;
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

            return rootNode;
        }

        public SinglyNode MidOfList()
        {
            if (rootNode == null)
            {
                return null;
            }

            var currentNode = rootNode;
            var midNode = rootNode;
            var count = 0;
            while (currentNode != null)
            {
                currentNode = currentNode.NextNode;
                count++;
                if (count % 2 == 0)
                {
                    midNode = midNode.NextNode;
                }
            }

            return midNode;
        }

        public void Swap()
        {
            var currentNode = rootNode;
            var prevNode = rootNode;
            prevNode = currentNode;
            currentNode = currentNode.NextNode;
            int count = 0;
            while (currentNode != null)
            {
                

                prevNode.NextNode = currentNode.NextNode;
                currentNode.NextNode = prevNode;

                if (count == 0)
                {
                    rootNode = currentNode;
                }
                prevNode = prevNode.NextNode;
                currentNode = prevNode.NextNode;
                count++;
            }




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

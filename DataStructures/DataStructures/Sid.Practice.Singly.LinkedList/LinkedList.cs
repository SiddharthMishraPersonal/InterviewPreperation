// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinkedList.cs" company="Siddharth Mishra">
// It is a free license code. You can use it.  
// </copyright>
// <summary>
//   The linked list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sid.Practice.Singly.LinkedList
{
    using Shared;

    /// <summary>
    /// The linked list.
    /// </summary>
    public class LinkedList
    {
        #region Private Member Variables

        /// <summary>
        /// Header node which always tracks the starting point of the linked list.
        /// </summary>
        private SinglyNode _head;

        #endregion

        #region Public Properties

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkedList"/> class. 
        /// Constructor for LinkedList class.
        /// </summary>
        public LinkedList()
        {
            this._head = null;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The add node at front.
        /// </summary>
        /// <param name="nodeValue">
        /// The node value.
        /// </param>
        public void AddNodeAtFront(int nodeValue)
        {
            if (this._head == null)
            {
                this._head = new SinglyNode(nodeValue);
            }
            else
            {
                var newNode = new SinglyNode(nodeValue);
                newNode.NextNode = this._head;
                this._head = newNode;
            }
        }

        /// <summary>
        /// The add node at rear.
        /// </summary>
        /// <param name="nodeValue">
        /// The node value.
        /// </param>
        public void AddNodeAtRear(int nodeValue)
        {
            if (this._head == null)
            {
                this._head = new SinglyNode(nodeValue);
            }
            else
            {
                var currentNode = this._head;
                while (currentNode.NextNode != null)
                {
                    currentNode = currentNode.NextNode;
                }

                currentNode.NextNode = new SinglyNode(nodeValue);
            }
        }

        /// <summary>
        /// The add node in middle.
        /// </summary>
        /// <param name="nodeValue">
        /// The node value.
        /// </param>
        /// <param name="sortedAscending">
        /// The sorted ascending.
        /// </param>
        public void AddNodeInMiddle(int nodeValue, bool sortedAscending = true)
        {
            if (this._head == null)
            {
                this._head = new SinglyNode(nodeValue);
            }
            else
            {
                var currentNode = this._head;
                var prevNode = this._head;
                while (currentNode.NodeValue >= nodeValue)
                {
                    prevNode = currentNode;
                    currentNode = currentNode.NextNode;
                }
                var newNode = new SinglyNode(nodeValue);
                prevNode.NextNode = newNode;
                newNode.NextNode = currentNode;
            }
        }

        /// <summary>
        /// The remove node.
        /// </summary>
        /// <param name="nodeValue">
        /// The node value.
        /// </param>
        /// <returns>
        /// The <see cref="SinglyNode"/>.
        /// </returns>
        /// <exception cref="MyException">
        /// System Exception
        /// </exception>
        public SinglyNode RemoveNode(int nodeValue)
        {
            var currentNode = this._head;
            var prevNode = this._head;

            if (this._head == null)
            {
                throw new MyException("Linked List is Empty.");
            }

            if (this._head.NodeValue.Equals(nodeValue))
            {
                this._head = this._head.NextNode;
            }
            else
            {
                while (!currentNode.NodeValue.Equals(nodeValue))
                {
                    prevNode = currentNode;
                    currentNode = currentNode.NextNode;
                }

                if (currentNode == null)
                {
                    throw new MyException("Node not found in the linked list.");
                }

                prevNode.NextNode = currentNode.NextNode;
            }

            return currentNode;
        }

        /// <summary>
        /// Displays the linked list.
        /// </summary>
        public void Display()
        {
            if (this._head == null)
            {
                throw new MyException("Linked List is empty.");
            }

            var currentNode = this._head;
            while (currentNode != null)
            {
                currentNode.Display();
                currentNode = currentNode.NextNode;
            }
        }

        /// <summary>
        /// To sort the linked list in ascending order.
        /// </summary>
        public void SortListAscending()
        {
            if (this._head == null)
            {
                throw new MyException("Linked List is Empty.");
            }

            var prevNode = this._head;
            var currentNode = this._head;
            var nextNode = this._head.NextNode;

            while (nextNode != null)
            {
                if (currentNode.NodeValue > nextNode.NodeValue)
                {
                    SinglyNode tempNode = nextNode.NextNode;
                    nextNode.NextNode = currentNode;

                    // While swapping in and out we can lose Head pointer. So we need to set that Head pointer here to very first node.
                    if (currentNode.NodeId == prevNode.NodeId)
                    {
                        this._head = nextNode;
                    }
                    prevNode.NextNode = nextNode;
                    currentNode.NextNode = tempNode;

                    prevNode = this._head;
                    currentNode = this._head;
                    nextNode = this._head.NextNode;
                    tempNode = null;
                }
                else
                {
                    prevNode = nextNode;
                    currentNode = nextNode;
                    nextNode = nextNode.NextNode;
                }
            }
        }

        /// <summary>
        /// Sorts linked list in descending order.
        /// </summary>
        public void SortListDescending()
        {
            if (this._head == null)
            {
                throw new MyException("Linked List is Empty.");
            }
        }


        /// <summary>
        /// The node position.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="SinglyNode"/>.
        /// </returns>
        /// <exception cref="MyException">
        /// System Exception
        /// </exception>
        public SinglyNode NodePosition(int value)
        {
            var currentNode = this._head;
            if (this._head == null)
            {
                throw new MyException("Linked List is Empty.");
            }

            while (currentNode != null && !currentNode.NodeValue.Equals(value))
            {
                currentNode = currentNode.NextNode;
            }

            if (currentNode == null)
            {
                throw new MyException("Node cannot be found in the Linked List.");
            }

            return currentNode;
        }

        /// <summary>
        /// The peep.
        /// </summary>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <returns>
        /// The <see cref="SinglyNode"/>.
        /// </returns>
        /// <exception cref="MyException">
        /// System Exception
        /// </exception>
        public SinglyNode Peep(int position)
        {
            var currentNode = this._head;

            if (this._head == null)
            {
                throw new MyException("Linked List is Empty.");
            }

            var currentPosition = 0;

            while (currentNode != null && currentPosition != position)
            {
                currentNode = currentNode.NextNode;
                currentPosition++;
            }

            if (currentNode == null)
            {
                throw new MyException("Node cannot be found in the Linked List.");
            }

            return currentNode;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}

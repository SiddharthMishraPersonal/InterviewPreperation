using Sid.Practice.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sid.Practice.Singly.LinkedList
{
  public class LinkedList
  {
    #region Private Member Variables

    SinglyNode _head;

    #endregion

    #region Public Properties

    #endregion

    #region Constructors

    public LinkedList()
    {
      _head = null;
    }

    #endregion

    #region Public Methods

    public void AddNodeAtFront(int nodeValue)
    {
      if (_head == null)
        _head = new SinglyNode(nodeValue);
      else
      {
        var newNode = new SinglyNode(nodeValue);
        newNode.NextNode = _head;
        _head = newNode;
      }
    }

    public void AddNodeAtRear(int nodeValue)
    {
      if (_head == null)
        _head = new SinglyNode(nodeValue);
      else
      {
        var currentNode = _head;
        while (currentNode.NextNode != null)
        {
          currentNode = currentNode.NextNode;
        }
        currentNode.NextNode = new SinglyNode(nodeValue);
      }
    }

    public void AddNodeInMiddle(int nodeValue, bool sortedAscending = true)
    {
      if (_head == null)
        _head = new SinglyNode(nodeValue);
      else
      {
        var currentNode = _head;
        var prevNode = _head;
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

    public SinglyNode RemoveNode(int nodeValue)
    {
      var currentNode = _head;
      var prevNode = _head;

      if (_head == null)
        throw new MyException("Linked List is Empty.");
      else
      {
        while (!currentNode.NodeValue.Equals(nodeValue))
        {
          prevNode = currentNode;
          currentNode = currentNode.NextNode;
        }

        if (currentNode == null)
          throw new MyException("Node not found in the linked list.");

        prevNode.NextNode = currentNode.NextNode;
      }

      return currentNode;
    }

    public void Display()
    {
      if (_head == null)
        throw new MyException("Linked List is empty.");

      var currentNode = _head;
      while (currentNode != null)
      {
        currentNode.Display();
        currentNode = currentNode.NextNode;
      }
    }

    public void SortListAcending()
    {
      if (_head == null)
        throw new MyException("Linked List is Empty.");
      var prevNode = _head;
      var curentNode = _head.NextNode;
      while (prevNode != null)
      {
        while (curentNode.NodeValue>=prevNode.NodeValue)
        {
          
        }
        prevNode++;
      }

    }

    public void SortListDecending()
    {
      if (_head == null)
        throw new MyException("Linked List is Empty.");

    }

    #endregion

    #region Private Methods

    #endregion


    public SinglyNode NodePostion(int inputInt)
    {
      var currentNode = _head;
      if (_head == null)
        throw new MyException("Linked List is Empty.");

      while (currentNode != null && !currentNode.NodeValue.Equals(inputInt))
      {
        currentNode = currentNode.NextNode;
      }

      if (currentNode == null)
      {
        throw new MyException("Node cannot be found in the Linked List.");
      }

      return currentNode;
    }

    public SinglyNode Peep(int postion)
    {
      var currentNode = _head;
      if (_head == null)
        throw new MyException("Linked List is Empty.");

      var currentPosition = 0;

      while (currentNode != null && currentPosition != postion)
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

  }
}

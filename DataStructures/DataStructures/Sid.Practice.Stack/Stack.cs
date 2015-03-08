using Sid.Practice.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sid.Practice.Stack
{
  public class Stack
  {
    #region Private Member Variables

    private SinglyNode _head = null;
    private int _size = 0;

    #endregion

    #region Public Properties

    #endregion

    #region Constructors

    public Stack()
    {

    }

    public Stack(int size)
    {
      this._size = size;
    }

    #endregion

    #region Public Methods

    public void Push(int value)
    {
      try
      {
        if (_head == null)
        {
          _head = new SinglyNode(value);

        }
        else
        {
          var newNode = new SinglyNode(value);
          newNode.NextNode = _head;
          _head = newNode;

        }
        _size++;
      }
      catch (Exception exception)
      {
        throw new Exception("Cannot insert new item.", exception);
      }
    }

    public SinglyNode Pop()
    {
      var lastNode = GetNode();
      if (lastNode == null)
      {
        throw new MyException("Stack is Empty.");
      }

      RemoveNode(lastNode);
      _size--;

      return lastNode;
    }

    public SinglyNode Peep(int position)
    {
      if (position > _size - 1)
      {
        var message = string.Format("Can't reach to position: '{0}'.\nStack size is '{1}'.", position, _size);
        if (_size == 0)
        {
          message = "Stack is empty.";
        }

        throw new MyException(message);
      }

      if (_head == null)
        throw new MyException("Stack is Empty.");

      var node = GetNode(position);

      if (node == null)
      {
        throw new MyException("Node not found at this position.");
      }

      return node;
    }

    public void Display()
    {
      var current = _head;

      Console.WriteLine("Stack as Array:");
      while (current != null)
      {
        Console.WriteLine(string.Format("[  {0}  ]", current.NodeValue));
        current = current.NextNode;
      }

      Console.WriteLine();

      Console.WriteLine("Stack as LinkedList:");
      current = _head;
      while (current != null)
      {
        current.Display();
        current = current.NextNode;
      }
    }

    #endregion

    #region Private Methods

    private SinglyNode GetNode(int position = -1)
    {
      if (_head == null)
        return null;

      var currentNode = _head;

      //If position <= -1 then we will consider it as last node.
      if (position > -1)
      {
        var currentPosition = 0;
        while (!currentPosition.Equals(position))
        {
          currentNode = currentNode.NextNode;
          currentPosition++;
        }
      }
      else
      {
        //Get the last node
        while (currentNode.NextNode != null)
        {
          currentNode = currentNode.NextNode;
        }
      }

      return currentNode;
    }

    private void RemoveNode(SinglyNode node)
    {
      var current = _head;
      var prevNode = _head;

      //Will serach for the node.
      while (current != null && !current.NodeValue.Equals(node.NodeValue))
      {
        prevNode = current;
        current = current.NextNode;
      }

      //will remove the node

      //assign next of current to the next of previous.
      prevNode.NextNode = current.NextNode;

      //dispose the current.
      current.Dispose();
    }
    #endregion
  }

}

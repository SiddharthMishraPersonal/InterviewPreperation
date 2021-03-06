﻿using Sid.Practice.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sid.Practice.Queue
{
  public class Queue
  {
    #region Private Memeber Variables

    private int _size = 0;
    private SinglyNode _head = null;
    private SinglyNode _front = null;
    private SinglyNode _rear = null;

    #endregion

    #region Constructors

    public Queue(int size)
    {
      _size = size;
      _head = null;
      _front = null;
      _rear = null;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Inserts element (node) into the front of the queue.
    /// </summary>
    /// <param name="nodeValue">Value to be inserted as node.</param>
    public void Enqueue(int nodeValue)
    {
      if (_head == null)
      {
        _head = new SinglyNode(nodeValue);
        _front = _head;
        _rear = _head;
      }
      else
      {
        _rear.NextNode = new SinglyNode(nodeValue);
        _rear = _rear.NextNode;
      }
    }

    /// <summary>
    /// Removes an element (node) from the front of the queue.
    /// </summary>
    /// <returns>Node removed.</returns>
    public SinglyNode Dequeue()
    {
      var node = _front;
      _front = _front.NextNode;
      _head = _front;
      return node;
    }

    /// <summary>
    /// Displays list between front to end of the node.
    /// </summary>
    public void Display()
    {
      if (_head == null)
        throw new MyException("Queue is Empty.");

      Console.WriteLine("Queue as Array:");
      var currentNode = _front;
      while (!currentNode.NodeId.Equals(_rear.NodeId))
      {
        Console.Write(string.Format("[  {0}  ]", currentNode.NodeValue));
        currentNode = currentNode.NextNode;
      }

      Console.WriteLine();
      Console.WriteLine("Queue as LinkedList:");
      currentNode = _front;
      while (!currentNode.NodeId.Equals(_rear.NodeId))
      {
        currentNode.Display();
        currentNode = currentNode.NextNode;
      }
    }

    public SinglyNode Peep(int position)
    {
      if (_head == null && _front == null)
        throw new MyException("Queue is Empty.");

      var currentPosition = 0;
      var currentNode = _front;
      while (!currentPosition.Equals(position))
      {
        currentNode = currentNode.NextNode;
        currentPosition++;
      }

      return currentNode;
    }

    #endregion

    #region Private Methods



    #endregion



  }
}

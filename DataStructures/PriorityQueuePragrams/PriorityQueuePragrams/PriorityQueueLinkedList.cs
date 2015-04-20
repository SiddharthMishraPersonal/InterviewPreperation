using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PriorityQueuePragrams
{
  public class PriorityQueueLinkedList : IDisposable
  {
    private Node _frontNode = null;
    private Node _rearNode = null;

    public void Insert(int newValue)
    {
      //We will use simple Queue operation to insert a new node. But then we will swap them to get minimum to Front so that we can get minimum always on Front index.
      var newNode = new Node(newValue);

      //If Front and Rear are null then it means Queue is empty.
      if (_frontNode == null && _rearNode == null)
      {
        _frontNode = newNode;
        _rearNode = newNode;
      }
      else
      {
        newNode.NextNode = _frontNode;
        _frontNode = newNode;
      }
      var currentNode = _frontNode;
      var currentNextNode = currentNode;
      while (currentNode != null)
      {
        if (currentNextNode.NextNode != null && currentNextNode.Value > currentNextNode.NextNode.Value)
        {
          var tempNode = currentNextNode.NextNode.NextNode;
          if (currentNextNode == _frontNode)
          {
            _frontNode = currentNextNode.NextNode;
          }
          currentNextNode.NextNode.NextNode = currentNextNode;
          currentNode.NextNode = currentNextNode.NextNode;
          currentNextNode.NextNode = tempNode;


          currentNextNode = currentNode.NextNode;
          
        }
        else
        {
          break;
        }

      }
    }

    public void RemoveMin()
    {

    }

    public void Display()
    {
      var current = _frontNode;

      while (current.NextNode != null)
      {
        Console.WriteLine(string.Format("{0}\t", current.Value));
      }
    }

    #region IDisposable Members

    public void Dispose()
    {

    }

    #endregion
  }
}

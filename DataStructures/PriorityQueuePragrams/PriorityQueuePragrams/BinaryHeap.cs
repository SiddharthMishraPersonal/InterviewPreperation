using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueuePragrams
{
  public class BinaryHeap : IDisposable
  {
    private int[] _heap;
    private int _heapSize = 0;
    private int _lastNodeIndex = 0;

    public BinaryHeap(int heapSize)
    {
      _heapSize = heapSize;
      _heap = new int[heapSize];
    }

    ~BinaryHeap()
    {
      _heap = null;
    }

    public void Display()
    {
      foreach (var value in _heap)
      {
        Console.WriteLine(value);
      }

      //for (int j = 0; j < _heapSize; )
      //{
      //  var t = j;
      //  for (int k = 0; k < t; k++)
      //  {
      //    for (int i = 0; i < _heapSize / j; i++)
      //    {
      //      Console.Write("\t");
      //    }
      //    if (j != _heapSize)
      //      Console.Write(_heap[j++]);
      //    for (int i = _heapSize / j; i > 0; i--)
      //    {
      //      Console.Write("\t");
      //    }

      //  }
      //  Console.WriteLine();
      //}
    }

    /// <summary>
    /// Inserts value to its desired position. It also does percolation or heapify to keep Heap in order.
    /// </summary>
    /// <param name="value"></param>
    public void Insert(int value)
    {
      //Insert a value at the end of the list.
      _lastNodeIndex = InsertValue(value);

      //Heapify to upside. Which means, newly added node will get swapped with its parent if parent is greater than node.
      HeapifyUp(_lastNodeIndex);

      //During heapify upwards if we messed with an order of tree then we will reorder it again from top to bottom. Rule is: Parent should be less than its left and right child.
      HeapifyDown();
    }

    /// <summary>
    /// Inserts value into Heap as last node.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Returns index where we have added last child</returns>
    private int InsertValue(int value)
    {
      var parentIndex = 1;
      var childIndex = 0;

      while (true)
      {
        if (_heap[parentIndex] == 0)
        {
          _heap[parentIndex] = value;
          childIndex = parentIndex;
          break;
        }

        childIndex = 2 * parentIndex;
        if (_heap[childIndex] == 0)
        {
          _heap[2 * parentIndex] = value;
          break;
        }

        childIndex = 2 * parentIndex + 1;
        if (_heap[childIndex] == 0)
        {
          _heap[2 * parentIndex + 1] = value;
          break;
        }

        parentIndex++;
      }

      return childIndex;
    }

    /// <summary>
    /// //Heapify to upside. Which means, newly added node will get swapped with its parent if parent is greater than node.
    /// </summary>
    /// <param name="childIndex">Index of the newly added node in list.</param>
    private void HeapifyUp(int childIndex)
    {
      while (childIndex / 2 != 0)
      {
        var parentIndex = childIndex / 2;

        if (_heap[parentIndex] == 0)
          continue;

        if (_heap[parentIndex] > _heap[childIndex])
        {
          var temp = _heap[parentIndex];
          _heap[parentIndex] = _heap[childIndex];
          _heap[childIndex] = temp;
        }
        else
        {
          break;
        }

        //Lets return index where we have added node.
        childIndex = parentIndex;
      }
    }

    /// <summary>
    /// During heapify upwards if we messed with an order of tree then we will reorder it again from top to bottom. Rule is: Parent should be less than its left and right child.
    /// </summary>
    private void HeapifyDown()
    {
      var parentIndex = 1;
      var leftChildIndex = 2 * parentIndex;
      var rightChildIndex = 2 * parentIndex + 1;

      while (true)
      {
        //If we are at end of the list
        if (_heap[parentIndex] == 0 || (parentIndex >= _heapSize))
        {
          break;
        }

        leftChildIndex = 2 * parentIndex;

        //If child index is Out of bound.
        if (leftChildIndex >= _heapSize)
          break;

        //We will ignore zeros
        if (_heap[leftChildIndex] == 0)
          break;

        //If parent is greater than its left child. We will swap parent with its left child
        if ((_heap[parentIndex] > _heap[leftChildIndex]) && (_heap[leftChildIndex] > 0))
        {
          var temp = _heap[parentIndex];
          _heap[parentIndex] = _heap[leftChildIndex];
          _heap[leftChildIndex] = temp;
        }

        rightChildIndex = 2 * parentIndex + 1;

        //If child index is Out of bound.
        if (rightChildIndex >= _heapSize)
          return;

        //Will ignore zeros
        if (_heap[rightChildIndex] == 0)
          break;

        //If parent is greater than its right child. We will swap parent with its right child
        if ((_heap[parentIndex] > _heap[rightChildIndex]) && (_heap[rightChildIndex] > 0))
        {
          var temp = _heap[parentIndex];
          _heap[parentIndex] = _heap[rightChildIndex];
          _heap[rightChildIndex] = temp;
        }

        //Move to next item
        parentIndex++;
      }
    }

    public void DeleteMin()
    {
      var parentIndex = 1;

      //We will replace top item with the last item. And then we will do percolation downwards to fit that item at proper place.
      _heap[parentIndex] = _heap[_lastNodeIndex];
      PopLastItem();
      HeapifyDown();
    }

    public void PopLastItem()
    {
      _heap[_lastNodeIndex] = 0;
    }


    #region IDisposable Members

    public void Dispose()
    {

    }

    #endregion
  }
}

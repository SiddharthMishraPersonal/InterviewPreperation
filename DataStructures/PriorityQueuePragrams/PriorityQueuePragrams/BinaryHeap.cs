using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueuePragrams
{
  public class BinaryHeap
  {
    private int[] _heap;
    private int _currentSize = 0;

    public BinaryHeap(int heapSize)
    {
      _heap = new int[heapSize];
    }

    public void Display()
    {
      foreach (var value in _heap)
      {
        Console.WriteLine(value);
      }

      //for (int j = 0; j < _currentSize; )
      //{
      //  var t = j;
      //  for (int k = 0; k < t; k++)
      //  {
      //    for (int i = 0; i < _currentSize / j; i++)
      //    {
      //      Console.Write("\t");
      //    }
      //    if (j != _currentSize)
      //      Console.Write(_heap[j++]);
      //    for (int i = _currentSize / j; i > 0; i--)
      //    {
      //      Console.Write("\t");
      //    }

      //  }
      //  Console.WriteLine();
      //}
    }


    public void Insert(int value)
    {
      var childIndex = InsertValue(value);
      HeapifyUp(childIndex);
      HeapifyDown();
    }

    private int InsertValue(int value)
    {
      var parentIndex = 1;
      var childIndex = 0;
      while (true)
      {
        if (_heap[parentIndex] == 0)
        {
          _heap[parentIndex] = value;
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

    private void HeapifyUp(int childIndex)
    {
      var parentIndex = 1;

      while (childIndex / 2 != 0)
      {
        parentIndex = childIndex / 2;
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

        childIndex = parentIndex;
      }
    }

    private void HeapifyDown()
    {
      var parentIndex = 1;
      var leftChildIndex = 0;
      var rightChildIndex = 0;
      ;
      while (true)
      {
        if (_heap[parentIndex] == 0 || (parentIndex - 1 == _currentSize))
        {
          break;
        }

        leftChildIndex = 2 * parentIndex;
        rightChildIndex = 2 * parentIndex + 1;

        if (_heap[parentIndex] < _heap[leftChildIndex])
        {
          var temp = _heap[parentIndex];
          _heap[parentIndex] = _heap[leftChildIndex];
          _heap[leftChildIndex] = temp;
        }

        if (_heap[parentIndex] < _heap[rightChildIndex])
        {
          var temp = _heap[parentIndex];
          _heap[parentIndex] = _heap[rightChildIndex];
          _heap[rightChildIndex] = temp;
        }

        parentIndex++;
      }
    }

    public void DeleteMin()
    {

    }

  }
}

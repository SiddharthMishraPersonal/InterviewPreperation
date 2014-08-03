using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueuePragrams
{
  class Program
  {
    static void Main(string[] args)
    {

      using (var heap = new BinaryHeap(16))
      {


        heap.Insert(5);
        heap.Insert(11);
        heap.Insert(18);
        heap.Insert(21);
        heap.Insert(33);
        heap.Insert(7);
        heap.Insert(1);
        heap.Insert(2);
        heap.Insert(3);
        heap.Insert(19);
        heap.Insert(6);
        heap.Insert(10);
        heap.Insert(4);

        heap.Display();
        heap.DeleteMin();
        Console.WriteLine();
        heap.Display();

      }


      using (var priorityQueue = new PriorityQueueLinkedList())
      {

        priorityQueue.Insert(5);
        priorityQueue.Insert(11);
        priorityQueue.Insert(18);
        priorityQueue.Insert(21);
        priorityQueue.Insert(33);
        priorityQueue.Insert(7);

        priorityQueue.Display();
      }

      Console.Read();

    }
  }
}

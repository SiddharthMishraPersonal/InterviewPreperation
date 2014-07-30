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
      BinaryHeap heap = new BinaryHeap(13);

      heap.Insert(5);
      heap.Insert(11);
      heap.Insert(18);
      heap.Insert(21);
      heap.Insert(33);
      heap.Insert(9);
      heap.Insert(1);
      heap.Insert(2);
      heap.Insert(3);
      heap.Insert(19);
      heap.Insert(6);
      heap.Insert(10);

      heap.Display();
      heap.DeleteMin();
      Console.WriteLine();
      heap.Display();
      Console.Read();

    }
  }
}

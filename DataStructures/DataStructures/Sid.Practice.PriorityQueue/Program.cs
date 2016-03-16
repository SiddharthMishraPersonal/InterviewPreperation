using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sid.Practice.PriorityQueue
{
  public class PriorityQueueProgram
  {
    public static void Main(string[] args)
    {
            var priorityQueue = new PriorityQueue(7);
            priorityQueue.Insert(7);
            priorityQueue.Insert(2);
            priorityQueue.Insert(4);
            priorityQueue.Insert(3);
            priorityQueue.Insert(6);
            priorityQueue.Insert(1);
            priorityQueue.Insert(5);

            Console.WriteLine("In-order display");
            priorityQueue.InorderDisplay(0);

            Console.WriteLine("Pre-order display");
            priorityQueue.PreorderDisplay(0);

            priorityQueue.Delete();
            Console.WriteLine("Pre-order display");
            priorityQueue.PreorderDisplay(0);


            Console.WriteLine("Post-order display");
            priorityQueue.PostorderDisplay(0);

            Console.ReadKey();
        }
  }
}

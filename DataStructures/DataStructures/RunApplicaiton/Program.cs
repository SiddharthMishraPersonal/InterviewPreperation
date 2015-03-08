using Sid.Practice.PriorityQueue;
using Sid.Practice.Queue;
using Sid.Practice.Stack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunApplicaiton
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Enter following commands:\nS : Stack\nQ : Queue\nPQ : Priority Queue\nT : Tree\n");
      Console.Write("Enter Command: ");
     var key = Console.ReadKey().KeyChar.ToString().ToLowerInvariant();
      Console.WriteLine();
      while (key != "exit")
      {
        try
        {
          switch (key.ToLowerInvariant())
          {
            case "s": StackProgram.Main(null); break;
            case "q": QueueProgram.Main(null); break;
            case "pq": PriorityQueueProgram.Main(null); break;
            case "t":  break;
            default:
              Console.WriteLine();
              Console.WriteLine();
              Console.WriteLine();
              Console.WriteLine("************Main Program***********");
              Console.WriteLine("Enter following commands:\nS : Stack\nQ : Queue\nPQ : Priority Queue\nT : Tree\n");
              break;
          }
        }
        catch (MyException exception)
        {
          Console.WriteLine(exception.Message);
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Enter Command: ");
        key = Console.ReadKey().KeyChar.ToString().ToLowerInvariant();

      }
    }
  }
}

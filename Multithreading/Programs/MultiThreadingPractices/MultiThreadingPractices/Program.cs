using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

namespace MultiThreadingPractices
{
  class Program
  {
    static void Main(string[] args)
    {
      var newThread = new Thread(StartCounter);
      newThread.Start();

      var counter = 0;
      var timer = new Timer(1);
      timer.Elapsed += (o, e) =>
      {
        Console.WriteLine("Main thread: " + counter++);
        if (Console.KeyAvailable) { timer.Stop(); }
      };
      timer.Start();

      Console.Read();
      newThread.Abort();
      Console.Read();
    }

    private static void StartCounter()
    {
      var counter = 0;
      var timer = new Timer(1);
      timer.Elapsed += (o, args) => Console.WriteLine("Worker Thread: " + counter++);
      timer.Start();
    }


  }
}

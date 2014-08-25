using System;
using System.Threading;

namespace MultiThreadingPractices
{
 public class IsBackgroundTest
  {
    internal static void RunTest()
    {
      BackgroundTest shortTest = new BackgroundTest(10);
      Thread foregroundThread =
          new Thread(new ThreadStart(shortTest.RunLoop));
      foregroundThread.Name = "ForegroundThread";

      BackgroundTest longTest = new BackgroundTest(50);
      Thread backgroundThread =
          new Thread(new ThreadStart(longTest.RunLoop));
      backgroundThread.Name = "BackgroundThread";
      backgroundThread.IsBackground = true;

      foregroundThread.Start();
      backgroundThread.Start();

      Console.ReadKey();
    }
  }

  class BackgroundTest
  {
    private int maxIterationsVar = 0;
    public BackgroundTest(int maxIterations)
    {
      maxIterationsVar = maxIterations;
    }

    public void RunLoop()
    {
      var threadName = Thread.CurrentThread.Name;

      for (var i = 0; i < maxIterationsVar; i++)
      {
        Console.WriteLine("{0} count: {1}",
            threadName, i.ToString());
        Thread.Sleep(250);
      }

      Console.WriteLine("{0} finished counting.", threadName);
    }
  }

}

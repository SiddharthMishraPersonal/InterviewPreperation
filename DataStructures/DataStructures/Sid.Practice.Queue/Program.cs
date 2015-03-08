using Sid.Practice.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sid.Practice.Queue
{
  public class QueueProgram
  {
    static Queue queue = null;
    static string key = "n";

    public static void Main(string[] args)
    {
      try
      {
        Console.Write("Enter the size of Queue:");
        var key = Console.ReadLine().ToLowerInvariant();
        var inputInt = 0;
        Int32.TryParse(key, out inputInt);

        if (inputInt == 0)
        {
          try
          {
            inputInt = Convert.ToInt32(key);
          }
          catch (Exception)
          {
            throw new MyException("\nInput valid integer.");
          }
        }

        queue = new Queue(inputInt);

        Console.WriteLine("Enter following commands:\nn : Enqueue into Queue\nr : Dequeue from Queue\ns : Peep from Queueu\nd : Display Queue\n");
        Console.Write("Enter Command: ");
        key = Console.ReadKey().KeyChar.ToString().ToLowerInvariant();
        Console.WriteLine();
        while (key != "x")
        {
          try
          {

            switch (key)
            {
              case "n": EnqueueToQueue(); break;
              case "d": Display(); break;
              case "r": DequeueFromQueue(); break;
              case "s": PeepFromQueue(); break;
              default:
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("***********************");
                Console.WriteLine("Enter following commands:\nn : Enqueue into Queue\nr : Dequeue from Queue\ns : Peep from Queueu\nd : Display Queue\n");
                break;
            }
          }
          catch (MyException exception)
          {
            Console.WriteLine(exception.Message);
            Console.WriteLine();
            Console.WriteLine("***********************");
            Console.WriteLine("Enter following commands:\nn : Enqueue into Queue\nr : Dequeue from Queue\ns : Peep from Queueu\nd : Display Queue\n");
          }

          Console.WriteLine();
          Console.WriteLine();
          Console.Write("Enter Command: ");
          key = Console.ReadKey().KeyChar.ToString().ToLowerInvariant();

        }

      }
      catch (Exception exception)
      {
        Console.WriteLine(exception.Message);
      }
    }

    private static void EnqueueToQueue()
    {
      Console.Write("\nEnter the value:");
      var key = Console.ReadLine().ToLowerInvariant();
      var inputInt = 0;
      Int32.TryParse(key, out inputInt);

      if (inputInt == 0)
      {
        try
        {
          Convert.ToInt32(key);
        }
        catch (Exception)
        {
          throw new MyException("\nInput valid integer.");
        }
      }

      queue.Enqueue(inputInt);
    }

    private static void Display()
    {
      Console.WriteLine("\n");
      queue.Display();
    }

    private static void DequeueFromQueue()
    {
      SinglyNode poppedNode = queue.Dequeue();


      poppedNode.Display();
    }

    private static void PeepFromQueue()
    {
      SinglyNode poppedNode = null;
      Console.Write("\nEnter the position:");
      var key = Console.ReadLine().ToLowerInvariant();
      var inputInt = 0;
      Int32.TryParse(key, out inputInt);
      if (inputInt > 0)
      {
        poppedNode = queue.Peep(inputInt);
      }
      else
      {
        poppedNode = queue.Peep(0);
      }

      poppedNode.Display();
    }
  }
}

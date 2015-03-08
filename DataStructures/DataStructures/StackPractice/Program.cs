using Sid.Practice.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackPractice
{
  class Program
  {
    static Stack stack = new Stack();
    static string key = "n";

    static void Main(string[] args)
    {
      try
      {
        Console.WriteLine("Enter following commands:\nn : Push into Stack\nr : Pop from Stack\ns : Peep from Stack\nd : Display Stack\n");
        Console.Write("Enter Command: ");
        key = Console.ReadKey().KeyChar.ToString().ToLowerInvariant();
        Console.WriteLine();
        while (key != "x")
        {
          try
          {

            switch (key)
            {
              case "n": PushToStack(); break;
              case "d": Display(); break;
              case "r": PopFromStack(); break;
              case "s": PeepFromStack(); break;
              default:
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("***********************");
                Console.WriteLine("Enter following commands:\nn : Push into Stack\nr : Pop from Stack\nd : Display Stack\n");
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
      catch (Exception exception)
      {
        Console.WriteLine(exception.Message);
      }
    }

    private static void PushToStack()
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

      stack.Push(inputInt);
    }

    private static void Display()
    {
      Console.WriteLine("\n");
      stack.Display();
    }

    private static void PopFromStack()
    {
      SinglyNode poppedNode = stack.Pop();


      poppedNode.Display();
    }

    private static void PeepFromStack()
    {
      SinglyNode poppedNode = null;
      Console.Write("\nEnter the position:");
      var key = Console.ReadLine().ToLowerInvariant();
      var inputInt = 0;
      Int32.TryParse(key, out inputInt);
      if (inputInt > 0)
      {
        poppedNode = stack.Peep(inputInt);
      }
      else
      {
        poppedNode = stack.Peep(0);
      }

      poppedNode.Display();
    }
  }
}

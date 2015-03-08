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
      Console.WriteLine("Enter following commands:\nn : Push into Stack\nr : Pop from Stack\nd : Display Stack\n");
      Console.Write("Enter Command: ");
      key = Console.ReadKey().KeyChar.ToString().ToLowerInvariant();
      Console.WriteLine();
      while (key != "x")
      {
        switch (key)
        {
          case "n": PushToStack(); break;
          case "d": Display(); break;
          case "r": PopFromStack(); break;
          default:
            break;
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("***********************");
        Console.WriteLine("Enter following commands:\nn : Push into Stack\nr : Pop from Stack\nd : Display Stack\n");
        Console.Write("Enter Command: ");
        key = Console.ReadKey().KeyChar.ToString().ToLowerInvariant();
        Console.WriteLine();
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
          Console.WriteLine("\nInput valid integer.");
        }
      }

      stack.Push(inputInt);
    }

    private static void Display()
    {
      stack.Display();
    }

    private static void PopFromStack()
    {
      var val = stack.Pop();
      val.Display();
    }
  }
}

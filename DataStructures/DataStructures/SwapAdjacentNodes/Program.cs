using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapAdjacentNodes
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList();
            for (int i = 1; i <= 7; i++)
            {
                list.Insert(i);
            }

            list.Display();

            Console.WriteLine("Reverse the list");

            list.Reverse();
            list.Display();

            Console.ReadKey();

            list.Swap();

        }
    }
}

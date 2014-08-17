using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftScreening
{
  class Program
  {
    static void Main(string[] args)
    {
      var result = function(5);
      Console.WriteLine(result);
    }

    static int function(int a)
    {
      int c = 0;
      if (a != 0)
      {
        do
          ++c;
        while (a == (a & (a - 1)));
      }

      return 0;
    }
  }
}

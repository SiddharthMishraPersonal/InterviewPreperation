using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvParserLib;

namespace CsvDataParser
{
  class Program
  {
    static void Main(string[] args)
    {
      var parser = new CsvParser(@"C:\Users\smishra\Desktop\DART\Test Import Files\Test Import Files\Hit Pick.csv");
      //parser.ParseFields();
      parser.ParseReadLine();
      //parser.ParseReadToEnd();
    }
  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace CsvParserLib
{
  public class CsvParser
  {
    #region Private Member Variables

    private string _csvFilePath = string.Empty;
    #endregion

    #region Constructors

    public CsvParser(string csvFilePath)
    {
      _csvFilePath = csvFilePath;
    }

    #endregion

    #region Public Methods

    public void ParseReadToEnd()
    {
      using (var parser = new TextFieldParser(_csvFilePath))
      {
        parser.CommentTokens = new string[] { "#" };
        parser.SetDelimiters(new string[] { "," });
        parser.HasFieldsEnclosedInQuotes = false;

        parser.ReadLine();

        while (!parser.EndOfData)
        {
          string fields = parser.ReadToEnd();
          Console.WriteLine(fields);
        }
      }
    }

    public void ParseFields()
    {
      using (var parser = new TextFieldParser(_csvFilePath))
      {
        parser.CommentTokens = new string[] { "#" };
        parser.SetDelimiters(new string[] { "," });
        parser.HasFieldsEnclosedInQuotes = false;

        parser.ReadLine();

        while (!parser.EndOfData)
        {
          var fields = parser.ReadFields().ToList();
          //foreach (var field in fields)
          //{
          //  Console.WriteLine(field);
          //}

          var distinct = fields.Distinct();

          foreach (var field in distinct)
          {
            Console.WriteLine(field);
          }

        }


      }
    }

    public void ParseReadLine()
    {
      using (var parser = new TextFieldParser(_csvFilePath))
      {
        parser.CommentTokens = new string[] { "#" };
        parser.SetDelimiters(new string[] { "," });
        parser.HasFieldsEnclosedInQuotes = false;
        //string fields = parser.ReadLine();
        while (!parser.EndOfData)
        {
          string fields = parser.ReadLine();
          Console.ReadKey();
          Console.WriteLine(fields);
        }
      }
    }

    public void ParseHeaders()
    {
      using (var parser = new TextFieldParser(_csvFilePath))
      {
        parser.CommentTokens = new string[] { "#" };
        parser.SetDelimiters(new string[] { "," });
        parser.HasFieldsEnclosedInQuotes = false;

        while (!parser.EndOfData)
        {
          string fields = parser.ReadLine();
          Console.WriteLine(fields);
        }
      }
    }

    #endregion

    #region Helper Methods

    #endregion
  }
}

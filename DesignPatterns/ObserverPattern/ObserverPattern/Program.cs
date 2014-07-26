using System;
using System.Collections.Generic;
using System.Linq;

namespace ObserverPattern
{
  class Program
  {
    static void Main(string[] args)
    {
      var stockList = new List<IStock>();
      IStock ibmStock = new Stock("IBM", 12.34);
      IStock hclStock = new Stock("HCL", 02.98);
      IStock pslStock = new Stock("PSL", 16.67);
      IStock msStock = new Stock("MS", 20.3);

      stockList.Add(ibmStock);
      stockList.Add(hclStock);
      stockList.Add(pslStock);
      stockList.Add(msStock);

      IInvestor investor01 = new Investor("Siddharth");
      ibmStock.RegisterInvestor(investor01);
      msStock.RegisterInvestor(investor01);

      IInvestor investor02 = new Investor("Pradeep");
      pslStock.RegisterInvestor(investor02);

      IInvestor investor03 = new Investor("Richa");
      msStock.RegisterInvestor(investor03);
      pslStock.RegisterInvestor(investor03);

      IInvestor investor04 = new Investor("Krishna Chandra Mishra");
      hclStock.RegisterInvestor(investor04);
      msStock.RegisterInvestor(investor04);
      ibmStock.RegisterInvestor(investor04);

      var exit = false;

      while (!exit)
      {
        Console.WriteLine("Enter Stock Symbol:");
        var symbol = Console.ReadLine();
        Console.WriteLine("Enter Stock Price: ");
        var price = Console.ReadLine();

        var stock = stockList.Where(s => s.Symbol.ToLowerInvariant().Equals(symbol.ToLowerInvariant())).FirstOrDefault();
        if (stock == null)
          Console.WriteLine("Stock not found");
        else
        {
          stock.Price = Convert.ToDouble(price);
        }

      }






      Console.ReadKey();

    }
  }
}

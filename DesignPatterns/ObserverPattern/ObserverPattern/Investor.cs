using System;

namespace ObserverPattern
{
  public class Investor : IInvestor
  {
    private string _name;

    #region IInvestor Members

    public Investor(string name)
    {
      Name = name;
    }

    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    public void UpdatePrice(IStock stock)
    {
      Console.WriteLine(string.Format("Investor: {0},\tStock: {1},\tPrice: {2}", Name, stock.Symbol, stock.Price));
    }

    #endregion
  }
}

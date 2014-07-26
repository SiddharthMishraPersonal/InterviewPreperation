using System.Collections.Generic;

namespace ObserverPattern
{
  public class Stock : IStock
  {
    IList<IInvestor> _investors = new List<IInvestor>();
    private string _symbol = string.Empty;
    private double _price = 0;

    public Stock(string symbol, double price)
    {
      Price = price;
      _symbol = symbol;
    }

    #region IStock Members

    public string Symbol
    {
      get { return _symbol; }
    }

    public double Price
    {
      get { return _price; }
      set
      {
        _price = value;
        this.NotifyInvestor();
      }
    }

    public void RegisterInvestor(IInvestor investor)
    {
      _investors.Add(investor);
    }

    public void RemoveInvestor(IInvestor investor)
    {
      _investors.Remove(investor);
    }

    public void NotifyInvestor()
    {
      foreach (var investor in _investors)
      {
        investor.UpdatePrice(this);
      }
    }

    #endregion
  }
}

namespace ObserverPattern
{
  public interface IStock
  {
    double Price { get; set; }
    string Symbol { get; }


    void RegisterInvestor(IInvestor investor);
    void RemoveInvestor(IInvestor investor);
    void NotifyInvestor();
  }
}

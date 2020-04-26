Facade: Provide a unified interface to a set of interfaces in a subsystem. Façade defines a higher-level interface that makes the subsystem easier to use.

  class Mortgage
  {
    private Bank _bank = new Bank();
    private Loan _loan = new Loan();
    private Credit _credit = new Credit();
 
    public bool IsEligible(Customer cust, int amount)
    {
       return _bank.HasSufficientSavings(cust, amount) 
           && _loan.HasNoBadLoans(cust)
           && _credit.HasGoodCredit(cust);
    }

    public bool HasSufficientSavings(Customer cust, int amount) => _bank.HasSufficientSavings(cust, amount);
    public bool HasNoBadLoans(Customer cust) => _loan.HasNoBadLoans(cust);
    public bool HasGoodCredit(Customer cust) => _credit.HasGoodCredit(cust);
  }
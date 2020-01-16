Adapter: Convert the interface of a class into another interface clients expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.

 class EmailNotifier
 {
   public void Send(string message, DateTime when) { }
 }

 class EmailNotifierAdapter : INotifier
 {
   private EmailNotifier _notifier = new EmailNotifier();
   public override void Nofity(string message) => _notifier.Send(message, DateTime.Now);
 }

Bridge: Decouple an abstraction from its implementation so that the two can vary independently.
https://blog.usejournal.com/design-patterns-a-quick-guide-to-bridge-pattern-9ebf6a77baed
https://fpierin.wordpress.com/2011/08/02/explorando-os-beneficios-do-uso-do-design-pattern-bridge/

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

Decorator: Attach additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality.

    class UserRepositoryLogTimeDecorator : AbstractUserRepositoryDecoretor
    {
        public UserRepositoryLogDecorator(IUserRepository repository) : base(repository) { }
        
        public override User GetById(int id)
        {
            logger.Write($"IUserRepository.GetById was called for id {id}, starting at {DateTime.Now}");
            var user = _repository.GetById(id);
            logger.Write($"IUserRepository.GetById was called for id {id}, ending at {DateTime.Now}");
            return user;
        }
    }

	void Main()
	{
		IUserRepository repository = new UserRepository();
		IUserRepository repositoryLogTime = new UserRepositoryLogTimeDecorator(repository);
		IUserRepository repositoryLogTimeAndError = new UserRepositoryLogErrorDecorator(repositoryLogTime);
	}


Proxy: Provide a surrogate or placeholder for another object to control access to it.

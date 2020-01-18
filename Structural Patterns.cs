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

void Main()
{
    MoveLogic crawl = new Crawl();
    MoveLogic walk = new Walk();
    MoveLogic swim  = new Swim();

    Animal fish = new Fish(swim);
    fish.Move(); // swimming

    Animal person = new Person(crawl);
    person.Move(); // crawling

    person.MoveLogic = walk;
    person.Move(); // walking

    person.MoveLogic = swim;
    person.Move(); // swimming
}

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
        public UserRepositoryLogTimeDecorator(IUserRepository repository) : base(repository) { }
        
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

Composite: Compose objects into tree structures to represent part-whole hierarchies. Composite lets clients treat individual objects and compositions of objects uniformly.
//https://robsoncastilho.com.br/2013/07/10/design-patterns-usando-composite-para-montar-uma-estrutura-em-arvore/
//https://www.dofactory.com/net/composite-design-pattern

public interface ICompanyMember
{
	decimal CalculateCost();
}

public class Departament : ICompanyMember
{
	private List<ICompanyMember> _members = new List<ICompanyMember>();
	public decimal CalculateCost() => _members.Sum(x => x.CalculateCost());
	public void Add(ICompanyMember member) => _members.Add(member);
	public void Remove(ICompanyMember member) => _members.Remove(member);
}

public class Employee :  ICompanyMember
{
	public decimal Salary;
	public decimal CalculateCost() => Salary;
}

void Main()
{
	var departamentX = new Departament();
	var departamentY = new Departament();

	var employeeA = new Employee() { Salary = 1 };
	var employeeB = new Employee() { Salary = 2 };
	var employeeC = new Employee() { Salary = 3 };

	departamentX.Add(departamentY);
	departamentX.Add(employeeA);

	departamentY.Add(employeeB);
	departamentY.Add(employeeC);
	departamentX.CalculateCost(); // outputs 6
}
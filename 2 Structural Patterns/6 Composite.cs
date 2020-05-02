Composite: Compose objects into tree structures to represent part-whole hierarchies. 
Composite lets clients treat individual objects and compositions of objects uniformly.
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
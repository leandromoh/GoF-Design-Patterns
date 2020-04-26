Proxy: Provide a surrogate or placeholder for another object to control access to it.
//https://www.dotnettricks.com/learn/designpatterns/proxy-design-pattern-dotnet

public interface ISubject
{
  void PerformAction();
}

public class RealSubject : ISubject
{
  public void PerformAction() => Console.WriteLine("RealSubject action performed.");
}

public class Proxy : ISubject
{
 private RealSubject _realSubject;
 public void PerformAction() => (_realSubject ??= new RealSubject()).PerformAction();
}
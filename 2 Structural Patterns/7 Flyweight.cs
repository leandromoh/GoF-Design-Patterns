Flyweight: Use sharing to support large numbers of fine-grained objects efficiently.
// https://www.dotnettricks.com/learn/designpatterns/flyweight-design-pattern-dotnet
// https://www.dofactory.com/net/flyweight-design-pattern

   static void Main()
    {
      // Arbitrary extrinsic state

      int extrinsicstate = 22;
 
      FlyweightFactory factory = new FlyweightFactory();
 
      // Work with different flyweight instances

      Flyweight fx = factory.GetFlyweight("X");
      fx.Operation(--extrinsicstate);
 
      Flyweight fy1 = factory.GetFlyweight("Y");
      fy1.Operation(--extrinsicstate);

      Flyweight fy2 = factory.GetFlyweight("Y");
      fy2.Operation(--extrinsicstate);
 
      Flyweight fu = new UnsharedConcreteFlyweight { Id = "A" };
      fu.Operation(--extrinsicstate);
    }

  class FlyweightFactory
  {
    private Hashtable flyweights = new Hashtable();
 
    public Flyweight GetFlyweight(string key)
    {
      if (flyweights.Contains(key))
        return (Flyweight)flyweights[key];

      var model = new ConcreteFlyweight { Id = key };
      flyweights.Add(key, model);
      return model;
    } 
  }
 
  abstract class Flyweight
  {
    public string Id { get; set; }
    public abstract void Operation(int extrinsicstate);
  }
 
  class ConcreteFlyweight : Flyweight
  {
    public override void Operation(int extrinsicstate) => 
      Console.WriteLine($"ConcreteFlyweight: {Id} {extrinsicstate}");
  }
 
  class UnsharedConcreteFlyweight : Flyweight
  {
    public override void Operation(int extrinsicstate) => 
      Console.WriteLine($"UnsharedConcreteFlyweight: {Id} {extrinsicstate}");
  }
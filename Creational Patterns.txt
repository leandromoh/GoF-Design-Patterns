https://pt.slideshare.net/ercarval/gof-design-patterns-12303484
https://www.dofactory.com/net/design-patterns

Creational Patterns

Simple Factory is a Factory class in its simplest form, compared to Factory Method Pattern or Abstract Factory Pattern, is a factory object for creating other objects. In simplelest terms Factory helps to keep all object creation in one place and avoid of spreading new keyword value across codebase, as well exposing the object creation logic.

    public class BookFactory
    {
        public IBook MakeBook(string title, string author, int pageCount)
        {
            return new PaperbackBook(title, author, pageCount);
        }
    }

Factory Method: Defines an interface for creating an object, but lets subclasses decide which class to instantiate. Factory Method lets a class defer instantiation to subclasses.

    public static class VehicleFactory
    {
        public static IVehicle Build(int numberOfWheels)
        {
            switch (numberOfWheels)
            {
                case 1:
                    return new UniCycle();
                case 2:
                case 3:
                    return new Motorbike();
                case 4:
                    return new Car();
                default :
                    return new Truck();
            }
        }
    }

Abstract Factory: Provide an interface for creating families of related or dependent objects without specifying their concrete classes.

  public class WindowsFactory : AbstractOperationSystemFactory
  {
    public override IButton CreateButton() => new WindowsButton();
    public override INotification CreateNotification() => new WindowsNotification();
  }

  public class UbuntuFactory : AbstractOperationSystemFactory
  {
    public override IButton CreateButton() => new UbuntuButton();
    public override INotification CreateNotification() => new UbuntuNotification();
  }

  AbstractOperationSystemFactory factory = new UbuntuFactory()

Builder: Separate the construction of a complex object from its representation so that the same construction process can create different representations.

        public async Task GivenACompanyHouseSearchClient_WhenSearchingForAOfficer()
        {
            var fixture = new Fixture();
            Person person = fixture.Build<Person>()
                                   .With(x => x.Name, "Bob")
                                   .With(x => x.Id, 13)
                                   .Create();

            var mockRepository = new Mock<IPersonRepository>();
            mockRepository.Setup(x => x.GetById(person.Id))
                          .Returns(person);

            IPersonRepository repository = mockRepository.Object;
        }
  
Singleton: Ensure a class has only one instance and provide a global point of access to it.

public class Person
{
   private static Person _instance = null;
   
   private Person() { }
   
   public static Person GetInstance()
   {
       if (_instance == null)
           _instance = new Spooler();

       return _instance;
   }
}

Prototype: Specify the kind of objects to create using a prototypical instance, and create new objects by copying this prototype.

        public static T DeepCopy<T>(this T source)
        {
            if (Object.ReferenceEquals(source, null))
                return default(T);

            var serializeSettings = new JsonSerializerSettings
            {
                ObjectCreationHandling = ObjectCreationHandling.Replace,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameHandling = TypeNameHandling.All
            };

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source, serializeSettings), serializeSettings);
        }

Singleton: Ensure a class has only one instance and provide a global point of access to it.

public class Person
{
   private static Person _instance = null;
   
   private Person() { }
   
   public static Person GetInstance()
   {
       if (_instance == null)
           _instance = new Person();

       return _instance;
   }
}
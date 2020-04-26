Simple Factory is a Factory class in its simplest form, compared to Factory Method Pattern or Abstract Factory Pattern, is a factory object for creating other objects. In simplelest terms Factory helps to keep all object creation in one place and avoid of spreading new keyword value across codebase, as well exposing the object creation logic.

public class BookFactory
{
    public IBook MakeBook(string title, string author, int pageCount)
    {
        return new PaperbackBook(title, author, pageCount);
    }
}
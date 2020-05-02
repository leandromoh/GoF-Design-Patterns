Visitor: Represent an operation to be performed on the elements of an object structure. Visitor lets you define a new operation without changing the classes of the elements on which it operates.

    abstract class Element
    {
        virtual void Accept(IVisitor visitor) => visitor.Visit(this);
    }

    interface IVisitor
    {
        void Visit(Element element);
    }

    var elements = new List<Element> { new ElementA(), new ElementB() };
    IVisitor visitor = new Visitor1(); 

    foreach (var e in elements)
    {
        e.Accept(visitor);
    }
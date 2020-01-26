Chain of Responsibility: Avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request. Chain the receiving objects and pass the request along the chain until an object handles it.
// https://www.dofactory.com/net/chain-of-responsibility-design-pattern


Command: Encapsulate a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations.

Iterator: Provide a way to access the elements of an aggregate object sequentially without exposing its underlying representation.
// C# interfaces IEnumerable<T> and IEnumerator<T>

Memento: Without violating encapsulation, capture and externalize an object's internal state so that the object can be restored to this state later.

Strategy: Define a family of algorithms, encapsulate each one, and make them interchangeable. Strategy lets the algorithm vary independently from clients that use it.

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
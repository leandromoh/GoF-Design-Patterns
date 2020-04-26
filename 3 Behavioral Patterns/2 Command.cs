Command: Encapsulate a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations.

using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    /*
    The classes and objects participating in this pattern are:

    - Invoker: contains the command(s) and asks the command(s) to execute the request
    - Receiver: knows how to perform the operations associated with carrying out the request.
    - Command: declares an interface for executing an operation
    - ConcreteCommand: defines a binding between a Receiver object and an action. Implements Execute by invoking the corresponding operation(s) on Receiver
    - Client: creates a ConcreteCommand object and sets its receiver

    */

    public class Program
    {
        static void Main(string[] args)
        {
            var garcon = new Garcon();
            var comanda = new Comanda();

            garcon.Invoke(Operation.Increase, "hamburger", 2); // hamburger = 2
            garcon.Invoke(Operation.Increase, "soda", 1); // soda = 1

            garcon.Invoke(Operation.Multiply, "soda", 2); // soda = 2
            garcon.Invoke(Operation.Increase, "soda", 1); // soda = 3
            garcon.Invoke(Operation.Increase, "hamburger", 1); // hamburger = 3

            garcon.Undo(levels: 3); // soda = 1 hamburger = 2
        }
    }


    public enum Operation
    {
        Increase = 1,
        Decrease = 2,
        Multiply = 3,
        Divide = 4,
    }

    public interface ICommand // Command
    {
        void Execute();
        void UnExecute();
    }

    public class Command : ICommand // ConcreteCommand
    {
        private readonly Comanda _comanda;
        private readonly int _quantity;
        private readonly string _product;
        private readonly Operation _operation;

        public Command(Comanda comanda, Operation operation, string product, int quantity) =>
          (_comanda, _operation, _product, _quantity) = (comanda, operation, product, quantity);

        public void Execute() => _comanda.Update(_operation, _product, _quantity);

        public void UnExecute() => _comanda.Update(Undo(_operation), _product, _quantity);

        private static Operation Undo(Operation op)
        {
            switch (op)
            {
                case Operation.Increase: return Operation.Decrease;
                case Operation.Decrease: return Operation.Increase;
                case Operation.Multiply: return Operation.Divide;
                case Operation.Divide: return Operation.Multiply;
                default: throw new InvalidOperationException("");
            }
        }
    }

    public class Comanda // Receiver
    {
        private Dictionary<string, int> Pedidos { get; set; } = new Dictionary<string, int>();

        public void Update(Operation operation, string product, int quantity)
        {
            var currentQuantity = Pedidos.TryGetValue(product, out var count) ? count : 0;

            var newQuantity = operation == Operation.Increase ? currentQuantity + quantity :
                              operation == Operation.Decrease ? currentQuantity - quantity :
                              operation == Operation.Multiply ? currentQuantity * quantity :
                              operation == Operation.Divide ? currentQuantity / quantity :
                              0;

            Pedidos[product] = newQuantity;
        }
    }

    public class Garcon // Invoker & Client
    {
        private List<Command> _commands { get; set; } = new List<Command>();
        private Comanda _comanda { get; set; } = new Comanda();

        public void Invoke(Operation operation, string product, int quantity)
        {
            var command = new Command(_comanda, operation, product, quantity);
            command.Execute();
            _commands.Add(command);
        }

        public void Undo(int levels)
        {
            foreach(var c in  _commands.TakeLast(levels).Reverse())
            {
                c.UnExecute();
                _commands.Remove(c);
            }
        }
    }
}
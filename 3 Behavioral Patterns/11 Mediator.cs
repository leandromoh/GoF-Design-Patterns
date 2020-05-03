Mediator: Define an object that encapsulates how a set of objects interact. 
Mediator promotes loose coupling by keeping objects from referring to each other explicitly, 
and it lets you vary their interaction independently.

// MediatR library deal with it

using System;
using System.Collections.Generic;

namespace DoFactory.GangOfFour.Mediator.RealWorld
{
    class MainApp
    {
        static void Main()
        {
            // Create chatroom

            Chatroom chatroom = new Chatroom();

            // Create participants and register them

            Participant George = new Beatle("George");
            Participant Paul = new Beatle("Paul");
            Participant Ringo = new Beatle("Ringo");
            Participant John = new Beatle("John");
            Participant Yoko = new NonBeatle("Yoko");

            chatroom.Register(George);
            chatroom.Register(Paul);
            chatroom.Register(Ringo);
            chatroom.Register(John);
            chatroom.Register(Yoko);

            // Chatting participants

            Yoko.Send("John", "Hi John!");
            Paul.Send("Ringo", "All you need is love");
            Ringo.Send("George", "My sweet Lord");
            Paul.Send("John", "Can't buy me love");
            John.Send("Yoko", "My sweet love");

            // outputs 
            // To a Beatle: Yoko to John: 'Hi John!'
            // To a Beatle: Paul to Ringo: 'All you need is love'
            // To a Beatle: Ringo to George: 'My sweet Lord'
            // To a Beatle: Paul to John: 'Can't buy me love'
            // To a non-Beatle: John to Yoko: 'My sweet love'
        }
    }

    abstract class AbstractChatroom // Mediator
    {
        public abstract void Register(Participant participant);
        public abstract void Send(string from, string to, string message);
    }

    class Chatroom : AbstractChatroom // ConcreteMediator
    {
        private Dictionary<string, Participant> _participants =
          new Dictionary<string, Participant>();

        public override void Register(Participant participant)
        {
            if (!_participants.ContainsValue(participant))
            {
                _participants[participant.Name] = participant;
            }

            participant.Chatroom = this;
        }

        public override void Send(string from, string to, string message) =>
            _participants[to].Receive(from, message);
    }

    class Participant // AbstractColleague
    {
        public string Name { get; }
        public Chatroom Chatroom { get; set; }

        public Participant(string name) =>
          Name = name;

        public void Send(string to, string message) =>
          Chatroom.Send(Name, to, message);

        public virtual void Receive(string from, string message) =>
          Console.WriteLine($"{from} to {Name}: '{message}'");
    }

    class Beatle : Participant // ConcreteColleague
    {
        public Beatle(string name) : base(name) { }

        public override void Receive(string from, string message)
        {
            Console.Write("To a Beatle: ");
            base.Receive(from, message);
        }
    }

    class NonBeatle : Participant // ConcreteColleague
    {
        public NonBeatle(string name) : base(name) { }

        public override void Receive(string from, string message)
        {
            Console.Write("To a non-Beatle: ");
            base.Receive(from, message);
        }
    }
}

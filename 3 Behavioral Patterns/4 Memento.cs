Memento: Without violating encapsulation, capture and externalize an object's 
internal state so that the object can be restored to this state later.


namespace ConsoleApp
{
    class MainApp
    {
        static void Main()
        {
            var s = new SalesProspect();
            s.Name = "Noel van Halen";
            s.Phone = "(412) 256-0990";
            s.Budget = 25000.0;

            // Store internal state

            var m = new ProspectMemory();
            m.Memento = s.SaveState();

            // Continue changing originator

            s.Name = "Leo Welch";
            s.Phone = "(310) 209-7111";
            s.Budget = 1000000.0;

            // Restore saved state

            s.RestoreState(m.Memento);
        }
    }

    class SalesProspect
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public double Budget { get; set; }

        public Memento SaveState() => new Memento(Name, Phone, Budget);

        public void RestoreState(Memento memento)
        {
            this.Name = memento.Name;
            this.Phone = memento.Phone;
            this.Budget = memento.Budget;
        }
    }

    class Memento
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public double Budget { get; set; }

        public Memento(string name, string phone, double budget)
        {
            this.Name = name;
            this.Phone = phone;
            this.Budget = budget;
        }

    }

    class ProspectMemory
    {
        public Memento Memento { get; set; }
    }
}

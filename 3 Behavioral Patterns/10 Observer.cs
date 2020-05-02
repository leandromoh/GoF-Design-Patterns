Observer: Define a one-to-many dependency between objects so that when one object changes state, 
all its dependents are notified and updated automatically.

// .net interfaces System.IObserver<T> and System.IObservable<T>

    class MainApp
    {
        static void Main()
        {
            // Create IBM stock and attach investors

            IBM ibm = new IBM("IBM", 120.00);
            ibm.Attach(new Investor("Sorros"));
            ibm.Attach(new Investor("Berkshire"));

            // Fluctuating prices will notify investors

            ibm.Price = 120.10;
            ibm.Price = 121.00;
            ibm.Price = 120.50;
            ibm.Price = 120.75;

            // outputs
            // Notified Sorros of IBM's change to $120.10
            // Notified Berkshire of IBM's change to $120.10            

            // Notified Sorros of IBM's change to $121.00
            // Notified Berkshire of IBM's change to $121.00

            // Notified Sorros of IBM's change to $120.50
            // Notified Berkshire of IBM's change to $120.50

            // Notified Sorros of IBM's change to $120.75
            // Notified Berkshire of IBM's change to $120.75
        }
    }

    abstract class Stock // Subject
    {
        public string Symbol { get; }
        private double _price;
        private readonly List<IInvestor> _investors = new List<IInvestor>();

        public Stock(string symbol, double price)
        {
            Symbol = symbol;
            _price = price;
        }

        public void Attach(IInvestor investor) => _investors.Add(investor);

        public void Detach(IInvestor investor) => _investors.Remove(investor);

        public void Notify()
        {
            foreach (IInvestor investor in _investors)
                investor.Update(this);

            Console.WriteLine("");
        }

        public double Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    Notify();
                }
            }
        }
    }

    class IBM : Stock // ConcreteSubject
    {
        public IBM(string symbol, double price)
          : base(symbol, price) { }
    }

    interface IInvestor // Observer
    {
        void Update(Stock stock);
    }

    class Investor : IInvestor // ConcreteObserver
    {
        public string Name { get; set; }
        public Stock Stock { get; set; }

        public Investor(string name) => Name = name;

        public void Update(Stock stock) =>
          Console.WriteLine($"Notified {Name} of {stock.Symbol}'s change to {stock.Price:C}");
    }

State: Allow an object to alter its behavior when its internal state changes. 
The object will appear to change its class.

    class Program
    {
        static void Main(string[] args)
        {
            var w = new Warrior();
            w.ShowHealth();

            for (int i = 0; i < 4; i++)
            {
                w.Battle();    
                w.ShowHealth();
            }

            // outputs
            // Warrior is now: Normal
            // Warrior is now: Weak
            // Warrior is now: Strong
            // Warrior is now: SuperStrong
            // Warrior is now: Normal
        }
    }

    public interface IHealth // State
    {
        void DoBattle(Warrior w);
    }

    public class Warrior // Context  
    {
        private IHealth health = new Normal();  //start as normal health

        public void Battle()
        {
            health.DoBattle(this);  //calls the health to exhibit the behavior
        }

        public void SetHealth(IHealth health)
        {
            this.health = health;
        }

        public void ShowHealth()
        {
            Console.WriteLine("Warrior is now: " + health.GetType().ToString());
        }
    }

    public class SuperStrong : IHealth
    {
        void IHealth.DoBattle(Warrior w)
        {
            //warrior can transition to another state based on the outcome
            w.SetHealth(new Normal());
        }
    }

    public class Strong : IHealth
    {
        void IHealth.DoBattle(Warrior w)
        {
            //warrior can transition to another state based on the outcome
            w.SetHealth(new SuperStrong());
        }
    }

    public class Normal : IHealth
    {
        void IHealth.DoBattle(Warrior w)
        {
            //warrior can transition to another state based on the outcome
            w.SetHealth(new Weak());
        }
    }

    public class Weak : IHealth
    {
        void IHealth.DoBattle(Warrior w)
        {
            //warrior can transition to another state based on the outcome
            w.SetHealth(new Strong());
        }
    }
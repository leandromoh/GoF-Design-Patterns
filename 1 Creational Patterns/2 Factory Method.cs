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
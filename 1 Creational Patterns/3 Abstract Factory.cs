Abstract Factory: Provide an interface for creating families of related or dependent objects without specifying their concrete classes.

  public class WindowsFactory : AbstractOperationSystemFactory
  {
    public override IButton CreateButton() => new WindowsButton();
    public override INotification CreateNotification() => new WindowsNotification();
  }

  public class UbuntuFactory : AbstractOperationSystemFactory
  {
    public override IButton CreateButton() => new UbuntuButton();
    public override INotification CreateNotification() => new UbuntuNotification();
  }

  AbstractOperationSystemFactory factory = new UbuntuFactory()
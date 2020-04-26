Adapter: Convert the interface of a class into another interface clients expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.

 class EmailNotifier
 {
   public void Send(string message, DateTime when) { }
 }

 class EmailNotifierAdapter : INotifier
 {
   private EmailNotifier _notifier = new EmailNotifier();
   public override void Nofity(string message) => _notifier.Send(message, DateTime.Now);
 }
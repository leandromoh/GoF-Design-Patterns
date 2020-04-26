Chain of Responsibility: Avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request. Chain the receiving objects and pass the request along the chain until an object handles it.
// Real-world example is .net core middleware

static void Main() {
	// Setup Chain of Responsibility

	Approver larry = new Director();
	Approver sam = new VicePresident();
	Approver tammy = new President();

	larry.SetSuccessor(sam);
	sam.SetSuccessor(tammy);

	// Generate and process the requests

	var p = new Purchase(number: 2034, amount: 150, purpose: "Assets");
	larry.ProcessRequest(p); // outputs VicePresident approved request# 2034
}

abstract class Approver {
	protected Approver successor;

	public void SetSuccessor(Approver successor) => this.successor = successor;

	public abstract void ProcessRequest(Purchase purchase);
}

class Director: Approver {
	public override void ProcessRequest(Purchase purchase) {
		if (purchase.Amount < 100) {
			Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
		}
		else if (successor != null) {
			successor.ProcessRequest(purchase);
		}
	}
}

class VicePresident: Approver {
	public override void ProcessRequest(Purchase purchase) {
		if (purchase.Amount < 200) {
			Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
		}
		else if (successor != null) {
			successor.ProcessRequest(purchase);
		}
	}
}

class President: Approver {
	public override void ProcessRequest(Purchase purchase) {
		if (purchase.Amount < 300) {
			Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
		}
		else {
			Console.WriteLine("Request# {0} requires an executive meeting!", purchase.Number);
		}
	}
}
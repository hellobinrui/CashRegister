namespace CashRegister
{
	public class Printer
	{
		public bool HasPrinted { get; set; } = false;
		public virtual void Print(string content)
		{
			HasPrinted = true;
			// send message to a real printer
		}
	}
}

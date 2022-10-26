namespace CashRegister
{
	public class SpyPrinter : Printer
	{
		public string PrintContent { get; set; }
		public bool HasPrinted { get; set; } = false;
		public override void Print(string content)
		{
			PrintContent = content;
			//base.Print(content);
			HasPrinted = true;
			// send message to a real printer
		}
	}
}

using System;

namespace CashRegister
{
	public class StubPurchase : Purchase
	{
		private readonly string content;

		public override string AsString()
		{
			return "stub content";
		}

		private string Timestamp()
		{
			return DateTime.Now.ToString("fff");
		}
	}
}

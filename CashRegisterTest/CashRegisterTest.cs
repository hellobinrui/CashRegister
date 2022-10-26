namespace CashRegisterTest
{
	using CashRegister;
	using Xunit;

	public class CashRegisterTest
	{
		//[Fact]
		//public void Should_process_execute_printing()
		//{
        //    //given
        //    var printer = new Printer();
        //    //var printer = new SpyPrinter();
        //    var cashRegister = new CashRegister(printer);
		//	var purchase = new Purchase();
		//	//when
		//	cashRegister.Process(purchase);
		//	//then
		//	//verify that cashRegister.process will trigger print
		//	Assert.True(printer.HasPrinted);
		//}
        //
        //[Fact]
        //public void Should_process_execute_printing_using_inherentence()
        //{
        //    //given
        //    var printer = new SpyPrinter();
        //    var cashRegister = new CashRegister(printer);
        //    var purchase = new Purchase();
        //    //when
        //    cashRegister.Process(purchase);
        //    //then
        //    //verify that cashRegister.process will trigger print
        //    Assert.True(printer.HasPrinted);
        //}

        [Fact]
        public void Should_process_execute_printing_using_interface()
        {
            //given
            var printer = new SkyPrinter();
            var cashRegister = new CashRegister(printer);
            var purchase = new Purchase();
            //when
            cashRegister.Process(purchase);
            //then
            //verify that cashRegister.process will trigger print
            Assert.True(printer.HasPrinted);
        }
    }
}

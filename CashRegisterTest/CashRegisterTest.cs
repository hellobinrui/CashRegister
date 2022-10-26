namespace CashRegisterTest
{
	using CashRegister;
    using Moq;
    using Xunit;

	public class CashRegisterTest
	{
		[Fact]
		public void Should_process_execute_printing()
		{
            //given
            SpyPrinter printer = new SpyPrinter();
            var cashRegister = new CashRegister(printer);
			var purchase = new Purchase();
			//when
			cashRegister.Process(purchase);
			//then
			//verify that cashRegister.process will trigger print
			Assert.True(printer.HasPrinted);
		}

        [Fact]
        public void Should_process_execute_printing_using_Moq()
        {
            //given
            var printer = new Mock<Printer>();
            var cashRegister = new CashRegister(printer.Object);
            var purchase = new Purchase();
            //when
            cashRegister.Process(purchase);
            //then
            //verify that cashRegister.process will trigger print
            printer.Verify(_ => _.Print(It.IsAny<string>()));
        }

        [Fact]
        public void Should_return_same_content_for_purchase_and_printer()
        {
            //given
            var printer = new SpyPrinter();
            var cashRegister = new CashRegister(printer);
            var stubpurchase = new StubPurchase();
            //when
            cashRegister.Process(stubpurchase);
            //then
            //verify that cashRegister.process will trigger print
            Assert.Equal("stub content", printer.PrintContent);
        }

        [Fact]
        public void Should_return_same_content_for_purchase_and_printer_using_Moq()
        {
            //given
            var printer = new Mock<Printer>();
            var cashRegister = new CashRegister(printer.Object);
            var stubpurchase = new Mock<Purchase>();
            stubpurchase.Setup(_ => _.AsString()).Returns("lalala");
            //when
            cashRegister.Process(stubpurchase.Object);
            //then
            //verify that cashRegister.process will trigger print
            printer.Verify(_ => _.Print("lalala"));
        }

        [Fact]
        public void Should_throw_hardwareException_given_stubPrinter_when_out_of_paper()
        {
            //given
            var printer = new StubPrinter();
            var cashRegister = new CashRegister(printer);
            var purchase = new Purchase();
            //when
            //then
            //verify that cashRegister.process will trigger print
            HardwareException hardwareException = Assert.Throws<HardwareException>(() => cashRegister.Process(purchase));
            Assert.Equal("Printer is out of paper.", hardwareException.Message);
        }

        // [Fact]
        // public void Should_process_execute_printing_using_inherentence()
        // {
        //     //given
        //     var printer = new SpyPrinter();
        //     var cashRegister = new CashRegister(printer);
        //     var purchase = new Purchase();
        //     //when
        //     cashRegister.Process(purchase);
        //     //then
        //     //verify that cashRegister.process will trigger print
        //     Assert.True(printer.HasPrinted);
        //     Assert.Equal( printer.PrintContent);
        // }

        // [Fact]
        // public void Should_process_execute_printing_using_interface()
        // {
        //     //given
        //     var printer = new SkyPrinter();
        //     var cashRegister = new CashRegister(printer);
        //     var purchase = new Purchase();
        //     //when
        //     cashRegister.Process(purchase);
        //     //then
        //     //verify that cashRegister.process will trigger print
        //     Assert.True(printer.HasPrinted);
        // }
    }
}

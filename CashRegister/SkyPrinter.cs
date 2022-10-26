using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    public class SkyPrinter : IPrinter
    {
        public bool HasPrinted { get; set; }
        public void Print(string content)
        {
            HasPrinted = true;
            Console.WriteLine(content);
        }
    }
}

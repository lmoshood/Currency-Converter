using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency {
    public class Menu {
        public Tuple<string,string,string> MenuStart() {
            Console.WriteLine("Currency Coverter");
            Console.WriteLine("1. Ammount: ");
            var ammount = Console.ReadLine();
            Console.WriteLine("2. Convert from: ");
            var from = Console.ReadLine();
            Console.WriteLine("3. Convert to: ");
            var to = Console.ReadLine();
            return new Tuple<string, string, string>(from, to, ammount);
        }
    }
}

using System;

namespace Currency {
    public class Menu {
        public Tuple<string, string, string> Choices() {
            Console.WriteLine("Currency Coverter");
            Console.WriteLine("1. Ammount: ");
            var ammount = Console.ReadLine();
            Console.WriteLine("2. Convert from: ");
            var from = Console.ReadLine();
            Console.WriteLine("3. Convert to: ");
            var to = Console.ReadLine();
            return new Tuple<string, string, string>(from, to, ammount);
        }
        public void HandleError(string baseAmmount) {
            var baseAmountConverted = baseAmmount.Trim('{', '}');
            if (baseAmountConverted.Length <= 0) {
                throw new Exception("You have not entered the right valuta");
            }
        }
    }
}

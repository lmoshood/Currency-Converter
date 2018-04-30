using System;

namespace Currency {
    class Client {
        static void Main(string[] args) {
            var menu = new Menu();
            var choices = menu.Choices();
            var currency = new Currency();
            var baseAmmount = currency.CallCurrencyBaseFromAPI(choices.Item1, choices.Item2).Result;
            menu.HandleError(baseAmmount);
            var conversionResult = currency.ConvertBaseToGivenAmmount(baseAmmount, choices.Item3, choices);
            Console.WriteLine("Result: " + conversionResult);
        }
    }
}

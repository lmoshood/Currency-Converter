using System;

namespace Currency {
    class Client {
        static void Main(string[] args) {
            var currency = new Currency();
            var currencies = currency.CallCurrenciesFromAPI();
            currency.PutCurrenciesInList(currencies.Result);
            var menu = new Menu();
            var choices = menu.Choices();
            var conversionBase = currency.CallCurrencyBaseFromAPI(choices.Item1, choices.Item2).Result;
            var conversionResult = currency.ConvertBaseToGivenAmmount(conversionBase, choices.Item3, choices);
            Console.WriteLine("Result: " + conversionResult);
        }
    }
}

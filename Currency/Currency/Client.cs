using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Currency {
    class Client {
        static void Main(string[] args) {
            var cur = new Currency();
            var currencies = cur.CallCurrenciesFromAPI();
            cur.PutCurrenciesInList(currencies.Result);
            var menu = new Menu();
            var choices = menu.MenuStart();
            var conversionBase = cur.CallCurrencyBaseFromAPI(choices.Item1, choices.Item2).Result;
            Console.WriteLine(conversionBase);
            var res= JsonConvert.DeserializeObject<Currencies>(conversionBase);
            Console.WriteLine("CONVERSION");
            Console.WriteLine(res.currencies);
            Console.WriteLine(res.currencies);
            var conversionResult = cur.ConvertBaseToGivenAmmount(JsonConvert.DeserializeObject<string>(conversionBase), choices.Item3);
            Console.WriteLine(conversionResult + " AMMOUNT");
        }
    }
}

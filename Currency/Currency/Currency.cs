using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using System.Dynamic;
using System.Globalization;

namespace Currency {
    public struct Currencies {
        public string currencies;
    }
    public class Currency {
        public List<string> currencies;
        public async Task<string> CallCurrenciesFromAPI() {
            var response = await new HttpClient().GetAsync("https://openexchangerates.org/api/currencies.json");
            if (response.IsSuccessStatusCode) {
                var responseConverted = response.Content.ReadAsStringAsync().Result.ToString();
                return responseConverted;
            }
            return Task.FromException(new Exception("Something went wrong..")).ToString();
        }
        public void PutCurrenciesInList(string currenciesFromAPI) {
            currencies = currenciesFromAPI.Split(',').ToList();
        }
        public async Task<string> CallCurrencyBaseFromAPI(string from, string to) {
            var response = await new HttpClient().GetAsync(String.Format("http://free.currencyconverterapi.com/api/v3/convert?q={0}_{1}&compact=ultra", from, to));
            if (response.IsSuccessStatusCode) {
                var responseConverted = response.Content.ReadAsStringAsync().Result.ToString();
                return responseConverted;
            }
            return Task.FromException(new Exception("Something went wrong..")).ToString();
        }
        public decimal ConvertBaseToGivenAmmount(string baseAmmount, string ammount, Tuple<string,string,string> choices) {
            var doubleDotIndex = baseAmmount.IndexOf(':') + 1;
            var baseAmmountSubString = baseAmmount.Substring(doubleDotIndex,baseAmmount.Length - doubleDotIndex - 1);
            var BasedAmountParsed = Decimal.Parse(baseAmmountSubString,new NumberFormatInfo { NumberDecimalSeparator = "." });
            return Decimal.Round(BasedAmountParsed * Decimal.Parse(ammount),2);        
        }
    }
}

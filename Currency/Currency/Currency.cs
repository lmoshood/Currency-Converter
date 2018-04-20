using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using System.Dynamic;

//https://docs.openexchangerates.org/docs/currencies-json
//Use expandoObject to dynamically create Object + attributes

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
        public int ConvertBaseToGivenAmmount(string baseAmmount, string ammount) {
            Console.WriteLine(baseAmmount);
            Console.WriteLine(baseAmmount.Length);
            return int.Parse(baseAmmount.Substring(5,baseAmmount.Length - 1)) * int.Parse(ammount);
            
        }
    }
}

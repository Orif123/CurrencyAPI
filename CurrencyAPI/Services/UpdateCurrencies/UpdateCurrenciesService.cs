using CurrencyAPI.Models.Entities;
using CurrencyAPI.Services.Repository;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace CurrencyAPI.Services.UpdateCurrencies
{
    public enum CurrencyList
    {
        USDILS,
        GBPEUR,
        EURJPY,
        EURUSD
    }
    public class UpdateCurrenciesService : IUpdateCurrenciesService
    {
        private string API_URL = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("APILinks")["API_URL"];


        public async Task UpdateCurrenciesAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var currList = Enum.GetValues(typeof(CurrencyList)).Cast<CurrencyList>();
                foreach (var item in currList)
                {
                    var from = item.ToString().Substring(0, 3);
                    var to = item.ToString().Substring(3, 3);
                    var fullName = String.Format("{0}/{1}", from, to);

                    var request = String.Format(API_URL, from, to);
                    var response = await httpClient.GetAsync(request);
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    var dto = JObject.Parse(jsonResponse)["result"]["rate"].ToString();
                    var valueNumber = Convert.ToDouble(dto);
                    Currency currency;
                    if (DBRepository.GetAll<Currency>().Count()>3)
                         currency = DBRepository.GetAll<Currency>().SingleOrDefault(p => p.Name == fullName);
                    else
                    {
                        currency = new Currency()
                        {
                            Name = fullName,
                            CurrentDatTime = DateTime.Now,

                            
                        };
                    }
                    currency.Value = valueNumber;
                    await DBRepository.AddOrUpdateAsync(currency);
                    
                }


            }

        }

    }
}

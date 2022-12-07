using CurrencyAPI.Models.Entities;
using CurrencyAPI.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyAPI.Services.GetAllCurrencies
{
    public class GetAllCurrenciesService : IGetAllCurrenciesService
    {
        
        public IEnumerable<Currency> GetAllCurrencies()
        {
            var currencies = DBRepository.GetAll<Currency>();
            return currencies;
        }
    }
}

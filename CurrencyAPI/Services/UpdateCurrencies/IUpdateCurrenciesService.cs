using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CurrencyAPI.Services.UpdateCurrencies
{
    public interface IUpdateCurrenciesService
    {
        /// <summary>
        /// Add the required <see cref="Models.Entities.Currency"/> from the API if the list is <see cref="null"/> 
        /// or update the list if not
        /// </summary>
        /// <returns></returns>
        Task UpdateCurrenciesAsync();
    }
}

using CurrencyAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyAPI.Services.GetAllCurrencies
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns>Returns the current currency as <see cref="IEnumerable{T}"></see></returns>
    public interface IGetAllCurrenciesService
    {
        IEnumerable<Currency>GetAllCurrencies();
    }
}

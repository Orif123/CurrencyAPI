using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyAPI.Models.Interfaces
{
    public interface IEntityWithId
    {
        Guid Id { get; set; }
    }
}

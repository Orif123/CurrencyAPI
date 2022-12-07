using CurrencyAPI.Models.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace CurrencyAPI.Models.Entities
{
    public partial class Currency : IEntityWithId
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Full name of the desired exchange in format of {From Currency}/{To Currency}
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Represents the current exchange value
        /// </summary>
        public double Value { get; set; }
        /// <summary>
        /// Represents The <see cref="DateTime"/> of the last update
        /// </summary>
        public DateTime CurrentDatTime { get; set; }
    }
}

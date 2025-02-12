using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Entities
{
    public interface IConvertation
    {
        public int Id { get; set; }
        int BaseCurrencyId { get; set; }
        int TradeCurrencyId { get; set; }
        decimal BaseCurrencyAmount { get; set; }
        decimal TradeCurrencyAmount { get; set; }
        bool ToTradeCurrency { get; set; }
        DateTime Date { get; set; }
    }
}

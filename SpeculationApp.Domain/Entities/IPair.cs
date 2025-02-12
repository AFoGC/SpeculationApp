using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Entities
{
    public interface IPair
    {
        int BaseCurrencyId { get; set; }
        int TradeCurrencyId { get; set; }
        int PositionInList { get; set; }
    }
}

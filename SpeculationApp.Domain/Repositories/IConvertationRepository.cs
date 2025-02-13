using SpeculationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Repositories
{
    public interface IConvertationRepository : IRepository<Convertation>
    {
        IEnumerable<Convertation> GetBaseCurrencyConvertations(int baseCurrencyId);
        IEnumerable<Convertation> GetTradeCurrencyConvertations(int tradeCurrencyId);
    }
}

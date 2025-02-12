using SpeculationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Repositories
{
    public interface IConvertationRepository : IRepository<IConvertation>
    {
        IEnumerable<IConvertation> GetBaseCurrencyConvertations(int baseCurrencyId);
        IEnumerable<IConvertation> GetTradeCurrencyConvertations(int tradeCurrencyId);
    }
}

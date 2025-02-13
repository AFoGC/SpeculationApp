using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculationApp.Domain.Repositories
{
    public interface IUnitOfWork
    {
        ICurrencyRepository Currencies { get; }
        IConvertationRepository Convertations { get; }
        IOperationRepository Operations { get; }
        IOperationTypeRepository OperationTypes { get; }
        IPairRepository Pairs { get; }
        void Complete();
    }
}

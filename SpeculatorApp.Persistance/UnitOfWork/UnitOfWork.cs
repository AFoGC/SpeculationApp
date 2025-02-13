using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Persistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UnitOfWorkSettings _settings;

        public UnitOfWork(UnitOfWorkSettings settings)
        {
            _settings = settings;

            Currencies = new CurrencyRepository();
            Convertations = new ConvertationRepository();
            Operations = new OperationRepository();
            OperationTypes = new OperationTypeRepository();
            Pairs = new PairRepository();
        }

        public ICurrencyRepository Currencies { get; }
        public IConvertationRepository Convertations { get; }
        public IOperationRepository Operations { get; }
        public IOperationTypeRepository OperationTypes { get; }
        public IPairRepository Pairs { get; }

        public void Complete()
        {
            throw NotImplementedException();
        }
    }
}

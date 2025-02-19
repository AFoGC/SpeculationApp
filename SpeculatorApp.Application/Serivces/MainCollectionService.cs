using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Serivces
{
    public class MainCollectionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MainCollectionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            CurrencyViewModelFactory currencyFactory = new CurrencyViewModelFactory(unitOfWork, this);
            PairViewModelFactory pairFactory = new PairViewModelFactory(unitOfWork, this);
            ConvertationViewModelFactory convertationFactory = new ConvertationViewModelFactory(unitOfWork, this);
            OperationViewModelFactory operationFactory = new OperationViewModelFactory(unitOfWork, this);
            OperationTypeViewModelFactory operationTypeFactory = new OperationTypeViewModelFactory(unitOfWork, this);

            CurrencyCollection = new CurrencyCollectionService(unitOfWork, currencyFactory);
            PairCollection = new PairCollectionService(unitOfWork, pairFactory);
            ConvertationCollection = new ConvertationCollectionService(unitOfWork, convertationFactory);
            OperationCollection = new OperationCollectionService(unitOfWork, operationFactory);
            OperationTypeCollection = new OperationTypeCollectionService(unitOfWork, operationTypeFactory);
        }

        public CurrencyCollectionService CurrencyCollection { get; }
        public PairCollectionService PairCollection { get; }
        public ConvertationCollectionService ConvertationCollection { get; }
        public OperationCollectionService OperationCollection { get; }
        public OperationTypeCollectionService OperationTypeCollection { get; }
    }
}

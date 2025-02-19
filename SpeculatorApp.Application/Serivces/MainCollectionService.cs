using SpeculationApp.Domain.Repositories;
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

            //CurrencyCollection = new CurrencyCollectionService();
            //PairCollection = new PairCollectionService();
            //ConvertationCollection = new ConvertationCollectionService();
            //OperationCollection = new OperationCollectionService();
            //OperationTypeCollection = new OperationTypeCollectionService();
        }

        public CurrencyCollectionService CurrencyCollection { get; }
        public PairCollectionService PairCollection { get; }
        public ConvertationCollectionService ConvertationCollection { get; }
        public OperationCollectionService OperationCollection { get; }
        public OperationTypeCollectionService OperationTypeCollection { get; }
    }
}

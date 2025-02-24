using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.Tables.ViewModels;
using SpeculatorApp.Application.Tables.Serivces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Tables.Strategies
{
    public class CurrencyStrategy
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly Func<OperationCollectionService> _getOperations;
        private readonly Func<CurrencyCollectionService> _getCurrencies;

        private readonly int _currencyId;

        private CurrencyOperations? _currencyOperations;

        public CurrencyStrategy(IUnitOfWork unitOfWork, MainCollectionService mainCollectionService, int currencyId)
        {
            _unitOfWork = unitOfWork;
            _currencyId = currencyId;

            _getCurrencies = () => mainCollectionService.CurrencyCollection;
            _getOperations = () => mainCollectionService.OperationCollection;
        }

        public CurrencyOperations Operations
        {
            get
            {
                if (_currencyOperations == null)
                {
                    var operations = _getOperations.Invoke();
                    _currencyOperations = operations.GetOperations(_currencyId);
                }

                return _currencyOperations;
            }
        }

        public decimal TotalAmount
        {
            get
            {
                return 0;
            }
        }

        public void AddOperation(OperationEntity model)
        {
            Operations.AddOperation(model);
        }

        public void Remove(CurrencyViewModel viewModel)
        {
            var currencies = _getCurrencies.Invoke();
            currencies.Remove(viewModel);
        }

        public void Update(CurrencyEntity model)
        {
            _unitOfWork.Currencies.Update(model);
            _unitOfWork.Complete();
        }
    }
}

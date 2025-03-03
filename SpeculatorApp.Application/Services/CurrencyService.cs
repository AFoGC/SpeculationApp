using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
using SpeculatorApp.Application.Factories;
using SpeculatorApp.Application.Stores;
using SpeculatorApp.Application.ViewModels.EditViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Services
{
    public class CurrencyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ReadTablesStore _tablesStore;
        private readonly EditViewModelFactory _factory;

        public CurrencyService(IUnitOfWork unitOfWork, ReadTablesStore tablesStore, EditViewModelFactory factory)
        {
            _unitOfWork = unitOfWork;
            _tablesStore = tablesStore;
            _factory = factory;
        }

        public CurrencyEditViewModel LoadCurrency(int currencyId)
        {
            IEnumerable<OperationTypeReadViewModel> operationTypes = _tablesStore.OperationTypes;
            CurrencyModel model = _unitOfWork.Currencies.GetById(currencyId);

            var operations = _unitOfWork.Operations
                .GetAll(currencyId)
                .Select(x => _factory.CreateOperation(x, operationTypes));

            return _factory.CreateCurrency(model, operations);
        }

        public void UpdateCurrency(CurrencyEditViewModel viewModel)
        {
            CurrencyModel currency = viewModel.GetModel();
            IEnumerable<OperationModel> operations = viewModel.Operations
                .Where(x => x.IsChanged)
                .Select(x => x.GetModel());

            bool isChanged = viewModel.IsChanged || operations.Count() > 0;

            if (viewModel.IsChanged)
            {
                _unitOfWork.Currencies.Update(currency);
            }
            
            foreach (var operation in operations)
            {
                _unitOfWork.Operations.Update(operation);
            }

            if (isChanged)
            {
                _unitOfWork.Complete();
                UpdateViewModels(viewModel);
            }
        }

        private void UpdateViewModels(CurrencyEditViewModel viewModel)
        {
            var currency = _tablesStore.Currencies.Single(x => x.Id == viewModel.Id);
            currency.RefreshData();
        }
    }
}

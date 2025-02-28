using SpeculationApp.Domain.Entities;
using SpeculationApp.Domain.Repositories;
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

        public CurrencyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CurrencyEditViewModel LoadCurrency(int currencyId, IEnumerable<OperationTypeReadViewModel> operationTypes)
        {
            CurrencyModel model = _unitOfWork.Currencies.GetById(currencyId);

            var operations = _unitOfWork.Operations
                .GetAll(currencyId)
                .Select(x => CreateOperation(x, operationTypes));

            return new CurrencyEditViewModel(model, operations);
        }

        public IEnumerable<OperationTypeReadViewModel> LoadOperationTypes()
        {
            return _unitOfWork.OperationTypes
                .GetAll()
                .Select(x => new OperationTypeReadViewModel(_unitOfWork, x));
        }

        public bool UpdateCurrency(CurrencyEditViewModel viewModel)
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

            _unitOfWork.Complete();
            return isChanged;
        }

        public OperationEditViewModel CreateOperation(OperationModel model, IEnumerable<OperationTypeReadViewModel> operationTypes)
        {
            return new OperationEditViewModel(model, operationTypes);
        }
    }
}
